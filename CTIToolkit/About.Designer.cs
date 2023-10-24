namespace CTIToolkit
{
    partial class About
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.versionLabel = new System.Windows.Forms.Label();
            this.versionNumber = new System.Windows.Forms.Label();
            this.logo = new System.Windows.Forms.PictureBox();
            this.copyright = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.serialNumber = new System.Windows.Forms.Label();
            this.serialNumberLabel = new System.Windows.Forms.Label();
            this.websiteLabel = new System.Windows.Forms.Label();
            this.demoWarning = new System.Windows.Forms.RichTextBox();
            this.setSerialNumberButton = new System.Windows.Forms.Button();
            this.SerialNumberInput = new System.Windows.Forms.TextBox();
            this.setSerialNumberInputLabel = new System.Windows.Forms.Label();
            this.ctiLinkLabel = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(22, 257);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(45, 13);
            this.versionLabel.TabIndex = 0;
            this.versionLabel.Text = "Version:";
            // 
            // versionNumber
            // 
            this.versionNumber.AutoSize = true;
            this.versionNumber.ForeColor = System.Drawing.Color.Red;
            this.versionNumber.Location = new System.Drawing.Point(73, 257);
            this.versionNumber.Name = "versionNumber";
            this.versionNumber.Size = new System.Drawing.Size(22, 13);
            this.versionNumber.TabIndex = 1;
            this.versionNumber.Text = "4.0";
            // 
            // logo
            // 
            this.logo.Image = global::CTIToolkit.Properties.Resources.CTI_Logo;
            this.logo.Location = new System.Drawing.Point(25, 14);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(185, 179);
            this.logo.TabIndex = 2;
            this.logo.TabStop = false;
            // 
            // copyright
            // 
            this.copyright.AutoSize = true;
            this.copyright.Location = new System.Drawing.Point(22, 304);
            this.copyright.Name = "copyright";
            this.copyright.Size = new System.Drawing.Size(245, 13);
            this.copyright.TabIndex = 3;
            this.copyright.Text = "© Cooling Technology Institute. All rights reserved.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(21, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cooling Technology Institute Toolkit";
            // 
            // serialNumber
            // 
            this.serialNumber.AutoSize = true;
            this.serialNumber.Location = new System.Drawing.Point(104, 280);
            this.serialNumber.Name = "serialNumber";
            this.serialNumber.Size = new System.Drawing.Size(31, 13);
            this.serialNumber.TabIndex = 6;
            this.serialNumber.Text = "1234";
            // 
            // serialNumberLabel
            // 
            this.serialNumberLabel.AutoSize = true;
            this.serialNumberLabel.Location = new System.Drawing.Point(22, 280);
            this.serialNumberLabel.Name = "serialNumberLabel";
            this.serialNumberLabel.Size = new System.Drawing.Size(76, 13);
            this.serialNumberLabel.TabIndex = 5;
            this.serialNumberLabel.Text = "Serial Number:";
            // 
            // websiteLabel
            // 
            this.websiteLabel.AutoSize = true;
            this.websiteLabel.Location = new System.Drawing.Point(21, 234);
            this.websiteLabel.Name = "websiteLabel";
            this.websiteLabel.Size = new System.Drawing.Size(54, 13);
            this.websiteLabel.TabIndex = 8;
            this.websiteLabel.Text = "Web Site:";
            // 
            // demoWarning
            // 
            this.demoWarning.BackColor = System.Drawing.SystemColors.Control;
            this.demoWarning.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.demoWarning.ForeColor = System.Drawing.Color.Red;
            this.demoWarning.Location = new System.Drawing.Point(230, 14);
            this.demoWarning.Name = "demoWarning";
            this.demoWarning.ReadOnly = true;
            this.demoWarning.Size = new System.Drawing.Size(282, 83);
            this.demoWarning.TabIndex = 9;
            this.demoWarning.TabStop = false;
            this.demoWarning.Text = resources.GetString("demoWarning.Text");
            // 
            // setSerialNumberButton
            // 
            this.setSerialNumberButton.Location = new System.Drawing.Point(230, 131);
            this.setSerialNumberButton.Name = "setSerialNumberButton";
            this.setSerialNumberButton.Size = new System.Drawing.Size(108, 23);
            this.setSerialNumberButton.TabIndex = 10;
            this.setSerialNumberButton.Text = "Set Serial Number";
            this.setSerialNumberButton.UseVisualStyleBackColor = true;
            this.setSerialNumberButton.Click += new System.EventHandler(this.SetSerialNumber_Click);
            // 
            // SerialNumberInput
            // 
            this.SerialNumberInput.Location = new System.Drawing.Point(312, 103);
            this.SerialNumberInput.Name = "SerialNumberInput";
            this.SerialNumberInput.Size = new System.Drawing.Size(200, 20);
            this.SerialNumberInput.TabIndex = 0;
            // 
            // setSerialNumberInputLabel
            // 
            this.setSerialNumberInputLabel.AutoSize = true;
            this.setSerialNumberInputLabel.Location = new System.Drawing.Point(230, 106);
            this.setSerialNumberInputLabel.Name = "setSerialNumberInputLabel";
            this.setSerialNumberInputLabel.Size = new System.Drawing.Size(76, 13);
            this.setSerialNumberInputLabel.TabIndex = 12;
            this.setSerialNumberInputLabel.Text = "Serial Number:";
            // 
            // ctiLinkLabel
            // 
            this.ctiLinkLabel.AutoSize = true;
            this.ctiLinkLabel.Location = new System.Drawing.Point(76, 233);
            this.ctiLinkLabel.Name = "ctiLinkLabel";
            this.ctiLinkLabel.Size = new System.Drawing.Size(94, 13);
            this.ctiLinkLabel.TabIndex = 13;
            this.ctiLinkLabel.TabStop = true;
            this.ctiLinkLabel.Text = "http://www.cti.org";
            this.ctiLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CtiLinkLabel_LinkClicked);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(550, 334);
            this.Controls.Add(this.ctiLinkLabel);
            this.Controls.Add(this.setSerialNumberInputLabel);
            this.Controls.Add(this.SerialNumberInput);
            this.Controls.Add(this.setSerialNumberButton);
            this.Controls.Add(this.demoWarning);
            this.Controls.Add(this.websiteLabel);
            this.Controls.Add(this.serialNumber);
            this.Controls.Add(this.serialNumberLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.copyright);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.versionNumber);
            this.Controls.Add(this.versionLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "About";
            this.Text = "Cooling Technology Institute About";
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label versionNumber;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Label copyright;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label serialNumber;
        private System.Windows.Forms.Label serialNumberLabel;
        private System.Windows.Forms.Label websiteLabel;
        private System.Windows.Forms.RichTextBox demoWarning;
        private System.Windows.Forms.Button setSerialNumberButton;
        private System.Windows.Forms.TextBox SerialNumberInput;
        private System.Windows.Forms.Label setSerialNumberInputLabel;
        private System.Windows.Forms.LinkLabel ctiLinkLabel;
    }
}