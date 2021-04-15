namespace CTIToolkit
{
    partial class DemandCurveTabPage
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.DemandCurveCalculate = new System.Windows.Forms.Button();
            this.DemandCurveDataFileLabel = new System.Windows.Forms.Label();
            this.RangeLabel = new System.Windows.Forms.Label();
            this.RangeValue = new System.Windows.Forms.TextBox();
            this.WetBulbTemperatureValue = new System.Windows.Forms.TextBox();
            this.DemandCurveRangeUnits = new System.Windows.Forms.Label();
            this.DemandCurveWetBulbTemperatureLabel = new System.Windows.Forms.Label();
            this.ElevationValue = new System.Windows.Forms.TextBox();
            this.ElevationPressureUnits = new System.Windows.Forms.Label();
            this.ElevationPressureLabel = new System.Windows.Forms.Label();
            this.WebBulbTemperatureUnits = new System.Windows.Forms.Label();
            this.InputPropertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.DesignPointGroupBox = new System.Windows.Forms.GroupBox();
            this.KavLRadio = new System.Windows.Forms.RadioButton();
            this.LiquidToGasRatioValue = new System.Windows.Forms.TextBox();
            this.ApproachRadio = new System.Windows.Forms.RadioButton();
            this.LiquidToGasRatioLabel = new System.Windows.Forms.Label();
            this.TowerOrFillCharacteristicsGroupBox = new System.Windows.Forms.GroupBox();
            this.UserApproachValue = new System.Windows.Forms.TextBox();
            this.UserApproachLabel = new System.Windows.Forms.Label();
            this.MaximumValue = new System.Windows.Forms.NumericUpDown();
            this.MinimumValue = new System.Windows.Forms.NumericUpDown();
            this.MaximumLabel = new System.Windows.Forms.Label();
            this.MinimumLabel = new System.Windows.Forms.Label();
            this.Slope_C2_Value = new System.Windows.Forms.TextBox();
            this.SlopeLabel = new System.Windows.Forms.Label();
            this.C_C1_Value = new System.Windows.Forms.TextBox();
            this.CLabel = new System.Windows.Forms.Label();
            this.ThermalDesignConditionsGroupBox = new System.Windows.Forms.GroupBox();
            this.RangeUnits = new System.Windows.Forms.Label();
            this.groupBoxPressureElevation = new System.Windows.Forms.GroupBox();
            this.BarometricPressureRadio = new System.Windows.Forms.RadioButton();
            this.ElevationRadio = new System.Windows.Forms.RadioButton();
            this.DemandCurveChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.DataFilename = new System.Windows.Forms.TextBox();
            this.CalculatedValue = new System.Windows.Forms.TextBox();
            this.InputPropertiesGroupBox.SuspendLayout();
            this.DesignPointGroupBox.SuspendLayout();
            this.TowerOrFillCharacteristicsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimumValue)).BeginInit();
            this.ThermalDesignConditionsGroupBox.SuspendLayout();
            this.groupBoxPressureElevation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DemandCurveChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 50;
            this.toolTip1.ReshowDelay = 100;
            // 
            // DemandCurveCalculate
            // 
            this.DemandCurveCalculate.Location = new System.Drawing.Point(830, 13);
            this.DemandCurveCalculate.Name = "DemandCurveCalculate";
            this.DemandCurveCalculate.Size = new System.Drawing.Size(75, 23);
            this.DemandCurveCalculate.TabIndex = 15;
            this.DemandCurveCalculate.Text = "Calculate";
            this.DemandCurveCalculate.UseVisualStyleBackColor = true;
            this.DemandCurveCalculate.Click += new System.EventHandler(this.DemandCurveCalculate_Click);
            // 
            // DemandCurveDataFileLabel
            // 
            this.DemandCurveDataFileLabel.Location = new System.Drawing.Point(9, 14);
            this.DemandCurveDataFileLabel.Name = "DemandCurveDataFileLabel";
            this.DemandCurveDataFileLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DemandCurveDataFileLabel.Size = new System.Drawing.Size(126, 13);
            this.DemandCurveDataFileLabel.TabIndex = 0;
            this.DemandCurveDataFileLabel.Text = "Demand Curve Data File:";
            this.DemandCurveDataFileLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // RangeLabel
            // 
            this.RangeLabel.Location = new System.Drawing.Point(9, 51);
            this.RangeLabel.Name = "RangeLabel";
            this.RangeLabel.Size = new System.Drawing.Size(116, 13);
            this.RangeLabel.TabIndex = 1;
            this.RangeLabel.Text = "Range:";
            this.RangeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RangeValue
            // 
            this.RangeValue.Location = new System.Drawing.Point(134, 51);
            this.RangeValue.Name = "RangeValue";
            this.RangeValue.Size = new System.Drawing.Size(56, 20);
            this.RangeValue.TabIndex = 4;
            this.RangeValue.Text = "10";
            this.RangeValue.Validating += new System.ComponentModel.CancelEventHandler(this.RangeValue_Validating);
            this.RangeValue.Validated += new System.EventHandler(this.RangeValue_Validated);
            // 
            // WetBulbTemperatureValue
            // 
            this.WetBulbTemperatureValue.Location = new System.Drawing.Point(134, 25);
            this.WetBulbTemperatureValue.Name = "WetBulbTemperatureValue";
            this.WetBulbTemperatureValue.Size = new System.Drawing.Size(56, 20);
            this.WetBulbTemperatureValue.TabIndex = 5;
            this.WetBulbTemperatureValue.Text = "80";
            this.WetBulbTemperatureValue.Validating += new System.ComponentModel.CancelEventHandler(this.WetBulbTemperature_Value_Validating);
            this.WetBulbTemperatureValue.Validated += new System.EventHandler(this.WetBulbTemperature_Value_Validated);
            // 
            // DemandCurveRangeUnits
            // 
            this.DemandCurveRangeUnits.AutoSize = true;
            this.DemandCurveRangeUnits.Location = new System.Drawing.Point(164, 51);
            this.DemandCurveRangeUnits.Name = "DemandCurveRangeUnits";
            this.DemandCurveRangeUnits.Size = new System.Drawing.Size(17, 13);
            this.DemandCurveRangeUnits.TabIndex = 7;
            this.DemandCurveRangeUnits.Text = "°F";
            // 
            // DemandCurveWetBulbTemperatureLabel
            // 
            this.DemandCurveWetBulbTemperatureLabel.Location = new System.Drawing.Point(9, 25);
            this.DemandCurveWetBulbTemperatureLabel.Name = "DemandCurveWetBulbTemperatureLabel";
            this.DemandCurveWetBulbTemperatureLabel.Size = new System.Drawing.Size(119, 13);
            this.DemandCurveWetBulbTemperatureLabel.TabIndex = 11;
            this.DemandCurveWetBulbTemperatureLabel.Text = "Wet Bulb Temperature:";
            this.DemandCurveWetBulbTemperatureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ElevationValue
            // 
            this.ElevationValue.Location = new System.Drawing.Point(134, 77);
            this.ElevationValue.Name = "ElevationValue";
            this.ElevationValue.Size = new System.Drawing.Size(56, 20);
            this.ElevationValue.TabIndex = 15;
            this.ElevationValue.Text = "0";
            this.ElevationValue.Validating += new System.ComponentModel.CancelEventHandler(this.ElevationValue_Validating);
            this.ElevationValue.Validated += new System.EventHandler(this.ElevationValue_Validated);
            // 
            // ElevationPressureUnits
            // 
            this.ElevationPressureUnits.AutoSize = true;
            this.ElevationPressureUnits.Location = new System.Drawing.Point(204, 80);
            this.ElevationPressureUnits.Name = "ElevationPressureUnits";
            this.ElevationPressureUnits.Size = new System.Drawing.Size(13, 13);
            this.ElevationPressureUnits.TabIndex = 16;
            this.ElevationPressureUnits.Text = "ft";
            // 
            // ElevationPressureLabel
            // 
            this.ElevationPressureLabel.Location = new System.Drawing.Point(9, 77);
            this.ElevationPressureLabel.Name = "ElevationPressureLabel";
            this.ElevationPressureLabel.Size = new System.Drawing.Size(116, 13);
            this.ElevationPressureLabel.TabIndex = 17;
            this.ElevationPressureLabel.Text = "Elevation:";
            this.ElevationPressureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // WebBulbTemperatureUnits
            // 
            this.WebBulbTemperatureUnits.AutoSize = true;
            this.WebBulbTemperatureUnits.Location = new System.Drawing.Point(204, 28);
            this.WebBulbTemperatureUnits.Name = "WebBulbTemperatureUnits";
            this.WebBulbTemperatureUnits.Size = new System.Drawing.Size(17, 13);
            this.WebBulbTemperatureUnits.TabIndex = 18;
            this.WebBulbTemperatureUnits.Text = "°F";
            // 
            // InputPropertiesGroupBox
            // 
            this.InputPropertiesGroupBox.Controls.Add(this.DesignPointGroupBox);
            this.InputPropertiesGroupBox.Controls.Add(this.TowerOrFillCharacteristicsGroupBox);
            this.InputPropertiesGroupBox.Controls.Add(this.ThermalDesignConditionsGroupBox);
            this.InputPropertiesGroupBox.Location = new System.Drawing.Point(9, 41);
            this.InputPropertiesGroupBox.Name = "InputPropertiesGroupBox";
            this.InputPropertiesGroupBox.Size = new System.Drawing.Size(896, 135);
            this.InputPropertiesGroupBox.TabIndex = 11;
            this.InputPropertiesGroupBox.TabStop = false;
            this.InputPropertiesGroupBox.Text = "Input Properties";
            // 
            // DesignPointGroupBox
            // 
            this.DesignPointGroupBox.Controls.Add(this.CalculatedValue);
            this.DesignPointGroupBox.Controls.Add(this.KavLRadio);
            this.DesignPointGroupBox.Controls.Add(this.LiquidToGasRatioValue);
            this.DesignPointGroupBox.Controls.Add(this.ApproachRadio);
            this.DesignPointGroupBox.Controls.Add(this.LiquidToGasRatioLabel);
            this.DesignPointGroupBox.Location = new System.Drawing.Point(664, 20);
            this.DesignPointGroupBox.Name = "DesignPointGroupBox";
            this.DesignPointGroupBox.Size = new System.Drawing.Size(180, 106);
            this.DesignPointGroupBox.TabIndex = 22;
            this.DesignPointGroupBox.TabStop = false;
            this.DesignPointGroupBox.Text = "Design Point";
            // 
            // KavLRadio
            // 
            this.KavLRadio.Location = new System.Drawing.Point(18, 73);
            this.KavLRadio.Name = "KavLRadio";
            this.KavLRadio.Size = new System.Drawing.Size(91, 17);
            this.KavLRadio.TabIndex = 1;
            this.KavLRadio.Text = "Kav/L";
            this.KavLRadio.UseVisualStyleBackColor = true;
            this.KavLRadio.CheckedChanged += new System.EventHandler(this.KavLRadio_CheckedChanged);
            // 
            // LiquidToGasRatioValue
            // 
            this.LiquidToGasRatioValue.Location = new System.Drawing.Point(125, 22);
            this.LiquidToGasRatioValue.Name = "LiquidToGasRatioValue";
            this.LiquidToGasRatioValue.Size = new System.Drawing.Size(39, 20);
            this.LiquidToGasRatioValue.TabIndex = 2;
            this.LiquidToGasRatioValue.Text = "1";
            this.LiquidToGasRatioValue.Validating += new System.ComponentModel.CancelEventHandler(this.LiquidToGasRatioValue_Validating);
            this.LiquidToGasRatioValue.Validated += new System.EventHandler(this.LiquidToGasRatioValue_Validated);
            // 
            // ApproachRadio
            // 
            this.ApproachRadio.Checked = true;
            this.ApproachRadio.Location = new System.Drawing.Point(18, 52);
            this.ApproachRadio.Name = "ApproachRadio";
            this.ApproachRadio.Size = new System.Drawing.Size(91, 17);
            this.ApproachRadio.TabIndex = 0;
            this.ApproachRadio.TabStop = true;
            this.ApproachRadio.Text = "Approach";
            this.ApproachRadio.UseVisualStyleBackColor = true;
            this.ApproachRadio.CheckedChanged += new System.EventHandler(this.ApproachRadio_CheckedChanged);
            // 
            // LiquidToGasRatioLabel
            // 
            this.LiquidToGasRatioLabel.AutoSize = true;
            this.LiquidToGasRatioLabel.Location = new System.Drawing.Point(15, 25);
            this.LiquidToGasRatioLabel.Name = "LiquidToGasRatioLabel";
            this.LiquidToGasRatioLabel.Size = new System.Drawing.Size(104, 13);
            this.LiquidToGasRatioLabel.TabIndex = 0;
            this.LiquidToGasRatioLabel.Text = "Liquid To Gas Ratio:";
            // 
            // TowerOrFillCharacteristicsGroupBox
            // 
            this.TowerOrFillCharacteristicsGroupBox.Controls.Add(this.UserApproachValue);
            this.TowerOrFillCharacteristicsGroupBox.Controls.Add(this.UserApproachLabel);
            this.TowerOrFillCharacteristicsGroupBox.Controls.Add(this.MaximumValue);
            this.TowerOrFillCharacteristicsGroupBox.Controls.Add(this.MinimumValue);
            this.TowerOrFillCharacteristicsGroupBox.Controls.Add(this.MaximumLabel);
            this.TowerOrFillCharacteristicsGroupBox.Controls.Add(this.MinimumLabel);
            this.TowerOrFillCharacteristicsGroupBox.Controls.Add(this.Slope_C2_Value);
            this.TowerOrFillCharacteristicsGroupBox.Controls.Add(this.SlopeLabel);
            this.TowerOrFillCharacteristicsGroupBox.Controls.Add(this.C_C1_Value);
            this.TowerOrFillCharacteristicsGroupBox.Controls.Add(this.CLabel);
            this.TowerOrFillCharacteristicsGroupBox.Location = new System.Drawing.Point(397, 20);
            this.TowerOrFillCharacteristicsGroupBox.Name = "TowerOrFillCharacteristicsGroupBox";
            this.TowerOrFillCharacteristicsGroupBox.Size = new System.Drawing.Size(255, 106);
            this.TowerOrFillCharacteristicsGroupBox.TabIndex = 21;
            this.TowerOrFillCharacteristicsGroupBox.TabStop = false;
            this.TowerOrFillCharacteristicsGroupBox.Text = "Tower or Fill Characteristics";
            // 
            // UserApproachValue
            // 
            this.UserApproachValue.Location = new System.Drawing.Point(100, 76);
            this.UserApproachValue.Name = "UserApproachValue";
            this.UserApproachValue.Size = new System.Drawing.Size(37, 20);
            this.UserApproachValue.TabIndex = 11;
            this.UserApproachValue.Validating += new System.ComponentModel.CancelEventHandler(this.UserApproachValue_Validating);
            this.UserApproachValue.Validated += new System.EventHandler(this.UserApproachValue_Validated);
            // 
            // UserApproachLabel
            // 
            this.UserApproachLabel.AutoSize = true;
            this.UserApproachLabel.Location = new System.Drawing.Point(12, 80);
            this.UserApproachLabel.Name = "UserApproachLabel";
            this.UserApproachLabel.Size = new System.Drawing.Size(81, 13);
            this.UserApproachLabel.TabIndex = 10;
            this.UserApproachLabel.Text = "User Approach:";
            // 
            // MaximumValue
            // 
            this.MaximumValue.DecimalPlaces = 1;
            this.MaximumValue.Location = new System.Drawing.Point(185, 49);
            this.MaximumValue.Name = "MaximumValue";
            this.MaximumValue.Size = new System.Drawing.Size(53, 20);
            this.MaximumValue.TabIndex = 9;
            this.MaximumValue.Validating += new System.ComponentModel.CancelEventHandler(this.MaximumValue_Validating);
            this.MaximumValue.Validated += new System.EventHandler(this.MaximumValue_Validated);
            // 
            // MinimumValue
            // 
            this.MinimumValue.DecimalPlaces = 1;
            this.MinimumValue.Location = new System.Drawing.Point(185, 23);
            this.MinimumValue.Name = "MinimumValue";
            this.MinimumValue.Size = new System.Drawing.Size(53, 20);
            this.MinimumValue.TabIndex = 8;
            this.MinimumValue.Validating += new System.ComponentModel.CancelEventHandler(this.MinimumValue_Validating);
            this.MinimumValue.Validated += new System.EventHandler(this.MinimumValue_Validated);
            // 
            // MaximumLabel
            // 
            this.MaximumLabel.AutoSize = true;
            this.MaximumLabel.Location = new System.Drawing.Point(128, 51);
            this.MaximumLabel.Name = "MaximumLabel";
            this.MaximumLabel.Size = new System.Drawing.Size(54, 13);
            this.MaximumLabel.TabIndex = 6;
            this.MaximumLabel.Text = "Maximum:";
            // 
            // MinimumLabel
            // 
            this.MinimumLabel.AutoSize = true;
            this.MinimumLabel.Location = new System.Drawing.Point(128, 25);
            this.MinimumLabel.Name = "MinimumLabel";
            this.MinimumLabel.Size = new System.Drawing.Size(51, 13);
            this.MinimumLabel.TabIndex = 4;
            this.MinimumLabel.Text = "Minimum:";
            // 
            // Slope_C2_Value
            // 
            this.Slope_C2_Value.Location = new System.Drawing.Point(51, 45);
            this.Slope_C2_Value.Name = "Slope_C2_Value";
            this.Slope_C2_Value.Size = new System.Drawing.Size(50, 20);
            this.Slope_C2_Value.TabIndex = 3;
            this.Slope_C2_Value.Text = "0";
            this.Slope_C2_Value.Validating += new System.ComponentModel.CancelEventHandler(this.Slope_C2_Value_Validating);
            this.Slope_C2_Value.Validated += new System.EventHandler(this.Slope_C2_Value_Validated);
            // 
            // SlopeLabel
            // 
            this.SlopeLabel.AutoSize = true;
            this.SlopeLabel.Location = new System.Drawing.Point(12, 51);
            this.SlopeLabel.Name = "SlopeLabel";
            this.SlopeLabel.Size = new System.Drawing.Size(37, 13);
            this.SlopeLabel.TabIndex = 2;
            this.SlopeLabel.Text = "Slope:";
            // 
            // C_C1_Value
            // 
            this.C_C1_Value.Location = new System.Drawing.Point(51, 22);
            this.C_C1_Value.Name = "C_C1_Value";
            this.C_C1_Value.Size = new System.Drawing.Size(50, 20);
            this.C_C1_Value.TabIndex = 1;
            this.C_C1_Value.Text = "0";
            this.C_C1_Value.Validating += new System.ComponentModel.CancelEventHandler(this.C_C1_Value_Validating);
            this.C_C1_Value.Validated += new System.EventHandler(this.C_C1_Value_Validated);
            // 
            // CLabel
            // 
            this.CLabel.AutoSize = true;
            this.CLabel.Location = new System.Drawing.Point(12, 25);
            this.CLabel.Name = "CLabel";
            this.CLabel.Size = new System.Drawing.Size(17, 13);
            this.CLabel.TabIndex = 0;
            this.CLabel.Text = "C:";
            // 
            // ThermalDesignConditionsGroupBox
            // 
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.RangeUnits);
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.groupBoxPressureElevation);
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.DemandCurveWetBulbTemperatureLabel);
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.RangeLabel);
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.RangeValue);
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.WebBulbTemperatureUnits);
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.WetBulbTemperatureValue);
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.ElevationPressureLabel);
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.DemandCurveRangeUnits);
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.ElevationPressureUnits);
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.ElevationValue);
            this.ThermalDesignConditionsGroupBox.Location = new System.Drawing.Point(14, 20);
            this.ThermalDesignConditionsGroupBox.Name = "ThermalDesignConditionsGroupBox";
            this.ThermalDesignConditionsGroupBox.Size = new System.Drawing.Size(373, 106);
            this.ThermalDesignConditionsGroupBox.TabIndex = 20;
            this.ThermalDesignConditionsGroupBox.TabStop = false;
            this.ThermalDesignConditionsGroupBox.Text = "Thermal Design Conditions";
            // 
            // RangeUnits
            // 
            this.RangeUnits.AutoSize = true;
            this.RangeUnits.Location = new System.Drawing.Point(203, 54);
            this.RangeUnits.Name = "RangeUnits";
            this.RangeUnits.Size = new System.Drawing.Size(17, 13);
            this.RangeUnits.TabIndex = 22;
            this.RangeUnits.Text = "°F";
            // 
            // groupBoxPressureElevation
            // 
            this.groupBoxPressureElevation.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxPressureElevation.Controls.Add(this.BarometricPressureRadio);
            this.groupBoxPressureElevation.Controls.Add(this.ElevationRadio);
            this.groupBoxPressureElevation.Location = new System.Drawing.Point(244, 13);
            this.groupBoxPressureElevation.Name = "groupBoxPressureElevation";
            this.groupBoxPressureElevation.Size = new System.Drawing.Size(123, 84);
            this.groupBoxPressureElevation.TabIndex = 21;
            this.groupBoxPressureElevation.TabStop = false;
            // 
            // BarometricPressureRadio
            // 
            this.BarometricPressureRadio.Location = new System.Drawing.Point(6, 48);
            this.BarometricPressureRadio.Name = "BarometricPressureRadio";
            this.BarometricPressureRadio.Size = new System.Drawing.Size(122, 17);
            this.BarometricPressureRadio.TabIndex = 1;
            this.BarometricPressureRadio.Text = "Barometric Pressure";
            this.BarometricPressureRadio.UseVisualStyleBackColor = true;
            this.BarometricPressureRadio.CheckedChanged += new System.EventHandler(this.BarometricPressureRadio_CheckedChanged);
            // 
            // ElevationRadio
            // 
            this.ElevationRadio.Checked = true;
            this.ElevationRadio.Location = new System.Drawing.Point(6, 19);
            this.ElevationRadio.Name = "ElevationRadio";
            this.ElevationRadio.Size = new System.Drawing.Size(122, 17);
            this.ElevationRadio.TabIndex = 0;
            this.ElevationRadio.TabStop = true;
            this.ElevationRadio.Text = "Elevation";
            this.ElevationRadio.UseVisualStyleBackColor = true;
            this.ElevationRadio.CheckedChanged += new System.EventHandler(this.ElevationRadio_CheckedChanged);
            // 
            // DemandCurveChart
            // 
            this.DemandCurveChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.DemandCurveChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.DemandCurveChart.Legends.Add(legend1);
            this.DemandCurveChart.Location = new System.Drawing.Point(9, 180);
            this.DemandCurveChart.Name = "DemandCurveChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.DemandCurveChart.Series.Add(series1);
            this.DemandCurveChart.Size = new System.Drawing.Size(896, 428);
            this.DemandCurveChart.TabIndex = 12;
            this.DemandCurveChart.Text = "DemandCurveChart";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // DataFilename
            // 
            this.DataFilename.Enabled = false;
            this.DataFilename.Location = new System.Drawing.Point(141, 11);
            this.DataFilename.Name = "DataFilename";
            this.DataFilename.Size = new System.Drawing.Size(538, 20);
            this.DataFilename.TabIndex = 16;
            // 
            // CalculatedValue
            // 
            this.CalculatedValue.Enabled = false;
            this.CalculatedValue.Location = new System.Drawing.Point(125, 60);
            this.CalculatedValue.Name = "CalculatedValue";
            this.CalculatedValue.Size = new System.Drawing.Size(39, 20);
            this.CalculatedValue.TabIndex = 3;
            // 
            // DemandCurveTabPage
            // 
            this.Controls.Add(this.DataFilename);
            this.Controls.Add(this.DemandCurveChart);
            this.Controls.Add(this.InputPropertiesGroupBox);
            this.Controls.Add(this.DemandCurveCalculate);
            this.Controls.Add(this.DemandCurveDataFileLabel);
            this.Name = "DemandCurveTabPage";
            this.Size = new System.Drawing.Size(920, 634);
            this.InputPropertiesGroupBox.ResumeLayout(false);
            this.DesignPointGroupBox.ResumeLayout(false);
            this.DesignPointGroupBox.PerformLayout();
            this.TowerOrFillCharacteristicsGroupBox.ResumeLayout(false);
            this.TowerOrFillCharacteristicsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimumValue)).EndInit();
            this.ThermalDesignConditionsGroupBox.ResumeLayout(false);
            this.ThermalDesignConditionsGroupBox.PerformLayout();
            this.groupBoxPressureElevation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DemandCurveChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button DemandCurveCalculate;
        private System.Windows.Forms.Label DemandCurveDataFileLabel;
        private System.Windows.Forms.Label RangeLabel;
        private System.Windows.Forms.TextBox RangeValue;
        private System.Windows.Forms.TextBox WetBulbTemperatureValue;
        private System.Windows.Forms.Label DemandCurveRangeUnits;
        private System.Windows.Forms.Label DemandCurveWetBulbTemperatureLabel;
        private System.Windows.Forms.TextBox ElevationValue;
        private System.Windows.Forms.Label ElevationPressureUnits;
        private System.Windows.Forms.Label ElevationPressureLabel;
        private System.Windows.Forms.Label WebBulbTemperatureUnits;
        private System.Windows.Forms.GroupBox InputPropertiesGroupBox;
        private System.Windows.Forms.GroupBox ThermalDesignConditionsGroupBox;
        private System.Windows.Forms.GroupBox TowerOrFillCharacteristicsGroupBox;
        private System.Windows.Forms.GroupBox DesignPointGroupBox;
        private System.Windows.Forms.Label LiquidToGasRatioLabel;
        private System.Windows.Forms.TextBox Slope_C2_Value;
        private System.Windows.Forms.Label SlopeLabel;
        private System.Windows.Forms.TextBox C_C1_Value;
        private System.Windows.Forms.Label CLabel;
        private System.Windows.Forms.TextBox LiquidToGasRatioValue;
        private System.Windows.Forms.Label MaximumLabel;
        private System.Windows.Forms.Label MinimumLabel;
        private System.Windows.Forms.NumericUpDown MaximumValue;
        private System.Windows.Forms.NumericUpDown MinimumValue;
        private System.Windows.Forms.RadioButton KavLRadio;
        private System.Windows.Forms.RadioButton ApproachRadio;
        private System.Windows.Forms.DataVisualization.Charting.Chart DemandCurveChart;
        private System.Windows.Forms.GroupBox groupBoxPressureElevation;
        private System.Windows.Forms.RadioButton BarometricPressureRadio;
        private System.Windows.Forms.RadioButton ElevationRadio;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Label RangeUnits;
        private System.Windows.Forms.TextBox DataFilename;
        private System.Windows.Forms.TextBox UserApproachValue;
        private System.Windows.Forms.Label UserApproachLabel;
        private System.Windows.Forms.TextBox CalculatedValue;
    }
}
