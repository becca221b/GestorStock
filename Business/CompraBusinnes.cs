using DataEF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CompraBusinnes
    {
        private readonly CompraRepository _compraRepository;
        public CompraBusinnes(CompraRepository compraRepository)
        {
            _compraRepository = compraRepository;
        }
    }
}
