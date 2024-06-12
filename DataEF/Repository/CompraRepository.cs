using Configuration;
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
    }
}
