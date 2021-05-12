// Copyright Cooling Technology Institute 2019-2021

using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using ViewModels;

namespace CTIToolkit
{
    public partial class MechanicalDraftPerformanceCurveTabPage : CalculatePrintUserControl
    {
        private MechanicalDraftPerformanceCurveViewModel MechanicalDraftPerformanceCurveViewModel { get; set; }

        private TowerDesignDataForm TowerDesignDataForm { get; set; }

        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_SI { get; set; }
        private bool IsChanged { get; set; }

        public MechanicalDraftPerformanceCurveTabPage(ApplicationSettings applicationSettings)
        {
            InitializeComponent();

            IsInternationalSystemOfUnits_SI = (applicationSettings.UnitsSelection == UnitsSelection.International_System_Of_Units_SI);
            ErrorMessage = string.Empty;

            Filter = "Mechanical Draft Performance Curve files (*.mdpc)|*.mdpc|All files (*.*)|*.*";
            DefaultExt = "mdpc";
            Title = "Mechanical Draft Performance Curve";
            DefaultFileName = "MechanicalDraftPerformanceCurve";

            MechanicalDraftPerformanceCurveViewModel = new MechanicalDraftPerformanceCurveViewModel(IsDemo, IsInternationalSystemOfUnits_SI);
            TowerDesignDataForm = new TowerDesignDataForm(IsDemo, IsInternationalSystemOfUnits_SI, MechanicalDraftPerformanceCurveViewModel.DesignData);
            TestPointTabControl.TabPages.Clear();

            MechanicalDraftPerformanceCurveViewModel.DataFileName = BuildDefaultFileName();

            LoadTestPoints();
            SetDisplayedUnits();
            SetDisplayedValues();
            IsChanged = false;
        }

        public void SetUnitsStandard(bool isInternationalSystemOfUnits_SI)
        {
            if (IsInternationalSystemOfUnits_SI != isInternationalSystemOfUnits_SI)
            {
                IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;
                TowerDesignDataForm.SetUnitsStandard(IsInternationalSystemOfUnits_SI);
                SwitchUnits();
            }
        }

        private void SwitchUnits()
        {
            MechanicalDraftPerformanceCurveViewModel.SwitchUnits(IsInternationalSystemOfUnits_SI);
            SetDisplayedUnits();
            SetDisplayedValues();
        }

        private void SetDisplayedUnits()
        {
            if (IsInternationalSystemOfUnits_SI)
            {
                UnitsWaterFlowRate.Text = ConstantUnits.LitersPerSecond;
                UnitsHotWaterTemperature.Text = ConstantUnits.TemperatureCelsius;
                UnitsColdWaterTemperature.Text = ConstantUnits.TemperatureCelsius;
                UnitsWetBulbTemperature.Text = ConstantUnits.TemperatureCelsius;
                UnitsDryBulbTemperature.Text = ConstantUnits.TemperatureCelsius;
                UnitsFanDriverPower.Text = ConstantUnits.Kilowatt;
                UnitsBarometricPressure.Text = ConstantUnits.BarometricPressureKiloPascal;
            }
            else
            {
                UnitsWaterFlowRate.Text = ConstantUnits.GallonsPerMinute;
                UnitsHotWaterTemperature.Text = ConstantUnits.TemperatureFahrenheit;
                UnitsColdWaterTemperature.Text = ConstantUnits.TemperatureFahrenheit;
                UnitsWetBulbTemperature.Text = ConstantUnits.TemperatureFahrenheit;
                UnitsDryBulbTemperature.Text = ConstantUnits.TemperatureFahrenheit;
                UnitsFanDriverPower.Text = ConstantUnits.BrakeHorsepower;
                UnitsBarometricPressure.Text = ConstantUnits.BarometricPressureInchOfMercury;
            }
        }

        public override bool OpenDataFile(string fileName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;

            if(MechanicalDraftPerformanceCurveViewModel.OpenDataFile(fileName))
            {
                if(MechanicalDraftPerformanceCurveViewModel.IsInternationalSystemOfUnits_SI != IsInternationalSystemOfUnits_SI)
                {
                    ToolkitMain main = this.Parent.Parent.Parent as ToolkitMain;
                    if(main != null)
                    {
                        main.UpdateUnits(MechanicalDraftPerformanceCurveViewModel.IsInternationalSystemOfUnits_SI ? UnitsSelection.International_System_Of_Units_SI : UnitsSelection.United_States_Customary_Units_IP);
                    }
                }

                if (!TowerDesignDataForm.LoadData(MechanicalDraftPerformanceCurveViewModel.DesignData))
                {
                    stringBuilder.AppendLine(TowerDesignDataForm.ErrorMessage);
                    returnValue = false;
                }

                // enable controls
                AddTestPointButton.Enabled = true;
                AddTestPointName.Enabled = true;

                if (MechanicalDraftPerformanceCurveViewModel.TestPoints.Count > 0)
                {
                    CalculateButton.Enabled = true;
                }

                if (MechanicalDraftPerformanceCurveViewModel.IsDesignDataValid)
                {
                    ViewGraph.Enabled = true;
                }

                if (!LoadTestPoints())
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    returnValue = false;
                    ErrorMessage = string.Empty;
                }

                if (!SetDisplayedValues())
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    returnValue = false;
                    ErrorMessage = string.Empty;
                }
                Calculate();
            }
            else
            {
                stringBuilder.AppendLine("Unable to load file. File contains invalid data.");
            }

            if(!returnValue)
            {
                ErrorMessage = stringBuilder.ToString();
            }
            IsChanged = false;

            return returnValue;
        }

        public override bool OpenNewDataFile(string fileName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;

            if (MechanicalDraftPerformanceCurveViewModel.OpenNewDataFile(fileName))
            {
                if (!TowerDesignDataForm.LoadData(MechanicalDraftPerformanceCurveViewModel.DesignData))
                {
                    stringBuilder.AppendLine(TowerDesignDataForm.ErrorMessage);
                    returnValue = false;
                }

                // enable controls
                AddTestPointButton.Enabled = true;
                AddTestPointName.Enabled = true;

                if (MechanicalDraftPerformanceCurveViewModel.TestPoints.Count > 0)
                {
                    CalculateButton.Enabled = true;
                    ViewGraph.Enabled = true;
                }

                if (!LoadTestPoints())
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    returnValue = false;
                }

                if (!SetDisplayedValues())
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    returnValue = false;
                }
            }
            else
            {
                stringBuilder.AppendLine("Unable to load file. File contains invalid data");
                returnValue = false;
            }

            if (!returnValue)
            {
                ErrorMessage = stringBuilder.ToString();
            }
            IsChanged = false;

            return returnValue;
        }

        public bool LoadTestPoints()
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;
            ErrorMessage = string.Empty;

            TestPointTabControl.TabPages.Clear();
            foreach (TowerTestPoint towerTestPoint in MechanicalDraftPerformanceCurveViewModel.TestPoints)
            {
                TestPointUserControl testPointUserControl = new TestPointUserControl();
                if(!testPointUserControl.LoadData(towerTestPoint))
                {
                    stringBuilder.AppendLine(testPointUserControl.ErrorMessage);
                    returnValue = false;
                }
                TabPage tabPage = new TabPage();
                tabPage.Controls.Add(testPointUserControl);
                tabPage.Text = towerTestPoint.TestName;
                TestPointTabControl.TabPages.Add(tabPage);
            }

            if(!returnValue)
            {
                ErrorMessage = stringBuilder.ToString();
            }

            return returnValue;
        }

        public override bool SaveDataFile()
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;
            ErrorMessage = string.Empty;

            if (!MechanicalDraftPerformanceCurveViewModel.SaveDataFile())
            {
                stringBuilder.AppendLine(MechanicalDraftPerformanceCurveViewModel.ErrorMessage);
                returnValue = false;
            }

            if (!SetDisplayedValues())
            {
                stringBuilder.AppendLine(ErrorMessage);
                returnValue = false;
            }

            if (!returnValue)
            {
                ErrorMessage = stringBuilder.ToString();
            }

            return returnValue;
        }

        public override bool SaveAsDataFile(string fileName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;

            MechanicalDraftPerformanceCurveViewModel.DataFileName = fileName;
            DataFilename.Text = MechanicalDraftPerformanceCurveViewModel.DataFilenameInputValue;

            if (!MechanicalDraftPerformanceCurveViewModel.SaveAsDataFile(fileName))
            {
                stringBuilder.AppendLine(MechanicalDraftPerformanceCurveViewModel.ErrorMessage);
                returnValue = false;
            }

            ErrorMessage = stringBuilder.ToString();

            return returnValue;
        }

        private bool SetDisplayedValues()
        {
            try
            {
                // design data
                OwnerNameField.Text = TowerDesignDataForm.TowerDesignData.OwnerNameValue;
                ProjectNameField.Text = TowerDesignDataForm.TowerDesignData.ProjectNameValue;
                LocationField.Text = TowerDesignDataForm.TowerDesignData.LocationValue;
                TowerManufacturerField.Text = TowerDesignDataForm.TowerDesignData.TowerManufacturerValue;
                TowerTypeField.Text = TowerDesignDataForm.TowerDesignData.TowerTypeValue.ToString();

                DesignWaterFlowRate.Text = TowerDesignDataForm.TowerDesignData.WaterFlowRateDataValue.InputValue;
                DesignHotWaterTemperature.Text = TowerDesignDataForm.TowerDesignData.HotWaterTemperatureDataValue.InputValue;
                DesignColdWaterTemperature.Text = TowerDesignDataForm.TowerDesignData.ColdWaterTemperatureDataValue.InputValue;
                DesignWetBulbTemperature.Text = TowerDesignDataForm.TowerDesignData.WetBulbTemperatureDataValue.InputValue;
                DesignDryBulbTemperature.Text = TowerDesignDataForm.TowerDesignData.DryBulbTemperatureDataValue.InputValue;
                DesignFanDriverPower.Text = TowerDesignDataForm.TowerDesignData.FanDriverPowerDataValue.InputValue;
                DesignBarometricPressure.Text = TowerDesignDataForm.TowerDesignData.BarometricPressureDataValue.InputValue;
                DesignLiquidToGasRatio.Text = TowerDesignDataForm.TowerDesignData.LiquidToGasRatioDataValue.InputValue;

                DataFilename.Text = MechanicalDraftPerformanceCurveViewModel.DataFilenameInputValue;

                TestResultsGroupBox.Text = string.Format("Test Results ({0})", (IsInternationalSystemOfUnits_SI) ? "SI" : "IP");

                foreach (TabPage tabPage in TestPointTabControl.TabPages)
                {
                    try
                    {
                        TestPointUserControl testPointUserControl = tabPage.Controls[0] as TestPointUserControl;
                        if(testPointUserControl != null)
                        {
                            testPointUserControl.SetDisplayedValues();
                        }
                    }
                    catch
                    { }
                }
            }
            catch (Exception e)
            {
                ErrorMessage = string.Format("Failure to load page. Exception: {0}", e.ToString());
                return false;
            }
            return true;
        }

        private void DesignDataButton_Click(object sender, EventArgs e)
        {
            // set data
            if (TowerDesignDataForm.ShowDialog(this) == DialogResult.OK)
            {
                if(TowerDesignDataForm.HasDataChanged)
                {
                    // save design data
                    TowerDesignDataForm.SaveDesignData(MechanicalDraftPerformanceCurveViewModel.DesignData);

                    // enable controls
                    AddTestPointButton.Enabled = true;
                    AddTestPointName.Enabled = true;

                    // update data on this page
                    if (SetDisplayedValues())
                    {

                    }
                }
            }
            else
            {
                if (TowerDesignDataForm.HasDataChanged)
                {
                    TowerDesignDataForm.LoadData(MechanicalDraftPerformanceCurveViewModel.DesignData);
                }
            }
        }

        public override void Calculate()
        {
            //int testIndex = TestPointTabControl.SelectedIndex;

            //MechanicalDraftPerformanceCurveViewModel.TestPoints.Clear();

            // save the test points to view model
            //foreach (TabPage tabPage in TestPointTabControl.TabPages)
            //{
            //    try
            //    {
            //        TestPointUserControl testPointUserControl = tabPage.Controls[0] as TestPointUserControl;
            //        MechanicalDraftPerformanceCurveViewModel.TestPoints.Add(testPointUserControl.TowerTestPoint);
            //    }
            //    catch
            //    { }
            //    //    if (!testPointUserControl.LoadData(towerTestPoint, out errorMessage))
            //    //    {
            //    //        returnValue = false;
            //    //    }
            //}

            if (MechanicalDraftPerformanceCurveViewModel.CalculatePerformanceCurve(TestPointTabControl.SelectedIndex))
            {
                if (MechanicalDraftPerformanceCurveViewModel.GetDataTable() != null)
                {
                    DataGridView.DataSource = null;
                }

                if (MechanicalDraftPerformanceCurveViewModel.GetDataTable() != null)
                {
                    // Set a DataGrid control's DataSource to the DataView.
                    DataGridView.DataSource = new DataView(MechanicalDraftPerformanceCurveViewModel.GetDataTable());
                }
            }
            else
            {
                MessageBox.Show(MechanicalDraftPerformanceCurveViewModel.ErrorMessage, "Mechanical Draft Performance Curve Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable BuildFlowRateDataTable(WaterFlowRate waterFlowRate, List<double> ranges)
        {
            DataTable DataTable = new DataTable();
            DataColumn column;

            // Create Name column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Wet Bulb Temperature";
            DataTable.Columns.Add(column);

            foreach(double range in ranges)
            {
                // Create Value column.
                column = new DataColumn();
                column.DataType = Type.GetType("System.String");
                column.ColumnName = string.Format("Range: {0}", range.ToString("F2"));
                DataTable.Columns.Add(column);
            }

            // Create Units column.
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Units";
            DataTable.Columns.Add(column);

            foreach(WetBulbTemperature wetBulbTemperature in waterFlowRate.WetBulbTemperatures)
            {
                DataRow row = DataTable.NewRow();
                row[0] = wetBulbTemperature.Temperature.ToString("F2");
                int columnIndex = 1;
                foreach(double temperature in wetBulbTemperature.ColdWaterTemperatures)
                {
                    row[columnIndex++] = temperature.ToString("F2");
                }
                if(IsInternationalSystemOfUnits_SI)
                {
                    row[columnIndex] = ConstantUnits.TemperatureCelsius;
                }
                else
                {
                    row[columnIndex] = ConstantUnits.TemperatureFahrenheit;
                }
                DataTable.Rows.Add(row);
            }

            return DataTable;
        }

        public override void PrintPage(object sender, PrintPageEventArgs e)
        {
            if(PrintControl.UserControl == null)
            {
                NameValueUnitsDataTable nameValueUnitsDataTable = new NameValueUnitsDataTable();
                UserControl printerOutput = null;
                
                if(PrintControl.Bitmap != null)
                {
                    PrintControl.Bitmap.Dispose();
                }

                if (MechanicalDraftPerformanceCurveViewModel.IsDesignDataValid)
                {
                    if (PrintControl.IsDesignData)
                    {
                        int pageSize = e.PageSettings.Bounds.Height;
                        TowerDesignDataForm.FillNameValueUnitsDataTable(nameValueUnitsDataTable);
                        MechanicalDraftPerformanceCurveDataPrinterOutput output = new MechanicalDraftPerformanceCurveDataPrinterOutput(pageSize, this.PrintControl.Label, nameValueUnitsDataTable, MechanicalDraftPerformanceCurveViewModel);
                        PrintControl.X.Clear();
                        PrintControl.PageIndex = 0;
                        printerOutput = output;
                        if ((MechanicalDraftPerformanceCurveViewModel.CalculationData != null)
                            && (MechanicalDraftPerformanceCurveViewModel.CalculationData.WaterFlowRates != null)
                            && (MechanicalDraftPerformanceCurveViewModel.CalculationData.WaterFlowRates.Count > 0))
                        {
                            int bottom = 475;
                            int index = 1;
                            int pageHeight = pageSize;
                            int newBottom = 0;
                            PrintControl.X.Add(0);
                            PrintControl.X.Add(pageHeight);

                            foreach (WaterFlowRate waterFlowRate in MechanicalDraftPerformanceCurveViewModel.CalculationData.WaterFlowRates)
                            {
                                newBottom = output.AddWaterFlowRate(pageHeight, bottom,
                                    string.Format("Water Flow Rate: {0} {1}", waterFlowRate.FlowRate, (IsInternationalSystemOfUnits_SI) ? ConstantUnits.LitersPerSecond : ConstantUnits.GallonsPerMinute),
                                    BuildFlowRateDataTable(waterFlowRate, MechanicalDraftPerformanceCurveViewModel.CalculationData.Ranges));

                                if (newBottom > pageHeight)
                                {
                                    if (index > 1)
                                    {
                                        PrintControl.X.Add(pageHeight);
                                    }
                                    index++;
                                    pageHeight = pageSize * index;
                                }
                                bottom = newBottom;
                            }
                            PrintControl.X.Add(newBottom);
                        }
                    }
                    else
                    {
                        printerOutput = new MechanicalDraftPerformanceCurvePrinterOutput(e.PageBounds.Height - 120, this.PrintControl.Label, TestPointTabControl.SelectedIndex, MechanicalDraftPerformanceCurveViewModel);
                        //               int bottom = 500;
                    }
                }
                else
                {
                    MessageBox.Show("The design data is not valid", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }

                if (printerOutput != null)
                {
                    PrintControl.UserControl = printerOutput;
                    printerOutput.CreateControl();
                    PrintControl.Bitmap = new Bitmap(printerOutput.Width, printerOutput.Height);
                    printerOutput.DrawToBitmap(PrintControl.Bitmap, new Rectangle(0, 0, PrintControl.Bitmap.Width, PrintControl.Bitmap.Height));
                }
            }

            if(!e.Cancel)
            {
                if (PrintControl.PageIndex < PrintControl.X.Count)
                {
                    int pageTop = PrintControl.X[PrintControl.PageIndex];
                    int pageBottom;
                    if (PrintControl.PageIndex + 1 < PrintControl.X.Count)
                    {
                        pageBottom = PrintControl.X[PrintControl.PageIndex + 1];

                        if (pageBottom < PrintControl.Bitmap.Height)
                        {
                            e.HasMorePages = true;
                        }
                    }
                    else
                    {
                        pageBottom = PrintControl.Bitmap.Height;
                    }
                    DrawImage(e, PrintControl.Bitmap, new Rectangle(0, pageTop, PrintControl.Bitmap.Width, pageBottom));
                    PrintControl.PageIndex++;
                }
                else
                {
                    e.Graphics.DrawImage(PrintControl.Bitmap, 40, 40);
                }

                e.Graphics.DrawString("CTI Toolkit 4.0 Beta Version",
                                      new Font("Times New Roman", 16),
                                      new SolidBrush(Color.Red),
                                      40, e.PageSettings.Bounds.Height - 60);
                Font font = new Font("Times New Roman", 8);
                SizeF size = e.Graphics.MeasureString(MechanicalDraftPerformanceCurveViewModel.DataFilenameInputValue, font);
                e.Graphics.DrawString(MechanicalDraftPerformanceCurveViewModel.DataFilenameInputValue,
                                      font,
                                      new SolidBrush(Color.Black),
                                      e.PageSettings.Bounds.Width - size.Width - 40, e.PageSettings.Bounds.Height - 60);

            }
        }

        public void DrawImage(PrintPageEventArgs e, Image image, Rectangle rectangle)
        {
            // Draw image to screen.
            e.Graphics.DrawImage(image, 40, 40, rectangle, GraphicsUnit.Pixel);
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        private void ViewGraph_Click(object sender, EventArgs e)
        {
            MechanicalDraftPerformanceCurveViewModel.CalculateViewGraphs(TestPointTabControl.SelectedIndex);

            ViewGraphsForm viewGraphsForm = new ViewGraphsForm(MechanicalDraftPerformanceCurveViewModel.CalculationData);
            if (viewGraphsForm.ShowDialog(this) == DialogResult.OK)
            {
            }
        }

        private void TestSelector_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddTestPointButton_Click(object sender, EventArgs e)
        {
            ErrorMessage = string.Empty;
            if(!AddTabPage(AddTestPointName.Text))
            {
                //todo Message box
            }
            AddTestPointName.Text = string.Empty;
        }

        private bool AddTabPage(string testName)
        {
            bool returnValue = true;
            StringBuilder stringBuilder = new StringBuilder();

            try
            {
                if(MechanicalDraftPerformanceCurveViewModel.AddTestPoint(testName))
                {
                    TabPage tabPage = new TabPage()
                    {
                        Text = testName
                    };
                    TestPointUserControl testPointUserControl = new TestPointUserControl();
                    if (!testPointUserControl.LoadData(MechanicalDraftPerformanceCurveViewModel.TestPoints[MechanicalDraftPerformanceCurveViewModel.TestPoints.Count - 1]))
                    {
                        stringBuilder.AppendLine(testPointUserControl.ErrorMessage);
                        returnValue = false;
                    }
                    tabPage.Controls.Add(testPointUserControl);
                    TestPointTabControl.TabPages.Add(tabPage);
                    TestPointTabControl.SelectedIndex = TestPointTabControl.TabPages.Count - 1;
                }
                else
                {
                    stringBuilder.AppendLine(MechanicalDraftPerformanceCurveViewModel.ErrorMessage);
                }
            }
            catch (Exception e)
            {
                stringBuilder.AppendLine(string.Format("Tower design page setup failed. Exception: {0} ", e.ToString()));
                returnValue = false;
            }

            if(!returnValue)
            {
                ErrorMessage = stringBuilder.ToString();
            }

            return returnValue;
        }
        private void TestPointDelete_Click(object sender, EventArgs e)
        {
            CustomMenuItem customMenuItem = sender as CustomMenuItem;
            TestPointTabControl.TabPages.Remove(TestPointTabControl.TabPages[customMenuItem.TabIndex]);
        }

        private void TestPointUpdate_Click(object sender, EventArgs e)
        {
            CustomMenuItem customMenuItem = sender as CustomMenuItem;
            TestPointUserControl testPointUserControl = TestPointTabControl.TabPages[customMenuItem.TabIndex].Controls[0] as TestPointUserControl;

            if (testPointUserControl != null)
            {
                UpdateTestPointTestNameForm updateTestPointForm = new UpdateTestPointTestNameForm(IsDemo, IsInternationalSystemOfUnits_SI, testPointUserControl.TowerTestPoint.TestName);

                if (updateTestPointForm.ShowDialog(this) == DialogResult.OK)
                {
                    testPointUserControl.TowerTestPoint.TestName = updateTestPointForm.TestName;
                    TestPointTabControl.TabPages[customMenuItem.TabIndex].Text = testPointUserControl.TowerTestPoint.TestName;
                    IsChanged = true;
                }

                updateTestPointForm.Dispose();
            }
        }

        private void TestPointMoveLeft_Click(object sender, EventArgs e)
        {
            CustomMenuItem customMenuItem = sender as CustomMenuItem;
            TabPage tabPage = TestPointTabControl.TabPages[customMenuItem.TabIndex];
            TestPointTabControl.TabPages[customMenuItem.TabIndex] = TestPointTabControl.TabPages[customMenuItem.TabIndex - 1];
            TestPointTabControl.TabPages[customMenuItem.TabIndex - 1] = tabPage;
            TestPointTabControl.SelectedIndex = customMenuItem.TabIndex - 1;
        }

        private void TestPointMoveRight_Click(object sender, EventArgs e)
        {
            CustomMenuItem customMenuItem = sender as CustomMenuItem;
            TabPage tabPage = TestPointTabControl.TabPages[customMenuItem.TabIndex + 1];
            TestPointTabControl.TabPages[customMenuItem.TabIndex + 1] = TestPointTabControl.TabPages[customMenuItem.TabIndex];
            TestPointTabControl.TabPages[customMenuItem.TabIndex] = tabPage;
            TestPointTabControl.SelectedIndex = customMenuItem.TabIndex + 1;
        }

        private void TestPointTabControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // find tab then display menu next to tab
                // iterate through all the tab pages
                for (int i = 0; i < TestPointTabControl.TabCount; i++)
                {
                    // get their rectangle area and check if it contains the mouse cursor
                    Rectangle r = TestPointTabControl.GetTabRect(i);

                    if (r.Contains(e.Location))
                    {
                        ContextMenu contextMenu = new ContextMenu();
                        contextMenu.MenuItems.Add(new CustomMenuItem("Update", new System.EventHandler(this.TestPointUpdate_Click), i));
                        contextMenu.MenuItems.Add("-");
                        if (i != 0)
                        {
                            contextMenu.MenuItems.Add(new CustomMenuItem("< Move Left", new System.EventHandler(this.TestPointMoveLeft_Click), i));
                        }
                        if (i != TestPointTabControl.TabCount - 1)
                        {
                            contextMenu.MenuItems.Add(new CustomMenuItem("> Move Right", new System.EventHandler(this.TestPointMoveRight_Click), i));
                        }
                        contextMenu.MenuItems.Add("-");
                        contextMenu.MenuItems.Add(new CustomMenuItem("Delete", new System.EventHandler(this.TestPointDelete_Click), i));


                        // show the context menu here
                        contextMenu.Show(this.TestPointTabControl, e.Location);
                    }
                }
            }
            else
            {

            }
        }

        public void ValueHasChanged()
        {
            // Clear output data
            DataGridView.DataSource = null;
        }

        private void TestPointTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear output data and calculate values
            DataGridView.DataSource = null;
            Calculate();
        }
    }
}
