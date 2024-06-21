using Business;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using X.PagedList;


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
        public IActionResult Index(string sortOrder, string buscar, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name" : "name_desc";
            ViewBag.DateSortParm = sortOrder == "Date" ? "" : "Date";

            if (buscar != null)
            {
                page = 1;
            }
            else
            {
                buscar = currentFilter;
            }

            ViewBag.CurrentFilter = buscar;
            
            var ventas = _ventaBusinnes.GetAll(sortOrder, buscar);

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(ventas.ToPagedList(pageNumber, pageSize));
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
