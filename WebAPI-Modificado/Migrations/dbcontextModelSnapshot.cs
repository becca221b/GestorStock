using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Context;

#nullable disable

namespace WebAPI.Migrations
{
    [DbContext(typeof(GestorStockContext))]
    partial class dbcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebAPI.Modelo.Compra", b =>
                {
                    b.Property<int>("compraid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("compraid"));

                    b.Property<int>("cant")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaCompra")
                        .HasColumnType("datetime2");

                    b.Property<int>("productoid")
                        .HasColumnType("int");

                    b.HasKey("compraid");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("WebAPI.Modelo.Producto", b =>
                {
                    b.Property<int>("productoid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("productoid"));

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("productoid");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("WebAPI.Modelo.Venta", b =>
                {
                    b.Property<int>("ventaid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ventaid"));

                    b.Property<int>("cant")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaVenta")
                        .HasColumnType("datetime2");

                    b.Property<int>("productoid")
                        .HasColumnType("int");

                    b.HasKey("ventaid");

                    b.ToTable("Ventas");
                });
#pragma warning restore 612, 618
        }
    }
}
