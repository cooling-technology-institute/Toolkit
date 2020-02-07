using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationLibrary
{
    public class CalculationVariables
    {
        //public static void CalculateVariablesSI(double p, double temperatureDryBulb, double temperatureWetBulb, ref double PwsDB, ref double PwsWB, ref double FsDB, ref double FsWB)
        // saturation vapor pressure (Pws)
        public double BarometricPressure { get; set; }
        public double WetBulbTemperature { get; set; }
        public double DryBulbTemperature { get; set; }
        public double SaturationVaporPressureWetBulbTemperature { get; set; }
        public double SaturationVaporPressureDryBulbTemperature { get; set; }
        public double FsWetBulbTemperature { get; set; }
        public double FsDryBulbTemperature { get; set; }

        public CalculationVariables()
        {
            BarometricPressure = 0.0;
            WetBulbTemperature = 0.0;
            DryBulbTemperature = 0.0;
            SaturationVaporPressureWetBulbTemperature = 0.0;
            SaturationVaporPressureDryBulbTemperature = 0.0;
            FsWetBulbTemperature = 0.0;
            FsDryBulbTemperature = 0.0;
        }

        public CalculationVariables(PsychrometricsData data)
        {
            BarometricPressure = data.BarometricPressure;
            DryBulbTemperature = data.DryBulbTemperature;
            WetBulbTemperature = data.WetBulbTemperature;
        }
    }
}
