// Copyright Cooling Technology Institute 2019-2021

using Models;

namespace ViewModels
{
    public class DemandCurveInputData
    {
        public bool IsDemo { get; set; }
        public bool IsInternationalSystemOfUnits_SI { get; set; }
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
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_IS_;
            IsElevation = true;

            WetBulbTemperatureDataValue = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            RangeDataValue = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            ElevationDataValue = new ElevationDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            BarometricPressureDataValue = new BarometricPressureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            C1DataValue = new C1DataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            SlopeDataValue = new SlopeDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            MinimumDataValue = new MinimumDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            MaximumDataValue = new MaximumDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            LiquidToGasRatioDataValue = new LiquidToGasRatioDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            ApproachDataValue = new ApproachDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
        }

        public bool ConvertValues(bool isIS, bool isElevation, out string errorMessage)
        {
            bool isChanged = false;
            errorMessage = string.Empty;

            if (IsInternationalSystemOfUnits_SI != isIS)
            {
                IsInternationalSystemOfUnits_SI = isIS;
                RangeDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
                LiquidToGasRatioDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
                ElevationDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
                WetBulbTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
                BarometricPressureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
                isChanged = true;
            }

            if (IsElevation != isElevation)
            {
                IsElevation = isElevation;

                //double value = 0.0;
                //if (IsElevation)
                //{
                //    if (IsInternationalSystemOfUnits_SI)
                //    {
                //        value = UnitConverter.ConvertKilopascalToElevationInMeters(BarometricPressureDataValue.Current);
                //    }
                //    else
                //    {
                //        value = UnitConverter.ConvertBarometricPressureToElevationInFeet(BarometricPressureDataValue.Current);
                //    }
                //    ElevationDataValue.UpdateCurrentValue(value, out errorMessage);
                //}
                //else
                //{
                //    if (IsInternationalSystemOfUnits_SI)
                //    {
                //        value = UnitConverter.ConvertElevationInMetersToKilopascal(ElevationDataValue.Current);
                //    }
                //    else
                //    {
                //        value = UnitConverter.CalculatePsiToInchesOfMercury(UnitConverter.ConvertElevationInFeetToBarometricPressure(ElevationDataValue.Current));
                //    }
                //    BarometricPressureDataValue.UpdateCurrentValue(value, out errorMessage);
                //}

                isChanged = true;
            }

            return isChanged;
        }

        public bool FillAndValidate(DemandCurveData data, out string errorMessage)
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