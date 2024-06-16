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
        private readonly Config _config;
        public CompraRepository(Config config)
        {
            _config = config;
        }

        public List<CompraDTO> GetAll(string sortOrder)
        {
            var lista = new CompraDTO();

            using (var db = new GestionStockContext(_config))
            {
                var compras = (from c in db.Compra
                               join p in db.Producto on c.CompraId equals p.ProductoId
                                select new CompraDTO
                                {
                                    //CompraId= c.CompraId,
                                    //ProductoId= c.ProductoId,
                                    Producto = p.Nombre,
                                    Cantidad = c.Cantidad,
                                    FechaCompra = c.FechaCompra,


                                });
                
                switch (sortOrder)
                {
                    case "name_desc":
                        compras = compras.OrderByDescending(c => c.Producto);
                        break;
                    case "name":
                        compras = compras.OrderBy(c => c.Producto);
                        break;
                    case "date_desc":
                        compras = compras.OrderByDescending(c => c.FechaCompra);
                        break;
                    default:
                        compras = compras.OrderBy(c => c.FechaCompra);
                        break;
                }
                
                return compras.ToList();

            }
            
        }

        public bool Create(Compra compra)
        {
            bool result;
            try
            {
                using (var db = new GestionStockContext(_config))
                {
                    db.Add(compra);
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
    }
}
