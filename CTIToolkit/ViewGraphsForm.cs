using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ViewModels;
using CalculationLibrary;
using System.Drawing;
using System.IO;

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
            chart.ChartAreas[0].IsSameFontSizeForAllAxes = true;

            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chart.ChartAreas[0].AxisX.MajorGrid.Interval = 1;
            chart.ChartAreas[0].AxisX.MajorTickMark.Interval = 1.0;
            chart.ChartAreas[0].AxisX.MajorTickMark.IntervalOffset = 1.0;
            chart.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            //chart.ChartAreas[0].AxisX.LabelAutoFitMaxFontSize = 8;
            //chart.ChartAreas[0].AxisX.LabelAutoFitMinFontSize = 7;
            //chart.ChartAreas[0].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.None;
            //chart.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            chart.ChartAreas[0].AxisX.MinorTickMark.Interval = 0.1;
            chart.ChartAreas[0].AxisX.Minimum = calculationData.FindMinimumWetBulbTempurature(waterFlowRate);
            chart.ChartAreas[0].AxisX.Maximum = calculationData.FindMaximumWetBulbTempurature(waterFlowRate);
            chart.ChartAreas[0].AxisX.Title = "Wet Bulb Temperature";
            chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart.ChartAreas[0].CursorX.AutoScroll = true;
            chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;

            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chart.ChartAreas[0].AxisY.MajorGrid.Interval = 1;
            chart.ChartAreas[0].AxisY.MajorTickMark.Interval = 1.0;
            chart.ChartAreas[0].AxisY.MajorTickMark.IntervalOffset = 1.0;
            chart.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;
            //chart.ChartAreas[0].AxisY.LabelAutoFitMaxFontSize = 8;
            //chart.ChartAreas[0].AxisY.LabelAutoFitMinFontSize = 7;
            //chart.ChartAreas[0].AxisY.LabelAutoFitStyle = LabelAutoFitStyles.None;
            //chart.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart.ChartAreas[0].AxisY.MinorTickMark.Interval = 0.1;
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

                foreach (Models.Point point in waterFlowRate.RangePoints[rangeIndex].Points)
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
            // get the tab control chart
            if(TabControl.SelectedIndex != -1)
            {
                Chart chart = TabControl.TabPages[TabControl.SelectedIndex].Controls[0] as Chart;
                if(chart != null)
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        chart.SaveImage(memoryStream, ChartImageFormat.Bmp);
                        Bitmap bm = new Bitmap(memoryStream);
                        Clipboard.SetImage(bm);
                    }
                }
            }
        }

        private void ReverseButton_Click(object sender, EventArgs e)
        {
            // get the tab control chart
            foreach (TabPage tabpage in TabControl.TabPages)
            {
                Chart chart = tabpage.Controls[0] as Chart;
                if (chart != null)
                {
                    if(chart.BackColor == Color.Black)
                    {
                        // set background to white and lines and text to black
                        chart.BackColor = Color.White;
                        if (chart.Legends.Count > 0)
                        {
                            chart.Legends[0].BackColor = Color.White;
                            chart.Legends[0].ForeColor = Color.Black;
                        }

                        if (chart.Titles.Count > 0)
                        {
                            chart.Titles[0].BackColor = Color.White;
                            chart.Titles[0].ForeColor = Color.Black;
                        }

                        if (chart.ChartAreas.Count > 0)
                        {
                            chart.ChartAreas[0].BackColor = Color.White;
                            //chart.ChartAreas[0] = Color.Black;

                            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Black;
                            chart.ChartAreas[0].AxisX.MajorTickMark.LineColor = Color.Black;
                            chart.ChartAreas[0].AxisX.TitleForeColor = Color.Black;
                            chart.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Black;
                            chart.ChartAreas[0].AxisX.LineColor = Color.Black;

                            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Black;
                            chart.ChartAreas[0].AxisY.MajorTickMark.LineColor = Color.Black;
                            chart.ChartAreas[0].AxisY.TitleForeColor = Color.Black;
                            chart.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Black;
                            chart.ChartAreas[0].AxisY.LineColor = Color.Black;
                        }
                    }
                    else
                    {
                        // set background to black and lines and text to white
                        chart.BackColor = Color.Black;
                        if (chart.Legends.Count > 0)
                        {
                            chart.Legends[0].BackColor = Color.Black;
                            chart.Legends[0].ForeColor = Color.White;
                        }

                        if (chart.Titles.Count > 0)
                        {
                            chart.Titles[0].BackColor = Color.Black;
                            chart.Titles[0].ForeColor = Color.White;
                        }

                        if (chart.ChartAreas.Count > 0)
                        {
                            chart.ChartAreas[0].BackColor = Color.Black;

                            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.White;
                            chart.ChartAreas[0].AxisX.MajorTickMark.LineColor = Color.White;
                            chart.ChartAreas[0].AxisX.TitleForeColor = Color.White;
                            chart.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
                            chart.ChartAreas[0].AxisX.LineColor = Color.White;

                            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.White;
                            chart.ChartAreas[0].AxisY.MajorTickMark.LineColor = Color.White;
                            chart.ChartAreas[0].AxisY.TitleForeColor = Color.White;
                            chart.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;
                            chart.ChartAreas[0].AxisY.LineColor = Color.White;
                        }
                    }
                    chart.Invalidate();
                }
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ViewGraphsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
