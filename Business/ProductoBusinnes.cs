using DataEF;
using DataEF.Repository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProductoBusinnes
    {
        private readonly ProductoRepository _productoRepository;

        public ProductoBusinnes(ProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }
        /*
        public bool SumarStock(int cantidad, int productoId)
        {
            return _productoRepository.SumarStock(cantidad, productoId);
        }

        public bool RestarStock(int cantidad, int productoId)
        {
            return _productoRepository.RestarStock(cantidad, productoId);
        }

        public int GetStock(int productoId)
        {
            return _productoRepository.GetStock(productoId);
        }
        */
        //A PARTIR DE ACÁ METODOS PARA EL WINFORM
        public List<Producto> GetProducts()
        {
            return _productoRepository.GetProducts();
        }

        public bool AddProduct(string nombre, int categoriaId)
        {
            return _productoRepository.AddProduct(nombre, categoriaId);
        }

        public List<Categoria> GetCategories()
        {
            return _productoRepository.GetCategories();
        }

        public List<Producto> GetProductByName(string nombre)
        {
            return _productoRepository.GetProductByName(nombre);
        }

        public List<Producto> GetProductByCategory(int categoryId)
        {
            return _productoRepository.GetProductByCategory(categoryId);
        }

        public List<Producto> GetProductsByCategAndName(string category, string prodName)
        {
            return _productoRepository.GetProductsByCategAndName(category, prodName);
        }
    }
}
