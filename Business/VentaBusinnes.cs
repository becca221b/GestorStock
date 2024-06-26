﻿using DataEF.Repository;
using Entities.DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class VentaBusinnes
    {
        private readonly VentaRepository _ventaRepository;
        public VentaBusinnes(VentaRepository ventaRepository)
        {
            _ventaRepository = ventaRepository;
        }

        public List<VentaDTO> GetAll(string sortOrder, string buscar)
        {
            return _ventaRepository.GetAll(sortOrder, buscar);
        }

        public bool Create(Venta venta)
        {
            return _ventaRepository.Create(venta);
        }

        public List<Categoria> GetCategories()
        {
            return _ventaRepository.GetCategories();
        }

        public List<Producto> GetProductsByCategoryId(int categoryId)
        {
            return _ventaRepository.GetProductsByCategoryId(categoryId);
        }
    }
}
