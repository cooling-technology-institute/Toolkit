using System;
using System.Data;
using System.Text;

namespace ToolkitLibrary
{
    public class DemandCurveInputData
    {
        public PsychrometricsCalculationType CalculationType { get; set; }
        public bool IsDemo { get; set; }
        public bool IsInternationalSystemOfUnits_IS { get; set; }
        public bool IsElevation { get; set; }

        public WetBulbTemperatureDataValue WetBulbTemperatureDataValue { get; set; }
        public RangeDataValue RangeDataValue { get; set; }
        public ElevationDataValue ElevationDataValue { get; set; }
        public LiquidToGasRatioRateDataValue LiquidToGasRatioRateDataValue { get; set; }
        public BarometricPressureDataValue BarometricPressureDataValue { get; set; }
        public C1DataValue C1DataValue { get; set; }
        public SlopeDataValue SlopeDataValue { get; set; }
        public MinimumDataValue MinimumDataValue { get; set; }
        public MaximumDataValue MaximumDataValue { get; set; }

        public DemandCurveInputData(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_IS = isInternationalSystemOfUnits_IS_;
            IsElevation = true;

            WetBulbTemperatureDataValue = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            RangeDataValue = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            ElevationDataValue = new ElevationDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            BarometricPressureDataValue = new BarometricPressureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            C1DataValue = new C1DataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            SlopeDataValue = new SlopeDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            MinimumDataValue = new MinimumDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            MaximumDataValue = new MaximumDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            LiquidToGasRatioRateDataValue = new LiquidToGasRatioRateDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
        }

        public bool ConvertValues(bool isIS, bool isElevation)
        {
            bool isChanged = false;

            if (IsInternationalSystemOfUnits_IS != isIS)
            {
                IsInternationalSystemOfUnits_IS = isIS;
                LiquidToGasRatioRateDataValue.ConvertValue(IsInternationalSystemOfUnits_IS, true);
                ElevationDataValue.ConvertValue(IsInternationalSystemOfUnits_IS, true);
                WetBulbTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_IS, true);
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