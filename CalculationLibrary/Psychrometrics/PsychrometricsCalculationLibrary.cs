// Copyright Cooling Technology Institute 2019-2020

using Models;
using System.Text;

namespace CalculationLibrary
{
    public class PsychrometricsCalculationLibrary
    {
        public bool PsychrometricsCalculation(PsychrometricsCalculationType calculationType, bool isElevation, PsychrometricsData data, out string errorMessage)
        {
            switch (calculationType)
            {
                case PsychrometricsCalculationType.WetBulbTemperature_DryBulbTemperature:
                    return Psychrometrics_WetBulbTemperature_DryBulbTemperature_Calculation(isElevation, data, out errorMessage);

                case PsychrometricsCalculationType.DryBulbTemperature_RelativeHumidity:
                    return Psychrometrics_DryBulbTemperature_RelativeHumidity_Calculation(isElevation, data, out errorMessage);

                case PsychrometricsCalculationType.Enthalpy:
                    return Psychrometrics_Enthalpy_Calculation(isElevation, data, out errorMessage);

                default:
                    errorMessage = "Calculation Type is invalid";
                    return false;
            }
        }

        public bool Psychrometrics_WetBulbTemperature_DryBulbTemperature_Calculation(bool isElevation, PsychrometricsData data, out string errorMessage)
        {
            if (data.IsInternationalSystemOfUnits_SI)
            {
                if (isElevation)
                {
                    data.BarometricPressure = UnitConverter.ConvertElevationInMetersToKilopascal(data.Elevation);
                }

                CalculationLibrary.CalculateProperties(data);

                if (data.Enthalpy > 6030)
                {
                    data.Enthalpy = -999.0;
                }
            }
            else
            {
                if (isElevation)
                {
                    data.BarometricPressure = UnitConverter.ConvertElevationInFeetToBarometricPressure(data.Elevation);
                }

                CalculationLibrary.CalculateProperties(data);

                if (data.Enthalpy > 2758)
                {
                    data.Enthalpy = -999.0;
                }

                data.BarometricPressure = UnitConverter.CalculatePressureFahrenheit(data.BarometricPressure);
            }

            return Psychrometrics_CheckCalculationValues(data, out errorMessage);
        }

        public bool Psychrometrics_DryBulbTemperature_RelativeHumidity_Calculation(bool isElevation, PsychrometricsData data, out string errorMessage)
        {
            if (isElevation)
            {
                data.BarometricPressure = (data.IsInternationalSystemOfUnits_SI) ? UnitConverter.ConvertElevationInMetersToKilopascal(data.Elevation) : UnitConverter.ConvertElevationInFeetToBarometricPressure(data.Elevation);
            }
            
            data.WetBulbTemperature = CalculationLibrary.CalculateWetBulbTemperature(data.IsInternationalSystemOfUnits_SI, data.BarometricPressure, data.RelativeHumidity / 100, data.DryBulbTemperature);

            CalculationLibrary.CalculateProperties(data);

            if(!data.IsInternationalSystemOfUnits_SI)
            { 
                data.BarometricPressure = UnitConverter.CalculatePressureFahrenheit(data.BarometricPressure);
            }

            return Psychrometrics_CheckCalculationValues(data, out errorMessage);
        }

        public bool Psychrometrics_Enthalpy_Calculation(bool isElevation, PsychrometricsData data, out string errorMessage)
        {
            data.SpecificVolume = -999;
            data.Density = -999;
            data.DewPoint = -999;

            if (isElevation)
            {
                data.BarometricPressure = (data.IsInternationalSystemOfUnits_SI) ? UnitConverter.ConvertElevationInMetersToKilopascal(data.Elevation) : UnitConverter.ConvertElevationInFeetToBarometricPressure(data.Elevation);
            }

            CalculationLibrary.EnthalpySearch(true, data);
            CalculationLibrary.CalculateProperties(data);

            if (!data.IsInternationalSystemOfUnits_SI)
            {
                data.BarometricPressure = UnitConverter.CalculatePressureFahrenheit(data.BarometricPressure);
            }

            return Psychrometrics_CheckCalculationValues(data, out errorMessage);
        }

        public bool Psychrometrics_CheckCalculationValues(PsychrometricsData data, out string errorMessage)
        {
            errorMessage = string.Empty;

            if ((data.RelativeHumidity < 0) || (data.Enthalpy < 0) || (data.SpecificVolume < 0) || (data.HumidityRatio < 0))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Calculation returned invalid data. Check the input values.");
                if (data.RelativeHumidity < 0)
                {
                    sb.AppendLine(string.Format("Relative Humidity is less than zero. Value: {0}", (data.RelativeHumidity * 100.00).ToString("F2")));
                }
                if (data.Enthalpy < 0)
                {
                    sb.AppendLine(string.Format("Enthalpy is less than zero. Value: {0}", data.Enthalpy.ToString("F4")));
                }
                if (data.SpecificVolume < 0)
                {
                    sb.AppendLine(string.Format("Specific Volume is less than zero. Value: {0}", data.SpecificVolume.ToString("F4")));
                }
                if (data.HumidityRatio < 0)
                {
                    sb.AppendLine(string.Format("Humidity Ratio is less than zero. Value: {0}", data.HumidityRatio.ToString("F5")));
                }
                errorMessage = sb.ToString();
            }
            return string.IsNullOrEmpty(errorMessage);
        }
    }
}