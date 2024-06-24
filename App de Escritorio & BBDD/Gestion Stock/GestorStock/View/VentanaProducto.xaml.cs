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
    /// Lógica de interacción para VentanaProducto.xaml
    /// </summary>
    public partial class VentanaProducto : Window
    {
        private readonly ProductoRepository _productoRepository;
        public VentanaProducto()
        {
            InitializeComponent();

            _productoRepository = new ProductoRepository(new GestorStockContext());
            LoadProducts();
        }

        private void LoadProducts()
        {
            dataGridProductos.ItemsSource = _productoRepository.GetProductos();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
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

        private void BtnAgregarProducto_Click(object sender, RoutedEventArgs e)
        {
            var agregarProducto = new VentanaAgregarProducto();
            agregarProducto.ShowDialog();

            LoadProducts();
        }

        private void BtnActualizarProducto_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridProductos.SelectedItem is Producto selectedProduct)
            {
                var actualizarProducto = new VentanaActualizarProducto(selectedProduct.ProductoId);
                actualizarProducto.ShowDialog();
                LoadProducts();
            }
        }

        private void BtnEliminarProducto_Click(object sender, RoutedEventArgs e)
        {
            var eliminarProducto = new VentanaEliminarProducto();
            eliminarProducto.ShowDialog();
        }

        private void BtnCerrarWinProductos_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnActualizarLista_Click(object sender, RoutedEventArgs e)
        {
            LoadProducts();
        }
    }
}
