namespace WeAreCarsRentalSystemWinForms
{
    partial class WelcomeForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Button btnProceed;
        private System.Windows.Forms.Panel panelMain;

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
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.btnProceed = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.lblTitle);
            this.panelMain.Controls.Add(this.lblSubtitle);
            this.panelMain.Controls.Add(this.lblInstructions);
            this.panelMain.Controls.Add(this.btnProceed);
            this.panelMain.Location = new System.Drawing.Point(30, 30);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(540, 390);
            this.panelMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = false;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 40);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(500, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "WeAreCars Rental System";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = false;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtitle.Location = new System.Drawing.Point(20, 90);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(500, 25);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "CET131 Assessment 2";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = false;
            this.lblInstructions.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInstructions.Location = new System.Drawing.Point(50, 150);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(440, 140);
            this.lblInstructions.TabIndex = 2;
            this.lblInstructions.Text = "Welcome to WeAreCars Rental System!\r\n\r\nInstructions:\r\n1. Staff must login with valid credentials\r\n2. Enter customer details and rental preferences\r\n3. Review and confirm the booking\r\n\r\nClick \'Proceed to Login\' to continue...";
            this.lblInstructions.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // btnProceed
            // 
            this.btnProceed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnProceed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProceed.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnProceed.ForeColor = System.Drawing.Color.White;
            this.btnProceed.Location = new System.Drawing.Point(170, 310);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.Size = new System.Drawing.Size(200, 45);
            this.btnProceed.TabIndex = 3;
            this.btnProceed.Text = "Proceed to Login";
            this.btnProceed.UseVisualStyleBackColor = false;
            this.btnProceed.Click += new System.EventHandler(this.btnProceed_Click);
            // 
            // WelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "WelcomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WeAreCars Rental System - Welcome";
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
