using Microsoft.AspNetCore.Mvc;

namespace GestorStock.WebApp.Controllers
{
    public class CompraController : Controller
    {
        private readonly ILogger<CompraController> _logger;

        private readonly CompraBusinnes _compraBusinnes;
        public IActionResult Index()
        {
            return View();
        }
    }
}
