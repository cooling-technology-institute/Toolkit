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
            this.Psychrometrics_GridView = new System.Windows.Forms.DataGridView();
            this.PsychrometricPropertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.Psychrometrics_Enthalpy = new System.Windows.Forms.RadioButton();
            this.Psychrometrics_DBT_RH = new System.Windows.Forms.RadioButton();
            this.Psychrometrics_WBT_DBT = new System.Windows.Forms.RadioButton();
            this.PsychrometricsCalculate = new System.Windows.Forms.Button();
            this.InputPropertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.PsychrometricsElevationPressureLabel1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PyschmetricsPressureRadio = new System.Windows.Forms.RadioButton();
            this.PyschmetricsElevationRadio = new System.Windows.Forms.RadioButton();
            this.PsychrometricsElevationPressureLabel2 = new System.Windows.Forms.Label();
            this.PsychrometricsTemperatureDryBlubUnits = new System.Windows.Forms.Label();
            this.PsychrometricsTemperatureWetBlubUnits = new System.Windows.Forms.Label();
            this.Psychrometrics_Elevation_Value = new System.Windows.Forms.TextBox();
            this.Psychrometrics_DBT_Value = new System.Windows.Forms.TextBox();
            this.Psychrometrics_WBT_Value = new System.Windows.Forms.TextBox();
            this.TemperatureDryBlubLabel = new System.Windows.Forms.Label();
            this.TemperatureWetBlubLabel = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Psychrometrics_GridView)).BeginInit();
            this.PsychrometricPropertiesGroupBox.SuspendLayout();
            this.InputPropertiesGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Psychrometrics_GridView
            // 
            this.Psychrometrics_GridView.AllowUserToAddRows = false;
            this.Psychrometrics_GridView.AllowUserToDeleteRows = false;
            this.Psychrometrics_GridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Psychrometrics_GridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.Psychrometrics_GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Psychrometrics_GridView.Location = new System.Drawing.Point(10, 317);
            this.Psychrometrics_GridView.Name = "Psychrometrics_GridView";
            this.Psychrometrics_GridView.ReadOnly = true;
            this.Psychrometrics_GridView.Size = new System.Drawing.Size(742, 294);
            this.Psychrometrics_GridView.TabIndex = 13;
            // 
            // PsychrometricPropertiesGroupBox
            // 
            this.PsychrometricPropertiesGroupBox.Controls.Add(this.Psychrometrics_Enthalpy);
            this.PsychrometricPropertiesGroupBox.Controls.Add(this.Psychrometrics_DBT_RH);
            this.PsychrometricPropertiesGroupBox.Controls.Add(this.Psychrometrics_WBT_DBT);
            this.PsychrometricPropertiesGroupBox.Controls.Add(this.PsychrometricsCalculate);
            this.PsychrometricPropertiesGroupBox.Location = new System.Drawing.Point(10, 155);
            this.PsychrometricPropertiesGroupBox.Name = "PsychrometricPropertiesGroupBox";
            this.PsychrometricPropertiesGroupBox.Size = new System.Drawing.Size(742, 145);
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
            // Psychrometrics_DBT_RH
            // 
            this.Psychrometrics_DBT_RH.AutoSize = true;
            this.Psychrometrics_DBT_RH.Location = new System.Drawing.Point(17, 65);
            this.Psychrometrics_DBT_RH.Name = "Psychrometrics_DBT_RH";
            this.Psychrometrics_DBT_RH.Size = new System.Drawing.Size(234, 17);
            this.Psychrometrics_DBT_RH.TabIndex = 1;
            this.Psychrometrics_DBT_RH.Text = "Dry Bulb Temperature and Relative Humidity";
            this.Psychrometrics_DBT_RH.UseVisualStyleBackColor = true;
            this.Psychrometrics_DBT_RH.CheckedChanged += new System.EventHandler(this.Psychrometrics_DBT_RH_CheckedChanged);
            // 
            // Psychrometrics_WBT_DBT
            // 
            this.Psychrometrics_WBT_DBT.AutoSize = true;
            this.Psychrometrics_WBT_DBT.Checked = true;
            this.Psychrometrics_WBT_DBT.Location = new System.Drawing.Point(17, 33);
            this.Psychrometrics_WBT_DBT.Name = "Psychrometrics_WBT_DBT";
            this.Psychrometrics_WBT_DBT.Size = new System.Drawing.Size(259, 17);
            this.Psychrometrics_WBT_DBT.TabIndex = 0;
            this.Psychrometrics_WBT_DBT.TabStop = true;
            this.Psychrometrics_WBT_DBT.Text = "Wet Bulb Temperature and Dry Bulb Temperature";
            this.Psychrometrics_WBT_DBT.UseVisualStyleBackColor = true;
            this.Psychrometrics_WBT_DBT.CheckedChanged += new System.EventHandler(this.Psychrometrics_WBT_DBT_CheckedChanged);
            // 
            // PsychrometricsCalculate
            // 
            this.PsychrometricsCalculate.Location = new System.Drawing.Point(648, 19);
            this.PsychrometricsCalculate.Name = "PsychrometricsCalculate";
            this.PsychrometricsCalculate.Size = new System.Drawing.Size(75, 23);
            this.PsychrometricsCalculate.TabIndex = 0;
            this.PsychrometricsCalculate.Text = "Calculate";
            this.PsychrometricsCalculate.UseVisualStyleBackColor = true;
            this.PsychrometricsCalculate.Click += new System.EventHandler(this.PsychrometricsCalculate_Click);
            // 
            // InputPropertiesGroupBox
            // 
            this.InputPropertiesGroupBox.Controls.Add(this.PsychrometricsElevationPressureLabel1);
            this.InputPropertiesGroupBox.Controls.Add(this.groupBox2);
            this.InputPropertiesGroupBox.Controls.Add(this.PsychrometricsElevationPressureLabel2);
            this.InputPropertiesGroupBox.Controls.Add(this.PsychrometricsTemperatureDryBlubUnits);
            this.InputPropertiesGroupBox.Controls.Add(this.PsychrometricsTemperatureWetBlubUnits);
            this.InputPropertiesGroupBox.Controls.Add(this.Psychrometrics_Elevation_Value);
            this.InputPropertiesGroupBox.Controls.Add(this.Psychrometrics_DBT_Value);
            this.InputPropertiesGroupBox.Controls.Add(this.Psychrometrics_WBT_Value);
            this.InputPropertiesGroupBox.Controls.Add(this.TemperatureDryBlubLabel);
            this.InputPropertiesGroupBox.Controls.Add(this.TemperatureWetBlubLabel);
            this.InputPropertiesGroupBox.Location = new System.Drawing.Point(9, 10);
            this.InputPropertiesGroupBox.Name = "InputPropertiesGroupBox";
            this.InputPropertiesGroupBox.Size = new System.Drawing.Size(743, 130);
            this.InputPropertiesGroupBox.TabIndex = 11;
            this.InputPropertiesGroupBox.TabStop = false;
            this.InputPropertiesGroupBox.Text = "Input Properties";
            // 
            // PsychrometricsElevationPressureLabel1
            // 
            this.PsychrometricsElevationPressureLabel1.Location = new System.Drawing.Point(22, 91);
            this.PsychrometricsElevationPressureLabel1.Name = "PsychrometricsElevationPressureLabel1";
            this.PsychrometricsElevationPressureLabel1.Size = new System.Drawing.Size(110, 13);
            this.PsychrometricsElevationPressureLabel1.TabIndex = 11;
            this.PsychrometricsElevationPressureLabel1.Text = "Elevation:";
            this.PsychrometricsElevationPressureLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.PyschmetricsPressureRadio);
            this.groupBox2.Controls.Add(this.PyschmetricsElevationRadio);
            this.groupBox2.Location = new System.Drawing.Point(318, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(164, 79);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // PyschmetricsPressureRadio
            // 
            this.PyschmetricsPressureRadio.Location = new System.Drawing.Point(17, 50);
            this.PyschmetricsPressureRadio.Name = "PyschmetricsPressureRadio";
            this.PyschmetricsPressureRadio.Size = new System.Drawing.Size(130, 17);
            this.PyschmetricsPressureRadio.TabIndex = 1;
            this.PyschmetricsPressureRadio.Text = "Barometric Pressure";
            this.PyschmetricsPressureRadio.UseVisualStyleBackColor = true;
            this.PyschmetricsPressureRadio.CheckedChanged += new System.EventHandler(this.PyschmetricsPressureRadio_CheckedChanged);
            // 
            // PyschmetricsElevationRadio
            // 
            this.PyschmetricsElevationRadio.Checked = true;
            this.PyschmetricsElevationRadio.Location = new System.Drawing.Point(17, 21);
            this.PyschmetricsElevationRadio.Name = "PyschmetricsElevationRadio";
            this.PyschmetricsElevationRadio.Size = new System.Drawing.Size(130, 17);
            this.PyschmetricsElevationRadio.TabIndex = 0;
            this.PyschmetricsElevationRadio.TabStop = true;
            this.PyschmetricsElevationRadio.Text = "Elevation";
            this.PyschmetricsElevationRadio.UseVisualStyleBackColor = true;
            this.PyschmetricsElevationRadio.CheckedChanged += new System.EventHandler(this.PyschmetricsElevationRadio_CheckedChanged);
            // 
            // PsychrometricsElevationPressureLabel2
            // 
            this.PsychrometricsElevationPressureLabel2.AutoSize = true;
            this.PsychrometricsElevationPressureLabel2.Location = new System.Drawing.Point(259, 91);
            this.PsychrometricsElevationPressureLabel2.Name = "PsychrometricsElevationPressureLabel2";
            this.PsychrometricsElevationPressureLabel2.Size = new System.Drawing.Size(13, 13);
            this.PsychrometricsElevationPressureLabel2.TabIndex = 8;
            this.PsychrometricsElevationPressureLabel2.Text = "ft";
            // 
            // PsychrometricsTemperatureDryBlubUnits
            // 
            this.PsychrometricsTemperatureDryBlubUnits.AutoSize = true;
            this.PsychrometricsTemperatureDryBlubUnits.Location = new System.Drawing.Point(259, 65);
            this.PsychrometricsTemperatureDryBlubUnits.Name = "PsychrometricsTemperatureDryBlubUnits";
            this.PsychrometricsTemperatureDryBlubUnits.Size = new System.Drawing.Size(17, 13);
            this.PsychrometricsTemperatureDryBlubUnits.TabIndex = 7;
            this.PsychrometricsTemperatureDryBlubUnits.Text = "°F";
            // 
            // PsychrometricsTemperatureWetBlubUnits
            // 
            this.PsychrometricsTemperatureWetBlubUnits.AutoSize = true;
            this.PsychrometricsTemperatureWetBlubUnits.Location = new System.Drawing.Point(259, 36);
            this.PsychrometricsTemperatureWetBlubUnits.Name = "PsychrometricsTemperatureWetBlubUnits";
            this.PsychrometricsTemperatureWetBlubUnits.Size = new System.Drawing.Size(17, 13);
            this.PsychrometricsTemperatureWetBlubUnits.TabIndex = 6;
            this.PsychrometricsTemperatureWetBlubUnits.Text = "°F";
            // 
            // Psychrometrics_Elevation_Value
            // 
            this.Psychrometrics_Elevation_Value.Location = new System.Drawing.Point(152, 88);
            this.Psychrometrics_Elevation_Value.Name = "Psychrometrics_Elevation_Value";
            this.Psychrometrics_Elevation_Value.Size = new System.Drawing.Size(100, 20);
            this.Psychrometrics_Elevation_Value.TabIndex = 5;
            this.Psychrometrics_Elevation_Value.Text = "0";
            // 
            // Psychrometrics_DBT_Value
            // 
            this.Psychrometrics_DBT_Value.Location = new System.Drawing.Point(152, 62);
            this.Psychrometrics_DBT_Value.Name = "Psychrometrics_DBT_Value";
            this.Psychrometrics_DBT_Value.Size = new System.Drawing.Size(100, 20);
            this.Psychrometrics_DBT_Value.TabIndex = 4;
            this.Psychrometrics_DBT_Value.Text = "90";
            // 
            // Psychrometrics_WBT_Value
            // 
            this.Psychrometrics_WBT_Value.Location = new System.Drawing.Point(152, 36);
            this.Psychrometrics_WBT_Value.Name = "Psychrometrics_WBT_Value";
            this.Psychrometrics_WBT_Value.Size = new System.Drawing.Size(100, 20);
            this.Psychrometrics_WBT_Value.TabIndex = 3;
            this.Psychrometrics_WBT_Value.Text = "80";
            // 
            // TemperatureDryBlubLabel
            // 
            this.TemperatureDryBlubLabel.Location = new System.Drawing.Point(19, 65);
            this.TemperatureDryBlubLabel.Name = "TemperatureDryBlubLabel";
            this.TemperatureDryBlubLabel.Size = new System.Drawing.Size(113, 13);
            this.TemperatureDryBlubLabel.TabIndex = 1;
            this.TemperatureDryBlubLabel.Text = "Dry Bulb Temperature:";
            this.TemperatureDryBlubLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TemperatureWetBlubLabel
            // 
            this.TemperatureWetBlubLabel.Location = new System.Drawing.Point(15, 39);
            this.TemperatureWetBlubLabel.Name = "TemperatureWetBlubLabel";
            this.TemperatureWetBlubLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TemperatureWetBlubLabel.Size = new System.Drawing.Size(117, 13);
            this.TemperatureWetBlubLabel.TabIndex = 0;
            this.TemperatureWetBlubLabel.Text = "Wet Bulb Temperature:";
            this.TemperatureWetBlubLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PsychrometricsTabPage
            // 
            this.Controls.Add(this.Psychrometrics_GridView);
            this.Controls.Add(this.PsychrometricPropertiesGroupBox);
            this.Controls.Add(this.InputPropertiesGroupBox);
            this.Name = "PsychrometricsTabPage";
            this.Size = new System.Drawing.Size(767, 622);
            ((System.ComponentModel.ISupportInitialize)(this.Psychrometrics_GridView)).EndInit();
            this.PsychrometricPropertiesGroupBox.ResumeLayout(false);
            this.PsychrometricPropertiesGroupBox.PerformLayout();
            this.InputPropertiesGroupBox.ResumeLayout(false);
            this.InputPropertiesGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView Psychrometrics_GridView;
        private System.Windows.Forms.GroupBox PsychrometricPropertiesGroupBox;
        private System.Windows.Forms.RadioButton Psychrometrics_Enthalpy;
        private System.Windows.Forms.RadioButton Psychrometrics_DBT_RH;
        private System.Windows.Forms.RadioButton Psychrometrics_WBT_DBT;
        private System.Windows.Forms.Button PsychrometricsCalculate;
        private System.Windows.Forms.GroupBox InputPropertiesGroupBox;
        private System.Windows.Forms.Label PsychrometricsElevationPressureLabel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton PyschmetricsPressureRadio;
        private System.Windows.Forms.RadioButton PyschmetricsElevationRadio;
        private System.Windows.Forms.Label PsychrometricsElevationPressureLabel2;
        private System.Windows.Forms.Label PsychrometricsTemperatureDryBlubUnits;
        private System.Windows.Forms.Label PsychrometricsTemperatureWetBlubUnits;
        private System.Windows.Forms.TextBox Psychrometrics_Elevation_Value;
        private System.Windows.Forms.TextBox Psychrometrics_DBT_Value;
        private System.Windows.Forms.TextBox Psychrometrics_WBT_Value;
        private System.Windows.Forms.Label TemperatureDryBlubLabel;
        private System.Windows.Forms.Label TemperatureWetBlubLabel;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
