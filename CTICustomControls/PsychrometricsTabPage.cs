using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ToolkitLibrary;

namespace CTICustomControls
{
    public partial class PsychrometricsTabPage: UserControl
    {
        private PsychrometricsInputData PsychrometricsInputData { get; set; }
        private PsychrometricsData PsychrometricsData { get; set; }
        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_IS_ { get; set; }

        public PsychrometricsTabPage()
        {
            InitializeComponent();

            PsychrometricsInputData = new PsychrometricsInputData(IsDemo, IsInternationalSystemOfUnits_IS_);

            SwitchCalculation();

            CalculatePsychrometrics();

        }

        private void SwitchUnitedStatesCustomaryUnits_IP_InternationalSystemOfUnits_IS_()
        {
            if (PsychrometricsInputData.ConvertValues(InternationalSystemOfUnits_IS_.Checked))
            {
                SwitchCalculation();
            }

            if (InternationalSystemOfUnits_IS_.Checked)
            {
                if (Psychrometrics_DBT_RH.Checked)
                {
                    PsychrometricsTemperatureWetBlubUnits.Text = ConstantUnits.Percentage;
                }
                else
                {
                    PsychrometricsTemperatureWetBlubUnits.Text = ConstantUnits.TemperatureCelsius;
                }

                if (Psychrometrics_Enthalpy.Checked)
                {
                    PsychrometricsTemperatureDryBlubUnits.Text = ConstantUnits.KilojoulesPerKilogram;
                }
                else
                {
                    PsychrometricsTemperatureDryBlubUnits.Text = ConstantUnits.TemperatureCelsius;
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
                    PsychrometricsTemperatureWetBlubUnits.Text = ConstantUnits.Percentage;
                }
                else
                {
                    PsychrometricsTemperatureWetBlubUnits.Text = ConstantUnits.TemperatureFahrenheit;
                }

                if (Psychrometrics_Enthalpy.Checked)
                {
                    PsychrometricsTemperatureDryBlubUnits.Text = ConstantUnits.BtuPerPound;
                }
                else
                {
                    PsychrometricsTemperatureDryBlubUnits.Text = ConstantUnits.TemperatureFahrenheit;
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
                if (InternationalSystemOfUnits_IS_.Checked)
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
                if (InternationalSystemOfUnits_IS_.Checked)
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
                TemperatureWetBlubLabel.Visible = false;
                PsychrometricsTemperatureWetBlubUnits.Visible = false;
                Psychrometrics_WBT_Value.Visible = false;
            }
            else
            {
                TemperatureWetBlubLabel.Visible = true;
                PsychrometricsTemperatureWetBlubUnits.Visible = true;
                Psychrometrics_WBT_Value.Visible = true;
            }

            if (Psychrometrics_DBT_RH.Checked)
            {
                TemperatureWetBlubLabel.Text = PsychrometricsInputData.RelativeHumitityDataValue.InputMessage + ":";
                TemperatureWetBlubLabel.TextAlign = ContentAlignment.MiddleRight;
                PsychrometricsTemperatureWetBlubUnits.Text = ConstantUnits.Percentage;
                Psychrometrics_WBT_Value.Text = PsychrometricsInputData.RelativeHumitityDataValue.InputValue;
                toolTip1.SetToolTip(Psychrometrics_WBT_Value, PsychrometricsInputData.RelativeHumitityDataValue.ToolTip);

                TemperatureDryBlubLabel.Text = PsychrometricsInputData.DryBlubTemperatureDataValue.InputMessage + ":";
                Psychrometrics_DBT_Value.Text = PsychrometricsInputData.DryBlubTemperatureDataValue.InputValue;
                toolTip1.SetToolTip(Psychrometrics_DBT_Value, PsychrometricsInputData.DryBlubTemperatureDataValue.ToolTip);
                if (InternationalSystemOfUnits_IS_.Checked)
                {
                    PsychrometricsTemperatureDryBlubUnits.Text = ConstantUnits.TemperatureCelsius;
                }
                else
                {
                    PsychrometricsTemperatureDryBlubUnits.Text = ConstantUnits.TemperatureFahrenheit;
                }
            }
            else if (Psychrometrics_Enthalpy.Checked)
            {
                TemperatureDryBlubLabel.Text = PsychrometricsInputData.EnthalpyDataValue.InputMessage + ":";
                TemperatureDryBlubLabel.TextAlign = ContentAlignment.MiddleRight;
                toolTip1.SetToolTip(Psychrometrics_DBT_Value, PsychrometricsInputData.EnthalpyDataValue.ToolTip);

                if (InternationalSystemOfUnits_IS_.Checked)
                {
                    PsychrometricsTemperatureDryBlubUnits.Text = ConstantUnits.KilojoulesPerKilogram;
                }
                else
                {
                    PsychrometricsTemperatureDryBlubUnits.Text = ConstantUnits.BtuPerPound;
                }
                Psychrometrics_DBT_Value.Text = PsychrometricsInputData.EnthalpyDataValue.InputValue;
            }
            else
            {
                TemperatureWetBlubLabel.Text = PsychrometricsInputData.WetBlubTemperatureDataValue.InputMessage + ":";
                TemperatureWetBlubLabel.TextAlign = ContentAlignment.MiddleRight;
                Psychrometrics_WBT_Value.Text = PsychrometricsInputData.WetBlubTemperatureDataValue.InputValue;
                toolTip1.SetToolTip(Psychrometrics_WBT_Value, PsychrometricsInputData.WetBlubTemperatureDataValue.ToolTip);

                TemperatureDryBlubLabel.Text = PsychrometricsInputData.DryBlubTemperatureDataValue.InputMessage + ":";
                TemperatureDryBlubLabel.TextAlign = ContentAlignment.MiddleRight;
                Psychrometrics_DBT_Value.Text = PsychrometricsInputData.DryBlubTemperatureDataValue.InputValue;
                toolTip1.SetToolTip(Psychrometrics_WBT_Value, PsychrometricsInputData.WetBlubTemperatureDataValue.ToolTip);

                if (InternationalSystemOfUnits_IS_.Checked)
                {
                    PsychrometricsTemperatureWetBlubUnits.Text = ConstantUnits.TemperatureCelsius;
                    PsychrometricsTemperatureDryBlubUnits.Text = ConstantUnits.TemperatureCelsius;
                }
                else
                {
                    PsychrometricsTemperatureWetBlubUnits.Text = ConstantUnits.TemperatureFahrenheit;
                    PsychrometricsTemperatureDryBlubUnits.Text = ConstantUnits.TemperatureFahrenheit;
                }
            }
        }

        private void CalculatePsychrometrics()
        {
            try
            {
                PsychrometricsData = new PsychrometricsData();

                // clear data set
                if (PsychrometricsGridView.DataSource != null)
                {
                    PsychrometricsGridView.DataSource = null;
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
                    if (!PsychrometricsInputData.DryBlubTemperatureDataValue.UpdateValue(Psychrometrics_DBT_Value.Text, out message))
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
                    if (!PsychrometricsInputData.DryBlubTemperatureDataValue.UpdateValue(Psychrometrics_DBT_Value.Text, out message))
                    {
                        MessageBox.Show(message);
                        return;
                    }
                    if (!PsychrometricsInputData.WetBlubTemperatureDataValue.UpdateValue(Psychrometrics_WBT_Value.Text, out message))
                    {
                        MessageBox.Show(message);
                        return;
                    }
                    if (PsychrometricsInputData.DryBlubTemperatureDataValue.Current < PsychrometricsInputData.WetBlubTemperatureDataValue.Current)
                    {
                        MessageBox.Show("The Dry Blub Temperature value must be greater than the Wet Blub Temperature value");
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
                PsychrometricsData.SetInternationalSystemOfUnits_IS_(InternationalSystemOfUnits_IS_.Checked);

                if (Psychrometrics_WBT_DBT.Checked)
                {
                    PsychrometricsData.CalculationType = PsychrometricsCalculationType.Psychrometrics_WBT_DBT;
                    PsychrometricsInputData.CalculationType = PsychrometricsCalculationType.Psychrometrics_WBT_DBT;
                    PsychrometricsData.TemperatureDryBulb = PsychrometricsInputData.DryBlubTemperatureDataValue.Current;
                    PsychrometricsData.TemperatureWetBulb = PsychrometricsInputData.WetBlubTemperatureDataValue.Current;
                }
                else if (Psychrometrics_DBT_RH.Checked)
                {
                    PsychrometricsData.CalculationType = PsychrometricsCalculationType.Psychrometrics_DBT_RH;
                    PsychrometricsInputData.CalculationType = PsychrometricsCalculationType.Psychrometrics_DBT_RH;
                    PsychrometricsData.RelativeHumidity = PsychrometricsInputData.RelativeHumitityDataValue.Current;
                    PsychrometricsData.TemperatureDryBulb = PsychrometricsInputData.DryBlubTemperatureDataValue.Current;
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
                    PsychrometricsGridView.DataSource = view;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(string.Format("Error in calculation. Please check your input values. Exception Message: {0}", exception.Message), "Psychrometrics Calculation Error");
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

        private void UnitedStatesCustomaryUnits_IP__CheckedChanged(object sender, EventArgs e)
        {
            if (UnitedStatesCustomaryUnits_IP_.Checked)
            {
                SwitchUnitedStatesCustomaryUnits_IP_InternationalSystemOfUnits_IS_();

                CalculatePsychrometrics();
            }
        }

        private void InternationalSystemOfUnits_IS__CheckedChanged(object sender, EventArgs e)
        {
            if (InternationalSystemOfUnits_IS_.Checked)
            {
                SwitchUnitedStatesCustomaryUnits_IP_InternationalSystemOfUnits_IS_();
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
