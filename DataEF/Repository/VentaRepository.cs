using Configuration;
using Entities.DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEF.Repository
{
    public class VentaRepository
    {
        private readonly Config _config;
        public VentaRepository(Config config)
        {
            _config = config;
        }

        public List<VentaDTO> GetAll()
        {
            var lista = new CompraDTO();

            using (var db = new GestionStockContext(_config))
            {
                var ventas = (from c in db.Venta
                               join p in db.Producto on c.VentaId equals p.ProductoId
                               select new VentaDTO
                               {
                                   //CompraId= c.CompraId,
                                   //ProductoId= c.ProductoId,
                                   Producto = p.Nombre,
                                   Cantidad = c.Cantidad,
                                   FechaVenta = c.FechaVenta,


                               }).ToList();
                //VER query Y dbo.Compra
                return ventas;

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
