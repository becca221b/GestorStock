using Business;
using Entities;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace GestorStock.WebApp.Controllers
{
    public class CompraController : Controller
    {
        private readonly ILogger<CompraController> _logger;

        private readonly CompraBusinnes _compraBusinnes;

        public CompraController(CompraBusinnes compraBusinnes,
            ILogger<CompraController> logger)
        {
            _logger = logger;

            //Para hacer Inyección de dependencias

            _compraBusinnes = compraBusinnes;
        }
        public IActionResult Index(string sortOrder, string currentFilter, string buscar, int? page)
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

            var compras = _compraBusinnes.GetAll(sortOrder, buscar);

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(compras.ToPagedList(pageNumber, pageSize));
        }

        public IActionResult Cargar()
        {
            //EESTE METODO SOLO DEVUELVE LA VISTA
            return View();
        }

        [HttpPost]
        public IActionResult Cargar(Compra compra)
        {
            //ESTE METODO RECIBE EL OBJETO PARA GUARDARLO EN LA DB
            ModelState.Remove("CompraId");
            if (ModelState.IsValid)
            {
                var response = _compraBusinnes.Create(compra);
                if (response)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }

            }

            else
            {
                return View(compra);
            }
        }


    }
}
