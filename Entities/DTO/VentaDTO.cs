using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class VentaDTO
    {
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public int UsuarioId { get; set; }
        public string Usuario { get; set; }
        public DateTime FechaVenta { get; set; }
    }
}
