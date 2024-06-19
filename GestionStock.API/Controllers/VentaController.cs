using Microsoft.AspNetCore.Mvc;

namespace GestionStockAPI.Controllers
{

    public class VentaController : Controller
    {

        private readonly ILogger<VentaController> _logger;

        private readonly VentaBusinnes _ventaBusinnes;

        public VentaController(VentaBusinnes ventaBusinnes,
            ILogger<VentaController> logger)
        {
            _logger = logger;

            //Para hacer Inyección de dependencias

            _ventaBusinnes = ventaBusinnes;
        }
        public IActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "name";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            var ventas = _ventaBusinnes.GetAll(sortOrder);

            return View(ventas);
        }

        public IActionResult Cargar()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Cargar(Venta venta)
        {
          
            var response = _ventaBusinnes.Create(venta);
            if (response)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

    }
}
