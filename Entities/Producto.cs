﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public int CategoriaId { get; set; }
        public bool Habilitado { get; set; }

        [Range(0, 100.00,
            ErrorMessage = "Verificar stock")]
        public int Stock {  get; set; }
    }
}
