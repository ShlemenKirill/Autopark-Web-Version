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
        readonly IDetailsRepository<Details> details;        
        public DetailsController(IDetailsRepository<Details> details)
        {
            this.details = details;            
        }

        public async Task<ActionResult> Index()
        {      
            return View(await details.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Details newDetail)
        {
            await details.Create(newDetail);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int id)
        {
            var currentDetail = await details.Get(id);
            if (currentDetail != null)
                return View(currentDetail);
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Details editedDetail)
        {
            await details.Update(editedDetail);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<ActionResult> ConfirmDelete(int id)
        {
            var deletingDetail = await details.Get(id);
            if (deletingDetail != null)
                return View(deletingDetail);
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            await details.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]        
        public async Task<ActionResult> Details(int id)
        {
            var currentDetail = await details.Get(id);            
            if (currentDetail != null)
                return View(currentDetail);
            return NotFound();
        }
    }
}
