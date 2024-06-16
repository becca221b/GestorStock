using Entities.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Compra
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CompraId { get; set; }
        public int ProductoId { get; set; }      
        public int Cantidad { get; set; }
        public decimal Precio {  get; set; }
        public int UsuarioId { get; set; }

        [FechaMayorASieteDias(ErrorMessage = "La fecha no puede ser más de 7 días atrás")]
        [FechaMayorAHoy(ErrorMessage = "La fecha no puede ser futura")]
        public DateTime FechaCompra { get; set; }
    }
}
