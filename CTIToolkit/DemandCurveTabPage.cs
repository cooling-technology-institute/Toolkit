// Copyright Cooling Technology Institute 2019-2021

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using CalculationLibrary;
using Models;
using ViewModels;

namespace CTIToolkit
{
    public partial class DemandCurveTabPage : CalculatePrintUserControl
    {
        const int INDEX_TARGETAPPROACH = 18;
        const int INDEX_USERAPPROACH = 19;
        const int INDEX_COEF = 20;
        const int INDEX_LG = 21;
        const int INDEX_KAVL = 22;

        private DemandCurveViewModel DemandCurveViewModel { get; set; }
        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_SI { get; set; }
        private bool HasChanged { get; set; }

        public DemandCurveTabPage(ApplicationSettings applicationSettings)
        {
            InitializeComponent();

            IsInternationalSystemOfUnits_SI = (applicationSettings.UnitsSelection == UnitsSelection.International_System_Of_Units_SI);

            DemandCurveViewModel = new DemandCurveViewModel(IsDemo, IsInternationalSystemOfUnits_SI);

            HasChanged = false;

            SetDisplayedValues();
        }

        public void SetUnitsStandard(bool isInternationalSystemOfUnits_SI)
        {
            if (IsInternationalSystemOfUnits_SI != isInternationalSystemOfUnits_SI)
            {
                IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;
                SwitchUnits();
            }
        }

        private void SwitchUnits()
        {
            string errorMessage;
            DemandCurveViewModel.ConvertValues(IsInternationalSystemOfUnits_SI, out errorMessage);
        }
        
        private void SetDisplayedValues()
        {
            DemandCurveWetBulbTemperatureLabel.Text = DemandCurveViewModel.WetBulbTemperatureDataValueInputMessage + ":";
            DemandCurveWetBulbTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
            DemandCurve_WetBulbTemperature_Value.Text = DemandCurveViewModel.WetBulbTemperatureDataValueInputValue;
            toolTip1.SetToolTip(DemandCurve_WetBulbTemperature_Value, DemandCurveViewModel.WetBulbTemperatureDataValueTooltip);

            RangeLabel.Text = DemandCurveViewModel.RangeDataValueInputMessage + ":";
            RangeLabel.TextAlign = ContentAlignment.MiddleRight;
            DemandCurve_Range_Value.Text = DemandCurveViewModel.RangeDataValueInputValue;
            toolTip1.SetToolTip(DemandCurve_Range_Value, DemandCurveViewModel.RangeDataValueTooltip);

            DemandCurveElevationPressureLabel.Text = DemandCurveViewModel.ElevationDataValueInputMessage + ":";
            DemandCurveElevationPressureLabel.TextAlign = ContentAlignment.MiddleRight;
            DemandCurve_Elevation_Value.Text = DemandCurveViewModel.ElevationDataValueInputValue;
            toolTip1.SetToolTip(DemandCurve_Elevation_Value, DemandCurveViewModel.ElevationDataValueTooltip);

            CLabel.Text = DemandCurveViewModel.C1DataValueInputMessage + ":";
            CLabel.TextAlign = ContentAlignment.MiddleRight;
            DemandCurve_C_C1_Value.Text = DemandCurveViewModel.C1DataValueInputValue;
            toolTip1.SetToolTip(DemandCurve_C_C1_Value, DemandCurveViewModel.C1DataValueTooltip);

            SlopeLabel.Text = DemandCurveViewModel.SlopeDataValueInputMessage + ":";
            SlopeLabel.TextAlign = ContentAlignment.MiddleRight;
            DemandCurve_Slope_C2_Value.Text = DemandCurveViewModel.SlopeDataValueInputValue;
            toolTip1.SetToolTip(DemandCurve_Slope_C2_Value, DemandCurveViewModel.SlopeDataValueTooltip);

            MinimumLabel.Text = DemandCurveViewModel.MinimumDataValueInputMessage + ":";
            MinimumLabel.TextAlign = ContentAlignment.MiddleRight;
            DemandCurve_Minimum_Value.Text = DemandCurveViewModel.MinimumDataValueInputValue;
            toolTip1.SetToolTip(DemandCurve_Minimum_Value, DemandCurveViewModel.MinimumDataValueTooltip);

            MaximumLabel.Text = DemandCurveViewModel.MaximumDataValueInputMessage + ":";
            MaximumLabel.TextAlign = ContentAlignment.MiddleRight;
            DemandCurve_Maximum_Value.Text = DemandCurveViewModel.MaximumDataValueInputValue;
            toolTip1.SetToolTip(DemandCurve_Maximum_Value, DemandCurveViewModel.MaximumDataValueTooltip);

            LiquidToGasRatioLabel.Text = DemandCurveViewModel.LiquidToGasRatioDataValueInputMessage + ":";
            LiquidToGasRatioLabel.TextAlign = ContentAlignment.MiddleRight;
            DemandCurve_LiquidToGasRatio_Value.Text = DemandCurveViewModel.LiquidToGasRatioDataValueInputValue;
            toolTip1.SetToolTip(DemandCurve_LiquidToGasRatio_Value, DemandCurveViewModel.LiquidToGasRatioDataValueTooltip);
        }

        public override void Calculate()
        {
            try
            {
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


                DemandCurveChart.Series.Clear();

                for (int i = 1; i <= INDEX_KAVL; i++)
                {
                    //Series series = //DemandCurveChart.Series.Add(string.Format("Series{0}", i));
                    //series.ChartType = SeriesChartType.Line;
                    //series.XValueMember = string.Format("L/G-{0}", i);
                    //series.YValueMembers = string.Format("Y{0}", i);
                }

                string errorMessage = string.Empty;

                if (DemandCurveViewModel.CalculateDemandCurve(DemandCurve_ElevationRadio.Checked, DemandCurve_KavLRadio.Checked, out errorMessage))
                {
                    // AxisX, AxisY, AxisX2 and AxisY2
                    //Primary X-Axis  Bottom horizontal axis.
                    //Secondary X-Axis    Top horizontal axis.
                    //Primary Y-Axis  Left vertical axis.
                    //Secondary Y-Axis    Right vertical axis.
                    if (DemandCurveViewModel.GetDataTable() != null) //&& //DemandCurveData.DataTable.Rows != null && //DemandCurveData.DataTable.Rows.Count > 0)
                    {
                        DemandCurveChart.ChartAreas[0].AxisX.IsLabelAutoFit = false;
                        DemandCurveChart.ChartAreas[0].AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(119)))));
                        DemandCurveChart.ChartAreas[0].AxisX.MajorTickMark.Interval = 0.75D;
                        DemandCurveChart.ChartAreas[0].AxisX.MajorTickMark.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
                        DemandCurveChart.ChartAreas[0].AxisX.Maximum = 5D;
                        DemandCurveChart.ChartAreas[0].AxisX.Minimum = 0.1D;
                        DemandCurveChart.ChartAreas[0].AxisX.MinorTickMark.Enabled = true;
                        DemandCurveChart.ChartAreas[0].AxisX.MajorTickMark.Enabled = true;
                        DemandCurveChart.ChartAreas[0].AxisX.MinorTickMark.Interval = 0.75D;
                        DemandCurveChart.ChartAreas[0].AxisX.MinorTickMark.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
                        DemandCurveChart.ChartAreas[0].AxisX.Title = "L/G";
                        DemandCurveChart.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);

                        DemandCurveChart.ChartAreas[0].AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(119)))));
                        DemandCurveChart.ChartAreas[0].AxisY.MajorGrid.Interval = 0.75D;
                        DemandCurveChart.ChartAreas[0].AxisY.MajorTickMark.Interval = 0.5D;
                        DemandCurveChart.ChartAreas[0].AxisY.Maximum = 10D;
                        DemandCurveChart.ChartAreas[0].AxisY.Minimum = 0.1D;
                        DemandCurveChart.ChartAreas[0].AxisY.MinorTickMark.Enabled = true;
                        DemandCurveChart.ChartAreas[0].AxisY.MinorTickMark.Interval = 0.75D;
                        DemandCurveChart.ChartAreas[0].AxisY.MinorTickMark.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
                        DemandCurveChart.ChartAreas[0].AxisY.Title = "KaV/L";
                        DemandCurveChart.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);

                        DemandCurveChart.ChartAreas[0].AxisX.Minimum = 0.1;
                        DemandCurveChart.ChartAreas[0].AxisX.IsLogarithmic = true;
                        DemandCurveChart.ChartAreas[0].AxisX.Maximum = 5;
                        DemandCurveChart.ChartAreas[0].AxisY.Title = "KaV/L";
                        DemandCurveChart.ChartAreas[0].AxisY.Minimum = 0.1;
                        DemandCurveChart.ChartAreas[0].AxisY.IsLogarithmic = true;

                        DemandCurveChart.Legends[0].Title = "Approach";

                        for (int i = 0; i < DemandCurveViewModel.DemandCurveCalculationLibrary.InitialApproachXValues.Length; i++)
                        {
                            if (DemandCurveViewModel.DemandCurveCalculationLibrary.ApproachInRange[i])
                            {
                                Series series = new Series();
                                series.ChartArea = "ChartArea1";
                                series.ChartType = SeriesChartType.Line;
                                //series.Color = System.Drawing.Color.Yellow;
                                series.Name = string.Format("{0}", DemandCurveViewModel.DemandCurveCalculationLibrary.InitialApproachXValues[i]);
                                series.XValueMember = string.Format("L/G-{0}", DemandCurveViewModel.DemandCurveCalculationLibrary.InitialApproachXValues[i]);
                                series.YValueMembers = string.Format("kaVL-{0}", DemandCurveViewModel.DemandCurveCalculationLibrary.InitialApproachXValues[i]);
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


                        DemandCurveChart.DataSource = DemandCurveViewModel.GetDataTable();
                        BindingSource SBind = new BindingSource();

                        SBind.DataSource = DemandCurveViewModel.GetDataTable();

                        dataGridView1.AutoGenerateColumns = true;
                        dataGridView1.DataSource = DemandCurveViewModel.GetDataTable();

                        dataGridView1.DataSource = SBind;
                        dataGridView1.Refresh();

                        DemandCurveChart.DataBind();

                    }
                }
                else
                {
                    //DemandCurveChart.ChartAreas[0].AxisX.IsLogarithmic = false;
                    //DemandCurveChart.ChartAreas[0].AxisY.IsLogarithmic = false;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(string.Format("Error in Demand Curve calculation. Please check your input values. Exception Message: {0}", exception.Message), "Demand Curve Calculation Error");
            }
        }

        public override void Print()
        {
        }

        public void DemandCurveCalculate_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        private void DemandCurveChart_Click(object sender, EventArgs e)
        {
            // get xy
            // determine value
            // update page
        }

        private void DemandCurve_KavLRadio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void DemandCurve_ApproachRadio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void DemandCurve_LiquidToGasRatio_Value_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(DemandCurve_LiquidToGasRatio_Value, "");
        }

        private void DemandCurve_LiquidToGasRatio_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!DemandCurveViewModel.LiquidToGasRatioDataValueUpdateValue(DemandCurve_LiquidToGasRatio_Value.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                DemandCurve_LiquidToGasRatio_Value.Select(0, DemandCurve_LiquidToGasRatio_Value.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(DemandCurve_LiquidToGasRatio_Value, errorMessage);
            }
        }

        private void DemandCurve_WetBulbTemperature_Value_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(DemandCurve_WetBulbTemperature_Value, "");
        }

        private void DemandCurve_WetBulbTemperature_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!DemandCurveViewModel.WetBulbTemperatureDataValueUpdateValue(DemandCurve_WetBulbTemperature_Value.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                DemandCurve_WetBulbTemperature_Value.Select(0, DemandCurve_WetBulbTemperature_Value.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(DemandCurve_WetBulbTemperature_Value, errorMessage);
            }
        }

        private void DemandCurve_Range_Value_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(DemandCurve_Range_Value, "");
        }

        private void DemandCurve_Range_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!DemandCurveViewModel.RangeDataValueUpdateValue(DemandCurve_Range_Value.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                DemandCurve_Range_Value.Select(0, DemandCurve_Range_Value.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(DemandCurve_Range_Value, errorMessage);
            }
        }

        private void DemandCurve_Elevation_Value_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(DemandCurve_Elevation_Value, "");
        }

        private void DemandCurve_Elevation_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (DemandCurve_ElevationRadio.Checked)
            {
                if (!DemandCurveViewModel.ElevationDataValueUpdateValue(DemandCurve_Elevation_Value.Text, out errorMessage))
                {
                    // Cancel the event and select the text to be corrected by the user.
                    e.Cancel = true;
                    DemandCurve_Elevation_Value.Select(0, DemandCurve_Elevation_Value.Text.Length);

                    // Set the ErrorProvider error with the text to display. 
                    this.errorProvider1.SetError(DemandCurve_Elevation_Value, errorMessage);
                }
            }
            else
            {
                if (!DemandCurveViewModel.BarometricPressureDataValueUpdateValue(DemandCurve_Elevation_Value.Text, out errorMessage))
                {
                    // Cancel the event and select the text to be corrected by the user.
                    e.Cancel = true;
                    DemandCurve_Elevation_Value.Select(0, DemandCurve_Elevation_Value.Text.Length);

                    // Set the ErrorProvider error with the text to display. 
                    this.errorProvider1.SetError(DemandCurve_Elevation_Value, errorMessage);
                }
            }
        }

        private void DemandCurve_ElevationRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (DemandCurve_ElevationRadio.Checked)
            {
                DemandCurve_Elevation_Value.Text = DemandCurveViewModel.ElevationDataValueInputValue;
                DemandCurveElevationPressureLabel.Text = DemandCurveViewModel.ElevationDataValueInputMessage;
                if (IsInternationalSystemOfUnits_SI)
                {
                    DemandCurveElevationPressureUnits.Text = ConstantUnits.Meter;
                }
                else
                {
                    DemandCurveElevationPressureUnits.Text = ConstantUnits.Foot;
                }
            }
        }

        private void DemandCurve_PressureRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (DemandCurve_PressureRadio.Checked)
            {
                DemandCurve_Elevation_Value.Text = DemandCurveViewModel.BarometricPressureDataValueInputValue;
                DemandCurveElevationPressureLabel.Text = DemandCurveViewModel.BarometricPressureDataValueInputMessage;
                if (IsInternationalSystemOfUnits_SI)
                {
                    DemandCurveElevationPressureUnits.Text = ConstantUnits.BarometricPressureKiloPascal;
                }
                else
                {
                    DemandCurveElevationPressureUnits.Text = ConstantUnits.BarometricPressureInchOfMercury;
                }
            }
        }

        private void DemandCurve_C_C1_Value_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(DemandCurve_C_C1_Value, "");
        }

        private void DemandCurve_C_C1_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!DemandCurveViewModel.C1DataValueUpdateValue(DemandCurve_C_C1_Value.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                DemandCurve_C_C1_Value.Select(0, DemandCurve_C_C1_Value.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(DemandCurve_C_C1_Value, errorMessage);
            }
        }

        private void DemandCurve_Slope_C2_Value_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(DemandCurve_Slope_C2_Value, "");
        }

        private void DemandCurve_Slope_C2_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!DemandCurveViewModel.SlopeDataValueUpdateValue(DemandCurve_Slope_C2_Value.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                DemandCurve_Slope_C2_Value.Select(0, DemandCurve_Slope_C2_Value.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(DemandCurve_Slope_C2_Value, errorMessage);
            }
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
