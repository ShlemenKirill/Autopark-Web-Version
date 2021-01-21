using Autopark_Web_Version.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Autopark_Web_Version.Models.Interfaces;

namespace Autopark_Web_Version.Controllers
{
    public class OrdersController : Controller
    {
        IReadOnlyRepository<VOrders> repo;
        IOrdersRepository<Orders> orders;
        public OrdersController(IReadOnlyRepository<VOrders> r, IOrdersRepository<Orders> ord)
        {
            repo = r;
            orders = ord;
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
        public ActionResult Create(Orders order)
        {
            
            orders.Create(order);
            return RedirectToAction("Index");
        }
    }
}
