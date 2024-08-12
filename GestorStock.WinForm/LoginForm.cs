using Business;
using DataEF;
using DataEF.Repository;

namespace GestorStock.WinForm
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            InitControl();
        }

        private void InitControl()
        {
            var userService = new UsuarioBusinnes(new UserRepository(new StockDbContext()));
        }


        private void button1_Click(object sender, EventArgs e)
        {

            var userService = new UsuarioBusinnes(new UserRepository(new StockDbContext()));


            var usuario = userService.Login(userNameTextBox.Text, passTextBox.Text);
            if (usuario != null)
            {
                MessageBox.Show("Succesful login");
                ProductForm productForm = new ProductForm();
                productForm.Show();
                //this.Close();
            }
            else
            {
                MessageBox.Show("User or password is wrong.");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
             RegisterForm formRegister = new RegisterForm();
             formRegister.ShowDialog();
        }
    }
}
