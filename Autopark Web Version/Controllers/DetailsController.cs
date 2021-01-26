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

        public async Task<ActionResult> Index()
        {      
            return View(await repo.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Details details)
        {
            await repo.Create(details);
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Edit(int id)
        {
            Details details = await repo.Get(id);
            if (details != null)
                return View(details);
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Details details)
        {
            await repo.Update(details);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<ActionResult> ConfirmDelete(int id)
        {
            Details details = await repo.Get(id);
            if (details != null)
                return View(details);
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
            Details details = await repo.Get(id);            
            if (details != null)
                return View(details);
            return NotFound();
        }
    }
}
