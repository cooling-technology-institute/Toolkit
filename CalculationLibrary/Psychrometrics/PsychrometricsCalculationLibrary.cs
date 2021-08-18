// Copyright Cooling Technology Institute 2019-2021

using Models;
using System.Text;

namespace CalculationLibrary
{
    public class PsychrometricsCalculationLibrary : CalculationLibrary
    {
        public bool PsychrometricsCalculation(PsychrometricsCalculationType calculationType, PsychrometricsData data, out string errorMessage)
        {
            CalculatePressurePSI(data);

            switch (calculationType)
            {
                case PsychrometricsCalculationType.WetBulbTemperature_DryBulbTemperature:
                    Psychrometrics_WetBulbTemperature_DryBulbTemperature_Calculation(data);
                    break;

                case PsychrometricsCalculationType.DryBulbTemperature_RelativeHumidity:
                    Psychrometrics_DryBulbTemperature_RelativeHumidity_Calculation(data);
                    break;

                case PsychrometricsCalculationType.Enthalpy:
                    Psychrometrics_Enthalpy_Calculation(data);
                    break;

                default:
                    errorMessage = "Calculation Type is invalid";
                    return false;
            }

            return Psychrometrics_CheckCalculationValues(calculationType, data, out errorMessage);
        }

        public void Psychrometrics_WetBulbTemperature_DryBulbTemperature_Calculation(PsychrometricsData data)
        {
            CalculateProperties(data);
        }

        public void Psychrometrics_DryBulbTemperature_RelativeHumidity_Calculation(PsychrometricsData data)
        {
            data.WetBulbTemperature = data.RelativeHumidity;
            data.WetBulbTemperature = CalculateWetBulbTemperature(data);

            CalculateProperties(data);
        }

        public void Psychrometrics_Enthalpy_Calculation(PsychrometricsData data)
        {
            EnthalpySearch(true, data);
            CalculateProperties(data);
        }

        public bool Psychrometrics_CheckCalculationValues(PsychrometricsCalculationType calculationType, PsychrometricsData data, out string errorMessage)
        {
            errorMessage = string.Empty;

            if ((data.RelativeHumidity < 0) || (data.Enthalpy < 0) || (data.SpecificVolume < 0) || (data.HumidityRatio < 0))
            {
                StringBuilder sb = new StringBuilder();

                switch (calculationType)
                {
                    case PsychrometricsCalculationType.WetBulbTemperature_DryBulbTemperature:
                        sb.AppendLine("Thermodynamically impossible combination of Wet Bulb Temperature and Dry Bulb Temperature. Check the input values.");
                        break;

                    case PsychrometricsCalculationType.DryBulbTemperature_RelativeHumidity:
                        sb.AppendLine("Thermodynamically impossible combination of Relative Humidity and Dry Bulb Temperature. Check the input values.");
                        break;

                    case PsychrometricsCalculationType.Enthalpy:
                        sb.AppendLine("Thermodynamically impossible combination of Enthalpy and Barometric Pressure. Check the input values.");
                        break;
                }

                if (data.RelativeHumidity < 0)
                {
                    sb.AppendLine(string.Format("Relative Humidity is less than zero. Value: {0}", (data.RelativeHumidity * 100.00).ToString("F2")));
                }
                if (data.Enthalpy < 0)
                {
                    sb.AppendLine(string.Format("Enthalpy is less than zero. Value: {0}", data.Enthalpy.ToString("F4")));
                }
                double maxEnthalpy = (data.IsInternationalSystemOfUnits_SI) ? 6030 : 2758;
                if (data.Enthalpy > maxEnthalpy)
                {
                    sb.AppendLine(string.Format("Enthalpy is out of bounds. Value: {0} Maximum value is: {1}", data.Enthalpy.ToString("F4"), maxEnthalpy.ToString("F4")));
                    data.Enthalpy = -999.0;
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