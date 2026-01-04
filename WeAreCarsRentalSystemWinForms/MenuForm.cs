using System;
using System.Windows.Forms;

namespace WeAreCarsRentalSystemWinForms
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void btnNewBooking_Click(object sender, EventArgs e)
        {
            this.Hide();
            BookingForm bookingForm = new BookingForm();
            bookingForm.FormClosed += (s, args) => this.Show();
            bookingForm.Show();
        }

        private void btnViewBookings_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewBookingsForm viewForm = new ViewBookingsForm();
            viewForm.FormClosed += (s, args) => this.Show();
            viewForm.Show();
        }
    }
}
