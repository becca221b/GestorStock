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
    /// Lógica de interacción para VentanaAgregarProducto.xaml
    /// </summary>
    public partial class VentanaAgregarProducto : Window
    {
        private readonly ProductoRepository _productoRepository;
        public VentanaAgregarProducto()
        {
            InitializeComponent();

            _productoRepository = new ProductoRepository(new GestorStockContext());
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

        private void BtnAgregarProducto_Click(object sender, RoutedEventArgs e)
        {
            var nombre = txtProducto.Text;
            var cantidad = int.Parse(txtCantidad.Text);
            var categoriaId = int.Parse(txtCategoriaId.Text);

            _productoRepository.AgregarProducto(nombre, cantidad, categoriaId);

            MessageBox.Show("Producto agregado correctamente!!");

            this.Close();
        }
    }
}
