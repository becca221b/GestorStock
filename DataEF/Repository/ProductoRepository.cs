using Configuration;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataEF.Repository
{
    public class ProductoRepository
    {
        //private readonly Config _config;
        //private readonly StockDbContext _context;
        /*
        public ProductoRepository(Config config)
        {
            _config = config;
        }*/
        private readonly GestionStockContext _context;

        public ProductoRepository(GestionStockContext context)
        {
            _context = context;
        }
        
        
        public int GetStock(int productoId)
        {
            try
            {
                var compras = (from p in _context.Compra
                             where p.ProductoId == productoId
                             select p.Cantidad).Sum();

                var ventas = (from p in _context.Venta
                              where p.ProductoId == productoId
                              select p.Cantidad).Sum();
                
                return compras-ventas;
            }catch(Exception ex) {
                return 0;
            }
        }
        
        //DESDE ACÁ METODOS PARA EL WINFORM
        public bool AddProduct(string nombre, int categoriaId)
        {
            var producto = new Producto
            {
                Nombre = nombre,
                CategoriaId = categoriaId,
                Habilitado = true
            };

            bool result;
            try
            {
                using (var db = _context)
                {
                    if (db.Producto.Any(p => p.Nombre == nombre))
                    {
                        throw new InvalidOperationException("El producto con el mismo nombre ya existe.");
                    }
                    db.Add(producto);

                    db.SaveChanges();
                }
                result = true;

            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public List<Producto> GetProducts()
        {
            using (var db = _context)
            {
                var products = db.Producto.Select(X => X).ToList();
                return products;
            }
                
        }

        public List<Categoria> GetCategories()
        {
            using (var db = _context)
            {
                var categorias = (from c in db.Categoria
                                  select c).ToList();
                return categorias;
            }
        }

        public List<Producto> GetProductByName(string nombre)
        {
            using (var db = _context)
            {
                var products = from p in db.Producto
                               where p.Nombre.Contains(nombre)
                               select p;
                return products.ToList();
            }
        }

        public List<Producto> GetProductByCategory(int categoryId)
        {
            var db = _context;
            try{
                var products = from p in db.Producto
                               where p.CategoriaId == categoryId
                               select p;
                return products.ToList();
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public List<Producto> GetProductsByCategAndName(string category, string prodName)
        {
            using (var db = _context)
            {
                var products = from p in db.Producto
                               where p.Nombre == category
                               where p.Nombre == prodName
                               select p;
                return products.ToList();
            }
        }
    }   

}
