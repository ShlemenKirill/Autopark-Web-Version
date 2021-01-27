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
        IVenicleRepository<Venicles> repo;
        IVVeniclesRepository<VVEnicles> type;
        public VenicleController(IVenicleRepository<Venicles> r, IVVeniclesRepository<VVEnicles> t)
        {
            repo = r;
            type = t;
        }

        public async Task<ActionResult> Index(string sortParam)
        {            
            ViewBag.VenicleTypeSortParam = sortParam == "VenicleType" ? "VenicleType_desc" : "VenicleType";
            ViewBag.ModelNameSortParam = sortParam == "ModelName" ? "ModelName_desc" : "ModelName";
            ViewBag.MileageSortParam = sortParam == "Mileage" ? "Mileage_desc" : "Mileage";            

            var sort = await type.GetAll();
            if (sortParam != null)
            {
                sort = await type.SortBy(sortParam);
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
            await repo.Create(venicles);
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Edit(int id)
        {
            Venicles venicles = await repo.Get(id);
            if (venicles != null)
                return View(venicles);
            return NotFound();            
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Venicles venicles)
        {
            await repo.Update(venicles);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<ActionResult> ConfirmDelete(int id)
        {
            Venicles venicles = await repo.Get(id);
            if (venicles != null)
                return View(venicles);
            return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            await repo.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Details")]
        public async Task<ActionResult> Details(int id)
        {
            Venicles venicles = await repo.Get(id);            
            ViewData["TaxPerMounth"] = await repo.CalculateTaxPerMounth(id);
            ViewData["MaxKilometers"] = await repo.CalculateMaxKilometers(id);
            if (venicles != null)
                return View(venicles);
            return NotFound();
        }


    }
}
