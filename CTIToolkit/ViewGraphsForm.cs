using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ViewModels;
using CalculationLibrary;

namespace CTIToolkit
{
    public partial class ViewGraphsForm : Form
    {
        private MechanicalDraftPerformanceCurveCalculationLibrary CalculationLibrary { get; set; }

        public ViewGraphsForm(MechanicalDraftPerformanceCurveCalculationData calculationData)
        {
            InitializeComponent();

            CalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();

            TabControl.TabPages.Clear();
            foreach(WaterFlowRate waterFlowRate in calculationData.WaterFlowRates)
            {
                AddFlowRateTabPage(calculationData, waterFlowRate);
            }

            if (calculationData.TowerTestData.WetBulbTemperature != 0.0)
            {
                AddCrossPlot1(calculationData);
                AddCrossPlot2(calculationData);
            }
        }

        private void AddFlowRateTabPage(MechanicalDraftPerformanceCurveCalculationData calculationData, WaterFlowRate waterFlowRate)
        {
            TabPage tabPage = new TabPage();
            tabPage.Text = string.Format("Flow = {0}", waterFlowRate.FlowRate.ToString("F2"));
            Chart chart = new Chart();

            chart.Titles.Add(string.Format("Flow = {0} {1}", waterFlowRate.FlowRate.ToString("F2"), (calculationData.IsInternationalSystemOfUnits_SI) ? ConstantUnits.LitersPerSecond : ConstantUnits.GallonsPerMinute));
            chart.Dock = DockStyle.Fill;
            chart.ChartAreas.Add(new ChartArea());

            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            //chart.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            //chart.ChartAreas[0].AxisX.MajorTickMark.Interval = 1;
            chart.ChartAreas[0].AxisX.MinorTickMark.Interval = 1;
            chart.ChartAreas[0].AxisX.Minimum = calculationData.FindMinimumWetBulbTempurature(waterFlowRate);
            chart.ChartAreas[0].AxisX.Maximum = calculationData.FindMaximumWetBulbTempurature(waterFlowRate);
            chart.ChartAreas[0].AxisX.Title = "Wet Bulb Temperature";
            chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart.ChartAreas[0].CursorX.AutoScroll = true;
            chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;

            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            //chart.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            //chart.ChartAreas[0].AxisY.MajorTickMark.Interval = 1;
            chart.ChartAreas[0].AxisY.MinorTickMark.Interval = 1;
            chart.ChartAreas[0].AxisY.Minimum = calculationData.FindMinimumColdWaterTempurature(waterFlowRate);
            chart.ChartAreas[0].AxisY.Maximum = calculationData.FindMaximumColdWaterTempurature(waterFlowRate);
            chart.ChartAreas[0].AxisY.Title = "Cold Water Temperature";
            chart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart.ChartAreas[0].CursorY.AutoScroll = true;
            chart.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            Legend legend = new Legend();
            chart.Legends.Add(legend);
            //chart.Legends[0].Title = "Ranges";

            for (int rangeIndex = 0; rangeIndex < calculationData.Ranges.Count; rangeIndex++)
            {
                Series series = new Series();
                series.ChartArea = "ChartArea1";
                series.ChartType = SeriesChartType.Line;
                series.Name = string.Format("Range {0} ({1})", rangeIndex + 1, calculationData.Ranges[rangeIndex].ToString("F2"));

                foreach (Point point in waterFlowRate.RangePoints[rangeIndex].Points)
                {
                    series.Points.AddXY(point.X, point.Y);
                }

                chart.Series.Add(series);
            }

            //
            // Add series for Test WBT
            //
            if (calculationData.TowerTestData.WetBulbTemperature != 0.0)
            {
                Series series = new Series();
                series.ChartArea = "ChartArea1";
                series.ChartType = SeriesChartType.Line;
                series.Name = string.Format("Test WBT ({0})", calculationData.TowerTestData.WetBulbTemperature.ToString("F2"));
                series.Points.AddXY(calculationData.TowerTestData.WetBulbTemperature, chart.ChartAreas[0].AxisY.Minimum);
                series.Points.AddXY(calculationData.TowerTestData.WetBulbTemperature, chart.ChartAreas[0].AxisY.Maximum);
                chart.Series.Add(series);
            }


            chart.Invalidate();
            tabPage.Controls.Add(chart);
            TabControl.TabPages.Add(tabPage);
        }

        private void AddCrossPlot1(MechanicalDraftPerformanceCurveCalculationData calculationData)
        {
            TabPage tabPage = new TabPage();
            tabPage.Text = "Cross Plot 1";
            Chart chart = new Chart();

            chart.Titles.Add(string.Format("At {0} {1} Test Wet Bulb Temperature", calculationData.TowerTestData.WetBulbTemperature, (calculationData.IsInternationalSystemOfUnits_SI) ? ConstantUnits.TemperatureCelsius : ConstantUnits.TemperatureFahrenheit));
            chart.Dock = DockStyle.Fill;
            chart.ChartAreas.Add(new ChartArea());

            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            //chart.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            //chart.ChartAreas[0].AxisX.MajorTickMark.Interval = 1;
            chart.ChartAreas[0].AxisX.MinorTickMark.Interval = 1;
            //chart.ChartAreas[0].AxisX.Minimum = calculationData.FindMinimumWetBulbTempurature(waterFlowRate);
            //chart.ChartAreas[0].AxisX.Maximum = calculationData.FindMaximumWetBulbTempurature(waterFlowRate);
            chart.ChartAreas[0].AxisX.Title = "Wet Bulb Temperature";
            chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart.ChartAreas[0].CursorX.AutoScroll = true;
            chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;

            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            //chart.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            //chart.ChartAreas[0].AxisY.MajorTickMark.Interval = 1;
            chart.ChartAreas[0].AxisY.MinorTickMark.Interval = 1;
            //chart.ChartAreas[0].AxisY.Minimum = calculationData.FindMinimumColdWaterTempurature(waterFlowRate);
            //chart.ChartAreas[0].AxisY.Maximum = calculationData.FindMaximumColdWaterTempurature(waterFlowRate);
            chart.ChartAreas[0].AxisY.Title = "Cold Water Temperature";
            chart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart.ChartAreas[0].CursorY.AutoScroll = true;
            chart.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            Legend legend = new Legend();
            chart.Legends.Add(legend);
            //chart.Legends[0].Title = "Ranges";

            //for (int rangeIndex = 0; rangeIndex < calculationData.Ranges.Count; rangeIndex++)
            //{
            //    Series series = new Series();
            //    series.ChartArea = "ChartArea1";
            //    series.ChartType = SeriesChartType.Line;
            //    series.Name = string.Format("Range {0} ({1})", rangeIndex + 1, calculationData.Ranges[rangeIndex].ToString("F2"));

            //    foreach (Point point in waterFlowRate.RangePoints[rangeIndex].Points)
            //    {
            //        series.Points.AddXY(point.X, point.Y);
            //    }

            //    chart.Series.Add(series);
            //}

            ////
            //// Add series for Test WBT
            ////
            //if (calculationData.TowerTestData.WetBulbTemperature != 0.0)
            //{
            //    Series series = new Series();
            //    series.ChartArea = "ChartArea1";
            //    series.ChartType = SeriesChartType.Line;
            //    series.Name = string.Format("Test WBT ({0})", calculationData.TowerTestData.WetBulbTemperature.ToString("F2"));
            //    series.Points.AddXY(calculationData.TowerTestData.WetBulbTemperature, chart.ChartAreas[0].AxisY.Minimum);
            //    series.Points.AddXY(calculationData.TowerTestData.WetBulbTemperature, chart.ChartAreas[0].AxisY.Maximum);
            //    chart.Series.Add(series);
            //}


            chart.Invalidate();
            tabPage.Controls.Add(chart);
            TabControl.TabPages.Add(tabPage);
        }

        private void AddCrossPlot2(MechanicalDraftPerformanceCurveCalculationData calculationData)
        {
            TabPage tabPage = new TabPage();
            tabPage.Text = "Cross Plot 2";
            Chart chart = new Chart();

            chart.Titles.Add(string.Format("At {0} {1} Test Wet Bulb Temperature", calculationData.TowerTestData.WetBulbTemperature, (calculationData.IsInternationalSystemOfUnits_SI) ? ConstantUnits.TemperatureCelsius : ConstantUnits.TemperatureFahrenheit));
            chart.Dock = DockStyle.Fill;
            chart.ChartAreas.Add(new ChartArea());

            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            //chart.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            //chart.ChartAreas[0].AxisX.MajorTickMark.Interval = 1;
            chart.ChartAreas[0].AxisX.MinorTickMark.Interval = 1;
            //chart.ChartAreas[0].AxisX.Minimum = calculationData.FindMinimumWetBulbTempurature(waterFlowRate);
            //chart.ChartAreas[0].AxisX.Maximum = calculationData.FindMaximumWetBulbTempurature(waterFlowRate);
            chart.ChartAreas[0].AxisX.Title = "Wet Bulb Temperature";
            chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart.ChartAreas[0].CursorX.AutoScroll = true;
            chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;

            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            //chart.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            //chart.ChartAreas[0].AxisY.MajorTickMark.Interval = 1;
            chart.ChartAreas[0].AxisY.MinorTickMark.Interval = 1;
            //chart.ChartAreas[0].AxisY.Minimum = calculationData.FindMinimumColdWaterTempurature(waterFlowRate);
            //chart.ChartAreas[0].AxisY.Maximum = calculationData.FindMaximumColdWaterTempurature(waterFlowRate);
            chart.ChartAreas[0].AxisY.Title = "Cold Water Temperature";
            chart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart.ChartAreas[0].CursorY.AutoScroll = true;
            chart.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            Legend legend = new Legend();
            chart.Legends.Add(legend);
            //chart.Legends[0].Title = "Ranges";

            //for (int rangeIndex = 0; rangeIndex < calculationData.Ranges.Count; rangeIndex++)
            //{
            //    Series series = new Series();
            //    series.ChartArea = "ChartArea1";
            //    series.ChartType = SeriesChartType.Line;
            //    series.Name = string.Format("Range {0} ({1})", rangeIndex + 1, calculationData.Ranges[rangeIndex].ToString("F2"));

            //    foreach (Point point in waterFlowRate.RangePoints[rangeIndex].Points)
            //    {
            //        series.Points.AddXY(point.X, point.Y);
            //    }

            //    chart.Series.Add(series);
            //}

            ////
            //// Add series for Test WBT
            ////
            //if (calculationData.TowerTestData.WetBulbTemperature != 0.0)
            //{
            //    Series series = new Series();
            //    series.ChartArea = "ChartArea1";
            //    series.ChartType = SeriesChartType.Line;
            //    series.Name = string.Format("Test WBT ({0})", calculationData.TowerTestData.WetBulbTemperature.ToString("F2"));
            //    series.Points.AddXY(calculationData.TowerTestData.WetBulbTemperature, chart.ChartAreas[0].AxisY.Minimum);
            //    series.Points.AddXY(calculationData.TowerTestData.WetBulbTemperature, chart.ChartAreas[0].AxisY.Maximum);
            //    chart.Series.Add(series);
            //}


            chart.Invalidate();
            tabPage.Controls.Add(chart);
            TabControl.TabPages.Add(tabPage);
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {

        }

        private void ReverseButton_Click(object sender, EventArgs e)
        {

        }

        private void OkButton_Click(object sender, EventArgs e)
        {

        }

        private void ViewGraphsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
