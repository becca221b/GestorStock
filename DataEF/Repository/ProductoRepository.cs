using Configuration;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEF.Repository
{
    public class ProductoRepository
    {
        private readonly Config _config;
        public ProductoRepository(Config config)
        {
            _config = config;
        }

        public bool SumarStock(int cantidad, int productoId)
        {
            bool result;
            try
            {
                using (var db = new GestionStockContext(_config))
                {
                    /*var stock = (from p in db.Producto
                                 where p.ProductoId == productoId
                                 select p.Stock).FirstOrDefault();*/
                    
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
    }
}
