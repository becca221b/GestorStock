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
        private readonly Config _config;
        private readonly StockDbContext _context;
        public ProductoRepository(Config config)
        {
            _config = config;
        }
        
        public ProductoRepository(StockDbContext context)
        {
            _context = context;
        }
        /*
        public bool SumarStock(int cantidad, int productoId)
        {
            bool result;
            try
            {
                using (var db = new GestionStockContext(_config))
                {
                    
                    
                    var producto = (from p in db.Producto
                                    where p.ProductoId == productoId
                                    select p).FirstOrDefault();
                    
                    producto.Stock += cantidad;
                    

                    db.Attach(producto);
                    db.Entry(producto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        public bool RestarStock(int cantidad, int productoId)
        {
            bool result;
            try
            {
                using (var db = new GestionStockContext(_config))
                {
                    var producto = (from p in db.Producto
                                    where p.ProductoId == productoId
                                    select p).FirstOrDefault();

                    if(producto.Stock>=cantidad) {
                        producto.Stock = producto.Stock-cantidad;
                    }
                    else
                    {
                        return false;
                    }
                    
                    db.Attach(producto);
                    db.Entry(producto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        public int GetStock(int productoId)
        {
            using (var db = new GestionStockContext(_config))
            {
                var stock = (from p in db.Producto
                             where p.ProductoId == productoId
                             select p.Stock).FirstOrDefault();
                return stock;
            }
        }
        */
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
                using (var db = new StockDbContext())
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
            using (var db = new StockDbContext())
            {
                var products = db.Producto.Select(X => X).ToList();
                return products;
            }
                
        }

        public List<Categoria> GetCategories()
        {
            using (var db = new StockDbContext())
            {
                var categorias = (from c in db.Categoria
                                  select c).ToList();
                return categorias;
            }
        }

        public List<Producto> GetProductByName(string nombre)
        {
            using (var db = new StockDbContext())
            {
                var products = from p in db.Producto
                               where p.Nombre.Contains(nombre)
                               select p;
                return products.ToList();
            }
        }

        public List<Producto> GetProductByCategory(int categoryId)
        {
            using (var db = new StockDbContext())
            {
                var products = from p in db.Producto
                               where p.CategoriaId == categoryId
                               select p;
                return products.ToList();
            }
        }

        public List<Producto> GetProductsByCategAndName(string category, string prodName)
        {
            using (var db = new StockDbContext())
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
