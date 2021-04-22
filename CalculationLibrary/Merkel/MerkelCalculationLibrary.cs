// Copyright Cooling Technology Institute 2019-2021

using Models;

namespace CalculationLibrary
{
    public class MerkelCalculationLibrary : CalculationLibrary
    {
        public bool MerkelCalculation(MerkelCalculationData data)
        {
            ErrorMessage = string.Empty;
            return CalculateMerkel(data);
        }

        public void MerkelConvertValues(bool isInternationalSystemOfUnits_IS_, bool isElevation, MerkelCalculationData data)
        {
            if (isInternationalSystemOfUnits_IS_)
            {
                data.WetBulbTemperature = UnitConverter.ConvertCelsiusToFahrenheit(data.WetBulbTemperature);
                data.ColdWaterTemperature = UnitConverter.ConvertCelsiusToFahrenheit(data.ColdWaterTemperature);
                data.HotWaterTemperature = UnitConverter.ConvertCelsiusToFahrenheit(data.HotWaterTemperature);

                if (!isElevation)
                {
                    data.Elevation = UnitConverter.ConvertMetersToFeet(UnitConverter.ConvertKilopascalToElevationInMeters(data.BarometricPressure));
                }
            }
            else
            {
                if (!isElevation)
                {
                    data.Elevation = UnitConverter.ConvertBarometricPressureToElevationInFeet(UnitConverter.CalculateInchesOfMercuryToPsi(data.BarometricPressure));
                }
            }

            data.IsInternationalSystemOfUnits_SI = false;
        }
    }
}