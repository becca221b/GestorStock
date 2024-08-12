using Business;
using Microsoft.AspNetCore.Mvc;

namespace GestorStock.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ILogger<ProductoController> _logger;
        private readonly ProductoBusinnes _productoBusinnes;


        
        [HttpGet("{productoId:int}")]
        public int GetStock(int productoId)
        {
            var prodStock = _productoBusinnes.GetStock(productoId);
            return prodStock;
        }

    }

        
    
}
