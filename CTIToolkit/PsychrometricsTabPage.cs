﻿// Copyright Cooling Technology Institute 2019-2021

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ViewModels;

namespace CTIToolkit
{
    public partial class PsychrometricsTabPage: CalculatePrintUserControl
    {
        PsychrometricsViewModel PsychrometricsViewModel { get; set; }
        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_SI_ { get; set; }

        public PsychrometricsTabPage(ApplicationSettings applicationSettings)
        {
            IsInternationalSystemOfUnits_SI_ = (applicationSettings.UnitsSelection == UnitsSelection.International_System_Of_Units_SI);
            IsDemo = applicationSettings.IsDemo;

            InitializeComponent();

            PsychrometricsViewModel = new PsychrometricsViewModel(IsDemo, IsInternationalSystemOfUnits_SI_);

            string errorMessage;
            Setup(out errorMessage);
        }

        private void SetupBarometericPressure(bool value)
        {
            BarometericPressureLabel.Enabled = value;
            BarometericPressureLabel.Visible = value;
            BarometericPressure_Value.Enabled = value;
            BarometericPressure_Value.Visible = value;
            BarometericPressureUnits.Enabled = value;
            BarometericPressureUnits.Visible = value;
        }

        private void SetupElevation(bool value)
        {
            ElevationLabel.Enabled = value;
            ElevationLabel.Visible = value;
            Elevation_Value.Enabled = value;
            Elevation_Value.Visible = value;
            ElevationUnits.Enabled = value;
            ElevationUnits.Visible = value;
        }

        private void SetupRelativeHumidity(bool value)
        {
            RelativeHumidityLabel.Enabled = value;
            RelativeHumidityLabel.Visible = value;
            RelativeHumidity_Value.Enabled = value;
            RelativeHumidity_Value.Visible = value;
            RelativeHumidityUnits.Enabled = value;
            RelativeHumidityUnits.Visible = value;
        }

        private void SetupEnthalpy(bool value)
        {
            EnthalpyLabel.Enabled = value;
            EnthalpyLabel.Visible = value;
            EnthalpyValue.Enabled = value;
            EnthalpyValue.Visible = value;
            EnthalpyUnits.Enabled = value;
            EnthalpyUnits.Visible = value;
        }

        private void SetupWetBulbTemperature(bool value)
        {
            WetBulbTemperatureLabel.Enabled = value;
            WetBulbTemperatureLabel.Visible = value;
            WetBulbTemperature_Value.Enabled = value;
            WetBulbTemperature_Value.Visible = value;
            WetBulbTemperatureUnits.Enabled = value;
            WetBulbTemperatureUnits.Visible = value;
        }

        private bool Setup(out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                SwitchUnitsSelection();

                if (PsychrometricsPressureRadio.Checked)
                {
                    SetupBarometericPressure(true);
                    SetupElevation(false);
                }
                else
                {
                    SetupBarometericPressure(false);
                    SetupElevation(true);
                }

                if (Psychrometrics_DryBulbTemperature_RelativeHumidity.Checked)
                {
                    SetupRelativeHumidity(true);
                    SetupWetBulbTemperature(false);
                    SetupEnthalpy(false);
                }
                else if(Psychrometrics_WetBulbTemperature_DryBulbTemperature.Checked)
                {
                    SetupRelativeHumidity(false);
                    SetupWetBulbTemperature(true);
                    SetupEnthalpy(false);
                }
                else //Psychrometrics_Enthalpy
                {
                    SetupRelativeHumidity(false);
                    SetupWetBulbTemperature(false);
                    SetupEnthalpy(true);
                }

                WetBulbTemperatureLabel.Text = PsychrometricsViewModel.WetBulbTemperatureDataValueInputMessage + ":";
                WetBulbTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
                WetBulbTemperature_Value.Text = PsychrometricsViewModel.WetBulbTemperatureDataValueInputValue;
                toolTip1.SetToolTip(WetBulbTemperature_Value, PsychrometricsViewModel.WetBulbTemperatureDataValueToolTip);

                DryBulbTemperatureLabel.Text = PsychrometricsViewModel.DryBulbTemperatureDataValueInputMessage + ":";
                DryBulbTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
                DryBulbTemperature_Value.Text = PsychrometricsViewModel.DryBulbTemperatureDataValueInputValue;
                toolTip1.SetToolTip(DryBulbTemperature_Value, PsychrometricsViewModel.DryBulbTemperatureDataValueToolTip);

                RelativeHumidityLabel.Text = PsychrometricsViewModel.RelativeHumidityDataValueInputMessage + ":";
                RelativeHumidityLabel.TextAlign = ContentAlignment.MiddleRight;
                RelativeHumidity_Value.Text = PsychrometricsViewModel.RelativeHumidityDataValueInputValue;
                toolTip1.SetToolTip(RelativeHumidity_Value, PsychrometricsViewModel.RelativeHumidityDataValueToolTip);

                EnthalpyLabel.Text = PsychrometricsViewModel.EnthalpyDataValueInputMessage + ":";
                EnthalpyLabel.TextAlign = ContentAlignment.MiddleRight;
                EnthalpyValue.Text = PsychrometricsViewModel.EnthalpyDataValueInputValue;
                toolTip1.SetToolTip(EnthalpyValue, PsychrometricsViewModel.EnthalpyDataValueToolTip);

                ElevationLabel.Text = PsychrometricsViewModel.ElevationDataValueInputMessage + ":";
                ElevationLabel.TextAlign = ContentAlignment.MiddleRight;
                Elevation_Value.Text = PsychrometricsViewModel.ElevationDataValueInputValue;
                toolTip1.SetToolTip(Elevation_Value, PsychrometricsViewModel.ElevationDataValueToolTip);

                BarometericPressureLabel.Text = PsychrometricsViewModel.BarometricPressureDataValueInputMessage + ":";
                BarometericPressureLabel.TextAlign = ContentAlignment.MiddleRight;
                BarometericPressure_Value.Text = PsychrometricsViewModel.BarometricPressureDataValueInputValue;
                toolTip1.SetToolTip(BarometericPressure_Value, PsychrometricsViewModel.BarometricPressureDataValueToolTip);
            }
            catch (Exception e)
            {
                errorMessage = string.Format("Failure to load page. Exception: {0}", e.ToString());
                return false;
            }
            return true;
        }

        public void SetUnitsStandard(ApplicationSettings applicationSettings)
        {
            IsInternationalSystemOfUnits_SI_ = (applicationSettings.UnitsSelection == UnitsSelection.International_System_Of_Units_SI);

            SwitchUnitsSelection();
        }

        private void SwitchUnitsSelection()
        {
            RelativeHumidityUnits.Text = ConstantUnits.Percentage;

            if (IsInternationalSystemOfUnits_SI_)
            {
                WetBulbTemperatureUnits.Text = ConstantUnits.TemperatureCelsius;
                DryBulbTemperatureUnits.Text = ConstantUnits.TemperatureCelsius;
                EnthalpyUnits.Text = ConstantUnits.BtuPerPound;
                ElevationUnits.Text = ConstantUnits.Meter;
                BarometericPressureUnits.Text = ConstantUnits.BarometricPressureInchOfMercury;
            }
            else
            {
                WetBulbTemperatureUnits.Text = ConstantUnits.TemperatureFahrenheit;
                DryBulbTemperatureUnits.Text = ConstantUnits.TemperatureFahrenheit;
                EnthalpyUnits.Text = ConstantUnits.BtuPerPound;
                ElevationUnits.Text = ConstantUnits.Foot;
                DryBulbTemperatureUnits.Text = ConstantUnits.TemperatureFahrenheit;
                BarometericPressureUnits.Text = ConstantUnits.BarometricPressureInchOfMercury;
            }
        }

        private void PyschmetricsElevationRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (PsychrometricsElevationRadio.Checked)
            {
                ClearDataSource();
                SetupBarometericPressure(false);
                SetupElevation(true);
            }
        }

        private void PsychrometricsPressureRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (PsychrometricsPressureRadio.Checked)
            {
                ClearDataSource();
                SetupBarometericPressure(true);
                SetupElevation(false);
            }
        }

        private void Psychrometrics_WetBulbTemperature_DryBulbTemperature_CheckedChanged(object sender, EventArgs e)
        {
            if (Psychrometrics_WetBulbTemperature_DryBulbTemperature.Checked)
            {
                ClearDataSource();
                SetupRelativeHumidity(false);
                SetupWetBulbTemperature(true);
                SetupEnthalpy(false);
                string errorMessage = string.Empty;
                PsychrometricsViewModel.UpdateCalculationType(Models.PsychrometricsCalculationType.WetBulbTemperature_DryBulbTemperature, out errorMessage);
            }
        }

        private void Psychrometrics_DryBulbTemperature_RelativeHumidity_CheckedChanged(object sender, EventArgs e)
        {
            if (Psychrometrics_DryBulbTemperature_RelativeHumidity.Checked)
            {
                ClearDataSource();
                SetupRelativeHumidity(true);
                SetupWetBulbTemperature(false);
                SetupEnthalpy(false);
                string errorMessage = string.Empty;
                PsychrometricsViewModel.UpdateCalculationType(Models.PsychrometricsCalculationType.DryBulbTemperature_RelativeHumidity, out errorMessage);
            }
        }

        private void Psychrometrics_Enthalpy_CheckedChanged(object sender, EventArgs e)
        {
            if (Psychrometrics_Enthalpy.Checked)
            {
                ClearDataSource();
                SetupRelativeHumidity(false);
                SetupWetBulbTemperature(false);
                SetupEnthalpy(true);
                string errorMessage = string.Empty;
                PsychrometricsViewModel.UpdateCalculationType(Models.PsychrometricsCalculationType.Enthalpy, out errorMessage);
            }
        }

        private void ClearDataSource()
        {
            if (Psychrometrics_GridView.DataSource != null)
            {
                Psychrometrics_GridView.DataSource = null;
            }
        }

        public override void Calculate()
        {
        }

        public override void Print()
        {
        }

        public void PsychrometricsCalculate_Click(object sender, EventArgs e)
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

        private void Elevation_Value_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Elevation_Value, "");
        }

        private void Elevation_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!PsychrometricsViewModel.ElevationDataValueUpdateValue(Elevation_Value.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Elevation_Value.Select(0, Elevation_Value.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Elevation_Value, errorMessage);
            }
        }

        private void BarometericPressure_Value_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(BarometericPressure_Value, "");
        }

        private void BarometericPressure_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!PsychrometricsViewModel.BarometricPressureDataValueUpdateValue(BarometericPressure_Value.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                BarometericPressure_Value.Select(0, BarometericPressure_Value.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(BarometericPressure_Value, errorMessage);
            }
        }

        private void DryBulbTemperature_Value_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(DryBulbTemperature_Value, "");

        }

        private void DryBulbTemperature_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!PsychrometricsViewModel.DryBulbTemperatureDataValueUpdateValue(DryBulbTemperature_Value.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                DryBulbTemperature_Value.Select(0, DryBulbTemperature_Value.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(DryBulbTemperature_Value, errorMessage);
            }
        }

        private void WetBulbTemperature_Value_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(WetBulbTemperature_Value, "");
        }

        private void WetBulbTemperature_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!PsychrometricsViewModel.WetBulbTemperatureDataValueUpdateValue(WetBulbTemperature_Value.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                WetBulbTemperature_Value.Select(0, WetBulbTemperature_Value.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(WetBulbTemperature_Value, errorMessage);
            }
        }

        private void RelativeHumidity_Value_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(RelativeHumidity_Value, "");
        }

        private void RelativeHumidity_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!PsychrometricsViewModel.RelativeHumidityDataValueUpdateValue(RelativeHumidity_Value.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                RelativeHumidity_Value.Select(0, RelativeHumidity_Value.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(RelativeHumidity_Value, errorMessage);
            }
        }

        private void EnthalpyValue_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(EnthalpyValue, "");
        }

        private void EnthalpyValue_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!PsychrometricsViewModel.EnthalpyDataValueUpdateValue(EnthalpyValue.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                EnthalpyValue.Select(0, EnthalpyValue.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(EnthalpyValue, errorMessage);
            }
        }
    }
}
