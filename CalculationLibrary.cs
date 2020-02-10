// Copyright Cooling Technology Institute 2019-2020

using Models;
using System;

namespace CalculationLibrary
{
    public class CalculationLibrary
    {
        public static int errno = 0;
        public const double Tboil = 212.0;
        public const double Patm = 14.696;

        //---------------------------------------------------------------------
        // Data calculations
        //---------------------------------------------------------------------

        public static void CalculateVariablesIP(double pressure, double temperatureDryBulb, double temperatureWetBulb, ref double PwsDB, ref double PwsWB, ref double FsDB, ref double FsWB)
        {
            PwsDB = IPPws(temperatureDryBulb);
            PwsWB = IPPws(temperatureWetBulb);
            FsDB = Fs(temperatureDryBulb, pressure);
            FsWB = Fs(temperatureWetBulb, pressure);
        }

        // humidityRatio = ((1093. - .556 * temperatureWetBulb) * WsWB - .24 * (temperatureDryBulb - temperatureWetBulb)) / (1093. + .444 * temperatureDryBulb - temperatureWetBulb);  //ASHRAE Eq.(33)
        public static double CalculateHumidityRatioIP(double pressure, double temperatureDryBulb, double temperatureWetBulb)
        {
            double PwsDB = 0.0;
            double PwsWB = 0.0;
            double FsDB = 0.0;
            double FsWB = 0.0;
            double WsWB = 0.0;
            double humidityRatio = 0.0;

            CalculateVariablesIP(pressure, temperatureDryBulb, temperatureWetBulb, ref PwsDB, ref PwsWB, ref FsDB, ref FsWB);

            // Calculate saturated humidity ratio at twb using saturation pressure (Pws) at twb,
            // and Fs correction factor at twb
            double density = (pressure - PwsWB * FsWB);
            if (density != 0.0)
            {
                WsWB = 0.62198 * PwsWB * FsWB / density;  //ASHRAE Eq.(21a)
            }

            // Calculate humidity ratio of the mixture
            // Check for thermodynamic capability
            density = (1093.0 + (0.444 * temperatureDryBulb) - temperatureWetBulb);
            if (density != 0.0)
            {
                humidityRatio = ((1093.0 - 0.556 * temperatureWetBulb) * WsWB - 0.24 * (temperatureDryBulb - temperatureWetBulb)) / density;  //ASHRAE Eq.(33)
            }

            return humidityRatio;
        }

        //public static void IPEnthalpysearch(int sat,
        //                       double p,
        //                       double RootEnthalpy,
        //                       ref double OutputEnthalpy,
        //                       ref double temperatureWetBulb,
        //                       ref double temperatureDryBulb,
        //                       double humidityRatio,
        //                       double relativeHumidity,
        //                       double specificVolume,
        //                       double Density,
        //                       double DEWPoint)
        //{
        //    // Establish tolerance on enthalpy search
        //    double temptolerance = 0.001;
        //    double Htolerance = 0.00005;

        //    // First need to bracket region of WB/DB to created bisection region
        //    // High and low values are respectively:
        //    double Tlower = 0.0;
        //    //DDP double Tupper = 200.0;
        //    double Tupper = 140.0;
        //    double Hlower;
        //    double Hupper;
        //    double hmid;
        //    double Enthalpy;

        //    // Calculate low value and compare to program and tolerance limits
        //    temperatureWetBulb = Tlower;
        //    if (sat == 1)
        //    {
        //        temperatureDryBulb = temperatureWetBulb;
        //    }

        //    CalcIPProperties(p,
        //                      temperatureWetBulb,
        //                      ref temperatureDryBulb,
        //                      ref humidityRatio,
        //                      ref relativeHumidity,
        //                      ref Hlower,
        //                      ref specificVolume,
        //                      ref Density,
        //                      ref DEWPoint
        //                    );

        //    // DDP change if ( Math.Abs(Tlower - RootEnthalpy) <= Htolerance ) 
        //    if (Math.Abs(Hlower - RootEnthalpy) <= Htolerance)
        //    {
        //        OutputEnthalpy = 0.0;
        //        temperatureDryBulb = 0.0;
        //        return;
        //    }

        //    if (RootEnthalpy < Hlower)
        //    {
        //        OutputEnthalpy = -999.0; // DDP ref of range
        //        return;
        //    }

        //    //Calculate high value and compare to program and tolerance limits
        //    temperatureWetBulb = Tupper;

        //    if (sat == 1)
        //    {
        //        temperatureDryBulb = temperatureWetBulb;
        //    }

        //    CalcIPProperties(p,
        //                      temperatureWetBulb,
        //                      temperatureDryBulb,
        //                      ref humidityRatio,
        //                      ref relativeHumidity,
        //                      ref Hupper,
        //                      ref specificVolume,
        //                      ref Density,
        //                      ref DEWPoint
        //                    );

        //    if (Math.Abs(Hupper - RootEnthalpy) <= Htolerance)
        //    {
        //        OutputEnthalpy = 0.0;
        //        return;
        //    }

        //    if (RootEnthalpy > Hupper)
        //    {
        //        OutputEnthalpy = -999.0; // DDP ref of range
        //        return;
        //    }

        //    // Begin bisection root search procedure from Numerical Recipes in BASIC, p 193
        //    double trtbis = Tlower;
        //    double DT = (Tupper - Tlower);
        //    double tmid;
        //    do
        //    {
        //        DT = DT / 2.0;
        //        tmid = trtbis + DT;
        //        if (sat == 1)
        //            temperatureDryBulb = tmid;
        //        CalcIPProperties(p,
        //                          tmid,
        //                          temperatureDryBulb,
        //                          ref humidityRatio,
        //                          ref relativeHumidity,
        //                          ref Enthalpy,
        //                          ref specificVolume,
        //                          ref Density,
        //                          ref DEWPoint
        //                        );
        //        hmid = RootEnthalpy - Enthalpy;
        //        if (hmid >= 0.0)
        //            trtbis = tmid;
        //    }
        //    while ((Math.Abs(DT) >= temptolerance) && (hmid != 0.0));

        //    temperatureWetBulb = tmid;
        //    if (sat == 1)
        //    {
        //        temperatureDryBulb = tmid;
        //    }
        //    OutputEnthalpy = Enthalpy;
        //}

        // double truncit( double number, int precision )
        public static double AdjustPrecision(double number, int precision)
        {
            //? should use Math.Round(number, precision)
            // String.Format("{0:F3}", dec); // Show 3 Decimel Points
            double adjustedNumber = 0;
            string format = "{0:F" + precision.ToString() + "}";
            if (!double.TryParse(string.Format(format, number), out adjustedNumber))
            {
                adjustedNumber = number;
            }
            return adjustedNumber;
        }

        public static double CalculatedegreeOfSaturationIP(double pressure, double temperatureDryBulb, double temperatureWetBulb)
        {
            double PwsDB = 0.0;
            double PwsWB = 0.0;
            double FsDB = 0.0;
            double FsWB = 0.0;
            double WsDB = 0.0;
            double WsWB = 0.0;
            double degreeOfSaturation = 0.0;
            double humidityRatio;

            CalculateVariablesIP(pressure, temperatureDryBulb, temperatureWetBulb, ref PwsDB, ref PwsWB, ref FsDB, ref FsWB);

            // Calculate saturated humidity ratio at twb using saturation pressure (Pws) at twb,
            // and Fs correction factor at twb
            double density = (pressure - PwsWB * FsWB);
            if (density != 0.0)
            {
                WsWB = 0.62198 * PwsWB * FsWB / density;  //ASHRAE Eq.(21a)
            }

            // Calculate humidity ratio of the mixture
            // humidityRatio = ((1093. - .556 * temperatureWetBulb) * WsWB - .24 * (temperatureDryBulb - temperatureWetBulb)) / (1093. + .444 * temperatureDryBulb - temperatureWetBulb);  //ASHRAE Eq.(33)
            humidityRatio = CalculateHumidityRatioIP(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate saturated humidity ratio at tdb using saturation pressure(Pws) at
            // tdb and correction factor Fs at tdb
            density = (pressure - PwsDB * FsDB);
            if (density != 0.0)
            {
                WsDB = 0.62198 * PwsDB * FsDB / density; //ASHRAE Eq.(21a)
            }

            // Calculate degree of saturation
            if (WsDB != 0.0)
            {
                degreeOfSaturation = humidityRatio / WsDB;           //ASHRAE Eq.(10)
            }

            return degreeOfSaturation;
        }

        // relativeHumidity = degreeOfSaturation / (1. - (1. - degreeOfSaturation) * (FsDB * PwsDB / p));  //ASHRAE Eq.(23a)
        public static double CalculateRelativeHumidityIP(double pressure, double temperatureDryBulb, double temperatureWetBulb)
        {
            double PwsDB = 0.0;
            double PwsWB = 0.0;
            double FsDB = 0.0;
            double FsWB = 0.0;
            double WsDB = 0.0;
            double WsWB = 0.0;
            double degreeOfSaturation;
            double humidityRatio;
            double relativeHumidity = 0.0;

            // Calculate vapor pressure and Fs factor at wb & db temperature
            CalculateVariablesIP(pressure, temperatureDryBulb, temperatureWetBulb, ref PwsDB, ref PwsWB, ref FsDB, ref FsWB);

            // Calculate saturated humidity ratio at twb using saturation pressure (Pws) at twb,
            // and Fs correction factor at twb
            double density = (pressure - PwsWB * FsWB);
            if (density != 0.0)
            {
                WsWB = 0.62198 * PwsWB * FsWB / density;  //ASHRAE Eq.(21a)
            }

            // Calculate humidity ratio of the mixture
            // humidityRatio = ((1093. - .556 * temperatureWetBulb) * WsWB - .24 * (temperatureDryBulb - temperatureWetBulb)) / (1093. + .444 * temperatureDryBulb - temperatureWetBulb);  //ASHRAE Eq.(33)
            humidityRatio = CalculateHumidityRatioIP(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate saturated humidity ratio at tdb using saturation pressure(Pws) at
            // tdb and correction factor Fs at tdb
            density = (pressure - PwsDB * FsDB);
            if (density != 0.0)
            {
                WsDB = 0.62198 * PwsDB * FsDB / density; //ASHRAE Eq.(21a)
            }

            // Calculate degree of saturation
            degreeOfSaturation = CalculatedegreeOfSaturationIP(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate relative humidity
            density = pressure != 0.0 ? (1.0 - (1.0 - degreeOfSaturation) * (FsDB * PwsDB / pressure)) : 0.0;

            if (density != 0.0)
            {
                relativeHumidity = degreeOfSaturation / density;  //ASHRAE Eq.(23a)
            }

            return relativeHumidity;
        }

        public static double CalculateSpecificVolumeIP(double p, double temperatureDryBulb, double temperatureWetBulb)
        {
            double PwsDB = 0.0;
            double PwsWB = 0.0;
            double FsDB = 0.0;
            double FsWB = 0.0;
            double WsDB = 0.0;
            double WsWB = 0.0;
            double degreeOfSaturation;
            double Ra;
            double relativeHumidity;
            double humidityRatio;
            double specificVolume = 0.0;

            // Calculate vapor pressure and Fs factor at wb & db temperature
            CalculateVariablesIP(p, temperatureDryBulb, temperatureWetBulb, ref PwsDB, ref PwsWB, ref FsDB, ref FsWB);

            // Calculate saturated humidity ratio at twb using saturation pressure (Pws) at twb,
            // and Fs correction factor at twb
            double density = (p - PwsWB * FsWB);
            if (density != 0.0)
            {
                WsWB = 0.62198 * PwsWB * FsWB / density;  //ASHRAE Eq.(21a)
            }

            // Calculate humidity ratio of the mixture
            // humidityRatio = ((1093. - .556 * temperatureWetBulb) * WsWB - .24 * (temperatureDryBulb - temperatureWetBulb)) / (1093. + .444 * temperatureDryBulb - temperatureWetBulb);  //ASHRAE Eq.(33)
            humidityRatio = CalculateHumidityRatioIP(p, temperatureDryBulb, temperatureWetBulb);

            // Calculate saturated humidity ratio at tdb using saturation pressure(Pws) at
            // tdb and correction factor Fs at tdb
            density = (p - PwsDB * FsDB);
            if (density != 0.0)
            {
                WsDB = 0.62198 * PwsDB * FsDB / density; //ASHRAE Eq.(21a)
            }

            // Calculate degree of saturation
            // degreeOfSaturation = humidityRatio / WsDB;           //ASHRAE Eq.(10)
            degreeOfSaturation = CalculatedegreeOfSaturationIP(p, temperatureDryBulb, temperatureWetBulb);

            // Calculate relative humidity
            // relativeHumidity = degreeOfSaturation / (1. - (1. - degreeOfSaturation) * (FsDB * PwsDB / p));  //ASHRAE Eq.(23a)
            relativeHumidity = CalculateRelativeHumidityIP(p, temperatureDryBulb, temperatureWetBulb);

            // Calculate specific volume
            Ra = 53.352 / 144.0;   // to change gas constant to psi per foot
            if (p != 0.0)
            {
                specificVolume = Ra * (temperatureDryBulb + 459.67) * (1.0 + 1.6078 * humidityRatio) / p;   //ASHRAE Eq.(26)
            }

            return specificVolume;
        }

        public static double CalculateDensityIP(double pressure, double temperatureDryBulb, double temperatureWetBulb)
        {
            double PwsDB = 0.0;
            double PwsWB = 0.0;
            double FsDB = 0.0;
            double FsWB = 0.0;
            double WsDB = 0.0;
            double WsWB = 0.0;
            double humidityRatio;
            double relativeHumidity;
            double degreeOfSaturation;
            double density = 0.0;
            double specificVolume;
            //	double Ra;

            // Calculate vapor pressure and Fs factor at wb & db temperature
            CalculateVariablesIP(pressure, temperatureDryBulb, temperatureWetBulb, ref PwsDB, ref PwsWB, ref FsDB, ref FsWB);

            // Calculate saturated humidity ratio at twb using saturation pressure (Pws) at twb,
            // and Fs correction factor at twb
            density = (pressure - PwsWB * FsWB);
            if (density != 0.0)
            {
                WsWB = 0.62198 * PwsWB * FsWB / density;  //ASHRAE Eq.(21a)
            }

            // Calculate humidity ratio of the mixture
            // humidityRatio = ((1093. - .556 * temperatureWetBulb) * WsWB - .24 * (temperatureDryBulb - temperatureWetBulb)) / (1093. + .444 * temperatureDryBulb - temperatureWetBulb);  //ASHRAE Eq.(33)
            humidityRatio = CalculateHumidityRatioIP(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate saturated humidity ratio at tdb using saturation pressure(Pws) at
            // tdb and correction factor Fs at tdb
            density = (pressure - PwsDB * FsDB);
            if (density != 0.0)
            {
                WsDB = 0.62198 * PwsDB * FsDB / density; //ASHRAE Eq.(21a)
            }

            // Calculate degree of saturation
            // degreeOfSaturation = humidityRatio / WsDB;           //ASHRAE Eq.(10)
            degreeOfSaturation = CalculatedegreeOfSaturationIP(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate relative humidity
            // relativeHumidity = degreeOfSaturation / (1. - (1. - degreeOfSaturation) * (FsDB * PwsDB / p));  //ASHRAE Eq.(23a)
            relativeHumidity = CalculateRelativeHumidityIP(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate specific volume
            // Ra = 53.352 / 144.;   // to change gas constant to psi per foot
            // specificVolume = Ra * (temperatureDryBulb + 459.67) * (1. + 1.6078 * humidityRatio) / p;   //ASHRAE Eq.(26)
            specificVolume = CalculateSpecificVolumeIP(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate density
            if (specificVolume != 0.0)
            {
                density = (1.0 + humidityRatio) / specificVolume;
            }

            return density;
        }

        // streamlined Enthalpy function for demand curves
        public static double CalculateEnthalpy(double pressure, double temperatureDryBulb, double temperatureWetBulb)
        {
            double Ra;
            double PwsDB = 0.0;
            double PwsWB = 0.0;
            double FsDB = 0.0;
            double FsWB = 0.0;
            double WsDB = 0.0;
            double WsWB = 0.0;
            double degreeOfSaturation = 0.0;
            double humidityRatio = 0.0;
            double relativeHumidity = 0.0;
            double specificVolume = 0.0;
            double Density = 0.0;
            double Enthalpy;

            // CalcIpVars
            PwsDB = IPPws(temperatureDryBulb);
            PwsWB = IPPws(temperatureWetBulb);
            FsDB = Fs(temperatureDryBulb, pressure);
            FsWB = Fs(temperatureWetBulb, pressure);

            // calculate WsWB
            double density = (pressure - PwsWB * FsWB);
            if (density != 0.0)
            {
                WsWB = 0.62198 * PwsWB * FsWB / density; ;  //ASHRAE Eq.(21a)
            }

            // calculate humidity ratio
            density = (1093.0 + .444 * temperatureDryBulb - temperatureWetBulb);
            if (density != 0.0)
            {
                humidityRatio = ((1093.0 - .556 * temperatureWetBulb) * WsWB - .24 * (temperatureDryBulb - temperatureWetBulb)) / density;  //ASHRAE Eq.(33)
            }

            // Calculate saturated humidity ratio at tdb using saturation pressure(Pws) at
            // tdb and correction factor Fs at tdb
            density = (pressure - PwsDB * FsDB);
            if (density != 0.0)
            {
                WsDB = 0.62198 * PwsDB * FsDB / density; //ASHRAE Eq.(21a)    
            }

            // Calculate degree of saturation
            if (WsDB != 0.0)
            {
                degreeOfSaturation = humidityRatio / WsDB;           //ASHRAE Eq.(10)
            }

            // Calculate relative humidity
            density = pressure != 0.0 ? (1.0 - (1.0 - degreeOfSaturation) * (FsDB * PwsDB / pressure)) : 0.0;
            if (density != 0.0)
            {
                relativeHumidity = degreeOfSaturation / density;  //ASHRAE Eq.(23a)
            }

            // Calculate specific volume
            Ra = 53.352 / 144.0;   // to change gas constant to psi per foot
            if (pressure != 0.0)
            {
                specificVolume = Ra * (temperatureDryBulb + 459.67) * (1.0 + 1.6078 * humidityRatio) / pressure;   //ASHRAE Eq.(26)
            }

            // Calculate density
            if (specificVolume != 0.0)
            {
                Density = (1.0 + humidityRatio) / specificVolume;
            }

            // Calculate enthalpy
            Enthalpy = .24 * temperatureDryBulb + humidityRatio * (1061.0 + .444 * temperatureDryBulb);  //ASHRAE Eq.(30)

            return Enthalpy;
        }

        public static double CalculateEnthalpyIP(double pressure, double temperatureDryBulb, double temperatureWetBulb)
        {
            double PwsDB = 0.0;
            double PwsWB = 0.0;
            double FsDB = 0.0;
            double FsWB = 0.0;
            double WsDB = 0.0;
            double WsWB = 0.0;
            double degreeOfSaturation;
            double humidityRatio;
            double relativeHumidity;
            double specificVolume;
            double Density;
            double Enthalpy;
            //	double Ra;

            // Calculate vapor pressure and Fs factor at wb & db temperature
            CalculateVariablesIP(pressure, temperatureDryBulb, temperatureWetBulb, ref PwsDB, ref PwsWB, ref FsDB, ref FsWB);

            // Calculate saturated humidity ratio at twb using saturation pressure (Pws) at twb,
            // and Fs correction factor at twb
            double density = (pressure - PwsWB * FsWB);
            if (density != 0.0)
                WsWB = 0.62198 * PwsWB * FsWB / density;  //ASHRAE Eq.(21a)

            // Calculate humidity ratio of the mixture
            // humidityRatio = ((1093. - .556 * temperatureWetBulb) * WsWB - .24 * (temperatureDryBulb - temperatureWetBulb)) / (1093. + .444 * temperatureDryBulb - temperatureWetBulb);  //ASHRAE Eq.(33)
            humidityRatio = CalculateHumidityRatioIP(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate saturated humidity ratio at tdb using saturation pressure(Pws) at
            // tdb and correction factor Fs at tdb
            density = (pressure - PwsDB * FsDB);
            if (density != 0.0)
                WsDB = 0.62198 * PwsDB * FsDB / density; //ASHRAE Eq.(21a)

            // Calculate degree of saturation
            // degreeOfSaturation = humidityRatio / WsDB;           //ASHRAE Eq.(10)
            degreeOfSaturation = CalculatedegreeOfSaturationIP(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate relative humidity
            // relativeHumidity = degreeOfSaturation / (1. - (1. - degreeOfSaturation) * (FsDB * PwsDB / p));  //ASHRAE Eq.(23a)
            relativeHumidity = CalculateRelativeHumidityIP(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate specific volume
            // Ra = 53.352 / 144.;   // to change gas constant to psi per foot
            // specificVolume = Ra * (temperatureDryBulb + 459.67) * (1. + 1.6078 * humidityRatio) / p;   //ASHRAE Eq.(26)
            specificVolume = CalculateSpecificVolumeIP(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate density
            // Density = (1. + humidityRatio) / specificVolume;
            Density = CalculateDensityIP(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate enthalpy
            Enthalpy = .24 * temperatureDryBulb + humidityRatio * (1061.0 + .444 * temperatureDryBulb);  //ASHRAE Eq.(30)

            return Enthalpy;
        }

        public static double CalculateDewPointIP(double pressure, double temperatureDryBulb, double temperatureWetBulb)
        {
            double PwsDB = 0.0;
            double PwsWB = 0.0;
            double FsDB = 0.0;
            double FsWB = 0.0;
            double WsDB = 0.0;
            double WsWB = 0.0;
            double degreeOfSaturation;
            double humidityRatio;
            double relativeHumidity;
            double specificVolume;
            double Density;
            double Enthalpy;
            double DEWPoint = 0.0;

            // Calculate vapor pressure and Fs factor at wb & db temperature
            CalculateVariablesIP(pressure, temperatureDryBulb, temperatureWetBulb, ref PwsDB, ref PwsWB, ref FsDB, ref FsWB);

            // Calculate saturated humidity ratio at twb using saturation pressure (Pws) at twb,
            // and Fs correction factor at twb
            double density = (pressure - PwsWB * FsWB);
            if (density != 0.0)
            {
                WsWB = 0.62198 * PwsWB * FsWB / density;  //ASHRAE Eq.(21a)
            }

            // Calculate humidity ratio of the mixture
            // humidityRatio = ((1093. - .556 * temperatureWetBulb) * WsWB - .24 * (temperatureDryBulb - temperatureWetBulb)) / (1093. + .444 * temperatureDryBulb - temperatureWetBulb);  //ASHRAE Eq.(33)
            humidityRatio = CalculateHumidityRatioIP(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate saturated humidity ratio at tdb using saturation pressure(Pws) at
            // tdb and correction factor Fs at tdb
            density = (pressure - PwsDB * FsDB);
            if (density != 0.0)
            {
                WsDB = 0.62198 * PwsDB * FsDB / density; //ASHRAE Eq.(21a)
            }

            // Calculate degree of saturation
            // degreeOfSaturation = humidityRatio / WsDB;           //ASHRAE Eq.(10)
            degreeOfSaturation = CalculatedegreeOfSaturationIP(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate relative humidity
            // relativeHumidity = degreeOfSaturation / (1. - (1. - degreeOfSaturation) * (FsDB * PwsDB / p));  //ASHRAE Eq.(23a)
            relativeHumidity = CalculateRelativeHumidityIP(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate specific volume
            // Ra = 53.352 / 144.;   // to change gas constant to psi per foot
            // specificVolume = Ra * (temperatureDryBulb + 459.67) * (1. + 1.6078 * humidityRatio) / p;   //ASHRAE Eq.(26)
            specificVolume = CalculateSpecificVolumeIP(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate density
            // Density = (1. + humidityRatio) / specificVolume;
            Density = CalculateDensityIP(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate enthalpy
            // Enthalpy = .24 * temperatureDryBulb + humidityRatio * (1061. + .444 * temperatureDryBulb);  //ASHRAE Eq.(30)
            Enthalpy = CalculateEnthalpyIP(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate dew point temperature
            DEWPoint = CalculateDewPointIP(pressure, temperatureWetBulb, temperatureDryBulb, humidityRatio);

            return DEWPoint;
        }

        public static void CalculatePropertiesIP(PsychrometricsData data)
        {
            // Calculate humidity ratio of the mixture
            // humidityRatio = ((1093. - .556 * data.TemperatureWetBulb) * WsWB - .24 * (data.TemperatureDryBulb - data.TemperatureWetBulb)) / (1093. + .444 * data.TemperatureDryBulb - data.TemperatureWetBulb);  //ASHRAE Eq.(33)
            data.HumidityRatio = CalculateHumidityRatioIP(data.BarometricPressure, data.DryBulbTemperature, data.WetBulbTemperature);

            // Calculate degree of saturation
            // degreeOfSaturation = humidityRatio / WsDB;           //ASHRAE Eq.(10)
            data.DegreeOfSaturation = CalculatedegreeOfSaturationIP(data.BarometricPressure, data.DryBulbTemperature, data.WetBulbTemperature);

            // Calculate relative humidity
            // relativeHumidity = degreeOfSaturation / (1. - (1. - degreeOfSaturation) * (FsDB * PwsDB / p));  //ASHRAE Eq.(23a)
            data.RelativeHumidity = CalculateRelativeHumidityIP(data.BarometricPressure, data.DryBulbTemperature, data.WetBulbTemperature);

            // Calculate specific volume
            // Ra = 53.352 / 144.;   // to change gas constant to psi per foot
            // specificVolume = Ra * (data.TemperatureDryBulb + 459.67) * (1. + 1.6078 * humidityRatio) / p;   //ASHRAE Eq.(26)
            data.SpecificVolume = CalculateSpecificVolumeIP(data.BarometricPressure, data.DryBulbTemperature, data.WetBulbTemperature);

            // Calculate density
            // Density = (1. + humidityRatio) / specificVolume;
            data.Density = CalculateDensityIP(data.BarometricPressure, data.DryBulbTemperature, data.WetBulbTemperature);

            // Calculate enthalpy
            // Enthalpy = .24 * data.TemperatureDryBulb + humidityRatio * (1061. + .444 * data.TemperatureDryBulb);  //ASHRAE Eq.(30)
            data.Enthalpy = CalculateEnthalpyIP(data.BarometricPressure, data.DryBulbTemperature, data.WetBulbTemperature);

            // Calculate dew point temperature
            data.DewPoint = CalculateDewPointIP(data.BarometricPressure, data.WetBulbTemperature, data.DryBulbTemperature, data.HumidityRatio);

            if ((data.HumidityRatio < 0.0) && (Math.Abs(data.HumidityRatio) < .000001))
            {
                data.HumidityRatio = 0.0;
            }
        }

        //*******Given WB & DB Calculate IP psycrometric properties routine ********
        //
        public static void CalculatePropertiesIP(double pressure, double temperatureWetBulb, double temperatureDryBulb, ref double humidityRatio, ref double relativeHumidity, ref double Enthalpy, ref double specificVolume, ref double Density, ref double DEWPoint)
        {
            double degreeOfSaturation;

            // Calculate humidity ratio of the mixture
            // humidityRatio = ((1093. - .556 * temperatureWetBulb) * WsWB - .24 * (temperatureDryBulb - temperatureWetBulb)) / (1093. + .444 * temperatureDryBulb - temperatureWetBulb);  //ASHRAE Eq.(33)
            humidityRatio = CalculateHumidityRatioIP(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate degree of saturation
            // degreeOfSaturation = humidityRatio / WsDB;           //ASHRAE Eq.(10)
            degreeOfSaturation = CalculatedegreeOfSaturationIP(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate relative humidity
            // relativeHumidity = degreeOfSaturation / (1. - (1. - degreeOfSaturation) * (FsDB * PwsDB / p));  //ASHRAE Eq.(23a)
            relativeHumidity = CalculateRelativeHumidityIP(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate specific volume
            // Ra = 53.352 / 144.;   // to change gas constant to psi per foot
            // specificVolume = Ra * (temperatureDryBulb + 459.67) * (1. + 1.6078 * humidityRatio) / p;   //ASHRAE Eq.(26)
            specificVolume = CalculateSpecificVolumeIP(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate density
            // Density = (1. + humidityRatio) / specificVolume;
            Density = CalculateDensityIP(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate enthalpy
            // Enthalpy = .24 * temperatureDryBulb + humidityRatio * (1061. + .444 * temperatureDryBulb);  //ASHRAE Eq.(30)
            Enthalpy = CalculateEnthalpyIP(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate dew point temperature
            DEWPoint = CalculateDewPointIP(pressure, temperatureWetBulb, temperatureDryBulb, humidityRatio);

            if ((humidityRatio < 0.0) && (Math.Abs(humidityRatio) < .000001))
            {
                humidityRatio = 0.0;
            }
        }

        //************ Function calculates IP Vapor pressure ************************
        //*********** Partial Pressure of Water Vapor (-148ø to 32ø) ****************
        //*********** Partial Pressure of Water Vapor (32ø-392ø) ********************
        // ?? Pws = saturation vapor pressure
        public static double IPPws(double tair)
        {
            double dblIPPws;
            double C1;
            double C2;
            double C3;
            double C4;
            double C5;
            double C6;
            double C7;
            double C8;
            double C9;
            double C10;
            double C11;
            double C12;
            double C13;
            double LnPws = 0.0;
            double t;

            // Calculate saturation pressure at t!
            if (tair >= 32)
            {
                C8 = -10440.39708;
                C9 = -11.2946496;
                C10 = -.027022355;
                C11 = .00001289036;
                C12 = -.000000002478068;
                C13 = 6.5459673;
                t = tair + 459.67;
                LnPws = C8 / t + C9 + C10 * t + C11 * t * t + C12 * t * t * t + C13 * Math.Log(t);
                dblIPPws = Math.Exp(LnPws);    //ASHRAE Eq.(4)
            }
            else
            {
                C1 = -10214.16462;
                C2 = -4.89350301;
                C3 = -.00537657944;
                C4 = .000000192023769;
                C5 = 3.55758316E-10;
                C6 = -9.03446883E-14;
                C7 = 4.1635019;
                t = tair + 459.67;
                if (t != 0.0)
                    LnPws = C1 / t + C2 + C3 * t + C4 * t * t + C5 * t * t * t + C6 * t * t * t * t + C7 * Math.Log(t);
                dblIPPws = Math.Exp(LnPws);   //ASHRAE Eq.(3)
            }

            return dblIPPws;
        }

        /*
        // bluebook version
        double Fs ( double T, double P )
        {
            return(((-4.55447E-10*T+9.400757E-9*P+1.282159E-7)*T
            -1.762686E-6*P+6.35199E-6)*T+3.18886E-4*P+1.000104);
        }
        */
        // psych35 version
        public static double Fs(double t, double p)
        {
            double C1 = 1.000119;
            double C2 = 9.184907E-06;
            double C3 = 1.286098E-11;
            double C4 = -1.593274E-13;
            double C5 = 2.872637E-04;
            double C6 = -1.618048E-06;
            double C7 = 1.467535E-08;
            double C8 = 2.41896E-12;
            double C9 = -1.371762E-10;
            double C10 = -8.565893E-10;
            double C11 = 1.229524E-10;
            double C12 = -2.336628E-11;

            double C13 = C1 + C2 * t + C3 * Math.Pow(t, 4.0) + C4 * Math.Pow(t, 5.0) + C5 * p + C6 * p * t;
            double C14 = C13 + C7 * p * Math.Pow(t, 2.0) + C8 * p * Math.Pow(t, 4.0) + C9 * t * Math.Pow(p, 4.0);
            double dblFs = C14 + C10 * Math.Pow(t, 2.0) * Math.Pow(p, 2.0) + C11 * Math.Pow(t, 2.0) * Math.Pow(p, 3.0) + C12 * Math.Pow(p, 2.0) * Math.Pow(t, 3.0);

            return dblFs;
        }

        //*** Function to find IPDewPoint
        //*** Converges to the same Humidity Ratio as if you had entered
        //*** saturated conditions (DB=WB)
        public static double CalculateDewPointIP(double p, double temperatureWetBulb, double temperatureDryBulb, double humidityRatio)
        {
            double C1 = -10214.16462;
            double C3 = -.00537657944;
            double C4 = .000000192023769;
            double C5 = 3.55758316E-10;
            double C6 = -9.03446883E-14;
            double C7 = 4.1635019;
            double C8 = -10440.39708;
            double C10 = -.027022355;
            double C11 = .00001289036;
            double C12 = -.000000002478068;
            double C13 = 6.5459673;
            double PwsDp;
            double FsDp;
            double WsDp;
            double DEWPoint;
            double PDEW;
            double lnpw;
            double DeltaT;
            double DERPws;
            double t;
            double DERHR;
            int iLoop;
            double density;

            errno = 0;

            // Method to determine Dew Point - Fs varies with temp - Process in iterative passes.
            FsDp = Fs(temperatureWetBulb, p);
            DEWPoint = temperatureWetBulb;

            for (iLoop = 1; iLoop <= 2; iLoop++)      // Makes exactly two passes to get best first estimate
            {
                // Calculate dew point pressure
                density = (FsDp * (.62198 + humidityRatio));
                PDEW = density != 0.0 ? (p * humidityRatio / density) : 1.0;  //ASHRAE Eq.(34)

                // Calculate dew point temperature - check above and below ice point
                if (DEWPoint < 32)
                {
                    lnpw = Math.Log(PDEW);
                    DEWPoint = 90.12 + 26.142 * lnpw + .8927 * Math.Pow(lnpw, 2.0);   //ASHRAE Eq.(35)
                }
                else
                {
                    double C14 = 100.45;
                    double C15 = 33.193;
                    double C16 = 2.319;
                    double C17 = 0.17074;
                    double C18 = 1.2063;
                    lnpw = Math.Log(PDEW);

                    double t1 = (Math.Pow(lnpw, 2.0));
                    double t2 = (Math.Pow(lnpw, 3.0));
                    double t3 = (Math.Pow(PDEW, 0.1984));

                    DEWPoint = C14 + C15 * lnpw + C16 * t1 + C17 * t2 + C18 * t3;  //ASHRAE Eq.(36)
                }
                FsDp = Fs(DEWPoint, p);
            }

            PwsDp = IPPws(DEWPoint);
            density = (p - PwsDp * FsDp);
            WsDp = density != 0.0 ? (0.62198 * PwsDp * FsDp / density) : 0.0;
            DeltaT = 1.0;

            while (
                   (WsDp != 0.0) &&
                   ((Math.Abs(humidityRatio / WsDp - 1.0) >= 0.000001) ||
                    (Math.Abs(DeltaT) >= 0.0001))
                  )
            {
                PwsDp = IPPws(DEWPoint);
                FsDp = Fs(DEWPoint, p);
                density = (p - PwsDp * FsDp);
                WsDp = density != 0.0 ? (0.62198 * PwsDp * FsDp / density) : 0.0;

                //Calculate DERivative of Vapor Pressure
                t = DEWPoint + 459.67;
                if (DEWPoint >= 32)
                {
                    DERPws = PwsDp * (-C8 / Math.Pow(t, 2.0) + C10 + 2.0 * C11 * t + 3.0 * C12 * t * t + C13 / t);
                }
                else if (t != 0.0)
                {
                    DERPws = PwsDp * (-C1 / Math.Pow(t, 2.0) + C3 + 2.0 * C4 * t + 3.0 * C5 * t * t + 4.0 * C6 * Math.Pow(t, 3.0) + C7 / t);
                }
                else
                {
                    DERPws = 0.0;
                }

                //*****************************************************************************

                //Calculate DERivative of Humidity Ratio
                density = Math.Pow((p - FsDp * PwsDp), 2.0);
                if (density != 0.0)
                    DERHR = ((p - PwsDp * FsDp) * 0.62198 * FsDp * DERPws - (.62198 * FsDp * PwsDp) * (-FsDp * DERPws)) / density;
                else
                    DERHR = 0.0;

                //Converge to given humidityRatio using Newton-Raphson Method
                //Yields abref one order of magnitude correction per iteration
                DeltaT = DERHR != 0.0 ? ((humidityRatio - WsDp) / DERHR) : 0.0;
                DEWPoint = DEWPoint + DeltaT;
            }

            if (errno != 0)
            {
                DEWPoint = 0.0;
            }

            return DEWPoint;
        }

        public static void CalculateVariablesSI(double p, double temperatureDryBulb, double temperatureWetBulb, ref double PwsDB, ref double PwsWB, ref double FsDB, ref double FsWB)
        {
            double Ppsi;
            double tF;

            PwsDB = SIPws(temperatureDryBulb);
            PwsWB = SIPws(temperatureWetBulb);
            tF = temperatureDryBulb * 1.8 + 32.0;
            Ppsi = 14.696 * p / 101.325;
            FsDB = Fs(tF, Ppsi);
            tF = temperatureWetBulb * 1.8 + 32.0;
            FsWB = Fs(tF, Ppsi);
        }

        //*******Given WB & DB Calculate SI psycrometric properties routine ********
        //
        public static double CalculatehumidityRatioSI(double p, double temperatureDryBulb, double temperatureWetBulb)
        {
            double PwsDB = 0.0;
            double PwsWB = 0.0;
            double FsDB = 0.0;
            double FsWB = 0.0;
            double WsWB = 0.0;
            double humidityRatio = 0.0;

            CalculateVariablesSI(p, temperatureDryBulb, temperatureWetBulb, ref PwsDB, ref PwsWB, ref FsDB, ref FsWB);

            // Calculate saturated humidity ratio at twb using saturation pressure (Pws) at twb,
            // and Fs correction factor at twb
            double density = (p - PwsWB * FsWB);
            if (density != 0.0)
            {
                WsWB = 0.62198 * PwsWB * FsWB / density;  //ASHRAE Eq.(21a)
            }

            // Calculate humidity ratio of the mixture
            density = (2501.0 + 1.805 * temperatureDryBulb - 4.186 * temperatureWetBulb);
            if (density != 0.0)
            {
                humidityRatio = ((2501.0 - 2.381 * temperatureWetBulb) * WsWB - (temperatureDryBulb - temperatureWetBulb)) / density;  //ASHRAE Eq.(33)
            }

            return humidityRatio;
        }

        public static double CaclulateDegreeOfSaturationSI(double pressure, double temperatureDryBulb, double temperatureWetBulb)
        {
            double PwsDB = 0.0;
            double PwsWB = 0.0;
            double FsDB = 0.0;
            double FsWB = 0.0;
            double WsDB = 0.0;
            double humidityRatio;
            double degreeOfSaturation = 0.0;

            CalculateVariablesSI(pressure, temperatureDryBulb, temperatureWetBulb, ref PwsDB, ref PwsWB, ref FsDB, ref FsWB);

            // Calculate humidity ratio of the mixture
            //    humidityRatio = ((2501 - 2.381 * temperatureWetBulb) * WsWB - (temperatureDryBulb - temperatureWetBulb)) / (2501 + 1.805 * temperatureDryBulb - 4.186 * temperatureWetBulb);  //ASHRAE Eq.(33)
            humidityRatio = CalculatehumidityRatioSI(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate saturated humidity ratio at tdb using saturation pressure(Pws) at
            // tdb and correction factor Fs at tdb
            double density = (pressure - PwsDB * FsDB);
            if (density != 0.0)
                WsDB = 0.62198 * PwsDB * FsDB / density; //ASHRAE Eq.(21a)

            // Calculate degree of saturation
            if (WsDB != 0.0)
                degreeOfSaturation = humidityRatio / WsDB;           //ASHRAE Eq.(10)

            return degreeOfSaturation;
        }

        public static double CaclulateRelativeHumiditySI(double pressure, double temperatureDryBulb, double temperatureWetBulb)
        {
            double PwsDB = 0.0;
            double PwsWB = 0.0;
            double FsDB = 0.0;
            double FsWB = 0.0;
            double degreeOfSaturation;
            double humidityRatio;
            double relativeHumidity = 0.0;

            CalculateVariablesSI(pressure, temperatureDryBulb, temperatureWetBulb, ref PwsDB, ref PwsWB, ref FsDB, ref FsWB);

            // Calculate humidity ratio of the mixture
            //    humidityRatio = ((2501 - 2.381 * temperatureWetBulb) * WsWB - (temperatureDryBulb - temperatureWetBulb)) / (2501 + 1.805 * temperatureDryBulb - 4.186 * temperatureWetBulb);  //ASHRAE Eq.(33)
            humidityRatio = CalculatehumidityRatioSI(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate saturated humidity ratio at tdb using saturation pressure(Pws) at
            // tdb and correction factor Fs at tdb
            // WsDB = 0.62198 * PwsDB * FsDB / (p - PwsDB * FsDB); //ASHRAE Eq.(21a)

            // Calculate degree of saturation
            // degreeOfSaturation = humidityRatio / WsDB;           //ASHRAE Eq.(10)
            degreeOfSaturation = CaclulateDegreeOfSaturationSI(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate relative humidity
            double density = (pressure != 0.0 ? (1.0 - (1.0 - degreeOfSaturation) * (FsDB * PwsDB / pressure)) : 0.0);
            if (density != 0.0)
            {
                relativeHumidity = degreeOfSaturation / density;  //ASHRAE Eq.(23a)
            }

            return relativeHumidity;
        }

        public static double CaclulateSpecificVolumeSI(double p, double temperatureDryBulb, double temperatureWetBulb)
        {
            double PwsDB = 0.0;
            double PwsWB = 0.0;
            double FsDB = 0.0;
            double FsWB = 0.0;
            double degreeOfSaturation;
            double Ra;
            double humidityRatio;
            double relativeHumidity;
            double specificVolume = 0.0;

            CalculateVariablesSI(p, temperatureDryBulb, temperatureWetBulb, ref PwsDB, ref PwsWB, ref FsDB, ref FsWB);

            // Calculate humidity ratio of the mixture
            //    humidityRatio = ((2501 - 2.381 * temperatureWetBulb) * WsWB - (temperatureDryBulb - temperatureWetBulb)) / (2501 + 1.805 * temperatureDryBulb - 4.186 * temperatureWetBulb);  //ASHRAE Eq.(33)
            humidityRatio = CalculatehumidityRatioSI(p, temperatureDryBulb, temperatureWetBulb);

            // Calculate degree of saturation
            // degreeOfSaturation = humidityRatio / WsDB;           //ASHRAE Eq.(10)
            degreeOfSaturation = CaclulateDegreeOfSaturationSI(p, temperatureDryBulb, temperatureWetBulb);

            // Calculate relative humidity
            // relativeHumidity = degreeOfSaturation / (1 - (1 - degreeOfSaturation) * (FsDB * PwsDB / p));  //ASHRAE Eq.(23a)
            relativeHumidity = CaclulateRelativeHumiditySI(p, temperatureDryBulb, temperatureWetBulb);

            // Calculate specific volume
            Ra = 287.055 / 1000;   // to change gas constant units convert kPa to Pa

            if (p != 0.0)
            {
                specificVolume = Ra * (temperatureDryBulb + 273.15) * (1.0 + 1.6078 * humidityRatio) / p;   //ASHRAE Eq.(26)
            }

            return specificVolume;
        }

        public static double CalculateDensitySI(double pressure, double temperatureDryBulb, double temperatureWetBulb)
        {
            double PwsDB = 0.0;
            double PwsWB = 0.0;
            double FsDB = 0.0;
            double FsWB = 0.0;
            double degreeOfSaturation;
            double humidityRatio;
            double relativeHumidity;
            double specificVolume;
            double Density;

            CalculateVariablesSI(pressure, temperatureDryBulb, temperatureWetBulb, ref PwsDB, ref PwsWB, ref FsDB, ref FsWB);

            // Calculate humidity ratio of the mixture
            //    humidityRatio = ((2501 - 2.381 * temperatureWetBulb) * WsWB - (temperatureDryBulb - temperatureWetBulb)) / (2501 + 1.805 * temperatureDryBulb - 4.186 * temperatureWetBulb);  //ASHRAE Eq.(33)
            humidityRatio = CalculatehumidityRatioSI(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate degree of saturation
            // degreeOfSaturation = humidityRatio / WsDB;           //ASHRAE Eq.(10)
            degreeOfSaturation = CaclulateDegreeOfSaturationSI(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate relative humidity
            // relativeHumidity = degreeOfSaturation / (1 - (1 - degreeOfSaturation) * (FsDB * PwsDB / p));  //ASHRAE Eq.(23a)
            relativeHumidity = CaclulateRelativeHumiditySI(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate specific volume
            // Ra = 287.055 / 1000;   // to change gas constant units convert kPa to Pa
            // specificVolume = Ra * (temperatureDryBulb + 273.15) * (1 + 1.6078 * humidityRatio) / p;   //ASHRAE Eq.(26)
            specificVolume = CaclulateSpecificVolumeSI(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate density
            Density = specificVolume != 0.0 ? ((1.0 + humidityRatio) / specificVolume) : 0.0;
            return Density;
        }

        public static double CalculateEnthalpySI(double p, double temperatureDryBulb, double temperatureWetBulb)
        {
            double PwsDB = 0.0;
            double PwsWB = 0.0;
            double FsDB = 0.0;
            double FsWB = 0.0;
            double degreeOfSaturation;
            double humidityRatio;
            double relativeHumidity;
            double specificVolume;
            double Density;
            double Enthalpy;

            CalculateVariablesSI(p, temperatureDryBulb, temperatureWetBulb, ref PwsDB, ref PwsWB, ref FsDB, ref FsWB);

            // Calculate humidity ratio of the mixture
            //    humidityRatio = ((2501 - 2.381 * temperatureWetBulb) * WsWB - (temperatureDryBulb - temperatureWetBulb)) / (2501 + 1.805 * temperatureDryBulb - 4.186 * temperatureWetBulb);  //ASHRAE Eq.(33)
            humidityRatio = CalculatehumidityRatioSI(p, temperatureDryBulb, temperatureWetBulb);

            // Calculate degree of saturation
            // degreeOfSaturation = humidityRatio / WsDB;           //ASHRAE Eq.(10)
            degreeOfSaturation = CaclulateDegreeOfSaturationSI(p, temperatureDryBulb, temperatureWetBulb);

            // Calculate relative humidity
            // relativeHumidity = degreeOfSaturation / (1 - (1 - degreeOfSaturation) * (FsDB * PwsDB / p));  //ASHRAE Eq.(23a)
            relativeHumidity = CaclulateRelativeHumiditySI(p, temperatureDryBulb, temperatureWetBulb);

            // Calculate specific volume
            // Ra = 287.055 / 1000;   // to change gas constant units convert kPa to Pa
            // specificVolume = Ra * (temperatureDryBulb + 273.15) * (1 + 1.6078 * humidityRatio) / p;   //ASHRAE Eq.(26)
            specificVolume = CaclulateSpecificVolumeSI(p, temperatureDryBulb, temperatureWetBulb);

            // Calculate density
            // Density = (1 + humidityRatio) / specificVolume;
            Density = CalculateDensitySI(p, temperatureDryBulb, temperatureWetBulb);

            // Calculate enthalpy
            Enthalpy = 1.006 * temperatureDryBulb + humidityRatio * (2501.0 + 1.805 * temperatureDryBulb);  //ASHRAE Eq.(30)

            return Enthalpy;
        }

        public static double CalculateDewPointSI(double pressure, double temperatureDryBulb, double temperatureWetBulb)
        {
            double PwsDB = 0.0;
            double PwsWB = 0.0;
            double FsDB = 0.0;
            double FsWB = 0.0;
            double degreeOfSaturation;
            double humidityRatio;
            double relativeHumidity;
            double specificVolume;
            double Density;
            double Enthalpy;
            double DEWPoint = 0;

            CalculateVariablesSI(pressure, temperatureDryBulb, temperatureWetBulb, ref PwsDB, ref PwsWB, ref FsDB, ref FsWB);

            // Calculate humidity ratio of the mixture
            //    humidityRatio = ((2501 - 2.381 * temperatureWetBulb) * WsWB - (temperatureDryBulb - temperatureWetBulb)) / (2501 + 1.805 * temperatureDryBulb - 4.186 * temperatureWetBulb);  //ASHRAE Eq.(33)
            humidityRatio = CalculatehumidityRatioSI(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate degree of saturation
            // degreeOfSaturation = humidityRatio / WsDB;           //ASHRAE Eq.(10)
            degreeOfSaturation = CaclulateDegreeOfSaturationSI(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate relative humidity
            // relativeHumidity = degreeOfSaturation / (1 - (1 - degreeOfSaturation) * (FsDB * PwsDB / p));  //ASHRAE Eq.(23a)
            relativeHumidity = CaclulateRelativeHumiditySI(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate specific volume
            // Ra = 287.055 / 1000;   // to change gas constant units convert kPa to Pa
            // specificVolume = Ra * (temperatureDryBulb + 273.15) * (1 + 1.6078 * humidityRatio) / p;   //ASHRAE Eq.(26)
            specificVolume = CaclulateSpecificVolumeSI(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate density
            // Density = (1 + humidityRatio) / specificVolume;
            Density = CalculateDensitySI(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate enthalpy
            // Enthalpy = 1.006 * temperatureDryBulb + humidityRatio * (2501 + 1.805 * temperatureDryBulb);  //ASHRAE Eq.(30)
            Enthalpy = CalculateEnthalpySI(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate dew point temperature
            DEWPoint = CaclulateDewPointSI(pressure, temperatureWetBulb, temperatureDryBulb, humidityRatio);

            return DEWPoint;
        }


        public static void CalculatePropertiesSI(PsychrometricsData data)
        {
            double PwsDB = 0.0;
            double PwsWB = 0.0;
            double FsDB = 0.0;
            double FsWB = 0.0;

            CalculateVariablesSI(data.BarometricPressure, data.DryBulbTemperature, data.WetBulbTemperature, ref PwsDB, ref PwsWB, ref FsDB, ref FsWB);

            // Calculate humidity ratio of the mixture
            //    humidityRatio = ((2501 - 2.381 * data.TemperatureWetBulb) * WsWB - (data.TemperatureDryBulb - data.TemperatureWetBulb)) / (2501 + 1.805 * data.TemperatureDryBulb - 4.186 * data.TemperatureWetBulb);  //ASHRAE Eq.(33)
            data.HumidityRatio = CalculatehumidityRatioSI(data.BarometricPressure, data.DryBulbTemperature, data.WetBulbTemperature);

            // Calculate degree of saturation
            // degreeOfSaturation = humidityRatio / WsDB;           //ASHRAE Eq.(10)
            data.DegreeOfSaturation = CaclulateDegreeOfSaturationSI(data.BarometricPressure, data.DryBulbTemperature, data.WetBulbTemperature);

            // Calculate relative humidity
            // relativeHumidity = degreeOfSaturation / (1 - (1 - degreeOfSaturation) * (FsDB * PwsDB / p));  //ASHRAE Eq.(23a)
            data.RelativeHumidity = CaclulateRelativeHumiditySI(data.BarometricPressure, data.DryBulbTemperature, data.WetBulbTemperature);

            // Calculate specific volume
            // Ra = 287.055 / 1000;   // to change gas constant units convert kPa to Pa
            // specificVolume = Ra * (data.TemperatureDryBulb + 273.15) * (1 + 1.6078 * humidityRatio) / p;   //ASHRAE Eq.(26)
            data.SpecificVolume = CaclulateSpecificVolumeSI(data.BarometricPressure, data.DryBulbTemperature, data.WetBulbTemperature);

            // Calculate density
            // Density = (1 + humidityRatio) / specificVolume;
            data.Density = CalculateDensitySI(data.BarometricPressure, data.DryBulbTemperature, data.WetBulbTemperature);

            // Calculate enthalpy
            // Enthalpy = 1.006 * data.TemperatureDryBulb + humidityRatio * (2501 + 1.805 * data.TemperatureDryBulb);  //ASHRAE Eq.(30)
            data.Enthalpy = CalculateEnthalpySI(data.BarometricPressure, data.DryBulbTemperature, data.WetBulbTemperature);

            // Calculate dew point temperature
            data.DewPoint = CaclulateDewPointSI(data.BarometricPressure, data.WetBulbTemperature, data.DryBulbTemperature, data.HumidityRatio);

            if ((data.HumidityRatio < 0) && (Math.Abs(data.HumidityRatio) < .000001))
            {
                data.HumidityRatio = 0;
            }
        }

        public static void CalculatePropertiesSI(double pressure, double temperatureWetBulb, double temperatureDryBulb, ref double humidityRatio, ref double relativeHumidity, ref double Enthalpy, ref double specificVolume, ref double Density, ref double DEWPoint)
        {
            double PwsDB = 0.0;
            double PwsWB = 0.0;
            double FsDB = 0.0;
            double FsWB = 0.0;
            double degreeOfSaturation;

            CalculateVariablesSI(pressure, temperatureDryBulb, temperatureWetBulb, ref PwsDB, ref PwsWB, ref FsDB, ref FsWB);

            // Calculate humidity ratio of the mixture
            //    humidityRatio = ((2501 - 2.381 * temperatureWetBulb) * WsWB - (temperatureDryBulb - temperatureWetBulb)) / (2501 + 1.805 * temperatureDryBulb - 4.186 * temperatureWetBulb);  //ASHRAE Eq.(33)
            humidityRatio = CalculatehumidityRatioSI(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate degree of saturation
            // degreeOfSaturation = humidityRatio / WsDB;           //ASHRAE Eq.(10)
            degreeOfSaturation = CaclulateDegreeOfSaturationSI(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate relative humidity
            // relativeHumidity = degreeOfSaturation / (1 - (1 - degreeOfSaturation) * (FsDB * PwsDB / p));  //ASHRAE Eq.(23a)
            relativeHumidity = CaclulateRelativeHumiditySI(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate specific volume
            // Ra = 287.055 / 1000;   // to change gas constant units convert kPa to Pa
            // specificVolume = Ra * (temperatureDryBulb + 273.15) * (1 + 1.6078 * humidityRatio) / p;   //ASHRAE Eq.(26)
            specificVolume = CaclulateSpecificVolumeSI(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate density
            // Density = (1 + humidityRatio) / specificVolume;
            Density = CalculateDensitySI(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate enthalpy
            // Enthalpy = 1.006 * temperatureDryBulb + humidityRatio * (2501 + 1.805 * temperatureDryBulb);  //ASHRAE Eq.(30)
            Enthalpy = CalculateEnthalpySI(pressure, temperatureDryBulb, temperatureWetBulb);

            // Calculate dew point temperature
            DEWPoint = CaclulateDewPointSI(pressure, temperatureWetBulb, temperatureDryBulb, humidityRatio);

            if ((humidityRatio < 0) && (Math.Abs(humidityRatio) < .000001))
            {
                humidityRatio = 0;
            }
        }


        //************ Function calculates SI Vapor pressure ************************
        //*********** Partial Pressure of Water Vapor (-100ø to 0ø) ****************
        //*********** Partial Pressure of Water Vapor (0ø-200ø) ********************
        //
        public static double SIPws(double tair)
        {
            double dblSIPws = 0.0;
            double C1;
            double C2;
            double C3;
            double C4;
            double C5;
            double C6;
            double C7;
            double C8;
            double C9;
            double C10;
            double C11;
            double C12;
            double C13;
            double LnPws;
            double t;

            // Calculate saturation pressure at t!
            if (tair >= 0)
            {
                C8 = -5800.2206;
                C9 = -5.516256;
                C10 = -.048640239;
                C11 = .000041764768;
                C12 = -.000000014452093;
                C13 = 6.5459673;
                t = tair + 273.15;
                LnPws = C8 / t + C9 + C10 * t + C11 * t * t + C12 * t * t * t + C13 * Math.Log(t);
                dblSIPws = Math.Exp(LnPws);    //ASHRAE Eq.(4)
            }
            else
            {
                C1 = -5674.5359;
                C2 = -.51523058;
                C3 = -.009677843;
                C4 = .00000062215701;
                C5 = .0000000020747825;
                C6 = -9.484024000000001E-13;
                C7 = 4.1635019;
                t = tair + 273.15;
                if (t != 0.0)
                {
                    LnPws = C1 / t + C2 + C3 * t + C4 * t * t + C5 * t * t * t + C6 * t * t * t * t + C7 * Math.Log(t);
                    dblSIPws = Math.Exp(LnPws);   //ASHRAE Eq.(3)
                }
            }

            return dblSIPws;
        }


        //*** Function to find SIDewPoint
        //*** Converges to the same Humidity Ratio as if you had entered
        //*** saturated conditions (DB=WB)
        public static double CaclulateDewPointSI(double pressure, double temperatureWetBulb, double temperatureDryBulb, double humidityRatio)
        {
            int iLoop;
            double PDEW;
            double lnpw;
            double PwsDP;
            double WSDP;
            double DeltaT;
            double t;
            double DERPws;
            double DERHR;
            double Ppsi = 14.696 * pressure / 101.325;

            double C1 = -5674.5359;
            double C3 = -.009677843;
            double C4 = .00000062215701;
            double C5 = .0000000020747825;
            double C6 = -9.484024000000001E-13;
            double C7 = 4.1635019;

            double C8 = -5800.2206;
            double C10 = -.048640239;
            double C11 = .000041764768;
            double C12 = -.000000014452093;
            double C13 = 6.5459673;
            double C14 = 6.54;
            double C15 = 14.526;
            double C16 = .7389;
            double C17 = .09486;
            double C18 = .4569;

            errno = 0;

            // Method to determine Dew Point - Fs varies with temp - Process in iterative passes.
            double DEWPoint = temperatureWetBulb;
            double tF = DEWPoint * 1.8 + 32.0;
            double FsDP = Fs(tF, Ppsi);

            for (iLoop = 1; iLoop <= 2; iLoop++)      // Makes exactly two passes to get best first estimate
            {
                // Calculate dew point pressure
                PDEW = pressure * humidityRatio / (FsDP * (.62198 + humidityRatio));  //ASHRAE Eq.(34)

                // Calculate dew point temperature - check above and below ice point
                if (DEWPoint < 0)
                {
                    lnpw = Math.Log(PDEW);
                    DEWPoint = 6.09 + 12.608 * lnpw + .4959 * Math.Pow(lnpw, 2.0);   //ASHRAE Eq.(36)
                }
                else
                {
                    C14 = 6.54;
                    C15 = 14.526;
                    C16 = .7389;
                    C17 = .09486;
                    C18 = .4569;
                    lnpw = Math.Log(PDEW);
                    DEWPoint = C14 + C15 * lnpw + C16 * Math.Pow(lnpw, 2.0) + C17 * Math.Pow(lnpw, 3.0) + C18 * Math.Pow((PDEW), .1984);  //ASHRAE Eq.(35)
                }
                tF = DEWPoint * 1.8 + 32.0;
                FsDP = Fs(tF, Ppsi);
            }

            PwsDP = SIPws(DEWPoint);
            double density = (pressure - PwsDP * FsDP);
            WSDP = density != 0.0 ? (0.62198 * PwsDP * FsDP / density) : 0.0;
            DeltaT = 1.0;

            // DavidL, 04/26/2001: Fixed the loop conditions to mimic IPDEWPoint()
            while
                (
                (WSDP != 0.0) &&
                //		((Math.Abs(humidityRatio / WSDP - 1.0) < .000001) || (Math.Abs(DeltaT) < .0001))
                ((Math.Abs(humidityRatio / WSDP - 1.0) >= .000001) || (Math.Abs(DeltaT) >= .0001))
                )
            {
                PwsDP = SIPws(DEWPoint);
                tF = DEWPoint * 1.8 + 32.0;
                FsDP = Fs(tF, Ppsi);
                density = (pressure - PwsDP * FsDP);
                WSDP = density != 0.0 ? (0.62198 * PwsDP * FsDP / density) : 0.0;

                //Calculate DERivative of Vapor Pressure
                t = DEWPoint + 273.15;
                if (DEWPoint >= 0)
                {
                    DERPws = t != 0.0 ?
                        (PwsDP * (-C8 / Math.Pow(t, 2.0) + C10 + 2.0 * C11 * t + 3.0 * C12 * t * t + C13 / t)) : 0.0;
                }
                else
                {
                    DERPws = t != 0.0 ?
                        (PwsDP * (-C1 / Math.Pow(t, 2.0) + C3 + 2.0 * C4 * t + 3.0 * C5 * t * t + 4.0 * C6 * Math.Pow(t, 3.0) + C7 / t)) : 0.0;
                }
                //*****************************************************************************

                //Calculate DERivative of Humidity Ratio
                density = Math.Pow((pressure - FsDP * PwsDP), 2.0);
                if (density != 0.0)
                    DERHR = ((pressure - PwsDP * FsDP) * 0.62198 * FsDP * DERPws - (.62198 * FsDP * PwsDP) * (-FsDP * DERPws)) / density;
                else
                    DERHR = 0.0;

                //Converge to given humidityRatio using Newton-Raphson Method
                //Yields abref one order of magnitude correction per iteration

                DeltaT = DERHR != 0.0 ? ((humidityRatio - WSDP) / DERHR) : 0.0;
                DEWPoint = DEWPoint + DeltaT;
            }

            if (errno != 0)
            {
                DEWPoint = 0.0;
            }

            return DEWPoint;
        }

        public static double StandardAtmosphericPressure(double Z) 
        {
            Z /= 10000.0;
            return (.491154 * ((.547462 * Z - 7.67923) * Z + 29.9309) / (.10803 * Z + 1.0));
        }

        //public static double CalculateMerkel(double Twb, double Ran, double Apr, double LG, double elevation)  // used by demand curve
        //{
        //    short i;
        //    double KaV, Ha, Haex, Hain, Hw, Tcold, Thot, Tw;
        //    double[] X = new double[4] { 0.9, 0.6, 0.4, 0.1 };
        //    double pressure = 14.696;

        //    //	Hain = Hdbw(Twb,Wsat(Twb));  // produces 33.17 with defaults
        //    //  Tdb = Twb + Ran;
        //    //  Hain = CalcEnthalpyIP(14.696, Twb, Twb);

        //    if (elevation != 0)
        //    {
        //        pressure = Pstd(elevation);
        //    }
        //    Hain = CalculateEnthalpy(pressure, Twb, Twb);
        //    Haex = Hain + Ran * LG;
        //    Tcold = Twb + Apr;
        //    Thot = Tcold + Ran;
        //    if (Thot >= Tboil)
        //    {
        //        return (999);
        //    }

        //    KaV = 0;
        //    for (i = 0; i < 4; i++)
        //    {
        //        Tw = Tcold + X[i] * Ran;
        //        //		Hw = Hdbw( Tw, Wsat(Tw) );
        //        //      Hw = CalcEnthalpyIP(14.696, Tw, Tw);
        //        Hw = CalculateEnthalpy(pressure, Tw, Tw);
        //        Ha = Hain + X[i] * (Haex - Hain);
        //        if (Hw <= Ha) return (999);
        //        KaV += .25 / (Hw - Ha);
        //    }
        //    return KaV * Ran;
        //}

        // double Twb - merkelData.WetBulbTemperature
        // double Ran - merkelData.Range
        // double Apr - merkelData.Approach
        // double LG - merkelData.WaterAirRatio
        // double Elev - merkelData.Elevation
        public static double CalculateMerkel(MerkelData merkelData)
        {
            short i;
            double KaV, Ha, Haex, Hain, Hw, Tcold, Thot, Tw;
            double[] X = new double[4] { 0.9, 0.6, 0.4, 0.1 };
            double pressure = 14.696;

            if (merkelData.Elevation != 0)
            {
                pressure = StandardAtmosphericPressure(merkelData.Elevation);
            }
            Hain = CalculateEnthalpy(pressure, merkelData.WetBulbTemperature, merkelData.WetBulbTemperature);
            Haex = Hain + merkelData.Range * merkelData.LiquidToGasRatio;
            Tcold = merkelData.WetBulbTemperature + merkelData.Approach;
            Thot = Tcold + merkelData.Range;
            if (Thot >= Tboil)
            {
                return (999);
            }

            KaV = 0;
            for (i = 0; i < 4; i++)
            {
                Tw = Tcold + X[i] * merkelData.Range;
                Hw = CalculateEnthalpy(pressure, Tw, Tw);
                Ha = Hain + X[i] * (Haex - Hain);
                if (Hw <= Ha) return (999);
                KaV += .25 / (Hw - Ha);
            }

            merkelData.KaV_L = KaV * merkelData.Range;

            return merkelData.KaV_L;
        }

        public static double KAVL(double T1, double T2, double WBT, double LG) // used by merkel calculation
        {
            double dblKAVL = 0.0;

            double humidityRatio = 0.0;
            double relativeHumidity = 0.0;
            double specificVolume = 0.0;
            double Density = 0.0;
            double DEWPoint = 0.0;

            double Tt1 = T2 + .1 * (T1 - T2);
            double Tt2 = T2 + .4 * (T1 - T2);
            double Tt3 = T1 - .4 * (T1 - T2);
            double Tt4 = T1 - .1 * (T1 - T2);

            double Hw1 = 0.0;
            double Hw2 = 0.0;
            double Hw3 = 0.0;
            double Hw4 = 0.0;
            CalculatePropertiesIP(14.696, Tt1, Tt1, ref humidityRatio, ref relativeHumidity, ref Hw1, ref specificVolume, ref Density, ref DEWPoint);
            CalculatePropertiesIP(14.696, Tt2, Tt2, ref humidityRatio, ref relativeHumidity, ref Hw2, ref specificVolume, ref Density, ref DEWPoint);
            CalculatePropertiesIP(14.696, Tt3, Tt3, ref humidityRatio, ref relativeHumidity, ref Hw3, ref specificVolume, ref Density, ref DEWPoint);
            CalculatePropertiesIP(14.696, Tt4, Tt4, ref humidityRatio, ref relativeHumidity, ref Hw4, ref specificVolume, ref Density, ref DEWPoint);

            double HaStart = 0.0;
            double HaEnd = 0.0;
            CalculatePropertiesIP(14.696, WBT, WBT, ref humidityRatio, ref relativeHumidity, ref HaStart, ref specificVolume, ref Density, ref DEWPoint);
            HaEnd = HaStart + LG * (T1 - T2);

            double Ha1 = HaStart + .1 * LG * (T1 - T2);
            double Ha2 = HaStart + .4 * LG * (T1 - T2);
            double Ha3 = HaEnd - .4 * LG * (T1 - T2);
            double Ha4 = HaEnd - .1 * LG * (T1 - T2);

            double dH1 = Hw1 - Ha1;
            double dH2 = Hw2 - Ha2;
            double dH3 = Hw3 - Ha3;
            double dH4 = Hw4 - Ha4;

            if ((dH1 == 0.0) || (dH2 == 0.0) || (dH3 == 0.0) || (dH4 == 0.0))
                dblKAVL = 0.0;
            else
                dblKAVL = ((T1 - T2) / 4.0) * ((1.0 / dH1) + (1.0 / dH2) + (1.0 / dH3) + (1.0 / dH4));

            return dblKAVL;
        }

        /*
        double Math.Abs(double dblNum)
        {
            double dblabs = dblNum;

            if (dblNum < 0.0)
            {
                dblabs = dblNum * -1.0;
            }

            return dblabs;
        }
        */

        //public static double Interpolate(double top, double inc, int nvals, double Twb, double Ran, double Apr, double LG, double Elev)
        //{
        //    double next = 0.0;
        //    double intervals;
        //    double begin = CalculateMerkel(Twb, Ran, Apr, LG - inc, Elev);

        //    if (begin > top) return 0.0;  // Merkel returns 999 on error condition

        //    // determine where line crosses y-axis
        //    for (double x = LG - inc; x <= LG + inc; x += 0.01)
        //    {
        //        next = CalculateMerkel(Twb, Ran, Apr, x, Elev);
        //        if (next >= top)
        //        {
        //            break;
        //        }
        //    }

        //    // determine increment amount
        //    if (nvals > 0)
        //        intervals = (next - begin) / ((double)nvals);
        //    else
        //        intervals = (next - begin) / 99.0;

        //    return intervals;
        //}

        /* from bluebook
        dbl Hdbw(dbl Tdb,dbl W)                        
        {
          return(.24*Tdb+W*(1061.+.444*Tdb));
        }
        */

        public static double Hdbw(double Tdb, double W)
        {
            return (.24 * Tdb + W * (1061.0 + 0.444 * Tdb));
        }

        public static double Wsat(double Ts)
        {
            double Psat;
            Psat = Pwsat(Ts);
            double density = (Patm - Psat);
            return (density != 0.0 ? (0.62198 * Psat / density) : 0.0);
        }

        public static double Pwsat(double Ts)
        {
            Ts += 459.67;
            return (Ts != 0.0 ? Math.Exp(((-2.478068E-9 * Ts + .00001289036) * Ts - .027022355) * Ts - 11.2946496 - 10440.39708 / Ts + 6.5459673 * Math.Log(Ts)) : 0.0);
        }

        public static double RelativeHumidityityIP(double psi, double temperatureWetBulb, double temperatureDryBulb)
        {
            if (psi == 0.0)
                return 0.0;

            double PwsWB = (IPPws(temperatureWetBulb));
            double Pwsdb = (IPPws(temperatureDryBulb));
            double FsWB = (Fs(temperatureWetBulb, psi));
            double Fsdb = (Fs(temperatureDryBulb, psi));
            double density = (psi - PwsWB * FsWB);
            double Wswb = (density != 0.0 ? (0.62198 * PwsWB * FsWB / density) : 0.0);  // 'ASHRAE Eq.(21a)
            density = (psi - Pwsdb * Fsdb);
            double Wsdb = (density != 0.0 ? (0.62198 * Pwsdb * Fsdb / density) : 0.0);  // 'ASHRAE Eq.(21a)
            density = (1093.0 + .444 * temperatureDryBulb - temperatureWetBulb);
            double humidityRatio = (density != 0.0 ? (((1093.0 - .556 * temperatureWetBulb) * Wswb - .24 * (temperatureDryBulb - temperatureWetBulb)) / density) : 0.0); // 'ASHRAE Eq.(33)
            double degreeOfSaturation = (Wsdb != 0.0 ? (humidityRatio / Wsdb) : 0.0);
            density = (1.0 - (1.0 - degreeOfSaturation) * (Fsdb * Pwsdb / psi));
            double relativeHumidityity = (density != 0.0 ? (degreeOfSaturation / density) : 0.0);
            return relativeHumidityity;
        }

        //        public static void WBsearchIP(double psi, double relativeHumidity, double temperatureDryBulb, ref double temperatureWetBulb)
//        public static double CalculatetemperatureWetBulbIP(PsychrometricsData data)
        public static double CalculateTemperatureWetBulbIP(double psi, double relativeHumidity, double temperatureDryBulb)
        {
            double temptolerance = .0005;
            double RHtolerance = .00005;
            double RHhigh;
            double RHmid;

            //Calculate saturation value and compare to program and tolerance limits
            RHhigh = RelativeHumidityityIP(psi, temperatureDryBulb, temperatureDryBulb);
            if (Math.Abs(RHhigh - relativeHumidity) <= RHtolerance)
            {
                return temperatureDryBulb;
            }

            // Begin bisection root search procedure from Numerical Recipes in BASIC, p 193   
            double t1 = 0.0;
            double t2 = temperatureDryBulb;
            double trtbis = t1;
            double DT = t2 - t1;
            double tmid;
            int count = 0;
            do
            {
                count++;
                DT = DT / 2;
                tmid = trtbis + DT;
                RHmid = relativeHumidity - RelativeHumidityityIP(psi, tmid, temperatureDryBulb);
                if (RHmid >= 0.0) trtbis = tmid;
            }
            while ((Math.Abs(DT) >= temptolerance) && (RHmid != 0.0));

            // found wet bulb
            return tmid;
        }

//        public static void WBsearchSI(double psi, double relativeHumidity, double temperatureDryBulb, ref double temperatureWetBulb)
        public static double CalculateTemperatureWetBulbSI(double psi, double relativeHumidity, double temperatureDryBulb)
        {
            double temptolerance = .0005;
            double RHtolerance = .00005;

            //Calculate saturation value and compare to program and tolerance limits
            //double RHhigh = CalculaterelativeHumiditySI(psi, temperatureDryBulb, temperatureDryBulb);
            double RHhigh = CalculateRelativeHumiditySI(psi, temperatureDryBulb, temperatureDryBulb);
            if (Math.Abs(RHhigh - relativeHumidity) <= RHtolerance)
            {
                return temperatureDryBulb;
            }

            //Begin bisection root search procedure from Numerical Recipes in BASIC, p 193
            double t1 = -20;
            double t2 = temperatureDryBulb;
            double trtbis = t1;
            double DT = t2 - t1;
            double RHmid;
            double tmid;

            do
            {
                DT = DT / 2.0;
                tmid = trtbis + DT;
                RHmid = relativeHumidity - CalculateRelativeHumiditySI(psi, tmid, temperatureDryBulb);
                if (RHmid >= 0.0) trtbis = tmid;
            }
            while ((Math.Abs(DT) >= temptolerance) && (RHmid != 0.0));

            return tmid;
        }

        public static double CalculateRelativeHumiditySI(double psi, double temperatureWetBulb, double temperatureDryBulb)
        {
            if (psi == 0.0)
                return 0.0;

            double PwsWB = (SIPws(temperatureWetBulb));
            double Pwsdb = (SIPws(temperatureDryBulb));
            double tF = (temperatureDryBulb * 1.8 + 32.0);
            double Ppsi = (14.696 * psi / 101.325);
            double Fsdb = (Fs(tF, Ppsi));
            tF = temperatureWetBulb * 1.8 + 32.0;
            double FsWB = Fs(tF, Ppsi);

            double density = (psi - PwsWB * FsWB);
            double Wswb = (density != 0.0 ? (0.62198 * PwsWB * FsWB / density) : 0.0); // 'ASHRAE Eq.(21a)
            density = (psi - Pwsdb * Fsdb);
            double Wsdb = (density != 0.0 ? (0.62198 * Pwsdb * Fsdb / density) : 0.0); // 'ASHRAE Eq.(21a)
            density = (2501.0 + 1.805 * temperatureDryBulb - 4.186 * temperatureWetBulb);
            double humidityRatio = (density != 0.0 ? (((2501.0 - 2.381 * temperatureWetBulb) * Wswb - (temperatureDryBulb - temperatureWetBulb))) / density : 0.0); //   'ASHRAE Eq.(33)
            double degreeOfSaturation = (Wsdb != 0.0 ? (humidityRatio / Wsdb) : 0.0);
            density = (1.0 - (1.0 - degreeOfSaturation) * (Fsdb * Pwsdb / psi));
            double relativeHumidityity = (density != 0.0 ? (degreeOfSaturation / density) : 0.0);
            return relativeHumidityity;
        }

        //public static void SIEnthalpysearch(int sat,
        //                       double p,
        //                       double RootEnthalpy,
        //                       ref double OutputEnthalpy,
        //                       ref double temperatureWetBulb,
        //                       ref double temperatureDryBulb,
        //                       double humidityRatio,
        //                       double relativeHumidity,
        //                       double specificVolume,
        //                       double Density,
        //                       double DEWPoint
        //                       )
        // overwritten temperatureWetBulb temperatureDryBulb
        public static double EnthalpySI(int sat, PsychrometricsData data)
        {
            double OutputEnthalpy = 0.0;

            // Establish tolerance on enthalpy search
            double temptolerance = 0.001;
            double Htolerance = 0.00005;

            // First need to bracket region of WB/DB to created bisection region
            // High and low values are respectively:
            double Tlower = -18.0;
            double Tupper = 93.0;
            double hmid = 0.0;
            double RootEnthalpy = data.Enthalpy;

            // Calculate low value and compare to program and tolerance limits
            data.WetBulbTemperature = Tlower;
            if (sat == 1)
            {
                data.DryBulbTemperature = data.WetBulbTemperature;
            }

            data.Enthalpy = 0.0;

            CalculatePropertiesSI(data);

            if (Math.Abs(data.Enthalpy - RootEnthalpy) <= Htolerance)
            {
                return 0.0;
            }

            if (RootEnthalpy < data.Enthalpy)
            {
                return -999.0; // DDP ref of range	
            }

            // Calculate high value and compare to program and tolerance limits
            data.WetBulbTemperature = Tupper;

            if (sat == 1)
            {
                data.DryBulbTemperature = data.WetBulbTemperature;
            }

            data.Enthalpy = 0.0;

            CalculatePropertiesSI(data);

            if (Math.Abs(data.Enthalpy - RootEnthalpy) <= Htolerance)
            {
                return 0.0;
            }

            if (RootEnthalpy > data.Enthalpy)
            {
                return -999.0; // DDP ref of range
            }

            // Begin bisection root search procedure from Numerical Recipes in BASIC, p 193
            double trtbis = Tlower;
            double DT = Tupper - Tlower;
            double tmid;
            do
            {
                DT = DT / 2.0;
                tmid = trtbis + DT;

                data.WetBulbTemperature = tmid;

                if (sat == 1)
                {
                    data.DryBulbTemperature = tmid;
                }

                CalculatePropertiesSI(data);

                hmid = RootEnthalpy - data.Enthalpy;

                if (hmid >= 0.0)
                {
                    trtbis = tmid;
                }
            }
            while ((Math.Abs(DT) >= temptolerance) && (hmid != 0.0));

            data.WetBulbTemperature = tmid;

            if (sat == 1)
            {
                data.DryBulbTemperature = tmid;
            }

            OutputEnthalpy = data.Enthalpy;
            return OutputEnthalpy;
        }

        public static void CalculatePerformanceData(int INUM, double[] X, double[] YMEAS, double XREAL, ref double YFIT, double[] Y2)
        {
            //'						I			I			I				I				O			O
            //'  EXAMPLE:			4			2			112
            //'						9			113
            //'						16			114
            //'						23			115
            //'     DIM YMEASP(INUM)

            //' DETERMINE THE SECOND DERIVITATIVES FOR THE SPLINE INTERPOLATION

            SPLINE(X, YMEAS, INUM, 1E+31, 1E+31, Y2);

            //' DETERMINE INTERPOLATED VALUES
            SPLINT(X, YMEAS, Y2, INUM, XREAL, ref YFIT);

            //'ERASE YMEASP
        }

        public static void SPLINE(double[] X, double[] Y, int INUM, double YP1, double YPN, double[] Y2)
        {
            //'Cubic Spline subroutine from Numerical Recipes in BASIC (1994), p43
            double QN;
            double UN;
            double[] U = new double[INUM];
            int I;

            // Check preconditions
            if (INUM < 2)
            {
                //todo ASSERT(0);
                return;
            }
            for (I = 1; I < INUM; I++)
            {
                if (X[I - 1] >= X[I])
                {
                    //todo ASSERT(0);
                    return;
                }
            }

            if (YP1 > 9.9E+29)
            {
                Y2[0] = 0.0;
                U[0] = 0.0;
            }
            else
            {
                Y2[0] = -.5;
                U[0] = (3.0 / (X[1] - X[0])) * ((Y[1] - Y[0]) / (X[1] - X[0]) - YP1);
            }

            for (I = 1; I < INUM - 1; I++)
            {
                double SIG = (X[I] - X[I - 1]) / (X[I + 1] - X[I - 1]);
                double P = SIG * Y2[I - 1] + 2.0;
                Y2[I] = (SIG - 1.0) / P;
                double DUM1 = (Y[I + 1] - Y[I]) / (X[I + 1] - X[I]);
                double DUM2 = (Y[I] - Y[I - 1]) / (X[I] - X[I - 1]);
                U[I] = (6.0 * (DUM1 - DUM2) / (X[I + 1] - X[I - 1]) - SIG * U[I - 1]) / P;
            }

            if (YPN > 9.9E+29)
            {
                QN = 0.0;
                UN = 0.0;
            }
            else
            {
                QN = .5;
                //todo is it IN or INUM UN = (3.0 / (X[INUM - 1] - X[INUM - 2])) * (YPN - (Y[INUM - 1] - Y[IN - 2]) / (X[INUM - 1] - X[INUM - 2]));
                UN = (3.0 / (X[INUM - 1] - X[INUM - 2])) * (YPN - (Y[INUM - 1] - Y[INUM - 2]) / (X[INUM - 1] - X[INUM - 2]));
            }

            Y2[INUM - 1] = (UN - QN * U[INUM - 2]) / (QN * Y2[INUM - 2] + 1.0);

            for (int K = INUM - 2; K >= 0; K--)
            {
                Y2[K] = Y2[K] * Y2[K + 1] + U[K];
            }
        }

        public static void SPLINT(double[] XA, double[] YA, double[] Y2A, int INUM, double X, ref double Y)
        {
            //' Determine interpolated Y value
            //' Rev: 2-22-99 to handle either Increasing or Decreasing XA array
            if ((INUM < 2) || (XA[0] == XA[1]))
            {
                //todo //todo ASSERT(0);
                return;
            }

            int ILO = 0;
            int IHI = (INUM - 1);
            bool bIncreasingX = (XA[1] > XA[0]);

            while (IHI - ILO > 1)
            {
                int II = ((IHI + ILO) / 2);
                if (bIncreasingX)
                {
                    if (XA[II] > X)
                    {
                        IHI = II;
                    }
                    else
                    {
                        ILO = II;
                    }
                }
                else               //X DECREASING
                {
                    if (XA[II] > X)
                    {
                        ILO = II;
                    }
                    else
                    {
                        IHI = II;
                    }
                }
            }

            double DX = (XA[IHI] - XA[ILO]);
            if (DX == 0.0)
            {
                //todo ASSERT(0); //"BAD XA INPUT"
                return;
            }
            double A = ((XA[IHI] - X) / DX);
            double B = ((X - XA[ILO]) / DX);
            Y = A * YA[ILO] + B * YA[IHI];

            // Change suggested by Rich Harrison on Aug. 3, 2001:
            // Do just the linear fit (last calc above) if x is beyond array range
            if (((bIncreasingX) && (X > XA[0]) && (X < XA[INUM - 1])) || ((!bIncreasingX) && (X > XA[INUM - 1]) && (X < XA[0])))
            {
                Y += ((Math.Pow(A, 3.0) - A) * Y2A[ILO] + (Math.Pow(B, 3.0) - B) * Y2A[IHI]) * (Math.Pow(DX, 2.0)) / 6.0;
            }
        }


        public static double CalcTestLG(double dblDesignLG, double dblDesignFlow, double dblTestFlow, double dblDesignFanPower, double dblTestFanPower, double dblDesignAirDensity, double dblTestAirDensity, double dblDesignspecificVolume, double dblTestspecificVolume)
        {
            double dblReturn;

            dblReturn = dblDesignLG * (dblTestFlow / dblDesignFlow) * Math.Pow((dblDesignFanPower / dblTestFanPower), (1.0 / 3.0)) * (dblTestAirDensity / dblDesignAirDensity) * Math.Pow((dblTestspecificVolume / dblDesignspecificVolume), (1.0 / 3.0));

            return dblReturn;
        }


        public static double CalcAdjustedFlow(double dblTestWaterFlowRate, double dblDesignFanDriverPower, double dblTestFanDriverPower, double dblDesignAirDensity, double dblTestAirDensity)
        {
            double dblReturn;

            dblReturn = dblTestWaterFlowRate * Math.Pow((dblDesignFanDriverPower / dblTestFanDriverPower), (1.0 / 3.0)) * Math.Pow((dblTestAirDensity / dblDesignAirDensity), (1.0 / 3.0));

            return dblReturn;
        }

// 	                        Determineoutput.AdjustedFlow(!TPropPageBase::metricflag, (int)m_filePerfData.m_designData.m_fnGetInducedFlow(), m_dblDesignHWT,                             m_dblDesignCWT,                              m_dblDesignWBT,                            m_dblDesignDBT,                             m_dblDesignBarometricPressure,            m_dblDesignWaterFlowRate,              m_dblDesignFanDriverPower,              m_dblDesignLG,                           m_dblTestHWT,                             m_dblTestCWT,                              m_dblTestWBT,                             m_dblTestDBT,                            m_dblTestBarometricPressure,             m_dblTestWaterFlowRate,             m_dblTestFanDriverPower,              LWBTnew,            output.Density,            output.SpecificVolume,             output.WetBuldTemperature,           dblAdjustedFlow,        m_dblTestLG);

       public static double Determineoutput.AdjustedFlow(int IunitsIP,                int IInduced,                                         double data.DesignData.HotWaterTemperature, double data.DesignData.ColdWaterTemperature, double data.DesignData.WetBulbTemperature, double data.DesignData.DryBulbTemperature,  double data.DesignData.BarometricPressure, double data.DesignData.WaterFlowRate, double data.DesignData.FanDriverPower,  double data.DesignData.LiquidToGasRatio, double testPsychrometricsData.HotWaterTemperature, double testPsychrometricsData.ColdWaterTemperature, double testPsychrometricsData.WetBulbTemperature,  double testPsychrometricsData.DryBulbTemperature, double testPsychrometricsData.BarometricPressure, double testPsychrometricsData.WaterFlowRate,  double testPsychrometricsData.FanDriverPower, ref double LWBTnew, ref double output.Density, ref double output.SpecificVolume, ref double output.WetBuldTemperature, ref double output.AdjustedFlow, ref double output.LiquidToGasRatio)
        {
            //'                         I             I                I            I             I           I            I           I             I            I             I            I            I            I            I           I             I            O                 O                O               O              O
            //'                                       <------------------------------------------ DESIGN VALUES ------------------------------------------------------>  <------------------------------------ TEST VALUES -------------------------------------->  <------------------------------------ OUTPUT VALUES -------------------------------->
            //' Determine Adjusted Test Flow value based on Design and Test conditions
            //' IInduced =1 Induced Draft units - compute output.AdjustedFlow on LEAVING air temperatures
            //'          =0 Forced Draft units  - compute output.AdjustedFlow on ENTERING air temperatures - NO ITERATION REQ'D

            //string strTemp;
            double Cpw = 0;
            double data.DesignData.HumidityRatio = 0;
            double data.DesignData.RelativeHumidity = 0;
            double data.DesignData.Enthalpy = 0;
            double data.DesignData.SpecificVolume = 0;
            double data.DesignData.Density = 0;
            double data.DesignData.DewPoint = 0;
            double testPsychrometricsData.HumidityRatio = 0;
            double testPsychrometricsData.RelativeHumidity = 0;
            double testPsychrometricsData.Enthalpy = 0;
            double testPsychrometricsData.SpecificVolume = 0;
            double testPsychrometricsData.Density = 0;
            double testPsychrometricsData.DewPoint = 0;
            double HOutD = 0;
            double OutputEnthalpy = 0;
            double LWBD = 0;
            double LDBD = 0;
            double humidityRatio = 0;
            double relativeHumidity = 0;
            double SVOutD = 0;
            double DenOutD = 0;
            double DEWPoint = 0;
            double DenDesign = 0;
            double SVDesign = 0;
            double LWBT = 0;
            double WOutT = 0;
            double RHOutT = 0;
            double DEWPointOutT = 0;
            double HCalcT = 0;
            double LDBTnew = 0;
            double specificVolume = 0;
            double Density = 0;
            double DenTest = 0;

            output.LiquidToGasRatio = 0;

            //' Design Entering Air Conditions
            if (IunitsIP == 1)
            {
                data.DesignData.BarometricPressure = 14.696 * data.DesignData.BarometricPressure / 29.921;    //'Convert to Psi  Else assumed kPa
                Cpw = 1.0;                      //'IP specific heat at constant pressure
        ic void CalculatePropertiesIP(double pressure, double temperatureWetBulb, double temperatureDryBulb,                                     ref double humidityRatio,           ref double relativeHumidity,          ref double Enthalpy,          ref double specificVolume,          ref double Density,          ref double DEWPoint)
                CalculatePropertiesIP(data.DesignData.BarometricPressure, data.DesignData.WetBulbTemperature, data.DesignData.DryBulbTemperature, ref data.DesignData.HumidityRatio, ref data.DesignData.RelativeHumidity, ref data.DesignData.Enthalpy, ref data.DesignData.SpecificVolume, ref data.DesignData.Density, ref data.DesignData.DewPoint);
                //CalcPropertiesIP(data.DesignData.BarometricPressure, data.DesignData.WetBulbTemperature, data.DesignData.DryBulbTemperature, data.DesignData.HumidityRatio, data.DesignData.RelativeHumidity, data.DesignData.Enthalpy, data.DesignData.SpecificVolume, data.DesignData.Density, data.DesignData.DewPoint);
            }
            else //'SI
            {
                Cpw = 4.186;                    //'SI specific heat at constant pressure
                CalculatePropertiesSI(data.DesignData.BarometricPressure, data.DesignData.WetBulbTemperature, data.DesignData.DryBulbTemperature, ref data.DesignData.HumidityRatio, ref data.DesignData.RelativeHumidity, ref data.DesignData.Enthalpy, ref data.DesignData.SpecificVolume, ref data.DesignData.Density, ref data.DesignData.DewPoint);
                //CalcPropertiesSI(data.DesignData.BarometricPressure, data.DesignData.WetBulbTemperature, data.DesignData.DryBulbTemperature, data.DesignData.HumidityRatio, data.DesignData.RelativeHumidity, data.DesignData.Enthalpy, data.DesignData.SpecificVolume, data.DesignData.Density, data.DesignData.DewPoint);
            }

            //PRINT #2, USING "Design: data.DesignData.WaterFlowRate=#####.###  data.DesignData.FanDriverPower=###.#### data.DesignData.LiquidToGasRatio=#.####"; data.DesignData.WaterFlowRate; data.DesignData.FanDriverPower; data.DesignData.LiquidToGasRatio
            //PRINT #2, USING "    data.DesignData.HotWaterTemperature=###.###  data.DesignData.ColdWaterTemperature=###.###  RangeD=##.###  AppD=##.###"; data.DesignData.HotWaterTemperature; data.DesignData.ColdWaterTemperature; data.DesignData.HotWaterTemperature - data.DesignData.ColdWaterTemperature; data.DesignData.ColdWaterTemperature - testPsychrometricsData.WetBulbTemperature
            //PRINT #2, USING "    WBd=###.## DBd=###.## BP=###.###  Win=#.#####"; data.DesignData.WetBulbTemperature; data.DesignData.DryBulbTemperature; data.DesignData.BarometricPressure; data.DesignData.HumidityRatio
            //PRINT #2, USING "    data.DesignData.Enthalpy=###.#### data.DesignData.SpecificVolume=##.##### data.DesignData.Density=#.##### data.DesignData.RelativeHumidity=###.##% data.DesignData.DewPoint=##.##"; data.DesignData.Enthalpy; data.DesignData.SpecificVolume; data.DesignData.Density; data.DesignData.RelativeHumidity * 100!; data.DesignData.DewPoint
            //PRINT #2,

            //' Test Entering Air Conditions
            // Try using this calculation for Forced Draft enthalpy, sp. vol, and density values
            // (Toolkit v3.0 Build #5, DBL - 05/23/03)
            if (IunitsIP == 1) //'IP
            {
                testPsychrometricsData.BarometricPressure = 14.696 * testPsychrometricsData.BarometricPressure / 29.921;        //'Convert to Psi  Else assumed kPa
        ic void CalculatePropertiesIP(double pressure, double temperatureWetBulb, double temperatureDryBulb,                                ref double humidityRatio,        ref double relativeHumidity,         ref double Enthalpy,        ref double specificVolume,          ref double Density,          ref double DEWPoint)
                CalculatePropertiesIP(testPsychrometricsData.BarometricPressure, testPsychrometricsData.WetBulbTemperature, testPsychrometricsData.DryBulbTemperature, ref testPsychrometricsData.HumidityRatio, ref testPsychrometricsData.RelativeHumidity,  ref testPsychrometricsData.Enthalpy, ref testPsychrometricsData.SpecificVolume,   ref testPsychrometricsData.Density, ref testPsychrometricsData.DewPoint);
                //CalcPropertiesIP(testPsychrometricsData.BarometricPressure, testPsychrometricsData.WetBulbTemperature, testPsychrometricsData.DryBulbTemperature, testPsychrometricsData.HumidityRatio, testPsychrometricsData.RelativeHumidity, testPsychrometricsData.Enthalpy, testPsychrometricsData.SpecificVolume, testPsychrometricsData.Density, testPsychrometricsData.DewPoint);
            }
            else //'SI
            {
                CalculatePropertiesSI(testPsychrometricsData.BarometricPressure, testPsychrometricsData.WetBulbTemperature, testPsychrometricsData.DryBulbTemperature, ref testPsychrometricsData.HumidityRatio, ref testPsychrometricsData.RelativeHumidity, ref testPsychrometricsData.Enthalpy, ref testPsychrometricsData.SpecificVolume, ref testPsychrometricsData.Density, ref testPsychrometricsData.DewPoint);
                //CalcPropertiesSI(testPsychrometricsData.BarometricPressure, testPsychrometricsData.WetBulbTemperature, testPsychrometricsData.DryBulbTemperature, testPsychrometricsData.HumidityRatio, testPsychrometricsData.RelativeHumidity, testPsychrometricsData.Enthalpy, testPsychrometricsData.SpecificVolume, testPsychrometricsData.Density, testPsychrometricsData.DewPoint);
            }

            //   PRINT #2, USING "Test:  testPsychrometricsData.WaterFlowRate=#####.### testPsychrometricsData.FanDriverPower=###.####"; testPsychrometricsData.WaterFlowRate; testPsychrometricsData.FanDriverPower
            //   PRINT #2, USING "    testPsychrometricsData.HotWaterTemperature=###.###  testPsychrometricsData.ColdWaterTemperature=###.###  RangeT=##.###  AppT=##.###"; testPsychrometricsData.HotWaterTemperature; testPsychrometricsData.ColdWaterTemperature; testPsychrometricsData.HotWaterTemperature - testPsychrometricsData.ColdWaterTemperature; testPsychrometricsData.ColdWaterTemperature - testPsychrometricsData.WetBulbTemperature
            //   PRINT #2, USING "    WBt=###.## DBt =###.## testPsychrometricsData.BarometricPressure=###.### testPsychrometricsData.HumidityRatio=#.#####"; testPsychrometricsData.WetBulbTemperature; testPsychrometricsData.DryBulbTemperature; testPsychrometricsData.BarometricPressure; testPsychrometricsData.HumidityRatio
            //   PRINT #2, USING "    testPsychrometricsData.Enthalpy=###.#### testPsychrometricsData.SpecificVolume=##.#### testPsychrometricsData.Density=#.##### testPsychrometricsData.RelativeHumidity=###.##% testPsychrometricsData.DewPoint=##.##"; testPsychrometricsData.Enthalpy; testPsychrometricsData.SpecificVolume; testPsychrometricsData.Density; testPsychrometricsData.RelativeHumidity * 100!; testPsychrometricsData.DewPoint
            //   PRINT #2,


            if (IInduced == 1)      //'compute output.AdjustedFlow on LEAVING air temperatures
            {
                //'  LEAVING AIR CONDITIONS - Predicted Leaving Wet Bulb

                //'First determine Design Leaving Air Density, DenOutD  *****************************
                //'first step is determine Leaving air Enthalpy Design, HOutD
                HOutD = data.DesignData.Enthalpy + data.DesignData.LiquidToGasRatio * Cpw * (data.DesignData.HotWaterTemperature - data.DesignData.ColdWaterTemperature);

                //'Call Enthalpy Search subroutine with calculated HOutD value
                if (IunitsIP == 1)  //'IP
                {
                    EnthalpysearchIP(1, data.DesignData.BarometricPressure, HOutD, ref OutputEnthalpy, ref LWBD, ref LDBD, ref humidityRatio, ref relativeHumidity, ref SVOutD, ref DenOutD, ref DEWPoint);
                }   //'SI
                else
                {
                    EnthalpysearchSI(1, data.DesignData.BarometricPressure, HOutD, ref OutputEnthalpy, ref LWBD, ref LDBD, ref humidityRatio, ref relativeHumidity, ref SVOutD, ref DenOutD, ref DEWPoint);
                }

                //'Store Density Out as Density Design and SV Out as SV Design
                DenDesign = DenOutD;
                SVDesign = SVOutD;

                //    PRINT USING "Design Out: LWBD=###.####   DenOutD=#.#####  SVOutD=##.#####"; LWBD; DenOutD; SVOutD
                //    PRINT #2, USING "Design Out: LWBD=###.####   DenOutD=#.#####  SVOutD=##.#####"; LWBD; DenOutD; SVOutD
                //'***********************************************************************************

                //'Next Iterate to find Test Leaving Wet bulb and output.Density
                //'Initial guess of Leaving Wet Bulb is average of Test Entering and Leaving temperature
                LWBT = (testPsychrometricsData.HotWaterTemperature + testPsychrometricsData.ColdWaterTemperature) / 2.0;

                bool bGoto200 = true;
                while (bGoto200)
                {
                    //200 'Top of iteration loop *****************************************************************
                    //' Determine conditions of air at guess Leaving Wet Bulb (assumed saturated LDB=LWB)

                    if (IunitsIP == 1)  //'IP
                    {
                        CalculatePropertiesIP(testPsychrometricsData.BarometricPressure, LWBT, LWBT, ref WOutT, ref RHOutT, ref output.WetBuldTemperature, ref output.SpecificVolume, ref output.Density, ref DEWPointOutT);
                        //CalcPropertiesIP(testPsychrometricsData.BarometricPressure, LWBT, LWBT, WOutT, RHOutT, output.WetBuldTemperature, output.SpecificVolume, output.Density, DEWPointOutT);
                        //CalcIPProperties(testPsychrometricsData.BarometricPressure, testPsychrometricsData.WetBulbTemperature, testPsychrometricsData.DryBulbTemperature, testPsychrometricsData.HumidityRatio, testPsychrometricsData.RelativeHumidity, testPsychrometricsData.Enthalpy, testPsychrometricsData.SpecificVolume, testPsychrometricsData.Density, testPsychrometricsData.DewPoint);
                    }
                    else    //'SI
                    {
                        CalculatePropertiesSI(testPsychrometricsData.BarometricPressure, LWBT, LWBT, ref WOutT, ref RHOutT, ref output.WetBuldTemperature, ref output.SpecificVolume, ref output.Density, ref DEWPointOutT);
                        //CalcPropertiesSI(testPsychrometricsData.BarometricPressure, LWBT, LWBT, WOutT, RHOutT, output.WetBuldTemperature, output.SpecificVolume, output.Density, DEWPointOutT);
                    }

                    //PRINT USING "LWBt=###.### WOutT=#.##### HOutT=###.#### output.SpecificVolume=##.#### output.Density=#.#####  "; LWBT; WOutT; output.WetBuldTemperature; output.SpecificVolume; output.Density
                    //'     PRINT #2, USING "LWB=###.### W=#.##### H=###.#### SV=##.#### Den=#.#####  "; LWBT; WOutT; output.WetBuldTemperature; output.SpecificVolume; output.Density

                    //'Calculate L/G Test
                    //'Equation 5.1, Liquid to Gas ratio Test
                    if ((data.DesignData.WaterFlowRate == 0.0) || (DenOutD == 0.0) || (testPsychrometricsData.FanDriverPower == 0.0) || (SVOutD == 0.0))
                        output.LiquidToGasRatio = 0.0;
                    else
                        output.LiquidToGasRatio = data.DesignData.LiquidToGasRatio * (testPsychrometricsData.WaterFlowRate / data.DesignData.WaterFlowRate) * Math.Pow((output.Density / DenOutD * data.DesignData.FanDriverPower / testPsychrometricsData.FanDriverPower), (1.0 / 3.0)) * (output.SpecificVolume / SVOutD);
                    HCalcT = testPsychrometricsData.Enthalpy + output.LiquidToGasRatio * Cpw * (testPsychrometricsData.HotWaterTemperature - testPsychrometricsData.ColdWaterTemperature);
                    //PRINT USING "output.LiquidToGasRatio=##.#### HCalcT=###.#### HactT=###.#### R=##.###"; output.LiquidToGasRatio; HCalcT; output.WetBuldTemperature; (HCalcT / output.WetBuldTemperature - 1!) * 100
                    //'    PRINT #2, USING "output.LiquidToGasRatio=##.#### HOoutT=###.#### Hact=###.#### R=+##.###%"; output.LiquidToGasRatio; HCalcT; output.WetBuldTemperature; (HCalcT / output.WetBuldTemperature - 1!) * 100
                    //'    PRINT #2,
                    //PRINT

                    //'Call Enthalpy Search subroutine for calculated Href value
                    if (IunitsIP == 1)  //'IP
                    {
                        //'       CALL EnthalpysearchIP(sat%, P!, RootEnthalpy!,               OutputEnthalpy!,    temperatureWetBulb!, temperatureDryBulb!, humidityRatio!,    relativeHumidity!,    specificVolume!,    Density!,    DEWPoint!)
                        EnthalpysearchIP(1, testPsychrometricsData.BarometricPressure, HCalcT, ref OutputEnthalpy, ref LWBTnew,         ref LDBTnew,         ref humidityRatio, ref relativeHumidity, ref specificVolume, ref Density, ref DEWPoint);
                    }
                    else    //'SI
                    {
                        EnthalpysearchSI(1, testPsychrometricsData.BarometricPressure, HCalcT, ref OutputEnthalpy, ref LWBTnew, ref LDBTnew, ref humidityRatio, ref relativeHumidity, ref specificVolume, ref Density, ref DEWPoint);
                    }
                    //PRINT USING "HCalcT=###.#### HactT=###.#### dif=+##.#### LWBT=###.#### LWBTnew=###.####"; HCalcT; output.WetBuldTemperature; HCalcT - output.WetBuldTemperature; LWBT; LWBTnew
                    //'    PRINT #2, USING "HCalcT=###.#### HactT=###.#### dif=+##.#### LWBT=###.#### PLWBTnew=###.####"; HCalcT; output.WetBuldTemperature; HCalcT - output.WetBuldTemperature; LWBT; LWBTnew

                    //'Check to see if Enthalpy  of Leaving Wet Bulb Test (output.WetBuldTemperature) converged to calculated value (HCalcT)
                    if (Math.Abs(HCalcT - output.WetBuldTemperature) > .0002)
                    {
                        LWBT = LWBTnew;
                        bGoto200 = true;
                    }
                    else
                    {
                        bGoto200 = false;
                    }
                }//'******** BOTTOM OF ITERATION LOOP ********************************************

//# ifdef _DEBUG
                //PRINT USING "Test Out:HCalcT=###.#### HactT=###.#### dif=+##.#### LWB=###.#### LWBnew=###.####"; HCalcT; output.WetBuldTemperature; HCalcT - output.WetBuldTemperature; LWBT; LWBTnew
                //PRINT #2,
                //PRINT #2, USING "Test Out:HCalcT=###.#### Hact=###.#### dif=+##.#### LWB=###.#### LWBnew=###.####"; HCalcT; output.WetBuldTemperature; HCalcT - output.WetBuldTemperature; LWBT; LWBTnew
                //PRINT #2, USING "             output.LiquidToGasRatio=##.####  output.Density=#.#####  output.SpecificVolume=##.#####"; output.LiquidToGasRatio; output.Density; output.SpecificVolume
                //PRINT #2,

                //todo
                //strTemp = string.Format("Test Out:HCalcT=%.04f Hact=%.04f dif=%.04f LWB=%.04f LWBnew=%.04f\r\n", HCalcT, output.WetBuldTemperature, HCalcT - output.WetBuldTemperature, LWBT, LWBTnew);
                //TRACE0(strTemp);
                //strTemp = string.Format("             output.LiquidToGasRatio=%.04f  output.Density=%.05f  output.SpecificVolume=%.05f\r\n\r\n", output.LiquidToGasRatio, output.Density, output.SpecificVolume);
                //TRACE0(strTemp);
//#endif // _DEBUG

                //'Save convergered Density Out Test as Density Design
                DenTest = output.Density;
            }
            else    //'Forced Draft NO ITERATION
            {
                //'        ENTERING air conditions  Test and Design
                DenTest = testPsychrometricsData.Density;
                DenDesign = data.DesignData.Density;

                // Try these values for Forced Draft option
                // (Toolkit v3.0 Build #5, DBL - 05/23/03)
                output.WetBuldTemperature = testPsychrometricsData.Enthalpy;
                output.SpecificVolume = testPsychrometricsData.SpecificVolume;
                output.Density = testPsychrometricsData.Density;
                LWBTnew = testPsychrometricsData.WetBulbTemperature;
            }

            //'Equation 6.1, Adjusted TestFlow
            if ((testPsychrometricsData.FanDriverPower == 0.0) || (DenDesign == 0.0))
                output.AdjustedFlow = 0.0;
            else
                output.AdjustedFlow = testPsychrometricsData.WaterFlowRate * Math.Pow((data.DesignData.FanDriverPower / testPsychrometricsData.FanDriverPower * DenTest / DenDesign), (1.0 / 3.0));


//# ifdef _DEBUG
            //todo
            //strTemp.Format("output.AdjustedFlow = testPsychrometricsData.WaterFlowRate   *  (data.DesignData.FanDriverPower / testPsychrometricsData.FanDriverPower  * DenTest/DenDesign) ^ (1 / 3)\r\n");
            //OutputDebugString(strTemp);
            //strTemp.Format("output.AdjustedFlow = %.01f * (%.02f/%.02f * %.05f / %.05f) ^ (1 / 3)\r\n\r\n", testPsychrometricsData.WaterFlowRate, data.DesignData.FanDriverPower, testPsychrometricsData.FanDriverPower, DenTest, DenDesign);
            //OutputDebugString(strTemp);

            //if (output.AdjustedFlow >= 1000.0)
            //{
            //    //PRINT #2, USING "Adjusted Test Flow=######.#"; output.AdjustedFlow
            //}
            //else
            //{
            //    //PRINT #2, USING "Adjusted Test Flow=###.####"; output.AdjustedFlow
            //}
            //PRINT #2,
//#endif // _DEBUG
            return output.AdjustedFlow;
        }

        public static void EnthalpysearchIP(int sat, double P, double RootEnthalpy, ref double OutputEnthalpy, ref double temperatureWetBulb, ref double temperatureDryBulb, ref double humidityRatio, ref double relativeHumidity, ref double specificVolume, ref double Density, ref double DEWPoint)
        {
            //'****** Procedure finds IP WB, DB & properties given enthalpy & pressure **
            //'****** Uses bisection method to search for roots.  Limits 0-140 øF *******
            //'

            //'Establish tolerance on enthalpy search
            double temptolerance = .0001;
            double Htolerance = .00005;
            double H0 = 0.0;
            double H140 = 0.0;
            double Enthalpy = 0.0;

            //' First need to bracket region of WB/DB to created bisection region
            //' High and low values are 0ø and 140ø.

            //'Calculate low value and compare to program and tolerance limits

            temperatureWetBulb = 0.0;
            if (sat == 1)
            {
                temperatureDryBulb = temperatureWetBulb;
            }
            CalculatePropertiesIP(P, temperatureWetBulb, temperatureDryBulb, ref humidityRatio, ref relativeHumidity, ref H0, ref specificVolume, ref Density, ref DEWPoint);

            if (Math.Abs(H0 - RootEnthalpy) <= Htolerance)
            {
                return;
            }
            if (RootEnthalpy < H0)
            {
                ////todo ASSERT(0);
                //LOCATE 17, 10: PRINT "Enthalpy ref of range of program"
                return;
            }

            //'Calculate high value and compare to program and tolerance limits

            temperatureWetBulb = 140.0;
            if (sat == 1)
            {
                temperatureDryBulb = temperatureWetBulb;
            }
            CalculatePropertiesIP(P, temperatureWetBulb, temperatureDryBulb, ref humidityRatio, ref relativeHumidity, ref H140, ref specificVolume, ref Density, ref DEWPoint);

            if (Math.Abs(H140 - RootEnthalpy) <= Htolerance)
            {
                return;
            }
            if (RootEnthalpy > H140)
            {
                ////todo ASSERT(0);
                //LOCATE 17, 10: PRINT "Enthalpy ref of range of program"
                return;
            }

            //'Begin bisection root search procedure from Numerical Recipes in BASIC, p 193

            double t1 = 0.0;
            double t2 = 140.0;
            double trtbis = t1;
            double DT = t2 - t1;
            double tmid = 0.0;
            double hmid = 0.0;
            while (true)
            {
                DT = DT / 2.0;
                tmid = trtbis + DT;
                if (sat == 1)
                {
                    temperatureDryBulb = tmid;
                }
                CalculatePropertiesIP(P, tmid, temperatureDryBulb, ref humidityRatio, ref relativeHumidity, ref Enthalpy, ref specificVolume, ref Density, ref DEWPoint);
                //CalcPropertiesIP(P!, tmid, temperatureDryBulb!, humidityRatio!, relativeHumidity!, Enthalpy!, specificVolume!, Density!, DEWPoint!)
                hmid = RootEnthalpy - Enthalpy;
                if (hmid >= 0.0)
                {
                    trtbis = tmid;
                }
                if ((Math.Abs(DT) < temptolerance) || (hmid == 0.0))
                {
                    break;
                }
            }
            temperatureWetBulb = tmid;
            if (sat == 1)
            {
                temperatureDryBulb = tmid;
            }
            OutputEnthalpy = Enthalpy;
        }

        //public static void EnthalpyIP(int sat, double P, double RootEnthalpy, ref double OutputEnthalpy, ref double temperatureWetBulb, ref double temperatureDryBulb, double humidityRatio, double relativeHumidity, double specificVolume, double Density, double DEWPoint)
        public static double EnthalpyIP(int sat, PsychrometricsData data)
        {
            double OutputEnthalpy = 0;
            double temptolerance = 0.001;
            double Htolerance = 0.00005;

            // First need to bracket region of WB/DB to created bisection region
            // High and low values are respectively:
            double Tlower = 0.0;
            //DDP double Tupper = 200.0;
            double Tupper = 140.0;
            double Hlower = 0;
            double Hupper = 0;
            double hmid = 0;
            double EnthalpyIn = data.Enthalpy;

            //' First need to bracket region of WB/DB to created bisection region
            //' High and low values are 0ø and 140ø.

            //'Calculate low value and compare to program and tolerance limits
            data.WetBulbTemperature = Tlower;
            if (sat == 1)
            {
                data.DryBulbTemperature = data.WetBulbTemperature;
            }

            data.Enthalpy = Hlower;
            CalculatePropertiesIP(data);

            data.Enthalpy = EnthalpyIn; // reset

            if (Math.Abs(Hlower - data.Enthalpy) <= Htolerance)
            {
                OutputEnthalpy = 0.0;
                return OutputEnthalpy;
            }

            if (data.Enthalpy < Hlower)
            {
                OutputEnthalpy = -999.0; // ref of range		
                return OutputEnthalpy;
            }

            //'Calculate high value and compare to program and tolerance limits
            data.WetBulbTemperature = Tupper;
            if (sat == 1)
            {
                data.DryBulbTemperature = data.WetBulbTemperature;
            }

            data.Enthalpy = Hupper;
            CalculatePropertiesIP(data);
            Hupper = data.Enthalpy;

            data.Enthalpy = EnthalpyIn;

            if (Math.Abs(Hupper - data.Enthalpy) <= Htolerance)
            {
                OutputEnthalpy = 0.0;
                return OutputEnthalpy;
            }

            if (data.Enthalpy > Hupper)
            {
                OutputEnthalpy = -999.0; // ref of range		
                return OutputEnthalpy;
            }

            // Begin bisection root search procedure from Numerical Recipes in BASIC, p 193 ? version
            double trtbis = Tlower;
            double DT = (Tupper - Tlower);
            double tmid;
            do
            {
                DT = DT / 2.0;
                tmid = trtbis + DT;
                if (sat == 1)
                {
                    data.DryBulbTemperature = tmid;
                }

                data.WetBulbTemperature = tmid;
                CalculatePropertiesIP(data);

                hmid = EnthalpyIn - data.Enthalpy;
                if (hmid >= 0.0)
                {
                    trtbis = tmid;
                }
            }
            while ((Math.Abs(DT) >= temptolerance) && (hmid != 0.0));

            data.WetBulbTemperature = tmid;
            if (sat == 1)
            {
                data.DryBulbTemperature = tmid;
            }

            OutputEnthalpy = data.Enthalpy;
            return OutputEnthalpy;
        }

        public static void EnthalpysearchSI(int sat, double P, double RootEnthalpy, ref double OutputEnthalpy, ref double temperatureWetBulb, ref double temperatureDryBulb, ref double humidityRatio, ref double relativeHumidity, ref double specificVolume, ref double Density, ref double DEWPoint)
        {
            //'****** Procedure finds SI WB, DB & properties given enthalpy & pressure **
            //'****** Uses bisection method to search for roots.  Limits -20 to 60 øC ****

            //'Establish tolerance on enthalpy search

            double temptolerance = .00001;
            double Htolerance = .00005;
            double H20 = 0.0;
            double H60 = 0.0;
            double Enthalpy = 0.0;

            //' First need to bracket region of WB/DB to created bisection region
            //' High and low values are -20ø and 60ø.

            //'Calculate low value and compare to program and tolerance limits

            temperatureWetBulb = -20.0;
            if (sat == 1)
            {
                temperatureDryBulb = temperatureWetBulb;
            }
            CalculatePropertiesSI(P, temperatureWetBulb, temperatureDryBulb, ref humidityRatio, ref relativeHumidity, ref H20, ref specificVolume, ref Density, ref DEWPoint);
            //CalcPropertiesSI(P!, temperatureWetBulb!, temperatureDryBulb!, humidityRatio!, relativeHumidity!, H20, specificVolume!, Density!, DEWPoint!)

            if (Math.Abs(H20 - RootEnthalpy) <= Htolerance)
            {
                return;
            }
            if (RootEnthalpy < H20)
            {
                ////todo ASSERT(0);
                //LOCATE 17, 10: PRINT "Enthalpy ref of range of program"
                return;
            }

            //'Calculate high value and compare to program and tolerance limits

            temperatureWetBulb = 60.0;
            if (sat == 1)
            {
                temperatureDryBulb = temperatureWetBulb;
            }
            CalculatePropertiesSI(P, temperatureWetBulb, temperatureDryBulb, ref humidityRatio, ref relativeHumidity, ref H60, ref specificVolume, ref Density, ref DEWPoint);
            //CalcPropertiesSI(P!, temperatureWetBulb!, temperatureDryBulb!, humidityRatio!, relativeHumidity!, H60, specificVolume!, Density!, DEWPoint!)

            if (Math.Abs(H60 - RootEnthalpy) <= Htolerance)
            {
                return;
            }
            if (RootEnthalpy > H60)
            {
                ////todo ASSERT(0);
                //LOCATE 17, 10: PRINT "Enthalpy ref of range of program"
                return;
            }

            //'Begin bisection root search procedure from Numerical Recipes in BASIC, p 193

            double t1 = -20.0;
            double t2 = 60.0;
            double trtbis = t1;
            double DT = t2 - t1;
            double tmid = 0.0;
            double hmid;
            while (true)
            {
                DT = DT / 2.0;
                tmid = trtbis + DT;
                if (sat == 1)
                {
                    temperatureDryBulb = tmid;
                }
                CalculatePropertiesSI(P, tmid, temperatureDryBulb, ref humidityRatio, ref relativeHumidity, ref Enthalpy, ref specificVolume, ref Density, ref DEWPoint);
                //CalcPropertiesSI(P!, tmid, temperatureDryBulb!, humidityRatio!, relativeHumidity!, Enthalpy!, specificVolume!, Density!, DEWPoint!)
                hmid = RootEnthalpy - Enthalpy;
                if (hmid >= 0.0)
                {
                    trtbis = tmid;
                }
                if ((Math.Abs(DT) < temptolerance) || (hmid == 0.0))
                {
                    break;
                }
            }
            temperatureWetBulb = tmid;
            if (sat == 1)
            {
                temperatureDryBulb = tmid;
            }
            OutputEnthalpy = Enthalpy;
        }

        // Calculate ionization potential vapor pressure based on the air temperature
        // using ASHRAE equations
        public static double IonizationPotentialVaporPressure(double airTemperature)
        {
            double t = airTemperature + 459.67;

            if (t == 0.0)
            {
                throw new ArgumentException("Air temperature value must be above -459.67");
            }

            // Calculate saturation pressure at t!
            // from ASHRAE Eq.(4)
            if (airTemperature >= 32)
            {
                return Math.Exp(
                    (-10440.39708 / t)
                    + -11.2946496
                    + (-0.027022355 * t)
                    + (0.00001289036 * Math.Pow(t, 2.0))
                    + (-.000000002478068 * Math.Pow(t, 3.0))
                    + (6.5459673 * Math.Log(t))
                    );
            }
            else
            {
                return Math.Exp(
                    (-10214.16462 / t)
                    + -4.89350301
                    + (-0.00537657944 * t)
                    + (-0.000000192023769 * Math.Pow(t, 2.0))
                    + (3.55758316E-10 * Math.Pow(t, 3.0))
                    + (-9.03446883E-14 * Math.Pow(t, 4.0))
                    + (4.1635019 * Math.Log(t))
                    );
            }
        }

        // Function to compute saturation vapor pressure in [kPa]
        // ASHRAE Fundamentals handbood (2005) p 6.2, equation 5 and 6
        // Tdb = Dry bulb temperature[degC]
        // Valid from -100C to 200 C 
        public static double SaturationVaporPressure(double tair)
        {
            double dblSIPws = 0.0;
            double LnPws;
            double t;
            double C1 = -5674.5359;
            double C2 = -.51523058;
            double C3 = -.009677843;
            double C4 = .00000062215701;
            double C5 = .0000000020747825;
            double C6 = -9.484024000000001E-13;
            double C7 = 4.1635019;
            double C8 = -5800.2206;
            double C9 = -5.516256;
            double C10 = -.048640239;
            double C11 = .000041764768;
            double C12 = -.000000014452093;
            double C13 = 6.5459673;


            //    C1 = -5674.5359
            //    C2 = 6.3925247
            //    C3 = -0.009677843
            //    C4 = 0.00000062215701
            //    C5 = 2.0747825E-09
            //    C6 = -9.484024E-13
            //    C7 = 4.1635019
            //    C8 = -5800.2206
            //    C9 = 1.3914993
            //    C10 = -0.048640239
            //    C11 = 0.000041764768
            //    C12 = -0.000000014452093
            //    C13 = 6.5459673


            //    TK = Tdb + 273.15                     # Converts from degC to degK

            //    if TK <= 273.15:
            //        result = math.Math.Exp(C1 / TK + C2 + C3 * TK + C4 * TK * *2 + C5 * TK * *3 +
            //                          C6 * TK * *4 + C7 * math.Math.Log(TK)) / 1000
            //    else:
            //        result = math.Math.Exp(C8 / TK + C9 + C10 * TK + C11 * TK * *2 + C12 * TK * *3 +
            //                          C13 * math.Math.Log(TK)) / 1000
            //return result

            // Calculate saturation pressure at t!
            if (tair >= 0)
            {
                t = tair + 273.15;
                LnPws = C8 / t + C9 + C10 * t + C11 * t * t + C12 * t * t * t + C13 * Math.Log(t);
                dblSIPws = Math.Exp(LnPws);    //ASHRAE Eq.(4)
            }
            else
            {
                t = tair + 273.15;
                if (t != 0.0)
                {
                    LnPws = C1 / t + C2 + C3 * t + C4 * t * t + C5 * t * t * t + C6 * t * t * t * t + C7 * Math.Log(t);
                    dblSIPws = Math.Exp(LnPws);   //ASHRAE Eq.(3)
                }
            }

            return dblSIPws;
        }

        //double temperatureDryBulb, double temperatureWetBulb, ref double PwsDB, ref double PwsWB, ref double FsDB, ref double FsWB
        public static void CalcSiVariables(double pressure, double temperatureDryBulb, double temperatureWetBulb, ref double PwsDB, ref double PwsWB, ref double FsDB, ref double FsWB)
        {
            double Ppsi;
            double tF;

            PwsDB = SaturationVaporPressure(temperatureDryBulb);
            PwsWB = SaturationVaporPressure(temperatureWetBulb);
            tF = temperatureDryBulb * 1.8 + 32.0;
            Ppsi = 14.696 * pressure / 101.325;
            FsDB = Fs(tF, Ppsi);
            tF = temperatureWetBulb * 1.8 + 32.0;
            FsWB = Fs(tF, Ppsi);
        }

    }
}
