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
        IRepository<Venicles> repo;
        public VenicleController(IRepository<Venicles> r)
        {
            repo = r;
        }

        public ActionResult Index(string sortParam)
        {
            ViewBag.VeniclesTypeSortParam = String.IsNullOrEmpty(sortParam) ? "VeniclesType" : "";
            ViewBag.EngineSortParam = String.IsNullOrEmpty(sortParam) ? "Engine" : "";
            ViewBag.ModelNameSortParam = String.IsNullOrEmpty(sortParam) ? "ModelName" : "";
            ViewBag.RegistrationNumberSortParam = String.IsNullOrEmpty(sortParam) ? "RegistrationNumber" : "";
            ViewBag.WeightSortParam = String.IsNullOrEmpty(sortParam) ? "Weight" : "";
            ViewBag.YearSortParam = String.IsNullOrEmpty(sortParam) ? "Year" : "";
            ViewBag.ColorSortParam = String.IsNullOrEmpty(sortParam) ? "Color" : "";
            ViewBag.MileageSortParam = String.IsNullOrEmpty(sortParam) ? "Mileage" : "";
            ViewBag.TankSortParam = String.IsNullOrEmpty(sortParam) ? "Tank" : "";           

            if (sortParam != null)
            {
                return View(repo.SortBy(sortParam).ToList());
            }        
            
            return View(repo.GetAll().ToList());
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


    }
}
