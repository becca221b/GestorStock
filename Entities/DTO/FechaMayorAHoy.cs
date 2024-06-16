using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{

    //&& Convert.ToDateTime(value)<= DateTime.Today
    [AttributeUsage(AttributeTargets.Property)]
    public class FechaMayorAHoy : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            try
            {
                //var fechaValida = ((DateTime.Today) - Convert.ToDateTime(value)).TotalDays;
                return Convert.ToDateTime(value) <= DateTime.Today;
            }
            catch (Exception)
            {
                return base.IsValid(value);
            }
        }
    }
}
