using System;
using System.Data;

namespace CTIToolkit
{
    public class DefaultValues
    {
        //#define WBT_MIN_IP					   (0.0)
        //#define WBT_MAX_IP					 (200.0)
        //#define WBT_MIN_SI					 (-18.0)
        //#define WBT_MAX_SI					  (93.0)
        //#define DBT_MIN_IP					   (0.0)
        //#define DBT_MAX_IP					 (200.0)
        //#define DBT_MIN_SI				 	 (-18.0)
        //#define DBT_MAX_SI					  (93.0)

        public double MinimumTemperature = 0.0;
        public double MaximumTemperature = 200.0;

        public const double MinimumBulbTemperature = 0.0;
        public const double MaximumBulbTemperature = 200.0;

        public const double MinimumBulbTemperatureMetric = -18.0;
        public const double MaximumBulbTemperatureMetric = 93.0;

        public const double DemoMinimumBulbTemperature = 80.0;
        public const double DemoMaximumBulbTemperature = 100.0;

        public const double DemoMinimumBulbTemperatureMetric = 26.67;
        public const double DemoMaximumBulbTemperatureMetric = 37.78;

        public const double DefaultWetBulbTemperature = 26.67;
        public const double DefaultDryBulbTemperature = 37.78;

        public const double DefaultWetBulbTemperatureMetric = 26.67;
        public const double DefaultDryBulbTemperatureMetric = 37.78;

        public const double MinimumAltitude = -1000.00;
        public const double MaximumAltitude = 40000.00;
        public const double MinimumAltitudeMetric = -300.00;
        public const double MaximumAltitudeMetric = 12200.00;
        public const double DefaultAltitude = 0.0;

        public const double MinimumRelativeHumitity = 0.0;
        public const double MaximumRelativeHumitity = 100.0;
        public const double DefaultRelativeHumidity = 42.38;

        public const double MinimumEnthalpy = 0.0;
        public const double MaximumEnthalpy = 2758;
        public const double DefaultEnthalpy = 43.46;

        public const double MinimumBarometricPressure = 5.0;
        public const double MaximumBarometricPressure = 31.5;
        public const double MinimumBarometricPressureMetric = 16.932;
        public const double MaximumBarometricPressureMetric = 103.285;
        public const double DefaultBarometricPressure = 43.46;
        public const double DefaultBarometricPressureMetric = 43.46;
    }

    public class Units
    {
        public string Merkel = "KaV/L = %.5f";
        public string Foot = "ft";
        public string Percent = "%";

        //#define WBT_MIN_IP					   (0.0)
        //#define WBT_MAX_IP					 (200.0)
        //#define WBT_MIN_SI					 (-18.0)
        //#define WBT_MAX_SI					  (93.0)
        //#define DBT_MIN_IP					   (0.0)
        //#define DBT_MAX_IP					 (200.0)
        //#define DBT_MIN_SI				 	 (-18.0)
        //#define DBT_MAX_SI					  (93.0)

        public double MinimumTemperature = 0.0;
        public double MaximumTemperature = 0.0;

        public double MinimumAltitude = 0.0;
        public double MaximumAltitude = 0.0;

        public double MinimumRelativeHumitity = 0.0;
        public double MaximumRelativeHumitity = 100.0;

        public double MinimumEnthalpy = DefaultValues.MinimumEnthalpy;
        public double MaximumEnthalpy = DefaultValues.MaximumEnthalpy;

        public double MinimumBarometricPressure = DefaultValues.MinimumBarometricPressure;
        public double MaximumBarometricPressure = DefaultValues.MaximumBarometricPressure;

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
            if (isDemo)
            {
                MinimumTemperature = DefaultValues.DemoMinimumBulbTemperature;
                MaximumTemperature = DefaultValues.DemoMaximumBulbTemperature;
            }
            else
            {
                MinimumTemperature = DefaultValues.MinimumBulbTemperature;
                MaximumTemperature = DefaultValues.MaximumBulbTemperature;
            }

            MinimumAltitude = DefaultValues.MinimumAltitude;
            MaximumAltitude = DefaultValues.MaximumAltitude;

            MinimumBarometricPressure = UnitConverter.ConvertAltitudeToPsi(MinimumAltitude);
            MaximumBarometricPressure = UnitConverter.ConvertAltitudeToPsi(MaximumAltitude);

            MinimumRelativeHumitity = DefaultValues.MinimumRelativeHumitity;
            MaximumRelativeHumitity = DefaultValues.MaximumRelativeHumitity;

            BarometricPressure = "mmHg";
            Temperature = "°F";
            Enthalpy = "BTU mixture/lbm dry air";
            Density = "lbm mixture/ft³";
            SpecificVolume = "ft³/lbm dry air";
            HumidityRatio = "lbm water/lbm dry air";
        }
    }

    public class UnitsSI : Units
    {
        public UnitsSI(bool isDemo = false)
        {
            if (isDemo)
            {
                MinimumTemperature = DefaultValues.DemoMinimumBulbTemperatureMetric;
                MaximumTemperature = DefaultValues.DemoMaximumBulbTemperatureMetric;
            }
            else
            {
                MinimumTemperature = DefaultValues.MinimumBulbTemperatureMetric;
                MaximumTemperature = DefaultValues.MaximumBulbTemperatureMetric;
            }

            MinimumAltitude = DefaultValues.MinimumAltitudeMetric;
            MaximumAltitude = DefaultValues.MaximumAltitudeMetric;

            MinimumBarometricPressure = UnitConverter.ConvertAltitudeToKilopascal(MinimumAltitude);
            MaximumBarometricPressure = UnitConverter.ConvertAltitudeToKilopascal(MaximumAltitude);

            MinimumRelativeHumitity = DefaultValues.MinimumRelativeHumitity;
            MaximumRelativeHumitity = DefaultValues.MaximumRelativeHumitity;

            BarometricPressure = "kPa";
            Temperature = "°C";
            Enthalpy = "kJ mixture/kg dry air";
            Density = "kg mixture/m³";
            SpecificVolume = "m³/kg dry air";
            HumidityRatio = "kg water/kg dry air";
        }
    }
}
