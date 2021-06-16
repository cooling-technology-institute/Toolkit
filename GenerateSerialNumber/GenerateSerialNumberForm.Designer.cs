
namespace GenerateSerialNumber
{
    partial class GenerateSerialNumberForm
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
            this.serialNumber = new System.Windows.Forms.TextBox();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // serialNumber
            // 
            this.serialNumber.Location = new System.Drawing.Point(13, 26);
            this.serialNumber.Name = "serialNumber";
            this.serialNumber.Size = new System.Drawing.Size(238, 20);
            this.serialNumber.TabIndex = 0;
            // 
            // GenerateButton
            // 
            this.GenerateButton.Location = new System.Drawing.Point(298, 26);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(145, 23);
            this.GenerateButton.TabIndex = 1;
            this.GenerateButton.Text = "Generate Serial Number";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 74);
            this.Controls.Add(this.GenerateButton);
            this.Controls.Add(this.serialNumber);
            this.Name = "Form1";
            this.Text = "CTI Toolkit Serial Number Generator 4.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox serialNumber;
        private System.Windows.Forms.Button GenerateButton;
    }
}

