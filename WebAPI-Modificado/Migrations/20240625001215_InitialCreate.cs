using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    compraid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productoid = table.Column<int>(type: "int", nullable: false),
                    cant = table.Column<int>(type: "int", nullable: false),
                    fechaCompra = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.compraid);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    productoid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.productoid);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    ventaid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productoid = table.Column<int>(type: "int", nullable: false),
                    cant = table.Column<int>(type: "int", nullable: false),
                    fechaVenta = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.ventaid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Ventas");
        }
    }
}
