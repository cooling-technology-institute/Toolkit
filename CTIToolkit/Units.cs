using System;
using System.Data;

namespace CTIToolkit
{
    public class Units
    {
        public string Merkel = "KaV/L = %.5f";
        public string Foot = "ft";
        public string Percent = "%";

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
            // BarometricPressureMinimum = UnitConverter.ConvertAltitudeToPsi(AltitudeMinimum);
            //BarometricPressureMaximum = UnitConverter.ConvertAltitudeToPsi(AltitudeMaximum);

            BarometricPressure = "\"Hg";
            Temperature = "°F";
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
            BarometricPressure = "kPa";
            Temperature = "°C";
            Enthalpy = "kJ mixture/kg dry air";
            Density = "kg mixture/m³";
            SpecificVolume = "m³/kg dry air";
            HumidityRatio = "kg water/kg dry air";
        }
    }
}
