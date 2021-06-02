// Copyright Cooling Technology Institute 2019-2021

using CTIToolkit.PrintableForms;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using ViewModels;

namespace CTIToolkit
{
    public partial class MerkelTabPage: CalculatePrintUserControl
    {
        private MerkelViewModel MerkelViewModel { get; set; }
        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_SI { get; set; }

        public MerkelTabPage(ApplicationSettings applicationSettings)
        {
            InitializeComponent();

            IsDemo = applicationSettings.IsDemo;
            IsInternationalSystemOfUnits_SI = (applicationSettings.UnitsSelection == UnitsSelection.International_System_Of_Units_SI);

            Filter = "Merkel files (*.mrkl)|*.mrkl|All files (*.*)|*.*";
            DefaultExt = "mrkl";
            Title = "Merkel";
            DefaultFileName = "Merkel";

            MerkelViewModel = new MerkelViewModel(IsDemo, IsInternationalSystemOfUnits_SI);
            MerkelViewModel.DataFileName = BuildDefaultFileName();
  
            SetUnitsStandard(IsInternationalSystemOfUnits_SI);
            Calculate();
        }

        private void SetRadioButtons()
        {
            if (MerkelViewModel.IsElevation)
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
            HotWaterTemperatureLabel.Text = MerkelViewModel.HotWaterTemperatureDataValue.InputMessage + ":";
            HotWaterTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
            HotWaterTemperature_Value.Text = MerkelViewModel.HotWaterTemperatureDataValue.InputValue;
            toolTip1.SetToolTip(HotWaterTemperature_Value, MerkelViewModel.HotWaterTemperatureDataValue.ToolTip);

            ColdWaterTemperatureLabel.Text = MerkelViewModel.ColdWaterTemperatureDataValue.InputMessage + ":";
            ColdWaterTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
            ColdWaterTemperature_Value.Text = MerkelViewModel.ColdWaterTemperatureDataValue.InputValue;
            toolTip1.SetToolTip(ColdWaterTemperature_Value, MerkelViewModel.ColdWaterTemperatureDataValue.ToolTip);

            WetBulbTemperatureLabel.Text = MerkelViewModel.WetBulbTemperatureDataValue.InputMessage + ":";
            WetBulbTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
            WetBulbTemperature_Value.Text = MerkelViewModel.WetBulbTemperatureDataValue.InputValue;
            toolTip1.SetToolTip(WetBulbTemperature_Value, MerkelViewModel.WetBulbTemperatureDataValue.ToolTip);

            LiquidtoGasRatioLabel.Text = MerkelViewModel.LiquidToGasRatioDataValue.InputMessage + ":";
            LiquidtoGasRatioLabel.TextAlign = ContentAlignment.MiddleRight;
            LiquidtoGasRatio_Value.Text = MerkelViewModel.LiquidToGasRatioDataValue.InputValue;
            toolTip1.SetToolTip(LiquidtoGasRatio_Value, MerkelViewModel.LiquidToGasRatioDataValue.ToolTip);

            if (BarometricPressureRadio.Checked)
            {
                ElevationPressureLabel.Text = MerkelViewModel.BarometricPressureDataValue.InputMessage + ":";
                ElevationPressureLabel.TextAlign = ContentAlignment.MiddleRight;
                Elevation_Value.Text = MerkelViewModel.BarometricPressureDataValue.InputValue;
                toolTip1.SetToolTip(Elevation_Value, MerkelViewModel.BarometricPressureDataValue.ToolTip);
            }
            else
            {
                ElevationPressureLabel.Text = MerkelViewModel.ElevationDataValue.InputMessage + ":";
                ElevationPressureLabel.TextAlign = ContentAlignment.MiddleRight;
                Elevation_Value.Text = MerkelViewModel.ElevationDataValue.InputValue;
                toolTip1.SetToolTip(Elevation_Value, MerkelViewModel.ElevationDataValue.ToolTip);
            }

            DataFilename.Text = MerkelViewModel.DataFilenameInputValue;
        }

        public void SetUnitsStandard(bool isInternationalSystemOfUnits_SI)
        {
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;
            SwitchUnits();
            SetDisplayedValues();
        }

        private void SwitchUnits()
        {
            MerkelViewModel.SwitchUnits(IsInternationalSystemOfUnits_SI);

            HotWaterTemperatureUnits.Text = MerkelViewModel.HotWaterTemperatureDataValue.Units;
            ColdWaterTemperatureUnits.Text = MerkelViewModel.ColdWaterTemperatureDataValue.Units;
            WetBulbTemperatureUnits.Text = MerkelViewModel.WetBulbTemperatureDataValue.Units;
            if (ElevationRadio.Checked)
            {
                ElevationPressureUnits.Text = MerkelViewModel.ElevationDataValue.Units;
            }
            else
            {
                ElevationPressureUnits.Text = MerkelViewModel.BarometricPressureDataValue.Units;
            }
        }

        public override void Calculate()
        {
            try
            {
                if (MerkelViewModel.CalculateMerkel())
                {
                    if (CalculatedValuesGridView.DataSource != null)
                    {
                        CalculatedValuesGridView.DataSource = null;
                    }

                    if (MerkelViewModel.GetDataTable() != null)
                    {
                        // Set a DataGrid control's DataSource to the DataView.
                        CalculatedValuesGridView.DataSource = new DataView(MerkelViewModel.GetDataTable());
                    }
                }
                else
                {
                    MessageBox.Show(MerkelViewModel.ErrorMessage);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(string.Format("Error in Merkel calculation. Please check your input values. Exception Message: {0}", exception.Message), "Merkel Calculation Error");
            }
        }

        public override void PrintPage(object sender, PrintPageEventArgs e)
        {
            NameValueUnitsDataTable nameValueUnitsDataTable = new NameValueUnitsDataTable();

            if (MerkelViewModel.GetDataTable() != null)
            {
                nameValueUnitsDataTable.AddRow(HotWaterTemperatureLabel.Text, HotWaterTemperature_Value.Text, HotWaterTemperatureUnits.Text);
                nameValueUnitsDataTable.AddRow(ColdWaterTemperatureLabel.Text, ColdWaterTemperature_Value.Text, ColdWaterTemperatureUnits.Text);
                nameValueUnitsDataTable.AddRow(WetBulbTemperatureLabel.Text, WetBulbTemperature_Value.Text, WetBulbTemperatureUnits.Text);
                nameValueUnitsDataTable.AddRow(LiquidtoGasRatioLabel.Text, LiquidtoGasRatio_Value.Text, "");

                if (ElevationRadio.Checked)
                {
                    nameValueUnitsDataTable.AddRow(ElevationPressureLabel.Text, Elevation_Value.Text, ElevationPressureUnits.Text);
                }
                else 
                {
                    nameValueUnitsDataTable.AddRow(ElevationPressureLabel.Text, Elevation_Value.Text, ElevationPressureUnits.Text);
                }

                e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; // so footer is anti-aliased
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;  // so when we scale up, we smooth out the jaggies somewhat
                e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                DrawLogo(e, 0, 0);
                DrawText(e, 18, FontStyle.Bold, "CTI Merkel Report", 143, 0, true);
                if (!string.IsNullOrWhiteSpace(this.PrintControl.Label))
                {
                    DrawText(e, 18, FontStyle.Bold, this.PrintControl.Label, 143, 34, true);
                }
                float y = 145;
                y += DrawText(e, 12, FontStyle.Regular, "Input Properties:", 3, y, false);
                y += DrawDataTable(e, nameValueUnitsDataTable.DataTable, 7, y);
                y += DrawText(e, 12, FontStyle.Regular, "Output:", 3, y, false);
                DrawDataTable(e, MerkelViewModel.GetDataTable(), 7, y);

                e.Graphics.DrawString("CTI Toolkit 4.0 Beta Version",
                                      new Font("Times New Roman", 16),
                                      new SolidBrush(Color.Red),
                                      MARGIN, e.PageSettings.Bounds.Height - MARGIN);
                Font font = new Font("Times New Roman", 8);
                SizeF size = e.Graphics.MeasureString(MerkelViewModel.DataFilenameInputValue, font);
                e.Graphics.DrawString(MerkelViewModel.DataFilenameInputValue,
                                      font,
                                      new SolidBrush(Color.Black),
                                      e.PageSettings.Bounds.Width - size.Width - MARGIN, e.PageSettings.Bounds.Height - MARGIN);
            }
            else
            {
                MessageBox.Show("You must run the calculation before printing.");
            }
        }

        public override bool OpenDataFile(string fileName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;

            if (MerkelViewModel.OpenDataFile(fileName))
            {
                if (MerkelViewModel.IsInternationalSystemOfUnits_SI != IsInternationalSystemOfUnits_SI)
                {
                    if (this.Parent.Parent.Parent is ToolkitMain)
                    {
                        ToolkitMain main = this.Parent.Parent.Parent as ToolkitMain;
                        main.UpdateUnits(MerkelViewModel.IsInternationalSystemOfUnits_SI ? UnitsSelection.International_System_Of_Units_SI : UnitsSelection.United_States_Customary_Units_IP);
                    }
                }

                SetRadioButtons();

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

            if (MerkelViewModel.OpenNewDataFile(fileName))
            {
                if (!MerkelViewModel.LoadData())
                {
                    stringBuilder.AppendLine(MerkelViewModel.ErrorMessage);
                    returnValue = false;
                }

                SetDisplayedValues();
                Calculate();
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

            if (!MerkelViewModel.SaveDataFile())
            {
                stringBuilder.AppendLine(MerkelViewModel.ErrorMessage);
                returnValue = false;
            }

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

            MerkelViewModel.DataFileName = fileName;
            DataFilename.Text = MerkelViewModel.DataFilenameInputValue;

            if (!MerkelViewModel.SaveAsDataFile(fileName))
            {
                stringBuilder.AppendLine(MerkelViewModel.ErrorMessage);
                returnValue = false;
            }

            ErrorMessage = stringBuilder.ToString();

            return returnValue;
        }

        public void MerkelCalculate_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        private void Merkel_LiquidtoGasRatio_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool recalculate = (MerkelViewModel.LiquidToGasRatioDataValue.InputValue != LiquidtoGasRatio_Value.Text);

            if (!MerkelViewModel.LiquidToGasRatioDataValue.UpdateValue(LiquidtoGasRatio_Value.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                LiquidtoGasRatio_Value.Select(0, LiquidtoGasRatio_Value.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(LiquidtoGasRatio_Value, MerkelViewModel.LiquidToGasRatioDataValue.ErrorMessage);
                //MessageBox.Show(errorMessage);
            }
            else if (recalculate)
            {
                Calculate();
            }
        }

        private void Merkel_LiquidtoGasRatio_Value_Validated(object sender, System.EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider1.SetError(LiquidtoGasRatio_Value, "");
        }

        private void Merkel_ColdWaterTemperature_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool recalculate = (MerkelViewModel.ColdWaterTemperatureDataValue.InputValue != ColdWaterTemperature_Value.Text);

            if (!MerkelViewModel.ColdWaterTemperatureDataValue.UpdateValue(ColdWaterTemperature_Value.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                ColdWaterTemperature_Value.Select(0, ColdWaterTemperature_Value.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(ColdWaterTemperature_Value, MerkelViewModel.ColdWaterTemperatureDataValue.ErrorMessage);
                //MessageBox.Show(errorMessage);
            }
            else if (recalculate)
            {
                Calculate();
            }
        }

        private void Merkel_ColdWaterTemperature_Value_Validated(object sender, System.EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider1.SetError(ColdWaterTemperature_Value, "");
        }

        private void Merkel_HotWaterTemperature_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool recalculate = (MerkelViewModel.HotWaterTemperatureDataValue.InputValue != HotWaterTemperature_Value.Text);

            if (!MerkelViewModel.HotWaterTemperatureDataValue.UpdateValue(HotWaterTemperature_Value.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                HotWaterTemperature_Value.Select(0, HotWaterTemperature_Value.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(HotWaterTemperature_Value, MerkelViewModel.HotWaterTemperatureDataValue.ErrorMessage);
                //MessageBox.Show(errorMessage);
            }
            else if (recalculate)
            {
                Calculate();
            }
        }

        private void Merkel_HotWaterTemperature_Value_Validated(object sender, System.EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider1.SetError(HotWaterTemperature_Value, "");
        }

        private void Merkel_WetBulbTemperature_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool recalculate = (MerkelViewModel.WetBulbTemperatureDataValue.InputValue != WetBulbTemperature_Value.Text);

            if (!MerkelViewModel.WetBulbTemperatureDataValue.UpdateValue(WetBulbTemperature_Value.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                WetBulbTemperature_Value.Select(0, WetBulbTemperature_Value.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(WetBulbTemperature_Value, MerkelViewModel.WetBulbTemperatureDataValue.ErrorMessage);
            }
            else if (recalculate)
            {
                Calculate();
            }
        }

        private void Merkel_WetBulbTemperature_Value_Validated(object sender, System.EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider1.SetError(WetBulbTemperature_Value, "");
        }

        private void Merkel_Elevation_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool recalculate = false;

            if (ElevationRadio.Checked)
            {
                recalculate = (MerkelViewModel.ElevationDataValue.InputValue != Elevation_Value.Text);
                if (!MerkelViewModel.ElevationDataValue.UpdateValue(Elevation_Value.Text))
                {
                    // Cancel the event and select the text to be corrected by the user.
                    e.Cancel = true;
                    Elevation_Value.Select(0, Elevation_Value.Text.Length);

                    // Set the ErrorProvider error with the text to display. 
                    this.errorProvider1.SetError(Elevation_Value, MerkelViewModel.ElevationDataValue.ErrorMessage);
                    recalculate = false;
                }
            }
            else
            {
                recalculate = (MerkelViewModel.BarometricPressureDataValue.InputValue != Elevation_Value.Text);
                if (!MerkelViewModel.BarometricPressureDataValue.UpdateValue(Elevation_Value.Text))
                {
                    // Cancel the event and select the text to be corrected by the user.
                    e.Cancel = true;
                    Elevation_Value.Select(0, Elevation_Value.Text.Length);

                    // Set the ErrorProvider error with the text to display. 
                    this.errorProvider1.SetError(Elevation_Value, MerkelViewModel.BarometricPressureDataValue.ErrorMessage);
                    recalculate = false;
                }
            }
            if(recalculate)
            {
                Calculate();
            }
        }

        private void Merkel_Elevation_Value_Validated(object sender, System.EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider1.SetError(Elevation_Value, "");
        }


        private void BarometricPressureRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (BarometricPressureRadio.Checked)
            {
                if(MerkelViewModel.IsElevation)
                {
                    MerkelViewModel.ConvertElevationToBarometricPressure();
                }
                MerkelViewModel.IsElevation = false;
                Elevation_Value.Text = MerkelViewModel.BarometricPressureDataValue.InputValue;
                ElevationPressureLabel.Text = MerkelViewModel.BarometricPressureDataValue.InputMessage;
                ElevationPressureUnits.Text = MerkelViewModel.BarometricPressureDataValue.Units;
                Calculate();
            }
        }

        private void ElevationRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (ElevationRadio.Checked)
            {
                if (!MerkelViewModel.IsElevation)
                {
                    MerkelViewModel.ConvertBarometricPressureToElevation();
                }
                MerkelViewModel.IsElevation = true;
                Elevation_Value.Text = MerkelViewModel.ElevationDataValue.InputValue;
                ElevationPressureLabel.Text = MerkelViewModel.ElevationDataValue.InputMessage;
                ElevationPressureUnits.Text = MerkelViewModel.ElevationDataValue.Units;
                Calculate();
            }
        }

        private void MerkelTabPage_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Help.ShowHelp(this, "helpfile.chm", HelpNavigator.TopicId, "1234");
        }
    }
}
