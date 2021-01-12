using Autopark_Web_Version.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Autopark_Web_Version.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }        
        public ActionResult Privacy()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult Orders()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
