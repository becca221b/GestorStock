using Microsoft.AspNetCore.Mvc;
using WebAPI.Context;


namespace WebAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {
        private readonly GestorStockContext _context;

        public ProductoController(GestorStockContext context)
        {
            _context = context;
        }

        // GET: api/producto/{id}/stock
        [HttpGet("api/Producto/{id}/stock")]
        public IActionResult GetStock(int id)
        {
            // Consultar el total de compras para el producto
            var totalCompras = _context.Compra
                .Where(c => c.ProductoId == id)
                .Sum(c => (int?)c.Cantidad) ?? 0;

            // Consultar el total de ventas para el producto
            var totalVentas = _context.Venta
                .Where(v => v.ProductoId == id)
                .Sum(v => (int?)v.Cantidad) ?? 0;

            // Calcular el stock actual
            var stockActual = totalCompras - totalVentas;

            return Ok(new { productoid = id, Stock = stockActual });
        }
    }
}
