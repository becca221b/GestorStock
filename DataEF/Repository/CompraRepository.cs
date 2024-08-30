using Configuration;
using Entities;
using Entities.DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEF.Repository
{
    public class CompraRepository
    {
       
        private readonly GestionStockContext _context;
       
        public CompraRepository(GestionStockContext context)
        {
            _context = context;
        }

        public List<CompraDTO> GetAll(string sortOrder, string buscar)
        {
            //var lista = new CompraDTO();

            try
            {
                var compras = (from c in _context.Compra
                               join p in _context.Producto on c.ProductoId equals p.ProductoId
                               select new CompraDTO
                               {
                                   //CompraId= c.CompraId,
                                   //ProductoId= c.ProductoId,
                                   Producto = p.Nombre,
                                   Cantidad = c.Cantidad,
                                   FechaCompra = c.FechaCompra,


                               });

                if (!String.IsNullOrEmpty(buscar))
                {
                    compras = (compras.Where(c => c.Producto.Contains(buscar)));
                }

                switch (sortOrder)
                {
                    case "name_desc":
                        compras = compras.OrderByDescending(c => c.Producto);
                        break;
                    case "name":
                        compras = compras.OrderBy(c => c.Producto);
                        break;
                    case "Date":
                        compras = compras.OrderBy(c => c.FechaCompra);
                        break;
                    default:
                        compras = compras.OrderByDescending(c => c.FechaCompra);
                        break;
                }

                return compras.ToList();

            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return new List<CompraDTO>();
            }
            
        }

        public bool Create(Compra compra)
        {
            bool result;
            try
            {              
                _context.Add(compra);
                _context.SaveChanges();
                
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine($"General Error: {ex.Message}");
                result = false;
            }
            return result;
        }

        public List<Categoria> GetCategories()
        {
        
                var categorias = (from c in _context.Categoria
                                  select c).ToList();
                return categorias;
            
        }

        public List<Producto> GetProductsByCategoryId(int categoryId)
        {
            var db = _context;
            try
            {
                var productos = (from p in db.Producto
                                 join c in db.Categoria on p.CategoriaId equals c.CategoriaId
                                 where p.CategoriaId == categoryId
                                 select p).ToList();

                return productos;
            }
            catch (Exception ex) { 
                return new List<Producto>();
            }
        }
    }
}
