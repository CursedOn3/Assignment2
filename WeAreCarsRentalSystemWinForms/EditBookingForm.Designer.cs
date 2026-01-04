namespace WeAreCarsRentalSystemWinForms
{
    partial class EditBookingForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpCustomerDetails;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.NumericUpDown numAge;
        private System.Windows.Forms.GroupBox grpRentalDetails;
        private System.Windows.Forms.Label lblRentalDays;
        private System.Windows.Forms.NumericUpDown numRentalDays;
        private System.Windows.Forms.Label lblCarType;
        private System.Windows.Forms.ComboBox cmbCarType;
        private System.Windows.Forms.Label lblFuelType;
        private System.Windows.Forms.ComboBox cmbFuelType;
        private System.Windows.Forms.GroupBox grpOptionalExtras;
        private System.Windows.Forms.CheckBox chkUnlimitedMileage;
        private System.Windows.Forms.CheckBox chkBreakdownCover;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.Label lblTotalCostValue;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpCustomerDetails = new System.Windows.Forms.GroupBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblSurname = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAge = new System.Windows.Forms.Label();
            this.numAge = new System.Windows.Forms.NumericUpDown();
            this.grpRentalDetails = new System.Windows.Forms.GroupBox();
            this.lblRentalDays = new System.Windows.Forms.Label();
            this.numRentalDays = new System.Windows.Forms.NumericUpDown();
            this.lblCarType = new System.Windows.Forms.Label();
            this.cmbCarType = new System.Windows.Forms.ComboBox();
            this.lblFuelType = new System.Windows.Forms.Label();
            this.cmbFuelType = new System.Windows.Forms.ComboBox();
            this.grpOptionalExtras = new System.Windows.Forms.GroupBox();
            this.chkUnlimitedMileage = new System.Windows.Forms.CheckBox();
            this.chkBreakdownCover = new System.Windows.Forms.CheckBox();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.lblTotalCostValue = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpCustomerDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).BeginInit();
            this.grpRentalDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRentalDays)).BeginInit();
            this.grpOptionalExtras.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = false;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(760, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Edit Booking";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpCustomerDetails
            // 
            this.grpCustomerDetails.Controls.Add(this.lblFirstName);
            this.grpCustomerDetails.Controls.Add(this.txtFirstName);
            this.grpCustomerDetails.Controls.Add(this.lblSurname);
            this.grpCustomerDetails.Controls.Add(this.txtSurname);
            this.grpCustomerDetails.Controls.Add(this.lblAddress);
            this.grpCustomerDetails.Controls.Add(this.txtAddress);
            this.grpCustomerDetails.Controls.Add(this.lblAge);
            this.grpCustomerDetails.Controls.Add(this.numAge);
            this.grpCustomerDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpCustomerDetails.Location = new System.Drawing.Point(20, 70);
            this.grpCustomerDetails.Name = "grpCustomerDetails";
            this.grpCustomerDetails.Size = new System.Drawing.Size(370, 280);
            this.grpCustomerDetails.TabIndex = 1;
            this.grpCustomerDetails.TabStop = false;
            this.grpCustomerDetails.Text = "Customer Details";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFirstName.Location = new System.Drawing.Point(15, 30);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(83, 20);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFirstName.Location = new System.Drawing.Point(15, 53);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(340, 27);
            this.txtFirstName.TabIndex = 1;
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSurname.Location = new System.Drawing.Point(15, 90);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(70, 20);
            this.lblSurname.TabIndex = 2;
            this.lblSurname.Text = "Surname:";
            // 
            // txtSurname
            // 
            this.txtSurname.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSurname.Location = new System.Drawing.Point(15, 113);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(340, 27);
            this.txtSurname.TabIndex = 3;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAddress.Location = new System.Drawing.Point(15, 150);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(65, 20);
            this.lblAddress.TabIndex = 4;
            this.lblAddress.Text = "Address:";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAddress.Location = new System.Drawing.Point(15, 173);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(340, 27);
            this.txtAddress.TabIndex = 5;
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAge.Location = new System.Drawing.Point(15, 210);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(39, 20);
            this.lblAge.TabIndex = 6;
            this.lblAge.Text = "Age:";
            // 
            // numAge
            // 
            this.numAge.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numAge.Location = new System.Drawing.Point(15, 233);
            this.numAge.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            this.numAge.Minimum = new decimal(new int[] { 18, 0, 0, 0 });
            this.numAge.Name = "numAge";
            this.numAge.Size = new System.Drawing.Size(120, 27);
            this.numAge.TabIndex = 7;
            this.numAge.Value = new decimal(new int[] { 18, 0, 0, 0 });
            // 
            // grpRentalDetails
            // 
            this.grpRentalDetails.Controls.Add(this.lblRentalDays);
            this.grpRentalDetails.Controls.Add(this.numRentalDays);
            this.grpRentalDetails.Controls.Add(this.lblCarType);
            this.grpRentalDetails.Controls.Add(this.cmbCarType);
            this.grpRentalDetails.Controls.Add(this.lblFuelType);
            this.grpRentalDetails.Controls.Add(this.cmbFuelType);
            this.grpRentalDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpRentalDetails.Location = new System.Drawing.Point(410, 70);
            this.grpRentalDetails.Name = "grpRentalDetails";
            this.grpRentalDetails.Size = new System.Drawing.Size(370, 190);
            this.grpRentalDetails.TabIndex = 2;
            this.grpRentalDetails.TabStop = false;
            this.grpRentalDetails.Text = "Rental Details";
            // 
            // lblRentalDays
            // 
            this.lblRentalDays.AutoSize = true;
            this.lblRentalDays.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRentalDays.Location = new System.Drawing.Point(15, 30);
            this.lblRentalDays.Name = "lblRentalDays";
            this.lblRentalDays.Size = new System.Drawing.Size(161, 20);
            this.lblRentalDays.TabIndex = 0;
            this.lblRentalDays.Text = "Number of Rental Days:";
            // 
            // numRentalDays
            // 
            this.numRentalDays.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numRentalDays.Location = new System.Drawing.Point(15, 53);
            this.numRentalDays.Maximum = new decimal(new int[] { 28, 0, 0, 0 });
            this.numRentalDays.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numRentalDays.Name = "numRentalDays";
            this.numRentalDays.Size = new System.Drawing.Size(120, 27);
            this.numRentalDays.TabIndex = 1;
            this.numRentalDays.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.numRentalDays.ValueChanged += new System.EventHandler(this.CalculateTotalCost);
            // 
            // lblCarType
            // 
            this.lblCarType.AutoSize = true;
            this.lblCarType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCarType.Location = new System.Drawing.Point(15, 90);
            this.lblCarType.Name = "lblCarType";
            this.lblCarType.Size = new System.Drawing.Size(69, 20);
            this.lblCarType.TabIndex = 2;
            this.lblCarType.Text = "Car Type:";
            // 
            // cmbCarType
            // 
            this.cmbCarType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCarType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbCarType.FormattingEnabled = true;
            this.cmbCarType.Location = new System.Drawing.Point(15, 113);
            this.cmbCarType.Name = "cmbCarType";
            this.cmbCarType.Size = new System.Drawing.Size(340, 28);
            this.cmbCarType.TabIndex = 3;
            this.cmbCarType.SelectedIndexChanged += new System.EventHandler(this.CalculateTotalCost);
            // 
            // lblFuelType
            // 
            this.lblFuelType.AutoSize = true;
            this.lblFuelType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFuelType.Location = new System.Drawing.Point(220, 30);
            this.lblFuelType.Name = "lblFuelType";
            this.lblFuelType.Size = new System.Drawing.Size(74, 20);
            this.lblFuelType.TabIndex = 4;
            this.lblFuelType.Text = "Fuel Type:";
            // 
            // cmbFuelType
            // 
            this.cmbFuelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFuelType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbFuelType.FormattingEnabled = true;
            this.cmbFuelType.Location = new System.Drawing.Point(220, 53);
            this.cmbFuelType.Name = "cmbFuelType";
            this.cmbFuelType.Size = new System.Drawing.Size(135, 28);
            this.cmbFuelType.TabIndex = 5;
            this.cmbFuelType.SelectedIndexChanged += new System.EventHandler(this.CalculateTotalCost);
            // 
            // grpOptionalExtras
            // 
            this.grpOptionalExtras.Controls.Add(this.chkUnlimitedMileage);
            this.grpOptionalExtras.Controls.Add(this.chkBreakdownCover);
            this.grpOptionalExtras.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpOptionalExtras.Location = new System.Drawing.Point(410, 280);
            this.grpOptionalExtras.Name = "grpOptionalExtras";
            this.grpOptionalExtras.Size = new System.Drawing.Size(370, 70);
            this.grpOptionalExtras.TabIndex = 3;
            this.grpOptionalExtras.TabStop = false;
            this.grpOptionalExtras.Text = "Optional Extras";
            // 
            // chkUnlimitedMileage
            // 
            this.chkUnlimitedMileage.AutoSize = true;
            this.chkUnlimitedMileage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkUnlimitedMileage.Location = new System.Drawing.Point(15, 30);
            this.chkUnlimitedMileage.Name = "chkUnlimitedMileage";
            this.chkUnlimitedMileage.Size = new System.Drawing.Size(224, 24);
            this.chkUnlimitedMileage.TabIndex = 0;
            this.chkUnlimitedMileage.Text = "Unlimited Mileage (+£10/day)";
            this.chkUnlimitedMileage.UseVisualStyleBackColor = true;
            this.chkUnlimitedMileage.CheckedChanged += new System.EventHandler(this.CalculateTotalCost);
            // 
            // chkBreakdownCover
            // 
            this.chkBreakdownCover.AutoSize = true;
            this.chkBreakdownCover.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkBreakdownCover.Location = new System.Drawing.Point(245, 30);
            this.chkBreakdownCover.Name = "chkBreakdownCover";
            this.chkBreakdownCover.Size = new System.Drawing.Size(110, 24);
            this.chkBreakdownCover.TabIndex = 1;
            this.chkBreakdownCover.Text = "Cover (+£2/d)";
            this.chkBreakdownCover.UseVisualStyleBackColor = true;
            this.chkBreakdownCover.CheckedChanged += new System.EventHandler(this.CalculateTotalCost);
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalCost.Location = new System.Drawing.Point(250, 370);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(133, 32);
            this.lblTotalCost.TabIndex = 4;
            this.lblTotalCost.Text = "Total Cost:";
            // 
            // lblTotalCostValue
            // 
            this.lblTotalCostValue.AutoSize = false;
            this.lblTotalCostValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotalCostValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.lblTotalCostValue.Location = new System.Drawing.Point(380, 365);
            this.lblTotalCostValue.Name = "lblTotalCostValue";
            this.lblTotalCostValue.Size = new System.Drawing.Size(180, 40);
            this.lblTotalCostValue.TabIndex = 5;
            this.lblTotalCostValue.Text = "£25.00";
            this.lblTotalCostValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(250, 420);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 50);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "?? Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(420, 420);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 50);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "? Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // EditBookingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 490);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.grpCustomerDetails);
            this.Controls.Add(this.grpRentalDetails);
            this.Controls.Add(this.grpOptionalExtras);
            this.Controls.Add(this.lblTotalCost);
            this.Controls.Add(this.lblTotalCostValue);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditBookingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Booking - WeAreCars Rental System";
            this.grpCustomerDetails.ResumeLayout(false);
            this.grpCustomerDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).EndInit();
            this.grpRentalDetails.ResumeLayout(false);
            this.grpRentalDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRentalDays)).EndInit();
            this.grpOptionalExtras.ResumeLayout(false);
            this.grpOptionalExtras.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
