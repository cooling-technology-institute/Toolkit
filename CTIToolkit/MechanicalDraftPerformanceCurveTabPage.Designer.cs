namespace CTIToolkit
{
    partial class MechanicalDraftPerformanceCurveTabPage
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
            this.DataFileLabel = new System.Windows.Forms.Label();
            this.Calculate = new System.Windows.Forms.Button();
            this.ViewGraph = new System.Windows.Forms.Button();
            this.OwnerNameLabel = new System.Windows.Forms.Label();
            this.ProjectNameLabel = new System.Windows.Forms.Label();
            this.LocationLabel = new System.Windows.Forms.Label();
            this.TowerManufacturerLabel = new System.Windows.Forms.Label();
            this.TestResultsGroupBox = new System.Windows.Forms.GroupBox();
            this.ColdWaterTemperatureDeviationUnitLabel = new System.Windows.Forms.Label();
            this.TowerCapabilityUnitLabel = new System.Windows.Forms.Label();
            this.PredictedFlowRateUnitLabel = new System.Windows.Forms.Label();
            this.AdjustedFlowRateUnitLabel = new System.Windows.Forms.Label();
            this.ColdWaterTemperatureDeviation = new System.Windows.Forms.TextBox();
            this.ColdWaterTemperatureDeviationLabel = new System.Windows.Forms.Label();
            this.TowerCapability = new System.Windows.Forms.TextBox();
            this.TowerCapabilityLabel = new System.Windows.Forms.Label();
            this.PredictedFlowRate = new System.Windows.Forms.TextBox();
            this.PredictedFlowRateLabel = new System.Windows.Forms.Label();
            this.AdjustedFlowRate = new System.Windows.Forms.TextBox();
            this.AdjustedFlowRateLabel = new System.Windows.Forms.Label();
            this.UnitsWaterFlowRate = new System.Windows.Forms.Label();
            this.UnitsHotWaterTemperature = new System.Windows.Forms.Label();
            this.UnitsColdWaterTemperature = new System.Windows.Forms.Label();
            this.UnitsWetBulbTemperature = new System.Windows.Forms.Label();
            this.UnitsDryBulbTemperature = new System.Windows.Forms.Label();
            this.UnitsFanDriverPower = new System.Windows.Forms.Label();
            this.UnitsBarometricPressure = new System.Windows.Forms.Label();
            this.UnitsLiquidToGasRatio = new System.Windows.Forms.Label();
            this.TestGroupBox = new System.Windows.Forms.GroupBox();
            this.TestLiquidToGasRatio = new System.Windows.Forms.TextBox();
            this.TestWaterFlowRate = new System.Windows.Forms.TextBox();
            this.TestHotWaterTemperature = new System.Windows.Forms.TextBox();
            this.TestColdWaterTemperature = new System.Windows.Forms.TextBox();
            this.TestWetBulbTemperature = new System.Windows.Forms.TextBox();
            this.TestDryBulbTemperature = new System.Windows.Forms.TextBox();
            this.TestBarometricPressure = new System.Windows.Forms.TextBox();
            this.TestFanDriverPower = new System.Windows.Forms.TextBox();
            this.DesignGroupBox = new System.Windows.Forms.GroupBox();
            this.DesignFanDriverPower = new System.Windows.Forms.TextBox();
            this.DesignHotWaterTemperature = new System.Windows.Forms.TextBox();
            this.DesignColdWaterTemperature = new System.Windows.Forms.TextBox();
            this.DesignBarometricPressure = new System.Windows.Forms.TextBox();
            this.DesignDryBulbTemperature = new System.Windows.Forms.TextBox();
            this.DesignWetBulbTemperature = new System.Windows.Forms.TextBox();
            this.DesignLiquidToGasRatio = new System.Windows.Forms.TextBox();
            this.DesignWaterFlowRate = new System.Windows.Forms.TextBox();
            this.WaterFlowRateLabel = new System.Windows.Forms.Label();
            this.HotWaterTemperatureLabel = new System.Windows.Forms.Label();
            this.ColdWaterTemperatureLabel = new System.Windows.Forms.Label();
            this.WetBulbTemperatureLabel = new System.Windows.Forms.Label();
            this.DryBulbTemperatureLabel = new System.Windows.Forms.Label();
            this.FanDriverPowerLabel = new System.Windows.Forms.Label();
            this.BarometricPressureLabel = new System.Windows.Forms.Label();
            this.LiquidToGasRatioLabel = new System.Windows.Forms.Label();
            this.DesignDataButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.TowerTypeLabel = new System.Windows.Forms.Label();
            this.OwnerNameField = new System.Windows.Forms.TextBox();
            this.ProjectNameField = new System.Windows.Forms.TextBox();
            this.LocationField = new System.Windows.Forms.TextBox();
            this.TowerManufacturerField = new System.Windows.Forms.TextBox();
            this.TowerTypeField = new System.Windows.Forms.TextBox();
            this.DataFilename = new System.Windows.Forms.TextBox();
            this.TowerDataGroupBox = new System.Windows.Forms.GroupBox();
            this.TestSelector = new System.Windows.Forms.ComboBox();
            this.TestResultsGroupBox.SuspendLayout();
            this.TestGroupBox.SuspendLayout();
            this.DesignGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.TowerDataGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataFileLabel
            // 
            this.DataFileLabel.AutoSize = true;
            this.DataFileLabel.Location = new System.Drawing.Point(14, 21);
            this.DataFileLabel.Name = "DataFileLabel";
            this.DataFileLabel.Size = new System.Drawing.Size(118, 13);
            this.DataFileLabel.TabIndex = 0;
            this.DataFileLabel.Text = "Performance Data  File:";
            // 
            // Calculate
            // 
            this.Calculate.Location = new System.Drawing.Point(647, 16);
            this.Calculate.Name = "Calculate";
            this.Calculate.Size = new System.Drawing.Size(74, 23);
            this.Calculate.TabIndex = 3;
            this.Calculate.Text = "Calculate";
            this.Calculate.UseVisualStyleBackColor = true;
            this.Calculate.Click += new System.EventHandler(this.Calculate_Click);
            // 
            // ViewGraph
            // 
            this.ViewGraph.Enabled = false;
            this.ViewGraph.Location = new System.Drawing.Point(647, 52);
            this.ViewGraph.Name = "ViewGraph";
            this.ViewGraph.Size = new System.Drawing.Size(74, 23);
            this.ViewGraph.TabIndex = 4;
            this.ViewGraph.Text = "View Graph";
            this.ViewGraph.UseVisualStyleBackColor = true;
            this.ViewGraph.Click += new System.EventHandler(this.ViewGraph_Click);
            // 
            // OwnerNameLabel
            // 
            this.OwnerNameLabel.AutoSize = true;
            this.OwnerNameLabel.Location = new System.Drawing.Point(18, 23);
            this.OwnerNameLabel.Name = "OwnerNameLabel";
            this.OwnerNameLabel.Size = new System.Drawing.Size(72, 13);
            this.OwnerNameLabel.TabIndex = 5;
            this.OwnerNameLabel.Text = "Owner Name:";
            // 
            // ProjectNameLabel
            // 
            this.ProjectNameLabel.AutoSize = true;
            this.ProjectNameLabel.Location = new System.Drawing.Point(18, 51);
            this.ProjectNameLabel.Name = "ProjectNameLabel";
            this.ProjectNameLabel.Size = new System.Drawing.Size(74, 13);
            this.ProjectNameLabel.TabIndex = 7;
            this.ProjectNameLabel.Text = "Project Name:";
            // 
            // LocationLabel
            // 
            this.LocationLabel.AutoSize = true;
            this.LocationLabel.Location = new System.Drawing.Point(18, 79);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(51, 13);
            this.LocationLabel.TabIndex = 9;
            this.LocationLabel.Text = "Location:";
            // 
            // TowerManufacturerLabel
            // 
            this.TowerManufacturerLabel.AutoSize = true;
            this.TowerManufacturerLabel.Location = new System.Drawing.Point(18, 107);
            this.TowerManufacturerLabel.Name = "TowerManufacturerLabel";
            this.TowerManufacturerLabel.Size = new System.Drawing.Size(106, 13);
            this.TowerManufacturerLabel.TabIndex = 15;
            this.TowerManufacturerLabel.Text = "Tower Manufacturer:";
            // 
            // TestResultsGroupBox
            // 
            this.TestResultsGroupBox.Controls.Add(this.TestSelector);
            this.TestResultsGroupBox.Controls.Add(this.ColdWaterTemperatureDeviationUnitLabel);
            this.TestResultsGroupBox.Controls.Add(this.TowerCapabilityUnitLabel);
            this.TestResultsGroupBox.Controls.Add(this.PredictedFlowRateUnitLabel);
            this.TestResultsGroupBox.Controls.Add(this.AdjustedFlowRateUnitLabel);
            this.TestResultsGroupBox.Controls.Add(this.ColdWaterTemperatureDeviation);
            this.TestResultsGroupBox.Controls.Add(this.ColdWaterTemperatureDeviationLabel);
            this.TestResultsGroupBox.Controls.Add(this.TowerCapability);
            this.TestResultsGroupBox.Controls.Add(this.TowerCapabilityLabel);
            this.TestResultsGroupBox.Controls.Add(this.PredictedFlowRate);
            this.TestResultsGroupBox.Controls.Add(this.PredictedFlowRateLabel);
            this.TestResultsGroupBox.Controls.Add(this.AdjustedFlowRate);
            this.TestResultsGroupBox.Controls.Add(this.AdjustedFlowRateLabel);
            this.TestResultsGroupBox.Controls.Add(this.UnitsWaterFlowRate);
            this.TestResultsGroupBox.Controls.Add(this.UnitsHotWaterTemperature);
            this.TestResultsGroupBox.Controls.Add(this.UnitsColdWaterTemperature);
            this.TestResultsGroupBox.Controls.Add(this.UnitsWetBulbTemperature);
            this.TestResultsGroupBox.Controls.Add(this.UnitsDryBulbTemperature);
            this.TestResultsGroupBox.Controls.Add(this.UnitsFanDriverPower);
            this.TestResultsGroupBox.Controls.Add(this.UnitsBarometricPressure);
            this.TestResultsGroupBox.Controls.Add(this.UnitsLiquidToGasRatio);
            this.TestResultsGroupBox.Controls.Add(this.TestGroupBox);
            this.TestResultsGroupBox.Controls.Add(this.DesignGroupBox);
            this.TestResultsGroupBox.Controls.Add(this.WaterFlowRateLabel);
            this.TestResultsGroupBox.Controls.Add(this.HotWaterTemperatureLabel);
            this.TestResultsGroupBox.Controls.Add(this.ColdWaterTemperatureLabel);
            this.TestResultsGroupBox.Controls.Add(this.WetBulbTemperatureLabel);
            this.TestResultsGroupBox.Controls.Add(this.DryBulbTemperatureLabel);
            this.TestResultsGroupBox.Controls.Add(this.FanDriverPowerLabel);
            this.TestResultsGroupBox.Controls.Add(this.BarometricPressureLabel);
            this.TestResultsGroupBox.Controls.Add(this.LiquidToGasRatioLabel);
            this.TestResultsGroupBox.Location = new System.Drawing.Point(17, 227);
            this.TestResultsGroupBox.Name = "TestResultsGroupBox";
            this.TestResultsGroupBox.Size = new System.Drawing.Size(729, 337);
            this.TestResultsGroupBox.TabIndex = 14;
            this.TestResultsGroupBox.TabStop = false;
            this.TestResultsGroupBox.Text = "Test Results";
            // 
            // ColdWaterTemperatureDeviationUnitLabel
            // 
            this.ColdWaterTemperatureDeviationUnitLabel.AutoSize = true;
            this.ColdWaterTemperatureDeviationUnitLabel.Location = new System.Drawing.Point(705, 282);
            this.ColdWaterTemperatureDeviationUnitLabel.Name = "ColdWaterTemperatureDeviationUnitLabel";
            this.ColdWaterTemperatureDeviationUnitLabel.Size = new System.Drawing.Size(17, 13);
            this.ColdWaterTemperatureDeviationUnitLabel.TabIndex = 30;
            this.ColdWaterTemperatureDeviationUnitLabel.Text = "°F";
            // 
            // TowerCapabilityUnitLabel
            // 
            this.TowerCapabilityUnitLabel.AutoSize = true;
            this.TowerCapabilityUnitLabel.Location = new System.Drawing.Point(634, 251);
            this.TowerCapabilityUnitLabel.Name = "TowerCapabilityUnitLabel";
            this.TowerCapabilityUnitLabel.Size = new System.Drawing.Size(15, 13);
            this.TowerCapabilityUnitLabel.TabIndex = 29;
            this.TowerCapabilityUnitLabel.Text = "%";
            // 
            // PredictedFlowRateUnitLabel
            // 
            this.PredictedFlowRateUnitLabel.AutoSize = true;
            this.PredictedFlowRateUnitLabel.Location = new System.Drawing.Point(634, 221);
            this.PredictedFlowRateUnitLabel.Name = "PredictedFlowRateUnitLabel";
            this.PredictedFlowRateUnitLabel.Size = new System.Drawing.Size(19, 13);
            this.PredictedFlowRateUnitLabel.TabIndex = 28;
            this.PredictedFlowRateUnitLabel.Text = "l/s";
            // 
            // AdjustedFlowRateUnitLabel
            // 
            this.AdjustedFlowRateUnitLabel.AutoSize = true;
            this.AdjustedFlowRateUnitLabel.Location = new System.Drawing.Point(634, 191);
            this.AdjustedFlowRateUnitLabel.Name = "AdjustedFlowRateUnitLabel";
            this.AdjustedFlowRateUnitLabel.Size = new System.Drawing.Size(19, 13);
            this.AdjustedFlowRateUnitLabel.TabIndex = 27;
            this.AdjustedFlowRateUnitLabel.Text = "l/s";
            // 
            // ColdWaterTemperatureDeviation
            // 
            this.ColdWaterTemperatureDeviation.Location = new System.Drawing.Point(630, 278);
            this.ColdWaterTemperatureDeviation.Name = "ColdWaterTemperatureDeviation";
            this.ColdWaterTemperatureDeviation.ReadOnly = true;
            this.ColdWaterTemperatureDeviation.Size = new System.Drawing.Size(69, 20);
            this.ColdWaterTemperatureDeviation.TabIndex = 26;
            // 
            // ColdWaterTemperatureDeviationLabel
            // 
            this.ColdWaterTemperatureDeviationLabel.AutoSize = true;
            this.ColdWaterTemperatureDeviationLabel.Location = new System.Drawing.Point(450, 282);
            this.ColdWaterTemperatureDeviationLabel.Name = "ColdWaterTemperatureDeviationLabel";
            this.ColdWaterTemperatureDeviationLabel.Size = new System.Drawing.Size(174, 13);
            this.ColdWaterTemperatureDeviationLabel.TabIndex = 25;
            this.ColdWaterTemperatureDeviationLabel.Text = "Cold Water Temperature Deviation:";
            // 
            // TowerCapability
            // 
            this.TowerCapability.Location = new System.Drawing.Point(559, 248);
            this.TowerCapability.Name = "TowerCapability";
            this.TowerCapability.ReadOnly = true;
            this.TowerCapability.Size = new System.Drawing.Size(69, 20);
            this.TowerCapability.TabIndex = 24;
            // 
            // TowerCapabilityLabel
            // 
            this.TowerCapabilityLabel.AutoSize = true;
            this.TowerCapabilityLabel.Location = new System.Drawing.Point(450, 251);
            this.TowerCapabilityLabel.Name = "TowerCapabilityLabel";
            this.TowerCapabilityLabel.Size = new System.Drawing.Size(88, 13);
            this.TowerCapabilityLabel.TabIndex = 23;
            this.TowerCapabilityLabel.Text = "Tower Capability:";
            // 
            // PredictedFlowRate
            // 
            this.PredictedFlowRate.Location = new System.Drawing.Point(559, 218);
            this.PredictedFlowRate.Name = "PredictedFlowRate";
            this.PredictedFlowRate.ReadOnly = true;
            this.PredictedFlowRate.Size = new System.Drawing.Size(69, 20);
            this.PredictedFlowRate.TabIndex = 22;
            // 
            // PredictedFlowRateLabel
            // 
            this.PredictedFlowRateLabel.AutoSize = true;
            this.PredictedFlowRateLabel.Location = new System.Drawing.Point(450, 221);
            this.PredictedFlowRateLabel.Name = "PredictedFlowRateLabel";
            this.PredictedFlowRateLabel.Size = new System.Drawing.Size(106, 13);
            this.PredictedFlowRateLabel.TabIndex = 21;
            this.PredictedFlowRateLabel.Text = "Predicted Flow Rate:";
            // 
            // AdjustedFlowRate
            // 
            this.AdjustedFlowRate.Location = new System.Drawing.Point(559, 188);
            this.AdjustedFlowRate.Name = "AdjustedFlowRate";
            this.AdjustedFlowRate.ReadOnly = true;
            this.AdjustedFlowRate.Size = new System.Drawing.Size(69, 20);
            this.AdjustedFlowRate.TabIndex = 20;
            // 
            // AdjustedFlowRateLabel
            // 
            this.AdjustedFlowRateLabel.AutoSize = true;
            this.AdjustedFlowRateLabel.Location = new System.Drawing.Point(450, 191);
            this.AdjustedFlowRateLabel.Name = "AdjustedFlowRateLabel";
            this.AdjustedFlowRateLabel.Size = new System.Drawing.Size(102, 13);
            this.AdjustedFlowRateLabel.TabIndex = 19;
            this.AdjustedFlowRateLabel.Text = "Adjusted Flow Rate:";
            // 
            // UnitsWaterFlowRate
            // 
            this.UnitsWaterFlowRate.AutoSize = true;
            this.UnitsWaterFlowRate.Location = new System.Drawing.Point(394, 74);
            this.UnitsWaterFlowRate.Name = "UnitsWaterFlowRate";
            this.UnitsWaterFlowRate.Size = new System.Drawing.Size(27, 13);
            this.UnitsWaterFlowRate.TabIndex = 13;
            this.UnitsWaterFlowRate.Text = "gpm";
            // 
            // UnitsHotWaterTemperature
            // 
            this.UnitsHotWaterTemperature.AutoSize = true;
            this.UnitsHotWaterTemperature.Location = new System.Drawing.Point(394, 104);
            this.UnitsHotWaterTemperature.Name = "UnitsHotWaterTemperature";
            this.UnitsHotWaterTemperature.Size = new System.Drawing.Size(17, 13);
            this.UnitsHotWaterTemperature.TabIndex = 12;
            this.UnitsHotWaterTemperature.Text = "°F";
            // 
            // UnitsColdWaterTemperature
            // 
            this.UnitsColdWaterTemperature.AutoSize = true;
            this.UnitsColdWaterTemperature.Location = new System.Drawing.Point(394, 134);
            this.UnitsColdWaterTemperature.Name = "UnitsColdWaterTemperature";
            this.UnitsColdWaterTemperature.Size = new System.Drawing.Size(17, 13);
            this.UnitsColdWaterTemperature.TabIndex = 11;
            this.UnitsColdWaterTemperature.Text = "°F";
            // 
            // UnitsWetBulbTemperature
            // 
            this.UnitsWetBulbTemperature.AutoSize = true;
            this.UnitsWetBulbTemperature.Location = new System.Drawing.Point(394, 164);
            this.UnitsWetBulbTemperature.Name = "UnitsWetBulbTemperature";
            this.UnitsWetBulbTemperature.Size = new System.Drawing.Size(17, 13);
            this.UnitsWetBulbTemperature.TabIndex = 16;
            this.UnitsWetBulbTemperature.Text = "°F";
            // 
            // UnitsDryBulbTemperature
            // 
            this.UnitsDryBulbTemperature.AutoSize = true;
            this.UnitsDryBulbTemperature.Location = new System.Drawing.Point(394, 194);
            this.UnitsDryBulbTemperature.Name = "UnitsDryBulbTemperature";
            this.UnitsDryBulbTemperature.Size = new System.Drawing.Size(17, 13);
            this.UnitsDryBulbTemperature.TabIndex = 15;
            this.UnitsDryBulbTemperature.Text = "°F";
            // 
            // UnitsFanDriverPower
            // 
            this.UnitsFanDriverPower.AutoSize = true;
            this.UnitsFanDriverPower.Location = new System.Drawing.Point(394, 224);
            this.UnitsFanDriverPower.Name = "UnitsFanDriverPower";
            this.UnitsFanDriverPower.Size = new System.Drawing.Size(25, 13);
            this.UnitsFanDriverPower.TabIndex = 14;
            this.UnitsFanDriverPower.Text = "bhp";
            // 
            // UnitsBarometricPressure
            // 
            this.UnitsBarometricPressure.AutoSize = true;
            this.UnitsBarometricPressure.Location = new System.Drawing.Point(394, 254);
            this.UnitsBarometricPressure.Name = "UnitsBarometricPressure";
            this.UnitsBarometricPressure.Size = new System.Drawing.Size(26, 13);
            this.UnitsBarometricPressure.TabIndex = 17;
            this.UnitsBarometricPressure.Text = "\"Hg";
            // 
            // UnitsLiquidToGasRatio
            // 
            this.UnitsLiquidToGasRatio.AutoSize = true;
            this.UnitsLiquidToGasRatio.Location = new System.Drawing.Point(552, 288);
            this.UnitsLiquidToGasRatio.Name = "UnitsLiquidToGasRatio";
            this.UnitsLiquidToGasRatio.Size = new System.Drawing.Size(0, 13);
            this.UnitsLiquidToGasRatio.TabIndex = 18;
            // 
            // TestGroupBox
            // 
            this.TestGroupBox.Controls.Add(this.TestLiquidToGasRatio);
            this.TestGroupBox.Controls.Add(this.TestWaterFlowRate);
            this.TestGroupBox.Controls.Add(this.TestHotWaterTemperature);
            this.TestGroupBox.Controls.Add(this.TestColdWaterTemperature);
            this.TestGroupBox.Controls.Add(this.TestWetBulbTemperature);
            this.TestGroupBox.Controls.Add(this.TestDryBulbTemperature);
            this.TestGroupBox.Controls.Add(this.TestBarometricPressure);
            this.TestGroupBox.Controls.Add(this.TestFanDriverPower);
            this.TestGroupBox.Location = new System.Drawing.Point(272, 44);
            this.TestGroupBox.Name = "TestGroupBox";
            this.TestGroupBox.Size = new System.Drawing.Size(116, 273);
            this.TestGroupBox.TabIndex = 9;
            this.TestGroupBox.TabStop = false;
            this.TestGroupBox.Text = "Test";
            // 
            // TestLiquidToGasRatio
            // 
            this.TestLiquidToGasRatio.Enabled = false;
            this.TestLiquidToGasRatio.Location = new System.Drawing.Point(15, 237);
            this.TestLiquidToGasRatio.Name = "TestLiquidToGasRatio";
            this.TestLiquidToGasRatio.Size = new System.Drawing.Size(70, 20);
            this.TestLiquidToGasRatio.TabIndex = 13;
            this.TestLiquidToGasRatio.Validating += new System.ComponentModel.CancelEventHandler(this.TestLiquidToGasRatio_Validating);
            this.TestLiquidToGasRatio.Validated += new System.EventHandler(this.TestLiquidToGasRatio_Validated);
            // 
            // TestWaterFlowRate
            // 
            this.TestWaterFlowRate.Location = new System.Drawing.Point(15, 27);
            this.TestWaterFlowRate.Name = "TestWaterFlowRate";
            this.TestWaterFlowRate.Size = new System.Drawing.Size(70, 20);
            this.TestWaterFlowRate.TabIndex = 6;
            this.TestWaterFlowRate.Validating += new System.ComponentModel.CancelEventHandler(this.TestWaterFlowRate_Validating);
            this.TestWaterFlowRate.Validated += new System.EventHandler(this.TestWaterFlowRate_Validated);
            // 
            // TestHotWaterTemperature
            // 
            this.TestHotWaterTemperature.Location = new System.Drawing.Point(15, 57);
            this.TestHotWaterTemperature.Name = "TestHotWaterTemperature";
            this.TestHotWaterTemperature.Size = new System.Drawing.Size(70, 20);
            this.TestHotWaterTemperature.TabIndex = 7;
            this.TestHotWaterTemperature.Validating += new System.ComponentModel.CancelEventHandler(this.TestHotWaterTemperature_Validating);
            this.TestHotWaterTemperature.Validated += new System.EventHandler(this.TestHotWaterTemperature_Validated);
            // 
            // TestColdWaterTemperature
            // 
            this.TestColdWaterTemperature.Location = new System.Drawing.Point(15, 87);
            this.TestColdWaterTemperature.Name = "TestColdWaterTemperature";
            this.TestColdWaterTemperature.Size = new System.Drawing.Size(70, 20);
            this.TestColdWaterTemperature.TabIndex = 8;
            this.TestColdWaterTemperature.Validating += new System.ComponentModel.CancelEventHandler(this.TestColdWaterTemperature_Validating);
            this.TestColdWaterTemperature.Validated += new System.EventHandler(this.TestColdWaterTemperature_Validated);
            // 
            // TestWetBulbTemperature
            // 
            this.TestWetBulbTemperature.Location = new System.Drawing.Point(15, 117);
            this.TestWetBulbTemperature.Name = "TestWetBulbTemperature";
            this.TestWetBulbTemperature.Size = new System.Drawing.Size(70, 20);
            this.TestWetBulbTemperature.TabIndex = 9;
            this.TestWetBulbTemperature.Validating += new System.ComponentModel.CancelEventHandler(this.TestWetBulbTemperature_Validating);
            this.TestWetBulbTemperature.Validated += new System.EventHandler(this.TestWetBulbTemperature_Validated);
            // 
            // TestDryBulbTemperature
            // 
            this.TestDryBulbTemperature.Location = new System.Drawing.Point(15, 147);
            this.TestDryBulbTemperature.Name = "TestDryBulbTemperature";
            this.TestDryBulbTemperature.Size = new System.Drawing.Size(70, 20);
            this.TestDryBulbTemperature.TabIndex = 10;
            this.TestDryBulbTemperature.Validating += new System.ComponentModel.CancelEventHandler(this.TestDryBulbTemperature_Validating);
            this.TestDryBulbTemperature.Validated += new System.EventHandler(this.TestDryBulbTemperature_Validated);
            // 
            // TestBarometricPressure
            // 
            this.TestBarometricPressure.Location = new System.Drawing.Point(15, 207);
            this.TestBarometricPressure.Name = "TestBarometricPressure";
            this.TestBarometricPressure.Size = new System.Drawing.Size(70, 20);
            this.TestBarometricPressure.TabIndex = 12;
            this.TestBarometricPressure.Validating += new System.ComponentModel.CancelEventHandler(this.TestBarometricPressure_Validating);
            this.TestBarometricPressure.Validated += new System.EventHandler(this.TestBarometricPressure_Validated);
            // 
            // TestFanDriverPower
            // 
            this.TestFanDriverPower.Location = new System.Drawing.Point(15, 177);
            this.TestFanDriverPower.Name = "TestFanDriverPower";
            this.TestFanDriverPower.Size = new System.Drawing.Size(70, 20);
            this.TestFanDriverPower.TabIndex = 11;
            this.TestFanDriverPower.Validating += new System.ComponentModel.CancelEventHandler(this.TestFanDriverPower_Validating);
            this.TestFanDriverPower.Validated += new System.EventHandler(this.TestFanDriverPower_Validated);
            // 
            // DesignGroupBox
            // 
            this.DesignGroupBox.Controls.Add(this.DesignFanDriverPower);
            this.DesignGroupBox.Controls.Add(this.DesignHotWaterTemperature);
            this.DesignGroupBox.Controls.Add(this.DesignColdWaterTemperature);
            this.DesignGroupBox.Controls.Add(this.DesignBarometricPressure);
            this.DesignGroupBox.Controls.Add(this.DesignDryBulbTemperature);
            this.DesignGroupBox.Controls.Add(this.DesignWetBulbTemperature);
            this.DesignGroupBox.Controls.Add(this.DesignLiquidToGasRatio);
            this.DesignGroupBox.Controls.Add(this.DesignWaterFlowRate);
            this.DesignGroupBox.Location = new System.Drawing.Point(150, 44);
            this.DesignGroupBox.Name = "DesignGroupBox";
            this.DesignGroupBox.Size = new System.Drawing.Size(116, 273);
            this.DesignGroupBox.TabIndex = 8;
            this.DesignGroupBox.TabStop = false;
            this.DesignGroupBox.Text = "Design";
            // 
            // DesignFanDriverPower
            // 
            this.DesignFanDriverPower.Location = new System.Drawing.Point(15, 177);
            this.DesignFanDriverPower.Name = "DesignFanDriverPower";
            this.DesignFanDriverPower.ReadOnly = true;
            this.DesignFanDriverPower.Size = new System.Drawing.Size(70, 20);
            this.DesignFanDriverPower.TabIndex = 7;
            // 
            // DesignHotWaterTemperature
            // 
            this.DesignHotWaterTemperature.Location = new System.Drawing.Point(15, 57);
            this.DesignHotWaterTemperature.Name = "DesignHotWaterTemperature";
            this.DesignHotWaterTemperature.ReadOnly = true;
            this.DesignHotWaterTemperature.Size = new System.Drawing.Size(70, 20);
            this.DesignHotWaterTemperature.TabIndex = 6;
            // 
            // DesignColdWaterTemperature
            // 
            this.DesignColdWaterTemperature.Location = new System.Drawing.Point(15, 87);
            this.DesignColdWaterTemperature.Name = "DesignColdWaterTemperature";
            this.DesignColdWaterTemperature.ReadOnly = true;
            this.DesignColdWaterTemperature.Size = new System.Drawing.Size(70, 20);
            this.DesignColdWaterTemperature.TabIndex = 5;
            // 
            // DesignBarometricPressure
            // 
            this.DesignBarometricPressure.Location = new System.Drawing.Point(15, 207);
            this.DesignBarometricPressure.Name = "DesignBarometricPressure";
            this.DesignBarometricPressure.ReadOnly = true;
            this.DesignBarometricPressure.Size = new System.Drawing.Size(70, 20);
            this.DesignBarometricPressure.TabIndex = 4;
            // 
            // DesignDryBulbTemperature
            // 
            this.DesignDryBulbTemperature.Location = new System.Drawing.Point(15, 147);
            this.DesignDryBulbTemperature.Name = "DesignDryBulbTemperature";
            this.DesignDryBulbTemperature.ReadOnly = true;
            this.DesignDryBulbTemperature.Size = new System.Drawing.Size(70, 20);
            this.DesignDryBulbTemperature.TabIndex = 3;
            // 
            // DesignWetBulbTemperature
            // 
            this.DesignWetBulbTemperature.Location = new System.Drawing.Point(15, 117);
            this.DesignWetBulbTemperature.Name = "DesignWetBulbTemperature";
            this.DesignWetBulbTemperature.ReadOnly = true;
            this.DesignWetBulbTemperature.Size = new System.Drawing.Size(70, 20);
            this.DesignWetBulbTemperature.TabIndex = 2;
            // 
            // DesignLiquidToGasRatio
            // 
            this.DesignLiquidToGasRatio.Location = new System.Drawing.Point(15, 237);
            this.DesignLiquidToGasRatio.Name = "DesignLiquidToGasRatio";
            this.DesignLiquidToGasRatio.ReadOnly = true;
            this.DesignLiquidToGasRatio.Size = new System.Drawing.Size(70, 20);
            this.DesignLiquidToGasRatio.TabIndex = 1;
            // 
            // DesignWaterFlowRate
            // 
            this.DesignWaterFlowRate.Location = new System.Drawing.Point(15, 27);
            this.DesignWaterFlowRate.Name = "DesignWaterFlowRate";
            this.DesignWaterFlowRate.ReadOnly = true;
            this.DesignWaterFlowRate.Size = new System.Drawing.Size(70, 20);
            this.DesignWaterFlowRate.TabIndex = 0;
            // 
            // WaterFlowRateLabel
            // 
            this.WaterFlowRateLabel.AutoSize = true;
            this.WaterFlowRateLabel.Location = new System.Drawing.Point(18, 78);
            this.WaterFlowRateLabel.Name = "WaterFlowRateLabel";
            this.WaterFlowRateLabel.Size = new System.Drawing.Size(90, 13);
            this.WaterFlowRateLabel.TabIndex = 2;
            this.WaterFlowRateLabel.Text = "Water Flow Rate:";
            // 
            // HotWaterTemperatureLabel
            // 
            this.HotWaterTemperatureLabel.AutoSize = true;
            this.HotWaterTemperatureLabel.Location = new System.Drawing.Point(18, 107);
            this.HotWaterTemperatureLabel.Name = "HotWaterTemperatureLabel";
            this.HotWaterTemperatureLabel.Size = new System.Drawing.Size(122, 13);
            this.HotWaterTemperatureLabel.TabIndex = 1;
            this.HotWaterTemperatureLabel.Text = "Hot Water Temperature:";
            // 
            // ColdWaterTemperatureLabel
            // 
            this.ColdWaterTemperatureLabel.AutoSize = true;
            this.ColdWaterTemperatureLabel.Location = new System.Drawing.Point(18, 136);
            this.ColdWaterTemperatureLabel.Name = "ColdWaterTemperatureLabel";
            this.ColdWaterTemperatureLabel.Size = new System.Drawing.Size(126, 13);
            this.ColdWaterTemperatureLabel.TabIndex = 0;
            this.ColdWaterTemperatureLabel.Text = "Cold Water Temperature:";
            // 
            // WetBulbTemperatureLabel
            // 
            this.WetBulbTemperatureLabel.AutoSize = true;
            this.WetBulbTemperatureLabel.Location = new System.Drawing.Point(18, 165);
            this.WetBulbTemperatureLabel.Name = "WetBulbTemperatureLabel";
            this.WetBulbTemperatureLabel.Size = new System.Drawing.Size(117, 13);
            this.WetBulbTemperatureLabel.TabIndex = 5;
            this.WetBulbTemperatureLabel.Text = "Wet Bulb Temperature:";
            // 
            // DryBulbTemperatureLabel
            // 
            this.DryBulbTemperatureLabel.AutoSize = true;
            this.DryBulbTemperatureLabel.Location = new System.Drawing.Point(18, 194);
            this.DryBulbTemperatureLabel.Name = "DryBulbTemperatureLabel";
            this.DryBulbTemperatureLabel.Size = new System.Drawing.Size(113, 13);
            this.DryBulbTemperatureLabel.TabIndex = 4;
            this.DryBulbTemperatureLabel.Text = "Dry Bulb Temperature:";
            // 
            // FanDriverPowerLabel
            // 
            this.FanDriverPowerLabel.AutoSize = true;
            this.FanDriverPowerLabel.Location = new System.Drawing.Point(18, 223);
            this.FanDriverPowerLabel.Name = "FanDriverPowerLabel";
            this.FanDriverPowerLabel.Size = new System.Drawing.Size(92, 13);
            this.FanDriverPowerLabel.TabIndex = 3;
            this.FanDriverPowerLabel.Text = "Fan Driver Power:";
            // 
            // BarometricPressureLabel
            // 
            this.BarometricPressureLabel.AutoSize = true;
            this.BarometricPressureLabel.Location = new System.Drawing.Point(18, 252);
            this.BarometricPressureLabel.Name = "BarometricPressureLabel";
            this.BarometricPressureLabel.Size = new System.Drawing.Size(104, 13);
            this.BarometricPressureLabel.TabIndex = 6;
            this.BarometricPressureLabel.Text = "Barometric Pressure:";
            // 
            // LiquidToGasRatioLabel
            // 
            this.LiquidToGasRatioLabel.AutoSize = true;
            this.LiquidToGasRatioLabel.Location = new System.Drawing.Point(18, 281);
            this.LiquidToGasRatioLabel.Name = "LiquidToGasRatioLabel";
            this.LiquidToGasRatioLabel.Size = new System.Drawing.Size(104, 13);
            this.LiquidToGasRatioLabel.TabIndex = 7;
            this.LiquidToGasRatioLabel.Text = "Liquid To Gas Ratio:";
            // 
            // DesignDataButton
            // 
            this.DesignDataButton.Location = new System.Drawing.Point(647, 88);
            this.DesignDataButton.Name = "DesignDataButton";
            this.DesignDataButton.Size = new System.Drawing.Size(87, 25);
            this.DesignDataButton.TabIndex = 10;
            this.DesignDataButton.Text = "Design Data...";
            this.DesignDataButton.UseVisualStyleBackColor = true;
            this.DesignDataButton.Click += new System.EventHandler(this.DesignDataButton_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // TowerTypeLabel
            // 
            this.TowerTypeLabel.AutoSize = true;
            this.TowerTypeLabel.Location = new System.Drawing.Point(18, 135);
            this.TowerTypeLabel.Name = "TowerTypeLabel";
            this.TowerTypeLabel.Size = new System.Drawing.Size(67, 13);
            this.TowerTypeLabel.TabIndex = 17;
            this.TowerTypeLabel.Text = "Tower Type:";
            // 
            // OwnerNameField
            // 
            this.OwnerNameField.Location = new System.Drawing.Point(121, 20);
            this.OwnerNameField.Name = "OwnerNameField";
            this.OwnerNameField.ReadOnly = true;
            this.OwnerNameField.Size = new System.Drawing.Size(397, 20);
            this.OwnerNameField.TabIndex = 19;
            // 
            // ProjectNameField
            // 
            this.ProjectNameField.Location = new System.Drawing.Point(121, 48);
            this.ProjectNameField.Name = "ProjectNameField";
            this.ProjectNameField.ReadOnly = true;
            this.ProjectNameField.Size = new System.Drawing.Size(397, 20);
            this.ProjectNameField.TabIndex = 20;
            // 
            // LocationField
            // 
            this.LocationField.Location = new System.Drawing.Point(121, 76);
            this.LocationField.Name = "LocationField";
            this.LocationField.ReadOnly = true;
            this.LocationField.Size = new System.Drawing.Size(397, 20);
            this.LocationField.TabIndex = 21;
            // 
            // TowerManufacturerField
            // 
            this.TowerManufacturerField.Location = new System.Drawing.Point(121, 104);
            this.TowerManufacturerField.Name = "TowerManufacturerField";
            this.TowerManufacturerField.ReadOnly = true;
            this.TowerManufacturerField.Size = new System.Drawing.Size(397, 20);
            this.TowerManufacturerField.TabIndex = 22;
            // 
            // TowerTypeField
            // 
            this.TowerTypeField.Location = new System.Drawing.Point(121, 132);
            this.TowerTypeField.Name = "TowerTypeField";
            this.TowerTypeField.ReadOnly = true;
            this.TowerTypeField.Size = new System.Drawing.Size(397, 20);
            this.TowerTypeField.TabIndex = 23;
            // 
            // DataFilename
            // 
            this.DataFilename.Location = new System.Drawing.Point(138, 18);
            this.DataFilename.Name = "DataFilename";
            this.DataFilename.ReadOnly = true;
            this.DataFilename.Size = new System.Drawing.Size(416, 20);
            this.DataFilename.TabIndex = 24;
            // 
            // TowerDataGroupBox
            // 
            this.TowerDataGroupBox.Controls.Add(this.OwnerNameLabel);
            this.TowerDataGroupBox.Controls.Add(this.ProjectNameLabel);
            this.TowerDataGroupBox.Controls.Add(this.TowerTypeField);
            this.TowerDataGroupBox.Controls.Add(this.LocationLabel);
            this.TowerDataGroupBox.Controls.Add(this.TowerManufacturerField);
            this.TowerDataGroupBox.Controls.Add(this.TowerManufacturerLabel);
            this.TowerDataGroupBox.Controls.Add(this.LocationField);
            this.TowerDataGroupBox.Controls.Add(this.TowerTypeLabel);
            this.TowerDataGroupBox.Controls.Add(this.ProjectNameField);
            this.TowerDataGroupBox.Controls.Add(this.OwnerNameField);
            this.TowerDataGroupBox.Location = new System.Drawing.Point(17, 52);
            this.TowerDataGroupBox.Name = "TowerDataGroupBox";
            this.TowerDataGroupBox.Size = new System.Drawing.Size(537, 169);
            this.TowerDataGroupBox.TabIndex = 25;
            this.TowerDataGroupBox.TabStop = false;
            this.TowerDataGroupBox.Text = "Tower Data";
            // 
            // TestSelector
            // 
            this.TestSelector.FormattingEnabled = true;
            this.TestSelector.Location = new System.Drawing.Point(272, 17);
            this.TestSelector.Name = "TestSelector";
            this.TestSelector.Size = new System.Drawing.Size(265, 21);
            this.TestSelector.TabIndex = 31;
            this.TestSelector.SelectedIndexChanged += new System.EventHandler(this.TestSelector_SelectedIndexChanged);
            // 
            // MechanicalDraftPerformanceCurveTabPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TowerDataGroupBox);
            this.Controls.Add(this.DataFilename);
            this.Controls.Add(this.DesignDataButton);
            this.Controls.Add(this.TestResultsGroupBox);
            this.Controls.Add(this.ViewGraph);
            this.Controls.Add(this.Calculate);
            this.Controls.Add(this.DataFileLabel);
            this.Name = "MechanicalDraftPerformanceCurveTabPage";
            this.Size = new System.Drawing.Size(760, 567);
            this.TestResultsGroupBox.ResumeLayout(false);
            this.TestResultsGroupBox.PerformLayout();
            this.TestGroupBox.ResumeLayout(false);
            this.TestGroupBox.PerformLayout();
            this.DesignGroupBox.ResumeLayout(false);
            this.DesignGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.TowerDataGroupBox.ResumeLayout(false);
            this.TowerDataGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DataFileLabel;
        private System.Windows.Forms.Button Calculate;
        private System.Windows.Forms.Button ViewGraph;
        private System.Windows.Forms.Label OwnerNameLabel;
        private System.Windows.Forms.Label ProjectNameLabel;
        private System.Windows.Forms.Label LocationLabel;
        private System.Windows.Forms.Label TowerManufacturerLabel;
        private System.Windows.Forms.GroupBox TestResultsGroupBox;
        private System.Windows.Forms.Label ColdWaterTemperatureLabel;
        private System.Windows.Forms.Label HotWaterTemperatureLabel;
        private System.Windows.Forms.Label WaterFlowRateLabel;
        private System.Windows.Forms.Label WetBulbTemperatureLabel;
        private System.Windows.Forms.Label DryBulbTemperatureLabel;
        private System.Windows.Forms.Label FanDriverPowerLabel;
        private System.Windows.Forms.Label BarometricPressureLabel;
        private System.Windows.Forms.Label LiquidToGasRatioLabel;
        private System.Windows.Forms.GroupBox DesignGroupBox;
        private System.Windows.Forms.TextBox DesignFanDriverPower;
        private System.Windows.Forms.TextBox DesignHotWaterTemperature;
        private System.Windows.Forms.TextBox DesignColdWaterTemperature;
        private System.Windows.Forms.TextBox DesignBarometricPressure;
        private System.Windows.Forms.TextBox DesignDryBulbTemperature;
        private System.Windows.Forms.TextBox DesignWetBulbTemperature;
        private System.Windows.Forms.TextBox DesignLiquidToGasRatio;
        private System.Windows.Forms.TextBox DesignWaterFlowRate;
        private System.Windows.Forms.Button DesignDataButton;
        private System.Windows.Forms.Label UnitsWaterFlowRate;
        private System.Windows.Forms.Label UnitsHotWaterTemperature;
        private System.Windows.Forms.Label UnitsColdWaterTemperature;
        private System.Windows.Forms.Label UnitsWetBulbTemperature;
        private System.Windows.Forms.Label UnitsDryBulbTemperature;
        private System.Windows.Forms.Label UnitsFanDriverPower;
        private System.Windows.Forms.Label UnitsBarometricPressure;
        private System.Windows.Forms.Label UnitsLiquidToGasRatio;
        private System.Windows.Forms.GroupBox TestGroupBox;
        private System.Windows.Forms.TextBox TestLiquidToGasRatio;
        private System.Windows.Forms.TextBox TestWaterFlowRate;
        private System.Windows.Forms.TextBox TestHotWaterTemperature;
        private System.Windows.Forms.TextBox TestColdWaterTemperature;
        private System.Windows.Forms.TextBox TestWetBulbTemperature;
        private System.Windows.Forms.TextBox TestDryBulbTemperature;
        private System.Windows.Forms.TextBox TestBarometricPressure;
        private System.Windows.Forms.TextBox TestFanDriverPower;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label TowerTypeLabel;
        private System.Windows.Forms.TextBox TowerTypeField;
        private System.Windows.Forms.TextBox TowerManufacturerField;
        private System.Windows.Forms.TextBox LocationField;
        private System.Windows.Forms.TextBox ProjectNameField;
        private System.Windows.Forms.TextBox OwnerNameField;
        private System.Windows.Forms.TextBox DataFilename;
        private System.Windows.Forms.GroupBox TowerDataGroupBox;
        private System.Windows.Forms.Label ColdWaterTemperatureDeviationUnitLabel;
        private System.Windows.Forms.Label TowerCapabilityUnitLabel;
        private System.Windows.Forms.Label PredictedFlowRateUnitLabel;
        private System.Windows.Forms.Label AdjustedFlowRateUnitLabel;
        private System.Windows.Forms.TextBox ColdWaterTemperatureDeviation;
        private System.Windows.Forms.Label ColdWaterTemperatureDeviationLabel;
        private System.Windows.Forms.TextBox TowerCapability;
        private System.Windows.Forms.Label TowerCapabilityLabel;
        private System.Windows.Forms.TextBox PredictedFlowRate;
        private System.Windows.Forms.Label PredictedFlowRateLabel;
        private System.Windows.Forms.TextBox AdjustedFlowRate;
        private System.Windows.Forms.Label AdjustedFlowRateLabel;
        private System.Windows.Forms.ComboBox TestSelector;
    }
}
