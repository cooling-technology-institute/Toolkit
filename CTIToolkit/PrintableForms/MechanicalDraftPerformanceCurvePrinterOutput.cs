using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ViewModels;

namespace CTIToolkit
{
    public partial class MechanicalDraftPerformanceCurvePrinterOutput : UserControl
    {
        string UnitsWaterFlowRate { get; set; }
        string UnitsHotWaterTemperature { get; set; }
        string UnitsColdWaterTemperature { get; set; }
        string UnitsWetBulbTemperature { get; set; }
        string UnitsDryBulbTemperature { get; set; }
        string UnitsFanDriverPower { get; set; }
        string UnitsBarometricPressure { get; set; }

        private void SetUnits(bool IsInternationalSystemOfUnits_SI)
        { 
            if (IsInternationalSystemOfUnits_SI)
            {
                UnitsWaterFlowRate = ConstantUnits.LitersPerSecond;
                UnitsHotWaterTemperature = ConstantUnits.TemperatureCelsius;
                UnitsColdWaterTemperature = ConstantUnits.TemperatureCelsius;
                UnitsWetBulbTemperature = ConstantUnits.TemperatureCelsius;
                UnitsDryBulbTemperature = ConstantUnits.TemperatureCelsius;
                UnitsFanDriverPower = ConstantUnits.Kilowatt;
                UnitsBarometricPressure = ConstantUnits.BarometricPressureKiloPascal;
            }
            else
            {
                UnitsWaterFlowRate = ConstantUnits.GallonsPerMinute;
                UnitsHotWaterTemperature = ConstantUnits.TemperatureFahrenheit;
                UnitsColdWaterTemperature = ConstantUnits.TemperatureFahrenheit;
                UnitsWetBulbTemperature = ConstantUnits.TemperatureFahrenheit;
                UnitsDryBulbTemperature = ConstantUnits.TemperatureFahrenheit;
                UnitsFanDriverPower = ConstantUnits.BrakeHorsepower;
                UnitsBarometricPressure = ConstantUnits.BarometricPressureInchOfMercury;
            }
        }

        public MechanicalDraftPerformanceCurvePrinterOutput(int bottomOfPage, string optionalLabel, int index, MechanicalDraftPerformanceCurveViewModel viewModel)
        {
            InitializeComponent();

            SetUnits(viewModel.IsInternationalSystemOfUnits_SI);
            
            OptionalLabelTextBox.Text = optionalLabel;

            OwnerTextBox.Text = string.Format("Owner: {0}", viewModel.DesignData.OwnerNameValue);
            ProjectTextBox.Text = string.Format("Project: {0}", viewModel.DesignData.ProjectNameValue);
            LocationTextBox.Text = string.Format("Location: {0}", viewModel.DesignData.LocationValue);
            TowerManufacturerTextBox.Text = string.Format("Manufacturer: {0}", viewModel.DesignData.TowerManufacturerValue);
            TowerTypeTextBox.Text = string.Format("Tower Type: {0}", viewModel.DesignData.TowerTypeValue.ToString());

            DesignTestDataGridView.DataSource = BuildDesignTestDataTable(index, viewModel);
            DesignTestDataGridView.Size = new Size(DesignTestDataGridView.Size.Width, (DesignTestDataGridView.Rows.Count + 1) * 22);

            ColdVsRangeTitle.Location = new System.Drawing.Point(ColdVsRangeTitle.Location.X, DesignTestDataGridView.Location.Y + DesignTestDataGridView.Height + 20);
            ColdVsRange.Location = new System.Drawing.Point(ColdVsRange.Location.X, ColdVsRangeTitle.Location.Y + ColdVsRangeTitle.Height + 2);
            ColdVsRangeDataGridView.Location = new System.Drawing.Point(ColdVsRangeDataGridView.Location.X, ColdVsRange.Location.Y + ColdVsRange.Height + 2);
            ColdVsRange.Text = string.Format("At {0} {1} Test Wet Bulb Temperature", viewModel.TestPoints[index].WetBulbTemperatureDataValue.InputValue, UnitsWetBulbTemperature);
            ColdVsRangeDataGridView.DataSource = BuildColdVsRangeDataTable(viewModel);
            ColdVsRangeDataGridView.Size = new Size(ColdVsRangeDataGridView.Size.Width, (ColdVsRangeDataGridView.Rows.Count + 1) * 22);

            ColdVsWaterFlowTitle.Location = new System.Drawing.Point(ColdVsWaterFlowTitle.Location.X, ColdVsRangeDataGridView.Location.Y + ColdVsRangeDataGridView.Height + 20);
            ColdVsWaterFlow.Location = new System.Drawing.Point(ColdVsWaterFlow.Location.X, ColdVsWaterFlowTitle.Location.Y + ColdVsWaterFlowTitle.Height + 2);
            ColdVsWaterFlowDataGridView.Location = new System.Drawing.Point(ColdVsWaterFlowDataGridView.Location.X, ColdVsWaterFlow.Location.Y + ColdVsWaterFlow.Height + 2);
            ColdVsWaterFlow.Text = string.Format("At {0} {1} Test Wet Bulb Temperature and {2} {1} Test Range", 0, UnitsColdWaterTemperature, 0);
            ColdVsWaterFlowDataGridView.DataSource = BuildColdVsWaterFLowDataTable(viewModel);
            ColdVsWaterFlowDataGridView.Size = new Size(ColdVsWaterFlowDataGridView.Size.Width, (ColdVsWaterFlowDataGridView.Rows.Count + 1) * 22);

            ExitAirTitle.Location = new System.Drawing.Point(ExitAirTitle.Location.X, ColdVsWaterFlowDataGridView.Location.Y + ColdVsWaterFlowDataGridView.Height + 20);
            ExitAirDataGridView.Location = new System.Drawing.Point(ExitAirDataGridView.Location.X, ExitAirTitle.Location.Y + ExitAirTitle.Height + 2);
            ExitAirDataGridView.DataSource = BuildExitAirDataTable(viewModel);
            ExitAirDataGridView.Size = new Size(ExitAirDataGridView.Size.Width, (ExitAirDataGridView.Rows.Count + 1) * 22);

            TestResultTitle.Location = new System.Drawing.Point(TestResultTitle.Location.X, ExitAirDataGridView.Location.Y + ExitAirDataGridView.Height + 20);
            TestResultDataGridView.Location = new System.Drawing.Point(TestResultDataGridView.Location.X, TestResultTitle.Location.Y + TestResultTitle.Height + 2);
            TestResultDataGridView.DataSource = viewModel.OutputDataViewModel.NameValueUnitsDataTable.DataTable;
            TestResultDataGridView.Size = new Size(TestResultDataGridView.Size.Width, (TestResultDataGridView.Rows.Count + 1) * 22);

            WarningLabel.Location = new System.Drawing.Point(WarningLabel.Location.X, TestResultDataGridView.Location.Y + TestResultDataGridView.Height + 20);

            this.Height = WarningLabel.Location.Y + 30;
        }

        private DataTable BuildDesignTestDataTable(int index, MechanicalDraftPerformanceCurveViewModel viewModel)
        {
            DataTable dataTable = new DataTable();

            // Declare DataColumn and DataRow variables.
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
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

            AddRowDesignTest(dataTable, viewModel.DesignData.WaterFlowRateDataValue, viewModel.TestPoints[index].WaterFlowRateDataValue, UnitsWaterFlowRate);
            AddRowDesignTest(dataTable, viewModel.DesignData.HotWaterTemperatureDataValue, viewModel.TestPoints[index].HotWaterTemperatureDataValue, UnitsHotWaterTemperature);
            AddRowDesignTest(dataTable, viewModel.DesignData.ColdWaterTemperatureDataValue, viewModel.TestPoints[index].ColdWaterTemperatureDataValue, UnitsColdWaterTemperature);
            AddRowDesignTest(dataTable, viewModel.DesignData.WetBulbTemperatureDataValue, viewModel.TestPoints[index].WetBulbTemperatureDataValue, UnitsWetBulbTemperature);
            AddRowDesignTest(dataTable, viewModel.DesignData.DryBulbTemperatureDataValue, viewModel.TestPoints[index].DryBulbTemperatureDataValue, UnitsDryBulbTemperature);
            AddRowDesignTest(dataTable, viewModel.DesignData.FanDriverPowerDataValue, viewModel.TestPoints[index].FanDriverPowerDataValue, UnitsFanDriverPower);
            AddRowDesignTest(dataTable, viewModel.DesignData.BarometricPressureDataValue, viewModel.TestPoints[index].BarometricPressureDataValue, UnitsBarometricPressure);
            AddRowDesignTest(dataTable, viewModel.DesignData.LiquidToGasRatioDataValue, viewModel.TestPoints[index].LiquidToGasRatioDataValue, string.Empty);
            return dataTable;
        }

        private void AddRowDesignTest(DataTable dataTable, DataValue design, DataValue test, string units)
        {
            DataRow row = dataTable.NewRow();
            row["Parameters"] = design.InputMessage;
            row["Design"] = design.InputValue;
            row["Test"] = test.InputValue;
            row["Units"] = units;
            dataTable.Rows.Add(row);
        }

        private DataTable BuildColdVsRangeDataTable(MechanicalDraftPerformanceCurveViewModel viewModel)
        {
            DataTable dataTable = new DataTable();

            // Declare DataColumn and DataRow variables.
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Range";
            dataTable.Columns.Add(column);

            foreach(WaterFlowRate waterFlowRate in viewModel.CalculationData.WaterFlowRates)
            {
                column = new DataColumn();
                column.DataType = Type.GetType("System.String");
                column.ColumnName = waterFlowRate.FlowRate.ToString("F2");
                dataTable.Columns.Add(column);
            }

            for (int i = 0; i < viewModel.CalculationData.Ranges.Count; i++)
            {
                AddRowColdVsRange(dataTable, i, viewModel.CalculationData.Ranges[i], viewModel.CalculationData.WaterFlowRates);
            }
            return dataTable;
        }

        private void AddRowColdVsRange(DataTable dataTable, int i, double range, List<WaterFlowRate> waterFlowRates)
        {
            DataRow row = dataTable.NewRow();
            row["range"] = range.ToString("F2");
            foreach (WaterFlowRate waterFlowRate in waterFlowRates)
            {
                row[waterFlowRate.FlowRate.ToString("F2")] = waterFlowRate.Yfit[i].ToString("F2");
            }
            dataTable.Rows.Add(row);
        }

        private DataTable BuildColdVsWaterFLowDataTable(MechanicalDraftPerformanceCurveViewModel viewModel)
        {
            DataTable dataTable = new DataTable();

            // Declare DataColumn and DataRow variables.
            DataColumn column;

            foreach (WaterFlowRate waterFlowRate in viewModel.CalculationData.WaterFlowRates)
            {
                column = new DataColumn();
                column.DataType = Type.GetType("System.String");
                column.ColumnName = waterFlowRate.FlowRate.ToString("F2");
                dataTable.Columns.Add(column);
            }

            for (int i = 0; i < viewModel.CalculationData.Ranges.Count; i++)
            {
                AddRowColdVsWaterFLow(dataTable, i, viewModel.CalculationData.Ranges[i], viewModel.CalculationData.WaterFlowRates);
            }
            return dataTable;
        }

        private void AddRowColdVsWaterFLow(DataTable dataTable, int i, double range, List<WaterFlowRate> waterFlowRates)
        {
            DataRow row = dataTable.NewRow();
            foreach (WaterFlowRate waterFlowRate in waterFlowRates)
            {
                row[waterFlowRate.FlowRate.ToString("F2")] = waterFlowRate.Yfit[i].ToString("F2");
            }
            dataTable.Rows.Add(row);
        }

        private DataTable BuildExitAirDataTable(MechanicalDraftPerformanceCurveViewModel viewModel)
        {
            DataTable dataTable = new DataTable();

            // Declare DataColumn and DataRow variables.

            DataColumn column;
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = " ";
            dataTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Wet Bulb Temperature";
            dataTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Density";
            dataTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Specific Volume";
            dataTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Enthalpy";
            dataTable.Columns.Add(column);

            AddRowExitAir(dataTable, "Design", viewModel.OutputDataViewModel.MechanicalDraftPerformanceCurveOutput.DesignPsychrometricsData);
            AddRowExitAir(dataTable, "Testn", viewModel.OutputDataViewModel.MechanicalDraftPerformanceCurveOutput.TestPsychrometricsData);

            return dataTable;
        }

        private void AddRowExitAir(DataTable dataTable, string rowId, PsychrometricsData psychrometricsData)
        {
            DataRow row = dataTable.NewRow();
            row[0] = rowId;
            row[1] = psychrometricsData.WetBulbTemperature.ToString("F2");
            row[2] = psychrometricsData.Density.ToString("F5");
            row[3] = psychrometricsData.SpecificVolume.ToString("F4");
            row[4] = psychrometricsData.Enthalpy.ToString("F4");
            dataTable.Rows.Add(row);
        }
    }
}
