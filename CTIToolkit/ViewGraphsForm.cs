// Copyright Cooling Technology Institute 2019-2022

using Models;
using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ViewModels;
using CalculationLibrary;
using System.Drawing;
using System.IO;
using System.Text;

namespace CTIToolkit
{
    public partial class ViewGraphsForm : Form
    {
        private MechanicalDraftPerformanceCurveCalculationLibrary CalculationLibrary { get; set; }

        private static Color[] ctiPalette = {
                                                   Color.FromArgb(65, 140, 240),
                                                   Color.FromArgb(252, 180, 65),
                                                   Color.FromArgb(224, 64, 10),
                                                   Color.FromArgb(5, 100, 146),
                                                   Color.Green,
                                                   Color.FromArgb(26, 59, 105),
                                                   Color.FromArgb(255, 227, 130),
                                                   Color.FromArgb(18, 156, 221),
                                                   Color.FromArgb(202, 107, 75),
                                                   Color.FromArgb(0, 92, 219),
                                                   Color.FromArgb(243, 210, 136),
                                                   Color.FromArgb(80, 99, 129),
                                                   Color.FromArgb(241, 185, 168),
                                                   Color.FromArgb(224, 131, 10),
                                                   Color.FromArgb(120, 147, 190),
                                                   Color.Blue,
                                                   Color.Purple,
                                                   Color.Lime,
                                                   Color.Fuchsia,
                                                   Color.Teal,
                                                   Color.Yellow,
                                                   Color.Gray,
                                                   Color.Aqua,
                                                   Color.Navy,
                                                   Color.Maroon,
                                                   Color.Red,
                                                   Color.Olive,
                                                   Color.Silver,
                                                   Color.Tomato,
                                                   Color.Moccasin
                                               };

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
            chart.Palette = ChartColorPalette.None;
            chart.PaletteCustomColors = Globals.CTI_Palette;

            chart.ChartAreas[0].AxisX.Title = "Wet Bulb Temperature";
            chart.ChartAreas[0].AxisX.IsStartedFromZero = true;
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.DarkGray;
            chart.ChartAreas[0].AxisX.MinorTickMark.Enabled = true;
            chart.ChartAreas[0].AxisX.MinorTickMark.LineColor = Color.DarkGray;
            chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            chart.ChartAreas[0].AxisX.Minimum = calculationData.FindMinimumWetBulbTempurature(waterFlowRate);
            chart.ChartAreas[0].AxisX.Maximum = calculationData.FindMaximumWetBulbTempurature(waterFlowRate);
            SetAxisFormats(chart.ChartAreas[0].AxisX, chart.ChartAreas[0].AxisX.Minimum, chart.ChartAreas[0].AxisX.Maximum);
            chart.ChartAreas[0].CursorX.AutoScroll = true;
            chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart.ChartAreas[0].CursorX.Interval = 0.001;

            chart.ChartAreas[0].AxisY.Title = "Cold Water Temperature";
            chart.ChartAreas[0].AxisY.IsStartedFromZero = true;
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.DarkGray;
            chart.ChartAreas[0].AxisY.MinorTickMark.Enabled = true;
            chart.ChartAreas[0].AxisY.MinorTickMark.LineColor = Color.DarkGray;
            chart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart.ChartAreas[0].AxisY.Minimum = calculationData.FindMinimumColdWaterTempurature(waterFlowRate);
            chart.ChartAreas[0].AxisY.Maximum = calculationData.FindMaximumColdWaterTempurature(waterFlowRate);
            SetAxisFormats(chart.ChartAreas[0].AxisY, chart.ChartAreas[0].AxisY.Minimum, chart.ChartAreas[0].AxisY.Maximum);
            chart.ChartAreas[0].CursorY.AutoScroll = true;
            chart.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chart.ChartAreas[0].CursorY.Interval = 0.001;

            Legend legend = new Legend();
            chart.Legends.Add(legend);
            //chart.Legends[0].Title = "Ranges";
            if (calculationData.Ranges != null && calculationData.Ranges.Count > 0)
            {
                for (int rangeIndex = 0; rangeIndex < calculationData.Ranges.Count; rangeIndex++)
                {
                    if (waterFlowRate.RangePoints != null && waterFlowRate.RangePoints.Count > rangeIndex)
                    {
                        Series series = new Series();
                        series.ChartArea = "ChartArea1";
                        series.ChartType = SeriesChartType.Line;
                        series.Name = string.Format("Range {0} ({1} {2})", rangeIndex + 1, calculationData.Ranges[rangeIndex].ToString("F2"), calculationData.IsInternationalSystemOfUnits_SI ? ConstantUnits.TemperatureCelsius : ConstantUnits.TemperatureFahrenheit);
                        foreach (Models.Point point in waterFlowRate.RangePoints[rangeIndex].Points)
                        {
                            series.Points.AddXY(point.X, point.Y);
                        }
                        chart.Series.Add(series);
                    }
                }
            }

            //
            // Add series for Test WBT
            //
            if (calculationData.TowerTestData.WetBulbTemperature != 0.0)
            {
                Series series = new Series();
                series.ChartArea = "ChartArea1";
                series.ChartType = SeriesChartType.Line;
                series.Name = string.Format("Test WBT ({0} {1})", calculationData.TowerTestData.WetBulbTemperature.ToString("F2"), calculationData.IsInternationalSystemOfUnits_SI ? ConstantUnits.TemperatureCelsius : ConstantUnits.TemperatureFahrenheit);
                series.Points.AddXY(calculationData.TowerTestData.WetBulbTemperature, chart.ChartAreas[0].AxisY.Minimum);
                series.Points.AddXY(calculationData.TowerTestData.WetBulbTemperature, chart.ChartAreas[0].AxisY.Maximum);
                if(chart.ChartAreas[0].AxisX.Maximum < calculationData.TowerTestData.WetBulbTemperature)
                {
                    chart.ChartAreas[0].AxisX.Maximum = calculationData.TowerTestData.WetBulbTemperature;
                }
                if (chart.ChartAreas[0].AxisX.Minimum > calculationData.TowerTestData.WetBulbTemperature)
                {
                    chart.ChartAreas[0].AxisX.Minimum = calculationData.TowerTestData.WetBulbTemperature;
                }
                chart.Series.Add(series);
            }

            chart.Invalidate();
            chart.AxisViewChanging += chart_AxisViewChanging;
            chart.AxisViewChanged += chart_AxisViewChanged;
            tabPage.Controls.Add(chart);
            TabControl.TabPages.Add(tabPage);
        }

        private void chart_AxisViewChanging(object sender, ViewEventArgs viewEventArgs)
        {
            if(!double.IsNaN(viewEventArgs.NewPosition) && !double.IsNaN(viewEventArgs.NewSize))
            {
                double minValue = viewEventArgs.NewPosition;
                double maxValue = viewEventArgs.NewPosition + viewEventArgs.NewSize;
                double interval = 0;
                double intMinor = 0;
                GetNiceRoundNumbers(ref minValue, ref maxValue, ref interval, ref intMinor);
                viewEventArgs.NewPosition = minValue;
                viewEventArgs.NewSize = maxValue - minValue;
            }
        }

        private void chart_AxisViewChanged(object sender, ViewEventArgs viewEventArgs)
        {
            if (!double.IsNaN(viewEventArgs.NewPosition) && !double.IsNaN(viewEventArgs.NewSize))
            {
                SetAxisFormats(viewEventArgs.Axis, viewEventArgs.NewPosition, viewEventArgs.NewPosition + viewEventArgs.NewSize);
            }
            else
            {
                SetAxisFormats(viewEventArgs.Axis, viewEventArgs.Axis.Minimum, viewEventArgs.Axis.Maximum);
            }
        }


        //Base10Exponent returns the integer exponent (N) that would yield a
        //number of the form A x Exp10(N), where 1.0 <= |A| < 10.0
        public int Base10Exponent(double num)
        {
            if ((Double.IsNaN(num)) || (num == 0))
            {
                return -Int32.MaxValue;
            }
            else
            {
                return Convert.ToInt32(Math.Floor(Math.Log10(Math.Abs(num))));
            }
        }

        double[] roundMantissa = { 1.00d, 1.20d, 1.40d, 1.60d, 1.80d, 2.00d, 2.50d, 3.00d, 4.00d, 5.00d, 6.00d, 8.00d, 10.00d };
        double[] roundInterval = { 0.20d, 0.20d, 0.20d, 0.20d, 0.20d, 0.50d, 0.50d, 0.50d, 0.50d, 1.00d, 1.00d, 2.00d, 2.00d };
        double[] roundIntMinor = { 0.05d, 0.05d, 0.05d, 0.05d, 0.05d, 0.10d, 0.10d, 0.10d, 0.10d, 0.20d, 0.20d, 0.50d, 0.50d };

        /// <summary>
        /// Gets nice round numbers for the axes. For the horizontal axis, minValue is always 0.
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <param name="axisInterval"></param>
        private void GetNiceRoundNumbers(ref double minValue, ref double maxValue, ref double interval, ref double intMinor)
        {
            double min = Math.Min(minValue, maxValue);
            double max = Math.Max(minValue, maxValue);
            double delta = max - min; //The full range
            //Special handling for zero full range
            if (delta == 0)
            {
                //When min == max == 0, choose arbitrary range of 0 - 1
                if (min == 0)
                {
                    minValue = 0;
                    maxValue = 1;
                    interval = 0.2;
                    intMinor = 0.5;
                    return;
                }
                //min == max, but not zero, so set one to zero
                if (min < 0)
                    max = 0; //min-max are -|min| to 0
                else
                    min = 0; //min-max are 0 to +|max|
                delta = max - min;
            }

            int N = Base10Exponent(delta);
            double tenToN = Math.Pow(10, N);
            double A = delta / tenToN;
            //At this point delta = A x Exp10(N), where
            // 1.0 <= A < 10.0 and N = integer exponent value
            //Now, based on A select a nice round interval and maximum value
            for (int i = 0; i < roundMantissa.Length; i++)
            {
                if (A <= roundMantissa[i])
                {
                    interval = roundInterval[i] * tenToN;
                    intMinor = roundIntMinor[i] * tenToN;
                    break;
                }
            }
            minValue = interval * Math.Floor(min / interval);
            maxValue = interval * Math.Ceiling(max / interval);
        }

        /// <summary>
        /// Returns a consistent format string with minimum necessary precision for a range with intervals
        /// </summary>
        /// <param name="interval">Range interval</param>
        /// <param name="minVal">Minimum value of the range</param>
        /// <param name="maxVal">Maximum value of the range</param>
        /// <param name="xtraDigits">Extra digits to display beyond those for minimum necessary precision</param>
        /// <returns></returns>
        public string RangeFormatString(ref double interval, double minVal, double maxVal, int xtraDigits, ref double minInt)
        {
            double minValue = minVal;
            double maxValue = maxVal;
            double intv = 0;

            GetNiceRoundNumbers(ref minValue, ref maxValue, ref intv, ref minInt);
            interval = intv;

            double maxAbsVal = Math.Max(Math.Abs(minVal), Math.Abs(maxVal));
            int minE = Base10Exponent(interval); //precision to which must show decimal
            int maxE = Base10Exponent(maxAbsVal);
            //(maxE - minE + 1) is the number of significant 
            //digits needed to distinguish two numbers spaced by "interval"
            //if (maxE < -4 || 3 < maxE)
            //    //"Exx" format displays 1 digit to the left of the decimal place, and xx
            //    //digits to the right of the decimal place, so xx = maxE - minE.
            //    return "E" + (xtraDigits + maxE - minE).ToString();
            //else
                //In fixed format, since all digits to the left of the decimal place are
                //displayed by default, for "Fxx" format, xx = -minE or zero, whichever is greater.
                return "F" + xtraDigits + Math.Max(0, -minE).ToString();
        }

        private void SetAxisFormats(Axis axis, double minimum, double maximum)
        {
            double interval = 1;
            double minInt = 1;
            axis.LabelStyle.Format = RangeFormatString(ref interval, minimum, maximum, 0, ref minInt);
            axis.Interval = interval;
            axis.MajorGrid.Interval = interval;
            axis.MinorTickMark.Interval = minInt;
        }

        private void AddCrossPlot1(MechanicalDraftPerformanceCurveCalculationData calculationData)
        {
            TabPage tabPage = new TabPage();
            tabPage.Text = "Cross Plot 1";
            Chart chart = new Chart();

            chart.Titles.Add(string.Format("At {0} {1} Test Wet Bulb Temperature", calculationData.TowerTestData.WetBulbTemperature, (calculationData.IsInternationalSystemOfUnits_SI) ? ConstantUnits.TemperatureCelsius : ConstantUnits.TemperatureFahrenheit));
            chart.Dock = DockStyle.Fill;
            chart.ChartAreas.Add(new ChartArea());
            chart.Palette = ChartColorPalette.None;
            chart.PaletteCustomColors = Globals.CTI_Palette;

            chart.ChartAreas[0].AxisX.Title = "Cooling Range";
            chart.ChartAreas[0].AxisX.IsStartedFromZero = true;
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.DarkGray;
            chart.ChartAreas[0].AxisX.MinorTickMark.Enabled = true;
            chart.ChartAreas[0].AxisX.MinorTickMark.LineColor = Color.DarkGray;
            chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            chart.ChartAreas[0].AxisX.Minimum = calculationData.CrossPlot1.RangeMinimum;
            chart.ChartAreas[0].AxisX.Maximum = calculationData.CrossPlot1.RangeMaximum;
            SetAxisFormats(chart.ChartAreas[0].AxisX, chart.ChartAreas[0].AxisX.Minimum, chart.ChartAreas[0].AxisX.Maximum);
            chart.ChartAreas[0].CursorX.AutoScroll = true;
            chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart.ChartAreas[0].CursorX.Interval = 0.001;

            chart.ChartAreas[0].AxisY.Title = "Cold Water Temperature";
            chart.ChartAreas[0].AxisY.IsStartedFromZero = true;
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.DarkGray;
            chart.ChartAreas[0].AxisY.MinorTickMark.Enabled = true;
            chart.ChartAreas[0].AxisY.MinorTickMark.LineColor = Color.DarkGray;
            chart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart.ChartAreas[0].AxisY.Minimum = calculationData.CrossPlot1.ColdWaterTemperatureMinimum;
            chart.ChartAreas[0].AxisY.Maximum = calculationData.CrossPlot1.ColdWaterTemperatureMaximum;
            SetAxisFormats(chart.ChartAreas[0].AxisY, chart.ChartAreas[0].AxisY.Minimum, chart.ChartAreas[0].AxisY.Maximum);
            chart.ChartAreas[0].CursorY.AutoScroll = true;
            chart.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chart.ChartAreas[0].CursorY.Interval = 0.001;

            Legend legend = new Legend();
            chart.Legends.Add(legend);
            //chart.Legends[0].Title = "Ranges";
            if(calculationData.CrossPlot1.SeriesPoints != null && calculationData.CrossPlot1.SeriesPoints.Count > 0)
            {
                foreach (SeriesPoints seriesPoints in calculationData.CrossPlot1.SeriesPoints)
                {
                    Series series = new Series();
                    series.ChartArea = "ChartArea1";
                    series.ChartType = SeriesChartType.Line;
                    series.Name = seriesPoints.Name;
                    foreach (Models.Point point in seriesPoints.Points)
                    {
                        series.Points.AddXY(point.X, point.Y);
                    }
                    chart.Series.Add(series);
                }
            }

            chart.Invalidate();
            chart.AxisViewChanging += chart_AxisViewChanging;
            chart.AxisViewChanged += chart_AxisViewChanged;
            tabPage.Controls.Add(chart);
            TabControl.TabPages.Add(tabPage);
        }

        private void AddCrossPlot2(MechanicalDraftPerformanceCurveCalculationData calculationData)
        {
            TabPage tabPage = new TabPage();
            tabPage.Text = "Cross Plot 2";
            Chart chart = new Chart();

            chart.Titles.Add(string.Format("At {0} {2} Test Wet Bulb Temperature and {1} {2} Test Range", 
                calculationData.TowerTestData.WetBulbTemperature,
                calculationData.CrossPlot2.TestRange, 
                (calculationData.IsInternationalSystemOfUnits_SI) ? ConstantUnits.TemperatureCelsius : ConstantUnits.TemperatureFahrenheit));

            chart.Dock = DockStyle.Fill;
            chart.ChartAreas.Add(new ChartArea());
            chart.Palette = ChartColorPalette.None;
            chart.PaletteCustomColors = Globals.CTI_Palette;

            chart.ChartAreas[0].AxisX.Title = "Water Flow Rate";
            chart.ChartAreas[0].AxisX.IsStartedFromZero = true;
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.DarkGray;
            chart.ChartAreas[0].AxisX.MinorTickMark.Enabled = true;
            chart.ChartAreas[0].AxisX.MinorTickMark.LineColor = Color.DarkGray;
            chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            chart.ChartAreas[0].AxisX.Minimum = calculationData.CrossPlot2.WaterFlowRateMinimum;
            chart.ChartAreas[0].AxisX.Maximum = calculationData.CrossPlot2.WaterFlowRateMaximum;
            SetAxisFormats(chart.ChartAreas[0].AxisX, chart.ChartAreas[0].AxisX.Minimum, chart.ChartAreas[0].AxisX.Maximum);
            chart.ChartAreas[0].CursorX.AutoScroll = true;
            chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart.ChartAreas[0].CursorX.Interval = 0.001;

            chart.ChartAreas[0].AxisY.Title = "Cold Water Temperature";
            chart.ChartAreas[0].AxisY.IsStartedFromZero = true;
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.DarkGray;
            chart.ChartAreas[0].AxisY.MinorTickMark.Enabled = true;
            chart.ChartAreas[0].AxisY.MinorTickMark.LineColor = Color.DarkGray;
            chart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart.ChartAreas[0].AxisY.Minimum = calculationData.CrossPlot2.ColdWaterTemperatureMinimum;
            chart.ChartAreas[0].AxisY.Maximum = calculationData.CrossPlot2.ColdWaterTemperatureMaximum;
            SetAxisFormats(chart.ChartAreas[0].AxisY, chart.ChartAreas[0].AxisY.Minimum, chart.ChartAreas[0].AxisY.Maximum);
            chart.ChartAreas[0].CursorY.AutoScroll = true;
            chart.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chart.ChartAreas[0].CursorY.Interval = 0.001;

            Legend legend = new Legend();
            chart.Legends.Add(legend);
            //chart.Legends[0].Title = "Ranges";

            if (calculationData.CrossPlot2.SeriesPoints != null && calculationData.CrossPlot2.SeriesPoints.Count > 0)
            {
                foreach (SeriesPoints seriesPoints in calculationData.CrossPlot2.SeriesPoints)
                {
                    Series series = new Series();
                    series.ChartArea = "ChartArea1";
                    series.ChartType = SeriesChartType.Line;
                    series.Name = seriesPoints.Name;
                    foreach (Models.Point point in seriesPoints.Points)
                    {
                        series.Points.AddXY(point.X, point.Y);
                    }
                    chart.Series.Add(series);
                }
            }

            chart.Invalidate();
            chart.AxisViewChanging += chart_AxisViewChanging;
            chart.AxisViewChanged += chart_AxisViewChanged;
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

                            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.DarkGray;
                            chart.ChartAreas[0].AxisX.MajorTickMark.LineColor = Color.Black;
                            chart.ChartAreas[0].AxisX.TitleForeColor = Color.Black;
                            chart.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Black;
                            chart.ChartAreas[0].AxisX.LineColor = Color.Black;

                            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.DarkGray;
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

                            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.DarkGray;
                            chart.ChartAreas[0].AxisX.MajorTickMark.LineColor = Color.White;
                            chart.ChartAreas[0].AxisX.TitleForeColor = Color.White;
                            chart.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
                            chart.ChartAreas[0].AxisX.LineColor = Color.White;

                            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.DarkGray;
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
