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
            this.MerkelElevationPressureLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BarometricPressureRadio = new System.Windows.Forms.RadioButton();
            this.ElevationRadio = new System.Windows.Forms.RadioButton();
            this.MerkelWebBulbTemperatureUnits = new System.Windows.Forms.Label();
            this.MerkelElevationPressureUnits = new System.Windows.Forms.Label();
            this.Merkel_Elevation_Value = new System.Windows.Forms.TextBox();
            this.LiquidtoGasRatioLabel = new System.Windows.Forms.Label();
            this.Merkel_LiquidtoGasRatio_Value = new System.Windows.Forms.TextBox();
            this.MerkelWetBulbTemperatureLabel = new System.Windows.Forms.Label();
            this.MerkelTemperatureColdWaterUnits = new System.Windows.Forms.Label();
            this.MerkelTemperatureHotWaterUnits = new System.Windows.Forms.Label();
            this.Merkel_WetBulbTemperature_Value = new System.Windows.Forms.TextBox();
            this.Merkel_ColdWaterTemperature_Value = new System.Windows.Forms.TextBox();
            this.Merkel_HotWaterTemperature_Value = new System.Windows.Forms.TextBox();
            this.TemperatureColdWaterLabel = new System.Windows.Forms.Label();
            this.TemperatureHotWaterLabel = new System.Windows.Forms.Label();
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
            this.InputPropertiesGroupBox.Controls.Add(this.MerkelElevationPressureLabel);
            this.InputPropertiesGroupBox.Controls.Add(this.groupBox2);
            this.InputPropertiesGroupBox.Controls.Add(this.MerkelWebBulbTemperatureUnits);
            this.InputPropertiesGroupBox.Controls.Add(this.MerkelElevationPressureUnits);
            this.InputPropertiesGroupBox.Controls.Add(this.Merkel_Elevation_Value);
            this.InputPropertiesGroupBox.Controls.Add(this.LiquidtoGasRatioLabel);
            this.InputPropertiesGroupBox.Controls.Add(this.Merkel_LiquidtoGasRatio_Value);
            this.InputPropertiesGroupBox.Controls.Add(this.MerkelWetBulbTemperatureLabel);
            this.InputPropertiesGroupBox.Controls.Add(this.MerkelTemperatureColdWaterUnits);
            this.InputPropertiesGroupBox.Controls.Add(this.MerkelTemperatureHotWaterUnits);
            this.InputPropertiesGroupBox.Controls.Add(this.Merkel_WetBulbTemperature_Value);
            this.InputPropertiesGroupBox.Controls.Add(this.Merkel_ColdWaterTemperature_Value);
            this.InputPropertiesGroupBox.Controls.Add(this.Merkel_HotWaterTemperature_Value);
            this.InputPropertiesGroupBox.Controls.Add(this.TemperatureColdWaterLabel);
            this.InputPropertiesGroupBox.Controls.Add(this.TemperatureHotWaterLabel);
            this.InputPropertiesGroupBox.Location = new System.Drawing.Point(9, 49);
            this.InputPropertiesGroupBox.Name = "InputPropertiesGroupBox";
            this.InputPropertiesGroupBox.Size = new System.Drawing.Size(743, 186);
            this.InputPropertiesGroupBox.TabIndex = 11;
            this.InputPropertiesGroupBox.TabStop = false;
            this.InputPropertiesGroupBox.Text = "Input Properties";
            // 
            // MerkelElevationPressureLabel
            // 
            this.MerkelElevationPressureLabel.Location = new System.Drawing.Point(36, 117);
            this.MerkelElevationPressureLabel.Name = "MerkelElevationPressureLabel";
            this.MerkelElevationPressureLabel.Size = new System.Drawing.Size(110, 13);
            this.MerkelElevationPressureLabel.TabIndex = 23;
            this.MerkelElevationPressureLabel.Text = "Elevation:";
            this.MerkelElevationPressureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.BarometricPressureRadio);
            this.groupBox2.Controls.Add(this.ElevationRadio);
            this.groupBox2.Location = new System.Drawing.Point(296, 29);
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
            // MerkelWebBulbTemperatureUnits
            // 
            this.MerkelWebBulbTemperatureUnits.AutoSize = true;
            this.MerkelWebBulbTemperatureUnits.Location = new System.Drawing.Point(258, 93);
            this.MerkelWebBulbTemperatureUnits.Name = "MerkelWebBulbTemperatureUnits";
            this.MerkelWebBulbTemperatureUnits.Size = new System.Drawing.Size(17, 13);
            this.MerkelWebBulbTemperatureUnits.TabIndex = 18;
            this.MerkelWebBulbTemperatureUnits.Text = "°F";
            // 
            // MerkelElevationPressureUnits
            // 
            this.MerkelElevationPressureUnits.AutoSize = true;
            this.MerkelElevationPressureUnits.Location = new System.Drawing.Point(258, 120);
            this.MerkelElevationPressureUnits.Name = "MerkelElevationPressureUnits";
            this.MerkelElevationPressureUnits.Size = new System.Drawing.Size(13, 13);
            this.MerkelElevationPressureUnits.TabIndex = 16;
            this.MerkelElevationPressureUnits.Text = "ft";
            // 
            // Merkel_Elevation_Value
            // 
            this.Merkel_Elevation_Value.Location = new System.Drawing.Point(152, 114);
            this.Merkel_Elevation_Value.Name = "Merkel_Elevation_Value";
            this.Merkel_Elevation_Value.Size = new System.Drawing.Size(100, 20);
            this.Merkel_Elevation_Value.TabIndex = 15;
            this.Merkel_Elevation_Value.Text = "0";
            this.Merkel_Elevation_Value.Validating += new System.ComponentModel.CancelEventHandler(this.Merkel_Elevation_Value_Validating);
            this.Merkel_Elevation_Value.Validated += new System.EventHandler(this.Merkel_Elevation_Value_Validated);
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
            // Merkel_LiquidtoGasRatio_Value
            // 
            this.Merkel_LiquidtoGasRatio_Value.Location = new System.Drawing.Point(152, 140);
            this.Merkel_LiquidtoGasRatio_Value.Name = "Merkel_LiquidtoGasRatio_Value";
            this.Merkel_LiquidtoGasRatio_Value.Size = new System.Drawing.Size(100, 20);
            this.Merkel_LiquidtoGasRatio_Value.TabIndex = 12;
            this.Merkel_LiquidtoGasRatio_Value.Text = "0";
            this.Merkel_LiquidtoGasRatio_Value.Validating += new System.ComponentModel.CancelEventHandler(this.Merkel_LiquidtoGasRatio_Value_Validating);
            this.Merkel_LiquidtoGasRatio_Value.Validated += new System.EventHandler(this.Merkel_LiquidtoGasRatio_Value_Validated);
            // 
            // MerkelWetBulbTemperatureLabel
            // 
            this.MerkelWetBulbTemperatureLabel.Location = new System.Drawing.Point(14, 91);
            this.MerkelWetBulbTemperatureLabel.Name = "MerkelWetBulbTemperatureLabel";
            this.MerkelWetBulbTemperatureLabel.Size = new System.Drawing.Size(132, 13);
            this.MerkelWetBulbTemperatureLabel.TabIndex = 11;
            this.MerkelWetBulbTemperatureLabel.Text = "Wet Bulb Temperature:";
            this.MerkelWetBulbTemperatureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MerkelTemperatureColdWaterUnits
            // 
            this.MerkelTemperatureColdWaterUnits.AutoSize = true;
            this.MerkelTemperatureColdWaterUnits.Location = new System.Drawing.Point(258, 66);
            this.MerkelTemperatureColdWaterUnits.Name = "MerkelTemperatureColdWaterUnits";
            this.MerkelTemperatureColdWaterUnits.Size = new System.Drawing.Size(17, 13);
            this.MerkelTemperatureColdWaterUnits.TabIndex = 7;
            this.MerkelTemperatureColdWaterUnits.Text = "°F";
            // 
            // MerkelTemperatureHotWaterUnits
            // 
            this.MerkelTemperatureHotWaterUnits.AutoSize = true;
            this.MerkelTemperatureHotWaterUnits.Location = new System.Drawing.Point(258, 39);
            this.MerkelTemperatureHotWaterUnits.Name = "MerkelTemperatureHotWaterUnits";
            this.MerkelTemperatureHotWaterUnits.Size = new System.Drawing.Size(17, 13);
            this.MerkelTemperatureHotWaterUnits.TabIndex = 6;
            this.MerkelTemperatureHotWaterUnits.Text = "°F";
            // 
            // Merkel_WetBulbTemperature_Value
            // 
            this.Merkel_WetBulbTemperature_Value.Location = new System.Drawing.Point(152, 88);
            this.Merkel_WetBulbTemperature_Value.Name = "Merkel_WetBulbTemperature_Value";
            this.Merkel_WetBulbTemperature_Value.Size = new System.Drawing.Size(100, 20);
            this.Merkel_WetBulbTemperature_Value.TabIndex = 5;
            this.Merkel_WetBulbTemperature_Value.Text = "0";
            this.Merkel_WetBulbTemperature_Value.Validating += new System.ComponentModel.CancelEventHandler(this.Merkel_WetBulbTemperature_Value_Validating);
            this.Merkel_WetBulbTemperature_Value.Validated += new System.EventHandler(this.Merkel_WetBulbTemperature_Value_Validated);
            // 
            // Merkel_ColdWaterTemperature_Value
            // 
            this.Merkel_ColdWaterTemperature_Value.Location = new System.Drawing.Point(152, 62);
            this.Merkel_ColdWaterTemperature_Value.Name = "Merkel_ColdWaterTemperature_Value";
            this.Merkel_ColdWaterTemperature_Value.Size = new System.Drawing.Size(100, 20);
            this.Merkel_ColdWaterTemperature_Value.TabIndex = 4;
            this.Merkel_ColdWaterTemperature_Value.Text = "90";
            this.Merkel_ColdWaterTemperature_Value.Validating += new System.ComponentModel.CancelEventHandler(this.Merkel_ColdWaterTemperature_Value_Validating);
            // 
            // Merkel_HotWaterTemperature_Value
            // 
            this.Merkel_HotWaterTemperature_Value.Location = new System.Drawing.Point(152, 36);
            this.Merkel_HotWaterTemperature_Value.Name = "Merkel_HotWaterTemperature_Value";
            this.Merkel_HotWaterTemperature_Value.Size = new System.Drawing.Size(100, 20);
            this.Merkel_HotWaterTemperature_Value.TabIndex = 3;
            this.Merkel_HotWaterTemperature_Value.Text = "80";
            this.Merkel_HotWaterTemperature_Value.Validating += new System.ComponentModel.CancelEventHandler(this.Merkel_HotWaterTemperature_Value_Validating);
            this.Merkel_HotWaterTemperature_Value.Validated += new System.EventHandler(this.Merkel_HotWaterTemperature_Value_Validated);
            // 
            // TemperatureColdWaterLabel
            // 
            this.TemperatureColdWaterLabel.Location = new System.Drawing.Point(14, 65);
            this.TemperatureColdWaterLabel.Name = "TemperatureColdWaterLabel";
            this.TemperatureColdWaterLabel.Size = new System.Drawing.Size(132, 13);
            this.TemperatureColdWaterLabel.TabIndex = 1;
            this.TemperatureColdWaterLabel.Text = "Cold Water Temperature:";
            this.TemperatureColdWaterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TemperatureHotWaterLabel
            // 
            this.TemperatureHotWaterLabel.Location = new System.Drawing.Point(14, 39);
            this.TemperatureHotWaterLabel.Name = "TemperatureHotWaterLabel";
            this.TemperatureHotWaterLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TemperatureHotWaterLabel.Size = new System.Drawing.Size(132, 13);
            this.TemperatureHotWaterLabel.TabIndex = 0;
            this.TemperatureHotWaterLabel.Text = "Hot Water Temperature:";
            this.TemperatureHotWaterLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // MerkelCalculate
            // 
            this.MerkelCalculate.Location = new System.Drawing.Point(677, 11);
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
            this.DataFilename.Location = new System.Drawing.Point(68, 13);
            this.DataFilename.Name = "DataFilename";
            this.DataFilename.ReadOnly = true;
            this.DataFilename.Size = new System.Drawing.Size(541, 20);
            this.DataFilename.TabIndex = 28;
            // 
            // DataFileLabel
            // 
            this.DataFileLabel.AutoSize = true;
            this.DataFileLabel.Location = new System.Drawing.Point(7, 15);
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
            this.CalculatedValuesGroupBox.Location = new System.Drawing.Point(9, 241);
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
        private System.Windows.Forms.Label MerkelWetBulbTemperatureLabel;
        private System.Windows.Forms.Label MerkelTemperatureColdWaterUnits;
        private System.Windows.Forms.Label MerkelTemperatureHotWaterUnits;
        private System.Windows.Forms.TextBox Merkel_WetBulbTemperature_Value;
        private System.Windows.Forms.TextBox Merkel_ColdWaterTemperature_Value;
        private System.Windows.Forms.TextBox Merkel_HotWaterTemperature_Value;
        private System.Windows.Forms.Label TemperatureColdWaterLabel;
        private System.Windows.Forms.Label TemperatureHotWaterLabel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label LiquidtoGasRatioLabel;
        private System.Windows.Forms.TextBox Merkel_LiquidtoGasRatio_Value;
        private System.Windows.Forms.Label MerkelElevationPressureUnits;
        private System.Windows.Forms.TextBox Merkel_Elevation_Value;
        private System.Windows.Forms.Label MerkelWebBulbTemperatureUnits;
        private System.Windows.Forms.Button MerkelCalculate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton BarometricPressureRadio;
        private System.Windows.Forms.RadioButton ElevationRadio;
        private System.Windows.Forms.Label MerkelElevationPressureLabel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.TextBox DataFilename;
        private System.Windows.Forms.Label DataFileLabel;
        private System.Windows.Forms.GroupBox CalculatedValuesGroupBox;
        private System.Windows.Forms.DataGridView CalculatedValuesGridView;
    }
}
