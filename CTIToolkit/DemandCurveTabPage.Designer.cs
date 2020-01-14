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
            this.DemandCurveDataFile_Value = new System.Windows.Forms.TextBox();
            this.DemandCurve_Range_Value = new System.Windows.Forms.TextBox();
            this.DemandCurve_Wet_Bulb_Value = new System.Windows.Forms.TextBox();
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
            this.DemandCurve_LG_Value = new System.Windows.Forms.TextBox();
            this.DemandCurve_ApproachRadio = new System.Windows.Forms.RadioButton();
            this.LGlabel = new System.Windows.Forms.Label();
            this.TowerOrFillCharacteristicsGroupBox = new System.Windows.Forms.GroupBox();
            this.DemandCurve_Maximum_Value = new System.Windows.Forms.NumericUpDown();
            this.DemandCurve_Minimum_Value = new System.Windows.Forms.NumericUpDown();
            this.Max_label = new System.Windows.Forms.Label();
            this.Min_Label = new System.Windows.Forms.Label();
            this.DemandCurve_Slope_C2_Value = new System.Windows.Forms.TextBox();
            this.Slopelabel = new System.Windows.Forms.Label();
            this.DemandCurve_C_C1_Value = new System.Windows.Forms.TextBox();
            this.Clabel = new System.Windows.Forms.Label();
            this.ThermalDesignConditionsGroupBox = new System.Windows.Forms.GroupBox();
            this.DemandCurve_Elevation_Pressure_Selector = new System.Windows.Forms.ComboBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBoxPressureElevation = new System.Windows.Forms.GroupBox();
            this.DemandCurve_PressureRadio = new System.Windows.Forms.RadioButton();
            this.DemandCurve_ElevationRadio = new System.Windows.Forms.RadioButton();
            this.InputPropertiesGroupBox.SuspendLayout();
            this.DesignPointGroupBox.SuspendLayout();
            this.TowerOrFillCharacteristicsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DemandCurve_Maximum_Value)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DemandCurve_Minimum_Value)).BeginInit();
            this.ThermalDesignConditionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBoxPressureElevation.SuspendLayout();
            this.SuspendLayout();
            // 
            // DemandCurveCalculate
            // 
            this.DemandCurveCalculate.Location = new System.Drawing.Point(652, 29);
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
            // 
            // DemandCurve_Wet_Bulb_Value
            // 
            this.DemandCurve_Wet_Bulb_Value.Location = new System.Drawing.Point(134, 25);
            this.DemandCurve_Wet_Bulb_Value.Name = "DemandCurve_Wet_Bulb_Value";
            this.DemandCurve_Wet_Bulb_Value.Size = new System.Drawing.Size(56, 20);
            this.DemandCurve_Wet_Bulb_Value.TabIndex = 5;
            this.DemandCurve_Wet_Bulb_Value.Text = "80";
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
            this.DesignPointGroupBox.Controls.Add(this.DemandCurve_LG_Value);
            this.DesignPointGroupBox.Controls.Add(this.DemandCurve_ApproachRadio);
            this.DesignPointGroupBox.Controls.Add(this.LGlabel);
            this.DesignPointGroupBox.Location = new System.Drawing.Point(664, 79);
            this.DesignPointGroupBox.Name = "DesignPointGroupBox";
            this.DesignPointGroupBox.Size = new System.Drawing.Size(165, 91);
            this.DesignPointGroupBox.TabIndex = 22;
            this.DesignPointGroupBox.TabStop = false;
            this.DesignPointGroupBox.Text = "Design Point";
            // 
            // DemandCurve_KavLRadio
            // 
            this.DemandCurve_KavLRadio.Location = new System.Drawing.Point(17, 62);
            this.DemandCurve_KavLRadio.Name = "DemandCurve_KavLRadio";
            this.DemandCurve_KavLRadio.Size = new System.Drawing.Size(122, 17);
            this.DemandCurve_KavLRadio.TabIndex = 1;
            this.DemandCurve_KavLRadio.Text = "Kav/L";
            this.DemandCurve_KavLRadio.UseVisualStyleBackColor = true;
            // 
            // DemandCurve_LG_Value
            // 
            this.DemandCurve_LG_Value.Location = new System.Drawing.Point(58, 17);
            this.DemandCurve_LG_Value.Name = "DemandCurve_LG_Value";
            this.DemandCurve_LG_Value.Size = new System.Drawing.Size(100, 20);
            this.DemandCurve_LG_Value.TabIndex = 2;
            this.DemandCurve_LG_Value.Text = "1";
            // 
            // DemandCurve_ApproachRadio
            // 
            this.DemandCurve_ApproachRadio.Checked = true;
            this.DemandCurve_ApproachRadio.Location = new System.Drawing.Point(17, 41);
            this.DemandCurve_ApproachRadio.Name = "DemandCurve_ApproachRadio";
            this.DemandCurve_ApproachRadio.Size = new System.Drawing.Size(122, 17);
            this.DemandCurve_ApproachRadio.TabIndex = 0;
            this.DemandCurve_ApproachRadio.TabStop = true;
            this.DemandCurve_ApproachRadio.Text = "Approach";
            this.DemandCurve_ApproachRadio.UseVisualStyleBackColor = true;
            // 
            // LGlabel
            // 
            this.LGlabel.AutoSize = true;
            this.LGlabel.Location = new System.Drawing.Point(14, 20);
            this.LGlabel.Name = "LGlabel";
            this.LGlabel.Size = new System.Drawing.Size(29, 13);
            this.LGlabel.TabIndex = 0;
            this.LGlabel.Text = "L/G:";
            // 
            // TowerOrFillCharacteristicsGroupBox
            // 
            this.TowerOrFillCharacteristicsGroupBox.Controls.Add(this.DemandCurve_Maximum_Value);
            this.TowerOrFillCharacteristicsGroupBox.Controls.Add(this.DemandCurve_Minimum_Value);
            this.TowerOrFillCharacteristicsGroupBox.Controls.Add(this.Max_label);
            this.TowerOrFillCharacteristicsGroupBox.Controls.Add(this.Min_Label);
            this.TowerOrFillCharacteristicsGroupBox.Controls.Add(this.DemandCurve_Slope_C2_Value);
            this.TowerOrFillCharacteristicsGroupBox.Controls.Add(this.Slopelabel);
            this.TowerOrFillCharacteristicsGroupBox.Controls.Add(this.DemandCurve_C_C1_Value);
            this.TowerOrFillCharacteristicsGroupBox.Controls.Add(this.Clabel);
            this.TowerOrFillCharacteristicsGroupBox.Location = new System.Drawing.Point(403, 72);
            this.TowerOrFillCharacteristicsGroupBox.Name = "TowerOrFillCharacteristicsGroupBox";
            this.TowerOrFillCharacteristicsGroupBox.Size = new System.Drawing.Size(255, 98);
            this.TowerOrFillCharacteristicsGroupBox.TabIndex = 21;
            this.TowerOrFillCharacteristicsGroupBox.TabStop = false;
            this.TowerOrFillCharacteristicsGroupBox.Text = "Tower or Fill Characteristics";
            // 
            // DemandCurve_Maximum_Value
            // 
            this.DemandCurve_Maximum_Value.DecimalPlaces = 1;
            this.DemandCurve_Maximum_Value.Location = new System.Drawing.Point(186, 50);
            this.DemandCurve_Maximum_Value.Name = "DemandCurve_Maximum_Value";
            this.DemandCurve_Maximum_Value.Size = new System.Drawing.Size(53, 20);
            this.DemandCurve_Maximum_Value.TabIndex = 9;
            // 
            // DemandCurve_Minimum_Value
            // 
            this.DemandCurve_Minimum_Value.DecimalPlaces = 1;
            this.DemandCurve_Minimum_Value.Location = new System.Drawing.Point(186, 24);
            this.DemandCurve_Minimum_Value.Name = "DemandCurve_Minimum_Value";
            this.DemandCurve_Minimum_Value.Size = new System.Drawing.Size(53, 20);
            this.DemandCurve_Minimum_Value.TabIndex = 8;
            // 
            // Max_label
            // 
            this.Max_label.AutoSize = true;
            this.Max_label.Location = new System.Drawing.Point(129, 52);
            this.Max_label.Name = "Max_label";
            this.Max_label.Size = new System.Drawing.Size(54, 13);
            this.Max_label.TabIndex = 6;
            this.Max_label.Text = "Maximum:";
            // 
            // Min_Label
            // 
            this.Min_Label.AutoSize = true;
            this.Min_Label.Location = new System.Drawing.Point(129, 26);
            this.Min_Label.Name = "Min_Label";
            this.Min_Label.Size = new System.Drawing.Size(51, 13);
            this.Min_Label.TabIndex = 4;
            this.Min_Label.Text = "Minimum:";
            // 
            // DemandCurve_Slope_C2_Value
            // 
            this.DemandCurve_Slope_C2_Value.Location = new System.Drawing.Point(61, 50);
            this.DemandCurve_Slope_C2_Value.Name = "DemandCurve_Slope_C2_Value";
            this.DemandCurve_Slope_C2_Value.Size = new System.Drawing.Size(50, 20);
            this.DemandCurve_Slope_C2_Value.TabIndex = 3;
            this.DemandCurve_Slope_C2_Value.Text = "0";
            // 
            // Slopelabel
            // 
            this.Slopelabel.AutoSize = true;
            this.Slopelabel.Location = new System.Drawing.Point(13, 52);
            this.Slopelabel.Name = "Slopelabel";
            this.Slopelabel.Size = new System.Drawing.Size(37, 13);
            this.Slopelabel.TabIndex = 2;
            this.Slopelabel.Text = "Slope:";
            // 
            // DemandCurve_C_C1_Value
            // 
            this.DemandCurve_C_C1_Value.Location = new System.Drawing.Point(60, 23);
            this.DemandCurve_C_C1_Value.Name = "DemandCurve_C_C1_Value";
            this.DemandCurve_C_C1_Value.Size = new System.Drawing.Size(50, 20);
            this.DemandCurve_C_C1_Value.TabIndex = 1;
            this.DemandCurve_C_C1_Value.Text = "0";
            // 
            // Clabel
            // 
            this.Clabel.AutoSize = true;
            this.Clabel.Location = new System.Drawing.Point(13, 26);
            this.Clabel.Name = "Clabel";
            this.Clabel.Size = new System.Drawing.Size(17, 13);
            this.Clabel.TabIndex = 0;
            this.Clabel.Text = "C:";
            // 
            // ThermalDesignConditionsGroupBox
            // 
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.groupBoxPressureElevation);
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.DemandCurve_Elevation_Pressure_Selector);
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.DemandCurveWetBulbTemperatureLabel);
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.RangeLabel);
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.DemandCurve_Range_Value);
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.DemandCurveTemperatureWebBulbUnits);
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.DemandCurve_Wet_Bulb_Value);
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
            // DemandCurve_Elevation_Pressure_Selector
            // 
            this.DemandCurve_Elevation_Pressure_Selector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DemandCurve_Elevation_Pressure_Selector.FormattingEnabled = true;
            this.DemandCurve_Elevation_Pressure_Selector.Items.AddRange(new object[] {
            "Elevation",
            "Barometric Pressure"});
            this.DemandCurve_Elevation_Pressure_Selector.Location = new System.Drawing.Point(6, 74);
            this.DemandCurve_Elevation_Pressure_Selector.Name = "DemandCurve_Elevation_Pressure_Selector";
            this.DemandCurve_Elevation_Pressure_Selector.Size = new System.Drawing.Size(119, 21);
            this.DemandCurve_Elevation_Pressure_Selector.TabIndex = 20;
            this.DemandCurve_Elevation_Pressure_Selector.SelectedIndexChanged += new System.EventHandler(this.DemandCurve_Elevation_Pressure_Selector_SelectedIndexChanged);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(9, 222);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(896, 579);
            this.chart1.TabIndex = 12;
            this.chart1.Text = "DemandCurveChart";
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
            // 
            // DemandCurveTabPage
            // 
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.InputPropertiesGroupBox);
            this.Name = "DemandCurveTabPage";
            this.Size = new System.Drawing.Size(920, 824);
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
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBoxPressureElevation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button DemandCurveCalculate;
        private System.Windows.Forms.Label DemandCurveDataFileLabel;
        private System.Windows.Forms.Label RangeLabel;
        private System.Windows.Forms.TextBox DemandCurveDataFile_Value;
        private System.Windows.Forms.TextBox DemandCurve_Range_Value;
        private System.Windows.Forms.TextBox DemandCurve_Wet_Bulb_Value;
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
        private System.Windows.Forms.Label LGlabel;
        private System.Windows.Forms.TextBox DemandCurve_Slope_C2_Value;
        private System.Windows.Forms.Label Slopelabel;
        private System.Windows.Forms.TextBox DemandCurve_C_C1_Value;
        private System.Windows.Forms.Label Clabel;
        private System.Windows.Forms.TextBox DemandCurve_LG_Value;
        private System.Windows.Forms.Label Max_label;
        private System.Windows.Forms.Label Min_Label;
        private System.Windows.Forms.NumericUpDown DemandCurve_Maximum_Value;
        private System.Windows.Forms.NumericUpDown DemandCurve_Minimum_Value;
        private System.Windows.Forms.RadioButton DemandCurve_KavLRadio;
        private System.Windows.Forms.RadioButton DemandCurve_ApproachRadio;
        private System.Windows.Forms.ComboBox DemandCurve_Elevation_Pressure_Selector;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox groupBoxPressureElevation;
        private System.Windows.Forms.RadioButton DemandCurve_PressureRadio;
        private System.Windows.Forms.RadioButton DemandCurve_ElevationRadio;
    }
}
