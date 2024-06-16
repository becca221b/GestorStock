using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FechaMayorASieteDias : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            try
            {
                var fechaValida = ((DateTime.Today)- Convert.ToDateTime(value)).TotalDays;
                return fechaValida <= 7;
            }
            catch(Exception)
            {
                return base.IsValid(value);
            }
        }
    }
}
