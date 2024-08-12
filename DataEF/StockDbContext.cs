using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataEF
{
    public class StockDbContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Venta> Ventas { get; set; }

        private readonly string CONNECTIONSTRING = "Persist Security Info=True;Initial Catalog=GestorStock;Data Source=.;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTIONSTRING);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
                .HasIndex(p => p.Nombre)
                .IsUnique();
        }

    }
}
