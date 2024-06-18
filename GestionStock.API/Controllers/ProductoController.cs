using Microsoft.AspNetCore.Mvc;

namespace GestionStockAPI.Controllers
{
    public class ProductoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/producto/{id}/stock
        [HttpGet("{id}/stock")]
        public async Task<ActionResult<int>> GetStock(int id)
        {
            // Verificar si el producto existe y está habilitado
            var producto = await _context.Productos
                .FirstOrDefaultAsync(p => p.ProductoId == id && p.Habilitado);

            if (producto == null)
            {
                return NotFound(new { Message = "Producto no encontrado o no está habilitado" });
            }

            // Calcular el stock como la suma de las compras menos las ventas
            var totalCompras = await _context.Compras
                .Where(c => c.ProductoId == id)
                .SumAsync(c => c.Cantidad);

            var totalVentas = await _context.Ventas
                .Where(v => v.ProductoId == id)
                .SumAsync(v => v.Cantidad);

            var stock = totalCompras - totalVentas;

            return Ok(stock);
        }
    }
}
