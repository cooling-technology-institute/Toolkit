// Copyright Cooling Technology Institute 2019-2021

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CalculationLibrary;
using Models;
using ViewModels;

namespace CTIToolkit
{
    public partial class MerkelTabPage: CalculatePrintUserControl
    {
        private MerkelViewModel MerkelViewModel { get; set; }
        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_SI_ { get; set; }

        public MerkelTabPage(ApplicationSettings applicationSettings)
        {
            InitializeComponent();

            IsInternationalSystemOfUnits_SI_ = (applicationSettings.UnitsSelection == UnitsSelection.International_System_Of_Units_SI);

            MerkelViewModel = new MerkelViewModel(IsDemo, IsInternationalSystemOfUnits_SI_);

            Setup();

            Calculate();

        }

        private void Setup()
        {
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
        }

        public void SetUnitsStandard(ApplicationSettings applicationSettings)
        {
            IsInternationalSystemOfUnits_SI_ = (applicationSettings.UnitsSelection == UnitsSelection.International_System_Of_Units_SI);
            SwitchUnitedStatesCustomaryUnits_IP_InternationalSystemOfUnits_IS_();
        }

        private void SwitchUnitedStatesCustomaryUnits_IP_InternationalSystemOfUnits_IS_()
        {
            string errorMessage = string.Empty;
            if (MerkelViewModel.ConvertValues(IsInternationalSystemOfUnits_SI_, MerkleElevationRadio.Checked, out errorMessage))
            {
                SwitchCalculation();
            }

            if (IsInternationalSystemOfUnits_SI_)
            {
                if (MerkleElevationRadio.Checked)
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
                if (MerkleBarometricPressureRadio.Checked)
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
            if (IsInternationalSystemOfUnits_SI_)
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
            string errorMessage = string.Empty;
            try
            {
                if (MerkelViewModel.CalculateMerkel(MerkleElevationRadio.Checked, out errorMessage))
                {
                    if (MerkelGridView.DataSource != null)
                    {
                        MerkelGridView.DataSource = null;
                    }

                    if (MerkelViewModel.GetDataTable() != null)
                    {
                        // Set a DataGrid control's DataSource to the DataView.
                        MerkelGridView.DataSource = new DataView(MerkelViewModel.GetDataTable());
                    }
                }
                else
                {
                    MessageBox.Show(errorMessage);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(string.Format("Error in Merkel calculation. Please check your input values. Exception Message: {0}", exception.Message), "Merkel Calculation Error");
            }
        }

        public override void Print()
        {
        }

        public void MerkelCalculate_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        private void Merkel_LiquidtoGasRatio_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!MerkelViewModel.LiquidtoGasRatioDataValueUpdateValue(Merkel_LiquidtoGasRatio_Value.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Merkel_LiquidtoGasRatio_Value.Select(0, Merkel_LiquidtoGasRatio_Value.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Merkel_LiquidtoGasRatio_Value, errorMessage);
                //MessageBox.Show(errorMessage);
            }
        }

        private void Merkel_LiquidtoGasRatio_Value_Validated(object sender, System.EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider1.SetError(Merkel_LiquidtoGasRatio_Value, "");
        }

        private void Merkel_ColdWaterTemperature_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!MerkelViewModel.ColdWaterTemperatureDataValueUpdateValue(Merkel_ColdWaterTemperature_Value.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Merkel_ColdWaterTemperature_Value.Select(0, Merkel_ColdWaterTemperature_Value.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Merkel_ColdWaterTemperature_Value, errorMessage);
                //MessageBox.Show(errorMessage);
            }
        }

        private void Merkel_ColdWaterTemperature_Value_Validated(object sender, System.EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider1.SetError(Merkel_ColdWaterTemperature_Value, "");
        }

        private void Merkel_HotWaterTemperature_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!MerkelViewModel.HotWaterTemperatureDataValueUpdateValue(Merkel_HotWaterTemperature_Value.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Merkel_HotWaterTemperature_Value.Select(0, Merkel_HotWaterTemperature_Value.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Merkel_HotWaterTemperature_Value, errorMessage);
                //MessageBox.Show(errorMessage);
            }
        }

        private void Merkel_HotWaterTemperature_Value_Validated(object sender, System.EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider1.SetError(Merkel_HotWaterTemperature_Value, "");
        }

        private void Merkel_WetBulbTemperature_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!MerkelViewModel.WetBulbTemperatureDataValueUpdateValue(Merkel_WetBulbTemperature_Value.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Merkel_WetBulbTemperature_Value.Select(0, Merkel_WetBulbTemperature_Value.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Merkel_WetBulbTemperature_Value, errorMessage);
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

            if (MerkleElevationRadio.Checked)
            {
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
                if (!MerkelViewModel.BarometricPressureDataValueUpdateValue(Merkel_Elevation_Value.Text, out errorMessage))
                {
                    // Cancel the event and select the text to be corrected by the user.
                    e.Cancel = true;
                    Merkel_Elevation_Value.Select(0, Merkel_Elevation_Value.Text.Length);

                    // Set the ErrorProvider error with the text to display. 
                    this.errorProvider1.SetError(Merkel_Elevation_Value, errorMessage);
                }
            }
        }

        private void Merkel_Elevation_Value_Validated(object sender, System.EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider1.SetError(Merkel_Elevation_Value, "");
        }


        private void MerkleBarometricPressureRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (MerkleBarometricPressureRadio.Checked)
            {
                Merkel_Elevation_Value.Text = MerkelViewModel.BarometricPressureDataValueInputValue;
                MerkelElevationPressureLabel.Text = MerkelViewModel.BarometricPressureDataValueInputMessage;
                if (IsInternationalSystemOfUnits_SI_)
                {
                    MerkelElevationPressureUnits.Text = ConstantUnits.BarometricPressureKiloPascal;
                }
                else
                {
                    MerkelElevationPressureUnits.Text = ConstantUnits.BarometricPressureInchOfMercury;
                }
            }
        }

        private void MerkleElevationRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (MerkleElevationRadio.Checked)
            {
                Merkel_Elevation_Value.Text = MerkelViewModel.ElevationDataValueInputValue;
                MerkelElevationPressureLabel.Text = MerkelViewModel.ElevationDataValueInputMessage;
                if (IsInternationalSystemOfUnits_SI_)
                {
                    MerkelElevationPressureUnits.Text = ConstantUnits.Meter;
                }
                else
                {
                    MerkelElevationPressureUnits.Text = ConstantUnits.Foot;
                }
            }
        }

        private void MerkelTabPage_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Help.ShowHelp(this, "helpfile.chm", HelpNavigator.TopicId, "1234");
        }
    }
}
