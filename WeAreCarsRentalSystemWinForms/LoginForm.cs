using System;
using System.Windows.Forms;

namespace WeAreCarsRentalSystemWinForms
{
    public partial class LoginForm : Form
    {
        private const string VALID_USERNAME = "sta001";
        private const string VALID_PASSWORD = "givemethekeys123";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (username == VALID_USERNAME && password == VALID_PASSWORD)
            {
                lblError.Visible = false;
                this.Hide();
                MenuForm menuForm = new MenuForm();
                menuForm.FormClosed += (s, args) => this.Close();
                menuForm.Show();
            }
            else
            {
                lblError.Text = "? Invalid username or password. Access denied.";
                lblError.Visible = true;
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }
    }
}
