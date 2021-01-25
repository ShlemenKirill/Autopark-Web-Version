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
        IVOrderDetailsRepository<VOrderDetails> details;
        public OrderDetailsController(IOrderDetailsRepository<OrderDetails> r, IVOrderDetailsRepository<VOrderDetails> det)
        {
            repo = r;
            details = det;
        }        

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(OrderDetails orderDetails)
        {
            repo.Create(orderDetails);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Details")]
        public ActionResult Details(int id)
        {
            IEnumerable<VOrderDetails> orderDetails = details.GetAllById(id);
            if (orderDetails != null)
                return View(orderDetails);
            return NotFound();
        }
    }
}
