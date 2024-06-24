using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GestorStock.Business;
using GestorStock.DataEF;
using GestorStock.Entities;
using GestorStock.View;

namespace GestorStock.View
{
    /// <summary>
    /// Lógica de interacción para VentanaActualizarProducto.xaml
    /// </summary>
    public partial class VentanaActualizarProducto : Window
    {
        private readonly ProductoRepository _productoRepository;
        private readonly int _productoId;
        public VentanaActualizarProducto(int produtoId)
        {
            InitializeComponent();

            _productoRepository = new ProductoRepository(new GestorStockContext());
            _productoId = produtoId;
            CargarDetallesProductos();
        }

        private void CargarDetallesProductos()
        {
            var producto = _productoRepository.GetProductos().FirstOrDefault(p => p.ProductoId == _productoId);

            if (producto != null)
            {
                txtNombreProducto.Text = producto.Nombre;
                txtCategoriaId.Text = producto.CategoriaId.ToString();
                checkboxHabilitado.IsChecked = producto.Habilitado;
            }
        }

        private void VentanaActualizarProducto1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnCerrarActualizar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            var nombre = txtNombreProducto.Text;
            var cantidad = int.Parse(txtCantidad.Text);
            var categoriaId = int.Parse(txtCategoriaId.Text);
            var habilitado = checkboxHabilitado.IsChecked ?? false;

            _productoRepository.ActualizarProducto(_productoId, nombre, cantidad, categoriaId, habilitado);
            this.Close();
        }
    }
}
