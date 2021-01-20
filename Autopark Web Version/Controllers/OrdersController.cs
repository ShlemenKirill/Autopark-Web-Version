using Autopark_Web_Version.Models.Models;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult Index()
        {
            return View(repo.GetAll());
        }
    }
}
