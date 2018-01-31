using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CTIToolkit
{
    public partial class ToolkitForm : Form
    {
        private PsychrometricsInputData PsychrometricsInputData { get; set;}
        private PsychrometricsData PsychrometricsData { get; set; }
        private bool IsDemo { get; set; }

        public ToolkitForm()
        {
            InitializeComponent();
            PsychrometricsInputData = new PsychrometricsInputData();
            // read register for serial number and set IsDemo
            IsDemo = false;
        }

        // wet bulb and dry bulb
        private void Psychrometrics_WBT_DBT_CheckedChanged(object sender, EventArgs e)
        {
            PsychrometricsInputData.CalculationType = CalculationType.Psychrometrics_WBT_DBT;

            SwitchCalculation();

            CalculatePsychrometrics();
        }

        private void Psychrometrics_DBT_RH_CheckedChanged(object sender, EventArgs e)
        {
            PsychrometricsInputData.CalculationType = CalculationType.Psychrometrics_DBT_RH;

            SwitchCalculation();

            CalculatePsychrometrics();
        }

        private void Psychrometrics_Enthalpy_CheckedChanged(object sender, EventArgs e)
        {
            PsychrometricsInputData.CalculationType = CalculationType.Psychrometrics_Enthalpy;

            SwitchCalculation();

            CalculatePsychrometrics();
        }

        private void PsychrometricsCalculate_Click(object sender, EventArgs e)
        {
            CalculatePsychrometrics();
        }

        private void CalculatePsychrometrics()
        {
            try
            {
                PsychrometricsData = new PsychrometricsData();
                PsychrometricsData.SetDemo(IsDemo);

                // clear data set
                if (dataGridView1.DataSource != null)
                {
                    dataGridView1.DataSource = null;
                }

                DataTable table = null;

                //bool isDemo = false;

                //double outputValue = 0.0;
                string message = string.Empty;

                if (PyschmetricsAltituteRadio.Checked)
                {
                    if (!PsychrometricsInputData.AltitudeDataValue.UpdateValue(Psychrometrics_Altitude_Value.Text, out message))
                    {
                        MessageBox.Show(message);
                        return;
                    }
                }
                else
                {
                    if (!PsychrometricsInputData.BarometricPressureDataValue.UpdateValue(Psychrometrics_Altitude_Value.Text, out message))
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

                if (PyschmetricsAltituteRadio.Checked)
                {
                    PsychrometricsData.Altitude = PsychrometricsInputData.AltitudeDataValue.Current;
                }
                else
                {
                    PsychrometricsData.BarometricPressure = PsychrometricsInputData.BarometricPressureDataValue.Current;
                }

                PsychrometricsData.IsAltitute = PyschmetricsAltituteRadio.Checked;
                PsychrometricsData.SetMetric(Metric.Checked);

                if (Psychrometrics_WBT_DBT.Checked)
                {
                    PsychrometricsData.CalculationType = CalculationType.Psychrometrics_WBT_DBT;
                    PsychrometricsInputData.CalculationType = CalculationType.Psychrometrics_WBT_DBT;
                    PsychrometricsData.TemperatureDryBulb = PsychrometricsInputData.DryBlubTemperatureDataValue.Current;
                    PsychrometricsData.TemperatureWetBulb = PsychrometricsInputData.WetBlubTemperatureDataValue.Current;
                }
                else if (Psychrometrics_DBT_RH.Checked)
                {
                    PsychrometricsData.CalculationType = CalculationType.Psychrometrics_DBT_RH;
                    PsychrometricsInputData.CalculationType = CalculationType.Psychrometrics_DBT_RH;
                    PsychrometricsData.RelativeHumidity = PsychrometricsInputData.RelativeHumitityDataValue.Current;
                    PsychrometricsData.TemperatureDryBulb = PsychrometricsInputData.DryBlubTemperatureDataValue.Current;
                }
                else if (Psychrometrics_Enthalpy.Checked)
                {
                    PsychrometricsData.CalculationType = CalculationType.Psychrometrics_Enthalpy;
                    PsychrometricsInputData.CalculationType = CalculationType.Psychrometrics_Enthalpy;
                    PsychrometricsData.Enthalpy = PsychrometricsInputData.EnthalpyDataValue.Current;
                }

                table = PsychrometricsCalculationLibrary.PsychrometricsCalculation(PsychrometricsData);

                if (table != null)
                {
                    // Create a DataView using the DataTable.
                    DataView view = new DataView(table);

                    // Set a DataGrid control's DataSource to the DataView.
                    dataGridView1.DataSource = view;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(string.Format("Error in calculation. Please check your input values. Exception Message: {0}", exception.Message), "Psychrometrics Calculation Error");
            }
        }

        private void Metric_CheckedChanged(object sender, EventArgs e)
        {
            SwitchStandardMetric();
        }

        private void Standard_CheckedChanged(object sender, EventArgs e)
        {
            SwitchStandardMetric();
        }

        private void SwitchStandardMetric()
        {
            if (Metric.Checked)
            {
                if (Psychrometrics_DBT_RH.Checked)
                {
                    PsychrometricsTemperatureWetBlubUnits.Text = "%";
                }
                else
                {
                    PsychrometricsTemperatureWetBlubUnits.Text = "°C";
                }

                if (Psychrometrics_Enthalpy.Checked)
                {
                    PsychrometricsTemperatureDryBlubUnits.Text = "kJ/kg";
                }
                else
                {
                    PsychrometricsTemperatureDryBlubUnits.Text = "°C";
                }

                if (PyschmetricsAltituteRadio.Checked)
                {
                    PsychrometricsAltitutePressureLabel2.Text = "m";
                }
                else
                {
                    PsychrometricsAltitutePressureLabel2.Text = "kPa";
                }
            }
            else
            {
                if (Psychrometrics_DBT_RH.Checked)
                {
                    PsychrometricsTemperatureWetBlubUnits.Text = "%";
                }
                else
                {
                    PsychrometricsTemperatureWetBlubUnits.Text = "°F";
                }

                if (Psychrometrics_Enthalpy.Checked)
                {
                    PsychrometricsTemperatureDryBlubUnits.Text = "Btu/lbm";
                }
                else
                {
                    PsychrometricsTemperatureDryBlubUnits.Text = "°F";
                }

                if (PyschmetricsAltituteRadio.Checked)
                {
                    PsychrometricsAltitutePressureLabel2.Text = "ft";
                }
                else
                {
                    PsychrometricsAltitutePressureLabel2.Text = "\"Hg";
                }
            }
        }

        private void PyschmetricsAltituteRadio_CheckedChanged(object sender, EventArgs e)
        {
            SwitchAltitutePressure();
        }

        private void PyschmetricsPressureRadio_CheckedChanged(object sender, EventArgs e)
        {
            SwitchAltitutePressure();
        }

        private void SwitchAltitutePressure()
        {
            //PsychrometricsData.SetAltitute(PyschmetricsAltituteRadio.Checked);

            if (PyschmetricsAltituteRadio.Checked)
            {
                Psychrometrics_Altitude_Value.Text = PsychrometricsInputData.AltitudeDataValue.InputValue;
                PsychrometricsAltitutePressureLabel1.Text = "Altitute:";
                if (Metric.Checked)
                {
                    PsychrometricsAltitutePressureLabel2.Text = "m";
                }
                else
                {
                    PsychrometricsAltitutePressureLabel2.Text = "ft";
                }
            }
            else
            {
                Psychrometrics_Altitude_Value.Text = PsychrometricsInputData.BarometricPressureDataValue.InputValue;
                PsychrometricsAltitutePressureLabel1.Text = "Barometric Pressure:";
                if (Metric.Checked)
                {
                    PsychrometricsAltitutePressureLabel2.Text = "kPa";
                }
                else
                {
                    PsychrometricsAltitutePressureLabel2.Text = "\"Hg";
                }
            }
        }

        private void SwitchCalculation()
        {
            if (Psychrometrics_Enthalpy.Checked)
            {
                TemperatureWetBlubLabel.Visible = false;
                PsychrometricsTemperatureWetBlubUnits.Visible = false;
                Psychrometrics_WBT_Value.Visible = false;
                //TemperatureWetBlubLabel.Enabled = false;
                //PsychrometricsTemperatureWetBlubUnits.Enabled = false;
                //Psychrometrics_WBT_Value.Enabled = false;
            }
            else
            {
                TemperatureWetBlubLabel.Visible = true;
                PsychrometricsTemperatureWetBlubUnits.Visible = true;
                Psychrometrics_WBT_Value.Visible = true;
                //TemperatureWetBlubLabel.Enabled = true;
                //PsychrometricsTemperatureWetBlubUnits.Enabled = true;
                //Psychrometrics_WBT_Value.Enabled = true;
            }

            if (Psychrometrics_DBT_RH.Checked)
            {
                TemperatureWetBlubLabel.Text = PsychrometricsInputData.RelativeHumitityDataValue.InputMessage + ":";
                TemperatureWetBlubLabel.TextAlign = ContentAlignment.MiddleRight;
                PsychrometricsTemperatureWetBlubUnits.Text = "%";
                Psychrometrics_WBT_Value.Text = PsychrometricsInputData.RelativeHumitityDataValue.InputValue;

                TemperatureDryBlubLabel.Text = PsychrometricsInputData.DryBlubTemperatureDataValue.InputMessage + ":";
                Psychrometrics_DBT_Value.Text = PsychrometricsInputData.DryBlubTemperatureDataValue.InputValue;
                if (Metric.Checked)
                {
                    PsychrometricsTemperatureDryBlubUnits.Text = "°C";
                }
                else
                {
                    PsychrometricsTemperatureDryBlubUnits.Text = "°F";
                }
            }
            else if(Psychrometrics_Enthalpy.Checked)
            {
                TemperatureDryBlubLabel.Text = "Enthalpy:";
                TemperatureDryBlubLabel.TextAlign = ContentAlignment.MiddleRight;

                if (Metric.Checked)
                {
                    PsychrometricsTemperatureDryBlubUnits.Text = "kJ/kg";
                }
                else
                {
                    PsychrometricsTemperatureDryBlubUnits.Text = "BTU/lbm";
                }
                Psychrometrics_DBT_Value.Text = PsychrometricsInputData.EnthalpyDataValue.InputValue;
            }
            else
            {
                TemperatureWetBlubLabel.Text = "Temperature Wet Bulb:";
                TemperatureWetBlubLabel.TextAlign = ContentAlignment.MiddleRight;
                Psychrometrics_WBT_Value.Text = PsychrometricsInputData.WetBlubTemperatureDataValue.InputValue;

                TemperatureDryBlubLabel.Text = "Temperature Dry Bulb:";
                TemperatureDryBlubLabel.TextAlign = ContentAlignment.MiddleRight;
                Psychrometrics_DBT_Value.Text = PsychrometricsInputData.DryBlubTemperatureDataValue.InputValue;

                if (Metric.Checked)
                {
                    PsychrometricsTemperatureWetBlubUnits.Text = "°C";
                    PsychrometricsTemperatureDryBlubUnits.Text = "°C";
                }
                else
                {
                    PsychrometricsTemperatureWetBlubUnits.Text = "°F";
                    PsychrometricsTemperatureDryBlubUnits.Text = "°F";
                }
            }
        }

        private void Psychrometrics_WBT_Value_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
