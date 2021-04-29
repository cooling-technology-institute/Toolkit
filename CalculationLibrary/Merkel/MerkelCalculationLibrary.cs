// Copyright Cooling Technology Institute 2019-2021

using Models;

namespace CalculationLibrary
{
    public class MerkelCalculationLibrary : CalculationLibrary
    {
        public bool MerkelCalculation(MerkelCalculationData data)
        {
            ErrorMessage = string.Empty;
            return CalculateMerkel(data, true);
        }

        public void MerkelConvertValues(MerkelCalculationData data)
        {
            if (data.IsInternationalSystemOfUnits_SI)
            {
                data.WetBulbTemperature = UnitConverter.ConvertCelsiusToFahrenheit(data.WetBulbTemperature);
                data.ColdWaterTemperature = UnitConverter.ConvertCelsiusToFahrenheit(data.ColdWaterTemperature);
                data.HotWaterTemperature = UnitConverter.ConvertCelsiusToFahrenheit(data.HotWaterTemperature);
                if (!data.IsElevation)
                {
                    data.Elevation = UnitConverter.ConvertMetersToFeet(UnitConverter.ConvertKilopascalToElevationInMeters(data.BarometricPressure));
                }
            }
            else
            {
                if (!data.IsElevation)
                {
                    data.Elevation = UnitConverter.ConvertBarometricPressureToElevationInFeet(UnitConverter.CalculateInchesOfMercuryToPsi(data.BarometricPressure));
                }
            }
            data.Range = data.HotWaterTemperature - data.ColdWaterTemperature;
            data.Approach = data.ColdWaterTemperature - data.WetBulbTemperature;
            data.IsInternationalSystemOfUnits_SI = false;
        }
    }
}