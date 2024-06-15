using Configuration;
using Entities;
using Entities.DTO;
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

        public List<CompraDTO> GetAll()
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


                                }).ToList();
                //VER query Y dbo.Compra
                return compras;

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
