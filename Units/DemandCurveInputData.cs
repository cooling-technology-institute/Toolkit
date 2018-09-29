using System;
using System.Data;
using System.Text;

namespace ToolkitLibrary
{
    //Hot Water Temperature HWT
    //Cold Water Temperature CWT
    //Wet Bulb Temperature WBT
    //Water Flow Rate L
    //Air Flow Rate G
    public class DemandCurveInputData
    {
        public PsychrometricsCalculationType CalculationType { get; set; }
        public bool IsDemo { get; set; }
        public bool IsInternationalSystemOfUnits_IS { get; set; }
        public bool IsElevation { get; set; }

        public WetBlubTemperatureDataValue WetBlubTemperatureDataValue { get; set; }
        public RangeDataValue RangeDataValue { get; set; }
        public ElevationDataValue ElevationDataValue { get; set; }
        public WaterAirFlowRateDataValue WaterAirFlowRateDataValue { get; set; }
        public BarometricPressureDataValue BarometricPressureDataValue { get; set; }

        public DemandCurveInputData(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_IS = IsInternationalSystemOfUnits_IS;
            IsElevation = true;

            RangeDataValue = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            WetBlubTemperatureDataValue = new WetBlubTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            ElevationDataValue = new ElevationDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            WaterAirFlowRateDataValue = new WaterAirFlowRateDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            BarometricPressureDataValue = new BarometricPressureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
        }

        public bool ConvertValues(bool isIS, bool isElevation)
        {
            bool isChanged = false;

            if (IsInternationalSystemOfUnits_IS != isIS)
            {
                IsInternationalSystemOfUnits_IS = isIS;
                WaterAirFlowRateDataValue.ConvertValue(IsInternationalSystemOfUnits_IS, true);
                ElevationDataValue.ConvertValue(IsInternationalSystemOfUnits_IS, true);
                WetBlubTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_IS, true);
                BarometricPressureDataValue.ConvertValue(IsInternationalSystemOfUnits_IS, true);
                isChanged = true;
            }

            if (IsElevation != isElevation)
            {
                IsElevation = isElevation;

                double value = 0.0;
                string message;
                if (IsElevation)
                {
                    if (IsInternationalSystemOfUnits_IS)
                    {
                        value = UnitConverter.ConvertKilopascalToElevationInMeters(BarometricPressureDataValue.Current);
                    }
                    else
                    {
                        value = UnitConverter.ConvertBarometricPressureToElevationInFeet(BarometricPressureDataValue.Current);
                    }
                    ElevationDataValue.UpdateCurrentValue(value, out message);
                }
                else
                {
                    if (IsInternationalSystemOfUnits_IS)
                    {
                        value = UnitConverter.ConvertElevationInMetersToKilopascal(ElevationDataValue.Current);
                    }
                    else
                    {
                        value = UnitConverter.CalculatePressureFahrenheit(UnitConverter.ConvertElevationInFeetToBarometricPressure(ElevationDataValue.Current));
                    }
                    BarometricPressureDataValue.UpdateCurrentValue(value, out message);
                }

                isChanged = true;
            }

            return isChanged;
        }

        public void SetElevation(bool value)
        {
            IsElevation = value;
        }

        public void SetDemo(bool value)
        {
            IsDemo = value;
        }
    }
}