using Autopark_Web_Version.Models;
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
        public VenicleController(IVenicleRepository<Venicles> r)
        {
            repo = r;
        }

        public ActionResult Index(string sortParam)
        {            
            ViewBag.VeniclesTypeSortParam = sortParam == "VeniclesType" ? "VeniclesType_desc" : "VeniclesType";
            ViewBag.EngineSortParam = sortParam == "Engine" ? "Engine_desc" : "Engine";
            ViewBag.ModelNameSortParam = sortParam == "ModelName" ? "ModelName_desc" : "ModelName";
            ViewBag.RegistrationNumberSortParam = sortParam == "RegistrationNumber" ? "RegistrationNumber_desc" : "RegistrationNumber";
            ViewBag.WeightSortParam = sortParam == "Weight" ? "Weight_desc" : "Weight";
            ViewBag.YearSortParam = sortParam == "Year" ? "Year_desc" : "Year";
            ViewBag.ColorSortParam = sortParam == "Color" ? "Color_desc" : "Color";            
            ViewBag.MileageSortParam = sortParam == "Mileage" ? "Mileage_desc" : "Mileage";
            ViewBag.TankSortParam = sortParam == "Tank" ? "Tank_desc" : "Tank";

            var sort = repo.GetAll();
            if (sortParam != null)
            {
                sort = repo.SortBy(sortParam);
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
            if (venicles != null)
                return View(venicles);
            return NotFound();
        }


    }
}
