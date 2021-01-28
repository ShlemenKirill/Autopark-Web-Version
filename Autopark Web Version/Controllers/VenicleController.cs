using Autopark_Web_Version.Models;
using Autopark_Web_Version.Models.Interfaces;
using Autopark_Web_Version.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autopark_Web_Version.Controllers
{
    public class VenicleController : Controller
    {
        IVenicleRepository<Venicles> veniclesRepository;
        IVVenicleRepository<VVEnicles> veniclesViewRepository;
        public VenicleController(IVenicleRepository<Venicles> veniclesRepository, IVVenicleRepository<VVEnicles> veniclesViewRepository)
        {
            this.veniclesRepository = veniclesRepository;
            this.veniclesViewRepository = veniclesViewRepository;
        }

        public async Task<ActionResult> Index(string sortParam)
        {            
            ViewBag.VenicleTypeSortParam = sortParam == "VenicleType" ? "VenicleType_desc" : "VenicleType";
            ViewBag.ModelNameSortParam = sortParam == "ModelName" ? "ModelName_desc" : "ModelName";
            ViewBag.MileageSortParam = sortParam == "Mileage" ? "Mileage_desc" : "Mileage";            

            var sort = await veniclesViewRepository.GetAll();
            if (sortParam != null)
            {
                sort = await veniclesViewRepository.SortBy(sortParam);
            }
            return View(sort.ToList());            
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Venicles venicles)
        {
            await veniclesRepository.Create(venicles);
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Edit(int id)
        {
            Venicles venicles = await veniclesRepository.Get(id);
            if (venicles != null)
                return View(venicles);
            return NotFound();            
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Venicles venicles)
        {
            await veniclesRepository.Update(venicles);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<ActionResult> ConfirmDelete(int id)
        {
            Venicles venicles = await veniclesRepository.Get(id);
            if (venicles != null)
                return View(venicles);
            return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            await veniclesRepository.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Details")]
        public async Task<ActionResult> Details(int id)
        {
            Venicles venicles = await veniclesRepository.Get(id);
            veniclesRepository.CalculateTaxPerMounth(id);
            ViewData["TaxPerMounth"] = veniclesRepository.CalculateTaxPerMounth(id);
            ViewData["MaxKilometers"] = veniclesRepository.CalculateMaxKilometers(id);
            if (venicles != null)
                return View(venicles);
            return NotFound();
        }


    }
}
