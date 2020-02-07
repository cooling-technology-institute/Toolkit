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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.DemandCurveCalculate = new System.Windows.Forms.Button();
            this.DemandCurveDataFileLabel = new System.Windows.Forms.Label();
            this.RangeLabel = new System.Windows.Forms.Label();
            this.DemandCurveDataFile_Value = new System.Windows.Forms.TextBox();
            this.DemandCurve_Range_Value = new System.Windows.Forms.TextBox();
            this.DemandCurve_WetBulbTemperature_Value = new System.Windows.Forms.TextBox();
            this.DemandCurveRangeUnits = new System.Windows.Forms.Label();
            this.DemandCurveWetBulbTemperatureLabel = new System.Windows.Forms.Label();
            this.DemandCurve_Elevation_Value = new System.Windows.Forms.TextBox();
            this.DemandCurveElevationPressureUnits = new System.Windows.Forms.Label();
            this.DemandCurveElevationPressureLabel = new System.Windows.Forms.Label();
            this.DemandCurveTemperatureWebBulbUnits = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.InputPropertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.DesignPointGroupBox = new System.Windows.Forms.GroupBox();
            this.DemandCurve_KavLRadio = new System.Windows.Forms.RadioButton();
            this.DemandCurve_LiquidToGasRatio_Value = new System.Windows.Forms.TextBox();
            this.DemandCurve_ApproachRadio = new System.Windows.Forms.RadioButton();
            this.LiquidToGasRatioLabel = new System.Windows.Forms.Label();
            this.TowerOrFillCharacteristicsGroupBox = new System.Windows.Forms.GroupBox();
            this.DemandCurve_Maximum_Value = new System.Windows.Forms.NumericUpDown();
            this.DemandCurve_Minimum_Value = new System.Windows.Forms.NumericUpDown();
            this.MaximumLabel = new System.Windows.Forms.Label();
            this.MinimumLabel = new System.Windows.Forms.Label();
            this.DemandCurve_Slope_C2_Value = new System.Windows.Forms.TextBox();
            this.SlopeLabel = new System.Windows.Forms.Label();
            this.DemandCurve_C_C1_Value = new System.Windows.Forms.TextBox();
            this.CLabel = new System.Windows.Forms.Label();
            this.ThermalDesignConditionsGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBoxPressureElevation = new System.Windows.Forms.GroupBox();
            this.DemandCurve_PressureRadio = new System.Windows.Forms.RadioButton();
            this.DemandCurve_ElevationRadio = new System.Windows.Forms.RadioButton();
            this.DemandCurveChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.InputPropertiesGroupBox.SuspendLayout();
            this.DesignPointGroupBox.SuspendLayout();
            this.TowerOrFillCharacteristicsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DemandCurve_Maximum_Value)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DemandCurve_Minimum_Value)).BeginInit();
            this.ThermalDesignConditionsGroupBox.SuspendLayout();
            this.groupBoxPressureElevation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DemandCurveChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
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
            this.DemandCurveCalculate.Location = new System.Drawing.Point(754, 29);
            this.DemandCurveCalculate.Name = "DemandCurveCalculate";
            this.DemandCurveCalculate.Size = new System.Drawing.Size(75, 23);
            this.DemandCurveCalculate.TabIndex = 15;
            this.DemandCurveCalculate.Text = "Calculate";
            this.DemandCurveCalculate.UseVisualStyleBackColor = true;
            this.DemandCurveCalculate.Click += new System.EventHandler(this.DemandCurveCalculate_Click);
            // 
            // DemandCurveDataFileLabel
            // 
            this.DemandCurveDataFileLabel.Location = new System.Drawing.Point(17, 34);
            this.DemandCurveDataFileLabel.Name = "DemandCurveDataFileLabel";
            this.DemandCurveDataFileLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DemandCurveDataFileLabel.Size = new System.Drawing.Size(132, 13);
            this.DemandCurveDataFileLabel.TabIndex = 0;
            this.DemandCurveDataFileLabel.Text = "Demand Curve Data File";
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
            // DemandCurveDataFile_Value
            // 
            this.DemandCurveDataFile_Value.Location = new System.Drawing.Point(157, 31);
            this.DemandCurveDataFile_Value.Name = "DemandCurveDataFile_Value";
            this.DemandCurveDataFile_Value.Size = new System.Drawing.Size(385, 20);
            this.DemandCurveDataFile_Value.TabIndex = 3;
            // 
            // DemandCurve_Range_Value
            // 
            this.DemandCurve_Range_Value.Location = new System.Drawing.Point(134, 51);
            this.DemandCurve_Range_Value.Name = "DemandCurve_Range_Value";
            this.DemandCurve_Range_Value.Size = new System.Drawing.Size(56, 20);
            this.DemandCurve_Range_Value.TabIndex = 4;
            this.DemandCurve_Range_Value.Text = "10";
            this.DemandCurve_Range_Value.Validating += new System.ComponentModel.CancelEventHandler(this.DemandCurve_Range_Value_Validating);
            this.DemandCurve_Range_Value.Validated += new System.EventHandler(this.DemandCurve_Range_Value_Validated);
            // 
            // DemandCurve_WetBulbTemperature_Value
            // 
            this.DemandCurve_WetBulbTemperature_Value.Location = new System.Drawing.Point(134, 25);
            this.DemandCurve_WetBulbTemperature_Value.Name = "DemandCurve_WetBulbTemperature_Value";
            this.DemandCurve_WetBulbTemperature_Value.Size = new System.Drawing.Size(56, 20);
            this.DemandCurve_WetBulbTemperature_Value.TabIndex = 5;
            this.DemandCurve_WetBulbTemperature_Value.Text = "80";
            this.DemandCurve_WetBulbTemperature_Value.Validating += new System.ComponentModel.CancelEventHandler(this.DemandCurve_WetBulbTemperature_Value_Validating);
            this.DemandCurve_WetBulbTemperature_Value.Validated += new System.EventHandler(this.DemandCurve_WetBulbTemperature_Value_Validated);
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
            // DemandCurve_Elevation_Value
            // 
            this.DemandCurve_Elevation_Value.Location = new System.Drawing.Point(134, 77);
            this.DemandCurve_Elevation_Value.Name = "DemandCurve_Elevation_Value";
            this.DemandCurve_Elevation_Value.Size = new System.Drawing.Size(56, 20);
            this.DemandCurve_Elevation_Value.TabIndex = 15;
            this.DemandCurve_Elevation_Value.Text = "0";
            this.DemandCurve_Elevation_Value.Validating += new System.ComponentModel.CancelEventHandler(this.DemandCurve_Elevation_Value_Validating);
            this.DemandCurve_Elevation_Value.Validated += new System.EventHandler(this.DemandCurve_Elevation_Value_Validated);
            // 
            // DemandCurveElevationPressureUnits
            // 
            this.DemandCurveElevationPressureUnits.AutoSize = true;
            this.DemandCurveElevationPressureUnits.Location = new System.Drawing.Point(196, 80);
            this.DemandCurveElevationPressureUnits.Name = "DemandCurveElevationPressureUnits";
            this.DemandCurveElevationPressureUnits.Size = new System.Drawing.Size(13, 13);
            this.DemandCurveElevationPressureUnits.TabIndex = 16;
            this.DemandCurveElevationPressureUnits.Text = "ft";
            // 
            // DemandCurveElevationPressureLabel
            // 
            this.DemandCurveElevationPressureLabel.Location = new System.Drawing.Point(9, 77);
            this.DemandCurveElevationPressureLabel.Name = "DemandCurveElevationPressureLabel";
            this.DemandCurveElevationPressureLabel.Size = new System.Drawing.Size(116, 13);
            this.DemandCurveElevationPressureLabel.TabIndex = 17;
            this.DemandCurveElevationPressureLabel.Text = "Elevation:";
            this.DemandCurveElevationPressureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DemandCurveTemperatureWebBulbUnits
            // 
            this.DemandCurveTemperatureWebBulbUnits.AutoSize = true;
            this.DemandCurveTemperatureWebBulbUnits.Location = new System.Drawing.Point(196, 28);
            this.DemandCurveTemperatureWebBulbUnits.Name = "DemandCurveTemperatureWebBulbUnits";
            this.DemandCurveTemperatureWebBulbUnits.Size = new System.Drawing.Size(17, 13);
            this.DemandCurveTemperatureWebBulbUnits.TabIndex = 18;
            this.DemandCurveTemperatureWebBulbUnits.Text = "°F";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(549, 29);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 16;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // InputPropertiesGroupBox
            // 
            this.InputPropertiesGroupBox.Controls.Add(this.DesignPointGroupBox);
            this.InputPropertiesGroupBox.Controls.Add(this.DemandCurveCalculate);
            this.InputPropertiesGroupBox.Controls.Add(this.TowerOrFillCharacteristicsGroupBox);
            this.InputPropertiesGroupBox.Controls.Add(this.ThermalDesignConditionsGroupBox);
            this.InputPropertiesGroupBox.Controls.Add(this.SaveButton);
            this.InputPropertiesGroupBox.Controls.Add(this.DemandCurveDataFile_Value);
            this.InputPropertiesGroupBox.Controls.Add(this.DemandCurveDataFileLabel);
            this.InputPropertiesGroupBox.Location = new System.Drawing.Point(9, 10);
            this.InputPropertiesGroupBox.Name = "InputPropertiesGroupBox";
            this.InputPropertiesGroupBox.Size = new System.Drawing.Size(896, 188);
            this.InputPropertiesGroupBox.TabIndex = 11;
            this.InputPropertiesGroupBox.TabStop = false;
            this.InputPropertiesGroupBox.Text = "Input Properties";
            // 
            // DesignPointGroupBox
            // 
            this.DesignPointGroupBox.Controls.Add(this.DemandCurve_KavLRadio);
            this.DesignPointGroupBox.Controls.Add(this.DemandCurve_LiquidToGasRatio_Value);
            this.DesignPointGroupBox.Controls.Add(this.DemandCurve_ApproachRadio);
            this.DesignPointGroupBox.Controls.Add(this.LiquidToGasRatioLabel);
            this.DesignPointGroupBox.Location = new System.Drawing.Point(664, 64);
            this.DesignPointGroupBox.Name = "DesignPointGroupBox";
            this.DesignPointGroupBox.Size = new System.Drawing.Size(214, 106);
            this.DesignPointGroupBox.TabIndex = 22;
            this.DesignPointGroupBox.TabStop = false;
            this.DesignPointGroupBox.Text = "Design Point";
            // 
            // DemandCurve_KavLRadio
            // 
            this.DemandCurve_KavLRadio.Location = new System.Drawing.Point(18, 67);
            this.DemandCurve_KavLRadio.Name = "DemandCurve_KavLRadio";
            this.DemandCurve_KavLRadio.Size = new System.Drawing.Size(122, 17);
            this.DemandCurve_KavLRadio.TabIndex = 1;
            this.DemandCurve_KavLRadio.Text = "Kav/L";
            this.DemandCurve_KavLRadio.UseVisualStyleBackColor = true;
            this.DemandCurve_KavLRadio.CheckedChanged += new System.EventHandler(this.DemandCurve_KavLRadio_CheckedChanged);
            // 
            // DemandCurve_LiquidToGasRatio_Value
            // 
            this.DemandCurve_LiquidToGasRatio_Value.Location = new System.Drawing.Point(125, 21);
            this.DemandCurve_LiquidToGasRatio_Value.Name = "DemandCurve_LiquidToGasRatio_Value";
            this.DemandCurve_LiquidToGasRatio_Value.Size = new System.Drawing.Size(69, 20);
            this.DemandCurve_LiquidToGasRatio_Value.TabIndex = 2;
            this.DemandCurve_LiquidToGasRatio_Value.Text = "1";
            this.DemandCurve_LiquidToGasRatio_Value.Validating += new System.ComponentModel.CancelEventHandler(this.DemandCurve_LiquidToGasRatio_Value_Validating);
            this.DemandCurve_LiquidToGasRatio_Value.Validated += new System.EventHandler(this.DemandCurve_LiquidToGasRatio_Value_Validated);
            // 
            // DemandCurve_ApproachRadio
            // 
            this.DemandCurve_ApproachRadio.Checked = true;
            this.DemandCurve_ApproachRadio.Location = new System.Drawing.Point(18, 46);
            this.DemandCurve_ApproachRadio.Name = "DemandCurve_ApproachRadio";
            this.DemandCurve_ApproachRadio.Size = new System.Drawing.Size(122, 17);
            this.DemandCurve_ApproachRadio.TabIndex = 0;
            this.DemandCurve_ApproachRadio.TabStop = true;
            this.DemandCurve_ApproachRadio.Text = "Approach";
            this.DemandCurve_ApproachRadio.UseVisualStyleBackColor = true;
            this.DemandCurve_ApproachRadio.CheckedChanged += new System.EventHandler(this.DemandCurve_ApproachRadio_CheckedChanged);
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
            this.TowerOrFillCharacteristicsGroupBox.Controls.Add(this.DemandCurve_Maximum_Value);
            this.TowerOrFillCharacteristicsGroupBox.Controls.Add(this.DemandCurve_Minimum_Value);
            this.TowerOrFillCharacteristicsGroupBox.Controls.Add(this.MaximumLabel);
            this.TowerOrFillCharacteristicsGroupBox.Controls.Add(this.MinimumLabel);
            this.TowerOrFillCharacteristicsGroupBox.Controls.Add(this.DemandCurve_Slope_C2_Value);
            this.TowerOrFillCharacteristicsGroupBox.Controls.Add(this.SlopeLabel);
            this.TowerOrFillCharacteristicsGroupBox.Controls.Add(this.DemandCurve_C_C1_Value);
            this.TowerOrFillCharacteristicsGroupBox.Controls.Add(this.CLabel);
            this.TowerOrFillCharacteristicsGroupBox.Location = new System.Drawing.Point(403, 64);
            this.TowerOrFillCharacteristicsGroupBox.Name = "TowerOrFillCharacteristicsGroupBox";
            this.TowerOrFillCharacteristicsGroupBox.Size = new System.Drawing.Size(255, 106);
            this.TowerOrFillCharacteristicsGroupBox.TabIndex = 21;
            this.TowerOrFillCharacteristicsGroupBox.TabStop = false;
            this.TowerOrFillCharacteristicsGroupBox.Text = "Tower or Fill Characteristics";
            // 
            // DemandCurve_Maximum_Value
            // 
            this.DemandCurve_Maximum_Value.DecimalPlaces = 1;
            this.DemandCurve_Maximum_Value.Location = new System.Drawing.Point(185, 49);
            this.DemandCurve_Maximum_Value.Name = "DemandCurve_Maximum_Value";
            this.DemandCurve_Maximum_Value.Size = new System.Drawing.Size(53, 20);
            this.DemandCurve_Maximum_Value.TabIndex = 9;
            // 
            // DemandCurve_Minimum_Value
            // 
            this.DemandCurve_Minimum_Value.DecimalPlaces = 1;
            this.DemandCurve_Minimum_Value.Location = new System.Drawing.Point(185, 23);
            this.DemandCurve_Minimum_Value.Name = "DemandCurve_Minimum_Value";
            this.DemandCurve_Minimum_Value.Size = new System.Drawing.Size(53, 20);
            this.DemandCurve_Minimum_Value.TabIndex = 8;
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
            // DemandCurve_Slope_C2_Value
            // 
            this.DemandCurve_Slope_C2_Value.Location = new System.Drawing.Point(60, 49);
            this.DemandCurve_Slope_C2_Value.Name = "DemandCurve_Slope_C2_Value";
            this.DemandCurve_Slope_C2_Value.Size = new System.Drawing.Size(50, 20);
            this.DemandCurve_Slope_C2_Value.TabIndex = 3;
            this.DemandCurve_Slope_C2_Value.Text = "0";
            this.DemandCurve_Slope_C2_Value.Validating += new System.ComponentModel.CancelEventHandler(this.DemandCurve_Slope_C2_Value_Validating);
            this.DemandCurve_Slope_C2_Value.Validated += new System.EventHandler(this.DemandCurve_Slope_C2_Value_Validated);
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
            // DemandCurve_C_C1_Value
            // 
            this.DemandCurve_C_C1_Value.Location = new System.Drawing.Point(59, 22);
            this.DemandCurve_C_C1_Value.Name = "DemandCurve_C_C1_Value";
            this.DemandCurve_C_C1_Value.Size = new System.Drawing.Size(50, 20);
            this.DemandCurve_C_C1_Value.TabIndex = 1;
            this.DemandCurve_C_C1_Value.Text = "0";
            this.DemandCurve_C_C1_Value.Validating += new System.ComponentModel.CancelEventHandler(this.DemandCurve_C_C1_Value_Validating);
            this.DemandCurve_C_C1_Value.Validated += new System.EventHandler(this.DemandCurve_C_C1_Value_Validated);
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
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.groupBoxPressureElevation);
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.DemandCurveWetBulbTemperatureLabel);
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.RangeLabel);
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.DemandCurve_Range_Value);
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.DemandCurveTemperatureWebBulbUnits);
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.DemandCurve_WetBulbTemperature_Value);
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.DemandCurveElevationPressureLabel);
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.DemandCurveRangeUnits);
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.DemandCurveElevationPressureUnits);
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.DemandCurve_Elevation_Value);
            this.ThermalDesignConditionsGroupBox.Location = new System.Drawing.Point(24, 64);
            this.ThermalDesignConditionsGroupBox.Name = "ThermalDesignConditionsGroupBox";
            this.ThermalDesignConditionsGroupBox.Size = new System.Drawing.Size(373, 106);
            this.ThermalDesignConditionsGroupBox.TabIndex = 20;
            this.ThermalDesignConditionsGroupBox.TabStop = false;
            this.ThermalDesignConditionsGroupBox.Text = "Thermal Design Conditions";
            // 
            // groupBoxPressureElevation
            // 
            this.groupBoxPressureElevation.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxPressureElevation.Controls.Add(this.DemandCurve_PressureRadio);
            this.groupBoxPressureElevation.Controls.Add(this.DemandCurve_ElevationRadio);
            this.groupBoxPressureElevation.Location = new System.Drawing.Point(229, 13);
            this.groupBoxPressureElevation.Name = "groupBoxPressureElevation";
            this.groupBoxPressureElevation.Size = new System.Drawing.Size(138, 84);
            this.groupBoxPressureElevation.TabIndex = 21;
            this.groupBoxPressureElevation.TabStop = false;
            // 
            // DemandCurve_PressureRadio
            // 
            this.DemandCurve_PressureRadio.Location = new System.Drawing.Point(6, 48);
            this.DemandCurve_PressureRadio.Name = "DemandCurve_PressureRadio";
            this.DemandCurve_PressureRadio.Size = new System.Drawing.Size(122, 17);
            this.DemandCurve_PressureRadio.TabIndex = 1;
            this.DemandCurve_PressureRadio.Text = "Barometric Pressure";
            this.DemandCurve_PressureRadio.UseVisualStyleBackColor = true;
            this.DemandCurve_PressureRadio.CheckedChanged += new System.EventHandler(this.DemandCurve_PressureRadio_CheckedChanged);
            // 
            // DemandCurve_ElevationRadio
            // 
            this.DemandCurve_ElevationRadio.Checked = true;
            this.DemandCurve_ElevationRadio.Location = new System.Drawing.Point(6, 19);
            this.DemandCurve_ElevationRadio.Name = "DemandCurve_ElevationRadio";
            this.DemandCurve_ElevationRadio.Size = new System.Drawing.Size(122, 17);
            this.DemandCurve_ElevationRadio.TabIndex = 0;
            this.DemandCurve_ElevationRadio.TabStop = true;
            this.DemandCurve_ElevationRadio.Text = "Elevation";
            this.DemandCurve_ElevationRadio.UseVisualStyleBackColor = true;
            this.DemandCurve_ElevationRadio.CheckedChanged += new System.EventHandler(this.DemandCurve_ElevationRadio_CheckedChanged);
            // 
            // DemandCurveChart
            // 
            this.DemandCurveChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.Name = "ChartArea1";
            this.DemandCurveChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.DemandCurveChart.Legends.Add(legend3);
            this.DemandCurveChart.Location = new System.Drawing.Point(9, 303);
            this.DemandCurveChart.Name = "DemandCurveChart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.DemandCurveChart.Series.Add(series3);
            this.DemandCurveChart.Size = new System.Drawing.Size(896, 560);
            this.DemandCurveChart.TabIndex = 12;
            this.DemandCurveChart.Text = "DemandCurveChart";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 204);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(878, 93);
            this.dataGridView1.TabIndex = 13;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(83, 869);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(671, 45);
            this.trackBar1.TabIndex = 14;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // DemandCurveTabPage
            // 
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.DemandCurveChart);
            this.Controls.Add(this.InputPropertiesGroupBox);
            this.Name = "DemandCurveTabPage";
            this.Size = new System.Drawing.Size(920, 976);
            this.InputPropertiesGroupBox.ResumeLayout(false);
            this.InputPropertiesGroupBox.PerformLayout();
            this.DesignPointGroupBox.ResumeLayout(false);
            this.DesignPointGroupBox.PerformLayout();
            this.TowerOrFillCharacteristicsGroupBox.ResumeLayout(false);
            this.TowerOrFillCharacteristicsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DemandCurve_Maximum_Value)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DemandCurve_Minimum_Value)).EndInit();
            this.ThermalDesignConditionsGroupBox.ResumeLayout(false);
            this.ThermalDesignConditionsGroupBox.PerformLayout();
            this.groupBoxPressureElevation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DemandCurveChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button DemandCurveCalculate;
        private System.Windows.Forms.Label DemandCurveDataFileLabel;
        private System.Windows.Forms.Label RangeLabel;
        private System.Windows.Forms.TextBox DemandCurveDataFile_Value;
        private System.Windows.Forms.TextBox DemandCurve_Range_Value;
        private System.Windows.Forms.TextBox DemandCurve_WetBulbTemperature_Value;
        private System.Windows.Forms.Label DemandCurveRangeUnits;
        private System.Windows.Forms.Label DemandCurveWetBulbTemperatureLabel;
        private System.Windows.Forms.TextBox DemandCurve_Elevation_Value;
        private System.Windows.Forms.Label DemandCurveElevationPressureUnits;
        private System.Windows.Forms.Label DemandCurveElevationPressureLabel;
        private System.Windows.Forms.Label DemandCurveTemperatureWebBulbUnits;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.GroupBox InputPropertiesGroupBox;
        private System.Windows.Forms.GroupBox ThermalDesignConditionsGroupBox;
        private System.Windows.Forms.GroupBox TowerOrFillCharacteristicsGroupBox;
        private System.Windows.Forms.GroupBox DesignPointGroupBox;
        private System.Windows.Forms.Label LiquidToGasRatioLabel;
        private System.Windows.Forms.TextBox DemandCurve_Slope_C2_Value;
        private System.Windows.Forms.Label SlopeLabel;
        private System.Windows.Forms.TextBox DemandCurve_C_C1_Value;
        private System.Windows.Forms.Label CLabel;
        private System.Windows.Forms.TextBox DemandCurve_LiquidToGasRatio_Value;
        private System.Windows.Forms.Label MaximumLabel;
        private System.Windows.Forms.Label MinimumLabel;
        private System.Windows.Forms.NumericUpDown DemandCurve_Maximum_Value;
        private System.Windows.Forms.NumericUpDown DemandCurve_Minimum_Value;
        private System.Windows.Forms.RadioButton DemandCurve_KavLRadio;
        private System.Windows.Forms.RadioButton DemandCurve_ApproachRadio;
        private System.Windows.Forms.DataVisualization.Charting.Chart DemandCurveChart;
        private System.Windows.Forms.GroupBox groupBoxPressureElevation;
        private System.Windows.Forms.RadioButton DemandCurve_PressureRadio;
        private System.Windows.Forms.RadioButton DemandCurve_ElevationRadio;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}
