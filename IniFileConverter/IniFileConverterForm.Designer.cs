namespace IniFileConverter
{
    partial class IniFileConverterForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.Convert = new System.Windows.Forms.Button();
            this.SelectInput = new System.Windows.Forms.Button();
            this.SelectOutput = new System.Windows.Forms.Button();
            this.OutputDirectory = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ConvertListBox = new System.Windows.Forms.ListBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.InputDirectoryComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input File Directory";
            // 
            // Convert
            // 
            this.Convert.Location = new System.Drawing.Point(35, 90);
            this.Convert.Name = "Convert";
            this.Convert.Size = new System.Drawing.Size(75, 23);
            this.Convert.TabIndex = 2;
            this.Convert.Text = "Convert";
            this.Convert.UseVisualStyleBackColor = true;
            this.Convert.Click += new System.EventHandler(this.Convert_Click);
            // 
            // SelectInput
            // 
            this.SelectInput.Location = new System.Drawing.Point(667, 21);
            this.SelectInput.Name = "SelectInput";
            this.SelectInput.Size = new System.Drawing.Size(75, 23);
            this.SelectInput.TabIndex = 4;
            this.SelectInput.Text = "Select Folder";
            this.SelectInput.UseVisualStyleBackColor = true;
            this.SelectInput.Click += new System.EventHandler(this.SelectInput_Click);
            // 
            // SelectOutput
            // 
            this.SelectOutput.Location = new System.Drawing.Point(667, 56);
            this.SelectOutput.Name = "SelectOutput";
            this.SelectOutput.Size = new System.Drawing.Size(75, 23);
            this.SelectOutput.TabIndex = 7;
            this.SelectOutput.Text = "Select Folder";
            this.SelectOutput.UseVisualStyleBackColor = true;
            this.SelectOutput.Click += new System.EventHandler(this.SelectOutput_Click);
            // 
            // OutputDirectory
            // 
            this.OutputDirectory.Location = new System.Drawing.Point(138, 58);
            this.OutputDirectory.Name = "OutputDirectory";
            this.OutputDirectory.Size = new System.Drawing.Size(506, 20);
            this.OutputDirectory.TabIndex = 6;
            this.OutputDirectory.TextChanged += new System.EventHandler(this.OutputDirectory_TextChanged);
            this.OutputDirectory.Validating += new System.ComponentModel.CancelEventHandler(this.OutputDirectory_Validating);
            this.OutputDirectory.Validated += new System.EventHandler(this.OutputDirectory_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Output File Directory";
            // 
            // ConvertListBox
            // 
            this.ConvertListBox.FormattingEnabled = true;
            this.ConvertListBox.Location = new System.Drawing.Point(35, 140);
            this.ConvertListBox.Name = "ConvertListBox";
            this.ConvertListBox.Size = new System.Drawing.Size(707, 303);
            this.ConvertListBox.TabIndex = 8;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // InputDirectoryComboBox
            // 
            this.InputDirectoryComboBox.FormattingEnabled = true;
            this.InputDirectoryComboBox.Location = new System.Drawing.Point(138, 23);
            this.InputDirectoryComboBox.Name = "InputDirectoryComboBox";
            this.InputDirectoryComboBox.Size = new System.Drawing.Size(506, 21);
            this.InputDirectoryComboBox.TabIndex = 9;
            this.InputDirectoryComboBox.SelectedIndexChanged += new System.EventHandler(this.InputDirectoryComboBox_SelectedIndexChanged);
            // 
            // IniFileConverterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 461);
            this.Controls.Add(this.InputDirectoryComboBox);
            this.Controls.Add(this.ConvertListBox);
            this.Controls.Add(this.SelectOutput);
            this.Controls.Add(this.OutputDirectory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SelectInput);
            this.Controls.Add(this.Convert);
            this.Controls.Add(this.label1);
            this.Name = "IniFileConverterForm";
            this.Text = "Data File Format Converter";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Convert;
        private System.Windows.Forms.Button SelectInput;
        private System.Windows.Forms.Button SelectOutput;
        private System.Windows.Forms.TextBox OutputDirectory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox ConvertListBox;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox InputDirectoryComboBox;
    }
}

