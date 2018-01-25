using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTIToolkit
{
    public partial class ToolkitForm : Form
    {
        public ToolkitForm()
        {
            InitializeComponent();
        }

        // wet bulb and dry bulb
        private void Psychrometrics_WBT_DBT_CheckedChanged(object sender, EventArgs e)
        {
            SwitchCalculation();
            
            // clear data set
            if (dataGridView1.DataSource != null)
            {
                dataGridView1.DataSource = null;
            }
        }

        private void Psychrometrics_DBT_RH_CheckedChanged(object sender, EventArgs e)
        {
            SwitchCalculation();

            // clear data set
            if (dataGridView1.DataSource != null)
            {
                dataGridView1.DataSource = null;
            }
        }

        private void Psychrometrics_Enthalpy_CheckedChanged(object sender, EventArgs e)
        {
            SwitchCalculation();

            // clear data set
            if (dataGridView1.DataSource != null)
            {
                dataGridView1.DataSource = null;
            }
        }

        private void PsychrometricsCalculate_Click(object sender, EventArgs e)
        {
            CalculatePsychrometrics();
        }

        private void CalculatePsychrometrics()
        {
            try
            {
                // clear data set
                if (dataGridView1.DataSource != null)
                {
                    dataGridView1.DataSource = null;
                }

                DataTable table = null;

                bool isDemo = false;

                PsychrometricsData psychrometricsData = new PsychrometricsData(Metric.Checked, PyschmetricsAltituteRadio.Checked, isDemo);

                if (PyschmetricsAltituteRadio.Checked)
                {
                    psychrometricsData.AltitudeInput = Psychrometrics_Altitude_Value.Text;
                }
                else
                {
                    psychrometricsData.BarometricPressureInput = Psychrometrics_Altitude_Value.Text;
                }

                if (Psychrometrics_DBT_RH.Checked)
                {
                    psychrometricsData.TemperatureDryBulbInput = Psychrometrics_DBT_Value.Text;
                    psychrometricsData.TemperatureWetBulbInput = string.Empty;
                    psychrometricsData.EnthalpyInput = string.Empty;
                    psychrometricsData.RelativeHumidityInput = Psychrometrics_WBT_Value.Text;
                }
                else if (Psychrometrics_Enthalpy.Checked)
                {
                    psychrometricsData.TemperatureDryBulbInput = string.Empty;
                    psychrometricsData.TemperatureWetBulbInput = string.Empty;
                    psychrometricsData.EnthalpyInput = Psychrometrics_DBT_Value.Text;
                    psychrometricsData.RelativeHumidityInput = string.Empty;
                }
                else
                {
                    psychrometricsData.TemperatureDryBulbInput = Psychrometrics_DBT_Value.Text;
                    psychrometricsData.TemperatureWetBulbInput = Psychrometrics_WBT_Value.Text;
                    psychrometricsData.EnthalpyInput = string.Empty;
                    psychrometricsData.RelativeHumidityInput = string.Empty;
                }

                if (Psychrometrics_WBT_DBT.Checked)
                {
                    psychrometricsData.CalculationType = CalculationType.Psychrometrics_WBT_DBT;
                }
                else if (Psychrometrics_DBT_RH.Checked)
                {
                    psychrometricsData.CalculationType = CalculationType.Psychrometrics_DBT_RH;
                }
                else if (Psychrometrics_Enthalpy.Checked)
                {
                    psychrometricsData.CalculationType = CalculationType.Psychrometrics_Enthalpy;
                }

                string message = string.Empty;
                if (psychrometricsData.IsValidInput(out message))
                {
                    table = PsychrometricsCalculationLibrary.PsychrometricsCalculation(psychrometricsData);

                    if (table != null)
                    {
                        // Create a DataView using the DataTable.
                        DataView view = new DataView(table);

                        // Set a DataGrid control's DataSource to the DataView.
                        dataGridView1.DataSource = view;
                    }
                }
                else
                {
                    MessageBox.Show(message);
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

                PsychrometricsTemperatureDryBlubUnits.Text = "°C";

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

                PsychrometricsTemperatureDryBlubUnits.Text = "°F";

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
            if (PyschmetricsAltituteRadio.Checked)
            {
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
            }
            else
            {
                TemperatureWetBlubLabel.Visible = true;
                PsychrometricsTemperatureWetBlubUnits.Visible = true;
                Psychrometrics_WBT_Value.Visible = true;

                TemperatureDryBulbLabel.Text = "Temperature Dry Bulb:";
                TemperatureDryBulbLabel.TextAlign = ContentAlignment.MiddleRight;
            }

            if (Psychrometrics_DBT_RH.Checked)
            {
                TemperatureWetBlubLabel.Text = "Relative Humidity:";
                TemperatureWetBlubLabel.TextAlign = ContentAlignment.MiddleRight;
                PsychrometricsTemperatureWetBlubUnits.Text = "%";
                Psychrometrics_WBT_Value.Text = "42.38";
            }
            else if(Psychrometrics_Enthalpy.Checked)
            {
                TemperatureDryBulbLabel.Text = "Enthalpy:";
                TemperatureDryBulbLabel.TextAlign = ContentAlignment.MiddleRight;
                PsychrometricsTemperatureDryBlubUnits.Text = "BTU/lbm";
            }
            else
            {
                TemperatureWetBlubLabel.Text = "Temperature Wet Bulb:";
                Psychrometrics_WBT_Value.Text = "80";
                TemperatureWetBlubLabel.TextAlign = ContentAlignment.MiddleRight;
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
