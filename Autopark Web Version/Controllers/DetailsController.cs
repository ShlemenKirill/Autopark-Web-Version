using Autopark_Web_Version.Models;
using Autopark_Web_Version.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autopark_Web_Version.Controllers
{
    public class DetailsController : Controller
    {
        IDetailsRepository<Details> repo;        
        public DetailsController(IDetailsRepository<Details> r)
        {
            repo = r;            
        }

        public ActionResult Index()
        {         
            
            return View(repo.GetAll());
        }        

        [HttpPost]
        public ActionResult Create(Details details)
        {
            repo.Create(details);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            Details details = repo.Get(id);
            if (details != null)
                return View(details);
            return NotFound();
        }

        [HttpPost]
        public ActionResult Edit(Details details)
        {
            repo.Update(details);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            Details details = repo.Get(id);
            if (details != null)
                return View(details);
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
            Details details = repo.Get(id);            
            if (details != null)
                return View(details);
            return NotFound();
        }
    }
}
