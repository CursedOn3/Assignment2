namespace WeAreCarsRentalSystemWinForms
{
    partial class MenuForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnNewBooking;
        private System.Windows.Forms.Button btnViewBookings;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblWelcome;

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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnNewBooking = new System.Windows.Forms.Button();
            this.btnViewBookings = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.lblTitle);
            this.panelMain.Controls.Add(this.lblWelcome);
            this.panelMain.Controls.Add(this.btnNewBooking);
            this.panelMain.Controls.Add(this.btnViewBookings);
            this.panelMain.Location = new System.Drawing.Point(30, 30);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(540, 390);
            this.panelMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = false;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 40);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(500, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "WeAreCars Rental System";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = false;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblWelcome.ForeColor = System.Drawing.Color.Gray;
            this.lblWelcome.Location = new System.Drawing.Point(20, 85);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(500, 30);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome! Please select an option:";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNewBooking
            // 
            this.btnNewBooking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.btnNewBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewBooking.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnNewBooking.ForeColor = System.Drawing.Color.White;
            this.btnNewBooking.Location = new System.Drawing.Point(120, 160);
            this.btnNewBooking.Name = "btnNewBooking";
            this.btnNewBooking.Size = new System.Drawing.Size(300, 70);
            this.btnNewBooking.TabIndex = 2;
            this.btnNewBooking.Text = "New Booking";
            this.btnNewBooking.UseVisualStyleBackColor = false;
            this.btnNewBooking.Click += new System.EventHandler(this.btnNewBooking_Click);
            // 
            // btnViewBookings
            // 
            this.btnViewBookings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnViewBookings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewBookings.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnViewBookings.ForeColor = System.Drawing.Color.White;
            this.btnViewBookings.Location = new System.Drawing.Point(120, 260);
            this.btnViewBookings.Name = "btnViewBookings";
            this.btnViewBookings.Size = new System.Drawing.Size(300, 70);
            this.btnViewBookings.TabIndex = 3;
            this.btnViewBookings.Text = "View Bookings";
            this.btnViewBookings.UseVisualStyleBackColor = false;
            this.btnViewBookings.Click += new System.EventHandler(this.btnViewBookings_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WeAreCars Rental System - Main Menu";
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
