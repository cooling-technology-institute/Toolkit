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
        public MechanicalDraftPerformanceCurvePrinterOutput(int bottomOfPage, string optionalLabel, int index, MechanicalDraftPerformanceCurveViewModel viewModel)
        {
            InitializeComponent();

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
            ColdVsRange.Text = string.Format("At {0} {1} Test Wet Bulb Temperature", viewModel.TestPoints[index].WetBulbTemperatureDataValue.InputValue, viewModel.WetBulbTemperatureDataValue.Units);
            ColdVsRangeDataGridView.DataSource = BuildColdVsRangeDataTable(viewModel);
            ColdVsRangeDataGridView.Size = new Size(ColdVsRangeDataGridView.Size.Width, (ColdVsRangeDataGridView.Rows.Count + 1) * 22);

            ColdVsWaterFlowTitle.Location = new System.Drawing.Point(ColdVsWaterFlowTitle.Location.X, ColdVsRangeDataGridView.Location.Y + ColdVsRangeDataGridView.Height + 20);
            ColdVsWaterFlow.Location = new System.Drawing.Point(ColdVsWaterFlow.Location.X, ColdVsWaterFlowTitle.Location.Y + ColdVsWaterFlowTitle.Height + 2);
            ColdVsWaterFlowDataGridView.Location = new System.Drawing.Point(ColdVsWaterFlowDataGridView.Location.X, ColdVsWaterFlow.Location.Y + ColdVsWaterFlow.Height + 2);
            ColdVsWaterFlow.Text = string.Format("At {0} {1} Test Wet Bulb Temperature and {2} {1} Test Range", 
                    viewModel.TestPoints[index].WetBulbTemperatureDataValue.InputValue, 
                    viewModel.TestPoints[index].WetBulbTemperatureDataValue.Units,
                    (viewModel.TestPoints[index].HotWaterTemperatureDataValue.Current - viewModel.TestPoints[index].ColdWaterTemperatureDataValue.Current).ToString("F2"),
                    viewModel.TestPoints[index].WetBulbTemperatureDataValue.Units);
            ColdVsWaterFlowDataGridView.DataSource = BuildColdVsWaterFLowDataTable(viewModel);
            ColdVsWaterFlowDataGridView.Size = new Size(ColdVsWaterFlowDataGridView.Size.Width, (ColdVsWaterFlowDataGridView.Rows.Count + 1) * 22);

            int y = ColdVsWaterFlowDataGridView.Location.Y + ColdVsWaterFlowDataGridView.Height + 2;
            if (!string.IsNullOrWhiteSpace(viewModel.CalculationData.TestOutput.ErrorMessage))
            {
                PredictedFlowCaution.Text = viewModel.CalculationData.TestOutput.ErrorMessage;
                PredictedFlowCaution.Location = new System.Drawing.Point(PredictedFlowCaution.Location.X, y);
                y += PredictedFlowCaution.Location.Y + PredictedFlowCaution.Height + 20;
                PredictedFlowCaution.Visible = true;
            }
            else
            {
                PredictedFlowCaution.Visible = false;
                y += 20;
            }
            if (viewModel.DesignData.TowerTypeValue == TOWER_TYPE.Induced)
            {
                ExitAirTitle.Text = "Exit Air Properties";
            }
            else
            {
                ExitAirTitle.Text = "Inlet Air Properties";
            }
            ExitAirTitle.Location = new System.Drawing.Point(ExitAirTitle.Location.X, y);
            ExitAirDataGridView.Location = new System.Drawing.Point(ExitAirDataGridView.Location.X, ExitAirTitle.Location.Y + ExitAirTitle.Height + 2);
            ExitAirDataGridView.DataSource = BuildExitAirDataTable(viewModel);
            ExitAirDataGridView.Size = new Size(ExitAirDataGridView.Size.Width, (ExitAirDataGridView.Rows.Count + 1) * 22);

            TestResultTitle.Location = new System.Drawing.Point(TestResultTitle.Location.X, ExitAirDataGridView.Location.Y + ExitAirDataGridView.Height + 20);
            TestResultDataGridView.Location = new System.Drawing.Point(TestResultDataGridView.Location.X, TestResultTitle.Location.Y + TestResultTitle.Height + 2);
            TestResultDataGridView.DataSource = viewModel.NameValueUnitsDataTable.DataTable;
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

            AddRowDesignTest(dataTable, viewModel.DesignData.WaterFlowRateDataValue, viewModel.TestPoints[index].WaterFlowRateDataValue);
            AddRowDesignTest(dataTable, viewModel.DesignData.HotWaterTemperatureDataValue, viewModel.TestPoints[index].HotWaterTemperatureDataValue);
            AddRowDesignTest(dataTable, viewModel.DesignData.ColdWaterTemperatureDataValue, viewModel.TestPoints[index].ColdWaterTemperatureDataValue);
            AddRowDesignTest(dataTable, viewModel.DesignData.WetBulbTemperatureDataValue, viewModel.TestPoints[index].WetBulbTemperatureDataValue);
            AddRowDesignTest(dataTable, viewModel.DesignData.DryBulbTemperatureDataValue, viewModel.TestPoints[index].DryBulbTemperatureDataValue);
            AddRowDesignTest(dataTable, viewModel.DesignData.FanDriverPowerDataValue, viewModel.TestPoints[index].FanDriverPowerDataValue);
            AddRowDesignTest(dataTable, viewModel.DesignData.BarometricPressureDataValue, viewModel.TestPoints[index].BarometricPressureDataValue);
            AddRowDesignTest(dataTable, viewModel.DesignData.LiquidToGasRatioDataValue, viewModel.TestPoints[index].LiquidToGasRatioDataValue);
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

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Units";
            dataTable.Columns.Add(column);

            for (int i = 0; i < viewModel.CalculationData.Ranges.Count; i++)
            {
                AddRowColdVsRange(dataTable, i, viewModel.CalculationData.Ranges[i], viewModel.CalculationData.WaterFlowRates, viewModel.DesignData.ColdWaterTemperatureDataValue.Units);
            }
            return dataTable;
        }

        private void AddRowColdVsRange(DataTable dataTable, int i, double range, List<WaterFlowRate> waterFlowRates, string units)
        {
            DataRow row = dataTable.NewRow();
            row["range"] = range.ToString("F2");
            foreach (WaterFlowRate waterFlowRate in waterFlowRates)
            {
                row[waterFlowRate.FlowRate.ToString("F2")] = waterFlowRate.Yfit[i].ToString("F2");
            }
            row["Units"] = units;
            dataTable.Rows.Add(row);
        }

        private DataTable BuildColdVsWaterFLowDataTable(MechanicalDraftPerformanceCurveViewModel viewModel)
        {
            DataTable dataTable = new DataTable();

            // Declare DataColumn and DataRow variables.
            DataColumn column;

            //column = new DataColumn();
            //column.DataType = Type.GetType("System.String");
            //column.ColumnName = "Range";
            //dataTable.Columns.Add(column);

            //column = new DataColumn();
            //column.DataType = Type.GetType("System.String");
            //column.ColumnName = "Units";
            //dataTable.Columns.Add(column);

            //column = new DataColumn();
            //column.DataType = Type.GetType("System.String");
            //column.ColumnName = "Cold Water Temperature";
            //dataTable.Columns.Add(column);

            //column = new DataColumn();
            //column.DataType = Type.GetType("System.String");
            //column.ColumnName = "CWT Units";
            //dataTable.Columns.Add(column);

            foreach (WaterFlowRate waterFlowRate in viewModel.CalculationData.WaterFlowRates)
            {
                column = new DataColumn();
                column.DataType = Type.GetType("System.String");
                column.ColumnName = string.Format("{0} {1}", waterFlowRate.FlowRate.ToString("F2"), viewModel.DesignData.WaterFlowRateDataValue.Units); 
                dataTable.Columns.Add(column);
            }

            DataRow row = dataTable.NewRow();
            for (int i = 0; i < viewModel.CalculationData.Ranges.Count; i++)
            {
                AddRowColdVsWaterFLow(row, i, viewModel.CalculationData.Ranges[i], viewModel.CalculationData.InterpolateRanges[i], viewModel.DesignData.ColdWaterTemperatureDataValue.Units);
            }
            dataTable.Rows.Add(row);
            return dataTable;
        }

        private void AddRowColdVsWaterFLow(DataRow row, int i, double range, double interpolateRange, string units)
        {
            row[i] = string.Format("{0} {1}", interpolateRange.ToString("F2"), units);
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

            AddRowExitAir(dataTable, "Design", viewModel.CalculationData.DesignOutput);
            AddRowExitAir(dataTable, "Test", viewModel.CalculationData.TestOutput);

            return dataTable;
        }

        private void AddRowExitAir(DataTable dataTable, string rowId, MechanicalDraftPerformanceCurveOutput data)
        {
            DataRow row = dataTable.NewRow();
            row[0] = rowId;
            row[1] = data.WetBulbTemperature.ToString("F2");
            row[2] = data.Density.ToString("F5");
            row[3] = data.SpecificVolume.ToString("F4");
            row[4] = data.Enthalpy.ToString("F4");
            dataTable.Rows.Add(row);
        }
    }
}
