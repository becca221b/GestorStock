using Configuration;
using Entities.DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DataEF.Repository
{
    public class VentaRepository
    {
        //private readonly Config _config;
        private readonly GestionStockContext _context;
        public VentaRepository(GestionStockContext context)
        {
            _context = context;
        }

        public List<VentaDTO> GetAll(string sortOrder, string buscar)
        {
            
            try
            {
                var ventas = (from v in _context.Venta
                               join p in _context.Producto on v.ProductoId equals p.ProductoId
                               select new VentaDTO
                               {
                                   //CompraId= c.CompraId,
                                   //ProductoId= c.ProductoId,
                                   Producto = p.Nombre,
                                   Cantidad = v.Cantidad,
                                   FechaVenta = v.FechaVenta,


                               });


                if (!String.IsNullOrEmpty(buscar))
                {
                    ventas = (ventas.Where(c => c.Producto.Contains(buscar)));
                }
                
                switch (sortOrder)
                {
                    case "name_desc":
                        ventas = ventas.OrderByDescending(v => v.Producto);
                        break;
                    case "name":
                        ventas = ventas.OrderBy(c => c.Producto);
                        break;
                    case "Date":
                        ventas = ventas.OrderBy(c => c.FechaVenta);
                        break;
                    default:
                        ventas = ventas.OrderByDescending(c => c.FechaVenta);
                        break;
                }

                return ventas.ToList();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new List<VentaDTO>();
            }

        }

        public bool Create(Venta venta)
        {
            bool result;
           
            try
            {
                _context.Add(venta);
                _context.SaveChanges();
                
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public List<Categoria> GetCategories()
        {
            try
            {
                var categorias = (from c in _context.Categoria
                                  select c).ToList();
                return categorias;
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.ToString());
                return new List<Categoria>();
            }
        }

        public List<Producto> GetProductsByCategoryId(int categoryId)
        {
            try
            {
                var productos = (from p in _context.Producto
                                 join c in _context.Categoria on p.CategoriaId equals c.CategoriaId
                                 where p.CategoriaId == categoryId
                                 select p).ToList();

                return productos;
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
                return new List<Producto>();
            }
        }
    }
}
