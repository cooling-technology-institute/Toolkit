// Copyright Cooling Technology Institute 2019-2020

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ViewModels;

namespace CTIToolkit
{
    public partial class PsychrometricsTabPage: UserControl
    {
        PsychrometricsViewModel PsychrometricsViewModel { get; set; }
        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_IS_ { get; set; }

        public PsychrometricsTabPage(ApplicationSettings applicationSettings)
        {
            InitializeComponent();

            IsInternationalSystemOfUnits_IS_ = (applicationSettings.UnitsSelection == UnitsSelection.International_System_Of_Units_SI);
            IsInternationalSystemOfUnits_IS_ = false;

            IsDemo = applicationSettings.IsDemo;
            IsInternationalSystemOfUnits_IS_ = false;

            PsychrometricsViewModel = new PsychrometricsViewModel(IsDemo, IsInternationalSystemOfUnits_IS_);

        }

        public void SetUnitsStandard(ApplicationSettings applicationSettings)
        {
            IsInternationalSystemOfUnits_IS_ = (applicationSettings.UnitsSelection == UnitsSelection.International_System_Of_Units_SI);

            SwitchUnitsSelection();
        }

        private void SwitchUnitsSelection()
        {
            if (IsInternationalSystemOfUnits_IS_)
            {
                if (Psychrometrics_DryBulbTemperature_RelativeHumidity.Checked)
                {
                    PsychrometricsTemperatureWetBulbUnits.Text = ConstantUnits.Percentage;
                }
                else
                {
                    PsychrometricsTemperatureWetBulbUnits.Text = ConstantUnits.TemperatureCelsius;
                }

                if (Psychrometrics_Enthalpy.Checked)
                {
                    PsychrometricsTemperatureDryBulbUnits.Text = ConstantUnits.KilojoulesPerKilogram;
                }
                else
                {
                    PsychrometricsTemperatureDryBulbUnits.Text = ConstantUnits.TemperatureCelsius;
                }

                if (PsychrometricsElevationRadio.Checked)
                {
                    PsychrometricsElevationPressureUnits.Text = ConstantUnits.Meter;
                }
                else
                {
                    PsychrometricsElevationPressureUnits.Text = ConstantUnits.BarometricPressureKiloPascal;
                }
            }
            else
            {
                if (Psychrometrics_DryBulbTemperature_RelativeHumidity.Checked)
                {
                    PsychrometricsTemperatureWetBulbUnits.Text = ConstantUnits.Percentage;
                }
                else
                {
                    PsychrometricsTemperatureWetBulbUnits.Text = ConstantUnits.TemperatureFahrenheit;
                }

                if (Psychrometrics_Enthalpy.Checked)
                {
                    PsychrometricsTemperatureDryBulbUnits.Text = ConstantUnits.BtuPerPound;
                }
                else
                {
                    PsychrometricsTemperatureDryBulbUnits.Text = ConstantUnits.TemperatureFahrenheit;
                }

                if (PsychrometricsElevationRadio.Checked)
                {
                    PsychrometricsElevationPressureUnits.Text = ConstantUnits.Foot;
                }
                else
                {
                    PsychrometricsElevationPressureUnits.Text = ConstantUnits.BarometricPressureInchOfMercury;
                }
            }
        }

        private void PyschmetricsElevationRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (PsychrometricsElevationRadio.Checked)
            {
                ClearDataSource();

                Psychrometrics_Elevation_Value.Text = PsychrometricsViewModel.ElevationDataValueInputValue;
                PsychrometricsElevationPressureLabel.Text = PsychrometricsViewModel.ElevationDataValueInputMessage + ":";
                if (IsInternationalSystemOfUnits_IS_)
                {
                    PsychrometricsElevationPressureUnits.Text = ConstantUnits.Meter;
                }
                else
                {
                    PsychrometricsElevationPressureUnits.Text = ConstantUnits.Foot;
                }
            }
        }

        private void PsychrometricsPressureRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (PsychrometricsPressureRadio.Checked)
            {
                ClearDataSource();

                Psychrometrics_Elevation_Value.Text = PsychrometricsViewModel.BarometricPressureDataValueInputValue;
                PsychrometricsElevationPressureLabel.Text = PsychrometricsViewModel.BarometricPressureDataValueInputMessage + ":";

                if (IsInternationalSystemOfUnits_IS_)
                {
                    PsychrometricsElevationPressureUnits.Text = ConstantUnits.BarometricPressureKiloPascal;
                }
                else
                {
                    PsychrometricsElevationPressureUnits.Text = ConstantUnits.BarometricPressureInchOfMercury;
                }
            }
        }

        private void Psychrometrics_WetBulbTemperature_DryBulbTemperature_CheckedChanged(object sender, EventArgs e)
        {
            if (Psychrometrics_WetBulbTemperature_DryBulbTemperature.Checked)
            {
                ClearDataSource();

                WetBulbTemperatureLabel.Visible = true;
                PsychrometricsTemperatureWetBulbUnits.Visible = true;
                Psychrometrics_WetBulbTemperature_Value.Visible = true;

                WetBulbTemperatureLabel.Text = PsychrometricsViewModel.WetBulbTemperatureDataValueInputMessage + ":";
                WetBulbTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
                Psychrometrics_WetBulbTemperature_Value.Text = PsychrometricsViewModel.WetBulbTemperatureDataValueInputValue;
                toolTip1.SetToolTip(Psychrometrics_WetBulbTemperature_Value, PsychrometricsViewModel.WetBulbTemperatureDataValueToolTip);

                TemperatureDryBulbLabel.Text = PsychrometricsViewModel.DryBulbTemperatureDataValueInputMessage + ":";
                TemperatureDryBulbLabel.TextAlign = ContentAlignment.MiddleRight;
                Psychrometrics_DryBulbTemperature_Value.Text = PsychrometricsViewModel.DryBulbTemperatureDataValueInputValue;
                toolTip1.SetToolTip(Psychrometrics_WetBulbTemperature_Value, PsychrometricsViewModel.WetBulbTemperatureDataValueToolTip);

                if (IsInternationalSystemOfUnits_IS_)
                {
                    PsychrometricsTemperatureWetBulbUnits.Text = ConstantUnits.TemperatureCelsius;
                    PsychrometricsTemperatureDryBulbUnits.Text = ConstantUnits.TemperatureCelsius;
                }
                else
                {
                    PsychrometricsTemperatureWetBulbUnits.Text = ConstantUnits.TemperatureFahrenheit;
                    PsychrometricsTemperatureDryBulbUnits.Text = ConstantUnits.TemperatureFahrenheit;
                }
            }
        }

        private void Psychrometrics_DryBulbTemperature_RelativeHumidity_CheckedChanged(object sender, EventArgs e)
        {
            if (Psychrometrics_DryBulbTemperature_RelativeHumidity.Checked)
            {
                ClearDataSource();

                WetBulbTemperatureLabel.Visible = true;
                PsychrometricsTemperatureWetBulbUnits.Visible = true;
                Psychrometrics_WetBulbTemperature_Value.Visible = true;

                WetBulbTemperatureLabel.Text = PsychrometricsViewModel.RelativeHumidityDataValueInputMessage + ":";
                WetBulbTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
                PsychrometricsTemperatureWetBulbUnits.Text = ConstantUnits.Percentage;
                Psychrometrics_WetBulbTemperature_Value.Text = PsychrometricsViewModel.RelativeHumidityDataValueInputValue;
                toolTip1.SetToolTip(Psychrometrics_WetBulbTemperature_Value, PsychrometricsViewModel.RelativeHumidityDataValueToolTip);

                TemperatureDryBulbLabel.Text = PsychrometricsViewModel.DryBulbTemperatureDataValueInputMessage + ":";
                Psychrometrics_DryBulbTemperature_Value.Text = PsychrometricsViewModel.DryBulbTemperatureDataValueInputValue;
                toolTip1.SetToolTip(Psychrometrics_DryBulbTemperature_Value, PsychrometricsViewModel.DryBulbTemperatureDataValueToolTip);

                if (IsInternationalSystemOfUnits_IS_)
                {
                    PsychrometricsTemperatureDryBulbUnits.Text = ConstantUnits.TemperatureCelsius;
                }
                else
                {
                    PsychrometricsTemperatureDryBulbUnits.Text = ConstantUnits.TemperatureFahrenheit;
                }
            }
        }

        private void Psychrometrics_Enthalpy_CheckedChanged(object sender, EventArgs e)
        {
            if (Psychrometrics_Enthalpy.Checked)
            {
                ClearDataSource();

                WetBulbTemperatureLabel.Visible = false;
                PsychrometricsTemperatureWetBulbUnits.Visible = false;
                Psychrometrics_WetBulbTemperature_Value.Visible = false;

                TemperatureDryBulbLabel.Text = PsychrometricsViewModel.EnthalpyDataValueInputMessage + ":";
                TemperatureDryBulbLabel.TextAlign = ContentAlignment.MiddleRight;
                toolTip1.SetToolTip(Psychrometrics_DryBulbTemperature_Value, PsychrometricsViewModel.EnthalpyDataValueToolTip);

                if (IsInternationalSystemOfUnits_IS_)
                {
                    PsychrometricsTemperatureDryBulbUnits.Text = ConstantUnits.KilojoulesPerKilogram;
                }
                else
                {
                    PsychrometricsTemperatureDryBulbUnits.Text = ConstantUnits.BtuPerPound;
                }
                Psychrometrics_DryBulbTemperature_Value.Text = PsychrometricsViewModel.EnthalpyDataValueInputValue;
            }
        }

        private void ClearDataSource()
        {
            if (Psychrometrics_GridView.DataSource != null)
            {
                Psychrometrics_GridView.DataSource = null;
            }
        }

        private void PsychrometricsCalculate_Click(object sender, EventArgs e)
        {
            string errorMessage = string.Empty;
            ClearDataSource();
            try
            {
                if (PsychrometricsViewModel.CalculatePsychrometrics(PsychrometricsElevationRadio.Checked, out errorMessage))
                {
                    if (PsychrometricsViewModel.GetDataTable() != null)
                    {
                        // Set a DataGrid control's DataSource to the DataView.
                        Psychrometrics_GridView.DataSource = new DataView(PsychrometricsViewModel.GetDataTable());
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

        private void Psychrometrics_Elevation_Value_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Psychrometrics_Elevation_Value, "");
        }

        private void Psychrometrics_Elevation_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (PsychrometricsElevationRadio.Checked)
            {
                if (!PsychrometricsViewModel.ElevationDataValueUpdateValue(Psychrometrics_Elevation_Value.Text, out errorMessage))
                {
                    // Cancel the event and select the text to be corrected by the user.
                    e.Cancel = true;
                    Psychrometrics_Elevation_Value.Select(0, Psychrometrics_Elevation_Value.Text.Length);

                    // Set the ErrorProvider error with the text to display. 
                    this.errorProvider1.SetError(Psychrometrics_Elevation_Value, errorMessage);
                }
            }
            else
            {
                if (!PsychrometricsViewModel.BarometricPressureDataValueUpdateValue(Psychrometrics_Elevation_Value.Text, out errorMessage))
                {
                    // Cancel the event and select the text to be corrected by the user.
                    e.Cancel = true;
                    Psychrometrics_Elevation_Value.Select(0, Psychrometrics_Elevation_Value.Text.Length);

                    // Set the ErrorProvider error with the text to display. 
                    this.errorProvider1.SetError(Psychrometrics_Elevation_Value, errorMessage);
                }
            }
        }

        private void Psychrometrics_DryBulbTemperature_Value_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(Psychrometrics_DryBulbTemperature_Value, "");

        }

        private void Psychrometrics_DryBulbTemperature_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!PsychrometricsViewModel.DryBulbTemperatureDataValueUpdateValue(Psychrometrics_DryBulbTemperature_Value.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Psychrometrics_DryBulbTemperature_Value.Select(0, Psychrometrics_DryBulbTemperature_Value.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Psychrometrics_DryBulbTemperature_Value, errorMessage);
            }
        }

        private void Psychrometrics_WetBulbTemperature_Value_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(Psychrometrics_WetBulbTemperature_Value, "");

        }

        private void Psychrometrics_WetBulbTemperature_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!PsychrometricsViewModel.WetBulbTemperatureDataValueUpdateValue(Psychrometrics_WetBulbTemperature_Value.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Psychrometrics_WetBulbTemperature_Value.Select(0, Psychrometrics_WetBulbTemperature_Value.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Psychrometrics_WetBulbTemperature_Value, errorMessage);
            }
        }
    }
}
