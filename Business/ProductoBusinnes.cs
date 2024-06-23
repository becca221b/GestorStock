using DataEF.Repository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProductoBusinnes
    {
        private readonly ProductoRepository _productoRepository;

        public ProductoBusinnes(ProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public bool SumarStock(int cantidad, int productoId)
        {
            return _productoRepository.SumarStock(cantidad, productoId);
        }
    }
}
