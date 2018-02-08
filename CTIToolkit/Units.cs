using System;
using System.Data;

namespace CTIToolkit
{
    public static class ConstantUnits
    {
        public static readonly string Merkel = "KaV/L = %.5f";
        public static readonly string Foot = "ft";
        public static readonly string Meter = "m";
        public static readonly string BarometricPressureKiloPascal = "kPa";
        public static readonly string BarometricPressureInchOfMercury = "\"Hg";
        public static readonly string TemperatureCelsius = "°C";
        public static readonly string TemperatureFahrenheit = "°F";
        public static readonly string Percentage = "%";
        public static readonly string KilojoulesPerKilogram = "kJ/kg";
        public static readonly string BtuPerPound = "BTU/lbm";

    }

    public class Units
    {
        public string BarometricPressure = string.Empty;
        public string Temperature = string.Empty;
        public string Enthalpy = string.Empty;
        public string Density = string.Empty;
        public string SpecificVolume = string.Empty;
        public string HumidityRatio = string.Empty;

    }

    public class UnitsIP : Units
    {
        public UnitsIP(bool isDemo = false)
        {
            // BarometricPressureMinimum = UnitConverter.ConvertElevationToPsi(ElevationMinimum);
            //BarometricPressureMaximum = UnitConverter.ConvertElevationToPsi(ElevationMaximum);

            BarometricPressure = ConstantUnits.BarometricPressureInchOfMercury;
            Temperature = ConstantUnits.TemperatureFahrenheit;
            Enthalpy = "BTU mixture/lbm dry air";
            Density = "lbm mixture/ft³";
            SpecificVolume = "ft³/lbm dry air";
            HumidityRatio = "lbm water/lbm dry air";
        }
    }

    public class UnitsSI : Units
    {
        public UnitsSI()
        {
            BarometricPressure = ConstantUnits.BarometricPressureKiloPascal;
            Temperature = ConstantUnits.TemperatureCelsius;
            Enthalpy = "kJ mixture/kg dry air";
            Density = "kg mixture/m³";
            SpecificVolume = "m³/kg dry air";
            HumidityRatio = "kg water/kg dry air";
        }
    }
}
