// Copyright Cooling Technology Institute 2019-2021

using Models;
using System;
using System.Text;

namespace ViewModels
{
    public class PsychrometricsInputData
    {
        public PsychrometricsCalculationType CalculationType { get; set; }
        public bool IsDemo { get; set; }
        public bool IsInternationalSystemOfUnits_SI { get; set; }
        public bool IsElevation { get; set; }
        public string ErrorMessage { get; set; }

        public EnthalpyDataValue EnthalpyDataValue { get; set; }
        public ElevationDataValue ElevationDataValue { get; set; }
        public BarometricPressureDataValue BarometricPressureDataValue { get; set; }
        public RelativeHumidityDataValue RelativeHumidityDataValue { get; set; }
        public WetBulbTemperatureDataValue WetBulbTemperatureDataValue { get; set; }
        public DryBulbTemperatureDataValue DryBulbTemperatureDataValue { get; set; }

        public PsychrometricsInputData(bool isDemo, bool isInternationalSystemOfUnits_SI)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;
            IsElevation = true;
            ErrorMessage = string.Empty;
            CalculationType = PsychrometricsCalculationType.WetBulbTemperature_DryBulbTemperature;
            EnthalpyDataValue = new EnthalpyDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            ElevationDataValue = new ElevationDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            BarometricPressureDataValue = new BarometricPressureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            RelativeHumidityDataValue = new RelativeHumidityDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            WetBulbTemperatureDataValue = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            DryBulbTemperatureDataValue = new DryBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
        }

        public bool FillAndValidate(PsychrometricsData data, out string errorMessage)
        {
            errorMessage = string.Empty;

            data.IsInternationalSystemOfUnits_SI = IsInternationalSystemOfUnits_SI;
            data.BarometricPressure = BarometricPressureDataValue.Current;
            data.Elevation = ElevationDataValue.Current;
            data.RootEnthalpy = EnthalpyDataValue.Current;
            data.RelativeHumidity = RelativeHumidityDataValue.Current;
            data.WetBulbTemperature = WetBulbTemperatureDataValue.Current;
            data.DryBulbTemperature = DryBulbTemperatureDataValue.Current;
            
            return true;
        }

        public void ConvertValues(bool isInternationalSystemOfUnits_SI)
        {
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;
            EnthalpyDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
            ElevationDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
            BarometricPressureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
            WetBulbTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
            DryBulbTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
        }

        public void SetElevation(bool value)
        {
            IsElevation = value;
        }

        public void SetDemo(bool value)
        {
            IsDemo = value;
        }

        public bool LoadData(PsychrometricsDataFile psychrometricsDataFile)
        {
            bool returnValue = true;
            ErrorMessage = string.Empty;
            StringBuilder stringBuilder = new StringBuilder();

            if (psychrometricsDataFile != null)
            {
                ConvertValues(psychrometricsDataFile.IsInternationalSystemOfUnits_SI);

                CalculationType = psychrometricsDataFile.CalculationType;
                IsElevation = psychrometricsDataFile.IsElevation;
                IsInternationalSystemOfUnits_SI = psychrometricsDataFile.IsInternationalSystemOfUnits_SI;

                if (!EnthalpyDataValue.UpdateCurrentValue(psychrometricsDataFile.Enthalpy))
                {
                    stringBuilder.AppendLine(EnthalpyDataValue.ErrorMessage);
                    returnValue = false;
                }
                if (!ElevationDataValue.UpdateCurrentValue(psychrometricsDataFile.Elevation))
                {
                    stringBuilder.AppendLine(ElevationDataValue.ErrorMessage);
                    returnValue = false;
                }
                if (!BarometricPressureDataValue.UpdateCurrentValue(psychrometricsDataFile.BarometricPressure))
                {
                    stringBuilder.AppendLine(BarometricPressureDataValue.ErrorMessage);
                    returnValue = false;
                }
                if (!RelativeHumidityDataValue.UpdateCurrentValue(psychrometricsDataFile.RelativeHumidity))
                {
                    stringBuilder.AppendLine(RelativeHumidityDataValue.ErrorMessage);
                    returnValue = false;
                }
                if (!WetBulbTemperatureDataValue.UpdateCurrentValue(psychrometricsDataFile.WetBulbTemperature))
                {
                    stringBuilder.AppendLine(WetBulbTemperatureDataValue.ErrorMessage);
                    returnValue = false;
                }
                if (!DryBulbTemperatureDataValue.UpdateCurrentValue(psychrometricsDataFile.DryBulbTemperature))
                {
                    stringBuilder.AppendLine(DryBulbTemperatureDataValue.ErrorMessage);
                    returnValue = false;
                }

                if(!returnValue)
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

        public void SetDefaults(PsychrometricsDataFile psychrometricsDataFile)
        {
            ErrorMessage = string.Empty;

            if (psychrometricsDataFile != null)
            {
                psychrometricsDataFile.IsElevation = IsElevation;
                psychrometricsDataFile.IsInternationalSystemOfUnits_SI = IsInternationalSystemOfUnits_SI;
                psychrometricsDataFile.CalculationType = CalculationType;
                psychrometricsDataFile.Enthalpy = EnthalpyDataValue.Default;
                psychrometricsDataFile.Elevation = ElevationDataValue.Default;
                psychrometricsDataFile.BarometricPressure = BarometricPressureDataValue.Default;
                psychrometricsDataFile.RelativeHumidity = RelativeHumidityDataValue.Default;
                psychrometricsDataFile.WetBulbTemperature = WetBulbTemperatureDataValue.Default;
                psychrometricsDataFile.DryBulbTemperature = DryBulbTemperatureDataValue.Default;
            }
            else
            {
                ErrorMessage = "Create data file.";
            }
        }

        public bool FillFileData(PsychrometricsDataFile psychrometricsDataFile)
        {
            ErrorMessage = string.Empty;
            bool returnValue = true;

            try
            {
                psychrometricsDataFile.IsElevation = IsElevation;
                psychrometricsDataFile.IsInternationalSystemOfUnits_SI = IsInternationalSystemOfUnits_SI;
                psychrometricsDataFile.CalculationType = CalculationType;
                psychrometricsDataFile.Enthalpy = EnthalpyDataValue.Current;
                psychrometricsDataFile.Elevation = ElevationDataValue.Current;
                psychrometricsDataFile.BarometricPressure = BarometricPressureDataValue.Current;
                psychrometricsDataFile.RelativeHumidity = RelativeHumidityDataValue.Current;
                psychrometricsDataFile.WetBulbTemperature = WetBulbTemperatureDataValue.Current;
                psychrometricsDataFile.DryBulbTemperature = DryBulbTemperatureDataValue.Current;
            }
            catch (Exception exception)
            {
                ErrorMessage = string.Format("Failure to fill and validate data file. Exception {0}.", exception.ToString());
            }
            return returnValue;
        }
    }
}