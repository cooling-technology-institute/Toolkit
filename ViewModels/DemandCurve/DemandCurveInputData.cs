// Copyright Cooling Technology Institute 2019-2020

using CalculationLibrary;
using Models;

namespace ViewModels
{
    public class DemandCurveInputData
    {
        //public PsychrometricsCalculationType CalculationType { get; set; }
        public bool IsDemo { get; set; }
        public bool IsInternationalSystemOfUnits_IS { get; set; }
        public bool IsElevation { get; set; }

        public WetBulbTemperatureDataValue WetBulbTemperatureDataValue { get; set; }
        public RangeDataValue RangeDataValue { get; set; }
        public ApproachDataValue ApproachDataValue { get; set; }
        public ElevationDataValue ElevationDataValue { get; set; }
        public LiquidToGasRatioDataValue LiquidToGasRatioDataValue { get; set; }
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
            LiquidToGasRatioDataValue = new LiquidToGasRatioDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
        }

        public bool ConvertValues(bool isIS, bool isElevation)
        {
            bool isChanged = false;

            if (IsInternationalSystemOfUnits_IS != isIS)
            {
                IsInternationalSystemOfUnits_IS = isIS;
                LiquidToGasRatioDataValue.ConvertValue(IsInternationalSystemOfUnits_IS, true);
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

        public bool FillDemandCurveData(DemandCurveData data, bool isElevation, bool showUserApproach, out string errorMessage)
        {
            errorMessage = string.Empty;

            if(MinimumDataValue.Current >= MaximumDataValue.Current)
            {
                errorMessage = "Minimum value must be less than the Maximum value";
                return false;
            }

            data.CurveC1 = C1DataValue.Current;
            data.CurveC2 = SlopeDataValue.Current;
            data.LiquidToGasRatio = LiquidToGasRatioDataValue.Current;
            data.Elevation = ElevationDataValue.Current;
            data.LiquidToGasRatio = LiquidToGasRatioDataValue.Current;
            data.BarometricPressure = BarometricPressureDataValue.Current;
            data.KaV_L = BarometricPressureDataValue.Current;
            data.CurveMinimum = MinimumDataValue.Current;
            data.CurveMaximum = MaximumDataValue.Current;
            data.WetBulbTemperature = WetBulbTemperatureDataValue.Current;
            data.Range = RangeDataValue.Current;
            data.Approach = ApproachDataValue.Current;

            return true;
        }
    }
}