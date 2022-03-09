// Copyright Cooling Technology Institute 2019-2021

using System;

namespace CalculationLibrary
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
        const double ElevationConversionFactor = 6.87535E-06;
        const double ElevationPowerFactor = 5.2561;
        const double CelsiusToFahrenheitAdjustment = 32.0;
        const double CelsiusToFahrenheitConversionFactor = 1.8;
        const double GallonToLiterConversionFactor = 3.785411784;
        const double GallonPerMinuteToLitersPerSecondConversionFactor = 0.0630902;
        const double BrakeHorsepowerToKilowattsConversionFactor = 0.7457;
        const double BarometricPressure = 29.921;
        const double OneAtmosphere = 101.325;
        const double KiloPascalToInchesOfMercuryConversionFactor = 3.386389; // 0.29529980164712 3.38653074866

        // Conversion Methods
        public static double ConvertElevationInFeetToPressurePSI(double elevation)
        {
            double pressure = SeaLevelBasePressure * Math.Pow((1.0 - (ElevationConversionFactor * elevation)), ElevationPowerFactor);
            return pressure;
        }

        public static double ConvertBarometricPressureToPsi(double barometricPressure)
        {
            return SeaLevelBasePressure * barometricPressure / BarometricPressure;
        }

        public static double ConvertPsiToBarometricPressure(double pressure)
        {
            return pressure / BarometricPressure * SeaLevelBasePressure;
        }

        public static double ConvertPressurePSIToElevationInFeet(double pressurePSI)
        {
            double elevation = (Math.Exp (Math.Log(pressurePSI / SeaLevelBasePressure) / ElevationPowerFactor) - 1.0) / ElevationConversionFactor * -1.0;
            return elevation;
        }

        public static double ConvertElevationInMetersToKilopascal(double elevation)
        {
            return OneAtmosphere * Math.Pow((1.0 - (ElevationConversionFactor * ConvertMetersToFeet(elevation))), ElevationPowerFactor);
        }

        public static double ConvertKilopascalToElevationInMeters(double kilopascal)
        {
            return ConvertFeetToMeters((Math.Exp(Math.Log(kilopascal / OneAtmosphere) / ElevationPowerFactor) - 1.0) / (ElevationConversionFactor * -1.0));
        }

        public static double ConvertBarometricPressureToKilopascal(double barometricPressure)
        {
            return barometricPressure / BarometricPressure * SeaLevelBasePressure;
        }

        //public static double ConvertBarometricPressureToKilopascal(double barometricPressure)
        //{
        //    return OneAtmosphere * barometricPressure / SeaLevelBasePressure;
        //}

        public static double ConvertKilopascalToPressurePSI(double kilopascal)
        {
            return (kilopascal * SeaLevelBasePressure) / OneAtmosphere;
        }

        public static double ConvertInchesOfMercuryToPsi(double inchesOfMercury)
        {
            return inchesOfMercury / BarometricPressure * SeaLevelBasePressure;
        }

        public static double ConvertPsiToInchesOfMercury(double pressure)
        {
            return (pressure / SeaLevelBasePressure) * BarometricPressure;
        }

        public static double ConvertInchesOfMercuryToKilopascal(double inchesOfMercury)
        {
            return (inchesOfMercury * KiloPascalToInchesOfMercuryConversionFactor);
        }

        public static double ConvertKilopascalToInchesOfMercury(double kilopascal)
        {
            return (kilopascal / KiloPascalToInchesOfMercuryConversionFactor); //3.386
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
