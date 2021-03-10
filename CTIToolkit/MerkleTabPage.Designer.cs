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
            this.MerkelGridView = new System.Windows.Forms.DataGridView();
            this.InputPropertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.MerkelCalculate = new System.Windows.Forms.Button();
            this.MerkelElevationPressureLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.MerkleBarometricPressureRadio = new System.Windows.Forms.RadioButton();
            this.MerkleElevationRadio = new System.Windows.Forms.RadioButton();
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.MerkelGridView)).BeginInit();
            this.InputPropertiesGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // MerkelGridView
            // 
            this.MerkelGridView.AllowUserToAddRows = false;
            this.MerkelGridView.AllowUserToDeleteRows = false;
            this.MerkelGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MerkelGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.MerkelGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MerkelGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MerkelGridView.Location = new System.Drawing.Point(10, 202);
            this.MerkelGridView.Name = "MerkelGridView";
            this.MerkelGridView.ReadOnly = true;
            this.MerkelGridView.Size = new System.Drawing.Size(742, 294);
            this.MerkelGridView.TabIndex = 13;
            // 
            // InputPropertiesGroupBox
            // 
            this.InputPropertiesGroupBox.Controls.Add(this.MerkelCalculate);
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
            this.InputPropertiesGroupBox.Location = new System.Drawing.Point(9, 10);
            this.InputPropertiesGroupBox.Name = "InputPropertiesGroupBox";
            this.InputPropertiesGroupBox.Size = new System.Drawing.Size(743, 186);
            this.InputPropertiesGroupBox.TabIndex = 11;
            this.InputPropertiesGroupBox.TabStop = false;
            this.InputPropertiesGroupBox.Text = "Input Properties";
            // 
            // MerkelCalculate
            // 
            this.MerkelCalculate.Location = new System.Drawing.Point(662, 19);
            this.MerkelCalculate.Name = "MerkelCalculate";
            this.MerkelCalculate.Size = new System.Drawing.Size(75, 23);
            this.MerkelCalculate.TabIndex = 15;
            this.MerkelCalculate.Text = "Calculate";
            this.MerkelCalculate.UseVisualStyleBackColor = true;
            this.MerkelCalculate.Click += new System.EventHandler(this.MerkelCalculate_Click);
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
            this.groupBox2.Controls.Add(this.MerkleBarometricPressureRadio);
            this.groupBox2.Controls.Add(this.MerkleElevationRadio);
            this.groupBox2.Location = new System.Drawing.Point(296, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(164, 79);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            // 
            // MerkleBarometricPressureRadio
            // 
            this.MerkleBarometricPressureRadio.Location = new System.Drawing.Point(17, 50);
            this.MerkleBarometricPressureRadio.Name = "MerkleBarometricPressureRadio";
            this.MerkleBarometricPressureRadio.Size = new System.Drawing.Size(130, 17);
            this.MerkleBarometricPressureRadio.TabIndex = 1;
            this.MerkleBarometricPressureRadio.Text = "Barometric Pressure";
            this.MerkleBarometricPressureRadio.UseVisualStyleBackColor = true;
            this.MerkleBarometricPressureRadio.CheckedChanged += new System.EventHandler(this.MerkleBarometricPressureRadio_CheckedChanged);
            // 
            // MerkleElevationRadio
            // 
            this.MerkleElevationRadio.Checked = true;
            this.MerkleElevationRadio.Location = new System.Drawing.Point(17, 21);
            this.MerkleElevationRadio.Name = "MerkleElevationRadio";
            this.MerkleElevationRadio.Size = new System.Drawing.Size(130, 17);
            this.MerkleElevationRadio.TabIndex = 0;
            this.MerkleElevationRadio.TabStop = true;
            this.MerkleElevationRadio.Text = "Elevation";
            this.MerkleElevationRadio.UseVisualStyleBackColor = true;
            this.MerkleElevationRadio.CheckedChanged += new System.EventHandler(this.MerkleElevationRadio_CheckedChanged);
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
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // MerkelTabPage
            // 
            this.Controls.Add(this.MerkelGridView);
            this.Controls.Add(this.InputPropertiesGroupBox);
            this.Name = "MerkelTabPage";
            this.Size = new System.Drawing.Size(767, 515);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.MerkelTabPage_HelpRequested);
            ((System.ComponentModel.ISupportInitialize)(this.MerkelGridView)).EndInit();
            this.InputPropertiesGroupBox.ResumeLayout(false);
            this.InputPropertiesGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView MerkelGridView;
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
        private System.Windows.Forms.RadioButton MerkleBarometricPressureRadio;
        private System.Windows.Forms.RadioButton MerkleElevationRadio;
        private System.Windows.Forms.Label MerkelElevationPressureLabel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}
