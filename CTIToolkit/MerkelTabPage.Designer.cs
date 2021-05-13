namespace CTIToolkit
{
    partial class MerkelTabPage
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.InputPropertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.ElevationPressureLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BarometricPressureRadio = new System.Windows.Forms.RadioButton();
            this.ElevationRadio = new System.Windows.Forms.RadioButton();
            this.WetBulbTemperatureUnits = new System.Windows.Forms.Label();
            this.ElevationPressureUnits = new System.Windows.Forms.Label();
            this.Elevation_Value = new System.Windows.Forms.TextBox();
            this.LiquidtoGasRatioLabel = new System.Windows.Forms.Label();
            this.LiquidtoGasRatio_Value = new System.Windows.Forms.TextBox();
            this.WetBulbTemperatureLabel = new System.Windows.Forms.Label();
            this.ColdWaterTemperatureUnits = new System.Windows.Forms.Label();
            this.HotWaterTemperatureUnits = new System.Windows.Forms.Label();
            this.WetBulbTemperature_Value = new System.Windows.Forms.TextBox();
            this.ColdWaterTemperature_Value = new System.Windows.Forms.TextBox();
            this.HotWaterTemperature_Value = new System.Windows.Forms.TextBox();
            this.ColdWaterTemperatureLabel = new System.Windows.Forms.Label();
            this.HotWaterTemperatureLabel = new System.Windows.Forms.Label();
            this.MerkelCalculate = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.DataFilename = new System.Windows.Forms.TextBox();
            this.DataFileLabel = new System.Windows.Forms.Label();
            this.CalculatedValuesGridView = new System.Windows.Forms.DataGridView();
            this.CalculatedValuesGroupBox = new System.Windows.Forms.GroupBox();
            this.InputPropertiesGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CalculatedValuesGridView)).BeginInit();
            this.CalculatedValuesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // InputPropertiesGroupBox
            // 
            this.InputPropertiesGroupBox.Controls.Add(this.ElevationPressureLabel);
            this.InputPropertiesGroupBox.Controls.Add(this.groupBox2);
            this.InputPropertiesGroupBox.Controls.Add(this.WetBulbTemperatureUnits);
            this.InputPropertiesGroupBox.Controls.Add(this.ElevationPressureUnits);
            this.InputPropertiesGroupBox.Controls.Add(this.Elevation_Value);
            this.InputPropertiesGroupBox.Controls.Add(this.LiquidtoGasRatioLabel);
            this.InputPropertiesGroupBox.Controls.Add(this.LiquidtoGasRatio_Value);
            this.InputPropertiesGroupBox.Controls.Add(this.WetBulbTemperatureLabel);
            this.InputPropertiesGroupBox.Controls.Add(this.ColdWaterTemperatureUnits);
            this.InputPropertiesGroupBox.Controls.Add(this.HotWaterTemperatureUnits);
            this.InputPropertiesGroupBox.Controls.Add(this.WetBulbTemperature_Value);
            this.InputPropertiesGroupBox.Controls.Add(this.ColdWaterTemperature_Value);
            this.InputPropertiesGroupBox.Controls.Add(this.HotWaterTemperature_Value);
            this.InputPropertiesGroupBox.Controls.Add(this.ColdWaterTemperatureLabel);
            this.InputPropertiesGroupBox.Controls.Add(this.HotWaterTemperatureLabel);
            this.InputPropertiesGroupBox.Location = new System.Drawing.Point(3, 36);
            this.InputPropertiesGroupBox.Name = "InputPropertiesGroupBox";
            this.InputPropertiesGroupBox.Size = new System.Drawing.Size(743, 186);
            this.InputPropertiesGroupBox.TabIndex = 11;
            this.InputPropertiesGroupBox.TabStop = false;
            this.InputPropertiesGroupBox.Text = "Input Properties";
            // 
            // ElevationPressureLabel
            // 
            this.ElevationPressureLabel.Location = new System.Drawing.Point(36, 117);
            this.ElevationPressureLabel.Name = "ElevationPressureLabel";
            this.ElevationPressureLabel.Size = new System.Drawing.Size(110, 13);
            this.ElevationPressureLabel.TabIndex = 23;
            this.ElevationPressureLabel.Text = "Elevation:";
            this.ElevationPressureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.BarometricPressureRadio);
            this.groupBox2.Controls.Add(this.ElevationRadio);
            this.groupBox2.Location = new System.Drawing.Point(287, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(164, 79);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            // 
            // BarometricPressureRadio
            // 
            this.BarometricPressureRadio.Location = new System.Drawing.Point(17, 50);
            this.BarometricPressureRadio.Name = "BarometricPressureRadio";
            this.BarometricPressureRadio.Size = new System.Drawing.Size(130, 17);
            this.BarometricPressureRadio.TabIndex = 1;
            this.BarometricPressureRadio.Text = "Barometric Pressure";
            this.BarometricPressureRadio.UseVisualStyleBackColor = true;
            this.BarometricPressureRadio.CheckedChanged += new System.EventHandler(this.BarometricPressureRadio_CheckedChanged);
            // 
            // ElevationRadio
            // 
            this.ElevationRadio.Checked = true;
            this.ElevationRadio.Location = new System.Drawing.Point(17, 21);
            this.ElevationRadio.Name = "ElevationRadio";
            this.ElevationRadio.Size = new System.Drawing.Size(130, 17);
            this.ElevationRadio.TabIndex = 0;
            this.ElevationRadio.TabStop = true;
            this.ElevationRadio.Text = "Elevation";
            this.ElevationRadio.UseVisualStyleBackColor = true;
            this.ElevationRadio.CheckedChanged += new System.EventHandler(this.ElevationRadio_CheckedChanged);
            // 
            // WetBulbTemperatureUnits
            // 
            this.WetBulbTemperatureUnits.AutoSize = true;
            this.WetBulbTemperatureUnits.Location = new System.Drawing.Point(244, 93);
            this.WetBulbTemperatureUnits.Name = "WetBulbTemperatureUnits";
            this.WetBulbTemperatureUnits.Size = new System.Drawing.Size(17, 13);
            this.WetBulbTemperatureUnits.TabIndex = 18;
            this.WetBulbTemperatureUnits.Text = "°F";
            // 
            // ElevationPressureUnits
            // 
            this.ElevationPressureUnits.AutoSize = true;
            this.ElevationPressureUnits.Location = new System.Drawing.Point(244, 120);
            this.ElevationPressureUnits.Name = "ElevationPressureUnits";
            this.ElevationPressureUnits.Size = new System.Drawing.Size(13, 13);
            this.ElevationPressureUnits.TabIndex = 16;
            this.ElevationPressureUnits.Text = "ft";
            // 
            // Elevation_Value
            // 
            this.Elevation_Value.Location = new System.Drawing.Point(152, 114);
            this.Elevation_Value.Name = "Elevation_Value";
            this.Elevation_Value.Size = new System.Drawing.Size(70, 20);
            this.Elevation_Value.TabIndex = 15;
            this.Elevation_Value.Text = "0";
            this.Elevation_Value.Validating += new System.ComponentModel.CancelEventHandler(this.Merkel_Elevation_Value_Validating);
            this.Elevation_Value.Validated += new System.EventHandler(this.Merkel_Elevation_Value_Validated);
            // 
            // LiquidtoGasRatioLabel
            // 
            this.LiquidtoGasRatioLabel.Location = new System.Drawing.Point(14, 143);
            this.LiquidtoGasRatioLabel.Name = "LiquidtoGasRatioLabel";
            this.LiquidtoGasRatioLabel.Size = new System.Drawing.Size(132, 13);
            this.LiquidtoGasRatioLabel.TabIndex = 14;
            this.LiquidtoGasRatioLabel.Text = "Liquid to Gas Ratio:";
            this.LiquidtoGasRatioLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LiquidtoGasRatio_Value
            // 
            this.LiquidtoGasRatio_Value.Location = new System.Drawing.Point(152, 140);
            this.LiquidtoGasRatio_Value.Name = "LiquidtoGasRatio_Value";
            this.LiquidtoGasRatio_Value.Size = new System.Drawing.Size(70, 20);
            this.LiquidtoGasRatio_Value.TabIndex = 12;
            this.LiquidtoGasRatio_Value.Text = "0";
            this.LiquidtoGasRatio_Value.Validating += new System.ComponentModel.CancelEventHandler(this.Merkel_LiquidtoGasRatio_Value_Validating);
            this.LiquidtoGasRatio_Value.Validated += new System.EventHandler(this.Merkel_LiquidtoGasRatio_Value_Validated);
            // 
            // WetBulbTemperatureLabel
            // 
            this.WetBulbTemperatureLabel.Location = new System.Drawing.Point(14, 91);
            this.WetBulbTemperatureLabel.Name = "WetBulbTemperatureLabel";
            this.WetBulbTemperatureLabel.Size = new System.Drawing.Size(132, 13);
            this.WetBulbTemperatureLabel.TabIndex = 11;
            this.WetBulbTemperatureLabel.Text = "Wet Bulb Temperature:";
            this.WetBulbTemperatureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ColdWaterTemperatureUnits
            // 
            this.ColdWaterTemperatureUnits.AutoSize = true;
            this.ColdWaterTemperatureUnits.Location = new System.Drawing.Point(244, 66);
            this.ColdWaterTemperatureUnits.Name = "ColdWaterTemperatureUnits";
            this.ColdWaterTemperatureUnits.Size = new System.Drawing.Size(17, 13);
            this.ColdWaterTemperatureUnits.TabIndex = 7;
            this.ColdWaterTemperatureUnits.Text = "°F";
            // 
            // HotWaterTemperatureUnits
            // 
            this.HotWaterTemperatureUnits.AutoSize = true;
            this.HotWaterTemperatureUnits.Location = new System.Drawing.Point(244, 39);
            this.HotWaterTemperatureUnits.Name = "HotWaterTemperatureUnits";
            this.HotWaterTemperatureUnits.Size = new System.Drawing.Size(17, 13);
            this.HotWaterTemperatureUnits.TabIndex = 6;
            this.HotWaterTemperatureUnits.Text = "°F";
            // 
            // WetBulbTemperature_Value
            // 
            this.WetBulbTemperature_Value.Location = new System.Drawing.Point(152, 88);
            this.WetBulbTemperature_Value.Name = "WetBulbTemperature_Value";
            this.WetBulbTemperature_Value.Size = new System.Drawing.Size(70, 20);
            this.WetBulbTemperature_Value.TabIndex = 5;
            this.WetBulbTemperature_Value.Text = "0";
            this.WetBulbTemperature_Value.Validating += new System.ComponentModel.CancelEventHandler(this.Merkel_WetBulbTemperature_Value_Validating);
            this.WetBulbTemperature_Value.Validated += new System.EventHandler(this.Merkel_WetBulbTemperature_Value_Validated);
            // 
            // ColdWaterTemperature_Value
            // 
            this.ColdWaterTemperature_Value.Location = new System.Drawing.Point(152, 62);
            this.ColdWaterTemperature_Value.Name = "ColdWaterTemperature_Value";
            this.ColdWaterTemperature_Value.Size = new System.Drawing.Size(70, 20);
            this.ColdWaterTemperature_Value.TabIndex = 4;
            this.ColdWaterTemperature_Value.Text = "90";
            this.ColdWaterTemperature_Value.Validating += new System.ComponentModel.CancelEventHandler(this.Merkel_ColdWaterTemperature_Value_Validating);
            // 
            // HotWaterTemperature_Value
            // 
            this.helpProvider1.SetHelpKeyword(this.HotWaterTemperature_Value, "MerkelHotWater");
            this.HotWaterTemperature_Value.Location = new System.Drawing.Point(152, 36);
            this.HotWaterTemperature_Value.Name = "HotWaterTemperature_Value";
            this.helpProvider1.SetShowHelp(this.HotWaterTemperature_Value, true);
            this.HotWaterTemperature_Value.Size = new System.Drawing.Size(70, 20);
            this.HotWaterTemperature_Value.TabIndex = 3;
            this.HotWaterTemperature_Value.Text = "80";
            this.HotWaterTemperature_Value.Validating += new System.ComponentModel.CancelEventHandler(this.Merkel_HotWaterTemperature_Value_Validating);
            this.HotWaterTemperature_Value.Validated += new System.EventHandler(this.Merkel_HotWaterTemperature_Value_Validated);
            // 
            // ColdWaterTemperatureLabel
            // 
            this.ColdWaterTemperatureLabel.Location = new System.Drawing.Point(14, 65);
            this.ColdWaterTemperatureLabel.Name = "ColdWaterTemperatureLabel";
            this.ColdWaterTemperatureLabel.Size = new System.Drawing.Size(132, 13);
            this.ColdWaterTemperatureLabel.TabIndex = 1;
            this.ColdWaterTemperatureLabel.Text = "Cold Water Temperature:";
            this.ColdWaterTemperatureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // HotWaterTemperatureLabel
            // 
            this.HotWaterTemperatureLabel.Location = new System.Drawing.Point(14, 39);
            this.HotWaterTemperatureLabel.Name = "HotWaterTemperatureLabel";
            this.HotWaterTemperatureLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.HotWaterTemperatureLabel.Size = new System.Drawing.Size(132, 13);
            this.HotWaterTemperatureLabel.TabIndex = 0;
            this.HotWaterTemperatureLabel.Text = "Hot Water Temperature:";
            this.HotWaterTemperatureLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // MerkelCalculate
            // 
            this.MerkelCalculate.Location = new System.Drawing.Point(682, 3);
            this.MerkelCalculate.Name = "MerkelCalculate";
            this.MerkelCalculate.Size = new System.Drawing.Size(75, 23);
            this.MerkelCalculate.TabIndex = 15;
            this.MerkelCalculate.Text = "Calculate";
            this.MerkelCalculate.UseVisualStyleBackColor = true;
            this.MerkelCalculate.Click += new System.EventHandler(this.MerkelCalculate_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // DataFilename
            // 
            this.DataFilename.Location = new System.Drawing.Point(72, 5);
            this.DataFilename.Name = "DataFilename";
            this.DataFilename.ReadOnly = true;
            this.DataFilename.Size = new System.Drawing.Size(541, 20);
            this.DataFilename.TabIndex = 28;
            // 
            // DataFileLabel
            // 
            this.DataFileLabel.AutoSize = true;
            this.DataFileLabel.Location = new System.Drawing.Point(7, 8);
            this.DataFileLabel.Name = "DataFileLabel";
            this.DataFileLabel.Size = new System.Drawing.Size(55, 13);
            this.DataFileLabel.TabIndex = 27;
            this.DataFileLabel.Text = "Data  File:";
            // 
            // CalculatedValuesGridView
            // 
            this.CalculatedValuesGridView.AllowUserToAddRows = false;
            this.CalculatedValuesGridView.AllowUserToDeleteRows = false;
            this.CalculatedValuesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CalculatedValuesGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.CalculatedValuesGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CalculatedValuesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CalculatedValuesGridView.Location = new System.Drawing.Point(7, 20);
            this.CalculatedValuesGridView.Name = "CalculatedValuesGridView";
            this.CalculatedValuesGridView.ReadOnly = true;
            this.CalculatedValuesGridView.Size = new System.Drawing.Size(730, 63);
            this.CalculatedValuesGridView.TabIndex = 0;
            this.CalculatedValuesGridView.TabStop = false;
            // 
            // CalculatedValuesGroupBox
            // 
            this.CalculatedValuesGroupBox.Controls.Add(this.CalculatedValuesGridView);
            this.CalculatedValuesGroupBox.Location = new System.Drawing.Point(10, 228);
            this.CalculatedValuesGroupBox.Name = "CalculatedValuesGroupBox";
            this.CalculatedValuesGroupBox.Size = new System.Drawing.Size(743, 125);
            this.CalculatedValuesGroupBox.TabIndex = 32;
            this.CalculatedValuesGroupBox.TabStop = false;
            this.CalculatedValuesGroupBox.Text = "Calculated Values:";
            // 
            // MerkelTabPage
            // 
            this.Controls.Add(this.CalculatedValuesGroupBox);
            this.Controls.Add(this.MerkelCalculate);
            this.Controls.Add(this.DataFilename);
            this.Controls.Add(this.DataFileLabel);
            this.Controls.Add(this.InputPropertiesGroupBox);
            this.Name = "MerkelTabPage";
            this.Size = new System.Drawing.Size(767, 554);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.MerkelTabPage_HelpRequested);
            this.InputPropertiesGroupBox.ResumeLayout(false);
            this.InputPropertiesGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CalculatedValuesGridView)).EndInit();
            this.CalculatedValuesGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox InputPropertiesGroupBox;
        private System.Windows.Forms.Label WetBulbTemperatureLabel;
        private System.Windows.Forms.Label ColdWaterTemperatureUnits;
        private System.Windows.Forms.Label HotWaterTemperatureUnits;
        private System.Windows.Forms.TextBox WetBulbTemperature_Value;
        private System.Windows.Forms.TextBox ColdWaterTemperature_Value;
        private System.Windows.Forms.TextBox HotWaterTemperature_Value;
        private System.Windows.Forms.Label ColdWaterTemperatureLabel;
        private System.Windows.Forms.Label HotWaterTemperatureLabel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label LiquidtoGasRatioLabel;
        private System.Windows.Forms.TextBox LiquidtoGasRatio_Value;
        private System.Windows.Forms.Label ElevationPressureUnits;
        private System.Windows.Forms.TextBox Elevation_Value;
        private System.Windows.Forms.Label WetBulbTemperatureUnits;
        private System.Windows.Forms.Button MerkelCalculate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton BarometricPressureRadio;
        private System.Windows.Forms.RadioButton ElevationRadio;
        private System.Windows.Forms.Label ElevationPressureLabel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.TextBox DataFilename;
        private System.Windows.Forms.Label DataFileLabel;
        private System.Windows.Forms.GroupBox CalculatedValuesGroupBox;
        private System.Windows.Forms.DataGridView CalculatedValuesGridView;
    }
}
