using Business;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace GestorStock.WebApp.Controllers
{
    public class AccesoController : Controller
    {
        private readonly ILogger<AccesoController> _logger;

        private readonly UsuarioBusinnes _userBusinnes;

        public AccesoController(UsuarioBusinnes usuarioBusinnes, ILogger<AccesoController> logger)
        {
            _logger = logger;
            _userBusinnes = usuarioBusinnes;

        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register() { 
            return View();
        }

        [HttpPost]
        public IActionResult Register(string name, string password, string confirm)
        {
            
            if (password != confirm) {
                ViewData["Mensaje"] = "Las contraseñas no coinciden";
                var user = new Usuario
                {
                    Nombre = name
                };
                
                return View(user);
            }
            if (ModelState.IsValid)
            {
                var response = _userBusinnes.Register(name, password);
                if (response)
                {
                    
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewData["Mensaje"] = "No se pudo crear el usuario, error";
                    return View();
                }

            }
            else
            {
                return View();
            }
        }
    }
}
