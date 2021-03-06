﻿using Autopark_Web_Version.Models;
using Autopark_Web_Version.Models.Interfaces;
using Autopark_Web_Version.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Autopark_Web_Version.Controllers
{
    public class OrderDetailsController : Controller
    {
        readonly IOrderDetailsRepository<OrderDetails> orderDetails;
        readonly IDetailsRepository<Details> details;
        readonly IOrdersRepository<Orders> orders;
        public OrderDetailsController(IOrderDetailsRepository<OrderDetails> orderDetails, IDetailsRepository<Details> details, IOrdersRepository<Orders> orders)
        {
            this.orderDetails = orderDetails;            
            this.details = details;
            this.orders = orders;
        }        

        public async Task<ActionResult> Create(int id)
        {
            ViewBag.Details = await details.GetAll();
            ViewBag.Order = await orders.Get(id);
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(OrderDetails newOrder)
        {
            await orderDetails.Create(newOrder);
            return Redirect("/Orders/Index");
        }

        [HttpGet]        
        public async Task<ActionResult> Details(int id)
        {
            ViewBag.Details = await details.GetAll();
            var currentOrderDetails = await orderDetails.GetAllByOrderId(id);
            if (orderDetails != null)
                return View(currentOrderDetails);
            return NotFound();
        }
    }
}
