using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ToolkitLibrary;


namespace CTIToolkit
{
    public partial class PsychrometricsTabPage: UserControl
    {
        private PsychrometricsInputData PsychrometricsInputData { get; set; }
        private PsychrometricsData PsychrometricsData { get; set; }
        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_IS_ { get; set; }

        public PsychrometricsTabPage(ApplicationSettings applicationSettings)
        {
            InitializeComponent();

            IsInternationalSystemOfUnits_IS_ = (applicationSettings.UnitsSelection == UnitsSelection.International_System_Of_Units_SI);
            IsInternationalSystemOfUnits_IS_ = false;

            PsychrometricsInputData = new PsychrometricsInputData(IsDemo, IsInternationalSystemOfUnits_IS_);

            SwitchCalculation();

            CalculatePsychrometrics();

        }

        public void SetUnitsStandard(ApplicationSettings applicationSettings)
        {
            IsInternationalSystemOfUnits_IS_ = (applicationSettings.UnitsSelection == UnitsSelection.International_System_Of_Units_SI);
            SwitchUnitedStatesCustomaryUnits_IP_InternationalSystemOfUnits_IS_();
        }

        private void SwitchUnitedStatesCustomaryUnits_IP_InternationalSystemOfUnits_IS_()
        {
            if (PsychrometricsInputData.ConvertValues(IsInternationalSystemOfUnits_IS_))
            {
                SwitchCalculation();
            }

            if (IsInternationalSystemOfUnits_IS_)
            {
                if (Psychrometrics_DBT_RH.Checked)
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

                if (PyschmetricsElevationRadio.Checked)
                {
                    PsychrometricsElevationPressureLabel2.Text = ConstantUnits.Meter;
                }
                else
                {
                    PsychrometricsElevationPressureLabel2.Text = ConstantUnits.BarometricPressureKiloPascal;
                }
            }
            else
            {
                if (Psychrometrics_DBT_RH.Checked)
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

                if (PyschmetricsElevationRadio.Checked)
                {
                    PsychrometricsElevationPressureLabel2.Text = ConstantUnits.Foot;
                }
                else
                {
                    PsychrometricsElevationPressureLabel2.Text = ConstantUnits.BarometricPressureInchOfMercury;
                }
            }
        }

        private void SwitchElevationPressure()
        {
            //PsychrometricsData.SetElevation(PyschmetricsElevationRadio.Checked);

            if (PyschmetricsElevationRadio.Checked)
            {
                double value = 0.0;
                if (double.TryParse(Psychrometrics_Elevation_Value.Text, out value))
                {
                    value = UnitConverter.ConvertBarometricPressureToElevationInFeet(value);
                }
                else
                {
                    value = PsychrometricsInputData.ElevationDataValue.Default;
                }
                Psychrometrics_Elevation_Value.Text = PsychrometricsInputData.ElevationDataValue.InputValue;
                PsychrometricsElevationPressureLabel1.Text = PsychrometricsInputData.ElevationDataValue.InputMessage + ":";
                if (IsInternationalSystemOfUnits_IS_)
                {
                    PsychrometricsElevationPressureLabel2.Text = ConstantUnits.Meter;
                }
                else
                {
                    PsychrometricsElevationPressureLabel2.Text = ConstantUnits.Foot;
                }
            }
            else
            {
                double value = 0.0;
                if (double.TryParse(Psychrometrics_Elevation_Value.Text, out value))
                {
                    value = UnitConverter.ConvertElevationInFeetToBarometricPressure(value);
                    value = UnitConverter.CalculatePressureFahrenheit(value);

                }
                else
                {
                    value = PsychrometricsInputData.BarometricPressureDataValue.Default;
                }
                Psychrometrics_Elevation_Value.Text = PsychrometricsInputData.BarometricPressureDataValue.InputValue;
                PsychrometricsElevationPressureLabel1.Text = PsychrometricsInputData.BarometricPressureDataValue.InputMessage + ":";
                if (IsInternationalSystemOfUnits_IS_)
                {
                    PsychrometricsElevationPressureLabel2.Text = ConstantUnits.BarometricPressureKiloPascal;
                }
                else
                {
                    PsychrometricsElevationPressureLabel2.Text = ConstantUnits.BarometricPressureInchOfMercury;
                }
            }
        }

        private void SwitchCalculation()
        {
            string tooltip = string.Empty;

            if (Psychrometrics_Enthalpy.Checked)
            {
                TemperatureWetBulbLabel.Visible = false;
                PsychrometricsTemperatureWetBulbUnits.Visible = false;
                Psychrometrics_WBT_Value.Visible = false;
            }
            else
            {
                TemperatureWetBulbLabel.Visible = true;
                PsychrometricsTemperatureWetBulbUnits.Visible = true;
                Psychrometrics_WBT_Value.Visible = true;
            }

            if (Psychrometrics_DBT_RH.Checked)
            {
                TemperatureWetBulbLabel.Text = PsychrometricsInputData.RelativeHumitityDataValue.InputMessage + ":";
                TemperatureWetBulbLabel.TextAlign = ContentAlignment.MiddleRight;
                PsychrometricsTemperatureWetBulbUnits.Text = ConstantUnits.Percentage;
                Psychrometrics_WBT_Value.Text = PsychrometricsInputData.RelativeHumitityDataValue.InputValue;
                toolTip1.SetToolTip(Psychrometrics_WBT_Value, PsychrometricsInputData.RelativeHumitityDataValue.ToolTip);

                TemperatureDryBulbLabel.Text = PsychrometricsInputData.DryBulbTemperatureDataValue.InputMessage + ":";
                Psychrometrics_DBT_Value.Text = PsychrometricsInputData.DryBulbTemperatureDataValue.InputValue;
                toolTip1.SetToolTip(Psychrometrics_DBT_Value, PsychrometricsInputData.DryBulbTemperatureDataValue.ToolTip);
                if (IsInternationalSystemOfUnits_IS_)
                {
                    PsychrometricsTemperatureDryBulbUnits.Text = ConstantUnits.TemperatureCelsius;
                }
                else
                {
                    PsychrometricsTemperatureDryBulbUnits.Text = ConstantUnits.TemperatureFahrenheit;
                }
            }
            else if (Psychrometrics_Enthalpy.Checked)
            {
                TemperatureDryBulbLabel.Text = PsychrometricsInputData.EnthalpyDataValue.InputMessage + ":";
                TemperatureDryBulbLabel.TextAlign = ContentAlignment.MiddleRight;
                toolTip1.SetToolTip(Psychrometrics_DBT_Value, PsychrometricsInputData.EnthalpyDataValue.ToolTip);

                if (IsInternationalSystemOfUnits_IS_)
                {
                    PsychrometricsTemperatureDryBulbUnits.Text = ConstantUnits.KilojoulesPerKilogram;
                }
                else
                {
                    PsychrometricsTemperatureDryBulbUnits.Text = ConstantUnits.BtuPerPound;
                }
                Psychrometrics_DBT_Value.Text = PsychrometricsInputData.EnthalpyDataValue.InputValue;
            }
            else
            {
                TemperatureWetBulbLabel.Text = PsychrometricsInputData.WetBulbTemperatureDataValue.InputMessage + ":";
                TemperatureWetBulbLabel.TextAlign = ContentAlignment.MiddleRight;
                Psychrometrics_WBT_Value.Text = PsychrometricsInputData.WetBulbTemperatureDataValue.InputValue;
                toolTip1.SetToolTip(Psychrometrics_WBT_Value, PsychrometricsInputData.WetBulbTemperatureDataValue.ToolTip);

                TemperatureDryBulbLabel.Text = PsychrometricsInputData.DryBulbTemperatureDataValue.InputMessage + ":";
                TemperatureDryBulbLabel.TextAlign = ContentAlignment.MiddleRight;
                Psychrometrics_DBT_Value.Text = PsychrometricsInputData.DryBulbTemperatureDataValue.InputValue;
                toolTip1.SetToolTip(Psychrometrics_WBT_Value, PsychrometricsInputData.WetBulbTemperatureDataValue.ToolTip);

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

        private void CalculatePsychrometrics()
        {
            try
            {
                PsychrometricsData = new PsychrometricsData(IsInternationalSystemOfUnits_IS_);

                // clear data set
                if (Psychrometrics_GridView.DataSource != null)
                {
                    Psychrometrics_GridView.DataSource = null;
                }

                DataTable table = null;

                string message = string.Empty;

                if (PyschmetricsElevationRadio.Checked)
                {
                    if (!PsychrometricsInputData.ElevationDataValue.UpdateValue(Psychrometrics_Elevation_Value.Text, out message))
                    {
                        MessageBox.Show(message);
                        return;
                    }
                }
                else
                {
                    if (!PsychrometricsInputData.BarometricPressureDataValue.UpdateValue(Psychrometrics_Elevation_Value.Text, out message))
                    {
                        MessageBox.Show(message);
                        return;
                    }
                }

                if (Psychrometrics_DBT_RH.Checked)
                {
                    if (!PsychrometricsInputData.DryBulbTemperatureDataValue.UpdateValue(Psychrometrics_DBT_Value.Text, out message))
                    {
                        MessageBox.Show(message);
                        return;
                    }
                    if (!PsychrometricsInputData.RelativeHumitityDataValue.UpdateValue(Psychrometrics_WBT_Value.Text, out message))
                    {
                        MessageBox.Show(message);
                        return;
                    }
                }
                else if (Psychrometrics_Enthalpy.Checked)
                {
                    if (!PsychrometricsInputData.EnthalpyDataValue.UpdateValue(Psychrometrics_DBT_Value.Text, out message))
                    {
                        MessageBox.Show(message);
                        return;
                    }
                }
                else
                {
                    if (!PsychrometricsInputData.DryBulbTemperatureDataValue.UpdateValue(Psychrometrics_DBT_Value.Text, out message))
                    {
                        MessageBox.Show(message);
                        return;
                    }
                    if (!PsychrometricsInputData.WetBulbTemperatureDataValue.UpdateValue(Psychrometrics_WBT_Value.Text, out message))
                    {
                        MessageBox.Show(message);
                        return;
                    }
                    if (PsychrometricsInputData.DryBulbTemperatureDataValue.Current < PsychrometricsInputData.WetBulbTemperatureDataValue.Current)
                    {
                        MessageBox.Show("The Dry Bulb Temperature value must be greater than the Wet Bulb Temperature value");
                        return;
                    }
                }

                if (PyschmetricsElevationRadio.Checked)
                {
                    PsychrometricsData.Elevation = PsychrometricsInputData.ElevationDataValue.Current;
                }
                else
                {
                    PsychrometricsData.BarometricPressure = PsychrometricsInputData.BarometricPressureDataValue.Current;
                }

                PsychrometricsData.IsElevation = PyschmetricsElevationRadio.Checked;
                PsychrometricsData.SetInternationalSystemOfUnits_IS_(IsInternationalSystemOfUnits_IS_);

                if (Psychrometrics_WBT_DBT.Checked)
                {
                    PsychrometricsData.CalculationType = PsychrometricsCalculationType.Psychrometrics_WBT_DBT;
                    PsychrometricsInputData.CalculationType = PsychrometricsCalculationType.Psychrometrics_WBT_DBT;
                    PsychrometricsData.TemperatureDryBulb = PsychrometricsInputData.DryBulbTemperatureDataValue.Current;
                    PsychrometricsData.TemperatureWetBulb = PsychrometricsInputData.WetBulbTemperatureDataValue.Current;
                }
                else if (Psychrometrics_DBT_RH.Checked)
                {
                    PsychrometricsData.CalculationType = PsychrometricsCalculationType.Psychrometrics_DBT_RH;
                    PsychrometricsInputData.CalculationType = PsychrometricsCalculationType.Psychrometrics_DBT_RH;
                    PsychrometricsData.RelativeHumidity = PsychrometricsInputData.RelativeHumitityDataValue.Current;
                    PsychrometricsData.TemperatureDryBulb = PsychrometricsInputData.DryBulbTemperatureDataValue.Current;
                }
                else if (Psychrometrics_Enthalpy.Checked)
                {
                    PsychrometricsData.CalculationType = PsychrometricsCalculationType.Psychrometrics_Enthalpy;
                    PsychrometricsInputData.CalculationType = PsychrometricsCalculationType.Psychrometrics_Enthalpy;
                    PsychrometricsData.Enthalpy = PsychrometricsInputData.EnthalpyDataValue.Current;
                }

                table = PsychrometricsCalculationLibrary.PsychrometricsCalculation(PsychrometricsData);

                if (table != null)
                {
                    // Create a DataView using the DataTable.
                    DataView view = new DataView(table);

                    // Set a DataGrid control's DataSource to the DataView.
                    Psychrometrics_GridView.DataSource = view;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(string.Format("Error in Psychrometrics calculation. Please check your input values. Exception Message: {0}", exception.Message), "Psychrometrics Calculation Error");
            }
        }

        private void PyschmetricsElevationRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (PyschmetricsElevationRadio.Checked)
            {
                SwitchElevationPressure();

                CalculatePsychrometrics();
            }
        }

        private void PyschmetricsPressureRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (PyschmetricsPressureRadio.Checked)
            {
                SwitchElevationPressure();

                CalculatePsychrometrics();
            }
        }

        private void Psychrometrics_WBT_DBT_CheckedChanged(object sender, EventArgs e)
        {
            if (Psychrometrics_WBT_DBT.Checked)
            {
                PsychrometricsInputData.CalculationType = PsychrometricsCalculationType.Psychrometrics_WBT_DBT;

                SwitchCalculation();

                CalculatePsychrometrics();
            }

        }

        private void Psychrometrics_DBT_RH_CheckedChanged(object sender, EventArgs e)
        {
            if (Psychrometrics_DBT_RH.Checked)
            {
                PsychrometricsInputData.CalculationType = PsychrometricsCalculationType.Psychrometrics_DBT_RH;

                SwitchCalculation();

                CalculatePsychrometrics();
            }
        }

        private void Psychrometrics_Enthalpy_CheckedChanged(object sender, EventArgs e)
        {
            if (Psychrometrics_Enthalpy.Checked)
            {
                PsychrometricsInputData.CalculationType = PsychrometricsCalculationType.Psychrometrics_Enthalpy;

                SwitchCalculation();

                CalculatePsychrometrics();
            }
        }

        private void PsychrometricsCalculate_Click(object sender, EventArgs e)
        {
            CalculatePsychrometrics();
        }
    }
}
