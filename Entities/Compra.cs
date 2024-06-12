using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Compra
    {
        public int CompraId { get; set; }
        public int ProductoId { get; set; }      
        public int Cantidad { get; set; }
        public decimal Precio {  get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaCompra { get; set; }
    }
}
