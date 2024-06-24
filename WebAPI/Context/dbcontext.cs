using Microsoft.EntityFrameworkCore;
using WebAPI.Modelo;

namespace WebAPI.Context
{
    public class dbcontext: DbContext
    {
        public dbcontext(DbContextOptions<dbcontext> options)
            : base(options)
        {
        }

        public DbSet<Compra> Compras { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Producto> Productos { get; set; }
    }
}
    
