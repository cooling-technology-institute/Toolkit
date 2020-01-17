using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ToolkitLibrary;

namespace CTIToolkit
{
    public partial class DemandCurveTabPage : UserControl
    {
        const int INDEX_TARGETAPPROACH = 18;
        const int INDEX_USERAPPROACH = 19;
        const int INDEX_COEF = 20;
        const int INDEX_LG = 21;
        const int INDEX_KAVL = 22;
        const int ELEVATION = 0;
        const int PRESSURE = 1;

        private DemandCurveInputData DemandCurveInputData { get; set; }
        private DemandCurveData DemandCurveData { get; set; }
        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_IS_ { get; set; }

        public DemandCurveTabPage(ApplicationSettings applicationSettings)
        {
            InitializeComponent();

            IsInternationalSystemOfUnits_IS_ = (applicationSettings.UnitsSelection == UnitsSelection.International_System_Of_Units_SI);
            IsInternationalSystemOfUnits_IS_ = false;

            DemandCurveInputData = new DemandCurveInputData(IsDemo, IsInternationalSystemOfUnits_IS_);
            DemandCurveData = new DemandCurveData(IsInternationalSystemOfUnits_IS_);

            InitializeData();

            SwitchCalculation();

            //CalculateDemandCurve();
        }

        public void SetUnitsStandard(ApplicationSettings applicationSettings)
        {
            IsInternationalSystemOfUnits_IS_ = (applicationSettings.UnitsSelection == UnitsSelection.International_System_Of_Units_SI);
            IsInternationalSystemOfUnits_IS_ = false;

            SwitchCalculation();
        }

        private void InitializeData()
        {
            DemandCurve_Wet_Bulb_Value.Text = DemandCurveInputData.WetBlubTemperatureDataValue.Current.ToString();
            DemandCurve_Range_Value.Text = DemandCurveInputData.RangeDataValue.Current.ToString();
            DemandCurve_Elevation_Value.Text = DemandCurveInputData.ElevationDataValue.Current.ToString();
            DemandCurve_C_C1_Value.Text = DemandCurveInputData.C1DataValue.Current.ToString();
            DemandCurve_Slope_C2_Value.Text = DemandCurveInputData.SlopeDataValue.Current.ToString();
            DemandCurve_Minimum_Value.Text = DemandCurveInputData.MinimumDataValue.Current.ToString();
            DemandCurve_Maximum_Value.Text = DemandCurveInputData.MaximumDataValue.Current.ToString();
            DemandCurve_LG_Value.Text = DemandCurveInputData.LGDataValue.Current.ToString();
            DemandCurve_Elevation_Pressure_Selector.SelectedIndex = ELEVATION;
        }

        private void SwitchElevationPressure()
        {
            if (DemandCurveInputData.ConvertValues(IsInternationalSystemOfUnits_IS_, DemandCurve_Elevation_Pressure_Selector.SelectedIndex == ELEVATION))
            {
                SwitchCalculation();
            }

            if (DemandCurve_Elevation_Pressure_Selector.SelectedIndex == ELEVATION)
            {
                if (IsInternationalSystemOfUnits_IS_)
                {
                    DemandCurveElevationPressureUnits.Text = ConstantUnits.Meter;
                }
                else
                {
                    DemandCurveElevationPressureUnits.Text = ConstantUnits.Foot;
                }
            }
            else
            {
                if (IsInternationalSystemOfUnits_IS_)
                {
                    DemandCurveElevationPressureUnits.Text = ConstantUnits.BarometricPressureKiloPascal;
                }
                else
                {
                    DemandCurveElevationPressureUnits.Text = ConstantUnits.BarometricPressureInchOfMercury;
                }
            }
        }

        private void SwitchCalculation()
        {
            string tooltip = string.Empty;

            DemandCurveWetBulbTemperatureLabel.Text = DemandCurveInputData.WetBlubTemperatureDataValue.InputMessage + ":";
            DemandCurveWetBulbTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
            DemandCurve_Wet_Bulb_Value.Text = DemandCurveInputData.WetBlubTemperatureDataValue.InputValue;
            toolTip1.SetToolTip(DemandCurve_Wet_Bulb_Value, DemandCurveInputData.WetBlubTemperatureDataValue.ToolTip);

            DemandCurve_LG_Value.Text = DemandCurveInputData.LGDataValue.InputValue;
            toolTip1.SetToolTip(DemandCurve_LG_Value, DemandCurveInputData.LGDataValue.ToolTip);

            if (DemandCurve_ElevationRadio.Checked)
            {
                DemandCurve_Elevation_Value.Text = DemandCurveInputData.ElevationDataValue.InputValue;
                DemandCurveElevationPressureLabel.Text = DemandCurveInputData.ElevationDataValue.InputMessage + ":";
                if (IsInternationalSystemOfUnits_IS_)
                {
                    DemandCurveElevationPressureUnits.Text = ConstantUnits.Meter;
                }
                else
                {
                    DemandCurveElevationPressureUnits.Text = ConstantUnits.Foot;
                }
            }
            else
            {
                DemandCurve_Elevation_Value.Text = DemandCurveInputData.BarometricPressureDataValue.InputValue;
                DemandCurveElevationPressureLabel.Text = DemandCurveInputData.BarometricPressureDataValue.InputMessage + ":";
                if (IsInternationalSystemOfUnits_IS_)
                {
                    DemandCurveElevationPressureUnits.Text = ConstantUnits.BarometricPressureKiloPascal;
                }
                else
                {
                    DemandCurveElevationPressureUnits.Text = ConstantUnits.BarometricPressureInchOfMercury;
                }
            }

            if (IsInternationalSystemOfUnits_IS_)
            {
                DemandCurveTemperatureWebBulbUnits.Text = ConstantUnits.TemperatureCelsius;
                DemandCurveRangeUnits.Text = ConstantUnits.RangeK;
            }
            else
            {
                DemandCurveTemperatureWebBulbUnits.Text = ConstantUnits.TemperatureFahrenheit;
                DemandCurveRangeUnits.Text = ConstantUnits.TemperatureFahrenheit;
            }
        }

        private void CalculateDemandCurve()
        {
            try
            {
                DemandCurveCalculationLibrary demandCurveCalculationLibrary = new DemandCurveCalculationLibrary();

                DemandCurveData = new DemandCurveData(IsInternationalSystemOfUnits_IS_);

                DemandCurveChart.ChartAreas[0].AxisX.Minimum = 0.1;
                DemandCurveChart.ChartAreas[0].AxisX.Maximum = 10;
                //DemandCurveChart.ChartAreas[0].AxisX.IsLogarithmic = true;
                //DemandCurveChart.ChartAreas[0].AxisX.MajorTickMark.LineColor = Color.FromArgb(0xCC, 0xCC, 0xCC);
                //DemandCurveChart.ChartAreas[0].AxisX.LineColor = Color.FromArgb(0x77, 0x77, 0x77);
                //DemandCurveChart.ChartAreas[0].AxisX.TitleForeColor = Color.FromArgb(0x77, 0x77, 0x77);
                //DemandCurveChart.ChartAreas[0].AxisX.Title = "KaV/L";
                ////m_wndGraph.GetAxis().GetLeft().GetGridPen().SetStyle(psSolid);
                ////m_wndGraph.GetAxis().GetLeft().GetGridPen().SetWidth(1);
                ////m_wndGraph.GetAxis().GetTop().GetLabels().SetAngle(90);
                ////m_wndGraph.GetAxis().GetLeft().GetLabels().GetFont().SetSize(6);
                ////m_wndGraph.GetAxis().GetLeft().SetAutomaticMinimum(true);
                ////m_wndGraph.GetAxis().GetLeft().SetAutomaticMaximum(true);
                ////m_wndGraph.GetAxis().GetLeft().GetTitle().GetFont().SetSize(10);
                ////m_wndGraph.GetAxis().GetLeft().GetTitle().GetFont().SetBold(true);

                //DemandCurveChart.ChartAreas[0].AxisY.Minimum = 0.1;
                //DemandCurveChart.ChartAreas[0].AxisY.Maximum = 10;
                //DemandCurveChart.ChartAreas[0].AxisY.IsLogarithmic = true;
                //DemandCurveChart.ChartAreas[0].AxisY.MajorTickMark.LineColor = Color.FromArgb(0xCC, 0xCC, 0xCC);
                //DemandCurveChart.ChartAreas[0].AxisY.LineColor = Color.FromArgb(0x77, 0x77, 0x77);
                //DemandCurveChart.ChartAreas[0].AxisY.TitleForeColor = Color.FromArgb(0x77, 0x77, 0x77);
                //DemandCurveChart.ChartAreas[0].AxisY.Title = "L/G";

                ////clear data set
                //if (DemandCurveGridView.DataSource != null)
                //{
                //    DemandCurveGridView.DataSource = null;
                //}

                string message = string.Empty;

                if (!DemandCurveInputData.WetBlubTemperatureDataValue.UpdateValue(DemandCurve_Wet_Bulb_Value.Text, out message))
                {
                    MessageBox.Show(message);
                    return;
                }

                if (!DemandCurveInputData.RangeDataValue.UpdateValue(DemandCurve_Range_Value.Text, out message))
                {
                    MessageBox.Show(message);
                    return;
                }

                //if (DemandCurve_ElevationRadio.Checked)
                //{
                //    if (!DemandCurveInputData.ElevationDataValue.UpdateValue(DemandCurve_Elevation_Value.Text, out message))
                //    {
                //        MessageBox.Show(message);
                //        return;
                //    }
                //}
                //else
                //{
                //    if (!DemandCurveInputData.BarometricPressureDataValue.UpdateValue(DemandCurve_Elevation_Value.Text, out message))
                //    {
                //        MessageBox.Show(message);
                //        return;
                //    }
                //}

                if (!DemandCurveInputData.C1DataValue.UpdateValue(DemandCurve_C_C1_Value.Text, out message))
                {
                    MessageBox.Show(message);
                    return;
                }

                if (!DemandCurveInputData.SlopeDataValue.UpdateValue(DemandCurve_Slope_C2_Value.Text, out message))
                {
                    MessageBox.Show(message);
                    return;
                }

                if (!DemandCurveInputData.MinimumDataValue.UpdateValue(DemandCurve_Minimum_Value.Text, out message))
                {
                    MessageBox.Show(message);
                    return;
                }

                if (!DemandCurveInputData.MaximumDataValue.UpdateValue(DemandCurve_Maximum_Value.Text, out message))
                {
                    MessageBox.Show(message);
                    return;
                }

                if (!DemandCurveInputData.LGDataValue.UpdateValue(DemandCurve_LG_Value.Text, out message))
                {
                    MessageBox.Show(message);
                    return;
                }


                //DemandCurveData.IsElevation = DemandCurve_ElevationRadio.Checked;
                //DemandCurveData.SetInternationalSystemOfUnits_IS_(IsInternationalSystemOfUnits_IS_);

                //DemandCurveData.WetBulbTemperature = DemandCurveInputData.WetBlubTemperatureDataValue.Current;
                //DemandCurveData.Range = DemandCurveInputData.RangeDataValue.Current;
                //if (DemandCurve_ElevationRadio.Checked)
                //{
                //    //DemandCurveData.Elevation = DemandCurveInputData.ElevationDataValue.Current;
                //}
                //else
                //{
                //    //DemandCurveData.BarometricPressure = DemandCurveInputData.BarometricPressureDataValue.Current;
                //}

                DemandCurveData.CurveC1 = DemandCurveInputData.C1DataValue.Current;
                DemandCurveData.CurveC2 = DemandCurveInputData.SlopeDataValue.Current;
                //DemandCurveData.CurveMinimum = DemandCurveInputData.MinimumDataValue.Current;
                //DemandCurveData.CurveMaximum = DemandCurveInputData.MaximumDataValue.Current;

                DemandCurveChart.Series.Clear();

                for (int i = 1; i <= INDEX_KAVL; i++)
                {
                    //Series series = //DemandCurveChart.Series.Add(string.Format("Series{0}", i));
                    //series.ChartType = SeriesChartType.Line;
                    //series.XValueMember = string.Format("L/G-{0}", i);
                    //series.YValueMembers = string.Format("Y{0}", i);
                }

                demandCurveCalculationLibrary.DemandCurveCalculation(DemandCurveData);
                // AxisX, AxisY, AxisX2 and AxisY2
                //Primary X-Axis  Bottom horizontal axis.
                //Secondary X-Axis    Top horizontal axis.
                //Primary Y-Axis  Left vertical axis.
                //Secondary Y-Axis    Right vertical axis.
                if (DemandCurveData.DataTable != null ) //&& //DemandCurveData.DataTable.Rows != null && //DemandCurveData.DataTable.Rows.Count > 0)
                {
                    ChartArea chartArea1 = new ChartArea();
                    chartArea1.AxisX.IsLabelAutoFit = false;
                    //chartArea1.AxisX.IsLogarithmic = true;
                    chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(119)))));
                    chartArea1.AxisX.MajorTickMark.Interval = 0.75D;
                    chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
                    chartArea1.AxisX.Maximum = 5D;
                    chartArea1.AxisX.Minimum = 0.1D;
                    chartArea1.AxisX.MinorTickMark.Enabled = true;
                    chartArea1.AxisX.MajorTickMark.Enabled = true;
                    chartArea1.AxisX.MinorTickMark.Interval = 0.75D;
                    chartArea1.AxisX.MinorTickMark.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
                    chartArea1.AxisX.Title = "L/G";
                    chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
                    //chartArea1.AxisX2.IsLogarithmic = true;
                    //chartArea1.AxisX2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(119)))));
                    //chartArea1.AxisX2.Maximum = 10D;
                    //chartArea1.AxisX2.Minimum = 0.1D;
                    //chartArea1.AxisX2.MinorTickMark.Enabled = true;
                    //chartArea1.AxisX2.MinorTickMark.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
                    //chartArea1.AxisY.IsLogarithmic = true;
                    chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(119)))));
                    chartArea1.AxisY.MajorGrid.Interval = 0.75D;
                    chartArea1.AxisY.MajorTickMark.Interval = 0.5D;
                    chartArea1.AxisY.Maximum = 10D;
                    chartArea1.AxisY.Minimum = 0.1D;
                    chartArea1.AxisY.MinorTickMark.Enabled = true;
                    chartArea1.AxisY.MinorTickMark.Interval = 0.75D;
                    chartArea1.AxisY.MinorTickMark.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
                    chartArea1.AxisY.Title = "KaV/L";
                    chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
                    //chartArea1.AxisY2.IsLogarithmic = true;
                    //chartArea1.AxisY2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(119)))));
                    //chartArea1.AxisY2.Maximum = 10D;
                    //chartArea1.AxisY2.Minimum = 0.1D;
                    //chartArea1.AxisY2.MinorTickMark.Enabled = true;
                    //chartArea1.AxisY2.MinorTickMark.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
                    chartArea1.Name = "ChartArea1";
                    DemandCurveChart.ChartAreas.Clear();
                    DemandCurveChart.ChartAreas.Add(chartArea1);
                    DemandCurveChart.Name = "DemandCurveChart";
                    DemandCurveChart.ChartAreas[0].AxisX.Minimum = 0.1;
                    DemandCurveChart.ChartAreas[0].AxisX.IsLogarithmic = true;
                    DemandCurveChart.ChartAreas[0].AxisX.Maximum = 5;
                    ////DemandCurveChart.ChartAreas[0].AxisX.MajorTickMark.LineColor = Color.FromArgb(0xCC, 0xCC, 0xCC);
                    ////DemandCurveChart.ChartAreas[0].AxisX.LineColor = Color.FromArgb(0x77, 0x77, 0x77);
                    ////DemandCurveChart.ChartAreas[0].AxisX.TitleForeColor = Color.FromArgb(0x77, 0x77, 0x77);
                    DemandCurveChart.ChartAreas[0].AxisY.Title = "KaV/L";
                    ////m_wndGraph.GetAxis().GetLeft().GetGridPen().SetStyle(psSolid);
                    ////m_wndGraph.GetAxis().GetLeft().GetGridPen().SetWidth(1);
                    ////m_wndGraph.GetAxis().GetTop().GetLabels().SetAngle(90);
                    ////m_wndGraph.GetAxis().GetLeft().GetLabels().GetFont().SetSize(6);
                    ////m_wndGraph.GetAxis().GetLeft().SetAutomaticMinimum(true);
                    ////m_wndGraph.GetAxis().GetLeft().SetAutomaticMaximum(true);
                    ////m_wndGraph.GetAxis().GetLeft().GetTitle().GetFont().SetSize(10);
                    ////m_wndGraph.GetAxis().GetLeft().GetTitle().GetFont().SetBold(true);

                    DemandCurveChart.ChartAreas[0].AxisY.Minimum = 0.1;
                    //DemandCurveChart.ChartAreas[0].AxisY.Maximum = 5;
                    DemandCurveChart.ChartAreas[0].AxisY.IsLogarithmic = true;

                    //DemandCurveChart.Legends.Clear();
                    //Legend legend = new Legend();
                    //DemandCurveChart.Legends.Add(legend);
                    DemandCurveChart.Legends[0].Title = "Approach";

                    for (int i = 0; i < demandCurveCalculationLibrary.InitialApproachXValues.Length; i++)
                    {
                        if(demandCurveCalculationLibrary.ApproachInRange[i])
                        {
                            Series series = new Series();
                            series.ChartArea = "ChartArea1";
                            series.ChartType = SeriesChartType.Line;
                            //series.Color = System.Drawing.Color.Yellow;
                            series.Name = string.Format("{0}", demandCurveCalculationLibrary.InitialApproachXValues[i]);
                            series.XValueMember = string.Format("L/G-{0}", demandCurveCalculationLibrary.InitialApproachXValues[i]);
                            series.YValueMembers = string.Format("kaVL-{0}", demandCurveCalculationLibrary.InitialApproachXValues[i]);
                            DemandCurveChart.Series.Add(series);
                        }
                    }
//                    if (Display_COEF)
                    if (true)
                    {
                        //Series series = new Series();
                        //series.ChartArea = "ChartArea1";
                        //series.ChartType = SeriesChartType.Line;
                        //series.Color = Color.Yellow;
                        //series.Name = "COEF";
                        //series.XValueMember = "L/G-COEF";
                        //series.YValueMembers = "kaVL-COEF";
                        //DemandCurveChart.Series.Add(series);
                    }


                    DemandCurveChart.DataSource = DemandCurveData.DataTable;
                    BindingSource SBind = new BindingSource();

                    SBind.DataSource = DemandCurveData.DataTable;

                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = DemandCurveData.DataTable;

                    dataGridView1.DataSource = SBind;
                    dataGridView1.Refresh();

                    DemandCurveChart.DataBind();
                }
                //else
                //{
                //    //DemandCurveChart.ChartAreas[0].AxisX.IsLogarithmic = false;
                //    //DemandCurveChart.ChartAreas[0].AxisY.IsLogarithmic = false;
                //}
            }
            catch (Exception exception)
            {
                MessageBox.Show(string.Format("Error in Demand Curve calculation. Please check your input values. Exception Message: {0}", exception.Message), "Demand Curve Calculation Error");
            }
        }

        //private void DemandCurveElevationRadio_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (DemandCurve_ElevationRadio.Checked)
        //    {
        //        SwitchElevationPressure();
        //        CalculateDemandCurve();
        //    }
        //}

        //private void DemandCurvePressureRadio_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (DemandCurve_PressureRadio.Checked)
        //    {
        //        SwitchElevationPressure();
        //        CalculateDemandCurve();
        //    }
        //}

        //private void UnitedStatesCustomaryUnits_IP__CheckedChanged(object sender, EventArgs e)
        //{
        //    if (UnitedStatesCustomaryUnits_IP_.Checked)
        //    {
        //        SwitchUnitedStatesCustomaryUnits_IP_InternationalSystemOfUnits_IS_();
        //        CalculateDemandCurve();
        //    }
        //}

        //private void InternationalSystemOfUnits_IS__CheckedChanged(object sender, EventArgs e)
        //{
        //    if (IsInternationalSystemOfUnits_IS_)
        //    {
        //        SwitchUnitedStatesCustomaryUnits_IP_InternationalSystemOfUnits_IS_();
        //        CalculateDemandCurve();
        //    }
        //}

        private void DemandCurveCalculate_Click(object sender, EventArgs e)
        {
            CalculateDemandCurve();
        }

        private void DemandCurveChart_Click(object sender, EventArgs e)
        {
            // get xy
            // determine value
            // update page
        }

        private void DemandCurve_Elevation_Pressure_Selector_SelectedIndexChanged(object sender, EventArgs e)
        {
            SwitchElevationPressure();
            //CalculateDemandCurve();
        }

        // resizing
        //	if (m_wndGraph.m_hWnd)
        //	{
        //		if (cy< 550)
        //		{
        //			m_wndGraph.GetAxis().GetLeft().SetIncrement(.75);
        //    }
        //		else if (cx< 850)
        //		{
        //			m_wndGraph.GetAxis().GetLeft().SetIncrement(.5);
        //}
        //		else
        //		{
        //			m_wndGraph.GetAxis().GetLeft().SetIncrement(.25);
        //		}

        //		if (cx< 650)
        //		{
        //			m_wndGraph.GetAxis().GetBottom().SetIncrement(.5);
        //		}
        //		else if (cx< 850)
        //		{
        //			m_wndGraph.GetAxis().GetBottom().SetIncrement(.25);
        //		}
        //		else
        //		{
        //			m_wndGraph.GetAxis().GetBottom().SetIncrement(.2);
        //		}
        //	}

    }
}
