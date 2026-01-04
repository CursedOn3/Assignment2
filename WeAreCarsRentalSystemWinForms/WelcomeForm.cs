using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WeAreCarsRentalSystemWinForms
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
            LoadBackgroundImage();
            SetupTransparentPanel();
        }

        private void LoadBackgroundImage()
        {
            try
            {
                // Try to load the image from the parent directory
                string imagePath = Path.Combine(
                    Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.FullName,
                    "Car-All.jpg"
                );

                if (File.Exists(imagePath))
                {
                    pictureBoxBackground.Image = Image.FromFile(imagePath);
                }
                else
                {
                    // If image not found, use a solid color background
                    pictureBoxBackground.BackColor = Color.FromArgb(240, 240, 240);
                }
            }
            catch
            {
                // If any error occurs, use a solid color background
                pictureBoxBackground.BackColor = Color.FromArgb(240, 240, 240);
            }
        }

        private void SetupTransparentPanel()
        {
            // Set the panel's parent to the PictureBox to enable transparency
            panelMain.Parent = pictureBoxBackground;
            panelMain.BackColor = Color.FromArgb(200, 255, 255, 255); // Semi-transparent white
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
