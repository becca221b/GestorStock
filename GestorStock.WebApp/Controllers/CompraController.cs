using Business;
using Entities;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "name";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            var compras = _compraBusinnes.GetAll(sortOrder);
            

            return View(compras);
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
