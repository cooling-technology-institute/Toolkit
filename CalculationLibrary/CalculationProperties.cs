using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationLibrary
{
    public class CalculationProperties
    {
        //public static void CalculatePropertiesSI(double pressure, double temperatureWetBulb, double temperatureDryBulb, ref double humidityRatio, ref double relativeHumidity, ref double Enthalpy, ref double specificVolume, ref double Density, ref double DEWPoint)

        public bool Saturation { get; set; }
        public double BarometricPressure { get; set; }
        public double WetBulbTemperature { get; set; }
        public double DryBulbTemperature { get; set; }
        public double HumidityRatio { get; set; }
        public double RelativeHumidity { get; set; }
        public double Enthalpy { get; set; }
        public double SpecificVolume { get; set; }
        public double Density { get; set; }
        public double DewPoint { get; set; }
    }
}
