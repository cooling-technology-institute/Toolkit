namespace CTICustomControls
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.DemandCurveCalculate = new System.Windows.Forms.Button();
            this.DemandCurveDataFileLabel = new System.Windows.Forms.Label();
            this.RangeLabel = new System.Windows.Forms.Label();
            this.DemandCurveDataFile_Value = new System.Windows.Forms.TextBox();
            this.DemandCurve_CWT_Value = new System.Windows.Forms.TextBox();
            this.DemandCurve_Wet_Bulb_Value = new System.Windows.Forms.TextBox();
            this.DemandCurveTemperatureColdWaterUnits = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DemandCurvePressureRadio = new System.Windows.Forms.RadioButton();
            this.DemandCurveElevationRadio = new System.Windows.Forms.RadioButton();
            this.DemandCurveWetBulbTemperatureLabel = new System.Windows.Forms.Label();
            this.DemandCurve_Elevation_Value = new System.Windows.Forms.TextBox();
            this.DemandCurveElevationPressureUnits = new System.Windows.Forms.Label();
            this.DemandCurveElevationPressureLabel = new System.Windows.Forms.Label();
            this.DemandCurveTemperatureWebBulbUnits = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.SaveButton = new System.Windows.Forms.Button();
            this.InputPropertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.ThermalDesignConditionsGroupBox = new System.Windows.Forms.GroupBox();
            this.TowerOrFillCharacteristicsGroupBox = new System.Windows.Forms.GroupBox();
            this.Clabel = new System.Windows.Forms.Label();
            this.C_Value = new System.Windows.Forms.TextBox();
            this.Slopelabel = new System.Windows.Forms.Label();
            this.Slope_Value = new System.Windows.Forms.TextBox();
            this.DesignPointGroupBox = new System.Windows.Forms.GroupBox();
            this.LGlabel = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.InputPropertiesGroupBox.SuspendLayout();
            this.ThermalDesignConditionsGroupBox.SuspendLayout();
            this.TowerOrFillCharacteristicsGroupBox.SuspendLayout();
            this.DesignPointGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // DemandCurveCalculate
            // 
            this.DemandCurveCalculate.Location = new System.Drawing.Point(24, 451);
            this.DemandCurveCalculate.Name = "DemandCurveCalculate";
            this.DemandCurveCalculate.Size = new System.Drawing.Size(75, 23);
            this.DemandCurveCalculate.TabIndex = 15;
            this.DemandCurveCalculate.Text = "Calculate";
            this.DemandCurveCalculate.UseVisualStyleBackColor = true;
            this.DemandCurveCalculate.Click += new System.EventHandler(this.DemandCurveCalculate_Click);
            // 
            // DemandCurveDataFileLabel
            // 
            this.DemandCurveDataFileLabel.Location = new System.Drawing.Point(12, 39);
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
            this.RangeLabel.Text = "Range";
            this.RangeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DemandCurveDataFile_Value
            // 
            this.DemandCurveDataFile_Value.Location = new System.Drawing.Point(152, 36);
            this.DemandCurveDataFile_Value.Name = "DemandCurveDataFile_Value";
            this.DemandCurveDataFile_Value.Size = new System.Drawing.Size(385, 20);
            this.DemandCurveDataFile_Value.TabIndex = 3;
            // 
            // DemandCurve_CWT_Value
            // 
            this.DemandCurve_CWT_Value.Location = new System.Drawing.Point(133, 48);
            this.DemandCurve_CWT_Value.Name = "DemandCurve_CWT_Value";
            this.DemandCurve_CWT_Value.Size = new System.Drawing.Size(100, 20);
            this.DemandCurve_CWT_Value.TabIndex = 4;
            this.DemandCurve_CWT_Value.Text = "90";
            // 
            // DemandCurve_Wet_Bulb_Value
            // 
            this.DemandCurve_Wet_Bulb_Value.Location = new System.Drawing.Point(133, 22);
            this.DemandCurve_Wet_Bulb_Value.Name = "DemandCurve_Wet_Bulb_Value";
            this.DemandCurve_Wet_Bulb_Value.Size = new System.Drawing.Size(100, 20);
            this.DemandCurve_Wet_Bulb_Value.TabIndex = 5;
            this.DemandCurve_Wet_Bulb_Value.Text = "0";
            // 
            // DemandCurveTemperatureColdWaterUnits
            // 
            this.DemandCurveTemperatureColdWaterUnits.AutoSize = true;
            this.DemandCurveTemperatureColdWaterUnits.Location = new System.Drawing.Point(240, 51);
            this.DemandCurveTemperatureColdWaterUnits.Name = "DemandCurveTemperatureColdWaterUnits";
            this.DemandCurveTemperatureColdWaterUnits.Size = new System.Drawing.Size(17, 13);
            this.DemandCurveTemperatureColdWaterUnits.TabIndex = 7;
            this.DemandCurveTemperatureColdWaterUnits.Text = "°F";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.DemandCurvePressureRadio);
            this.groupBox2.Controls.Add(this.DemandCurveElevationRadio);
            this.groupBox2.Location = new System.Drawing.Point(562, 238);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(164, 79);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // DemandCurvePressureRadio
            // 
            this.DemandCurvePressureRadio.Location = new System.Drawing.Point(17, 50);
            this.DemandCurvePressureRadio.Name = "DemandCurvePressureRadio";
            this.DemandCurvePressureRadio.Size = new System.Drawing.Size(130, 17);
            this.DemandCurvePressureRadio.TabIndex = 1;
            this.DemandCurvePressureRadio.Text = "Barometric Pressure";
            this.DemandCurvePressureRadio.UseVisualStyleBackColor = true;
            this.DemandCurvePressureRadio.CheckedChanged += new System.EventHandler(this.DemandCurvePressureRadio_CheckedChanged);
            // 
            // DemandCurveElevationRadio
            // 
            this.DemandCurveElevationRadio.Checked = true;
            this.DemandCurveElevationRadio.Location = new System.Drawing.Point(17, 21);
            this.DemandCurveElevationRadio.Name = "DemandCurveElevationRadio";
            this.DemandCurveElevationRadio.Size = new System.Drawing.Size(130, 17);
            this.DemandCurveElevationRadio.TabIndex = 0;
            this.DemandCurveElevationRadio.TabStop = true;
            this.DemandCurveElevationRadio.Text = "Elevation";
            this.DemandCurveElevationRadio.UseVisualStyleBackColor = true;
            this.DemandCurveElevationRadio.CheckedChanged += new System.EventHandler(this.DemandCurveElevationRadio_CheckedChanged);
            // 
            // DemandCurveWetBulbTemperatureLabel
            // 
            this.DemandCurveWetBulbTemperatureLabel.Location = new System.Drawing.Point(6, 25);
            this.DemandCurveWetBulbTemperatureLabel.Name = "DemandCurveWetBulbTemperatureLabel";
            this.DemandCurveWetBulbTemperatureLabel.Size = new System.Drawing.Size(119, 13);
            this.DemandCurveWetBulbTemperatureLabel.TabIndex = 11;
            this.DemandCurveWetBulbTemperatureLabel.Text = "Wet Bulb Temperature:";
            this.DemandCurveWetBulbTemperatureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DemandCurve_Elevation_Value
            // 
            this.DemandCurve_Elevation_Value.Location = new System.Drawing.Point(133, 74);
            this.DemandCurve_Elevation_Value.Name = "DemandCurve_Elevation_Value";
            this.DemandCurve_Elevation_Value.Size = new System.Drawing.Size(100, 20);
            this.DemandCurve_Elevation_Value.TabIndex = 15;
            this.DemandCurve_Elevation_Value.Text = "0";
            // 
            // DemandCurveElevationPressureUnits
            // 
            this.DemandCurveElevationPressureUnits.AutoSize = true;
            this.DemandCurveElevationPressureUnits.Location = new System.Drawing.Point(240, 77);
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
            this.DemandCurveTemperatureWebBulbUnits.Location = new System.Drawing.Point(240, 25);
            this.DemandCurveTemperatureWebBulbUnits.Name = "DemandCurveTemperatureWebBulbUnits";
            this.DemandCurveTemperatureWebBulbUnits.Size = new System.Drawing.Size(17, 13);
            this.DemandCurveTemperatureWebBulbUnits.TabIndex = 18;
            this.DemandCurveTemperatureWebBulbUnits.Text = "°F";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Location = new System.Drawing.Point(278, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(164, 79);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(17, 50);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(130, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.Text = "Barometric Pressure";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(17, 21);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(130, 17);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Elevation";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(651, 34);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 16;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // InputPropertiesGroupBox
            // 
            this.InputPropertiesGroupBox.Controls.Add(this.DesignPointGroupBox);
            this.InputPropertiesGroupBox.Controls.Add(this.TowerOrFillCharacteristicsGroupBox);
            this.InputPropertiesGroupBox.Controls.Add(this.ThermalDesignConditionsGroupBox);
            this.InputPropertiesGroupBox.Controls.Add(this.SaveButton);
            this.InputPropertiesGroupBox.Controls.Add(this.groupBox2);
            this.InputPropertiesGroupBox.Controls.Add(this.DemandCurveDataFile_Value);
            this.InputPropertiesGroupBox.Controls.Add(this.DemandCurveDataFileLabel);
            this.InputPropertiesGroupBox.Location = new System.Drawing.Point(9, 10);
            this.InputPropertiesGroupBox.Name = "InputPropertiesGroupBox";
            this.InputPropertiesGroupBox.Size = new System.Drawing.Size(743, 435);
            this.InputPropertiesGroupBox.TabIndex = 11;
            this.InputPropertiesGroupBox.TabStop = false;
            this.InputPropertiesGroupBox.Text = "Input Properties";
            // 
            // ThermalDesignConditionsGroupBox
            // 
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.DemandCurveWetBulbTemperatureLabel);
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.RangeLabel);
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.groupBox3);
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.DemandCurve_CWT_Value);
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.DemandCurveTemperatureWebBulbUnits);
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.DemandCurve_Wet_Bulb_Value);
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.DemandCurveElevationPressureLabel);
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.DemandCurveTemperatureColdWaterUnits);
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.DemandCurveElevationPressureUnits);
            this.ThermalDesignConditionsGroupBox.Controls.Add(this.DemandCurve_Elevation_Value);
            this.ThermalDesignConditionsGroupBox.Location = new System.Drawing.Point(24, 64);
            this.ThermalDesignConditionsGroupBox.Name = "ThermalDesignConditionsGroupBox";
            this.ThermalDesignConditionsGroupBox.Size = new System.Drawing.Size(513, 106);
            this.ThermalDesignConditionsGroupBox.TabIndex = 20;
            this.ThermalDesignConditionsGroupBox.TabStop = false;
            this.ThermalDesignConditionsGroupBox.Text = "Thermal Design Conditions";
            // 
            // TowerOrFillCharacteristicsGroupBox
            // 
            this.TowerOrFillCharacteristicsGroupBox.Controls.Add(this.Slope_Value);
            this.TowerOrFillCharacteristicsGroupBox.Controls.Add(this.Slopelabel);
            this.TowerOrFillCharacteristicsGroupBox.Controls.Add(this.C_Value);
            this.TowerOrFillCharacteristicsGroupBox.Controls.Add(this.Clabel);
            this.TowerOrFillCharacteristicsGroupBox.Location = new System.Drawing.Point(24, 192);
            this.TowerOrFillCharacteristicsGroupBox.Name = "TowerOrFillCharacteristicsGroupBox";
            this.TowerOrFillCharacteristicsGroupBox.Size = new System.Drawing.Size(513, 100);
            this.TowerOrFillCharacteristicsGroupBox.TabIndex = 21;
            this.TowerOrFillCharacteristicsGroupBox.TabStop = false;
            this.TowerOrFillCharacteristicsGroupBox.Text = "Tower orFill Characteristics";
            // 
            // Clabel
            // 
            this.Clabel.AutoSize = true;
            this.Clabel.Location = new System.Drawing.Point(12, 20);
            this.Clabel.Name = "Clabel";
            this.Clabel.Size = new System.Drawing.Size(17, 13);
            this.Clabel.TabIndex = 0;
            this.Clabel.Text = "C:";
            // 
            // C_Value
            // 
            this.C_Value.Location = new System.Drawing.Point(59, 17);
            this.C_Value.Name = "C_Value";
            this.C_Value.Size = new System.Drawing.Size(100, 20);
            this.C_Value.TabIndex = 1;
            // 
            // Slopelabel
            // 
            this.Slopelabel.AutoSize = true;
            this.Slopelabel.Location = new System.Drawing.Point(12, 46);
            this.Slopelabel.Name = "Slopelabel";
            this.Slopelabel.Size = new System.Drawing.Size(37, 13);
            this.Slopelabel.TabIndex = 2;
            this.Slopelabel.Text = "Slope:";
            // 
            // Slope_Value
            // 
            this.Slope_Value.Location = new System.Drawing.Point(60, 44);
            this.Slope_Value.Name = "Slope_Value";
            this.Slope_Value.Size = new System.Drawing.Size(100, 20);
            this.Slope_Value.TabIndex = 3;
            // 
            // DesignPointGroupBox
            // 
            this.DesignPointGroupBox.Controls.Add(this.LGlabel);
            this.DesignPointGroupBox.Location = new System.Drawing.Point(24, 319);
            this.DesignPointGroupBox.Name = "DesignPointGroupBox";
            this.DesignPointGroupBox.Size = new System.Drawing.Size(513, 100);
            this.DesignPointGroupBox.TabIndex = 22;
            this.DesignPointGroupBox.TabStop = false;
            this.DesignPointGroupBox.Text = "Design Point";
            // 
            // LGlabel
            // 
            this.LGlabel.AutoSize = true;
            this.LGlabel.Location = new System.Drawing.Point(15, 20);
            this.LGlabel.Name = "LGlabel";
            this.LGlabel.Size = new System.Drawing.Size(29, 13);
            this.LGlabel.TabIndex = 0;
            this.LGlabel.Text = "L/G:";
            // 
            // DemandCurveTabPage
            // 
            this.Controls.Add(this.DemandCurveCalculate);
            this.Controls.Add(this.InputPropertiesGroupBox);
            this.Name = "DemandCurveTabPage";
            this.Size = new System.Drawing.Size(767, 622);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.InputPropertiesGroupBox.ResumeLayout(false);
            this.InputPropertiesGroupBox.PerformLayout();
            this.ThermalDesignConditionsGroupBox.ResumeLayout(false);
            this.ThermalDesignConditionsGroupBox.PerformLayout();
            this.TowerOrFillCharacteristicsGroupBox.ResumeLayout(false);
            this.TowerOrFillCharacteristicsGroupBox.PerformLayout();
            this.DesignPointGroupBox.ResumeLayout(false);
            this.DesignPointGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button DemandCurveCalculate;
        private System.Windows.Forms.Label DemandCurveDataFileLabel;
        private System.Windows.Forms.Label RangeLabel;
        private System.Windows.Forms.TextBox DemandCurveDataFile_Value;
        private System.Windows.Forms.TextBox DemandCurve_CWT_Value;
        private System.Windows.Forms.TextBox DemandCurve_Wet_Bulb_Value;
        private System.Windows.Forms.Label DemandCurveTemperatureColdWaterUnits;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton DemandCurvePressureRadio;
        private System.Windows.Forms.RadioButton DemandCurveElevationRadio;
        private System.Windows.Forms.Label DemandCurveWetBulbTemperatureLabel;
        private System.Windows.Forms.TextBox DemandCurve_Elevation_Value;
        private System.Windows.Forms.Label DemandCurveElevationPressureUnits;
        private System.Windows.Forms.Label DemandCurveElevationPressureLabel;
        private System.Windows.Forms.Label DemandCurveTemperatureWebBulbUnits;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.GroupBox InputPropertiesGroupBox;
        private System.Windows.Forms.GroupBox ThermalDesignConditionsGroupBox;
        private System.Windows.Forms.GroupBox TowerOrFillCharacteristicsGroupBox;
        private System.Windows.Forms.GroupBox DesignPointGroupBox;
        private System.Windows.Forms.Label LGlabel;
        private System.Windows.Forms.TextBox Slope_Value;
        private System.Windows.Forms.Label Slopelabel;
        private System.Windows.Forms.TextBox C_Value;
        private System.Windows.Forms.Label Clabel;
    }
}
