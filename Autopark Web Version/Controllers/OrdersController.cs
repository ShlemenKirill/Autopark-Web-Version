using Autopark_Web_Version.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Autopark_Web_Version.Models.Interfaces;
using Autopark_Web_Version.Models;
using System.Threading.Tasks;

namespace Autopark_Web_Version.Controllers
{
    public class OrdersController : Controller
    {
        readonly IVVenicleRepository<VOrders> ordersView;
        readonly IOrdersRepository<Orders> orders;
        readonly IVenicleRepository<Venicles> venicles;
        public OrdersController(IVVenicleRepository<VOrders> ordersView, IOrdersRepository<Orders> orders, IVenicleRepository<Venicles> venicles)
        {
            this.ordersView = ordersView;
            this.orders = orders;
            this.venicles = venicles;
        }
        public async Task<ActionResult> Index()
        {
            return View(await ordersView.GetAll());
        }

        public async Task<ActionResult> Create()
        {
            ViewBag.Venicles = await venicles.GetAll();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Orders newOrder)
        {
            await orders.Create(newOrder);
            return RedirectToAction("Index");
        }
    }
}
