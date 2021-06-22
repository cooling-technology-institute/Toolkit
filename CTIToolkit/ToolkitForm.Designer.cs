﻿namespace CTIToolkit
{
    partial class ToolkitForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolkitForm));
            this.ToolkitTabControl = new System.Windows.Forms.TabControl();
            this.Psychrometrics = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.InternationalSystemOfUnits_IS_ = new System.Windows.Forms.RadioButton();
            this.UnitedStatesCustomaryUnits_IP_ = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            this.Merkel = new System.Windows.Forms.TabPage();
            this.DemandCurve = new System.Windows.Forms.TabPage();
            this.MechanicalDraftPerfCurve = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.printingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printerSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.iPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.siToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.demandCurvesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ToolkitTabControl.SuspendLayout();
            this.Psychrometrics.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.PsychrometricPropertiesGroupBox.SuspendLayout();
            this.InputPropertiesGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolkitTabControl
            // 
            this.ToolkitTabControl.Controls.Add(this.Psychrometrics);
            this.ToolkitTabControl.Controls.Add(this.Merkel);
            this.ToolkitTabControl.Controls.Add(this.DemandCurve);
            this.ToolkitTabControl.Controls.Add(this.MechanicalDraftPerfCurve);
            this.ToolkitTabControl.Location = new System.Drawing.Point(0, 27);
            this.ToolkitTabControl.Name = "ToolkitTabControl";
            this.ToolkitTabControl.SelectedIndex = 0;
            this.ToolkitTabControl.Size = new System.Drawing.Size(930, 650);
            this.ToolkitTabControl.TabIndex = 0;
            // 
            // Psychrometrics
            // 
            this.Psychrometrics.Controls.Add(this.groupBox1);
            this.Psychrometrics.Controls.Add(this.dataGridView1);
            this.Psychrometrics.Controls.Add(this.PsychrometricPropertiesGroupBox);
            this.Psychrometrics.Controls.Add(this.InputPropertiesGroupBox);
            this.Psychrometrics.Location = new System.Drawing.Point(4, 22);
            this.Psychrometrics.Name = "Psychrometrics";
            this.Psychrometrics.Padding = new System.Windows.Forms.Padding(3);
            this.Psychrometrics.Size = new System.Drawing.Size(922, 624);
            this.Psychrometrics.TabIndex = 0;
            this.Psychrometrics.Text = "Psychrometrics";
            this.Psychrometrics.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.InternationalSystemOfUnits_IS_);
            this.groupBox1.Controls.Add(this.UnitedStatesCustomaryUnits_IP_);
            this.groupBox1.Location = new System.Drawing.Point(509, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 79);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // InternationalSystemOfUnits_IS_
            // 
            this.InternationalSystemOfUnits_IS_.AutoSize = true;
            this.InternationalSystemOfUnits_IS_.Location = new System.Drawing.Point(17, 50);
            this.InternationalSystemOfUnits_IS_.Name = "InternationalSystemOfUnits_IS_";
            this.InternationalSystemOfUnits_IS_.Size = new System.Drawing.Size(178, 17);
            this.InternationalSystemOfUnits_IS_.TabIndex = 1;
            this.InternationalSystemOfUnits_IS_.Text = "International System of Units (SI)";
            this.InternationalSystemOfUnits_IS_.UseVisualStyleBackColor = true;
            this.UnitedStatesCustomaryUnits_IP_.CheckedChanged += new System.EventHandler(this.InternationalSystemOfUnits_IS__CheckedChanged);
            // 
            // UnitedStatesCustomaryUnits_IP_
            // 
            this.UnitedStatesCustomaryUnits_IP_.AutoSize = true;
            this.UnitedStatesCustomaryUnits_IP_.Checked = true;
            this.UnitedStatesCustomaryUnits_IP_.Location = new System.Drawing.Point(17, 21);
            this.UnitedStatesCustomaryUnits_IP_.Name = "UnitedStatesCustomaryUnits_IP_";
            this.UnitedStatesCustomaryUnits_IP_.Size = new System.Drawing.Size(187, 17);
            this.UnitedStatesCustomaryUnits_IP_.TabIndex = 0;
            this.UnitedStatesCustomaryUnits_IP_.TabStop = true;
            this.UnitedStatesCustomaryUnits_IP_.Text = "United States Customary Units (IP)";
            this.UnitedStatesCustomaryUnits_IP_.UseVisualStyleBackColor = true;
            this.UnitedStatesCustomaryUnits_IP_.CheckedChanged += new System.EventHandler(this.UnitedStatesCustomaryUnits_IP__CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 324);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(742, 294);
            this.dataGridView1.TabIndex = 3;
            // 
            // PsychrometricPropertiesGroupBox
            // 
            this.PsychrometricPropertiesGroupBox.Controls.Add(this.Psychrometrics_Enthalpy);
            this.PsychrometricPropertiesGroupBox.Controls.Add(this.Psychrometrics_DBT_RH);
            this.PsychrometricPropertiesGroupBox.Controls.Add(this.Psychrometrics_WBT_DBT);
            this.PsychrometricPropertiesGroupBox.Controls.Add(this.PsychrometricsCalculate);
            this.PsychrometricPropertiesGroupBox.Location = new System.Drawing.Point(8, 162);
            this.PsychrometricPropertiesGroupBox.Name = "PsychrometricPropertiesGroupBox";
            this.PsychrometricPropertiesGroupBox.Size = new System.Drawing.Size(742, 145);
            this.PsychrometricPropertiesGroupBox.TabIndex = 2;
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
            this.InputPropertiesGroupBox.Location = new System.Drawing.Point(7, 17);
            this.InputPropertiesGroupBox.Name = "InputPropertiesGroupBox";
            this.InputPropertiesGroupBox.Size = new System.Drawing.Size(743, 130);
            this.InputPropertiesGroupBox.TabIndex = 1;
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
            this.groupBox2.Location = new System.Drawing.Point(302, 29);
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
            this.toolTip1.SetToolTip(this.Psychrometrics_DBT_Value, "Dry Bulb Temperature. Value should be between 0 and 200. \r\nThe value should be le" +
        "ss than the Web Bulb Temperature.\r\n");
            // 
            // Psychrometrics_WBT_Value
            // 
            this.Psychrometrics_WBT_Value.Location = new System.Drawing.Point(152, 36);
            this.Psychrometrics_WBT_Value.Name = "Psychrometrics_WBT_Value";
            this.Psychrometrics_WBT_Value.Size = new System.Drawing.Size(100, 20);
            this.Psychrometrics_WBT_Value.TabIndex = 3;
            this.Psychrometrics_WBT_Value.Text = "80";
            this.Psychrometrics_WBT_Value.TextChanged += new System.EventHandler(this.Psychrometrics_WBT_Value_TextChanged);
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
            // Merkel
            // 
            this.Merkel.Location = new System.Drawing.Point(4, 22);
            this.Merkel.Name = "Merkel";
            this.Merkel.Padding = new System.Windows.Forms.Padding(3);
            this.Merkel.Size = new System.Drawing.Size(922, 624);
            this.Merkel.TabIndex = 1;
            this.Merkel.Text = "Merkel";
            this.Merkel.UseVisualStyleBackColor = true;
            // 
            // DemandCurve
            // 
            this.DemandCurve.Location = new System.Drawing.Point(4, 22);
            this.DemandCurve.Name = "DemandCurve";
            this.DemandCurve.Size = new System.Drawing.Size(922, 624);
            this.DemandCurve.TabIndex = 2;
            this.DemandCurve.Text = "Demand Curve";
            this.DemandCurve.UseVisualStyleBackColor = true;
            // 
            // MechanicalDraftPerfCurve
            // 
            this.MechanicalDraftPerfCurve.Location = new System.Drawing.Point(4, 22);
            this.MechanicalDraftPerfCurve.Name = "MechanicalDraftPerfCurve";
            this.MechanicalDraftPerfCurve.Size = new System.Drawing.Size(922, 624);
            this.MechanicalDraftPerfCurve.TabIndex = 3;
            this.MechanicalDraftPerfCurve.Text = "Mechanical Draft Perf Curve";
            this.MechanicalDraftPerfCurve.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.settingsToolStripMenuItem,
            this.documentationToolStripMenuItem,
            this.ViewMenu,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(930, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printingToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.printerSetupToolStripMenuItem});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(37, 20);
            this.FileMenu.Text = "File";
            // 
            // printingToolStripMenuItem
            // 
            this.printingToolStripMenuItem.Name = "printingToolStripMenuItem";
            this.printingToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.printingToolStripMenuItem.Text = "Print";
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.printPreviewToolStripMenuItem.Text = "Print Preview";
            // 
            // printerSetupToolStripMenuItem
            // 
            this.printerSetupToolStripMenuItem.Name = "printerSetupToolStripMenuItem";
            this.printerSetupToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.printerSetupToolStripMenuItem.Text = "Printer Setup";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // documentationToolStripMenuItem
            // 
            this.documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
            this.documentationToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.documentationToolStripMenuItem.Text = "Documentation";
            // 
            // ViewMenu
            // 
            this.ViewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iPToolStripMenuItem,
            this.siToolStripMenuItem,
            this.demandCurvesToolStripMenuItem});
            this.ViewMenu.Name = "ViewMenu";
            this.ViewMenu.Size = new System.Drawing.Size(44, 20);
            this.ViewMenu.Text = "View";
            // 
            // iPToolStripMenuItem
            // 
            this.iPToolStripMenuItem.Name = "iPToolStripMenuItem";
            this.iPToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.iPToolStripMenuItem.Text = "IP";
            // 
            // siToolStripMenuItem
            // 
            this.siToolStripMenuItem.Name = "siToolStripMenuItem";
            this.siToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.siToolStripMenuItem.Text = "Si";
            // 
            // demandCurvesToolStripMenuItem
            // 
            this.demandCurvesToolStripMenuItem.Name = "demandCurvesToolStripMenuItem";
            this.demandCurvesToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.demandCurvesToolStripMenuItem.Text = "Demand Curves";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // ToolkitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 674);
            this.Controls.Add(this.ToolkitTabControl);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ToolkitForm";
            this.Text = "Cooling Technology Institute Toolkit";
            this.ToolkitTabControl.ResumeLayout(false);
            this.Psychrometrics.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.PsychrometricPropertiesGroupBox.ResumeLayout(false);
            this.PsychrometricPropertiesGroupBox.PerformLayout();
            this.InputPropertiesGroupBox.ResumeLayout(false);
            this.InputPropertiesGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl ToolkitTabControl;
        private System.Windows.Forms.TabPage Psychrometrics;
        private System.Windows.Forms.GroupBox PsychrometricPropertiesGroupBox;
        private System.Windows.Forms.RadioButton Psychrometrics_Enthalpy;
        private System.Windows.Forms.RadioButton Psychrometrics_DBT_RH;
        private System.Windows.Forms.RadioButton Psychrometrics_WBT_DBT;
        private System.Windows.Forms.GroupBox InputPropertiesGroupBox;
        private System.Windows.Forms.Label PsychrometricsElevationPressureLabel2;
        private System.Windows.Forms.Label PsychrometricsTemperatureDryBlubUnits;
        private System.Windows.Forms.Label PsychrometricsTemperatureWetBlubUnits;
        private System.Windows.Forms.TextBox Psychrometrics_Elevation_Value;
        private System.Windows.Forms.TextBox Psychrometrics_DBT_Value;
        private System.Windows.Forms.TextBox Psychrometrics_WBT_Value;
        private System.Windows.Forms.Label TemperatureDryBlubLabel;
        private System.Windows.Forms.Label TemperatureWetBlubLabel;
        private System.Windows.Forms.Button PsychrometricsCalculate;
        private System.Windows.Forms.TabPage Merkel;
        private System.Windows.Forms.TabPage DemandCurve;
        private System.Windows.Forms.TabPage MechanicalDraftPerfCurve;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.ToolStripMenuItem printingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printerSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewMenu;
        private System.Windows.Forms.ToolStripMenuItem iPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem siToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem demandCurvesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label PsychrometricsElevationPressureLabel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton PyschmetricsPressureRadio;
        private System.Windows.Forms.RadioButton PyschmetricsElevationRadio;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentationToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton InternationalSystemOfUnits_IS_;
        private System.Windows.Forms.RadioButton UnitedStatesCustomaryUnits_IP_;
    }
}

