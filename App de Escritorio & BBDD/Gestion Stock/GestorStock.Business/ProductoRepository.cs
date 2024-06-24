using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorStock.DataEF;
using GestorStock.Entities;

namespace GestorStock.Business
{
    public class ProductoRepository
    {
        private readonly GestorStockContext _context;

        public ProductoRepository(GestorStockContext context)
        {
            _context = context;
        }

        public void AgregarProducto(string nombre, int cantidad, int categoriaId)
        {
            if (_context.Producto.Any(p => p.Nombre == nombre))
            {
                throw new InvalidOperationException("El producto con el mismo nombre ya existe.");
            }

            var producto = new Producto
            {
                Nombre = nombre,
                Cantidad = cantidad,
                CategoriaId = categoriaId,
                Habilitado = true
            };
            _context.Producto.Add(producto);
            _context.SaveChanges();
        }

        public void ActualizarProducto(int id, string nombre, int cantidad, int categoriaId, bool habilitado)
        {
            var producto = _context.Producto.Find(id);
            if (producto != null)
            {
                producto.Nombre = nombre;
                producto.Cantidad = cantidad;
                producto.CategoriaId = categoriaId;
                producto.Habilitado = habilitado;
                _context.SaveChanges();
            }
        }

        public void BorrarProducto(int id)
        {
            var producto = _context.Producto.Find(id);
            if (producto != null)
            {
                _context.Producto.Remove(producto);
                _context.SaveChanges();
            }
        }

        public List<Producto> GetProductos()
        {
            return _context.Producto.ToList();
        }
    }
}
