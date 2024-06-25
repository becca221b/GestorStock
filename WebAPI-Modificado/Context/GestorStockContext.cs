using Microsoft.EntityFrameworkCore;
using WebAPI.Modelo;

namespace WebAPI.Context
{
    public class GestorStockContext: DbContext
    {
        public GestorStockContext(DbContextOptions<GestorStockContext> options)
            : base(options)
        {
        }

        public DbSet<Compra> Compra { get; set; }
        public DbSet<Venta> Venta { get; set; }
        public DbSet<Producto> Producto { get; set; }
        
    }
}
    
