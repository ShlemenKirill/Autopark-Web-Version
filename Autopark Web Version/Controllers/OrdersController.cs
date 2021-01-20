using Autopark_Web_Version.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
using Autopark_Web_Version.Models.Interfaces;

namespace Autopark_Web_Version.Controllers
{
    public class OrdersController : Controller
    {
        IOrdersRepository<Orders> repo;
        public OrdersController(IOrdersRepository<Orders> r)
        {
            repo = r;
        }
        public IActionResult Index()
        {
            return View(repo.GetAll());
        }
    }
}
