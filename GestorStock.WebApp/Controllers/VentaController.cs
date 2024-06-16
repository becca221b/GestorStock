using Business;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;


namespace GestorStock.WebApp.Controllers
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
            //EESTE METODO SOLO DEVUELVE LA VISTA
            return View();
        }

        [HttpPost]
        public IActionResult Cargar(Venta venta)
        {
            //ESTE METODO RECIBE EL OBJETO PARA GUARDARLO EN LA DB
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
