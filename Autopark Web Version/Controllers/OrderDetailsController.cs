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
    public class OrderDetailsController : Controller
    {
        IOrderDetailsRepository<OrderDetails> orderDetails;        
        IDetailsRepository<Details> details;
        IOrdersRepository<Orders> orders;
        public OrderDetailsController(IOrderDetailsRepository<OrderDetails> orderDetails, IDetailsRepository<Details> details, IOrdersRepository<Orders> orders)
        {
            this.orderDetails = orderDetails;            
            this.details = details;
            this.orders = orders;
        }        

        public ActionResult Create(int id)
        {
            ViewBag.Details = details.GetAll();
            ViewBag.Order = orders.Get(id);
            return View();
        }

        [HttpPost]
        public ActionResult Create(OrderDetails orderDetail)
        {
            orderDetails.Create(orderDetail);
            return Redirect("/Orders/Index");
        }

        [HttpGet]
        [ActionName("Details")]
        public ActionResult Details(int id)
        {
            ViewBag.Details = details.GetAll();
            var orderDetail = orderDetails.GetAllByOrderId(id);
            if (orderDetails != null)
                return View(orderDetail);
            return NotFound();
        }
    }
}
