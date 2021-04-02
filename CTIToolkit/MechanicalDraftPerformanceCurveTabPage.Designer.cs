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
            this.CalculateButton = new System.Windows.Forms.Button();
            this.ViewGraph = new System.Windows.Forms.Button();
            this.OwnerNameLabel = new System.Windows.Forms.Label();
            this.ProjectNameLabel = new System.Windows.Forms.Label();
            this.LocationLabel = new System.Windows.Forms.Label();
            this.TowerManufacturerLabel = new System.Windows.Forms.Label();
            this.TestResultsGroupBox = new System.Windows.Forms.GroupBox();
            this.AddTestPointButton = new System.Windows.Forms.Button();
            this.AddTestPointName = new System.Windows.Forms.TextBox();
            this.TestPointTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
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
            this.UnitsWaterFlowRate = new System.Windows.Forms.Label();
            this.HotWaterTemperatureLabel = new System.Windows.Forms.Label();
            this.UnitsHotWaterTemperature = new System.Windows.Forms.Label();
            this.ColdWaterTemperatureLabel = new System.Windows.Forms.Label();
            this.WetBulbTemperatureLabel = new System.Windows.Forms.Label();
            this.UnitsColdWaterTemperature = new System.Windows.Forms.Label();
            this.DryBulbTemperatureLabel = new System.Windows.Forms.Label();
            this.FanDriverPowerLabel = new System.Windows.Forms.Label();
            this.UnitsWetBulbTemperature = new System.Windows.Forms.Label();
            this.BarometricPressureLabel = new System.Windows.Forms.Label();
            this.LiquidToGasRatioLabel = new System.Windows.Forms.Label();
            this.UnitsDryBulbTemperature = new System.Windows.Forms.Label();
            this.UnitsBarometricPressure = new System.Windows.Forms.Label();
            this.UnitsFanDriverPower = new System.Windows.Forms.Label();
            this.UnitsLiquidToGasRatio = new System.Windows.Forms.Label();
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
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.TestResultsGroupBox.SuspendLayout();
            this.TestPointTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.DesignGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.TowerDataGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DataFileLabel
            // 
            this.DataFileLabel.AutoSize = true;
            this.DataFileLabel.Location = new System.Drawing.Point(0, 23);
            this.DataFileLabel.Name = "DataFileLabel";
            this.DataFileLabel.Size = new System.Drawing.Size(118, 13);
            this.DataFileLabel.TabIndex = 0;
            this.DataFileLabel.Text = "Performance Data  File:";
            // 
            // CalculateButton
            // 
            this.CalculateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CalculateButton.Enabled = false;
            this.CalculateButton.Location = new System.Drawing.Point(723, 17);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(74, 23);
            this.CalculateButton.TabIndex = 3;
            this.CalculateButton.Text = "Calculate";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.Calculate_Click);
            // 
            // ViewGraph
            // 
            this.ViewGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ViewGraph.Enabled = false;
            this.ViewGraph.Location = new System.Drawing.Point(710, 46);
            this.ViewGraph.Name = "ViewGraph";
            this.ViewGraph.Size = new System.Drawing.Size(87, 23);
            this.ViewGraph.TabIndex = 4;
            this.ViewGraph.Text = "View Graphs...";
            this.ViewGraph.UseVisualStyleBackColor = true;
            this.ViewGraph.Click += new System.EventHandler(this.ViewGraph_Click);
            // 
            // OwnerNameLabel
            // 
            this.OwnerNameLabel.AutoSize = true;
            this.OwnerNameLabel.Location = new System.Drawing.Point(14, 20);
            this.OwnerNameLabel.Name = "OwnerNameLabel";
            this.OwnerNameLabel.Size = new System.Drawing.Size(72, 13);
            this.OwnerNameLabel.TabIndex = 5;
            this.OwnerNameLabel.Text = "Owner Name:";
            // 
            // ProjectNameLabel
            // 
            this.ProjectNameLabel.AutoSize = true;
            this.ProjectNameLabel.Location = new System.Drawing.Point(14, 44);
            this.ProjectNameLabel.Name = "ProjectNameLabel";
            this.ProjectNameLabel.Size = new System.Drawing.Size(74, 13);
            this.ProjectNameLabel.TabIndex = 7;
            this.ProjectNameLabel.Text = "Project Name:";
            // 
            // LocationLabel
            // 
            this.LocationLabel.AutoSize = true;
            this.LocationLabel.Location = new System.Drawing.Point(16, 72);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(51, 13);
            this.LocationLabel.TabIndex = 9;
            this.LocationLabel.Text = "Location:";
            // 
            // TowerManufacturerLabel
            // 
            this.TowerManufacturerLabel.AutoSize = true;
            this.TowerManufacturerLabel.Location = new System.Drawing.Point(14, 98);
            this.TowerManufacturerLabel.Name = "TowerManufacturerLabel";
            this.TowerManufacturerLabel.Size = new System.Drawing.Size(106, 13);
            this.TowerManufacturerLabel.TabIndex = 15;
            this.TowerManufacturerLabel.Text = "Tower Manufacturer:";
            // 
            // TestResultsGroupBox
            // 
            this.TestResultsGroupBox.Controls.Add(this.AddTestPointButton);
            this.TestResultsGroupBox.Controls.Add(this.AddTestPointName);
            this.TestResultsGroupBox.Controls.Add(this.TestPointTabControl);
            this.TestResultsGroupBox.Controls.Add(this.DesignGroupBox);
            this.TestResultsGroupBox.Controls.Add(this.WaterFlowRateLabel);
            this.TestResultsGroupBox.Controls.Add(this.UnitsWaterFlowRate);
            this.TestResultsGroupBox.Controls.Add(this.HotWaterTemperatureLabel);
            this.TestResultsGroupBox.Controls.Add(this.UnitsHotWaterTemperature);
            this.TestResultsGroupBox.Controls.Add(this.ColdWaterTemperatureLabel);
            this.TestResultsGroupBox.Controls.Add(this.WetBulbTemperatureLabel);
            this.TestResultsGroupBox.Controls.Add(this.UnitsColdWaterTemperature);
            this.TestResultsGroupBox.Controls.Add(this.DryBulbTemperatureLabel);
            this.TestResultsGroupBox.Controls.Add(this.FanDriverPowerLabel);
            this.TestResultsGroupBox.Controls.Add(this.UnitsWetBulbTemperature);
            this.TestResultsGroupBox.Controls.Add(this.BarometricPressureLabel);
            this.TestResultsGroupBox.Controls.Add(this.LiquidToGasRatioLabel);
            this.TestResultsGroupBox.Controls.Add(this.UnitsDryBulbTemperature);
            this.TestResultsGroupBox.Controls.Add(this.UnitsBarometricPressure);
            this.TestResultsGroupBox.Controls.Add(this.UnitsFanDriverPower);
            this.TestResultsGroupBox.Location = new System.Drawing.Point(3, 209);
            this.TestResultsGroupBox.Name = "TestResultsGroupBox";
            this.TestResultsGroupBox.Size = new System.Drawing.Size(804, 311);
            this.TestResultsGroupBox.TabIndex = 14;
            this.TestResultsGroupBox.TabStop = false;
            this.TestResultsGroupBox.Text = "Test Results";
            // 
            // AddTestPointButton
            // 
            this.AddTestPointButton.Enabled = false;
            this.AddTestPointButton.Location = new System.Drawing.Point(682, 277);
            this.AddTestPointButton.Name = "AddTestPointButton";
            this.AddTestPointButton.Size = new System.Drawing.Size(110, 23);
            this.AddTestPointButton.TabIndex = 34;
            this.AddTestPointButton.Text = "Add Test Point";
            this.AddTestPointButton.UseVisualStyleBackColor = true;
            this.AddTestPointButton.Click += new System.EventHandler(this.AddTestPointButton_Click);
            // 
            // AddTestPointName
            // 
            this.AddTestPointName.Enabled = false;
            this.AddTestPointName.Location = new System.Drawing.Point(396, 277);
            this.AddTestPointName.Name = "AddTestPointName";
            this.AddTestPointName.Size = new System.Drawing.Size(279, 20);
            this.AddTestPointName.TabIndex = 33;
            // 
            // TestPointTabControl
            // 
            this.TestPointTabControl.Controls.Add(this.tabPage1);
            this.TestPointTabControl.Controls.Add(this.tabPage2);
            this.TestPointTabControl.Location = new System.Drawing.Point(300, 14);
            this.TestPointTabControl.Name = "TestPointTabControl";
            this.TestPointTabControl.SelectedIndex = 0;
            this.TestPointTabControl.Size = new System.Drawing.Size(498, 256);
            this.TestPointTabControl.TabIndex = 32;
            this.TestPointTabControl.SelectedIndexChanged += new System.EventHandler(this.TestPointTabControl_SelectedIndexChanged);
            this.TestPointTabControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TestPointTabControl_MouseUp);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.textBox3);
            this.tabPage1.Controls.Add(this.textBox4);
            this.tabPage1.Controls.Add(this.textBox5);
            this.tabPage1.Controls.Add(this.textBox6);
            this.tabPage1.Controls.Add(this.textBox7);
            this.tabPage1.Controls.Add(this.textBox8);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(490, 230);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(15, 204);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(70, 20);
            this.textBox1.TabIndex = 21;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(15, 21);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(70, 20);
            this.textBox2.TabIndex = 14;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(15, 47);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(70, 20);
            this.textBox3.TabIndex = 15;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(15, 73);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(70, 20);
            this.textBox4.TabIndex = 16;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(15, 99);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(70, 20);
            this.textBox5.TabIndex = 17;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(15, 125);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(70, 20);
            this.textBox6.TabIndex = 18;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(15, 177);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(70, 20);
            this.textBox7.TabIndex = 20;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(15, 151);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(70, 20);
            this.textBox8.TabIndex = 19;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(490, 230);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.DesignGroupBox.Location = new System.Drawing.Point(146, 30);
            this.DesignGroupBox.Name = "DesignGroupBox";
            this.DesignGroupBox.Size = new System.Drawing.Size(116, 240);
            this.DesignGroupBox.TabIndex = 8;
            this.DesignGroupBox.TabStop = false;
            this.DesignGroupBox.Text = "Design";
            // 
            // DesignFanDriverPower
            // 
            this.DesignFanDriverPower.Location = new System.Drawing.Point(15, 157);
            this.DesignFanDriverPower.Name = "DesignFanDriverPower";
            this.DesignFanDriverPower.ReadOnly = true;
            this.DesignFanDriverPower.Size = new System.Drawing.Size(70, 20);
            this.DesignFanDriverPower.TabIndex = 7;
            // 
            // DesignHotWaterTemperature
            // 
            this.DesignHotWaterTemperature.Location = new System.Drawing.Point(15, 53);
            this.DesignHotWaterTemperature.Name = "DesignHotWaterTemperature";
            this.DesignHotWaterTemperature.ReadOnly = true;
            this.DesignHotWaterTemperature.Size = new System.Drawing.Size(70, 20);
            this.DesignHotWaterTemperature.TabIndex = 6;
            // 
            // DesignColdWaterTemperature
            // 
            this.DesignColdWaterTemperature.Location = new System.Drawing.Point(15, 79);
            this.DesignColdWaterTemperature.Name = "DesignColdWaterTemperature";
            this.DesignColdWaterTemperature.ReadOnly = true;
            this.DesignColdWaterTemperature.Size = new System.Drawing.Size(70, 20);
            this.DesignColdWaterTemperature.TabIndex = 5;
            // 
            // DesignBarometricPressure
            // 
            this.DesignBarometricPressure.Location = new System.Drawing.Point(15, 183);
            this.DesignBarometricPressure.Name = "DesignBarometricPressure";
            this.DesignBarometricPressure.ReadOnly = true;
            this.DesignBarometricPressure.Size = new System.Drawing.Size(70, 20);
            this.DesignBarometricPressure.TabIndex = 4;
            // 
            // DesignDryBulbTemperature
            // 
            this.DesignDryBulbTemperature.Location = new System.Drawing.Point(15, 131);
            this.DesignDryBulbTemperature.Name = "DesignDryBulbTemperature";
            this.DesignDryBulbTemperature.ReadOnly = true;
            this.DesignDryBulbTemperature.Size = new System.Drawing.Size(70, 20);
            this.DesignDryBulbTemperature.TabIndex = 3;
            // 
            // DesignWetBulbTemperature
            // 
            this.DesignWetBulbTemperature.Location = new System.Drawing.Point(15, 105);
            this.DesignWetBulbTemperature.Name = "DesignWetBulbTemperature";
            this.DesignWetBulbTemperature.ReadOnly = true;
            this.DesignWetBulbTemperature.Size = new System.Drawing.Size(70, 20);
            this.DesignWetBulbTemperature.TabIndex = 2;
            // 
            // DesignLiquidToGasRatio
            // 
            this.DesignLiquidToGasRatio.Location = new System.Drawing.Point(15, 210);
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
            this.WaterFlowRateLabel.Location = new System.Drawing.Point(14, 60);
            this.WaterFlowRateLabel.Name = "WaterFlowRateLabel";
            this.WaterFlowRateLabel.Size = new System.Drawing.Size(90, 13);
            this.WaterFlowRateLabel.TabIndex = 2;
            this.WaterFlowRateLabel.Text = "Water Flow Rate:";
            // 
            // UnitsWaterFlowRate
            // 
            this.UnitsWaterFlowRate.AutoSize = true;
            this.UnitsWaterFlowRate.Location = new System.Drawing.Point(268, 60);
            this.UnitsWaterFlowRate.Name = "UnitsWaterFlowRate";
            this.UnitsWaterFlowRate.Size = new System.Drawing.Size(27, 13);
            this.UnitsWaterFlowRate.TabIndex = 13;
            this.UnitsWaterFlowRate.Text = "gpm";
            // 
            // HotWaterTemperatureLabel
            // 
            this.HotWaterTemperatureLabel.AutoSize = true;
            this.HotWaterTemperatureLabel.Location = new System.Drawing.Point(14, 86);
            this.HotWaterTemperatureLabel.Name = "HotWaterTemperatureLabel";
            this.HotWaterTemperatureLabel.Size = new System.Drawing.Size(122, 13);
            this.HotWaterTemperatureLabel.TabIndex = 1;
            this.HotWaterTemperatureLabel.Text = "Hot Water Temperature:";
            // 
            // UnitsHotWaterTemperature
            // 
            this.UnitsHotWaterTemperature.AutoSize = true;
            this.UnitsHotWaterTemperature.Location = new System.Drawing.Point(268, 86);
            this.UnitsHotWaterTemperature.Name = "UnitsHotWaterTemperature";
            this.UnitsHotWaterTemperature.Size = new System.Drawing.Size(17, 13);
            this.UnitsHotWaterTemperature.TabIndex = 12;
            this.UnitsHotWaterTemperature.Text = "°F";
            // 
            // ColdWaterTemperatureLabel
            // 
            this.ColdWaterTemperatureLabel.AutoSize = true;
            this.ColdWaterTemperatureLabel.Location = new System.Drawing.Point(14, 112);
            this.ColdWaterTemperatureLabel.Name = "ColdWaterTemperatureLabel";
            this.ColdWaterTemperatureLabel.Size = new System.Drawing.Size(126, 13);
            this.ColdWaterTemperatureLabel.TabIndex = 0;
            this.ColdWaterTemperatureLabel.Text = "Cold Water Temperature:";
            // 
            // WetBulbTemperatureLabel
            // 
            this.WetBulbTemperatureLabel.AutoSize = true;
            this.WetBulbTemperatureLabel.Location = new System.Drawing.Point(14, 138);
            this.WetBulbTemperatureLabel.Name = "WetBulbTemperatureLabel";
            this.WetBulbTemperatureLabel.Size = new System.Drawing.Size(117, 13);
            this.WetBulbTemperatureLabel.TabIndex = 5;
            this.WetBulbTemperatureLabel.Text = "Wet Bulb Temperature:";
            // 
            // UnitsColdWaterTemperature
            // 
            this.UnitsColdWaterTemperature.AutoSize = true;
            this.UnitsColdWaterTemperature.Location = new System.Drawing.Point(268, 112);
            this.UnitsColdWaterTemperature.Name = "UnitsColdWaterTemperature";
            this.UnitsColdWaterTemperature.Size = new System.Drawing.Size(17, 13);
            this.UnitsColdWaterTemperature.TabIndex = 11;
            this.UnitsColdWaterTemperature.Text = "°F";
            // 
            // DryBulbTemperatureLabel
            // 
            this.DryBulbTemperatureLabel.AutoSize = true;
            this.DryBulbTemperatureLabel.Location = new System.Drawing.Point(14, 164);
            this.DryBulbTemperatureLabel.Name = "DryBulbTemperatureLabel";
            this.DryBulbTemperatureLabel.Size = new System.Drawing.Size(113, 13);
            this.DryBulbTemperatureLabel.TabIndex = 4;
            this.DryBulbTemperatureLabel.Text = "Dry Bulb Temperature:";
            // 
            // FanDriverPowerLabel
            // 
            this.FanDriverPowerLabel.AutoSize = true;
            this.FanDriverPowerLabel.Location = new System.Drawing.Point(14, 190);
            this.FanDriverPowerLabel.Name = "FanDriverPowerLabel";
            this.FanDriverPowerLabel.Size = new System.Drawing.Size(92, 13);
            this.FanDriverPowerLabel.TabIndex = 3;
            this.FanDriverPowerLabel.Text = "Fan Driver Power:";
            // 
            // UnitsWetBulbTemperature
            // 
            this.UnitsWetBulbTemperature.AutoSize = true;
            this.UnitsWetBulbTemperature.Location = new System.Drawing.Point(268, 138);
            this.UnitsWetBulbTemperature.Name = "UnitsWetBulbTemperature";
            this.UnitsWetBulbTemperature.Size = new System.Drawing.Size(17, 13);
            this.UnitsWetBulbTemperature.TabIndex = 16;
            this.UnitsWetBulbTemperature.Text = "°F";
            // 
            // BarometricPressureLabel
            // 
            this.BarometricPressureLabel.AutoSize = true;
            this.BarometricPressureLabel.Location = new System.Drawing.Point(14, 216);
            this.BarometricPressureLabel.Name = "BarometricPressureLabel";
            this.BarometricPressureLabel.Size = new System.Drawing.Size(104, 13);
            this.BarometricPressureLabel.TabIndex = 6;
            this.BarometricPressureLabel.Text = "Barometric Pressure:";
            // 
            // LiquidToGasRatioLabel
            // 
            this.LiquidToGasRatioLabel.AutoSize = true;
            this.LiquidToGasRatioLabel.Location = new System.Drawing.Point(16, 243);
            this.LiquidToGasRatioLabel.Name = "LiquidToGasRatioLabel";
            this.LiquidToGasRatioLabel.Size = new System.Drawing.Size(104, 13);
            this.LiquidToGasRatioLabel.TabIndex = 7;
            this.LiquidToGasRatioLabel.Text = "Liquid To Gas Ratio:";
            // 
            // UnitsDryBulbTemperature
            // 
            this.UnitsDryBulbTemperature.AutoSize = true;
            this.UnitsDryBulbTemperature.Location = new System.Drawing.Point(268, 164);
            this.UnitsDryBulbTemperature.Name = "UnitsDryBulbTemperature";
            this.UnitsDryBulbTemperature.Size = new System.Drawing.Size(17, 13);
            this.UnitsDryBulbTemperature.TabIndex = 15;
            this.UnitsDryBulbTemperature.Text = "°F";
            // 
            // UnitsBarometricPressure
            // 
            this.UnitsBarometricPressure.AutoSize = true;
            this.UnitsBarometricPressure.Location = new System.Drawing.Point(267, 216);
            this.UnitsBarometricPressure.Name = "UnitsBarometricPressure";
            this.UnitsBarometricPressure.Size = new System.Drawing.Size(26, 13);
            this.UnitsBarometricPressure.TabIndex = 17;
            this.UnitsBarometricPressure.Text = "\"Hg";
            // 
            // UnitsFanDriverPower
            // 
            this.UnitsFanDriverPower.AutoSize = true;
            this.UnitsFanDriverPower.Location = new System.Drawing.Point(268, 190);
            this.UnitsFanDriverPower.Name = "UnitsFanDriverPower";
            this.UnitsFanDriverPower.Size = new System.Drawing.Size(25, 13);
            this.UnitsFanDriverPower.TabIndex = 14;
            this.UnitsFanDriverPower.Text = "bhp";
            // 
            // UnitsLiquidToGasRatio
            // 
            this.UnitsLiquidToGasRatio.AutoSize = true;
            this.UnitsLiquidToGasRatio.Location = new System.Drawing.Point(902, 668);
            this.UnitsLiquidToGasRatio.Name = "UnitsLiquidToGasRatio";
            this.UnitsLiquidToGasRatio.Size = new System.Drawing.Size(0, 13);
            this.UnitsLiquidToGasRatio.TabIndex = 18;
            // 
            // DesignDataButton
            // 
            this.DesignDataButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DesignDataButton.Location = new System.Drawing.Point(710, 75);
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
            this.TowerTypeLabel.Location = new System.Drawing.Point(14, 124);
            this.TowerTypeLabel.Name = "TowerTypeLabel";
            this.TowerTypeLabel.Size = new System.Drawing.Size(67, 13);
            this.TowerTypeLabel.TabIndex = 17;
            this.TowerTypeLabel.Text = "Tower Type:";
            // 
            // OwnerNameField
            // 
            this.OwnerNameField.Location = new System.Drawing.Point(134, 17);
            this.OwnerNameField.Name = "OwnerNameField";
            this.OwnerNameField.ReadOnly = true;
            this.OwnerNameField.Size = new System.Drawing.Size(541, 20);
            this.OwnerNameField.TabIndex = 19;
            // 
            // ProjectNameField
            // 
            this.ProjectNameField.Location = new System.Drawing.Point(134, 43);
            this.ProjectNameField.Name = "ProjectNameField";
            this.ProjectNameField.ReadOnly = true;
            this.ProjectNameField.Size = new System.Drawing.Size(541, 20);
            this.ProjectNameField.TabIndex = 20;
            // 
            // LocationField
            // 
            this.LocationField.Location = new System.Drawing.Point(134, 69);
            this.LocationField.Name = "LocationField";
            this.LocationField.ReadOnly = true;
            this.LocationField.Size = new System.Drawing.Size(541, 20);
            this.LocationField.TabIndex = 21;
            // 
            // TowerManufacturerField
            // 
            this.TowerManufacturerField.Location = new System.Drawing.Point(134, 95);
            this.TowerManufacturerField.Name = "TowerManufacturerField";
            this.TowerManufacturerField.ReadOnly = true;
            this.TowerManufacturerField.Size = new System.Drawing.Size(541, 20);
            this.TowerManufacturerField.TabIndex = 22;
            // 
            // TowerTypeField
            // 
            this.TowerTypeField.Location = new System.Drawing.Point(134, 121);
            this.TowerTypeField.Name = "TowerTypeField";
            this.TowerTypeField.ReadOnly = true;
            this.TowerTypeField.Size = new System.Drawing.Size(70, 20);
            this.TowerTypeField.TabIndex = 23;
            // 
            // DataFilename
            // 
            this.DataFilename.Location = new System.Drawing.Point(137, 20);
            this.DataFilename.Name = "DataFilename";
            this.DataFilename.ReadOnly = true;
            this.DataFilename.Size = new System.Drawing.Size(541, 20);
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
            this.TowerDataGroupBox.Location = new System.Drawing.Point(3, 52);
            this.TowerDataGroupBox.Name = "TowerDataGroupBox";
            this.TowerDataGroupBox.Size = new System.Drawing.Size(685, 151);
            this.TowerDataGroupBox.TabIndex = 25;
            this.TowerDataGroupBox.TabStop = false;
            this.TowerDataGroupBox.Text = "Tower Data";
            // 
            // DataGridView
            // 
            this.DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Location = new System.Drawing.Point(3, 526);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.Size = new System.Drawing.Size(810, 129);
            this.DataGridView.TabIndex = 26;
            // 
            // MechanicalDraftPerformanceCurveTabPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DataGridView);
            this.Controls.Add(this.TowerDataGroupBox);
            this.Controls.Add(this.DataFilename);
            this.Controls.Add(this.DesignDataButton);
            this.Controls.Add(this.TestResultsGroupBox);
            this.Controls.Add(this.ViewGraph);
            this.Controls.Add(this.CalculateButton);
            this.Controls.Add(this.DataFileLabel);
            this.Controls.Add(this.UnitsLiquidToGasRatio);
            this.Name = "MechanicalDraftPerformanceCurveTabPage";
            this.Size = new System.Drawing.Size(819, 662);
            this.TestResultsGroupBox.ResumeLayout(false);
            this.TestResultsGroupBox.PerformLayout();
            this.TestPointTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.DesignGroupBox.ResumeLayout(false);
            this.DesignGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.TowerDataGroupBox.ResumeLayout(false);
            this.TowerDataGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DataFileLabel;
        private System.Windows.Forms.Button CalculateButton;
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
        private System.Windows.Forms.TabControl TestPointTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.Button AddTestPointButton;
        private System.Windows.Forms.TextBox AddTestPointName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
    }
}
