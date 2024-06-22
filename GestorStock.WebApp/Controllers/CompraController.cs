using Business;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
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

        public IActionResult Cargar(int categoryId)
        {
            //EESTE METODO SOLO DEVUELVE LA VISTA
            var categorias = _compraBusinnes.GetCategories();
            var lst = (from c in categorias
                      select new SelectListItem
                      {
                          Value = c.CategoriaId.ToString(),
                          Text = c.Nombre
                      }).ToList();
            ViewBag.Categorias = lst;

            var productos = _compraBusinnes.GetProductsByCategoryId(categoryId);
            //ViewBag.Productos
            return View();
        }

        [HttpPost]
        public IActionResult Cargar(Compra compra, string producto)
        {
            //ESTE METODO RECIBE EL OBJETO PARA GUARDARLO EN LA DB
            ModelState.Remove("CompraId");
            ModelState.Remove("ProductoId");
            compra.ProductoId = Int32.Parse(producto);
            


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

        [HttpGet]
        public JsonResult Producto(int categoriaId)
        {
            List<ElementJsonIntKey> lista = new List<ElementJsonIntKey>();

            var lst = _compraBusinnes.GetProductsByCategoryId(categoriaId);

            lista = (from p in lst
                             select new ElementJsonIntKey
                             {
                                 Value= p.ProductoId,
                                 Text = p.Nombre
                             }).ToList();

            return Json(lista);
        }

        public class ElementJsonIntKey
        {
            public int Value { get; set; }
            public string Text { get; set;}
        }


    }
}
