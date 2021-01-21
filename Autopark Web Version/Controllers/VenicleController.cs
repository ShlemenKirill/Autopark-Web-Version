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
        IReadOnlyRepository<VVEnicles> type;
        public VenicleController(IVenicleRepository<Venicles> r, IReadOnlyRepository<VVEnicles> t)
        {
            repo = r;
            type = t;
        }

        public ActionResult Index(string sortParam)
        {            
            ViewBag.VenicleTypeSortParam = sortParam == "VenicleType" ? "VenicleType_desc" : "VenicleType";
            ViewBag.ModelNameSortParam = sortParam == "ModelName" ? "ModelName_desc" : "ModelName";
            ViewBag.MileageSortParam = sortParam == "Mileage" ? "Mileage_desc" : "Mileage";            

            var sort = type.GetAll();
            if (sortParam != null)
            {
                sort = type.SortBy(sortParam);
            }
            return View(sort.ToList());            
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Venicles venicles)
        {
            repo.Create(venicles);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            Venicles venicles = repo.Get(id);
            if (venicles != null)
                return View(venicles);
            return NotFound();
        }

        [HttpPost]
        public ActionResult Edit(Venicles venicles)
        {
            repo.Update(venicles);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            Venicles venicles = repo.Get(id);
            if (venicles != null)
                return View(venicles);
            return NotFound();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Details")]
        public ActionResult Details(int id)
        {
            Venicles venicles = repo.Get(id);
            repo.CalculateTaxPerMounth(id);
            ViewData["TaxPerMounth"] = repo.CalculateTaxPerMounth(id);
            ViewData["MaxKilometers"] = repo.CalculateMaxKilometers(id);
            if (venicles != null)
                return View(venicles);
            return NotFound();
        }


    }
}
