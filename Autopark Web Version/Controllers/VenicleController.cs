using Autopark_Web_Version.Models;
using Autopark_Web_Version.Models.Interfaces;
using Autopark_Web_Version.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Autopark_Web_Version.Controllers
{
    public class VenicleController : Controller
    {
        readonly IVenicleRepository<Venicles> veniclesRepository;
        readonly IVVenicleRepository<VVEnicles> veniclesViewRepository;
        public VenicleController(IVenicleRepository<Venicles> veniclesRepository, IVVenicleRepository<VVEnicles> veniclesViewRepository)
        {
            this.veniclesRepository = veniclesRepository;
            this.veniclesViewRepository = veniclesViewRepository;
        }

        public async Task<ActionResult> Index(string sortingParameter)
        {            
            ViewBag.VenicleTypeSortParam = sortingParameter == "VenicleType" ? "VenicleType_desc" : "VenicleType";
            ViewBag.ModelNameSortParam = sortingParameter == "ModelName" ? "ModelName_desc" : "ModelName";
            ViewBag.MileageSortParam = sortingParameter == "Mileage" ? "Mileage_desc" : "Mileage";            

            var sortingResult = await veniclesViewRepository.GetAll();

            if (sortingParameter != null)
            {
                sortingResult = await veniclesViewRepository.SortBy(sortingParameter);
            }

            return View(sortingResult.ToList());            
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Venicles venicles)
        {
            await veniclesRepository.Create(venicles);
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Edit(int id)
        {
            Venicles venicles = await veniclesRepository.Get(id);

            if (venicles != null)
                return View(venicles);
            return NotFound();            
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Venicles venicles)
        {
            await veniclesRepository.Update(venicles);
            return RedirectToAction("Index");
        }

        [HttpGet]        
        public async Task<ActionResult> ConfirmDelete(int id)
        {
            Venicles venicles = await veniclesRepository.Get(id);

            if (venicles != null)
                return View(venicles);
            return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            await veniclesRepository.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]       
        public async Task<ActionResult> Details(int id)
        {
            Venicles venicles = await veniclesRepository.Get(id);            
            ViewData["TaxPerMounth"] = veniclesRepository.CalculateTaxPerMounth(id);
            ViewData["MaxKilometers"] = veniclesRepository.CalculateMaxKilometers(id);

            if (venicles != null)
                return View(venicles);
            return NotFound();
        }


    }
}
