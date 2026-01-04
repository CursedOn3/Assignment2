using System;
using System.Windows.Forms;

namespace WeAreCarsRentalSystemWinForms
{
    public partial class BookingForm : Form
    {
        private const decimal DAILY_RENTAL_RATE = 25.00m;
        private const decimal FAMILY_CAR_SURCHARGE = 50.00m;
        private const decimal SPORTS_CAR_SURCHARGE = 75.00m;
        private const decimal SUV_SURCHARGE = 65.00m;
        private const decimal HYBRID_SURCHARGE = 30.00m;
        private const decimal ELECTRIC_SURCHARGE = 50.00m;
        private const decimal UNLIMITED_MILEAGE_DAILY = 10.00m;
        private const decimal BREAKDOWN_COVER_DAILY = 2.00m;

        public BookingForm()
        {
            InitializeComponent();
            InitializeComboBoxes();
            CalculateTotalCost(null, null);
        }

        private void InitializeComboBoxes()
        {
            cmbCarType.Items.AddRange(new object[]
            {
                "City Car (+£0)",
                "Family Car (+£50)",
                "Sports Car (+£75)",
                "SUV (+£65)"
            });
            cmbCarType.SelectedIndex = 0;

            cmbFuelType.Items.AddRange(new object[]
            {
                "Petrol (+£0)",
                "Diesel (+£0)",
                "Hybrid (+£30)",
                "Electric (+£50)"
            });
            cmbFuelType.SelectedIndex = 0;
        }

        private void CalculateTotalCost(object? sender, EventArgs? e)
        {
            int rentalDays = (int)numRentalDays.Value;
            
            decimal baseCost = DAILY_RENTAL_RATE * rentalDays;
            decimal carCost = GetCarTypeSurcharge();
            decimal fuelCost = GetFuelTypeSurcharge();
            decimal mileageCost = chkUnlimitedMileage.Checked ? UNLIMITED_MILEAGE_DAILY * rentalDays : 0;
            decimal breakdownCost = chkBreakdownCover.Checked ? BREAKDOWN_COVER_DAILY * rentalDays : 0;

            decimal totalCost = baseCost + carCost + fuelCost + mileageCost + breakdownCost;
            
            lblTotalCostValue.Text = $"£{totalCost:F2}";
        }

        private decimal GetCarTypeSurcharge()
        {
            return cmbCarType.SelectedIndex switch
            {
                0 => 0,
                1 => FAMILY_CAR_SURCHARGE,
                2 => SPORTS_CAR_SURCHARGE,
                3 => SUV_SURCHARGE,
                _ => 0
            };
        }

        private decimal GetFuelTypeSurcharge()
        {
            return cmbFuelType.SelectedIndex switch
            {
                0 => 0,
                1 => 0,
                2 => HYBRID_SURCHARGE,
                3 => ELECTRIC_SURCHARGE,
                _ => 0
            };
        }

        private string GetCarTypeName()
        {
            return cmbCarType.SelectedIndex switch
            {
                0 => "City Car",
                1 => "Family Car",
                2 => "Sports Car",
                3 => "SUV",
                _ => "Unknown"
            };
        }

        private string GetFuelTypeName()
        {
            return cmbFuelType.SelectedIndex switch
            {
                0 => "Petrol",
                1 => "Diesel",
                2 => "Hybrid",
                3 => "Electric",
                _ => "Unknown"
            };
        }

        private void btnConfirmBooking_Click(object sender, EventArgs e)
        {
            if (!ValidateBooking())
            {
                return;
            }

            string firstName = txtFirstName.Text.Trim();
            string surname = txtSurname.Text.Trim();
            string address = txtAddress.Text.Trim();
            int age = (int)numAge.Value;
            int rentalDays = (int)numRentalDays.Value;
            string carType = GetCarTypeName();
            string fuelType = GetFuelTypeName();
            string extras = GetExtrasString();
            decimal totalCost = GetTotalCost();

            string summary = $"Customer Details:\n" +
                           $"Name: {firstName} {surname}\n" +
                           $"Address: {address}\n" +
                           $"Age: {age}\n\n" +
                           $"Rental Details:\n" +
                           $"Duration: {rentalDays} day(s)\n" +
                           $"Car Type: {carType}\n" +
                           $"Fuel Type: {fuelType}\n" +
                           $"Extras: {extras}\n\n" +
                           $"Total Cost: £{totalCost:F2}\n\n" +
                           $"Confirm this booking?";

            DialogResult result = MessageBox.Show(summary, "Confirm Booking",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DatabaseHelper.InsertBooking(firstName, surname, address, age,
                                                rentalDays, carType, fuelType, extras, totalCost);

                    MessageBox.Show($"? Booking confirmed successfully!\n\n" +
                                  $"Customer: {firstName} {surname}\n" +
                                  $"Total Cost: £{totalCost:F2}\n\n" +
                                  $"Booking saved to database.",
                                  "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"? Failed to save booking to database.\n\n" +
                                  $"Error: {ex.Message}\n\n" +
                                  $"Please check your database connection settings in DatabaseHelper.cs",
                                  "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateBooking()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Please enter customer's first name.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSurname.Text))
            {
                MessageBox.Show("Please enter customer's surname.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSurname.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Please enter customer's address.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }

            if (numAge.Value < 18)
            {
                MessageBox.Show("Customer must be 18 or over to rent a vehicle.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numAge.Focus();
                return false;
            }

            if (rbLicenceNo.Checked)
            {
                MessageBox.Show("A valid driving licence is required to rent a vehicle.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private string GetExtrasString()
        {
            var extras = new System.Collections.Generic.List<string>();
            
            if (chkUnlimitedMileage.Checked)
                extras.Add("Unlimited Mileage");
            
            if (chkBreakdownCover.Checked)
                extras.Add("Breakdown Cover");

            return extras.Count > 0 ? string.Join(", ", extras) : "None";
        }

        private decimal GetTotalCost()
        {
            int rentalDays = (int)numRentalDays.Value;
            decimal baseCost = DAILY_RENTAL_RATE * rentalDays;
            decimal carCost = GetCarTypeSurcharge();
            decimal fuelCost = GetFuelTypeSurcharge();
            decimal mileageCost = chkUnlimitedMileage.Checked ? UNLIMITED_MILEAGE_DAILY * rentalDays : 0;
            decimal breakdownCost = chkBreakdownCover.Checked ? BREAKDOWN_COVER_DAILY * rentalDays : 0;

            return baseCost + carCost + fuelCost + mileageCost + breakdownCost;
        }

        private void ClearForm()
        {
            txtFirstName.Clear();
            txtSurname.Clear();
            txtAddress.Clear();
            numAge.Value = 18;
            rbLicenceYes.Checked = true;
            numRentalDays.Value = 1;
            cmbCarType.SelectedIndex = 0;
            cmbFuelType.SelectedIndex = 0;
            chkUnlimitedMileage.Checked = false;
            chkBreakdownCover.Checked = false;
            txtFirstName.Focus();
        }
    }
}
