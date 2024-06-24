using Business;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using X.PagedList;


namespace GestorStock.WebApp.Controllers
{
    public class VentaController : Controller
    {

        private readonly ILogger<VentaController> _logger;

        private readonly VentaBusinnes _ventaBusinnes;

        private readonly ProductoBusinnes _productoBusinnes;

        public VentaController(VentaBusinnes ventaBusinnes, ProductoBusinnes productoBusinnes,
            ILogger<VentaController> logger)
        {
            _logger = logger;

            //Para hacer Inyección de dependencias

            _ventaBusinnes = ventaBusinnes;

            _productoBusinnes = productoBusinnes;
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

        public IActionResult Cargar(int categoryId)
        {
            var categorias = _ventaBusinnes.GetCategories();
            var lst = (from c in categorias
                       select new SelectListItem
                       {
                           Value = c.CategoriaId.ToString(),
                           Text = c.Nombre
                       }).ToList();
            ViewBag.Categorias = lst;
            ViewBag.StockOk = "display:none";

            //var productos = _ventaBusinnes.GetProductsByCategoryId(categoryId);

            //EESTE METODO SOLO DEVUELVE LA VISTA
            return View();
        }

        [HttpPost]
        public IActionResult Cargar(Venta venta, string producto)
        {

            var categorias = _ventaBusinnes.GetCategories();
            var lst = (from c in categorias
                       select new SelectListItem
                       {
                           Value = c.CategoriaId.ToString(),
                           Text = c.Nombre
                       }).ToList();
            ViewBag.Categorias = lst;
            

            venta.ProductoId = Int32.Parse(producto);
            
            var result = _productoBusinnes.RestarStock(venta.Cantidad, venta.ProductoId);

            ViewBag.StockOk = "display:none";


            if (result)
            {//ESTE METODO RECIBE EL OBJETO PARA GUARDARLO EN LA DB
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
            else
            {   
                ViewBag.StockOk= "display:block;color:red";
                return View(venta);
            }
            
            
            
        }

        [HttpGet]
        public JsonResult Producto(int categoriaId)
        {
            List<ElementJsonIntKey> lista = new List<ElementJsonIntKey>();

            var lst = _ventaBusinnes.GetProductsByCategoryId(categoriaId);

            lista = (from p in lst
                     select new ElementJsonIntKey
                     {
                         Value = p.ProductoId,
                         Text = p.Nombre
                     }).ToList();

            return Json(lista);
        }

        public class ElementJsonIntKey
        {
            public int Value { get; set; }
            public string Text { get; set; }
        }

    }
}
