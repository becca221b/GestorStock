using Business;
using DataEF.Repository;
using DataEF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorStock.WinForm
{
    public partial class AddProductForm : Form
    {
        public AddProductForm()
        {
            InitializeComponent();
            InitControl();
        }

        private void InitControl()
        {
            var categoryService = new ProductoBusinnes(new ProductoRepository(new StockDbContext()));

            comboBox1.DataSource = categoryService.GetCategories();
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "CategoriaID";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var productService = new ProductoBusinnes(new ProductoRepository(new StockDbContext()));

            var addedProduct = productService.AddProduct(newProdBox.Text, Convert.ToInt16(comboBox1.SelectedValue));

            if (addedProduct)
            {
                MessageBox.Show("Product added succesfully.");

                this.Close();

            }
            else
            {
                MessageBox.Show("Error adding a product");
            }
        }
    }
}
