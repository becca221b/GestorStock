using Microsoft.AspNetCore.Mvc;
using WebAPI.Context;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : Controller
    {
        private readonly dbcontext _context;

        public StockController(dbcontext context)
        {
            _context = context;
        }

        // GET: api/producto/{id}/stock
        [HttpGet("{id}/stock")]
        public IActionResult GetStock(int id)
        {
            // Consultar el total de compras para el producto
            var totalCompras = _context.Compras
                .Where(c => c.productoid == id)
                .Sum(c => (int?)c.cant) ?? 0;

            // Consultar el total de ventas para el producto
            var totalVentas = _context.Ventas
                .Where(v => v.productoid == id)
                .Sum(v => (int?)v.cant) ?? 0;

            // Calcular el stock actual
            var stockActual = totalCompras - totalVentas;

            return Ok(new { productoid = id, Stock = stockActual });
        }
    }
}
