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

        public ActionResult Index()
        {
            return View(repo.GetAll());
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
