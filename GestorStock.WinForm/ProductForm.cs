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
    public partial class ProductForm : Form
    {
        
        //ProductoBusinnes productService;
        public ProductForm()
        {
            InitializeComponent();

            InitControl();


        }
        private void InitControl()
        {

            var productService = new ProductoBusinnes(new ProductoRepository(new StockDbContext()));
            dataGridView1.DataSource = productService.GetProducts();

            var categoryService = new ProductoBusinnes(new ProductoRepository(new StockDbContext()));

            var categoriesList = categoryService.GetCategories();
            categoriesList.Insert(0, new Entities.Categoria() { CategoriaId= 0, Nombre="Select Category"});

            categoryCombo.DataSource = categoriesList;
            categoryCombo.DisplayMember = "Nombre";
            categoryCombo.ValueMember = "CategoriaID";
            
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm();
            addProductForm.ShowDialog();
            InitControl();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            var productService = new ProductoBusinnes(new ProductoRepository(new StockDbContext()));

            if (nameFilter.Text == "" && categoryCombo.SelectedIndex.Equals(0))
            {
                dataGridView1.DataSource = productService.GetProducts();
            }
            else
            {
                if (nameFilter.Text != "" && categoryCombo.SelectedIndex.Equals(0))
                {
                    dataGridView1.DataSource = productService.GetProductByName(nameFilter.Text);
                }
                else
                {
                    if(nameFilter.Text == "" && categoryCombo.SelectedIndex != 0)
                    {
                        dataGridView1.DataSource = productService.GetProductByCategory((int)categoryCombo.SelectedValue);
                    }
                    else
                    {
                        dataGridView1.DataSource = productService.GetProductsByCategAndName(nameFilter.Text, categoryCombo.Text);
                    }
                }
            }
        }
    }
}
