using Configuration;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEF
{
    public class GestionStockContext : DbContext
    {
        public GestionStockContext(DbContextOptions<GestionStockContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<Venta> Venta { get; set; }

        
    }
}
