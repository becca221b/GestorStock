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
using Business;

namespace GestorStock.WinForm
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void saveRegisterBtn_Click(object sender, EventArgs e)
        {
            var userService = new UsuarioBusinnes(new UserRepository(new StockDbContext()));

            if (confirmTextBox.Text == passTextBox.Text)
            {
                if (userService.Register(nameTextBox.Text, passTextBox.Text))
                {
                    MessageBox.Show("Usuario agregado exitosamente.");

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al agregar usuario");
                }
            }
            else
            {
                MessageBox.Show("Password does not match");

            }

        }
    }
}
