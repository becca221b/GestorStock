using Microsoft.AspNetCore.Mvc;

namespace GestorStock.WebApp.Controllers
{
    public class AccesoController : Controller
    {
        private readonly ILogger<CompraController> _logger;

        public AccesoController(ILogger<CompraController> logger)
        {
            _logger = logger;

        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
