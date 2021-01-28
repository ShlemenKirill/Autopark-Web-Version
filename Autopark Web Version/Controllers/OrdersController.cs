using Autopark_Web_Version.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Autopark_Web_Version.Models.Interfaces;
using Autopark_Web_Version.Models;
using System.Threading.Tasks;

namespace Autopark_Web_Version.Controllers
{
    public class OrdersController : Controller
    {
        IVVenicleRepository<VOrders> ordersView;
        IOrdersRepository<Orders> orders;
        IVenicleRepository<Venicles> venicle;
        public OrdersController(IVVenicleRepository<VOrders> ordersView, IOrdersRepository<Orders> orders, IVenicleRepository<Venicles> venicle)
        {
            this.ordersView = ordersView;
            this.orders = orders;
            this.venicle = venicle;
        }
        public async Task<ActionResult> Index()
        {
            return View(await ordersView.GetAll());
        }

        public async Task<ActionResult> Create()
        {
            ViewBag.Venicles = await venicle.GetAll();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Orders order)
        {
            await orders.Create(order);
            return RedirectToAction("Index");
        }
    }
}
