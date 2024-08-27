using Business;
using Entities;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

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
            if (User.Identity!.IsAuthenticated) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public IActionResult Login(string name, string password)
        {
            var user = new Usuario
            {
                Nombre = name

            };
            if (ModelState.IsValid)
            {

                var response = _userBusinnes.Login(name, password);
                if (response != null)
                {
                    List<Claim> claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, response.Nombre)
                    };

                    ClaimsIdentity claimsIdentity= new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    AuthenticationProperties properties = new AuthenticationProperties()
                    {
                        AllowRefresh = true,
                    };

                    HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        properties
                        );

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["Mensaje"] = "Usuario o contraseña incorrecto/s";
                    return View();
                }

            }
            else
            {
                return View(user);
            }
        }

        public IActionResult Register() {
            if (User.Identity!.IsAuthenticated) return RedirectToAction("Index", "Home");
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
