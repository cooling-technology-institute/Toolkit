// Copyright Cooling Technology Institute 2019-2021

using CalculationLibrary;
using Models;
using System;
using System.Text;

namespace ViewModels
{
    //Hot Water Temperature HWT
    //Cold Water Temperature CWT
    //Wet Bulb Temperature WBT
    //Water Flow Rate L
    //Air Flow Rate G
    public class MerkelInputData
    {
        public PsychrometricsCalculationType CalculationType { get; set; }
        public bool IsDemo { get; set; }
        public bool IsInternationalSystemOfUnits_SI { get; set; }
        public bool IsElevation { get; set; }
        public string ErrorMessage { get; set; }

        public HotWaterTemperatureDataValue HotWaterTemperatureDataValue { get; set; }
        public ColdWaterTemperatureDataValue ColdWaterTemperatureDataValue { get; set; }
        public WetBulbTemperatureDataValue WetBulbTemperatureDataValue { get; set; }
        public ElevationDataValue ElevationDataValue { get; set; }
        public LiquidToGasRatioDataValue LiquidToGasRatioDataValue { get; set; }
        public BarometricPressureDataValue BarometricPressureDataValue { get; set; }

        public MerkelInputData(bool isDemo, bool isInternationalSystemOfUnits_SI)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;
            IsElevation = true;
            ErrorMessage = string.Empty;
            HotWaterTemperatureDataValue = new HotWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            ColdWaterTemperatureDataValue = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            WetBulbTemperatureDataValue = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            ElevationDataValue = new ElevationDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            LiquidToGasRatioDataValue  = new LiquidToGasRatioDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            BarometricPressureDataValue = new BarometricPressureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
        }

        public void ConvertValues(bool isIS)
        {
            IsInternationalSystemOfUnits_SI = isIS;
            HotWaterTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
            ColdWaterTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
            LiquidToGasRatioDataValue .ConvertValue(IsInternationalSystemOfUnits_SI);
            ElevationDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
            WetBulbTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
            BarometricPressureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);

            double value;

            if (IsElevation)
            {
                if (IsInternationalSystemOfUnits_SI)
                {
                    value = UnitConverter.ConvertKilopascalToElevationInMeters(BarometricPressureDataValue.Current);
                }
                else
                {
                    value = UnitConverter.ConvertBarometricPressureToElevationInFeet(UnitConverter.CalculateInchesOfMercuryToPsi(BarometricPressureDataValue.Current));
                }
                ElevationDataValue.UpdateCurrentValue(value, out string errorMessage);
            }
            else
            {
                if (IsInternationalSystemOfUnits_SI)
                {
                    value = UnitConverter.ConvertElevationInMetersToKilopascal(ElevationDataValue.Current);
                }
                else
                {
                    value = UnitConverter.CalculatePsiToInchesOfMercury(UnitConverter.ConvertElevationInFeetToBarometricPressure(ElevationDataValue.Current));
                }
                BarometricPressureDataValue.UpdateCurrentValue(value, out string errorMessage);
            }
        }

        public void FillMerkelData(MerkelCalculationData data)
        {
            data.HotWaterTemperature = HotWaterTemperatureDataValue.Current;
            data.ColdWaterTemperature = ColdWaterTemperatureDataValue.Current;
            data.WetBulbTemperature = WetBulbTemperatureDataValue.Current;
            data.Elevation = ElevationDataValue.Current;
            data.LiquidToGasRatio = LiquidToGasRatioDataValue .Current;
            data.BarometricPressure = BarometricPressureDataValue.Current;
        }

        public bool LoadData(MerkelDataFile merkelDataFile)
        {
            bool returnValue = true;
            ErrorMessage = string.Empty;
            StringBuilder stringBuilder = new StringBuilder();
            

            if (merkelDataFile != null)
            {
                ConvertValues(merkelDataFile.IsInternationalSystemOfUnits_SI);

                IsElevation = merkelDataFile.IsElevation;
                IsInternationalSystemOfUnits_SI = merkelDataFile.IsInternationalSystemOfUnits_SI;

                if (!ElevationDataValue.UpdateCurrentValue(merkelDataFile.Elevation, out string errorMessage))
                {
                    stringBuilder.AppendLine(errorMessage);
                    errorMessage = string.Empty;
                    returnValue = false;
                }
                if (!BarometricPressureDataValue.UpdateCurrentValue(merkelDataFile.BarometricPressure, out errorMessage))
                {
                    stringBuilder.AppendLine(errorMessage);
                    errorMessage = string.Empty;
                    returnValue = false;
                }
                if (!WetBulbTemperatureDataValue.UpdateCurrentValue(merkelDataFile.WetBulbTemperature, out errorMessage))
                {
                    stringBuilder.AppendLine(errorMessage);
                    errorMessage = string.Empty;
                    returnValue = false;
                }
                if (!HotWaterTemperatureDataValue.UpdateCurrentValue(merkelDataFile.HotWaterTemperature, out errorMessage))
                {
                    stringBuilder.AppendLine(errorMessage);
                    errorMessage = string.Empty;
                    returnValue = false;
                }
                if (!ColdWaterTemperatureDataValue.UpdateCurrentValue(merkelDataFile.ColdWaterTemperature, out errorMessage))
                {
                    stringBuilder.AppendLine(errorMessage);
                    errorMessage = string.Empty;
                    returnValue = false;
                }
                if (!LiquidToGasRatioDataValue.UpdateCurrentValue(merkelDataFile.LiquidToGasRatio, out errorMessage))
                {
                    stringBuilder.AppendLine(errorMessage);
                    errorMessage = string.Empty;
                    returnValue = false;
                }

                if (!returnValue)
                {
                    ErrorMessage = stringBuilder.ToString();
                }
            }
            else
            {
                ErrorMessage = "Unable to load data file.";
                returnValue = false;
            }

            return returnValue;
        }

        public void SetDefaults(MerkelDataFile merkelDataFile)
        {
            ErrorMessage = string.Empty;

            if (merkelDataFile != null)
            {
                merkelDataFile.IsElevation = IsElevation;
                merkelDataFile.IsInternationalSystemOfUnits_SI = IsInternationalSystemOfUnits_SI;
                merkelDataFile.Elevation = ElevationDataValue.Default;
                merkelDataFile.BarometricPressure = BarometricPressureDataValue.Default;
                merkelDataFile.WetBulbTemperature = WetBulbTemperatureDataValue.Default;
                merkelDataFile.HotWaterTemperature = HotWaterTemperatureDataValue.Default;
                merkelDataFile.ColdWaterTemperature = ColdWaterTemperatureDataValue.Default;
                merkelDataFile.LiquidToGasRatio = LiquidToGasRatioDataValue.Default;
            }
            else
            {
                ErrorMessage = "Create data file.";
            }
        }

        public bool FillFileData(MerkelDataFile merkelDataFile)
        {
            ErrorMessage = string.Empty;
            bool returnValue = true;

            try
            {
                merkelDataFile.IsElevation = IsElevation;
                merkelDataFile.IsInternationalSystemOfUnits_SI = IsInternationalSystemOfUnits_SI;
                merkelDataFile.Elevation = ElevationDataValue.Current;
                merkelDataFile.BarometricPressure = BarometricPressureDataValue.Current;
                merkelDataFile.WetBulbTemperature = WetBulbTemperatureDataValue.Current;
                merkelDataFile.HotWaterTemperature = HotWaterTemperatureDataValue.Current;
                merkelDataFile.ColdWaterTemperature = ColdWaterTemperatureDataValue.Current;
                merkelDataFile.LiquidToGasRatio = LiquidToGasRatioDataValue.Current;
            }
            catch (Exception exception)
            {
                ErrorMessage = string.Format("Failure to fill and validate data file. Exception {0}.", exception.ToString());
            }
            return returnValue;
        }
    }
}