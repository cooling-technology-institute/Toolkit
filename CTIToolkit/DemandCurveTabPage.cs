// Copyright Cooling Technology Institute 2019-2021

using CTIToolkit.Properties;
using Models;
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
        enum TurnOffOn
        {
            TurnOn,
            TurnOff,
            Toggle
        };

        const int INDEX_TARGETAPPROACH = 18;
        const int INDEX_USERAPPROACH = 19;
        const int INDEX_Charactertics = 20;
        const int INDEX_LG = 21;
        const int INDEX_KAVL = 22;

        //private const string CheckedString = "✔";
        //private const string UncheckedString = "✘";

        private const string CheckedString = "☑";
        private const string UncheckedString = "☐";
        private const string AllOnString = "AllOn";
        private const string AllOffString = "AllOff";
        private const string GridString = "Grid";

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

                if (DemandCurveViewModel.Calculate())
                {
                    // AxisX, AxisY, AxisX2 and AxisY2
                    //Primary X-Axis  Bottom horizontal axis.
                    //Secondary X-Axis    Top horizontal axis.
                    //Primary Y-Axis  Left vertical axis.
                    //Secondary Y-Axis    Right vertical axis.
                    DrawSeries(Chart, false);
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
            NameValueUnitsDataTable nameValueUnitsDataTable = new NameValueUnitsDataTable();

            nameValueUnitsDataTable.AddRow(DemandCurveViewModel.WetBulbTemperatureDataValueInputMessage, WetBulbTemperatureValue.Text, WebBulbTemperatureUnits.Text);
            nameValueUnitsDataTable.AddRow(DemandCurveViewModel.RangeDataValueInputMessage, RangeValue.Text, RangeUnits.Text);

            if (ElevationRadio.Checked)
            {
                nameValueUnitsDataTable.AddRow(DemandCurveViewModel.ElevationDataValueInputMessage, DemandCurveViewModel.ElevationDataValueInputValue, ElevationPressureUnits.Text);
            }
            else
            {
                nameValueUnitsDataTable.AddRow(DemandCurveViewModel.BarometricPressureDataValueInputMessage, DemandCurveViewModel.BarometricPressureDataValueInputValue, ElevationPressureUnits.Text);
            }
            nameValueUnitsDataTable.AddRow(DemandCurveViewModel.C1DataValueInputMessage, C_C1_Value.Text, string.Empty);
            nameValueUnitsDataTable.AddRow(DemandCurveViewModel.SlopeDataValueInputMessage, Slope_C2_Value.Text, string.Empty);
            nameValueUnitsDataTable.AddRow(DemandCurveViewModel.MaximumDataValueInputMessage, MaximumValue.Text, string.Empty);
            nameValueUnitsDataTable.AddRow(DemandCurveViewModel.MinimumDataValueInputMessage, MinimumValue.Text, string.Empty);
            nameValueUnitsDataTable.AddRow(DemandCurveViewModel.LiquidToGasRatioDataValueInputMessage, LiquidToGasRatioValue.Text, string.Empty);
            nameValueUnitsDataTable.AddRow(DemandCurveViewModel.UserApproachDataValueInputMessage, UserApproachValue.Text, UserApproachUnits.Text);

            DemandCurvePrinterOutput printerOutput = new DemandCurvePrinterOutput(e.PageBounds.Height - 80, this.PrintControl.Label, nameValueUnitsDataTable, DemandCurveViewModel);
            Chart chart = printerOutput.Controls["Chart"] as Chart;
            InitializeChart(chart, true);
            DrawSeries(chart, true);

            printerOutput.CreateControl();
            var bm = new Bitmap(printerOutput.Width, printerOutput.Height);
            printerOutput.DrawToBitmap(bm, new Rectangle(0, 0, bm.Width, bm.Height));
            e.Graphics.DrawImage(bm, 40, 40);
        }

        private void DrawSeries(Chart chart, bool isPrintPage)
        {
            if (DemandCurveViewModel.Approaches.Count > 0)
            {
                chart.Series.Clear();
                chart.ChartAreas[0].AxisX.IsLogarithmic = true;
                chart.ChartAreas[0].AxisY.IsLogarithmic = true;

                foreach (Approach approach in DemandCurveViewModel.Approaches)
                {
                    if (approach.InRange && approach.Points.Count > 0)
                    {
                        Series series = new Series()
                        {
                            ChartArea = "ChartArea1",
                            ChartType = SeriesChartType.Line,
                            Name = approach.Name
                        };
                        DemandCurveViewModel.FillSeries(series);
                        if(!isPrintPage)
                        {
                            series.SetCustomProperty("CHECK", CheckedString);
                        }
                        chart.Series.Add(series);
                    }
                }

                if (DemandCurveViewModel.GetOutputDataTable() != null)
                {
                    OutputGridView.DataSource = new DataView(DemandCurveViewModel.GetOutputDataTable());
                }
            }
            else
            {
                chart.ChartAreas[0].AxisX.IsLogarithmic = false;
                chart.ChartAreas[0].AxisY.IsLogarithmic = false;
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

        private void Chart_Click(object sender, EventArgs e)
        {

        }
        private void TurnSeriesOffOn(Series series, TurnOffOn turnOffOn)
        {
            if ((series != null) && (series.GetCustomProperty("CHECK") != null))
            {
                switch(turnOffOn)
                {
                    case TurnOffOn.Toggle:
                        if (series.GetCustomProperty("CHECK").Equals(CheckedString))
                        {
                            series.SetCustomProperty("CHECK", UncheckedString);
                            series.Points.Clear();
                        }
                        else if (series.GetCustomProperty("CHECK").Equals(UncheckedString))
                        {
                            series.SetCustomProperty("CHECK", CheckedString);
                            if (!Chart.ChartAreas[0].AxisX.IsLogarithmic)
                            {
                                Chart.ChartAreas[0].AxisX.IsLogarithmic = true;
                                Chart.ChartAreas[0].AxisY.IsLogarithmic = true;
                            }
                            DemandCurveViewModel.FillSeries(series);
                        }
                        break;
                    case TurnOffOn.TurnOff:
                        if (series.GetCustomProperty("CHECK").Equals(CheckedString))
                        {
                            series.SetCustomProperty("CHECK", UncheckedString);
                            series.Points.Clear();
                        }
                        break;
                    case TurnOffOn.TurnOn:
                        if (series.GetCustomProperty("CHECK").Equals(UncheckedString))
                        {
                            series.SetCustomProperty("CHECK", CheckedString);
                            if (!Chart.ChartAreas[0].AxisX.IsLogarithmic)
                            {
                                Chart.ChartAreas[0].AxisX.IsLogarithmic = true;
                                Chart.ChartAreas[0].AxisY.IsLogarithmic = true;
                            }
                            DemandCurveViewModel.FillSeries(series);
                        }
                        break;
                }
            }
        }

        private void Chart_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult result = Chart.HitTest(e.X, e.Y);
            try
            {
                if (result != null && result.Object != null)
                {
                    if(e.Button == MouseButtons.Right)
                    {
                        double approach = 0.0;
                        double lg = 0.0;
                        double kval = 0.0;
                        if (result.Object is ChartArea)
                        {
                            lg = Math.Pow(10, Chart.ChartAreas[0].AxisX.PixelPositionToValue(e.X));
                            kval = Math.Pow(10, Chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Y));
                        }
                        else if (result.Object is DataPoint)
                        {
                            DataPoint dataPoint = result.Object as DataPoint;
                            lg = dataPoint.XValue;
                            kval = dataPoint.YValues[0];
                        }
                        if(lg != 0.0 && kval != 0.0)
                        {
                            approach = DemandCurveViewModel.CalculateExactApproach(lg, kval);
                            MessageBox.Show(string.Format("Approach={0}\n\nL/G={1}\n\nKaV/L={2}\n\n", approach.ToString("F3"), lg.ToString("F3"), kval.ToString("F5")));
                        }
                    }
                    else if (e.Button == MouseButtons.Left)
                    {
                        if (result.Object is LegendItem)
                        {
                            LegendItem legendItem = (LegendItem)result.Object;
                            if (string.IsNullOrWhiteSpace(legendItem.SeriesName))
                            {
                                if (legendItem.Name == AllOnString)
                                {
                                    foreach (Series series in Chart.Series)
                                    {
                                        TurnSeriesOffOn(series, TurnOffOn.TurnOn);
                                    }
                                }
                                else if (legendItem.Name == AllOffString)
                                {
                                    Chart.ChartAreas[0].AxisX.IsLogarithmic = false;
                                    Chart.ChartAreas[0].AxisY.IsLogarithmic = false;
                                    foreach (Series series in Chart.Series)
                                    {
                                        TurnSeriesOffOn(series, TurnOffOn.TurnOff);
                                    }
                                }
                                else if (legendItem.Name == GridString)
                                {
                                    if (legendItem.Cells[0].Text == CheckedString)
                                    {
                                        legendItem.Cells[0].Text = UncheckedString;
                                        Chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                                        Chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                                        Chart.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
                                        Chart.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
                                    }
                                    else
                                    {
                                        legendItem.Cells[0].Text = CheckedString;
                                        Chart.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
                                        Chart.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
                                        Chart.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
                                        Chart.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
                                    }
                                }
                            }
                            else
                            {
                                Series series = Chart.Series[legendItem.SeriesName];
                                TurnSeriesOffOn(series, TurnOffOn.Toggle);
                            }
                        }
                    }
                }

            } catch
            {

            }
        }

        private void InitializeChart(Chart chart, bool isPrintPage)
        {
            chart.SuppressExceptions = true;
            chart.ChartAreas[0].AxisX.IsLogarithmic = false;
            chart.ChartAreas[0].AxisY.IsLogarithmic = false;

            chart.Series.Clear();

            if (!isPrintPage)
            {
                chart.Legends[0].CellColumns.Clear();
                chart.Legends[0].CellColumns.Add(new LegendCellColumn()
                {
                    Name = "Check",
                    ColumnType = LegendCellColumnType.Text,
                    Text = "#CUSTOMPROPERTY(CHECK)",
                });
                chart.Legends[0].CellColumns.Add(new LegendCellColumn()
                {
                    Name = "Symbol",
                    ColumnType = LegendCellColumnType.SeriesSymbol
                });
                chart.Legends[0].CellColumns.Add(new LegendCellColumn()
                {
                    Name = "Name",
                    ColumnType = LegendCellColumnType.Text,
                    Text = "#LEGENDTEXT"
                });

                LegendItem allOnLegendItem = new LegendItem()
                {
                    Name = AllOnString,
                };
                allOnLegendItem.Cells.Add(new LegendCell(LegendCellType.Text, CheckedString));
                allOnLegendItem.Cells.Add(new LegendCell(LegendCellType.Text, string.Empty));
                allOnLegendItem.Cells.Add(new LegendCell(LegendCellType.Text, "All On"));
                chart.Legends[0].CustomItems.Add(allOnLegendItem);

                LegendItem allOffLegendItem = new LegendItem()
                {
                    Name = AllOffString,
                };
                allOffLegendItem.Cells.Add(new LegendCell(LegendCellType.Text, UncheckedString));
                allOffLegendItem.Cells.Add(new LegendCell(LegendCellType.Text, string.Empty));
                allOffLegendItem.Cells.Add(new LegendCell(LegendCellType.Text, "All Off"));
                chart.Legends[0].CustomItems.Add(allOffLegendItem);

                LegendItem gridOffOnLegendItem = new LegendItem()
                {
                    Name = GridString,
                };
                gridOffOnLegendItem.Cells.Add(new LegendCell(LegendCellType.Text, CheckedString));
                gridOffOnLegendItem.Cells.Add(new LegendCell(LegendCellType.Text, string.Empty));
                gridOffOnLegendItem.Cells.Add(new LegendCell(LegendCellType.Text, GridString));
                chart.Legends[0].CustomItems.Add(gridOffOnLegendItem);
            }

            chart.ChartAreas[0].AxisX.Title = "L/G";
            chart.ChartAreas[0].AxisX.Maximum = 6;
            chart.ChartAreas[0].AxisX.RoundAxisValues();
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "0.00";
            chart.ChartAreas[0].AxisX.LabelStyle.Angle = 90;
            chart.ChartAreas[0].AxisX.Interval = 0.2;
            chart.ChartAreas[0].AxisX.IntervalOffset = 0.1;
            chart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Number;
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chart.ChartAreas[0].AxisX.MajorGrid.Interval = 0.2;
            chart.ChartAreas[0].AxisX.MajorGrid.IntervalOffset = 0.1;
            chart.ChartAreas[0].AxisX.MajorTickMark.Enabled = true;
            chart.ChartAreas[0].AxisX.MajorTickMark.Interval = 0.2;
            chart.ChartAreas[0].AxisX.MajorTickMark.IntervalOffset = 0.1;
            chart.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart.ChartAreas[0].AxisX.MinorTickMark.Enabled = false;

            chart.ChartAreas[0].AxisY.Title = "KaV/L";
            chart.ChartAreas[0].AxisY.Maximum = 6;
            chart.ChartAreas[0].AxisY.RoundAxisValues();
            chart.ChartAreas[0].AxisY.LabelStyle.Format = "0.00";
            chart.ChartAreas[0].AxisY.Interval = 0.2;
            chart.ChartAreas[0].AxisY.IntervalOffset = 0.1;
            chart.ChartAreas[0].AxisY.IntervalType = DateTimeIntervalType.Number;
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart.ChartAreas[0].AxisY.MajorGrid.Interval = 0.2;
            chart.ChartAreas[0].AxisY.MajorGrid.IntervalOffset = 0.1;
            chart.ChartAreas[0].AxisY.MajorTickMark.Enabled = true;
            chart.ChartAreas[0].AxisY.MajorTickMark.Interval = 0.2;
            chart.ChartAreas[0].AxisY.MajorTickMark.IntervalOffset = 0.1;
            chart.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chart.ChartAreas[0].AxisY.MinorTickMark.Enabled = false;

            chart.Legends[0].Title = "Approach";

            if(!isPrintPage)
            {
                chart.ChartAreas[0].CursorX.AutoScroll = true;
                chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                chart.ChartAreas[0].CursorX.IsUserEnabled = true;
                chart.ChartAreas[0].CursorX.Interval = 0.01;

                chart.ChartAreas[0].CursorY.AutoScroll = true;
                chart.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
                chart.ChartAreas[0].CursorY.IsUserEnabled = true;
                chart.ChartAreas[0].CursorY.Interval = 0.01;

            }
        }

        private void DemandCurveTabPage_Load(object sender, EventArgs e)
        {
            InitializeChart(Chart, false);
        }

        private void Chart_Resize(object sender, EventArgs e)
        {
            if (Chart.Size.Width > 1500)
            {
                Chart.ChartAreas[0].AxisX.Interval = 0.05;
                Chart.ChartAreas[0].AxisX.IntervalOffset = 0.1;
                Chart.ChartAreas[0].AxisX.MajorGrid.Interval = 0.05;
                Chart.ChartAreas[0].AxisX.MajorGrid.IntervalOffset = 0.1;
                Chart.ChartAreas[0].AxisX.MajorTickMark.Interval = 0.05;
                Chart.ChartAreas[0].AxisX.MajorTickMark.IntervalOffset = 0.1;
            }
            else if (Chart.Size.Width > 1000)
            {
                Chart.ChartAreas[0].AxisX.Interval = 0.1;
                Chart.ChartAreas[0].AxisX.IntervalOffset = 0.1;
                Chart.ChartAreas[0].AxisX.MajorGrid.Interval = 0.1;
                Chart.ChartAreas[0].AxisX.MajorGrid.IntervalOffset = 0.1;
                Chart.ChartAreas[0].AxisX.MajorTickMark.Interval = 0.1;
                Chart.ChartAreas[0].AxisX.MajorTickMark.IntervalOffset = 0.1;
            }
            else //if (Chart.ChartAreas[0].Position.Width > 100)
            {
                Chart.ChartAreas[0].AxisX.Interval = 0.2;
                Chart.ChartAreas[0].AxisX.IntervalOffset = 0.1;
                Chart.ChartAreas[0].AxisX.MajorGrid.Interval = 0.2;
                Chart.ChartAreas[0].AxisX.MajorGrid.IntervalOffset = 0.1;
                Chart.ChartAreas[0].AxisX.MajorTickMark.Interval = 0.2;
                Chart.ChartAreas[0].AxisX.MajorTickMark.IntervalOffset = 0.1;
            }

            if (Chart.Size.Height > 200)
            {
                Chart.ChartAreas[0].AxisY.Interval = 0.05;
                Chart.ChartAreas[0].AxisY.IntervalOffset = 0.1;
                Chart.ChartAreas[0].AxisY.MajorGrid.Interval = 0.05;
                Chart.ChartAreas[0].AxisY.MajorGrid.IntervalOffset = 0.1;
                Chart.ChartAreas[0].AxisY.MajorTickMark.Interval = 0.05;
                Chart.ChartAreas[0].AxisY.MajorTickMark.IntervalOffset = 0.1;
            }
            else if (Chart.Size.Height > 100)
            {
                Chart.ChartAreas[0].AxisY.Interval = 0.1;
                Chart.ChartAreas[0].AxisY.IntervalOffset = 0.1;
                Chart.ChartAreas[0].AxisY.MajorGrid.Interval = 0.1;
                Chart.ChartAreas[0].AxisY.MajorGrid.IntervalOffset = 0.1;
                Chart.ChartAreas[0].AxisY.MajorTickMark.Interval = 0.1;
                Chart.ChartAreas[0].AxisY.MajorTickMark.IntervalOffset = 0.1;
            }
            else //if (Chart.ChartAreas[0].Position.Height > 100)
            {
                Chart.ChartAreas[0].AxisY.Interval = 0.2;
                Chart.ChartAreas[0].AxisY.IntervalOffset = 0.1;
                Chart.ChartAreas[0].AxisY.MajorGrid.Interval = 0.2;
                Chart.ChartAreas[0].AxisY.MajorGrid.IntervalOffset = 0.1;
                Chart.ChartAreas[0].AxisY.MajorTickMark.Interval = 0.2;
                Chart.ChartAreas[0].AxisY.MajorTickMark.IntervalOffset = 0.1;
            }
        }
    }
}
