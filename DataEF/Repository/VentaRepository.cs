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
        private readonly Config _config;
        public VentaRepository(Config config)
        {
            _config = config;
        }

        public List<VentaDTO> GetAll(string sortOrder)
        {
            var lista = new VentaDTO();

            using (var db = new GestionStockContext(_config))
            {
                var ventas = (from v in db.Venta
                               join p in db.Producto on v.VentaId equals p.ProductoId
                               select new VentaDTO
                               {
                                   //CompraId= c.CompraId,
                                   //ProductoId= c.ProductoId,
                                   Producto = p.Nombre,
                                   Cantidad = v.Cantidad,
                                   FechaVenta = v.FechaVenta,


                               });
                //VER query Y dbo.Compra
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

        }

        public bool Create(Venta venta)
        {
            bool result;
            try
            {
                using (var db = new GestionStockContext(_config))
                {
                    db.Add(venta);
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
