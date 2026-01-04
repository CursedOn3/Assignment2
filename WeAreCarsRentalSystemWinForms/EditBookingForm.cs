using System;
using System.Windows.Forms;

namespace WeAreCarsRentalSystemWinForms
{
    public partial class EditBookingForm : Form
    {
        private const decimal DAILY_RENTAL_RATE = 25.00m;
        private const decimal FAMILY_CAR_SURCHARGE = 50.00m;
        private const decimal SPORTS_CAR_SURCHARGE = 75.00m;
        private const decimal SUV_SURCHARGE = 65.00m;
        private const decimal HYBRID_SURCHARGE = 30.00m;
        private const decimal ELECTRIC_SURCHARGE = 50.00m;
        private const decimal UNLIMITED_MILEAGE_DAILY = 10.00m;
        private const decimal BREAKDOWN_COVER_DAILY = 2.00m;

        private int bookingId;
        public bool BookingUpdated { get; private set; }

        public EditBookingForm(int id, string firstName, string surname, string address, int age,
                               int rentalDays, string carType, string fuelType, string extras)
        {
            InitializeComponent();
            InitializeComboBoxes();
            
            bookingId = id;
            LoadBookingData(firstName, surname, address, age, rentalDays, carType, fuelType, extras);
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

            cmbFuelType.Items.AddRange(new object[]
            {
                "Petrol (+£0)",
                "Diesel (+£0)",
                "Hybrid (+£30)",
                "Electric (+£50)"
            });
        }

        private void LoadBookingData(string firstName, string surname, string address, int age,
                                    int rentalDays, string carType, string fuelType, string extras)
        {
            txtFirstName.Text = firstName;
            txtSurname.Text = surname;
            txtAddress.Text = address;
            numAge.Value = age;
            numRentalDays.Value = rentalDays;

            // Set car type
            switch (carType)
            {
                case "City Car": cmbCarType.SelectedIndex = 0; break;
                case "Family Car": cmbCarType.SelectedIndex = 1; break;
                case "Sports Car": cmbCarType.SelectedIndex = 2; break;
                case "SUV": cmbCarType.SelectedIndex = 3; break;
                default: cmbCarType.SelectedIndex = 0; break;
            }

            // Set fuel type
            switch (fuelType)
            {
                case "Petrol": cmbFuelType.SelectedIndex = 0; break;
                case "Diesel": cmbFuelType.SelectedIndex = 1; break;
                case "Hybrid": cmbFuelType.SelectedIndex = 2; break;
                case "Electric": cmbFuelType.SelectedIndex = 3; break;
                default: cmbFuelType.SelectedIndex = 0; break;
            }

            // Set extras
            if (!string.IsNullOrEmpty(extras) && extras != "None")
            {
                chkUnlimitedMileage.Checked = extras.Contains("Unlimited Mileage");
                chkBreakdownCover.Checked = extras.Contains("Breakdown Cover");
            }
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
                _ => "City Car"
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
                _ => "Petrol"
            };
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

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
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

            try
            {
                DatabaseHelper.UpdateBooking(bookingId, firstName, surname, address, age,
                                            rentalDays, carType, fuelType, extras, totalCost);

                MessageBox.Show("Booking updated successfully!", "Success", 
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                BookingUpdated = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating booking:\n\n{ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            BookingUpdated = false;
            this.Close();
        }
    }
}
