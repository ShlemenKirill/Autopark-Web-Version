using Autopark_Web_Version.Models.Interfaces;
using Autopark_Web_Version.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autopark_Web_Version.Controllers
{
    public class OrderDetailsController : Controller
    {
        IOrderDetailsRepository<OrderDetails> repo;
        public OrderDetailsController(IOrderDetailsRepository<OrderDetails> r)
        {
            repo = r;
        }        

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(OrderDetails orderDetails)
        {
            repo.Create(orderDetails);            
            return RedirectToPage("Orders/Index");
        }

        [HttpGet]
        [ActionName("Details")]
        public ActionResult Details(int id)
        {
            List<OrderDetails> orderDetails = repo.Get(id);
            if (orderDetails != null)
                return View(orderDetails);
            return NotFound();
        }
    }
}
