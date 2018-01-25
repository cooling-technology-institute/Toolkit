using System;

namespace CTIToolkit
{
    public class UnitConverter
    {
        // Acyronms
        // LS = Liters Per Second
        // GPM = Gallon Per Minute
        // BPM = Brake Horsepower
        // KW = Kilowatts
        // BP = Barometric Pressure
        // KPA = Kilopascal
        // IP = Ionization Potential 
        const double SeaLevelBasePressure = 14.696;
        const double MeterFeetConversionFactor = 0.3048;
        const double AltitudeConversionFactor = 6.87535E-06;
        const double AltitudePowerFactor = 5.2561;
        const double CelsiusToFahrenheitAdjustment = 32.0;
        const double CelsiusToFahrenheitConversionFactor = 1.8;
        const double GallonToLiterConversionFactor = 3.785411784;
        const double GallonPerMinuteToLitersPerSecondConversionFactor = 0.0630902;
        const double BrakeHorsepowerToKilowattsConversionFactor = 0.7457;
        const double BarometricPressure = 29.921;
        const double OneAtmosphere = 101.325;

        // Conversion Methods
        public static double ConvertAltitudeToPsi(double altitude)
        {
            double psi = SeaLevelBasePressure * Math.Pow((1.0 - (AltitudeConversionFactor * altitude)), AltitudePowerFactor);
            return psi;
        }

        public static double ConvertPsiToAltitude(double psi)
        {
            double altitude = (Math.Exp (Math.Log(psi / SeaLevelBasePressure) / AltitudePowerFactor) - 1.0) / AltitudeConversionFactor * -1.0;
            return altitude;
        }

        public static double ConvertAltitudeToKilopascal(double altitude)
        {
            return OneAtmosphere * Math.Pow((1.0 - (AltitudeConversionFactor * ConvertMetersToFeet(altitude))), AltitudePowerFactor);
        }

        public static double ConvertKilopascalToAltitude(double kilopascal)
        {
            return ConvertFeetToMeters((Math.Exp(Math.Log(kilopascal / OneAtmosphere) / AltitudePowerFactor) - 1.0) / (AltitudeConversionFactor * -1.0));
        }

        public static double ConvertPsiToKilopascal(double psi)
        {
            return OneAtmosphere * psi / SeaLevelBasePressure;
        }

        public static double ConvertKilopascalToPsi(double kilopascal)
        {
            return (kilopascal * SeaLevelBasePressure) / OneAtmosphere;
        }

        public static double CalculatePressureCelcius(double pressure)
        {
            return (pressure / BarometricPressure) * SeaLevelBasePressure;
        }

        public static double CalculatePressureFahrenheit(double pressure)
        {
            return (pressure / SeaLevelBasePressure) * BarometricPressure;
        }

        public static double ConvertCelsiusToFahrenheit(double celsiusTemperature)
        {
            return celsiusTemperature * CelsiusToFahrenheitConversionFactor + CelsiusToFahrenheitAdjustment;
        }

        public static double ConvertFahrenheitToCelsius(double fahrenheitTemperature)
        {
            return (fahrenheitTemperature - CelsiusToFahrenheitAdjustment) / CelsiusToFahrenheitConversionFactor;
        }

        public static double ConvertFeetToMeters(double meters)
        {
            return meters * MeterFeetConversionFactor;
        }

        public static double ConvertMetersToFeet(double feet)
        {
            return feet / MeterFeetConversionFactor;
        }

        public static double ConvertBrakeHorsepowerToKilowatts(double brakeHorsepower)
        {
            return brakeHorsepower * BrakeHorsepowerToKilowattsConversionFactor;
        }

        public static double ConvertKilowattsToBrakeHorsepower(double kilowatts)
        {
            return kilowatts / BrakeHorsepowerToKilowattsConversionFactor;
        }

        public static double ConvertGallonsToLiters(double gallons)
        {
            return gallons * GallonToLiterConversionFactor;
        }

        public static double ConvertLitersToGallons(double liters)
        {
            return liters / GallonToLiterConversionFactor;
        }

        public static double ConvertGallonPerMinuteToLitersPerSecond(double gallonPerMinute)
        {
            return gallonPerMinute * GallonPerMinuteToLitersPerSecondConversionFactor;
        }

        public static double ConvertLitersPerSecondToGallonPerMinute(double litersPerSecond)
        {
            return litersPerSecond / GallonPerMinuteToLitersPerSecondConversionFactor;
        }
    }
}
