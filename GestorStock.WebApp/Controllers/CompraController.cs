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
        public IActionResult Index()
        {
            var compras = _compraBusinnes.GetAll();
            

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


    }
}
