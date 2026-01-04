using System;
using System.Windows.Forms;

namespace WeAreCarsRentalSystemWinForms
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.FormClosed += (s, args) => this.Close();
            loginForm.Show();
        }
    }
}
