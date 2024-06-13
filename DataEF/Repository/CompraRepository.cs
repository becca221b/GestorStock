using Configuration;
using Entities;
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

        public List<Compra> GetAll()
        {
            //var result = new Compra();

            using (var db = new GestionStockContext(_config))
            {
                var compras = (from c in db.Compra
                                select c).ToList();
                //VER query Y dbo.Compra
                return compras;

            }

            
        }
    }
}
