// Copyright Cooling Technology Institute 2019-2022

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
        private bool IsChanged { get; set; }

        public DemandCurveTabPage(ApplicationSettings applicationSettings, string documentPath)
        {
            InitializeComponent();

            Filter = "Demand Curve files (*.dc)|*.dc|All files (*.*)|*.*";
            DefaultExt = "dc";
            Title = "Demand Curve";
            DefaultFileName = "DemandCurve";
            
            IsInternationalSystemOfUnits_SI = (applicationSettings.UnitsSelection == UnitsSelection.International_System_Of_Units_SI);
            IsDemo = applicationSettings.IsDemo;

            DemandCurveViewModel = new DemandCurveViewModel(IsDemo, IsInternationalSystemOfUnits_SI);
            DemandCurveViewModel.DataFileName = BuildDefaultFileName(documentPath);

            IsChanged = false;

            SetDisplayedValues();
        }

        public void UpdateDemo(bool isDemo)
        {
            if (IsDemo != isDemo)
            {
                IsDemo = isDemo;
                DemandCurveViewModel.UpdateDemo(isDemo);
            }
        }

        public void SetUnitsStandard(bool isInternationalSystemOfUnits_SI)
        {
            if (IsInternationalSystemOfUnits_SI != isInternationalSystemOfUnits_SI)
            {
                IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;
                SetDisplayedValues();
                Calculate();
            }
        }

        private void SwitchUnits()
        {
            DemandCurveViewModel.ConvertValues(IsInternationalSystemOfUnits_SI);
            WebBulbTemperatureUnits.Text = DemandCurveViewModel.WetBulbTemperatureDataValue.Units;
            RangeUnits.Text = DemandCurveViewModel.RangeDataValue.Units;
            UserApproachUnits.Text = DemandCurveViewModel.UserApproachDataValue.Units;
            if (ElevationRadio.Checked)
            {
                ElevationPressureUnits.Text = DemandCurveViewModel.ElevationDataValue.Units;
            }
            else
            {
                ElevationPressureUnits.Text = DemandCurveViewModel.BarometricPressureDataValue.Units;
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
        }

        private void SetDisplayedValues()
        {
            DataFilename.Text = DemandCurveViewModel.DataFilenameInputValue;

            SetRadioButtons();
            SwitchUnits();

            WetBulbTemperatureLabel.Text = DemandCurveViewModel.WetBulbTemperatureDataValue.InputMessage + ":";
            WetBulbTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
            WetBulbTemperatureValue.Text = DemandCurveViewModel.WetBulbTemperatureDataValue.InputValue;
            toolTip1.SetToolTip(WetBulbTemperatureValue, DemandCurveViewModel.WetBulbTemperatureDataValue.ToolTip);

            RangeLabel.Text = DemandCurveViewModel.RangeDataValue.InputMessage + ":";
            RangeLabel.TextAlign = ContentAlignment.MiddleRight;
            RangeValue.Text = DemandCurveViewModel.RangeDataValue.InputValue;
            toolTip1.SetToolTip(RangeValue, DemandCurveViewModel.RangeDataValue.ToolTip);

            if (ElevationRadio.Checked)
            {
                ElevationPressureLabel.Text = DemandCurveViewModel.ElevationDataValue.InputMessage + ":";
                ElevationPressureLabel.TextAlign = ContentAlignment.MiddleRight;
                ElevationValue.Text = DemandCurveViewModel.ElevationDataValue.InputValue;
                toolTip1.SetToolTip(ElevationValue, DemandCurveViewModel.ElevationDataValue.ToolTip);
            }
            else
            {
                ElevationPressureLabel.Text = DemandCurveViewModel.BarometricPressureDataValue.InputMessage + ":";
                ElevationPressureLabel.TextAlign = ContentAlignment.MiddleRight;
                ElevationValue.Text = DemandCurveViewModel.BarometricPressureDataValue.InputValue;
                toolTip1.SetToolTip(ElevationValue, DemandCurveViewModel.BarometricPressureDataValue.ToolTip);
            }

            CLabel.Text = DemandCurveViewModel.C1DataValue.InputMessage + ":";
            CLabel.TextAlign = ContentAlignment.MiddleRight;
            C_C1_Value.Text = DemandCurveViewModel.C1DataValue.InputValue;
            toolTip1.SetToolTip(C_C1_Value, DemandCurveViewModel.C1DataValue.ToolTip);

            SlopeLabel.Text = DemandCurveViewModel.SlopeDataValue.InputMessage + ":";
            SlopeLabel.TextAlign = ContentAlignment.MiddleRight;
            Slope_C2_Value.Text = DemandCurveViewModel.SlopeDataValue.InputValue;
            toolTip1.SetToolTip(Slope_C2_Value, DemandCurveViewModel.SlopeDataValue.ToolTip);

            MinimumLabel.Text = DemandCurveViewModel.MinimumDataValue.InputMessage + ":";
            MinimumLabel.TextAlign = ContentAlignment.MiddleRight;
            MinimumValue.Text = DemandCurveViewModel.MinimumDataValue.InputValue;
            toolTip1.SetToolTip(MinimumValue, DemandCurveViewModel.MinimumDataValue.ToolTip);

            MaximumLabel.Text = DemandCurveViewModel.MaximumDataValue.InputMessage + ":";
            MaximumLabel.TextAlign = ContentAlignment.MiddleRight;
            MaximumValue.Text = DemandCurveViewModel.MaximumDataValue.InputValue;
            toolTip1.SetToolTip(MaximumValue, DemandCurveViewModel.MaximumDataValue.ToolTip);

            LiquidToGasRatioLabel.Text = DemandCurveViewModel.LiquidToGasRatioDataValue.InputMessage + ":";
            LiquidToGasRatioLabel.TextAlign = ContentAlignment.MiddleRight;
            LiquidToGasRatioValue.Text = DemandCurveViewModel.LiquidToGasRatioDataValue.InputValue;
            toolTip1.SetToolTip(LiquidToGasRatioValue, DemandCurveViewModel.LiquidToGasRatioDataValue.ToolTip);

            UserApproachLabel.Text = DemandCurveViewModel.UserApproachDataValue.InputMessage + ":";
            UserApproachLabel.TextAlign = ContentAlignment.MiddleRight;
            UserApproachValue.Text = DemandCurveViewModel.UserApproachDataValue.InputValue;
            toolTip1.SetToolTip(UserApproachValue, DemandCurveViewModel.UserApproachDataValue.ToolTip);
        }

        public override void Calculate()
        {
            try
            {
                Chart.Series.Clear();
                if (DemandCurveViewModel.Calculate())
                {
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
                if(!DemandCurveViewModel.LoadDataFile())
                {
                    returnValue = false;
                    stringBuilder.AppendLine(DemandCurveViewModel.ErrorMessage);
                }

                if (DemandCurveViewModel.IsInternationalSystemOfUnits_SI != IsInternationalSystemOfUnits_SI)
                {
                    ToolkitMain main = this.Parent.Parent.Parent as ToolkitMain;
                    if (main != null)
                    {
                        main.UpdateUnits(DemandCurveViewModel.IsInternationalSystemOfUnits_SI ? UnitsSelection.International_System_Of_Units_SI : UnitsSelection.United_States_Customary_Units_IP);
                    }
                }

                SetDisplayedValues();

                if(returnValue)
                {
                    Calculate();
                }
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
            else
            {
                IsChanged = false;
            }

            SetDisplayedValues();

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
            else
            {
                IsChanged = false;
            }

            ErrorMessage = stringBuilder.ToString();
            return returnValue;
        }

        public override void PrintPage(object sender, PrintPageEventArgs e)
        {
            NameValueUnitsDataTable nameValueUnitsDataTable = new NameValueUnitsDataTable();

            nameValueUnitsDataTable.AddRow(DemandCurveViewModel.WetBulbTemperatureDataValue.InputMessage, WetBulbTemperatureValue.Text, WebBulbTemperatureUnits.Text);
            nameValueUnitsDataTable.AddRow(DemandCurveViewModel.RangeDataValue.InputMessage, RangeValue.Text, RangeUnits.Text);
            nameValueUnitsDataTable.AddRow(DemandCurveViewModel.ElevationDataValue.InputMessage, DemandCurveViewModel.ElevationDataValue.InputValue, DemandCurveViewModel.ElevationDataValue.Units);
            nameValueUnitsDataTable.AddRow(DemandCurveViewModel.BarometricPressureDataValue.InputMessage, DemandCurveViewModel.BarometricPressureDataValue.InputValue, DemandCurveViewModel.BarometricPressureDataValue.Units);
            nameValueUnitsDataTable.AddRow(DemandCurveViewModel.C1DataValue.InputMessage, C_C1_Value.Text, string.Empty);
            nameValueUnitsDataTable.AddRow(DemandCurveViewModel.SlopeDataValue.InputMessage, Slope_C2_Value.Text, string.Empty);
            //nameValueUnitsDataTable.AddRow(DemandCurveViewModel.MaximumDataValue.InputMessage, MaximumValue.Text, string.Empty);
            //nameValueUnitsDataTable.AddRow(DemandCurveViewModel.MinimumDataValue.InputMessage, MinimumValue.Text, string.Empty);
            nameValueUnitsDataTable.AddRow(DemandCurveViewModel.LiquidToGasRatioDataValue.InputMessage, LiquidToGasRatioValue.Text, string.Empty);

            bool shouldDisplayUserApproach = (DemandCurveViewModel.UserApproachDataValue.Current != 0.0);
            if(shouldDisplayUserApproach)
            {
                foreach (Series series in Chart.Series)
                {
                    if (series.Name == "User")
                    {
                        shouldDisplayUserApproach = series.GetCustomProperty("CHECK").Equals(CheckedString);
                    }
                }
            }

            nameValueUnitsDataTable.AddRow(DemandCurveViewModel.UserApproachDataValue.InputMessage,
                    (shouldDisplayUserApproach) ? UserApproachValue.Text : "N/A", UserApproachUnits.Text);

            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; // so footer is anti-aliased
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;  // so when we scale up, we smooth out the jaggies somewhat
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            DrawLogo(e, 0, 0);
            DrawText(e, 18, FontStyle.Bold, "CTI Demand Curve Report", 143, 0, true);
            if (!string.IsNullOrWhiteSpace(this.PrintControl.Label))
            {
                DrawText(e, 18, FontStyle.Bold, this.PrintControl.Label, 143, 34, true);
            }
            float y = 145;
            y += DrawText(e, 12, FontStyle.Regular, "Input Properties:", 3, y, false);
            y += DrawDataTable(e, nameValueUnitsDataTable.DataTable, 7, y);
            float y1 = 145;
            y1 += DrawText(e, 12, FontStyle.Regular, "Output:", e.PageSettings.Bounds.Width / 2 + 3, y1, false);
            y1 += DrawDataTable(e, DemandCurveViewModel.DataTable, e.PageSettings.Bounds.Width / 2 + 7, y1);

            y += DrawText(e, 12, FontStyle.Regular, "KaV/L = C * (L/G) ^ Slope", 3, y, false);
            y += 50;

            int width = Chart.Size.Width;
            int height = Chart.Size.Height;
            Chart.Size = new Size(e.PageSettings.Bounds.Width - (int) MARGIN, e.PageSettings.Bounds.Height / 2 - (int)MARGIN);
            PrintControl.Bitmap = new Bitmap(Chart.Width, Chart.Height);
            Chart.DrawToBitmap(PrintControl.Bitmap, new Rectangle(0, 0, PrintControl.Bitmap.Width, PrintControl.Bitmap.Height));
            e.Graphics.DrawImage(PrintControl.Bitmap, new PointF(3, y));
            Chart.Size = new Size(width, height);

            e.Graphics.DrawString("CTI Toolkit 4.0",
                                new Font("Times New Roman", 16),
                                new SolidBrush(Color.Red),
                                MARGIN, e.PageSettings.Bounds.Height - MARGIN);

            using (Font font = new Font("Times New Roman", 8))
            {
                SizeF size = e.Graphics.MeasureString(DemandCurveViewModel.DataFilenameInputValue, font);
                e.Graphics.DrawString(DemandCurveViewModel.DataFilenameInputValue,
                                      font,
                                      new SolidBrush(Color.Black),
                                      e.PageSettings.Bounds.Width - size.Width - MARGIN, e.PageSettings.Bounds.Height - MARGIN);
            }
        }

        private void DrawSeries(Chart chart, bool isPrintPage)
        {
            // AxisX, AxisY, AxisX2 and AxisY2
            //Primary X-Axis  Bottom horizontal axis.
            //Secondary X-Axis    Top horizontal axis.
            //Primary Y-Axis  Left vertical axis.
            //Secondary Y-Axis    Right vertical axis.
            if (DemandCurveViewModel.Approaches.Count > 0)
            {
                chart.ChartAreas[0].AxisX.IsLogarithmic = false;
                chart.ChartAreas[0].AxisY.IsLogarithmic = false;

                chart.ChartAreas[0].CursorX.SelectionStart = chart.ChartAreas[0].CursorX.SelectionEnd = double.NaN;
                chart.ChartAreas[0].CursorY.SelectionStart = chart.ChartAreas[0].CursorY.SelectionEnd = double.NaN;
                chart.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
                chart.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);

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

                if (DemandCurveViewModel.DataTable != null)
                {
                    OutputGridView.DataSource = new DataView(DemandCurveViewModel.DataTable);
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
            ValidatedForm();
            Calculate();
        }

        private void DemandCurveChart_Click(object sender, EventArgs e)
        {
            // get xy
            // determine value
            // update page
        }

        private void ValidatedValues()
        {
            if (!DemandCurveViewModel.LiquidToGasRatioDataValue.IsValid)
            {
                errorProvider1.SetError(LiquidToGasRatioValue, DemandCurveViewModel.LiquidToGasRatioDataValue.ErrorMessage);
            }
        }
        
        public override void ValidatedForm()
        {
            object sender = new object();
            EventArgs e = new EventArgs();

            LiquidToGasRatioValue_Validated(sender, e);
            WetBulbTemperature_Value_Validated(sender, e);
            RangeValue_Validated(sender, e);
            ElevationValue_Validated(sender, e);
            C_C1_Value_Validated(sender, e);
            Slope_C2_Value_Validated(sender, e);
            MaximumValue_Validated(sender, e);
            MinimumValue_Validated(sender, e);
            UserApproachValue_Validated(sender, e);
        }

        private void LiquidToGasRatioValue_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(LiquidToGasRatioValue, "");
        }

        private void LiquidToGasRatioValue_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (DemandCurveViewModel.LiquidToGasRatioDataValue.InputValue != LiquidToGasRatioValue.Text)
            {
                ClearPage();
            }
            if (!DemandCurveViewModel.LiquidToGasRatioDataValue.UpdateValue(LiquidToGasRatioValue.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                LiquidToGasRatioValue.Select(0, LiquidToGasRatioValue.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(LiquidToGasRatioValue, DemandCurveViewModel.LiquidToGasRatioDataValue.ErrorMessage);
            }
        }

        private void WetBulbTemperature_Value_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(WetBulbTemperatureValue, "");
        }

        private void WetBulbTemperature_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (DemandCurveViewModel.WetBulbTemperatureDataValue.InputValue != WetBulbTemperatureValue.Text)
            {
                ClearPage();
            }
            if (!DemandCurveViewModel.WetBulbTemperatureDataValue.UpdateValue(WetBulbTemperatureValue.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                WetBulbTemperatureValue.Select(0, WetBulbTemperatureValue.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(WetBulbTemperatureValue, DemandCurveViewModel.WetBulbTemperatureDataValue.ErrorMessage);
            }
        }

        private void RangeValue_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(RangeValue, "");
        }

        private void RangeValue_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (DemandCurveViewModel.RangeDataValue.InputValue != RangeValue.Text)
            {
                ClearPage();
            }
            if (!DemandCurveViewModel.RangeDataValue.UpdateValue(RangeValue.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                RangeValue.Select(0, RangeValue.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(RangeValue, DemandCurveViewModel.RangeDataValue.ErrorMessage);
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
                if (DemandCurveViewModel.ElevationDataValue.InputValue != ElevationValue.Text)
                {
                    ClearPage();
                }
                if (!DemandCurveViewModel.ElevationDataValue.UpdateValue(ElevationValue.Text))
                {
                    // Cancel the event and select the text to be corrected by the user.
                    e.Cancel = true;
                    ElevationValue.Select(0, ElevationValue.Text.Length);

                    // Set the ErrorProvider error with the text to display. 
                    this.errorProvider1.SetError(ElevationValue, DemandCurveViewModel.ElevationDataValue.ErrorMessage);
                }
            }
            else
            {
                if (DemandCurveViewModel.BarometricPressureDataValue.InputValue != ElevationValue.Text)
                {
                    ClearPage();
                }
                if (!DemandCurveViewModel.BarometricPressureDataValue.UpdateValue(ElevationValue.Text))
                {
                    // Cancel the event and select the text to be corrected by the user.
                    e.Cancel = true;
                    ElevationValue.Select(0, ElevationValue.Text.Length);

                    // Set the ErrorProvider error with the text to display. 
                    this.errorProvider1.SetError(ElevationValue, DemandCurveViewModel.BarometricPressureDataValue.ErrorMessage);
                }
            }
        }

        private void C_C1_Value_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(C_C1_Value, "");
        }

        private void C_C1_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (DemandCurveViewModel.C1DataValue.InputValue != C_C1_Value.Text)
            {
                ClearPage();
            }
            if (!DemandCurveViewModel.C1DataValue.UpdateValue(C_C1_Value.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                C_C1_Value.Select(0, C_C1_Value.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(C_C1_Value, DemandCurveViewModel.C1DataValue.ErrorMessage);
            }
        }

        private void Slope_C2_Value_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Slope_C2_Value, "");
        }

        private void Slope_C2_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (DemandCurveViewModel.SlopeDataValue.InputValue != Slope_C2_Value.Text)
            {
                ClearPage();
            }
            if (!DemandCurveViewModel.SlopeDataValue.UpdateValue(Slope_C2_Value.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Slope_C2_Value.Select(0, Slope_C2_Value.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Slope_C2_Value, DemandCurveViewModel.SlopeDataValue.ErrorMessage);
            }
        }

        private void MaximumValue_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(MaximumValue, "");
        }

        private void MaximumValue_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (DemandCurveViewModel.MaximumDataValue.InputValue != MaximumValue.Text)
            {
                ClearPage();
            }
            if (!DemandCurveViewModel.MaximumDataValue.UpdateValue(MaximumValue.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                MaximumValue.Select(0, MaximumValue.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(MaximumValue, DemandCurveViewModel.MaximumDataValue.ErrorMessage);
            }
        }

        private void MinimumValue_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(MinimumValue, "");
        }

        private void MinimumValue_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (DemandCurveViewModel.MinimumDataValue.InputValue != MinimumValue.Text)
            {
                ClearPage();
            }
            if (!DemandCurveViewModel.MinimumDataValue.UpdateValue(MinimumValue.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                MinimumValue.Select(0, MinimumValue.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(MinimumValue, DemandCurveViewModel.MinimumDataValue.ErrorMessage);
            }
        }

        private void UserApproachValue_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(UserApproachValue, "");
        }

        private void UserApproachValue_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (DemandCurveViewModel.UserApproachDataValue.InputValue != UserApproachValue.Text)
            {
                ClearPage();
            }
            if (!DemandCurveViewModel.UserApproachDataValue.UpdateValue(UserApproachValue.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                UserApproachValue.Select(0, UserApproachValue.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(UserApproachValue, DemandCurveViewModel.UserApproachDataValue.ErrorMessage);
            }
        }

        private void BarometricPressureRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (BarometricPressureRadio.Checked)
            {
                DemandCurveViewModel.IsElevation = false;
                ElevationValue.Text = DemandCurveViewModel.BarometricPressureDataValue.InputValue;
                ElevationPressureLabel.Text = DemandCurveViewModel.BarometricPressureDataValue.InputMessage;
                toolTip1.SetToolTip(ElevationValue, DemandCurveViewModel.BarometricPressureDataValue.ToolTip);
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

        private void ClearPage()
        {
            Chart.ChartAreas[0].AxisX.IsLogarithmic = false;
            Chart.ChartAreas[0].AxisY.IsLogarithmic = false;
            Chart.Series.Clear();
            OutputGridView.DataSource = null;
            IsChanged = true;
        }

        private void ElevationRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (ElevationRadio.Checked)
            {
                DemandCurveViewModel.IsElevation = true;
                ElevationValue.Text = DemandCurveViewModel.ElevationDataValue.InputValue;
                ElevationPressureLabel.Text = DemandCurveViewModel.ElevationDataValue.InputMessage;
                toolTip1.SetToolTip(ElevationValue, DemandCurveViewModel.ElevationDataValue.ToolTip);
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
                        else if (result.Object is Grid)
                        {
                            lg = Math.Pow(10, Chart.ChartAreas[0].AxisX.PixelPositionToValue(e.X));
                            kval = Math.Pow(10, Chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Y));
                        }
                        else if (result.Object is DataPoint)
                        {
                            lg = Math.Pow(10, Chart.ChartAreas[0].AxisX.PixelPositionToValue(e.X));
                            kval = Math.Pow(10, Chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Y));

                            //DataPoint dataPoint = result.Object as DataPoint;
                            //lg = dataPoint.XValue;
                            //kval = dataPoint.YValues[0];
                        }
                        if(lg != 0.0 && kval != 0.0)
                        {
                            approach = DemandCurveViewModel.CalculateExactApproach(lg, kval);
                            MessageBox.Show(string.Format("L/G = {0}\n\nKaV/L = {1}\n\n\nApproach = {2} {3}\n\n", lg.ToString("F3"), kval.ToString("F5"), approach.ToString("F3"), DemandCurveViewModel.RangeDataValue.Units), "Mouse Click at");
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
                                    // turn off and on check on All On and All Off
                                    legendItem.Cells[0].Text = CheckedString;
                                    ToggleOnOff(TurnOffOn.TurnOn);
                                }
                                else if (legendItem.Name == AllOffString)
                                {
                                    Chart.ChartAreas[0].AxisX.IsLogarithmic = false;
                                    Chart.ChartAreas[0].AxisY.IsLogarithmic = false;
                                    foreach (Series series in Chart.Series)
                                    {
                                        TurnSeriesOffOn(series, TurnOffOn.TurnOff);
                                    }
                                    // turn off and on check on All On and All Off
                                    legendItem.Cells[0].Text = CheckedString;
                                    ToggleOnOff(TurnOffOn.TurnOff);
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
                                ToggleOnOff(TurnOffOn.Toggle);
                            }
                        }
                    }
                }

            } catch
            {

            }
        }

        private void ToggleOnOff(TurnOffOn turnOffOn)
        {
            // find legend item with All On and All Off
            foreach(LegendItem legend in Chart.Legends[0].CustomItems)
            {
                if (legend.Name == AllOnString)
                {
                    if(turnOffOn != TurnOffOn.TurnOn)
                    {
                        legend.Cells[0].Text = UncheckedString;
                    }
                }

                // find legend item with All Off
                if (legend.Name == AllOffString)
                {
                    if (turnOffOn != TurnOffOn.TurnOff)
                    {
                        legend.Cells[0].Text = UncheckedString;
                    }
                }
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

            if (Chart.Size.Height > 600)
            {
                Chart.ChartAreas[0].AxisY.Interval = 0.05;
                Chart.ChartAreas[0].AxisY.IntervalOffset = 0.1;
                Chart.ChartAreas[0].AxisY.MajorGrid.Interval = 0.05;
                Chart.ChartAreas[0].AxisY.MajorGrid.IntervalOffset = 0.1;
                Chart.ChartAreas[0].AxisY.MajorTickMark.Interval = 0.05;
                Chart.ChartAreas[0].AxisY.MajorTickMark.IntervalOffset = 0.1;
            }
            else if (Chart.Size.Height > 450)
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
