using System;
using System.Data;
using System.Windows.Forms;

namespace WeAreCarsRentalSystemWinForms
{
    public partial class ViewBookingsForm : Form
    {
        public ViewBookingsForm()
        {
            InitializeComponent();
        }

        private void ViewBookingsForm_Load(object sender, EventArgs e)
        {
            LoadBookings();
        }

        private void LoadBookings()
        {
            try
            {
                DataTable bookingsTable = DatabaseHelper.GetAllBookings();
                
                if (bookingsTable.Rows.Count > 0)
                {
                    dgvBookings.DataSource = bookingsTable;
                    
                    // Format columns for better display
                    if (dgvBookings.Columns.Contains("id"))
                        dgvBookings.Columns["id"].HeaderText = "ID";
                    if (dgvBookings.Columns.Contains("first_name"))
                        dgvBookings.Columns["first_name"].HeaderText = "First Name";
                    if (dgvBookings.Columns.Contains("surname"))
                        dgvBookings.Columns["surname"].HeaderText = "Surname";
                    if (dgvBookings.Columns.Contains("address"))
                        dgvBookings.Columns["address"].HeaderText = "Address";
                    if (dgvBookings.Columns.Contains("age"))
                        dgvBookings.Columns["age"].HeaderText = "Age";
                    if (dgvBookings.Columns.Contains("rental_days"))
                        dgvBookings.Columns["rental_days"].HeaderText = "Days";
                    if (dgvBookings.Columns.Contains("car_type"))
                        dgvBookings.Columns["car_type"].HeaderText = "Car Type";
                    if (dgvBookings.Columns.Contains("fuel_type"))
                        dgvBookings.Columns["fuel_type"].HeaderText = "Fuel Type";
                    if (dgvBookings.Columns.Contains("extras"))
                        dgvBookings.Columns["extras"].HeaderText = "Extras";
                    if (dgvBookings.Columns.Contains("total_cost"))
                    {
                        dgvBookings.Columns["total_cost"].HeaderText = "Total Cost";
                        dgvBookings.Columns["total_cost"].DefaultCellStyle.Format = "£0.00";
                    }
                    if (dgvBookings.Columns.Contains("created_at"))
                        dgvBookings.Columns["created_at"].HeaderText = "Created At";

                    // Calculate statistics
                    int totalBookings = bookingsTable.Rows.Count;
                    decimal totalRevenue = 0;

                    foreach (DataRow row in bookingsTable.Rows)
                    {
                        if (row["total_cost"] != DBNull.Value)
                        {
                            totalRevenue += Convert.ToDecimal(row["total_cost"]);
                        }
                    }

                    lblTotalBookings.Text = $"Total Bookings: {totalBookings}";
                    lblTotalRevenue.Text = $"Total Revenue: £{totalRevenue:F2}";
                }
                else
                {
                    dgvBookings.DataSource = null;
                    lblTotalBookings.Text = "Total Bookings: 0";
                    lblTotalRevenue.Text = "Total Revenue: £0.00";
                    MessageBox.Show("No bookings found in the database.", "Information", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bookings:\n\n{ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBookings();
            MessageBox.Show("Bookings refreshed successfully!", "Success", 
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a booking to delete.", "No Selection", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected row
            DataGridViewRow selectedRow = dgvBookings.SelectedRows[0];
            int bookingId = Convert.ToInt32(selectedRow.Cells["id"].Value);
            string customerName = $"{selectedRow.Cells["first_name"].Value} {selectedRow.Cells["surname"].Value}";
            decimal totalCost = Convert.ToDecimal(selectedRow.Cells["total_cost"].Value);

            // Confirm deletion
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete this booking?\n\n" +
                $"Booking ID: {bookingId}\n" +
                $"Customer: {customerName}\n" +
                $"Total Cost: £{totalCost:F2}\n\n" +
                $"This action cannot be undone!",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DatabaseHelper.DeleteBooking(bookingId);
                    MessageBox.Show("Booking deleted successfully!", "Success", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBookings(); // Refresh the grid
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting booking:\n\n{ex.Message}", "Error", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a booking to edit.", "No Selection", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected row
            DataGridViewRow selectedRow = dgvBookings.SelectedRows[0];
            
            int bookingId = Convert.ToInt32(selectedRow.Cells["id"].Value);
            string firstName = selectedRow.Cells["first_name"].Value.ToString() ?? "";
            string surname = selectedRow.Cells["surname"].Value.ToString() ?? "";
            string address = selectedRow.Cells["address"].Value.ToString() ?? "";
            int age = Convert.ToInt32(selectedRow.Cells["age"].Value);
            int rentalDays = Convert.ToInt32(selectedRow.Cells["rental_days"].Value);
            string carType = selectedRow.Cells["car_type"].Value.ToString() ?? "";
            string fuelType = selectedRow.Cells["fuel_type"].Value.ToString() ?? "";
            string extras = selectedRow.Cells["extras"].Value.ToString() ?? "";

            // Open edit form
            EditBookingForm editForm = new EditBookingForm(bookingId, firstName, surname, address, 
                                                          age, rentalDays, carType, fuelType, extras);
            editForm.ShowDialog();

            // Refresh grid if booking was updated
            if (editForm.BookingUpdated)
            {
                LoadBookings();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
