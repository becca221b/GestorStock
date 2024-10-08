﻿using DataEF.Repository;
using Entities;
using Entities.DTO;
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

        public List<CompraDTO> GetAll(string sortOrder, string buscar)
        {
            
            return _compraRepository.GetAll(sortOrder, buscar);
        }

        public bool Create(Compra compra)
        {
            return _compraRepository.Create(compra);
        }
        
        public List<Categoria> GetCategories()
        {
            return _compraRepository.GetCategories();
        }

        public List<Producto> GetProductsByCategoryId(int categoryId)
        {
            return _compraRepository.GetProductsByCategoryId(categoryId);
        }
    }
}
