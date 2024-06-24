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
using GestorStock.View;

namespace GestorStock.View
{
    /// <summary>
    /// Lógica de interacción para VentanaEliminarProducto.xaml
    /// </summary>
    public partial class VentanaEliminarProducto : Window
    {
        private readonly ProductoRepository _productoRepository;
        public VentanaEliminarProducto()
        {
            InitializeComponent();

            _productoRepository = new ProductoRepository(new GestorStockContext());
            CargarProductos();
        }

        private void CargarProductos()
        {
            ProductComboBox.ItemsSource = _productoRepository.GetProductos();
            ProductComboBox.DisplayMemberPath = "Nombre";
            ProductComboBox.SelectedValuePath = "ProductoId";
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnEliminarProducto_Click(object sender, RoutedEventArgs e)
        {
            if(ProductComboBox.SelectedValue != null)
            {
                int productoId = (int)ProductComboBox.SelectedValue;
                _productoRepository.BorrarProducto(productoId);
                MessageBox.Show("Producto eliminado correctamente.");
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un producto.");
            }
        }
    }
}
