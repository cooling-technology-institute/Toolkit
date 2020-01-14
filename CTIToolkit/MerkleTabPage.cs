using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ToolkitLibrary;

namespace CTIToolkit
{
    public partial class MerkelTabPage: UserControl
    {
        const int ELEVATION = 0;
        const int PRESSURE = 1;

        private MerkelInputData MerkelInputData { get; set; }
        private MerkelData MerkelData { get; set; }
        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_IS_ { get; set; }

        public MerkelTabPage(ApplicationSettings applicationSettings)
        {
            InitializeComponent();

            IsInternationalSystemOfUnits_IS_ = (applicationSettings.UnitsSelection == UnitsSelection.International_System_Of_Units_SI);

            MerkelInputData = new MerkelInputData(IsDemo, IsInternationalSystemOfUnits_IS_);

            Setup();

            CalculateMerkel();

        }

        private void Setup()
        {
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

            Merkle_Elevation_Pressure_Selector.SelectedIndex = ELEVATION;
        }

        public void SetUnitsStandard(ApplicationSettings applicationSettings)
        {
            IsInternationalSystemOfUnits_IS_ = (applicationSettings.UnitsSelection == UnitsSelection.International_System_Of_Units_SI);
            SwitchUnitedStatesCustomaryUnits_IP_InternationalSystemOfUnits_IS_();
        }

        private void SwitchUnitedStatesCustomaryUnits_IP_InternationalSystemOfUnits_IS_()
        {
            if (MerkelInputData.ConvertValues(IsInternationalSystemOfUnits_IS_, (Merkle_Elevation_Pressure_Selector.SelectedIndex == ELEVATION)))
            {
                SwitchCalculation();
            }

            if (IsInternationalSystemOfUnits_IS_)
            {
                if (Merkle_Elevation_Pressure_Selector.SelectedIndex == ELEVATION)
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
                if (Merkle_Elevation_Pressure_Selector.SelectedIndex == ELEVATION)
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
            //string message;

            if (MerkelInputData.ConvertValues(IsInternationalSystemOfUnits_IS_, (Merkle_Elevation_Pressure_Selector.SelectedIndex == ELEVATION)))
            {
                SwitchCalculation();
            }

            if (Merkle_Elevation_Pressure_Selector.SelectedIndex == ELEVATION)
            {
                //double value = 0.0;
                //if (double.TryParse(Merkel_Elevation_Value.Text, out value))
                //{
                //    if (IsInternationalSystemOfUnits_IS_)
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
                //    value = MerkelInputData.ElevationDataValue.Default;
                //}
                //MerkelInputData.BarometricPressureDataValue.UpdateValue(value.ToString(), out message);
                //Merkel_Elevation_Value.Text = MerkelInputData.ElevationDataValue.InputValue;
                //MerkelElevationPressureLabel.Text = MerkelInputData.ElevationDataValue.InputMessage + ":";
                if (IsInternationalSystemOfUnits_IS_)
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
                //double value = 0.0;
                //if (double.TryParse(Merkel_Elevation_Value.Text, out value))
                //{
                //   if (IsInternationalSystemOfUnits_IS_)
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
                //    value = MerkelInputData.BarometricPressureDataValue.Default;
                //}
                //MerkelInputData.BarometricPressureDataValue.UpdateValue(value.ToString(), out message);
                //Merkel_Elevation_Value.Text = MerkelInputData.BarometricPressureDataValue.InputValue;
                //MerkelElevationPressureLabel.Text = MerkelInputData.BarometricPressureDataValue.InputMessage + ":";
                if (IsInternationalSystemOfUnits_IS_)
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


            if (Merkle_Elevation_Pressure_Selector.SelectedIndex == ELEVATION)
            {
                Merkel_Elevation_Value.Text = MerkelInputData.ElevationDataValue.InputValue;
                if (IsInternationalSystemOfUnits_IS_)
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
                Merkel_Elevation_Value.Text = MerkelInputData.BarometricPressureDataValue.InputValue;
                if (IsInternationalSystemOfUnits_IS_)
                {
                    MerkelElevationPressureUnits.Text = ConstantUnits.BarometricPressureKiloPascal;
                }
                else
                {
                    MerkelElevationPressureUnits.Text = ConstantUnits.BarometricPressureInchOfMercury;
                }
            }

            if (IsInternationalSystemOfUnits_IS_)
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
                MerkelData = new MerkelData(IsInternationalSystemOfUnits_IS_);

                // clear data set
                if (MerkelGridView.DataSource != null)
                {
                    MerkelGridView.DataSource = null;
                }

                DataTable table = null;

                string message = string.Empty;

                if (Merkle_Elevation_Pressure_Selector.SelectedIndex == ELEVATION)
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

                if (Merkle_Elevation_Pressure_Selector.SelectedIndex == ELEVATION)
                {
                    MerkelData.Elevation = MerkelInputData.ElevationDataValue.Current;
                }
                else
                {
                    MerkelData.BarometricPressure = MerkelInputData.BarometricPressureDataValue.Current;
                }

                MerkelData.IsElevation = (Merkle_Elevation_Pressure_Selector.SelectedIndex == ELEVATION);
                MerkelData.SetInternationalSystemOfUnits_IS_(IsInternationalSystemOfUnits_IS_);

                MerkelData.HotWaterTemperature = MerkelInputData.HotWaterTemperatureDataValue.Current;
                MerkelData.ColdWaterTemperature = MerkelInputData.ColdWaterTemperatureDataValue.Current;
                MerkelData.WetBulbTemperature = MerkelInputData.WetBlubTemperatureDataValue.Current;
                MerkelData.WaterAirRatio = MerkelInputData.WaterAirFlowRateDataValue.Current;

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
                MessageBox.Show(string.Format("Error in Merkel calculation. Please check your input values. Exception Message: {0}", exception.Message), "Merkel Calculation Error");
            }
        }

        private void MerkelCalculate_Click(object sender, EventArgs e)
        {
            CalculateMerkel();
        }

        private void Merkle_Elevation_Pressure_Selector_SelectedIndexChanged(object sender, EventArgs e)
        {
            SwitchElevationPressure();
            CalculateMerkel();
        }
    }
}
