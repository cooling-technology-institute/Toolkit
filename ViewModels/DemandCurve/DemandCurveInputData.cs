// Copyright Cooling Technology Institute 2019-2021

using Models;
using System;
using System.Text;

namespace ViewModels
{
    public class DemandCurveInputData
    {
        public string ErrorMessage { get; set; }
        public bool IsDemo { get; set; }
        public bool IsInternationalSystemOfUnits_SI { get; set; }
        public bool IsElevation { get; set; }
        public bool IsApproach { get; set; }
        public bool IsCoef { get; set; }

        public WetBulbTemperatureDataValue WetBulbTemperatureDataValue { get; set; }
        public RangeDataValue RangeDataValue { get; set; }
        public ElevationDataValue ElevationDataValue { get; set; }
        public LiquidToGasRatioDataValue LiquidToGasRatioDataValue { get; set; }
        public BarometricPressureDataValue BarometricPressureDataValue { get; set; }
        public C1DataValue C1DataValue { get; set; }
        public SlopeDataValue SlopeDataValue { get; set; }
        public MinimumDataValue MinimumDataValue { get; set; }
        public MaximumDataValue MaximumDataValue { get; set; }
        public UserApproachDataValue UserApproachDataValue { get; set; }

        public DemandCurveInputData(bool isDemo, bool isInternationalSystemOfUnits_SI)
        {
            ErrorMessage = string.Empty;

            IsDemo = isDemo;
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;
            IsElevation = true;
            IsApproach = true;
            IsCoef = false;

            WetBulbTemperatureDataValue = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            RangeDataValue = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            ElevationDataValue = new ElevationDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            BarometricPressureDataValue = new BarometricPressureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            C1DataValue = new C1DataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            SlopeDataValue = new SlopeDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            MinimumDataValue = new MinimumDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            MaximumDataValue = new MaximumDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            LiquidToGasRatioDataValue = new LiquidToGasRatioDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            UserApproachDataValue = new UserApproachDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
        }

        public bool ConvertValues(bool isIS, bool isElevation, bool isApproach)
        {
            bool isChanged = false;

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
                //    ElevationDataValue.UpdateCurrentValue(value);
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
                //    BarometricPressureDataValue.UpdateCurrentValue(value);
                //}

                isChanged = true;
            }

            if (IsApproach != isApproach)
            {
                IsApproach = isApproach;

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
                //    ElevationDataValue.UpdateCurrentValue(value);
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
                //    BarometricPressureDataValue.UpdateCurrentValue(value);
                //}

                isChanged = true;
            }

            return isChanged;
        }

        public bool LoadData(DemandCurveFileData data)
        {
            bool returnValue = true;
            StringBuilder stringBuilder = new StringBuilder();

            try
            {
                ConvertValues(data.IsInternationalSystemOfUnits_SI, data.IsElevation, data.IsApproach);

                IsElevation = data.IsElevation;

                if (!WetBulbTemperatureDataValue.UpdateCurrentValue(data.WetBulbTemperature))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(WetBulbTemperatureDataValue.ErrorMessage);
                }

                if (!RangeDataValue.UpdateCurrentValue(data.Range))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(RangeDataValue.ErrorMessage);
                }

                if (!ElevationDataValue.UpdateCurrentValue(data.Elevation))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(ElevationDataValue.ErrorMessage);
                }

                if (!BarometricPressureDataValue.UpdateCurrentValue(data.BarometricPressure))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(BarometricPressureDataValue.ErrorMessage);
                }

                if (!C1DataValue.UpdateCurrentValue(data.CurveC1))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(C1DataValue.ErrorMessage);
                }

                if (!SlopeDataValue.UpdateCurrentValue(data.CurveC2))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(SlopeDataValue.ErrorMessage);
                }

                if (!MinimumDataValue.UpdateCurrentValue(data.CurveMinimum))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(MinimumDataValue.ErrorMessage);
                }

                if (!MaximumDataValue.UpdateCurrentValue(data.CurveMaximum))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(MaximumDataValue.ErrorMessage);
                }

                if (!LiquidToGasRatioDataValue.UpdateCurrentValue(data.LiquidToGasRatio))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(LiquidToGasRatioDataValue.ErrorMessage);
                }
            }
            catch (Exception e)
            {
                ErrorMessage = string.Format("Failure load to data file. Exception: {0}", e.ToString());
                returnValue = false;
            }

            ErrorMessage = stringBuilder.ToString();

            return returnValue;
        }

        public bool FillAndValidate(DemandCurveData data)
        {
            ErrorMessage = string.Empty;

            if(MinimumDataValue.Current >= MaximumDataValue.Current)
            {
                ErrorMessage = "Minimum value must be less than the Maximum value";
                return false;
            }

            data.CurveC1 = C1DataValue.Current;
            data.CurveC2 = SlopeDataValue.Current;
            data.LiquidToGasRatio = LiquidToGasRatioDataValue.Current;
            data.Elevation = ElevationDataValue.Current;
            data.BarometricPressure = BarometricPressureDataValue.Current;
            //data.KaV_L = .Current;
            data.CurveMinimum = MinimumDataValue.Current;
            data.CurveMaximum = MaximumDataValue.Current;
            data.WetBulbTemperature = WetBulbTemperatureDataValue.Current;
            data.Range = RangeDataValue.Current;
            data.IsElevation = IsElevation;
            data.UserApproach = UserApproachDataValue.Current;
            return true;
        }

        public void SetDefaults(DemandCurveFileData demandCurveFileData)
        {
            ErrorMessage = string.Empty;

            if (demandCurveFileData != null)
            {
                demandCurveFileData.IsInternationalSystemOfUnits_SI = IsInternationalSystemOfUnits_SI;
                demandCurveFileData.IsElevation = IsElevation;
                demandCurveFileData.CurveC1 = C1DataValue.Default;
                demandCurveFileData.CurveC2 = SlopeDataValue.Default;
                demandCurveFileData.LiquidToGasRatio = LiquidToGasRatioDataValue.Default;
                demandCurveFileData.Elevation = ElevationDataValue.Default;
                demandCurveFileData.BarometricPressure = BarometricPressureDataValue.Default;
                demandCurveFileData.CurveMinimum = MinimumDataValue.Default;
                demandCurveFileData.CurveMaximum = MaximumDataValue.Default;
                demandCurveFileData.WetBulbTemperature = WetBulbTemperatureDataValue.Default;
                demandCurveFileData.Range = RangeDataValue.Default;
            }
            else
            {
                ErrorMessage = "Create data file.";
            }
        }

        public bool FillFileData(DemandCurveFileData demandCurveFileData)
        {
            ErrorMessage = string.Empty;
            bool returnValue = true;

            try
            {
                demandCurveFileData.IsInternationalSystemOfUnits_SI = IsInternationalSystemOfUnits_SI;
                demandCurveFileData.IsElevation = IsElevation;
                demandCurveFileData.CurveC1 = C1DataValue.Current;
                demandCurveFileData.CurveC2 = SlopeDataValue.Current;
                demandCurveFileData.LiquidToGasRatio = LiquidToGasRatioDataValue.Current;
                demandCurveFileData.Elevation = ElevationDataValue.Current;
                demandCurveFileData.BarometricPressure = BarometricPressureDataValue.Current;
                demandCurveFileData.CurveMinimum = MinimumDataValue.Current;
                demandCurveFileData.CurveMaximum = MaximumDataValue.Current;
                demandCurveFileData.WetBulbTemperature = WetBulbTemperatureDataValue.Current;
                demandCurveFileData.Range = RangeDataValue.Current;
            }
            catch (Exception exception)
            {
                ErrorMessage = string.Format("Failure to fill and validate data file. Exception {0}.", exception.ToString());
            }
            return returnValue;
        }
    }
}