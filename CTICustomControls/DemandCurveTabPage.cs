using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ToolkitLibrary;

namespace CTICustomControls
{
    public partial class DemandCurveTabPage: UserControl
    {
        private DemandCurveInputData DemandCurveInputData { get; set; }
        private DemandCurveData DemandCurveData { get; set; }
        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_IS_ { get; set; }

        public DemandCurveTabPage()
        {
            InitializeComponent();

            DemandCurveInputData = new DemandCurveInputData(IsDemo, IsInternationalSystemOfUnits_IS_);

            SwitchCalculation();

            CalculateDemandCurve();

        }

        private void SwitchUnitedStatesCustomaryUnits_IP_InternationalSystemOfUnits_IS_()
        {
            if (DemandCurveInputData.ConvertValues(InternationalSystemOfUnits_IS_.Checked, DemandCurveElevationRadio.Checked))
            {
                SwitchCalculation();
            }

            if (InternationalSystemOfUnits_IS_.Checked)
            {
                if (DemandCurveElevationRadio.Checked)
                {
                    DemandCurveElevationPressureUnits.Text = ConstantUnits.Meter;
                }
                else
                {
                    DemandCurveElevationPressureUnits.Text = ConstantUnits.BarometricPressureKiloPascal;
                }
            }
            else
            {
                if (DemandCurveElevationRadio.Checked)
                {
                    DemandCurveElevationPressureUnits.Text = ConstantUnits.Foot;
                }
                else
                {
                    DemandCurveElevationPressureUnits.Text = ConstantUnits.BarometricPressureInchOfMercury;
                }
            }
        }

        private void SwitchElevationPressure()
        {
            string message;

            if (DemandCurveInputData.ConvertValues(InternationalSystemOfUnits_IS_.Checked, DemandCurveElevationRadio.Checked))
            {
                SwitchCalculation();
            }

            if (DemandCurveElevationRadio.Checked)
            {
                //double value = 0.0;
                //if (double.TryParse(DemandCurve_Elevation_Value.Text, out value))
                //{
                //    if (InternationalSystemOfUnits_IS_.Checked)
                //    {
                //        value = UnitConverter.ConvertKilopascalToElevationInMeters(value);
                //    }
                //    else
                //    {
                //        value = UnitConverter.ConvertBarometricPressureToElevationInFeet(value);
                //    }
                //}
                //else
                //{
                //    value = DemandCurveInputData.ElevationDataValue.Default;
                //}
                //DemandCurveInputData.BarometricPressureDataValue.UpdateValue(value.ToString(), out message);
                //DemandCurve_Elevation_Value.Text = DemandCurveInputData.ElevationDataValue.InputValue;
                //DemandCurveElevationPressureLabel.Text = DemandCurveInputData.ElevationDataValue.InputMessage + ":";
                if (InternationalSystemOfUnits_IS_.Checked)
                {
                    DemandCurveElevationPressureUnits.Text = ConstantUnits.Meter;
                }
                else
                {
                    DemandCurveElevationPressureUnits.Text = ConstantUnits.Foot;
                }
            }
            else
            {
                //double value = 0.0;
                //if (double.TryParse(DemandCurve_Elevation_Value.Text, out value))
                //{
                //   if (InternationalSystemOfUnits_IS_.Checked)
                //    {
                //        value = UnitConverter.ConvertElevationInMetersToKilopascal(value);
                //    }
                //    else
                //    {
                //        value = UnitConverter.CalculatePressureFahrenheit(UnitConverter.ConvertElevationInFeetToBarometricPressure(value));
                //    }
                //}
                //else
                //{
                //    value = DemandCurveInputData.BarometricPressureDataValue.Default;
                //}
                //DemandCurveInputData.BarometricPressureDataValue.UpdateValue(value.ToString(), out message);
                //DemandCurve_Elevation_Value.Text = DemandCurveInputData.BarometricPressureDataValue.InputValue;
                //DemandCurveElevationPressureLabel.Text = DemandCurveInputData.BarometricPressureDataValue.InputMessage + ":";
                if (InternationalSystemOfUnits_IS_.Checked)
                {
                    DemandCurveElevationPressureUnits.Text = ConstantUnits.BarometricPressureKiloPascal;
                }
                else
                {
                    DemandCurveElevationPressureUnits.Text = ConstantUnits.BarometricPressureInchOfMercury;
                }
            }
        }

        private void SwitchCalculation()
        {
            string tooltip = string.Empty;

            DemandCurveDataFileLabel.Text = DemandCurveInputData.HotWaterTemperatureDataValue.InputMessage + ":";
            DemandCurveDataFileLabel.TextAlign = ContentAlignment.MiddleRight;
            DemandCurveDataFile_Value.Text = DemandCurveInputData.HotWaterTemperatureDataValue.InputValue;
            toolTip1.SetToolTip(DemandCurveDataFile_Value, DemandCurveInputData.HotWaterTemperatureDataValue.ToolTip);

            TemperatureColdWaterLabel.Text = DemandCurveInputData.ColdWaterTemperatureDataValue.InputMessage + ":";
            TemperatureColdWaterLabel.TextAlign = ContentAlignment.MiddleRight;
            DemandCurve_CWT_Value.Text = DemandCurveInputData.ColdWaterTemperatureDataValue.InputValue;
            toolTip1.SetToolTip(DemandCurve_CWT_Value, DemandCurveInputData.ColdWaterTemperatureDataValue.ToolTip);

            DemandCurveWetBulbTemperatureLabel.Text = DemandCurveInputData.WetBlubTemperatureDataValue.InputMessage + ":";
            DemandCurveWetBulbTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
            DemandCurve_Wet_Bulb_Value.Text = DemandCurveInputData.WetBlubTemperatureDataValue.InputValue;
            toolTip1.SetToolTip(DemandCurve_Wet_Bulb_Value, DemandCurveInputData.WetBlubTemperatureDataValue.ToolTip);

            DemandCurve_LG_Value.Text = DemandCurveInputData.WaterAirFlowRateDataValue.InputValue;
            toolTip1.SetToolTip(DemandCurve_LG_Value, DemandCurveInputData.WaterAirFlowRateDataValue.ToolTip);

            if (DemandCurveElevationRadio.Checked)
            {
                DemandCurve_Elevation_Value.Text = DemandCurveInputData.ElevationDataValue.InputValue;
                DemandCurveElevationPressureLabel.Text = DemandCurveInputData.ElevationDataValue.InputMessage + ":";
                if (InternationalSystemOfUnits_IS_.Checked)
                {
                    DemandCurveElevationPressureUnits.Text = ConstantUnits.Meter;
                }
                else
                {
                    DemandCurveElevationPressureUnits.Text = ConstantUnits.Foot;
                }
            }
            else
            {
                DemandCurve_Elevation_Value.Text = DemandCurveInputData.BarometricPressureDataValue.InputValue;
                DemandCurveElevationPressureLabel.Text = DemandCurveInputData.BarometricPressureDataValue.InputMessage + ":";
                if (InternationalSystemOfUnits_IS_.Checked)
                {
                    DemandCurveElevationPressureUnits.Text = ConstantUnits.BarometricPressureKiloPascal;
                }
                else
                {
                    DemandCurveElevationPressureUnits.Text = ConstantUnits.BarometricPressureInchOfMercury;
                }
            }

            if (InternationalSystemOfUnits_IS_.Checked)
            {
                DemandCurveTemperatureHotWaterUnits.Text = ConstantUnits.TemperatureCelsius;
                DemandCurveTemperatureColdWaterUnits.Text = ConstantUnits.TemperatureCelsius;
                DemandCurveTemperatureWebBulbUnits.Text = ConstantUnits.TemperatureCelsius;
            }
            else
            {
                DemandCurveTemperatureHotWaterUnits.Text = ConstantUnits.TemperatureFahrenheit;
                DemandCurveTemperatureColdWaterUnits.Text = ConstantUnits.TemperatureFahrenheit;
                DemandCurveTemperatureWebBulbUnits.Text = ConstantUnits.TemperatureFahrenheit;
            }
        }

        private void CalculateDemandCurve()
        {
            try
            {
                DemandCurveData = new DemandCurveData();

                // clear data set
                if (DemandCurveGridView.DataSource != null)
                {
                    DemandCurveGridView.DataSource = null;
                }

                DataTable table = null;

                string message = string.Empty;

                if (DemandCurveElevationRadio.Checked)
                {
                    if (!DemandCurveInputData.ElevationDataValue.UpdateValue(DemandCurve_Elevation_Value.Text, out message))
                    {
                        MessageBox.Show(message);
                        return;
                    }
                }
                else
                {
                    if (!DemandCurveInputData.BarometricPressureDataValue.UpdateValue(DemandCurve_Elevation_Value.Text, out message))
                    {
                        MessageBox.Show(message);
                        return;
                    }
                }

                if (!DemandCurveInputData.ColdWaterTemperatureDataValue.UpdateValue(DemandCurve_CWT_Value.Text, out message))
                {
                    MessageBox.Show(message);
                    return;
                }

                if (!DemandCurveInputData.HotWaterTemperatureDataValue.UpdateValue(DemandCurveDataFile_Value.Text, out message))
                {
                    MessageBox.Show(message);
                    return;
                }

                if (!DemandCurveInputData.WetBlubTemperatureDataValue.UpdateValue(DemandCurve_Wet_Bulb_Value.Text, out message))
                {
                    MessageBox.Show(message);
                    return;
                }

                if (!DemandCurveInputData.WaterAirFlowRateDataValue.UpdateValue(DemandCurve_LG_Value.Text, out message))
                {
                    MessageBox.Show(message);
                    return;
                }

                if (DemandCurveInputData.HotWaterTemperatureDataValue.Current < DemandCurveInputData.ColdWaterTemperatureDataValue.Current)
                {
                    MessageBox.Show("The Hot Water Temperature value must be greater than the Cold Water Temperature value");
                    return;
                }

                if (DemandCurveElevationRadio.Checked)
                {
                    DemandCurveData.Elevation = DemandCurveInputData.ElevationDataValue.Current;
                }
                else
                {
                    DemandCurveData.BarometricPressure = DemandCurveInputData.BarometricPressureDataValue.Current;
                }

                DemandCurveData.IsElevation = DemandCurveElevationRadio.Checked;
                DemandCurveData.SetInternationalSystemOfUnits_IS_(InternationalSystemOfUnits_IS_.Checked);

                DemandCurveData.HotWaterTemperature = DemandCurveInputData.HotWaterTemperatureDataValue.Current;
                DemandCurveData.ColdWaterTemperature = DemandCurveInputData.ColdWaterTemperatureDataValue.Current;
                DemandCurveData.WetBulbTemperature = DemandCurveInputData.WetBlubTemperatureDataValue.Current;
                DemandCurveData.WaterAirRatio = DemandCurveInputData.WaterAirFlowRateDataValue.Current;

                table = DemandCurveCalculationLibrary.DemandCurveCalculation(DemandCurveData);

                if (table != null)
                {
                    // Create a DataView using the DataTable.
                    DataView view = new DataView(table);

                    // Set a DataGrid control's DataSource to the DataView.
                    DemandCurveGridView.DataSource = view;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(string.Format("Error in calculation. Please check your input values. Exception Message: {0}", exception.Message), "DemandCurve Calculation Error");
            }
        }

        private void DemandCurveElevationRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (DemandCurveElevationRadio.Checked)
            {
                SwitchElevationPressure();
                CalculateDemandCurve();
            }
        }

        private void DemandCurvePressureRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (DemandCurvePressureRadio.Checked)
            {
                SwitchElevationPressure();
                CalculateDemandCurve();
            }
        }

        private void UnitedStatesCustomaryUnits_IP__CheckedChanged(object sender, EventArgs e)
        {
            if (UnitedStatesCustomaryUnits_IP_.Checked)
            {
                SwitchUnitedStatesCustomaryUnits_IP_InternationalSystemOfUnits_IS_();
                CalculateDemandCurve();
            }
        }

        private void InternationalSystemOfUnits_IS__CheckedChanged(object sender, EventArgs e)
        {
            if (InternationalSystemOfUnits_IS_.Checked)
            {
                SwitchUnitedStatesCustomaryUnits_IP_InternationalSystemOfUnits_IS_();
                CalculateDemandCurve();
            }
        }

        private void DemandCurveCalculate_Click(object sender, EventArgs e)
        {
            CalculateDemandCurve();
        }
    }
}
