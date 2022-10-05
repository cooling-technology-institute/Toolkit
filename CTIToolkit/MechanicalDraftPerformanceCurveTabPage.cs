// Copyright Cooling Technology Institute 2019-2022

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

        public MechanicalDraftPerformanceCurveTabPage(ApplicationSettings applicationSettings, string documentPath)
        {
            InitializeComponent();

            IsDemo = applicationSettings.IsDemo;
            IsInternationalSystemOfUnits_SI = (applicationSettings.UnitsSelection == UnitsSelection.International_System_Of_Units_SI);
            ErrorMessage = string.Empty;

            Filter = "Mechanical Draft Performance Curve files (*.mdpc)|*.mdpc|All files (*.*)|*.*";
            DefaultExt = "mdpc";
            Title = "Mechanical Draft Performance Curve";
            DefaultFileName = "MechanicalDraftPerformanceCurve";

            MechanicalDraftPerformanceCurveViewModel = new MechanicalDraftPerformanceCurveViewModel(IsDemo, IsInternationalSystemOfUnits_SI);
            TowerDesignDataForm = new TowerDesignDataForm(IsDemo, IsInternationalSystemOfUnits_SI, MechanicalDraftPerformanceCurveViewModel.DesignData);
            TestPointTabControl.TabPages.Clear();

            MechanicalDraftPerformanceCurveViewModel.DataFileName = BuildDefaultFileName(documentPath);

            LoadTestPoints();
            SetDisplayedUnits();
            SetDisplayedValues();
            IsChanged = false;
        }

        public void UpdateDemo(bool isDemo)
        {
            if (IsDemo != isDemo)
            {
                IsDemo = isDemo;
                MechanicalDraftPerformanceCurveViewModel.UpdateDemo(isDemo);
            }
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
            UnitsWaterFlowRate.Text = MechanicalDraftPerformanceCurveViewModel.WaterFlowRateDataValue.Units;
            UnitsHotWaterTemperature.Text = MechanicalDraftPerformanceCurveViewModel.HotWaterTemperatureDataValue.Units;
            UnitsColdWaterTemperature.Text = MechanicalDraftPerformanceCurveViewModel.ColdWaterTemperatureDataValue.Units;
            UnitsWetBulbTemperature.Text = MechanicalDraftPerformanceCurveViewModel.WetBulbTemperatureDataValue.Units;
            UnitsDryBulbTemperature.Text = MechanicalDraftPerformanceCurveViewModel.DryBulbTemperatureDataValue.Units;
            UnitsFanDriverPower.Text = MechanicalDraftPerformanceCurveViewModel.FanDriverPowerDataValue.Units;
            UnitsBarometricPressure.Text = MechanicalDraftPerformanceCurveViewModel.BarometricPressureDataValue.Units;
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

                if (!LoadTestPoints())
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    returnValue = false;
                    ErrorMessage = string.Empty;
                }

                TestButtonEnable();

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
                stringBuilder.AppendLine(MechanicalDraftPerformanceCurveViewModel.ErrorMessage);
                returnValue = false;
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
                IsChanged = false;
                if (!TowerDesignDataForm.LoadData(MechanicalDraftPerformanceCurveViewModel.DesignData))
                {
                    stringBuilder.AppendLine(TowerDesignDataForm.ErrorMessage);
                    returnValue = false;
                }

                if (!LoadTestPoints())
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    returnValue = false;
                }

                // enable controls
                TestButtonEnable();

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
            else
            {
                IsChanged = false;
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

            if (!returnValue)
            {
                ErrorMessage = stringBuilder.ToString();
            }
            else
            {
                IsChanged = false;
            }

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
                DesignDataButton_Validating(null, null);

                if (TowerDesignDataForm.HasDataChanged)
                {
                    // save design data
                    TowerDesignDataForm.SaveDesignData(MechanicalDraftPerformanceCurveViewModel.DesignData);

                    TestButtonEnable();

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
            if (TestPointTabControl.SelectedIndex >= 0)
            {
                if (MechanicalDraftPerformanceCurveViewModel.Calculate(TestPointTabControl.SelectedIndex))
                {
                    if (MechanicalDraftPerformanceCurveViewModel.DataTable != null)
                    {
                        DataGridView.DataSource = null;
                    }

                    if (MechanicalDraftPerformanceCurveViewModel.DataTable != null)
                    {
                        // Set a DataGrid control's DataSource to the DataView.
                        DataGridView.DataSource = new DataView(MechanicalDraftPerformanceCurveViewModel.DataTable);
                        if (TestPointTabControl.TabPages[TestPointTabControl.SelectedIndex].Controls[0] is TestPointUserControl)
                        {
                            TestPointUserControl testPointUserControl = TestPointTabControl.TabPages[TestPointTabControl.SelectedIndex].Controls[0] as TestPointUserControl;
                            testPointUserControl.LoadData(MechanicalDraftPerformanceCurveViewModel.TestPoints[TestPointTabControl.SelectedIndex]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(MechanicalDraftPerformanceCurveViewModel.ErrorMessage, "Mechanical Draft Performance Curve Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void PrintPage(object sender, PrintPageEventArgs e)
        {
            string reportLabel = string.Empty;

            if (!e.Cancel)
            {
                if (PrintControl.PageIndex == 0)
                {
                    PrintControl.PageIndex = 0;

                    if (PrintControl.Bitmap != null)
                    {
                        PrintControl.Bitmap.Dispose();
                    }

                    PrintControl.DataTables.Clear();

                    if ((MechanicalDraftPerformanceCurveViewModel.IsDesignDataValid)
                    && (MechanicalDraftPerformanceCurveViewModel.CalculationData != null)
                    && (MechanicalDraftPerformanceCurveViewModel.CalculationData.WaterFlowRates != null)
                    && (MechanicalDraftPerformanceCurveViewModel.CalculationData.WaterFlowRates.Count > 0))
                    {
                        if (PrintControl.IsDesignData)
                        {
                            reportLabel = "CTI Tower Design Data";
                            NameValueUnitsDataTable nameValueUnitsDataTable = new NameValueUnitsDataTable();
                            TowerDesignDataForm.FillNameValueUnitsDataTable(nameValueUnitsDataTable);
                            PrintControl.DataTables.Add(nameValueUnitsDataTable.DataTable);
                            foreach (WaterFlowRate waterFlowRate in MechanicalDraftPerformanceCurveViewModel.CalculationData.WaterFlowRates)
                            {
                                PrintControl.DataTables.Add(BuildFlowRateDataTable(waterFlowRate, MechanicalDraftPerformanceCurveViewModel.CalculationData.Ranges));
                            }
                        }
                        else
                        {
                            reportLabel = "CTI Mechanical Draft Performance Curve Test Report";
                            PrintControl.DataTables.Add(BuildDesignTestDataTable(TestPointTabControl.SelectedIndex));
                            PrintControl.DataTables.Add(BuildColdVsRangeDataTable(TestPointTabControl.SelectedIndex));
                            PrintControl.DataTables.Add(BuildColdVsWaterFlowDataTable(TestPointTabControl.SelectedIndex));
                            PrintControl.DataTables.Add(BuildExitAirDataTable());
                            MechanicalDraftPerformanceCurveViewModel.DataTable.TableName = "Test Results";
                            if (MechanicalDraftPerformanceCurveViewModel.CalculationData.TestOutput.Extrapolated)
                            {
                                MechanicalDraftPerformanceCurveViewModel.DataTable.TableName += "\n* Indicates predicted flow is extrapolated.";
                            }
                            PrintControl.DataTables.Add(MechanicalDraftPerformanceCurveViewModel.DataTable);
                        }
                    }
                    else
                    {
                        MessageBox.Show("The design data is not valid", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                }

                float y = 34;

                if (!e.Cancel)
                {
                    if (PrintControl.PageIndex == 0)
                    {
                        e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; // so footer is anti-aliased
                        e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;  // so when we scale up, we smooth out the jaggies somewhat
                        e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                        DrawLogo(e, 0, 0);
                        DrawText(e, 18, FontStyle.Bold, reportLabel, 143, 0, true);
                        if (!string.IsNullOrWhiteSpace(this.PrintControl.Label))
                        {
                            y += DrawText(e, 18, FontStyle.Bold, this.PrintControl.Label, 143, y, true);
                        }
                        y += DrawText(e, 12, FontStyle.Regular, string.Format("Owner: {0}", MechanicalDraftPerformanceCurveViewModel.DesignData.OwnerNameValue), 143, y, true);
                        y += DrawText(e, 12, FontStyle.Regular, string.Format("Project: {0}", MechanicalDraftPerformanceCurveViewModel.DesignData.ProjectNameValue), 143, y, true);
                        y += DrawText(e, 12, FontStyle.Regular, string.Format("Location: {0}", MechanicalDraftPerformanceCurveViewModel.DesignData.LocationValue), 143, y, true);
                        y += DrawText(e, 12, FontStyle.Regular, string.Format("Manufacturer: {0}", MechanicalDraftPerformanceCurveViewModel.DesignData.TowerManufacturerValue), 143, y, true);
                        y += DrawText(e, 12, FontStyle.Regular, string.Format("Tower Type: {0}", MechanicalDraftPerformanceCurveViewModel.DesignData.TowerTypeValue.ToString()), 143, y, true);
                    }
                    else
                    {
                        y = MARGIN;
                    }

                    if (PrintControl.IsDesignData)
                    {
                        y += DrawTowerDesignData(e, y);
                    }
                    else
                    {
                        y += DrawPerformanceData(e, y);
                        if (!e.HasMorePages)
                        {
                            y += DrawText(e, 8, FontStyle.Regular, "This test result is only certified by CTI if the test data was collected by a CTI Licensed Testing Agency. See www.cti.org for an agency list.", 0, y, false);
                        }
                    }

                    e.Graphics.DrawString("CTI Toolkit 4.0 Beta Version",
                                        new Font("Times New Roman", 16),
                                        new SolidBrush(Color.Red),
                                        MARGIN, e.PageSettings.Bounds.Height - MARGIN);
                    Font font = new Font("Times New Roman", 8);
                    string name = MechanicalDraftPerformanceCurveViewModel.DataFilenameInputValue;
                    if (!PrintControl.IsDesignData)
                    {
                        name += "\\" + TestPointTabControl.TabPages[TestPointTabControl.SelectedIndex].Name;
                    }
                    SizeF size = e.Graphics.MeasureString(name, font);
                    e.Graphics.DrawString(name,
                                          font,
                                          new SolidBrush(Color.Black),
                                          e.PageSettings.Bounds.Width - size.Width - MARGIN, e.PageSettings.Bounds.Height - MARGIN);
                }

                if (!e.HasMorePages || e.Cancel)
                {
                    PrintControl.PageIndex = 0;
                }
            }
        }

        private float DrawTowerDesignData(PrintPageEventArgs e, float y)
        {
            if (PrintControl.PageIndex == 0)
            {
                y += DrawText(e, 12, FontStyle.Bold, "Cooling Tower Design Data:", 3, y, false);
                if (PrintControl.DataTables.Count > 0)
                {
                    y += DrawDataTable(e, PrintControl.DataTables[0], 7, y);
                    PrintControl.DataTableIndex = 1;
                }
            }

            return DrawTowerDesignCurveData(e, y); 
        }

        private float DrawTowerDesignCurveData(PrintPageEventArgs e, float y)
        {
            float totalHeight = 0;
            float height;

            if (PrintControl.PageIndex == 0)
            {
                height = DrawText(e, 12, FontStyle.Bold, "Tower Design Curve Data:", 3, y, false);
                y += height;
                totalHeight += height;
            }

            if (PrintControl.DataTables.Count > 0)
            {
                for (int i = PrintControl.DataTableIndex; i < PrintControl.DataTables.Count; i++)
                {
                    height = GetDataTableHeight(e, PrintControl.DataTables[i]);
                    if (y + height < e.PageSettings.Bounds.Height - 80)
                    {
                        height = DrawDataTable(e, PrintControl.DataTables[i], 7, y);
                        y += height;
                        totalHeight += height;
                    }
                    else
                    {
                        PrintControl.DataTableIndex = i;
                        PrintControl.PageIndex++;
                        e.HasMorePages = true;
                        break;
                    }
                }
            }
            return totalHeight;
        }

        private float DrawPerformanceData(PrintPageEventArgs e, float y)
        {
            float totalHeight = 0;

            if (PrintControl.DataTables.Count > 0)
            {
                for (int i = PrintControl.DataTableIndex; i < PrintControl.DataTables.Count; i++)
                {
                    float height = GetDataTableHeight(e, PrintControl.DataTables[i]);
                    if (y + height < e.PageSettings.Bounds.Height - 80)
                    {
                        height = DrawDataTable(e, PrintControl.DataTables[i], 7, y);
                        totalHeight += height;
                        y += height;
                    }
                    else
                    {
                        PrintControl.DataTableIndex = i;
                        PrintControl.PageIndex++;
                        e.HasMorePages = true;
                        break;
                    }
                }
            }
            return totalHeight;
        }

        private DataTable BuildFlowRateDataTable(WaterFlowRate waterFlowRate, List<double> ranges)
        {
            DataTable dataTable = new DataTable();
            DataColumn column;

            dataTable.TableName = string.Format("Water Flow Rate: {0} {1}", waterFlowRate.FlowRate, MechanicalDraftPerformanceCurveViewModel.DesignData.WaterFlowRateDataValue.Units);

            // Create Name column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Wet Bulb Temperature";
            dataTable.Columns.Add(column);

            foreach (double range in ranges)
            {
                // Create Value column.
                column = new DataColumn();
                column.DataType = Type.GetType("System.String");
                column.ColumnName = string.Format("Range: {0}", range.ToString("F2"));
                dataTable.Columns.Add(column);
            }

            // Create Units column.
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Units";
            dataTable.Columns.Add(column);

            foreach (WetBulbTemperature wetBulbTemperature in waterFlowRate.WetBulbTemperatures)
            {
                DataRow row = dataTable.NewRow();
                row[0] = wetBulbTemperature.Temperature.ToString("F2");
                int columnIndex = 1;
                foreach (double temperature in wetBulbTemperature.ColdWaterTemperatures)
                {
                    row[columnIndex++] = temperature.ToString("F2");
                }
                row[columnIndex] = MechanicalDraftPerformanceCurveViewModel.DesignData.WetBulbTemperatureDataValue.Units;
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        private void DesignTestColumns(DataTable dataTable)
        {
            // Declare DataColumn and DataRow variables.
            DataColumn column;
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Parameters";
            dataTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Design";
            dataTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Test";
            dataTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Units";
            dataTable.Columns.Add(column);
        }

        private DataTable BuildDesignTestDataTable(int index)
        {
            DataTable dataTable = new DataTable();
            dataTable.TableName = "Cooling Tower Design and Test Data:";
            DesignTestColumns(dataTable);

            AddRowDesignTest(dataTable, MechanicalDraftPerformanceCurveViewModel.DesignData.WaterFlowRateDataValue, MechanicalDraftPerformanceCurveViewModel.TestPoints[index].WaterFlowRateDataValue);
            AddRowDesignTest(dataTable, MechanicalDraftPerformanceCurveViewModel.DesignData.HotWaterTemperatureDataValue, MechanicalDraftPerformanceCurveViewModel.TestPoints[index].HotWaterTemperatureDataValue);
            AddRowDesignTest(dataTable, MechanicalDraftPerformanceCurveViewModel.DesignData.ColdWaterTemperatureDataValue, MechanicalDraftPerformanceCurveViewModel.TestPoints[index].ColdWaterTemperatureDataValue);
            AddRowDesignTest(dataTable, MechanicalDraftPerformanceCurveViewModel.DesignData.WetBulbTemperatureDataValue, MechanicalDraftPerformanceCurveViewModel.TestPoints[index].WetBulbTemperatureDataValue);
            AddRowDesignTest(dataTable, MechanicalDraftPerformanceCurveViewModel.DesignData.DryBulbTemperatureDataValue, MechanicalDraftPerformanceCurveViewModel.TestPoints[index].DryBulbTemperatureDataValue);
            AddRowDesignTest(dataTable, MechanicalDraftPerformanceCurveViewModel.DesignData.FanDriverPowerDataValue, MechanicalDraftPerformanceCurveViewModel.TestPoints[index].FanDriverPowerDataValue);
            AddRowDesignTest(dataTable, MechanicalDraftPerformanceCurveViewModel.DesignData.BarometricPressureDataValue, MechanicalDraftPerformanceCurveViewModel.TestPoints[index].BarometricPressureDataValue);
            AddRowDesignTest(dataTable, MechanicalDraftPerformanceCurveViewModel.DesignData.LiquidToGasRatioDataValue, MechanicalDraftPerformanceCurveViewModel.TestPoints[index].LiquidToGasRatioDataValue);
            return dataTable;
        }

        private void AddRowDesignTest(DataTable dataTable, DataValue design, DataValue test)
        {
            DataRow row = dataTable.NewRow();
            row["Parameters"] = design.InputMessage;
            row["Design"] = design.InputValue;
            row["Test"] = test.InputValue;
            row["Units"] = design.Units;
            dataTable.Rows.Add(row);
        }

        private DataTable BuildColdVsRangeDataTable(int index)
        {
            DataTable dataTable = new DataTable();
            dataTable.TableName = string.Format("Cold Water Temperatures vs. Range\nAt {0} {1} Test Wet Bulb Temperature", MechanicalDraftPerformanceCurveViewModel.TestPoints[index].WetBulbTemperatureDataValue.InputValue, MechanicalDraftPerformanceCurveViewModel.WetBulbTemperatureDataValue.Units);

            // Declare DataColumn and DataRow variables.
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Range";
            dataTable.Columns.Add(column);

            foreach (WaterFlowRate waterFlowRate in MechanicalDraftPerformanceCurveViewModel.CalculationData.WaterFlowRates)
            {
                column = new DataColumn();
                column.DataType = Type.GetType("System.String");
                column.ColumnName = string.Format("{0} {1}", waterFlowRate.FlowRate.ToString("F2"), MechanicalDraftPerformanceCurveViewModel.DesignData.WaterFlowRateDataValue.Units);
                dataTable.Columns.Add(column);
            }

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Units";
            dataTable.Columns.Add(column);

            for (int i = 0; i < MechanicalDraftPerformanceCurveViewModel.CalculationData.Ranges.Count; i++)
            {
                AddRowColdVsRange(dataTable, i, MechanicalDraftPerformanceCurveViewModel.CalculationData.Ranges[i], MechanicalDraftPerformanceCurveViewModel.CalculationData.WaterFlowRates, MechanicalDraftPerformanceCurveViewModel.DesignData.ColdWaterTemperatureDataValue.Units);
            }
            return dataTable;
        }

        private void AddRowColdVsRange(DataTable dataTable, int i, double range, List<WaterFlowRate> waterFlowRates, string units)
        {
            DataRow row = dataTable.NewRow();
            row["range"] = range.ToString("F2");
            foreach (WaterFlowRate waterFlowRate in waterFlowRates)
            {
                string columnName = string.Format("{0} {1}", waterFlowRate.FlowRate.ToString("F2"), MechanicalDraftPerformanceCurveViewModel.DesignData.WaterFlowRateDataValue.Units);
                row[columnName] = waterFlowRate.Yfit[i].ToString("F2");
            }
            row["Units"] = units;
            dataTable.Rows.Add(row);
        }

        private DataTable BuildColdVsWaterFlowDataTable(int index)
        {
            DataTable dataTable = new DataTable();

            dataTable.TableName = string.Format("Cold Water Temperatures vs. Water Flow\nAt {0} {1} Test Wet Bulb Temperature and {2} {3} Test Range",
                    MechanicalDraftPerformanceCurveViewModel.TestPoints[index].WetBulbTemperatureDataValue.InputValue,
                    MechanicalDraftPerformanceCurveViewModel.TestPoints[index].WetBulbTemperatureDataValue.Units,
                    (MechanicalDraftPerformanceCurveViewModel.TestPoints[index].HotWaterTemperatureDataValue.Current - MechanicalDraftPerformanceCurveViewModel.TestPoints[index].ColdWaterTemperatureDataValue.Current).ToString("F2"),
                    MechanicalDraftPerformanceCurveViewModel.TestPoints[index].WetBulbTemperatureDataValue.Units);

            // Declare DataColumn and DataRow variables.
            DataColumn column;
            foreach (WaterFlowRate waterFlowRate in MechanicalDraftPerformanceCurveViewModel.CalculationData.WaterFlowRates)
            {
                column = new DataColumn();
                column.DataType = Type.GetType("System.String");
                column.ColumnName = string.Format("{0} {1}", waterFlowRate.FlowRate.ToString("F2"), MechanicalDraftPerformanceCurveViewModel.DesignData.WaterFlowRateDataValue.Units);
                dataTable.Columns.Add(column);
            }

            DataRow row = dataTable.NewRow();
            for (int i = 0; i < MechanicalDraftPerformanceCurveViewModel.CalculationData.Ranges.Count; i++)
            {
                AddRowColdVsWaterFLow(row, i, MechanicalDraftPerformanceCurveViewModel.CalculationData.Ranges[i], MechanicalDraftPerformanceCurveViewModel.CalculationData.InterpolateRanges[i], MechanicalDraftPerformanceCurveViewModel.DesignData.ColdWaterTemperatureDataValue.Units);
            }
            dataTable.Rows.Add(row);
            return dataTable;
        }

        private void AddRowColdVsWaterFLow(DataRow row, int i, double range, double interpolateRange, string units)
        {
            row[i] = string.Format("{0} {1}", interpolateRange.ToString("F2"), units);
        }

        private DataTable BuildExitAirDataTable()
        {
            DataTable dataTable = new DataTable();
            
            if (TowerDesignDataForm.TowerDesignData.TowerTypeValue == TOWER_TYPE.Induced)
            {
                dataTable.TableName = "Exit Air Properties";
            }
            else
            {
                dataTable.TableName = "Inlet Air Properties";
            }

            // Declare DataColumn and DataRow variables.
            DesignTestColumns(dataTable);

            Units Units;
            if (IsInternationalSystemOfUnits_SI)
            {
                Units = new UnitsIS();
            }
            else
            {
                Units = new UnitsIP();
            }

            AddRowExitAir(dataTable, "Wet Bulb Temperature", 
                                      MechanicalDraftPerformanceCurveViewModel.CalculationData.DesignOutput.WetBulbTemperature, 
                                      MechanicalDraftPerformanceCurveViewModel.CalculationData.TestOutput.WetBulbTemperature,
                                      Units.Temperature,
                                      "F2");
            AddRowExitAir(dataTable, "Density",
                                      MechanicalDraftPerformanceCurveViewModel.CalculationData.DesignOutput.Density,
                                      MechanicalDraftPerformanceCurveViewModel.CalculationData.TestOutput.Density,
                                      Units.Density,
                                      "F5");
            AddRowExitAir(dataTable, "Specific Volume",
                                      MechanicalDraftPerformanceCurveViewModel.CalculationData.DesignOutput.SpecificVolume,
                                      MechanicalDraftPerformanceCurveViewModel.CalculationData.TestOutput.SpecificVolume,
                                      Units.SpecificVolume,
                                      "F4");
            AddRowExitAir(dataTable, "Enthalpy", 
                                      MechanicalDraftPerformanceCurveViewModel.CalculationData.DesignOutput.Enthalpy, 
                                      MechanicalDraftPerformanceCurveViewModel.CalculationData.TestOutput.Enthalpy,
                                      Units.Enthalpy,
                                      "F4");

            return dataTable;
        }

        private void AddRowExitAir(DataTable dataTable, string name,  double value1, double value2, string units, string format)
        {
            DataRow row = dataTable.NewRow();
            row[0] = name;
            row[1] = value1.ToString(format);
            row[2] = value2.ToString(format);
            row[3] = units;
            dataTable.Rows.Add(row);
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            ValidatedForm();
            Calculate();
        }

        private void ViewGraph_Click(object sender, EventArgs e)
        {
            Calculate();
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
                    TestButtonEnable();
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

        private void TestButtonEnable()
        {
            if (MechanicalDraftPerformanceCurveViewModel.IsDesignDataValid)
            {
                DesignDataButton_Validated(null, null);

                // enable controls
                AddTestPointButton.Enabled = true;
                AddTestPointName.Enabled = true;

                if (MechanicalDraftPerformanceCurveViewModel.TestPoints.Count > 0)
                {
                    CalculateButton.Enabled = true;
                    ViewGraph.Enabled = true;
                }
            }
            else
            {
                DesignDataButton_Validating(null, null);
            }
        }

        private void TestPointDelete_Click(object sender, EventArgs e)
        {
            CustomMenuItem customMenuItem = sender as CustomMenuItem;
            TestPointTabControl.TabPages.Remove(TestPointTabControl.TabPages[customMenuItem.TabIndex]);
            TestButtonEnable();
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

            if(TestPointTabControl.SelectedIndex >= 0 
            && TestPointTabControl.TabPages.Count > TestPointTabControl.SelectedIndex 
            && MechanicalDraftPerformanceCurveViewModel.TestPoints.Count > TestPointTabControl.SelectedIndex)
            {
                if (TestPointTabControl.TabPages[TestPointTabControl.SelectedIndex].Controls[0] is TestPointUserControl)
                {
                    MechanicalDraftPerformanceCurveViewModel.TestPoints[TestPointTabControl.SelectedIndex].LiquidToGasRatioDataValue.UpdateCurrentValue(0);
                    if(TestPointTabControl.TabPages[TestPointTabControl.SelectedIndex].Controls.Count > 1 
                    && TestPointTabControl.TabPages[TestPointTabControl.SelectedIndex].Controls[0] is TestPointUserControl)
                    {
                        TestPointUserControl testPointUserControl = TestPointTabControl.TabPages[TestPointTabControl.SelectedIndex].Controls[0] as TestPointUserControl;
                        testPointUserControl.LoadData(MechanicalDraftPerformanceCurveViewModel.TestPoints[TestPointTabControl.SelectedIndex]);
                    }
                }
            }
        }

        private void TestPointTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear output data and calculate values
            DataGridView.DataSource = null;
            Calculate();
        }

        public override void ValidatedForm()
        {
            DesignDataButton_Validated(null, null);

            foreach (TabPage tabPage in TestPointTabControl.TabPages)
            {
                try
                {
                    TestPointUserControl testPointUserControl = tabPage.Controls[0] as TestPointUserControl;
                    if (testPointUserControl != null)
                    {
                        testPointUserControl.ValidatedForm();
                    }
                }
                catch
                { }
            }
        }

        private void DesignDataButton_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(DesignDataButton, "");
        }

        private void DesignDataButton_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MechanicalDraftPerformanceCurveViewModel.IsDesignDataValid = MechanicalDraftPerformanceCurveViewModel.DesignData.IsValid();
            if (!MechanicalDraftPerformanceCurveViewModel.IsDesignDataValid)
            {
                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(DesignDataButton, MechanicalDraftPerformanceCurveViewModel.DesignData.ErrorMessage + " Calculate and View Graph buttons will not be active until the design data is correct.");
            }
        }
    }
}
