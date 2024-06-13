using Business;
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

        
    }
}
