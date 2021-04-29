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

            SetDisplayedValues();

            Calculate();
        }

        private void SetRadioButtons()
        {
            if (MerkelViewModel.IsElevation())
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
            SwitchUnits();

            TemperatureHotWaterLabel.Text = MerkelViewModel.HotWaterTemperatureDataValueInputMessage + ":";
            TemperatureHotWaterLabel.TextAlign = ContentAlignment.MiddleRight;
            Merkel_HotWaterTemperature_Value.Text = MerkelViewModel.HotWaterTemperatureDataValueInputValue;
            toolTip1.SetToolTip(Merkel_HotWaterTemperature_Value, MerkelViewModel.HotWaterTemperatureDataValueTooltip);

            TemperatureColdWaterLabel.Text = MerkelViewModel.ColdWaterTemperatureDataValueInputMessage + ":";
            TemperatureColdWaterLabel.TextAlign = ContentAlignment.MiddleRight;
            Merkel_ColdWaterTemperature_Value.Text = MerkelViewModel.ColdWaterTemperatureDataValueInputValue;
            toolTip1.SetToolTip(Merkel_ColdWaterTemperature_Value, MerkelViewModel.ColdWaterTemperatureDataValueTooltip);

            MerkelWetBulbTemperatureLabel.Text = MerkelViewModel.WetBulbTemperatureDataValueInputMessage + ":";
            MerkelWetBulbTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
            Merkel_WetBulbTemperature_Value.Text = MerkelViewModel.WetBulbTemperatureDataValueInputValue;
            toolTip1.SetToolTip(Merkel_WetBulbTemperature_Value, MerkelViewModel.WetBulbTemperatureDataValueTooltip);

            LiquidtoGasRatioLabel.Text = MerkelViewModel.LiquidtoGasRatioDataValueInputMessage + ":";
            LiquidtoGasRatioLabel.TextAlign = ContentAlignment.MiddleRight;
            Merkel_LiquidtoGasRatio_Value.Text = MerkelViewModel.LiquidtoGasRatioDataValueInputValue;
            toolTip1.SetToolTip(Merkel_LiquidtoGasRatio_Value, MerkelViewModel.LiquidtoGasRatioDataValueTooltip);

            DataFilename.Text = MerkelViewModel.DataFilenameInputValue;
        }

        public void SetUnitsStandard(bool isInternationalSystemOfUnits_SI)
        {
            if(IsInternationalSystemOfUnits_SI != isInternationalSystemOfUnits_SI)
            {
                IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;
                SwitchUnits();
                SetDisplayedValues();
            }
        }

        private void SwitchUnits()
        {
            MerkelViewModel.SwitchUnits(IsInternationalSystemOfUnits_SI);
            SwitchCalculation();

            if (IsInternationalSystemOfUnits_SI)
            {
                if (ElevationRadio.Checked)
                {
                    MerkelElevationPressureUnits.Text = ConstantUnits.Meter;
                }
                else
                {
                    MerkelElevationPressureUnits.Text = ConstantUnits.BarometricPressureKiloPascal;
                }
            }
            else
            {
                if (BarometricPressureRadio.Checked)
                {
                    MerkelElevationPressureUnits.Text = ConstantUnits.Foot;
                }
                else
                {
                    MerkelElevationPressureUnits.Text = ConstantUnits.BarometricPressureInchOfMercury;
                }
            }
        }

        private void SwitchCalculation()
        {
            if (IsInternationalSystemOfUnits_SI)
            {
                MerkelTemperatureHotWaterUnits.Text = ConstantUnits.TemperatureCelsius;
                MerkelTemperatureColdWaterUnits.Text = ConstantUnits.TemperatureCelsius;
                MerkelWebBulbTemperatureUnits.Text = ConstantUnits.TemperatureCelsius;
            }
            else
            {
                MerkelTemperatureHotWaterUnits.Text = ConstantUnits.TemperatureFahrenheit;
                MerkelTemperatureColdWaterUnits.Text = ConstantUnits.TemperatureFahrenheit;
                MerkelWebBulbTemperatureUnits.Text = ConstantUnits.TemperatureFahrenheit;
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
                nameValueUnitsDataTable.AddRow(TemperatureHotWaterLabel.Text, Merkel_HotWaterTemperature_Value.Text, MerkelTemperatureHotWaterUnits.Text);
                nameValueUnitsDataTable.AddRow(TemperatureColdWaterLabel.Text, Merkel_ColdWaterTemperature_Value.Text, MerkelTemperatureColdWaterUnits.Text);
                nameValueUnitsDataTable.AddRow(MerkelWetBulbTemperatureLabel.Text, Merkel_WetBulbTemperature_Value.Text, MerkelWebBulbTemperatureUnits.Text);
                nameValueUnitsDataTable.AddRow(LiquidtoGasRatioLabel.Text, Merkel_LiquidtoGasRatio_Value.Text, "");

                if (ElevationRadio.Checked)
                {
                    nameValueUnitsDataTable.AddRow(MerkelElevationPressureLabel.Text, Merkel_Elevation_Value.Text, MerkelElevationPressureUnits.Text);
                }
                else 
                {
                    nameValueUnitsDataTable.AddRow(MerkelElevationPressureLabel.Text, Merkel_Elevation_Value.Text, MerkelElevationPressureUnits.Text);
                }

                MerkelPrinterOutput printerOutput = new MerkelPrinterOutput(e.PageBounds.Height - 80, this.PrintControl.Label, nameValueUnitsDataTable, MerkelViewModel);
                printerOutput.CreateControl();
                var bm = new Bitmap(printerOutput.Width, printerOutput.Height);
                printerOutput.DrawToBitmap(bm, new Rectangle(0, 0, bm.Width, bm.Height));
                e.Graphics.DrawImage(bm, 40, 40);

                e.Graphics.DrawString("CTI Toolkit 4.0 Beta Version",
                                      new Font("Times New Roman", 16),
                                      new SolidBrush(Color.Red),
                                      40, e.PageSettings.Bounds.Height - 60);
                Font font = new Font("Times New Roman", 8);
                SizeF size = e.Graphics.MeasureString(MerkelViewModel.DataFilenameInputValue, font);
                e.Graphics.DrawString(MerkelViewModel.DataFilenameInputValue,
                                      font,
                                      new SolidBrush(Color.Black),
                                      e.PageSettings.Bounds.Width - size.Width - 40, e.PageSettings.Bounds.Height - 60);
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
            bool recalculate = (MerkelViewModel.LiquidtoGasRatioDataValueInputValue != Merkel_LiquidtoGasRatio_Value.Text);

            if (!MerkelViewModel.LiquidtoGasRatioDataValueUpdateValue(Merkel_LiquidtoGasRatio_Value.Text, out string errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Merkel_LiquidtoGasRatio_Value.Select(0, Merkel_LiquidtoGasRatio_Value.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Merkel_LiquidtoGasRatio_Value, errorMessage);
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
            errorProvider1.SetError(Merkel_LiquidtoGasRatio_Value, "");
        }

        private void Merkel_ColdWaterTemperature_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool recalculate = (MerkelViewModel.ColdWaterTemperatureDataValueInputValue != Merkel_ColdWaterTemperature_Value.Text);

            if (!MerkelViewModel.ColdWaterTemperatureDataValueUpdateValue(Merkel_ColdWaterTemperature_Value.Text, out string errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Merkel_ColdWaterTemperature_Value.Select(0, Merkel_ColdWaterTemperature_Value.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Merkel_ColdWaterTemperature_Value, errorMessage);
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
            errorProvider1.SetError(Merkel_ColdWaterTemperature_Value, "");
        }

        private void Merkel_HotWaterTemperature_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool recalculate = (MerkelViewModel.HotWaterTemperatureDataValueInputValue != Merkel_HotWaterTemperature_Value.Text);

            if (!MerkelViewModel.HotWaterTemperatureDataValueUpdateValue(Merkel_HotWaterTemperature_Value.Text, out string errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Merkel_HotWaterTemperature_Value.Select(0, Merkel_HotWaterTemperature_Value.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Merkel_HotWaterTemperature_Value, errorMessage);
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
            errorProvider1.SetError(Merkel_HotWaterTemperature_Value, "");
        }

        private void Merkel_WetBulbTemperature_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool recalculate = (MerkelViewModel.WetBulbTemperatureDataValueInputValue != Merkel_WetBulbTemperature_Value.Text);

            if (!MerkelViewModel.WetBulbTemperatureDataValueUpdateValue(Merkel_WetBulbTemperature_Value.Text, out string errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Merkel_WetBulbTemperature_Value.Select(0, Merkel_WetBulbTemperature_Value.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Merkel_WetBulbTemperature_Value, errorMessage);
            }
            else if (recalculate)
            {
                Calculate();
            }
        }

        private void Merkel_WetBulbTemperature_Value_Validated(object sender, System.EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider1.SetError(Merkel_WetBulbTemperature_Value, "");
        }

        private void Merkel_Elevation_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;
            bool recalculate = false;

            if (ElevationRadio.Checked)
            {
                recalculate = (MerkelViewModel.ElevationDataValueInputValue != Merkel_Elevation_Value.Text);
                if (!MerkelViewModel.ElevationDataValueUpdateValue(Merkel_Elevation_Value.Text, out errorMessage))
                {
                    // Cancel the event and select the text to be corrected by the user.
                    e.Cancel = true;
                    Merkel_Elevation_Value.Select(0, Merkel_Elevation_Value.Text.Length);

                    // Set the ErrorProvider error with the text to display. 
                    this.errorProvider1.SetError(Merkel_Elevation_Value, errorMessage);
                }
            }
            else
            {
                recalculate = (MerkelViewModel.BarometricPressureDataValueInputValue != Merkel_Elevation_Value.Text);
                if (!MerkelViewModel.BarometricPressureDataValueUpdateValue(Merkel_Elevation_Value.Text, out errorMessage))
                {
                    // Cancel the event and select the text to be corrected by the user.
                    e.Cancel = true;
                    Merkel_Elevation_Value.Select(0, Merkel_Elevation_Value.Text.Length);

                    // Set the ErrorProvider error with the text to display. 
                    this.errorProvider1.SetError(Merkel_Elevation_Value, errorMessage);
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
            errorProvider1.SetError(Merkel_Elevation_Value, "");
        }


        private void BarometricPressureRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (BarometricPressureRadio.Checked)
            {
                MerkelViewModel.UpdateIsElevationValue(false);
                Merkel_Elevation_Value.Text = MerkelViewModel.BarometricPressureDataValueInputValue;
                MerkelElevationPressureLabel.Text = MerkelViewModel.BarometricPressureDataValueInputMessage;
                if (IsInternationalSystemOfUnits_SI)
                {
                    MerkelElevationPressureUnits.Text = ConstantUnits.BarometricPressureKiloPascal;
                }
                else
                {
                    MerkelElevationPressureUnits.Text = ConstantUnits.BarometricPressureInchOfMercury;
                }
                Calculate();
            }
        }

        private void ElevationRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (ElevationRadio.Checked)
            {
                MerkelViewModel.UpdateIsElevationValue(true);
                Merkel_Elevation_Value.Text = MerkelViewModel.ElevationDataValueInputValue;
                MerkelElevationPressureLabel.Text = MerkelViewModel.ElevationDataValueInputMessage;
                if (IsInternationalSystemOfUnits_SI)
                {
                    MerkelElevationPressureUnits.Text = ConstantUnits.Meter;
                }
                else
                {
                    MerkelElevationPressureUnits.Text = ConstantUnits.Foot;
                }
                Calculate();
            }
        }

        private void MerkelTabPage_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Help.ShowHelp(this, "helpfile.chm", HelpNavigator.TopicId, "1234");
        }
    }
}
