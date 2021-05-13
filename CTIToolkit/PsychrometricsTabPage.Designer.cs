namespace CTIToolkit
{
    partial class PsychrometricsTabPage
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
            this.PsychrometricPropertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.Psychrometrics_Enthalpy = new System.Windows.Forms.RadioButton();
            this.Psychrometrics_DryBulbTemperature_RelativeHumidity = new System.Windows.Forms.RadioButton();
            this.Psychrometrics_WetBulbTemperature_DryBulbTemperature = new System.Windows.Forms.RadioButton();
            this.PsychrometricsCalculate = new System.Windows.Forms.Button();
            this.InputPropertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.EnthalpyUnits = new System.Windows.Forms.Label();
            this.EnthalpyLabel = new System.Windows.Forms.Label();
            this.EnthalpyValue = new System.Windows.Forms.TextBox();
            this.BarometericPressureUnits = new System.Windows.Forms.Label();
            this.BarometericPressureLabel = new System.Windows.Forms.Label();
            this.BarometericPressure_Value = new System.Windows.Forms.TextBox();
            this.RelativeHumidityUnits = new System.Windows.Forms.Label();
            this.RelativeHumidityLabel = new System.Windows.Forms.Label();
            this.RelativeHumidity_Value = new System.Windows.Forms.TextBox();
            this.ElevationLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BarometricPressureRadio = new System.Windows.Forms.RadioButton();
            this.ElevationRadio = new System.Windows.Forms.RadioButton();
            this.ElevationUnits = new System.Windows.Forms.Label();
            this.DryBulbTemperatureUnits = new System.Windows.Forms.Label();
            this.WetBulbTemperatureUnits = new System.Windows.Forms.Label();
            this.Elevation_Value = new System.Windows.Forms.TextBox();
            this.DryBulbTemperature_Value = new System.Windows.Forms.TextBox();
            this.WetBulbTemperature_Value = new System.Windows.Forms.TextBox();
            this.DryBulbTemperatureLabel = new System.Windows.Forms.Label();
            this.WetBulbTemperatureLabel = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.DataFilename = new System.Windows.Forms.TextBox();
            this.DataFileLabel = new System.Windows.Forms.Label();
            this.CalculatedValuesGroupBox = new System.Windows.Forms.GroupBox();
            this.CalculatedValuesGridView = new System.Windows.Forms.DataGridView();
            this.PsychrometricPropertiesGroupBox.SuspendLayout();
            this.InputPropertiesGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.CalculatedValuesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CalculatedValuesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // PsychrometricPropertiesGroupBox
            // 
            this.PsychrometricPropertiesGroupBox.Controls.Add(this.Psychrometrics_Enthalpy);
            this.PsychrometricPropertiesGroupBox.Controls.Add(this.Psychrometrics_DryBulbTemperature_RelativeHumidity);
            this.PsychrometricPropertiesGroupBox.Controls.Add(this.Psychrometrics_WetBulbTemperature_DryBulbTemperature);
            this.PsychrometricPropertiesGroupBox.Location = new System.Drawing.Point(3, 172);
            this.PsychrometricPropertiesGroupBox.Name = "PsychrometricPropertiesGroupBox";
            this.PsychrometricPropertiesGroupBox.Size = new System.Drawing.Size(755, 145);
            this.PsychrometricPropertiesGroupBox.TabIndex = 12;
            this.PsychrometricPropertiesGroupBox.TabStop = false;
            this.PsychrometricPropertiesGroupBox.Text = "Calculate the psychrometric properties";
            // 
            // Psychrometrics_Enthalpy
            // 
            this.Psychrometrics_Enthalpy.AutoSize = true;
            this.Psychrometrics_Enthalpy.Location = new System.Drawing.Point(17, 100);
            this.Psychrometrics_Enthalpy.Name = "Psychrometrics_Enthalpy";
            this.Psychrometrics_Enthalpy.Size = new System.Drawing.Size(176, 17);
            this.Psychrometrics_Enthalpy.TabIndex = 2;
            this.Psychrometrics_Enthalpy.Text = "Enthalpy at saturated conditions";
            this.Psychrometrics_Enthalpy.UseVisualStyleBackColor = true;
            this.Psychrometrics_Enthalpy.CheckedChanged += new System.EventHandler(this.Psychrometrics_Enthalpy_CheckedChanged);
            // 
            // Psychrometrics_DryBulbTemperature_RelativeHumidity
            // 
            this.Psychrometrics_DryBulbTemperature_RelativeHumidity.AutoSize = true;
            this.Psychrometrics_DryBulbTemperature_RelativeHumidity.Location = new System.Drawing.Point(17, 65);
            this.Psychrometrics_DryBulbTemperature_RelativeHumidity.Name = "Psychrometrics_DryBulbTemperature_RelativeHumidity";
            this.Psychrometrics_DryBulbTemperature_RelativeHumidity.Size = new System.Drawing.Size(234, 17);
            this.Psychrometrics_DryBulbTemperature_RelativeHumidity.TabIndex = 1;
            this.Psychrometrics_DryBulbTemperature_RelativeHumidity.Text = "Dry Bulb Temperature and Relative Humidity";
            this.Psychrometrics_DryBulbTemperature_RelativeHumidity.UseVisualStyleBackColor = true;
            this.Psychrometrics_DryBulbTemperature_RelativeHumidity.CheckedChanged += new System.EventHandler(this.Psychrometrics_DryBulbTemperature_RelativeHumidity_CheckedChanged);
            // 
            // Psychrometrics_WetBulbTemperature_DryBulbTemperature
            // 
            this.Psychrometrics_WetBulbTemperature_DryBulbTemperature.AutoSize = true;
            this.Psychrometrics_WetBulbTemperature_DryBulbTemperature.Checked = true;
            this.Psychrometrics_WetBulbTemperature_DryBulbTemperature.Location = new System.Drawing.Point(17, 33);
            this.Psychrometrics_WetBulbTemperature_DryBulbTemperature.Name = "Psychrometrics_WetBulbTemperature_DryBulbTemperature";
            this.Psychrometrics_WetBulbTemperature_DryBulbTemperature.Size = new System.Drawing.Size(259, 17);
            this.Psychrometrics_WetBulbTemperature_DryBulbTemperature.TabIndex = 0;
            this.Psychrometrics_WetBulbTemperature_DryBulbTemperature.TabStop = true;
            this.Psychrometrics_WetBulbTemperature_DryBulbTemperature.Text = "Wet Bulb Temperature and Dry Bulb Temperature";
            this.Psychrometrics_WetBulbTemperature_DryBulbTemperature.UseVisualStyleBackColor = true;
            this.Psychrometrics_WetBulbTemperature_DryBulbTemperature.CheckedChanged += new System.EventHandler(this.Psychrometrics_WetBulbTemperature_DryBulbTemperature_CheckedChanged);
            // 
            // PsychrometricsCalculate
            // 
            this.PsychrometricsCalculate.Location = new System.Drawing.Point(682, 3);
            this.PsychrometricsCalculate.Name = "PsychrometricsCalculate";
            this.PsychrometricsCalculate.Size = new System.Drawing.Size(75, 23);
            this.PsychrometricsCalculate.TabIndex = 0;
            this.PsychrometricsCalculate.Text = "Calculate";
            this.PsychrometricsCalculate.UseVisualStyleBackColor = true;
            this.PsychrometricsCalculate.Click += new System.EventHandler(this.PsychrometricsCalculate_Click);
            // 
            // InputPropertiesGroupBox
            // 
            this.InputPropertiesGroupBox.Controls.Add(this.EnthalpyUnits);
            this.InputPropertiesGroupBox.Controls.Add(this.EnthalpyLabel);
            this.InputPropertiesGroupBox.Controls.Add(this.EnthalpyValue);
            this.InputPropertiesGroupBox.Controls.Add(this.BarometericPressureUnits);
            this.InputPropertiesGroupBox.Controls.Add(this.BarometericPressureLabel);
            this.InputPropertiesGroupBox.Controls.Add(this.BarometericPressure_Value);
            this.InputPropertiesGroupBox.Controls.Add(this.RelativeHumidityUnits);
            this.InputPropertiesGroupBox.Controls.Add(this.RelativeHumidityLabel);
            this.InputPropertiesGroupBox.Controls.Add(this.RelativeHumidity_Value);
            this.InputPropertiesGroupBox.Controls.Add(this.ElevationLabel);
            this.InputPropertiesGroupBox.Controls.Add(this.groupBox2);
            this.InputPropertiesGroupBox.Controls.Add(this.ElevationUnits);
            this.InputPropertiesGroupBox.Controls.Add(this.DryBulbTemperatureUnits);
            this.InputPropertiesGroupBox.Controls.Add(this.WetBulbTemperatureUnits);
            this.InputPropertiesGroupBox.Controls.Add(this.Elevation_Value);
            this.InputPropertiesGroupBox.Controls.Add(this.DryBulbTemperature_Value);
            this.InputPropertiesGroupBox.Controls.Add(this.WetBulbTemperature_Value);
            this.InputPropertiesGroupBox.Controls.Add(this.DryBulbTemperatureLabel);
            this.InputPropertiesGroupBox.Controls.Add(this.WetBulbTemperatureLabel);
            this.InputPropertiesGroupBox.Location = new System.Drawing.Point(3, 36);
            this.InputPropertiesGroupBox.Name = "InputPropertiesGroupBox";
            this.InputPropertiesGroupBox.Size = new System.Drawing.Size(755, 130);
            this.InputPropertiesGroupBox.TabIndex = 11;
            this.InputPropertiesGroupBox.TabStop = false;
            this.InputPropertiesGroupBox.Text = "Input Properties";
            // 
            // EnthalpyUnits
            // 
            this.EnthalpyUnits.AutoSize = true;
            this.EnthalpyUnits.Location = new System.Drawing.Point(245, 65);
            this.EnthalpyUnits.Name = "EnthalpyUnits";
            this.EnthalpyUnits.Size = new System.Drawing.Size(0, 13);
            this.EnthalpyUnits.TabIndex = 20;
            // 
            // EnthalpyLabel
            // 
            this.EnthalpyLabel.Location = new System.Drawing.Point(19, 65);
            this.EnthalpyLabel.Name = "EnthalpyLabel";
            this.EnthalpyLabel.Size = new System.Drawing.Size(113, 13);
            this.EnthalpyLabel.TabIndex = 19;
            this.EnthalpyLabel.Text = "Enthalpy:";
            this.EnthalpyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EnthalpyValue
            // 
            this.EnthalpyValue.Enabled = false;
            this.EnthalpyValue.Location = new System.Drawing.Point(152, 62);
            this.EnthalpyValue.Name = "EnthalpyValue";
            this.EnthalpyValue.Size = new System.Drawing.Size(70, 20);
            this.EnthalpyValue.TabIndex = 18;
            this.EnthalpyValue.Visible = false;
            this.EnthalpyValue.Validating += new System.ComponentModel.CancelEventHandler(this.EnthalpyValue_Validating);
            this.EnthalpyValue.Validated += new System.EventHandler(this.EnthalpyValue_Validated);
            // 
            // BarometericPressureUnits
            // 
            this.BarometericPressureUnits.AutoSize = true;
            this.BarometericPressureUnits.Location = new System.Drawing.Point(245, 91);
            this.BarometericPressureUnits.Name = "BarometericPressureUnits";
            this.BarometericPressureUnits.Size = new System.Drawing.Size(13, 13);
            this.BarometericPressureUnits.TabIndex = 17;
            this.BarometericPressureUnits.Text = "ft";
            // 
            // BarometericPressureLabel
            // 
            this.BarometericPressureLabel.Enabled = false;
            this.BarometericPressureLabel.Location = new System.Drawing.Point(22, 91);
            this.BarometericPressureLabel.Name = "BarometericPressureLabel";
            this.BarometericPressureLabel.Size = new System.Drawing.Size(110, 13);
            this.BarometericPressureLabel.TabIndex = 16;
            this.BarometericPressureLabel.Text = "Barometeric Pressure:";
            this.BarometericPressureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BarometericPressureLabel.Visible = false;
            // 
            // BarometericPressure_Value
            // 
            this.BarometericPressure_Value.Enabled = false;
            this.BarometericPressure_Value.Location = new System.Drawing.Point(152, 88);
            this.BarometericPressure_Value.Name = "BarometericPressure_Value";
            this.BarometericPressure_Value.Size = new System.Drawing.Size(70, 20);
            this.BarometericPressure_Value.TabIndex = 15;
            this.BarometericPressure_Value.Text = "0";
            this.BarometericPressure_Value.Visible = false;
            this.BarometericPressure_Value.Validating += new System.ComponentModel.CancelEventHandler(this.BarometericPressure_Value_Validating);
            this.BarometericPressure_Value.Validated += new System.EventHandler(this.BarometericPressure_Value_Validated);
            // 
            // RelativeHumidityUnits
            // 
            this.RelativeHumidityUnits.AutoSize = true;
            this.RelativeHumidityUnits.Enabled = false;
            this.RelativeHumidityUnits.Location = new System.Drawing.Point(245, 39);
            this.RelativeHumidityUnits.Name = "RelativeHumidityUnits";
            this.RelativeHumidityUnits.Size = new System.Drawing.Size(15, 13);
            this.RelativeHumidityUnits.TabIndex = 14;
            this.RelativeHumidityUnits.Text = "%";
            this.RelativeHumidityUnits.Visible = false;
            // 
            // RelativeHumidityLabel
            // 
            this.RelativeHumidityLabel.Enabled = false;
            this.RelativeHumidityLabel.Location = new System.Drawing.Point(15, 39);
            this.RelativeHumidityLabel.Name = "RelativeHumidityLabel";
            this.RelativeHumidityLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RelativeHumidityLabel.Size = new System.Drawing.Size(117, 13);
            this.RelativeHumidityLabel.TabIndex = 13;
            this.RelativeHumidityLabel.Text = "Relative Humidity:";
            this.RelativeHumidityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RelativeHumidityLabel.Visible = false;
            // 
            // RelativeHumidity_Value
            // 
            this.RelativeHumidity_Value.Enabled = false;
            this.RelativeHumidity_Value.Location = new System.Drawing.Point(152, 36);
            this.RelativeHumidity_Value.Name = "RelativeHumidity_Value";
            this.RelativeHumidity_Value.Size = new System.Drawing.Size(70, 20);
            this.RelativeHumidity_Value.TabIndex = 12;
            this.RelativeHumidity_Value.Visible = false;
            this.RelativeHumidity_Value.Validating += new System.ComponentModel.CancelEventHandler(this.RelativeHumidity_Value_Validating);
            this.RelativeHumidity_Value.Validated += new System.EventHandler(this.RelativeHumidity_Value_Validated);
            // 
            // ElevationLabel
            // 
            this.ElevationLabel.Location = new System.Drawing.Point(22, 91);
            this.ElevationLabel.Name = "ElevationLabel";
            this.ElevationLabel.Size = new System.Drawing.Size(110, 13);
            this.ElevationLabel.TabIndex = 11;
            this.ElevationLabel.Text = "Elevation:";
            this.ElevationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.BarometricPressureRadio);
            this.groupBox2.Controls.Add(this.ElevationRadio);
            this.groupBox2.Location = new System.Drawing.Point(297, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(164, 79);
            this.groupBox2.TabIndex = 10;
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
            this.BarometricPressureRadio.CheckedChanged += new System.EventHandler(this.PsychrometricsPressureRadio_CheckedChanged);
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
            this.ElevationRadio.CheckedChanged += new System.EventHandler(this.PyschmetricsElevationRadio_CheckedChanged);
            // 
            // ElevationUnits
            // 
            this.ElevationUnits.AutoSize = true;
            this.ElevationUnits.Location = new System.Drawing.Point(245, 91);
            this.ElevationUnits.Name = "ElevationUnits";
            this.ElevationUnits.Size = new System.Drawing.Size(13, 13);
            this.ElevationUnits.TabIndex = 8;
            this.ElevationUnits.Text = "ft";
            // 
            // DryBulbTemperatureUnits
            // 
            this.DryBulbTemperatureUnits.AutoSize = true;
            this.DryBulbTemperatureUnits.Location = new System.Drawing.Point(245, 65);
            this.DryBulbTemperatureUnits.Name = "DryBulbTemperatureUnits";
            this.DryBulbTemperatureUnits.Size = new System.Drawing.Size(17, 13);
            this.DryBulbTemperatureUnits.TabIndex = 7;
            this.DryBulbTemperatureUnits.Text = "°F";
            // 
            // WetBulbTemperatureUnits
            // 
            this.WetBulbTemperatureUnits.AutoSize = true;
            this.WetBulbTemperatureUnits.Location = new System.Drawing.Point(245, 39);
            this.WetBulbTemperatureUnits.Name = "WetBulbTemperatureUnits";
            this.WetBulbTemperatureUnits.Size = new System.Drawing.Size(17, 13);
            this.WetBulbTemperatureUnits.TabIndex = 6;
            this.WetBulbTemperatureUnits.Text = "°F";
            // 
            // Elevation_Value
            // 
            this.Elevation_Value.Location = new System.Drawing.Point(152, 88);
            this.Elevation_Value.Name = "Elevation_Value";
            this.Elevation_Value.Size = new System.Drawing.Size(70, 20);
            this.Elevation_Value.TabIndex = 5;
            this.Elevation_Value.Text = "0";
            this.Elevation_Value.Validating += new System.ComponentModel.CancelEventHandler(this.Elevation_Value_Validating);
            this.Elevation_Value.Validated += new System.EventHandler(this.Elevation_Value_Validated);
            // 
            // DryBulbTemperature_Value
            // 
            this.DryBulbTemperature_Value.Location = new System.Drawing.Point(152, 62);
            this.DryBulbTemperature_Value.Name = "DryBulbTemperature_Value";
            this.DryBulbTemperature_Value.Size = new System.Drawing.Size(70, 20);
            this.DryBulbTemperature_Value.TabIndex = 4;
            this.DryBulbTemperature_Value.Text = "90";
            this.DryBulbTemperature_Value.Validating += new System.ComponentModel.CancelEventHandler(this.DryBulbTemperature_Value_Validating);
            this.DryBulbTemperature_Value.Validated += new System.EventHandler(this.DryBulbTemperature_Value_Validated);
            // 
            // WetBulbTemperature_Value
            // 
            this.WetBulbTemperature_Value.Location = new System.Drawing.Point(152, 36);
            this.WetBulbTemperature_Value.Name = "WetBulbTemperature_Value";
            this.WetBulbTemperature_Value.Size = new System.Drawing.Size(70, 20);
            this.WetBulbTemperature_Value.TabIndex = 3;
            this.WetBulbTemperature_Value.Text = "80";
            this.WetBulbTemperature_Value.Validating += new System.ComponentModel.CancelEventHandler(this.WetBulbTemperature_Value_Validating);
            this.WetBulbTemperature_Value.Validated += new System.EventHandler(this.WetBulbTemperature_Value_Validated);
            // 
            // DryBulbTemperatureLabel
            // 
            this.DryBulbTemperatureLabel.Location = new System.Drawing.Point(19, 65);
            this.DryBulbTemperatureLabel.Name = "DryBulbTemperatureLabel";
            this.DryBulbTemperatureLabel.Size = new System.Drawing.Size(113, 13);
            this.DryBulbTemperatureLabel.TabIndex = 1;
            this.DryBulbTemperatureLabel.Text = "Dry Bulb Temperature:";
            this.DryBulbTemperatureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // WetBulbTemperatureLabel
            // 
            this.WetBulbTemperatureLabel.Location = new System.Drawing.Point(15, 39);
            this.WetBulbTemperatureLabel.Name = "WetBulbTemperatureLabel";
            this.WetBulbTemperatureLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.WetBulbTemperatureLabel.Size = new System.Drawing.Size(117, 13);
            this.WetBulbTemperatureLabel.TabIndex = 0;
            this.WetBulbTemperatureLabel.Text = "Wet Bulb Temperature:";
            this.WetBulbTemperatureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.DataFilename.TabIndex = 26;
            // 
            // DataFileLabel
            // 
            this.DataFileLabel.AutoSize = true;
            this.DataFileLabel.Location = new System.Drawing.Point(7, 8);
            this.DataFileLabel.Name = "DataFileLabel";
            this.DataFileLabel.Size = new System.Drawing.Size(55, 13);
            this.DataFileLabel.TabIndex = 25;
            this.DataFileLabel.Text = "Data  File:";
            // 
            // CalculatedValuesGroupBox
            // 
            this.CalculatedValuesGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CalculatedValuesGroupBox.Controls.Add(this.CalculatedValuesGridView);
            this.CalculatedValuesGroupBox.Location = new System.Drawing.Point(3, 323);
            this.CalculatedValuesGroupBox.Name = "CalculatedValuesGroupBox";
            this.CalculatedValuesGroupBox.Size = new System.Drawing.Size(755, 298);
            this.CalculatedValuesGroupBox.TabIndex = 31;
            this.CalculatedValuesGroupBox.TabStop = false;
            this.CalculatedValuesGroupBox.Text = "Calculated Values:";
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
            this.CalculatedValuesGridView.Size = new System.Drawing.Size(735, 262);
            this.CalculatedValuesGridView.TabIndex = 0;
            this.CalculatedValuesGridView.TabStop = false;
            // 
            // PsychrometricsTabPage
            // 
            this.AutoSize = true;
            this.Controls.Add(this.CalculatedValuesGroupBox);
            this.Controls.Add(this.DataFilename);
            this.Controls.Add(this.DataFileLabel);
            this.Controls.Add(this.PsychrometricPropertiesGroupBox);
            this.Controls.Add(this.InputPropertiesGroupBox);
            this.Controls.Add(this.PsychrometricsCalculate);
            this.Name = "PsychrometricsTabPage";
            this.Size = new System.Drawing.Size(781, 674);
            this.PsychrometricPropertiesGroupBox.ResumeLayout(false);
            this.PsychrometricPropertiesGroupBox.PerformLayout();
            this.InputPropertiesGroupBox.ResumeLayout(false);
            this.InputPropertiesGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.CalculatedValuesGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CalculatedValuesGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox PsychrometricPropertiesGroupBox;
        private System.Windows.Forms.RadioButton Psychrometrics_Enthalpy;
        private System.Windows.Forms.RadioButton Psychrometrics_DryBulbTemperature_RelativeHumidity;
        private System.Windows.Forms.RadioButton Psychrometrics_WetBulbTemperature_DryBulbTemperature;
        private System.Windows.Forms.Button PsychrometricsCalculate;
        private System.Windows.Forms.GroupBox InputPropertiesGroupBox;
        private System.Windows.Forms.Label ElevationLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton BarometricPressureRadio;
        private System.Windows.Forms.RadioButton ElevationRadio;
        private System.Windows.Forms.Label ElevationUnits;
        private System.Windows.Forms.Label DryBulbTemperatureUnits;
        private System.Windows.Forms.Label WetBulbTemperatureUnits;
        private System.Windows.Forms.TextBox Elevation_Value;
        private System.Windows.Forms.TextBox DryBulbTemperature_Value;
        private System.Windows.Forms.TextBox WetBulbTemperature_Value;
        private System.Windows.Forms.Label DryBulbTemperatureLabel;
        private System.Windows.Forms.Label WetBulbTemperatureLabel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.TextBox RelativeHumidity_Value;
        private System.Windows.Forms.Label RelativeHumidityLabel;
        private System.Windows.Forms.Label RelativeHumidityUnits;
        private System.Windows.Forms.TextBox BarometericPressure_Value;
        private System.Windows.Forms.Label BarometericPressureLabel;
        private System.Windows.Forms.Label BarometericPressureUnits;
        private System.Windows.Forms.TextBox EnthalpyValue;
        private System.Windows.Forms.Label EnthalpyLabel;
        private System.Windows.Forms.Label EnthalpyUnits;
        private System.Windows.Forms.TextBox DataFilename;
        private System.Windows.Forms.Label DataFileLabel;
        private System.Windows.Forms.GroupBox CalculatedValuesGroupBox;
        private System.Windows.Forms.DataGridView CalculatedValuesGridView;
    }
}
