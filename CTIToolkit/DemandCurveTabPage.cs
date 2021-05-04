// Copyright Cooling Technology Institute 2019-2021

using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ViewModels;

namespace CTIToolkit
{
    public partial class DemandCurveTabPage : CalculatePrintUserControl
    {
        const int INDEX_TARGETAPPROACH = 18;
        const int INDEX_USERAPPROACH = 19;
        const int INDEX_Charactertics = 20;
        const int INDEX_LG = 21;
        const int INDEX_KAVL = 22;

        private DemandCurveViewModel DemandCurveViewModel { get; set; }
        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_SI { get; set; }
        private bool HasChanged { get; set; }
        private bool AllOff { get; set; }
        private bool IsNonApproachSeries { get; set; }

        public DemandCurveTabPage(ApplicationSettings applicationSettings)
        {
            InitializeComponent();

            Filter = "Demand Curve files (*.dc)|*.dc|All files (*.*)|*.*";
            DefaultExt = "dc";
            Title = "Demand Curve";
            DefaultFileName = "DemandCurve";
            AllOff = false;
            IsNonApproachSeries = false;

            IsInternationalSystemOfUnits_SI = (applicationSettings.UnitsSelection == UnitsSelection.International_System_Of_Units_SI);
            IsDemo = applicationSettings.IsDemo;

            DemandCurveViewModel = new DemandCurveViewModel(IsDemo, IsInternationalSystemOfUnits_SI);
            DemandCurveViewModel.DataFileName = BuildDefaultFileName();

            HasChanged = false;

            SetDisplayedValues();
        }

        public void SetUnitsStandard(bool isInternationalSystemOfUnits_SI)
        {
            if (IsInternationalSystemOfUnits_SI != isInternationalSystemOfUnits_SI)
            {
                IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;
                SetDisplayedValues();
            }
        }

        private void SwitchUnits()
        {
            DemandCurveViewModel.ConvertValues(IsInternationalSystemOfUnits_SI);

            if (IsInternationalSystemOfUnits_SI)
            {
                WebBulbTemperatureUnits.Text = ConstantUnits.TemperatureCelsius;
                RangeUnits.Text = ConstantUnits.RangeK;
                UserApproachUnits.Text = ConstantUnits.RangeK;
                if (ElevationRadio.Checked)
                {
                    ElevationPressureUnits.Text = ConstantUnits.Meter;
                }
                else
                {
                    ElevationPressureUnits.Text = ConstantUnits.BarometricPressureKiloPascal;
                }
            }
            else
            {
                WebBulbTemperatureUnits.Text = ConstantUnits.TemperatureFahrenheit;
                RangeUnits.Text = ConstantUnits.TemperatureFahrenheit;
                UserApproachUnits.Text = ConstantUnits.TemperatureFahrenheit;
                if (ElevationRadio.Checked)
                {
                    ElevationPressureUnits.Text = ConstantUnits.Foot;
                }
                else
                {
                    ElevationPressureUnits.Text = ConstantUnits.BarometricPressureInchOfMercury;
                }
            }
        }

        private void SetRadioButtons()
        {
            if (DemandCurveViewModel.IsElevation)
            {
                ElevationRadio.Checked = true;
                BarometricPressureRadio.Checked = false;
            }
            else
            {
                ElevationRadio.Checked = false;
                BarometricPressureRadio.Checked = true;
            }

            //if (DemandCurveViewModel.IsApproach)
            //{
            //    ApproachRadio.Checked = true;
            //    KavLRadio.Checked = false;
            //}
            //else
            //{
            //    ApproachRadio.Checked = false;
            //    KavLRadio.Checked = true;
            //}
        }

        private void SetDisplayedValues()
        {
            DataFilename.Text = DemandCurveViewModel.DataFilenameInputValue;

            SetRadioButtons();
            SwitchUnits();

            WetBulbTemperatureLabel.Text = DemandCurveViewModel.WetBulbTemperatureDataValueInputMessage + ":";
            WetBulbTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
            WetBulbTemperatureValue.Text = DemandCurveViewModel.WetBulbTemperatureDataValueInputValue;
            toolTip1.SetToolTip(WetBulbTemperatureValue, DemandCurveViewModel.WetBulbTemperatureDataValueTooltip);

            RangeLabel.Text = DemandCurveViewModel.RangeDataValueInputMessage + ":";
            RangeLabel.TextAlign = ContentAlignment.MiddleRight;
            RangeValue.Text = DemandCurveViewModel.RangeDataValueInputValue;
            toolTip1.SetToolTip(RangeValue, DemandCurveViewModel.RangeDataValueTooltip);

            if (ElevationRadio.Checked)
            {
                ElevationPressureLabel.Text = DemandCurveViewModel.ElevationDataValueInputMessage + ":";
                ElevationPressureLabel.TextAlign = ContentAlignment.MiddleRight;
                ElevationValue.Text = DemandCurveViewModel.ElevationDataValueInputValue;
                toolTip1.SetToolTip(ElevationValue, DemandCurveViewModel.ElevationDataValueTooltip);
            }
            else
            {
                ElevationPressureLabel.Text = DemandCurveViewModel.BarometricPressureDataValueInputMessage + ":";
                ElevationPressureLabel.TextAlign = ContentAlignment.MiddleRight;
                ElevationValue.Text = DemandCurveViewModel.BarometricPressureDataValueInputValue;
                toolTip1.SetToolTip(ElevationValue, DemandCurveViewModel.BarometricPressureDataValueTooltip);
            }

            CLabel.Text = DemandCurveViewModel.C1DataValueInputMessage + ":";
            CLabel.TextAlign = ContentAlignment.MiddleRight;
            C_C1_Value.Text = DemandCurveViewModel.C1DataValueInputValue;
            toolTip1.SetToolTip(C_C1_Value, DemandCurveViewModel.C1DataValueTooltip);

            SlopeLabel.Text = DemandCurveViewModel.SlopeDataValueInputMessage + ":";
            SlopeLabel.TextAlign = ContentAlignment.MiddleRight;
            Slope_C2_Value.Text = DemandCurveViewModel.SlopeDataValueInputValue;
            toolTip1.SetToolTip(Slope_C2_Value, DemandCurveViewModel.SlopeDataValueTooltip);

            MinimumLabel.Text = DemandCurveViewModel.MinimumDataValueInputMessage + ":";
            MinimumLabel.TextAlign = ContentAlignment.MiddleRight;
            MinimumValue.Text = DemandCurveViewModel.MinimumDataValueInputValue;
            toolTip1.SetToolTip(MinimumValue, DemandCurveViewModel.MinimumDataValueTooltip);

            MaximumLabel.Text = DemandCurveViewModel.MaximumDataValueInputMessage + ":";
            MaximumLabel.TextAlign = ContentAlignment.MiddleRight;
            MaximumValue.Text = DemandCurveViewModel.MaximumDataValueInputValue;
            toolTip1.SetToolTip(MaximumValue, DemandCurveViewModel.MaximumDataValueTooltip);

            LiquidToGasRatioLabel.Text = DemandCurveViewModel.LiquidToGasRatioDataValueInputMessage + ":";
            LiquidToGasRatioLabel.TextAlign = ContentAlignment.MiddleRight;
            LiquidToGasRatioValue.Text = DemandCurveViewModel.LiquidToGasRatioDataValueInputValue;
            toolTip1.SetToolTip(LiquidToGasRatioValue, DemandCurveViewModel.LiquidToGasRatioDataValueTooltip);

            UserApproachLabel.Text = DemandCurveViewModel.UserApproachDataValueInputMessage + ":";
            UserApproachLabel.TextAlign = ContentAlignment.MiddleRight;
            UserApproachValue.Text = DemandCurveViewModel.UserApproachDataValueInputValue;
            toolTip1.SetToolTip(UserApproachValue, DemandCurveViewModel.UserApproachDataValueTooltip);
        }

        public override void Calculate()
        {
            try
            {
                Chart.Series.Clear();
                IsNonApproachSeries = false;
                AllOff = false;
                //update button text
                //AllOffOnButton.Text = "All On";

                for (int i = 1; i <= INDEX_KAVL; i++)
                {
                    //Series series = //DemandCurveChart.Series.Add(string.Format("Series{0}", i));
                    //series.ChartType = SeriesChartType.Line;
                    //series.XValueMember = string.Format("L/G-{0}", i);
                    //series.YValueMembers = string.Format("Y{0}", i);
                }

                if (DemandCurveViewModel.Calculate())
                {
                    // AxisX, AxisY, AxisX2 and AxisY2
                    //Primary X-Axis  Bottom horizontal axis.
                    //Secondary X-Axis    Top horizontal axis.
                    //Primary Y-Axis  Left vertical axis.
                    //Secondary Y-Axis    Right vertical axis.
                    if (DemandCurveViewModel.GetDataTable() != null) //&& //DemandCurveData.DataTable.Rows != null && //DemandCurveData.DataTable.Rows.Count > 0)
                    {
                        Chart.ChartAreas[0].AxisX.Title = "L/G";
                        Chart.ChartAreas[0].AxisX.IsLogarithmic = true;
                        //DemandCurveChart.ChartAreas[0].AxisX.IsLabelAutoFit = false;
                        Chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                        //DemandCurveChart.ChartAreas[0].AxisX.MajorGrid.Interval = 0.25D;
                        ////DemandCurveChart.ChartAreas[0].AxisX.MajorTickMark.Interval = 1.0;
                        ////DemandCurveChart.ChartAreas[0].AxisX.MajorTickMark.IntervalOffset = 1.0;
                        ////DemandCurveChart.ChartAreas[0].AxisX.MajorTickMark.Interval = 0.75D;
                        //DemandCurveChart.ChartAreas[0].AxisX.MajorTickMark.LineColor = Color.Gray;
                        Chart.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
                        //Chart.ChartAreas[0].AxisX.MinorTickMark.Enabled = false;
                        //DemandCurveChart.ChartAreas[0].AxisX.MajorTickMark.Enabled = true;
                        //DemandCurveChart.ChartAreas[0].AxisX.MinorTickMark.Interval = 0.75D;
                        //DemandCurveChart.ChartAreas[0].AxisX.MinorTickMark.LineColor = Color.LightGray;

                        Chart.ChartAreas[0].AxisY.Title = "KaV/L";
                        Chart.ChartAreas[0].AxisY.IsLogarithmic = true;
                        Chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                        Chart.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
                        //DemandCurveChart.ChartAreas[0].AxisY.MajorGrid.Interval = 0.25;
                        //DemandCurveChart.ChartAreas[0].AxisY.MajorGrid.Interval = 0.75D;
                        //DemandCurveChart.ChartAreas[0].AxisY.MajorTickMark.Interval = 0.5D;
                        Chart.ChartAreas[0].AxisY.MinorTickMark.Enabled = false;
                        //DemandCurveChart.ChartAreas[0].AxisY.MinorTickMark.Interval = 0.75D;
                        //DemandCurveChart.ChartAreas[0].AxisY.MajorTickMark.LineColor = Color.Gray;
                        //DemandCurveChart.ChartAreas[0].AxisY.MinorTickMark.LineColor = Color.LightGray;

                        Chart.Legends[0].Title = "Approach";

                        Chart.ChartAreas[0].CursorX.AutoScroll = true;
                        Chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                        Chart.ChartAreas[0].CursorY.AutoScroll = true;
                        Chart.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;

                        //int startOffset = -2;
                        //int endOffset = 2;
                        //for(double interval = 0.5; interval < 6.0; interval += 0.5)
                        //{
                        //    CustomLabel intervalLabel = new CustomLabel(startOffset, endOffset, interval.ToString("F2"), 0, LabelMarkStyle.LineSideMark);
                        //    DemandCurveChart.ChartAreas[0].AxisY.CustomLabels.Add(intervalLabel);
                        //    startOffset = startOffset + 25;
                        //    endOffset = endOffset + 25;
                        //}

                        for (int i = 0; i < DemandCurveViewModel.DemandCurveCalculationLibrary.InitialApproachXValues.Length; i++)
                        {
                            if (DemandCurveViewModel.DemandCurveCalculationLibrary.ApproachInRange[i])
                            {
                                Series series = new Series()
                                {
                                    ChartArea = "ChartArea1",
                                    ChartType = SeriesChartType.Line,
                                    Name = string.Format("{0}", DemandCurveViewModel.DemandCurveCalculationLibrary.InitialApproachXValues[i]),
                                    XValueMember = string.Format("L/G-Approach-{0}", DemandCurveViewModel.DemandCurveCalculationLibrary.InitialApproachXValues[i]),
                                    YValueMembers = string.Format("kaVL-Approach-{0}", DemandCurveViewModel.DemandCurveCalculationLibrary.InitialApproachXValues[i]),
                                };
                                Chart.Series.Add(series);
                            }
                        }

                        if (DemandCurveViewModel.IsUserApproach)
                        {
                            Series series = new Series();
                            series.ChartArea = "ChartArea1";
                            series.ChartType = SeriesChartType.Line;
                            series.Name = "User";
                            series.XValueMember = "User-X";
                            series.YValueMembers = "User-Y";
                            Chart.Series.Add(series);
                        }

                        if (DemandCurveViewModel.IsCoef)
                        {
                            Series series = new Series();
                            series.ChartArea = "ChartArea1";
                            series.ChartType = SeriesChartType.Line;
                            series.Name = "Chars";
                            series.XValueMember = "Charactertics-X";
                            series.YValueMembers = "Charactertics-Y";
                            Chart.Series.Add(series);
                        }

                        if (DemandCurveViewModel.IsLiquidToGasRatio)
                        {
                            Series series = new Series();
                            series.ChartArea = "ChartArea1";
                            series.ChartType = SeriesChartType.Line;
                            series.Name = "L/G";
                            series.XValueMember = "L/G-X";
                            series.YValueMembers = "L/G-Y";
                            Chart.Series.Add(series);
                        }

                        if (DemandCurveViewModel.IsKaV_L)
                        {
                            Series series = new Series();
                            series.ChartArea = "ChartArea1";
                            series.ChartType = SeriesChartType.Line;
                            series.Name = "KaV/L";
                            series.XValueMember = "Line-X";
                            series.YValueMembers = "Line-Y";
                            Chart.Series.Add(series);
                        }

                        Chart.DataSource = DemandCurveViewModel.GetDataTable();

                        //dataGridView1.AutoGenerateColumns = true;
                        //dataGridView1.DataSource = DemandCurveViewModel.GetDataTable();

                        //dataGridView1.DataSource = SBind;
                        //dataGridView1.Refresh();

                        Chart.DataBind();

                        if (DemandCurveViewModel.GetOutputDataTable() != null)
                        {
                            // Set a DataGrid control's DataSource to the DataView.
                            OutputGridView.DataSource = new DataView(DemandCurveViewModel.GetOutputDataTable());
                        }
                    }
                }
                else
                {
                    Chart.ChartAreas[0].AxisX.IsLogarithmic = false;
                    Chart.ChartAreas[0].AxisY.IsLogarithmic = false;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(string.Format("Error in Demand Curve calculation. Please check your input values. Exception Message: {0}", exception.Message), "Demand Curve Calculation Error");
            }
        }

        public override bool OpenDataFile(string fileName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;

            if (DemandCurveViewModel.OpenDataFile(fileName))
            {
                if (DemandCurveViewModel.IsInternationalSystemOfUnits_SI != IsInternationalSystemOfUnits_SI)
                {
                    ToolkitMain main = this.Parent.Parent.Parent as ToolkitMain;
                    if (main != null)
                    {
                        main.UpdateUnits(DemandCurveViewModel.IsInternationalSystemOfUnits_SI ? UnitsSelection.International_System_Of_Units_SI : UnitsSelection.United_States_Customary_Units_IP);
                    }
                }

                SetDisplayedValues();

                Calculate();
            }
            else
            {
                stringBuilder.AppendLine("Unable to load file. File contains invalid data.");
            }

            if (!returnValue)
            {
                ErrorMessage = stringBuilder.ToString();
            }
            
            return returnValue;
        }

        public override bool OpenNewDataFile(string fileName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;

            if (DemandCurveViewModel.OpenNewDataFile(fileName))
            {
                SetDisplayedValues();
                //{
                //    stringBuilder.AppendLine(ErrorMessage);
                //    returnValue = false;
                //}
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
            
            return returnValue;
        }

        public override bool SaveDataFile()
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;
            ErrorMessage = string.Empty;

            if (!DemandCurveViewModel.SaveDataFile())
            {
                stringBuilder.AppendLine(DemandCurveViewModel.ErrorMessage);
                returnValue = false;
            }

            SetDisplayedValues();
            //{
            //    stringBuilder.AppendLine(ErrorMessage);
            //    returnValue = false;
            //}

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
            
            DemandCurveViewModel.DataFileName = fileName;
            DataFilename.Text = DemandCurveViewModel.DataFilenameInputValue;

            if (!DemandCurveViewModel.SaveAsDataFile(fileName))
            {
                stringBuilder.AppendLine(DemandCurveViewModel.ErrorMessage);
                returnValue = false;
            }

            ErrorMessage = stringBuilder.ToString();
            return returnValue;
        }

        public override void PrintPage(object sender, PrintPageEventArgs e)
        {
            //if(PrintControl.UserControl == null)
            //{

            //}
            NameValueUnitsDataTable nameValueUnitsDataTable = new NameValueUnitsDataTable();

            if (DemandCurveViewModel.GetDataTable() != null)
            {
                nameValueUnitsDataTable.AddRow(DemandCurveViewModel.WetBulbTemperatureDataValueInputMessage, WetBulbTemperatureValue.Text, WebBulbTemperatureUnits.Text);
                nameValueUnitsDataTable.AddRow(DemandCurveViewModel.RangeDataValueInputMessage, RangeValue.Text, RangeUnits.Text);

                if (ElevationRadio.Checked)
                {
                    nameValueUnitsDataTable.AddRow(DemandCurveViewModel.ElevationDataValueInputMessage, DemandCurveViewModel.ElevationDataValueInputValue, ElevationPressureUnits.Text);
                }
                else
                    nameValueUnitsDataTable.AddRow(DemandCurveViewModel.BarometricPressureDataValueInputMessage, DemandCurveViewModel.BarometricPressureDataValueInputValue, ElevationPressureUnits.Text);
                {
                }

                DemandCurvePrinterOutput printerOutput = new DemandCurvePrinterOutput(e.PageBounds.Height - 80, this.PrintControl.Label, nameValueUnitsDataTable, DemandCurveViewModel);
                printerOutput.CreateControl();
                var bm = new Bitmap(printerOutput.Width, printerOutput.Height);
                printerOutput.DrawToBitmap(bm, new Rectangle(0, 0, bm.Width, bm.Height));
                e.Graphics.DrawImage(bm, 40, 40);
            }
            else
            {
                MessageBox.Show("You must run the calculation before printing.");
            }
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

        private void LiquidToGasRatioValue_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(LiquidToGasRatioValue, "");
        }

        private void LiquidToGasRatioValue_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!DemandCurveViewModel.LiquidToGasRatioDataValueUpdateValue(LiquidToGasRatioValue.Text, out string errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                LiquidToGasRatioValue.Select(0, LiquidToGasRatioValue.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(LiquidToGasRatioValue, errorMessage);
            }
        }

        private void WetBulbTemperature_Value_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(WetBulbTemperatureValue, "");
        }

        private void WetBulbTemperature_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!DemandCurveViewModel.WetBulbTemperatureDataValueUpdateValue(WetBulbTemperatureValue.Text, out string errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                WetBulbTemperatureValue.Select(0, WetBulbTemperatureValue.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(WetBulbTemperatureValue, errorMessage);
            }
        }

        private void RangeValue_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(RangeValue, "");
        }

        private void RangeValue_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!DemandCurveViewModel.RangeDataValueUpdateValue(RangeValue.Text, out string errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                RangeValue.Select(0, RangeValue.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(RangeValue, errorMessage);
            }
        }

        private void ElevationValue_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(ElevationValue, "");
        }

        private void ElevationValue_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ElevationRadio.Checked)
            {
                if (!DemandCurveViewModel.ElevationDataValueUpdateValue(ElevationValue.Text, out string errorMessage))
                {
                    // Cancel the event and select the text to be corrected by the user.
                    e.Cancel = true;
                    ElevationValue.Select(0, ElevationValue.Text.Length);

                    // Set the ErrorProvider error with the text to display. 
                    this.errorProvider1.SetError(ElevationValue, errorMessage);
                }
            }
            else
            {
                if (!DemandCurveViewModel.BarometricPressureDataValueUpdateValue(ElevationValue.Text, out string errorMessage))
                {
                    // Cancel the event and select the text to be corrected by the user.
                    e.Cancel = true;
                    ElevationValue.Select(0, ElevationValue.Text.Length);

                    // Set the ErrorProvider error with the text to display. 
                    this.errorProvider1.SetError(ElevationValue, errorMessage);
                }
            }
        }

        private void C_C1_Value_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(C_C1_Value, "");
        }

        private void C_C1_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!DemandCurveViewModel.C1DataValueUpdateValue(C_C1_Value.Text, out string errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                C_C1_Value.Select(0, C_C1_Value.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(C_C1_Value, errorMessage);
            }
        }

        private void Slope_C2_Value_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Slope_C2_Value, "");
        }

        private void Slope_C2_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!DemandCurveViewModel.SlopeDataValueUpdateValue(Slope_C2_Value.Text, out string errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Slope_C2_Value.Select(0, Slope_C2_Value.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Slope_C2_Value, errorMessage);
            }
        }

        private void MaximumValue_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(MaximumValue, "");
        }

        private void MaximumValue_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!DemandCurveViewModel.MaximumDataValueUpdateValue(MaximumValue.Text, out string errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                MaximumValue.Select(0, MaximumValue.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(MaximumValue, errorMessage);
            }
        }

        private void MinimumValue_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(MinimumValue, "");
        }

        private void MinimumValue_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!DemandCurveViewModel.MinimumDataValueUpdateValue(MinimumValue.Text, out string errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                MinimumValue.Select(0, MinimumValue.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(MinimumValue, errorMessage);
            }
        }

        private void UserApproachValue_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(UserApproachValue, "");
        }

        private void UserApproachValue_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!DemandCurveViewModel.UserApproachDataValueUpdateValue(UserApproachValue.Text, out string errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                UserApproachValue.Select(0, UserApproachValue.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(UserApproachValue, errorMessage);
            }
        }

        //private void ApproachRadio_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (ApproachRadio.Checked)
        //    {
        //        DemandCurveViewModel.IsApproach = true;
        //    }
        //}

        //private void KavLRadio_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (KavLRadio.Checked)
        //    {
        //        DemandCurveViewModel.IsApproach = false;
        //    }
        //}

        private void BarometricPressureRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (BarometricPressureRadio.Checked)
            {
                DemandCurveViewModel.IsElevation = false;
                ElevationValue.Text = DemandCurveViewModel.BarometricPressureDataValueInputValue;
                ElevationPressureLabel.Text = DemandCurveViewModel.BarometricPressureDataValueInputMessage;
                toolTip1.SetToolTip(ElevationValue, DemandCurveViewModel.BarometricPressureDataValueTooltip);
                if (IsInternationalSystemOfUnits_SI)
                {
                    ElevationPressureUnits.Text = ConstantUnits.BarometricPressureKiloPascal;
                }
                else
                {
                    ElevationPressureUnits.Text = ConstantUnits.BarometricPressureInchOfMercury;
                }
            }
        }

        private void ElevationRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (ElevationRadio.Checked)
            {
                DemandCurveViewModel.IsElevation = true;
                ElevationValue.Text = DemandCurveViewModel.ElevationDataValueInputValue;
                ElevationPressureLabel.Text = DemandCurveViewModel.ElevationDataValueInputMessage;
                toolTip1.SetToolTip(ElevationValue, DemandCurveViewModel.ElevationDataValueTooltip);
                if (IsInternationalSystemOfUnits_SI)
                {
                    ElevationPressureUnits.Text = ConstantUnits.Meter;
                }
                else
                {
                    ElevationPressureUnits.Text = ConstantUnits.Foot;
                }
            }
        }

        private void DemandCurveChart_Resize(object sender, EventArgs e)
        {
            //if (cy < 550)
            //{
            //    m_wndGraph.GetAxis().GetLeft().SetIncrement(.75);
            //}
            //else if (cx < 850)
            //{
            //    m_wndGraph.GetAxis().GetLeft().SetIncrement(.5);
            //}
            //else
            //{
            //    m_wndGraph.GetAxis().GetLeft().SetIncrement(.25);
            //}

            //if (cx < 650)
            //{
            //    m_wndGraph.GetAxis().GetBottom().SetIncrement(.5);
            //}
            //else if (cx < 850)
            //{
            //    m_wndGraph.GetAxis().GetBottom().SetIncrement(.25);
            //}
            //else
            //{
            //    m_wndGraph.GetAxis().GetBottom().SetIncrement(.2);
            //}
        }

        private void DemandCurveTabPage_Resize(object sender, EventArgs e)
        {
            if (sender is Control)
            {
                Control control = (Control)sender;

                int width = Chart.Size.Width - Chart.Margin.Left - Chart.Margin.Right;
                int height = Chart.Size.Height - Chart.Margin.Top - Chart.Margin.Bottom;
                int controlHeight = control.Size.Height - Chart.Location.Y - Chart.Margin.Top - Chart.Margin.Bottom;
                int controlWidth = control.Size.Width - Chart.Location.X - Chart.Margin.Left - Chart.Margin.Right;

                if(controlWidth < Chart.MinimumSize.Width)
                {
                    controlWidth = Chart.MinimumSize.Width;
                }
                if (controlHeight < Chart.MinimumSize.Height)
                {
                    controlHeight = Chart.MinimumSize.Height;
                }

                if ((controlWidth > 0) && (controlHeight > 0))
                {
                    if ((controlWidth != width) || (controlHeight != height))
                    {
                        Chart.Size = new Size(controlWidth, controlHeight - 120);
                    }
                }
            }

            //if (cy < 550)
            //{
            //    m_wndGraph.GetAxis().GetLeft().SetIncrement(.75);
            //}
            //else if (cx < 850)
            //{
            //    m_wndGraph.GetAxis().GetLeft().SetIncrement(.5);
            //}
            //else
            //{
            //    m_wndGraph.GetAxis().GetLeft().SetIncrement(.25);
            //}

            //if (cx < 650)
            //{
            //    m_wndGraph.GetAxis().GetBottom().SetIncrement(.5);
            //}
            //else if (cx < 850)
            //{
            //    m_wndGraph.GetAxis().GetBottom().SetIncrement(.25);
            //}
            //else
            //{
            //    m_wndGraph.GetAxis().GetBottom().SetIncrement(.2);
            //}
        }

        private void Chart_PostPaint(object sender, ChartPaintEventArgs e)
        {
            if (sender is Chart)
            {
                Chart chart = (Chart)sender;

            }
        }

        private void UserTargetButton_Click(object sender, EventArgs e)
        {

        }

        //private void AllOffOnButton_Click(object sender, EventArgs e)
        //{
        //    if (Chart.Series != null && Chart.Series.Count > 0)
        //    {
        //        if (AllOff)
        //        {
        //            AllOffOnButton.Text = "All On";
        //            foreach (Series series in Chart.Series)
        //            {
        //                if (series.XValueMember.StartsWith("L/G-Approach"))
        //                {
        //                    series.Enabled = false;
        //                }
        //                else
        //                {
        //                    Chart.ChartAreas[0].AxisX.IsLogarithmic = false;
        //                    Chart.ChartAreas[0].AxisY.IsLogarithmic = false;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            AllOffOnButton.Text = "All Off";
        //            foreach (Series series in Chart.Series)
        //            {
        //                if (series.XValueMember.StartsWith("L/G-Approach"))
        //                {
        //                    series.Enabled = true;
        //                }
        //            }
        //        }
        //        AllOff = !AllOff;
        //    }
        //}
    }
}
