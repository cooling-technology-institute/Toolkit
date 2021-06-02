
namespace CTIToolkit
{
    partial class PrintLabelForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintLabelForm));
            this.OKButton = new System.Windows.Forms.Button();
            this.DocumentLabelTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PreformanceDataRadioButton = new System.Windows.Forms.RadioButton();
            this.DesignRadioButton = new System.Windows.Forms.RadioButton();
            this.DataGroupBox = new System.Windows.Forms.GroupBox();
            this.DataGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(286, 33);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 24);
            this.OKButton.TabIndex = 2;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // DocumentLabelTextBox
            // 
            this.DocumentLabelTextBox.Location = new System.Drawing.Point(13, 35);
            this.DocumentLabelTextBox.Name = "DocumentLabelTextBox";
            this.DocumentLabelTextBox.Size = new System.Drawing.Size(260, 20);
            this.DocumentLabelTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter optional document label:";
            // 
            // PreformanceDataRadioButton
            // 
            this.PreformanceDataRadioButton.AutoSize = true;
            this.PreformanceDataRadioButton.Checked = true;
            this.PreformanceDataRadioButton.Location = new System.Drawing.Point(24, 23);
            this.PreformanceDataRadioButton.Name = "PreformanceDataRadioButton";
            this.PreformanceDataRadioButton.Size = new System.Drawing.Size(111, 17);
            this.PreformanceDataRadioButton.TabIndex = 0;
            this.PreformanceDataRadioButton.TabStop = true;
            this.PreformanceDataRadioButton.Text = "Performance Data";
            this.PreformanceDataRadioButton.UseVisualStyleBackColor = true;
            // 
            // DesignRadioButton
            // 
            this.DesignRadioButton.AutoSize = true;
            this.DesignRadioButton.Location = new System.Drawing.Point(177, 23);
            this.DesignRadioButton.Name = "DesignRadioButton";
            this.DesignRadioButton.Size = new System.Drawing.Size(84, 17);
            this.DesignRadioButton.TabIndex = 1;
            this.DesignRadioButton.Text = "Design Data";
            this.DesignRadioButton.UseVisualStyleBackColor = true;
            // 
            // DataGroupBox
            // 
            this.DataGroupBox.Controls.Add(this.DesignRadioButton);
            this.DataGroupBox.Controls.Add(this.PreformanceDataRadioButton);
            this.DataGroupBox.Location = new System.Drawing.Point(12, 71);
            this.DataGroupBox.Name = "DataGroupBox";
            this.DataGroupBox.Size = new System.Drawing.Size(281, 48);
            this.DataGroupBox.TabIndex = 0;
            this.DataGroupBox.TabStop = false;
            this.DataGroupBox.Text = "Data Type Selection";
            // 
            // PrintLabelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 131);
            this.Controls.Add(this.DataGroupBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DocumentLabelTextBox);
            this.Controls.Add(this.OKButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PrintLabelForm";
            this.Text = "Document Label";
            this.DataGroupBox.ResumeLayout(false);
            this.DataGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.TextBox DocumentLabelTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton PreformanceDataRadioButton;
        private System.Windows.Forms.RadioButton DesignRadioButton;
        private System.Windows.Forms.GroupBox DataGroupBox;
    }
}