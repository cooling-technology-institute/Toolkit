using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ToolkitLibrary;

namespace CTICustomControls
{
    public partial class MerkelTabPage: UserControl
    {
        private MerkelInputData MerkelInputData { get; set; }
        private MerkelData MerkelData { get; set; }
        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_IS_ { get; set; }

        public MerkelTabPage()
        {
            InitializeComponent();

            MerkelInputData = new MerkelInputData(IsDemo, IsInternationalSystemOfUnits_IS_);

            SwitchCalculation();

            CalculateMerkel();

        }

        private void SwitchUnitedStatesCustomaryUnits_IP_InternationalSystemOfUnits_IS_()
        {
            if (MerkelInputData.ConvertValues(InternationalSystemOfUnits_IS_.Checked))
            {
                SwitchCalculation();
            }

            if (InternationalSystemOfUnits_IS_.Checked)
            {
                if (MerkelElevationRadio.Checked)
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
                if (MerkelElevationRadio.Checked)
                {
                    MerkelElevationPressureUnits.Text = ConstantUnits.Foot;
                }
                else
                {
                    MerkelElevationPressureUnits.Text = ConstantUnits.BarometricPressureInchOfMercury;
                }
            }
        }

        private void SwitchElevationPressure()
        {
            string message;

            if (MerkelElevationRadio.Checked)
            {
                double value = 0.0;
                if (double.TryParse(Merkel_Elevation_Value.Text, out value))
                {
                    value = UnitConverter.ConvertBarometricPressureToElevation(value);
                }
                else
                {
                    value = MerkelInputData.ElevationDataValue.Default;
                }
                MerkelInputData.BarometricPressureDataValue.UpdateValue(value.ToString(), out message);
                Merkel_Elevation_Value.Text = MerkelInputData.ElevationDataValue.InputValue;
                MerkelElevationPressureLabel.Text = MerkelInputData.ElevationDataValue.InputMessage + ":";
                if (InternationalSystemOfUnits_IS_.Checked)
                {
                    MerkelElevationPressureUnits.Text = ConstantUnits.Meter;
                }
                else
                {
                    MerkelElevationPressureUnits.Text = ConstantUnits.Foot;
                }
            }
            else
            {
                double value = 0.0;
                if (double.TryParse(Merkel_Elevation_Value.Text, out value))
                {
                    value = UnitConverter.ConvertElevationToBarometricPressure(value);
                    value = UnitConverter.CalculatePressureFahrenheit(value);

                }
                else
                {
                    value = MerkelInputData.BarometricPressureDataValue.Default;
                }
                MerkelInputData.BarometricPressureDataValue.UpdateValue(value.ToString(), out message);
                Merkel_Elevation_Value.Text = MerkelInputData.BarometricPressureDataValue.InputValue;
                MerkelElevationPressureLabel.Text = MerkelInputData.BarometricPressureDataValue.InputMessage + ":";
                if (InternationalSystemOfUnits_IS_.Checked)
                {
                    MerkelElevationPressureUnits.Text = ConstantUnits.BarometricPressureKiloPascal;
                }
                else
                {
                    MerkelElevationPressureUnits.Text = ConstantUnits.BarometricPressureInchOfMercury;
                }
            }
        }

        private void SwitchCalculation()
        {
            string tooltip = string.Empty;

            TemperatureHotWaterLabel.Text = MerkelInputData.HotWaterTemperatureDataValue.InputMessage + ":";
            TemperatureHotWaterLabel.TextAlign = ContentAlignment.MiddleRight;
            Merkel_HWT_Value.Text = MerkelInputData.HotWaterTemperatureDataValue.InputValue;
            toolTip1.SetToolTip(Merkel_HWT_Value, MerkelInputData.HotWaterTemperatureDataValue.ToolTip);

            TemperatureColdWaterLabel.Text = MerkelInputData.ColdWaterTemperatureDataValue.InputMessage + ":";
            TemperatureColdWaterLabel.TextAlign = ContentAlignment.MiddleRight;
            Merkel_CWT_Value.Text = MerkelInputData.ColdWaterTemperatureDataValue.InputValue;
            toolTip1.SetToolTip(Merkel_CWT_Value, MerkelInputData.ColdWaterTemperatureDataValue.ToolTip);

            MerkelWetBulbTemperatureLabel.Text = MerkelInputData.WetBlubTemperatureDataValue.InputMessage + ":";
            MerkelWetBulbTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
            Merkel_Wet_Bulb_Value.Text = MerkelInputData.WetBlubTemperatureDataValue.InputValue;
            toolTip1.SetToolTip(Merkel_Wet_Bulb_Value, MerkelInputData.WetBlubTemperatureDataValue.ToolTip);

            Merkel_LG_Value.Text = MerkelInputData.WaterAirFlowRateDataValue.InputValue;
            toolTip1.SetToolTip(Merkel_LG_Value, MerkelInputData.WaterAirFlowRateDataValue.ToolTip);

            if (InternationalSystemOfUnits_IS_.Checked)
            {
                MerkelTemperatureHotWaterUnits.Text = ConstantUnits.TemperatureCelsius;
                MerkelTemperatureColdWaterUnits.Text = ConstantUnits.TemperatureCelsius;
                MerkelTemperatureWebBulbUnits.Text = ConstantUnits.TemperatureCelsius;
            }
            else
            {
                MerkelTemperatureHotWaterUnits.Text = ConstantUnits.TemperatureFahrenheit;
                MerkelTemperatureColdWaterUnits.Text = ConstantUnits.TemperatureFahrenheit;
                MerkelTemperatureWebBulbUnits.Text = ConstantUnits.TemperatureFahrenheit;
            }
        }

        private void CalculateMerkel()
        {
            try
            {
                MerkelData = new MerkelData();

                // clear data set
                if (MerkelGridView.DataSource != null)
                {
                    MerkelGridView.DataSource = null;
                }

                DataTable table = null;

                string message = string.Empty;

                if (MerkelElevationRadio.Checked)
                {
                    if (!MerkelInputData.ElevationDataValue.UpdateValue(Merkel_Elevation_Value.Text, out message))
                    {
                        MessageBox.Show(message);
                        return;
                    }
                }
                else
                {
                    if (!MerkelInputData.BarometricPressureDataValue.UpdateValue(Merkel_Elevation_Value.Text, out message))
                    {
                        MessageBox.Show(message);
                        return;
                    }
                }

                if (!MerkelInputData.ColdWaterTemperatureDataValue.UpdateValue(Merkel_CWT_Value.Text, out message))
                {
                    MessageBox.Show(message);
                    return;
                }

                if (!MerkelInputData.HotWaterTemperatureDataValue.UpdateValue(Merkel_HWT_Value.Text, out message))
                {
                    MessageBox.Show(message);
                    return;
                }

                if (!MerkelInputData.WetBlubTemperatureDataValue.UpdateValue(Merkel_Wet_Bulb_Value.Text, out message))
                {
                    MessageBox.Show(message);
                    return;
                }

                if (!MerkelInputData.WaterAirFlowRateDataValue.UpdateValue(Merkel_LG_Value.Text, out message))
                {
                    MessageBox.Show(message);
                    return;
                }

                if (MerkelInputData.HotWaterTemperatureDataValue.Current < MerkelInputData.ColdWaterTemperatureDataValue.Current)
                {
                    MessageBox.Show("The Hot Water Temperature value must be greater than the Cold Water Temperature value");
                    return;
                }

                if (MerkelElevationRadio.Checked)
                {
                    MerkelData.Elevation = MerkelInputData.ElevationDataValue.Current;
                }
                else
                {
                    MerkelData.BarometricPressure = MerkelInputData.BarometricPressureDataValue.Current;
                }

                MerkelData.IsElevation = MerkelElevationRadio.Checked;
                MerkelData.SetInternationalSystemOfUnits_IS_(InternationalSystemOfUnits_IS_.Checked);

                MerkelData.HotWaterTemperature = MerkelInputData.HotWaterTemperatureDataValue.Current;
                MerkelData.ColdWaterTemperature = MerkelInputData.ColdWaterTemperatureDataValue.Current;
                MerkelData.WetBulbTemperature = MerkelInputData.WetBlubTemperatureDataValue.Current;
                MerkelData.WaterAirRatio = MerkelInputData.WaterAirFlowRateDataValue.Current;

                MerkelData.Range = MerkelData.HotWaterTemperature - MerkelData.ColdWaterTemperature;
                MerkelData.Approach = MerkelData.ColdWaterTemperature - MerkelData.WetBulbTemperature;

                if (!MerkelData.IsElevation)
                {
                    MerkelData.Elevation = UnitConverter.ConvertBarometricPressureToElevation(MerkelData.BarometricPressure);
                }

                //double WBT = m_dblMerkelWBT;
                //double LG = m_dblMerkelLG;
                //double dblrange = m_dblMerkelT1 - m_dblMerkelT2;
                //double approach = m_dblMerkelT2 - m_dblMerkelWBT;
                //double altitude = m_dblMerkelAltitude;
                //double T1 = m_dblMerkelT1;
                //double T2 = m_dblMerkelT2;


                //if (TPropPageBase::metricflag)
                //{
                //    WBT = fnCelcToFar(WBT);
                //    T1 = fnCelcToFar(T1);
                //    T2 = fnCelcToFar(T2);
                //    dblrange = T1 - T2;
                //    approach = T2 - WBT;
                //    altitude = fnMetersToFeet(altitude);
                //}

                table = MerkelCalculationLibrary.MerkelCalculation(MerkelData);

                if (table != null)
                {
                    // Create a DataView using the DataTable.
                    DataView view = new DataView(table);

                    // Set a DataGrid control's DataSource to the DataView.
                    MerkelGridView.DataSource = view;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(string.Format("Error in calculation. Please check your input values. Exception Message: {0}", exception.Message), "Merkel Calculation Error");
            }
        }

        private void MerkelElevationRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (MerkelElevationRadio.Checked)
            {
                SwitchElevationPressure();
                CalculateMerkel();
            }
        }

        private void MerkelPressureRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (MerkelPressureRadio.Checked)
            {
                SwitchElevationPressure();
                CalculateMerkel();
            }
        }

        private void UnitedStatesCustomaryUnits_IP__CheckedChanged(object sender, EventArgs e)
        {
            if (UnitedStatesCustomaryUnits_IP_.Checked)
            {
                SwitchUnitedStatesCustomaryUnits_IP_InternationalSystemOfUnits_IS_();
                CalculateMerkel();
            }
        }

        private void InternationalSystemOfUnits_IS__CheckedChanged(object sender, EventArgs e)
        {
            if (InternationalSystemOfUnits_IS_.Checked)
            {
                SwitchUnitedStatesCustomaryUnits_IP_InternationalSystemOfUnits_IS_();
                CalculateMerkel();
            }
        }

        private void MerkelCalculate_Click(object sender, EventArgs e)
        {
            CalculateMerkel();
        }
    }
}
