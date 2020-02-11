// Copyright Cooling Technology Institute 2019-2020

using Models;
using System;
using System.IO;
using System.Text;

namespace CalculationLibrary
{
    // 2017, ashrae fundamental handbook IP.pdf
    // 2017, ashrae fundamental handbook IS.pdf

    public class CalculationLibrary
    {
        public const double Tboil = 212.0;
        public const double Patm = 14.696;

        //---------------------------------------------------------------------
        // Data calculations IP
        //---------------------------------------------------------------------
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

        // public static void WBsearchIP(double psi, double relativeHumidity, double temperatureDryBulb, ref double temperatureWetBulb)
        // public static double CalculatetemperatureWetBulbIP(PsychrometricsData data)
        // (double pressure, double temperatureDryBulb, double temperatureWetBulb)
        public static double CalculateWetBulbTemperature(bool isInternationalSystemOfUnits_SI, double psi, double relativeHumidity, double dryBulbTemperature)
        {
            double temptolerance = .0005;
            double RHtolerance = .00005;
            double RHhigh;
            double RHmid;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI,
                BarometricPressure = psi,
                WetBulbTemperature = dryBulbTemperature,
                DryBulbTemperature = dryBulbTemperature
            };

            CalculateProperties(data);

            //Calculate saturation value and compare to program and tolerance limits
            RHhigh = data.RelativeHumidity;

            if (Math.Abs(RHhigh - relativeHumidity) <= RHtolerance)
            {
                return dryBulbTemperature;
            }

            // Begin bisection root search procedure from Numerical Recipes in BASIC, p 193   
            double t1 = 0.0;
            double t2 = dryBulbTemperature;
            double trtbis = t1;
            double DT = t2 - t1;
            double tmid;
            do
            {
                DT /= 2;
                tmid = trtbis + DT;
                data.BarometricPressure = psi;
                data.WetBulbTemperature = dryBulbTemperature;
                data.DryBulbTemperature = tmid;
                RHmid = relativeHumidity - CalculateRelativeHumidity(data);
                if (RHmid >= 0.0)
                {
                    trtbis = tmid;
                }
            }
            while ((Math.Abs(DT) >= temptolerance) && (RHmid != 0.0));

            // found wet bulb
            return tmid;
        }

        // streamlined Enthalpy function for demand curves
        public static double CalculateEnthalpy(bool isSI, double pressure, double dryBulbTemperature, double wetBulbTemperature)
        {
            PsychrometricsData data = new PsychrometricsData()
            {
                BarometricPressure = pressure,
                DryBulbTemperature = dryBulbTemperature,
                WetBulbTemperature = wetBulbTemperature
            };

            CalculateProperties(data);

            return data.Enthalpy;
        }


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

            Hain = CalculateEnthalpy(merkelData.IsInternationalSystemOfUnits_SI, pressure, merkelData.WetBulbTemperature, merkelData.WetBulbTemperature);
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
                Hw = CalculateEnthalpy(merkelData.IsInternationalSystemOfUnits_SI, pressure, Tw, Tw);
                Ha = Hain + X[i] * (Haex - Hain);
                if (Hw <= Ha) return (999);
                KaV += .25 / (Hw - Ha);
            }

            merkelData.KaV_L = KaV * merkelData.Range;

            return merkelData.KaV_L;
        }

        public static double StandardAtmosphericPressure(double Z)
        {
            Z /= 10000.0;
            return (.491154 * ((.547462 * Z - 7.67923) * Z + 29.9309) / (.10803 * Z + 1.0));
        }

        public static void EnthalpySearch(bool saturation, PsychrometricsData data)
        {
            //'****** Procedure finds SI WB, DB & properties given enthalpy & pressure **
            //'****** Uses bisection method to search for roots.  Limits -20 to 60 øC ****
            StringBuilder stringBuilder = new StringBuilder();

            //'Establish tolerance on enthalpy search

            double temptolerance = (data.IsInternationalSystemOfUnits_SI) ? 0.00001 : 0.001;
            double Htolerance = 0.00005;

            //' First need to bracket region of WB/DB to created bisection region
            //' High and low values are -20ø and 60ø.

            //'Calculate low value and compare to program and tolerance limits

            data.WetBulbTemperature = (data.IsInternationalSystemOfUnits_SI) ? -20.0 : 0.0;

            if (saturation)
            {
                data.DryBulbTemperature = data.WetBulbTemperature;
            }

            CalculateProperties(data);

            if (Math.Abs(data.Enthalpy - data.RootEnthalpy) <= Htolerance)
            {
                return;
            }

            stringBuilder.AppendFormat(" WetBulbTemperature {0} DryBulbTemperature {1} Hlow {2} RootEnthalpy {3}\n", data.WetBulbTemperature.ToString("F6"), data.DryBulbTemperature.ToString("F6"), data.Enthalpy.ToString("F6"), data.RootEnthalpy.ToString("F6"));

            if (data.RootEnthalpy < data.Enthalpy)
            {
                ////todo ASSERT(0);
                //LOCATE 17, 10: PRINT "Enthalpy ref of range of program"
                return;
            }

            //'Calculate high value and compare to program and tolerance limits

            data.WetBulbTemperature = (data.IsInternationalSystemOfUnits_SI) ? 60.0 : 140.0;

            if (saturation)
            {
                data.DryBulbTemperature = data.WetBulbTemperature;
            }

            CalculateProperties(data);

            if (Math.Abs(data.Enthalpy - data.RootEnthalpy) <= Htolerance)
            {
                return;
            }

            if (data.RootEnthalpy > data.Enthalpy)
            {
                ////todo ASSERT(0);
                //LOCATE 17, 10: PRINT "Enthalpy ref of range of program"
                return;
            }

            stringBuilder.AppendFormat(" WetBulbTemperature {0} DryBulbTemperature {1} Hhigh {2} RootEnthalpy {3}\n", data.WetBulbTemperature.ToString("F6"), data.DryBulbTemperature.ToString("F6"), data.Enthalpy.ToString("F6"), data.RootEnthalpy.ToString("F6"));

            //'Begin bisection root search procedure from Numerical Recipes in BASIC, p 193

            double temperatureCold = (data.IsInternationalSystemOfUnits_SI) ? -20.0 : 0.0; // cold
            double temperatureHot = (data.IsInternationalSystemOfUnits_SI) ? 60.0 : 140;  // hot
            double trtbis = temperatureCold;
            double DT = temperatureHot - temperatureCold;
            double hmid;

            do
            {
                DT /= 2.0;
                data.WetBulbTemperature = trtbis + DT;
                if (saturation)
                {
                    data.DryBulbTemperature = data.WetBulbTemperature;
                }

                CalculateProperties(data);

                hmid = data.RootEnthalpy - data.Enthalpy;

                if (hmid >= 0.0)
                {
                    trtbis = data.WetBulbTemperature;
                }
                stringBuilder.AppendFormat(" hmid {0}\n", hmid.ToString("F6"));
                stringBuilder.AppendFormat(" temptolerance {0} DT {1} trtbis {2} tmid {3} Enthalpy {4} RootEnthalpy {5}\n", temptolerance.ToString("F6"), DT.ToString("F6"), trtbis.ToString("F6"), data.WetBulbTemperature.ToString("F6"), data.Enthalpy.ToString("F6"), data.RootEnthalpy.ToString("F6"));
            } while ((Math.Abs(DT) >= temptolerance) && (hmid != 0.0));

            if (saturation)
            {
                data.DryBulbTemperature = data.WetBulbTemperature;
            }

            stringBuilder.AppendFormat(" Enthalpy {0} WetBulbTemperature {1}\n", data.Enthalpy.ToString("F6"), data.WetBulbTemperature.ToString("F6"));

            File.WriteAllText("entout.txt", stringBuilder.ToString());
        }

        //*********** Partial Pressure of Water Vapor (-148ø to 32ø) ****************
        //*********** Partial Pressure of Water Vapor (32ø-392ø) ********************
        // Pws = saturation vapor pressure
        public static double CalculateVaporPressure(bool IsInternationalSystemOfUnits_SI, double tair)
        {
            // saturation vapor pressure (Pws)
            double Pws = 0.0;
            double C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13;
            double LnPws; // natural logarithm saturation pressure
            double t; // absolute temperature, K = °C + 273.15
            
            double freezingTemperature = (IsInternationalSystemOfUnits_SI) ? 0.0 : 32.0;

            // Calculate saturation pressure at t!
            if (tair >= freezingTemperature)
            {
                C8 = (IsInternationalSystemOfUnits_SI) ? -5800.2206 : -10440.39708;
                C9 = (IsInternationalSystemOfUnits_SI) ? -5.516256 : -11.2946496;
                C10 = (IsInternationalSystemOfUnits_SI) ? -.048640239 : -.027022355;
                C11 = (IsInternationalSystemOfUnits_SI) ? .000041764768 : .00001289036;
                C12 = (IsInternationalSystemOfUnits_SI) ? .000000014452093 : -.000000002478068;
                C13 = 6.5459673;
                t = tair + ((IsInternationalSystemOfUnits_SI) ? 273.15 : 459.67);

                if (t != 0.0)
                {
                    LnPws = C8 / t + C9 + C10 * t + C11 * t * t + C12 * t * t * t + C13 * Math.Log(t);
                    Pws = Math.Exp(LnPws);    //ASHRAE Eq.(6) in PSYCHROMETRICS_F01_06SI.pdf
                }
            }
            else
            {
                C1 = (IsInternationalSystemOfUnits_SI) ? -5674.5359 : -10214.16462;
                C2 = (IsInternationalSystemOfUnits_SI) ? -0.51523058 : -4.89350301;
                C3 = (IsInternationalSystemOfUnits_SI) ? -0.009677843 : -.00537657944;
                C4 = (IsInternationalSystemOfUnits_SI) ? 0.00000062215701 : .000000192023769;
                C5 = (IsInternationalSystemOfUnits_SI) ? 0.0000000020747825 : 3.55758316E-10;
                C6 = (IsInternationalSystemOfUnits_SI) ? -9.484024000000001E-13 : -9.03446883E-14;
                C7 = 4.1635019;
                t = tair + ((IsInternationalSystemOfUnits_SI) ? 273.15 : 459.67);

                if (t != 0.0)
                {
                    LnPws = C1 / t + C2 + C3 * t + C4 * t * t + C5 * t * t * t + C6 * t * t * t * t + C7 * Math.Log(t);
                    Pws = Math.Exp(LnPws);   //ASHRAE Eq.(5) PSYCHROMETRICS_F01_06SI.pdf
                }
            }
            return Pws;
        }

        public static void CalculateVariables(PsychrometricsData data)
        {
            double kilopascal;
            double tF;

            data.SaturationVaporPressureDryBulbTemperature = CalculateVaporPressure(data.IsInternationalSystemOfUnits_SI, data.DryBulbTemperature);
            data.SaturationVaporPressureWetBulbTemperature = CalculateVaporPressure(data.IsInternationalSystemOfUnits_SI, data.WetBulbTemperature);

            if(data.IsInternationalSystemOfUnits_SI)
            {
                kilopascal = UnitConverter.ConvertKilopascalToBarometricPressure(data.BarometricPressure);

                tF = data.DryBulbTemperature * 1.8 + 32.0;
                data.FsDryBulbTemperature = Fs(tF, kilopascal);
                tF = data.WetBulbTemperature * 1.8 + 32.0;
                data.FsWetBulbTemperature = Fs(tF, kilopascal);
            }
            else
            {
                data.FsDryBulbTemperature = Fs(data.DryBulbTemperature, data.BarometricPressure);
                data.FsWetBulbTemperature = Fs(data.WetBulbTemperature, data.BarometricPressure);
            }
        }

        public static void CalculateProperties(PsychrometricsData data)
        {
            CalculateVariables(data);

            // Calculate humidity ratio of the mixture
            // humidityRatio = ((1093. - .556 * data.TemperatureWetBulb) * WsWB - .24 * (data.TemperatureDryBulb - data.TemperatureWetBulb)) / (1093. + .444 * data.TemperatureDryBulb - data.TemperatureWetBulb);  //ASHRAE Eq.(33)
            data.HumidityRatio = CalculateHumidityRatio(data);

            // Calculate degree of saturation
            // degreeOfSaturation = humidityRatio / WsDB;           //ASHRAE Eq.(10)
            data.DegreeOfSaturation = CalculateDegreeOfSaturation(data);

            // Calculate relative humidity
            // relativeHumidity = degreeOfSaturation / (1. - (1. - degreeOfSaturation) * (FsDB * PwsDB / p));  //ASHRAE Eq.(23a)
            data.RelativeHumidity = CalculateRelativeHumidity(data);

            // Calculate specific volume
            // Ra = 53.352 / 144.;   // to change gas constant to psi per foot
            // specificVolume = Ra * (data.TemperatureDryBulb + 459.67) * (1. + 1.6078 * humidityRatio) / p;   //ASHRAE Eq.(26)
            data.SpecificVolume = CalculateSpecificVolume(data);

            // Calculate density
            // Density = (1. + humidityRatio) / specificVolume;
            data.Density = CalculateDensity(data);

            // Calculate enthalpy
            // Enthalpy = .24 * data.TemperatureDryBulb + humidityRatio * (1061. + .444 * data.TemperatureDryBulb);  //ASHRAE Eq.(30)
            data.Enthalpy = CalculateEnthalpy(data);

            // Calculate dew point temperature
            data.DewPoint = CalculateDewPoint(data);

            if ((data.HumidityRatio < 0.0) && (Math.Abs(data.HumidityRatio) < .000001))
            {
                data.HumidityRatio = 0.0;
            }
        }

        private static double CalculateHumidityRatio(PsychrometricsData data)
        {
            double WsWB = 0.0; // WsWB = humidity ratio of moist air at saturation at thermodynamic wet bulb temperature --- saturation humidity ratio Ws

            // Calculate saturated humidity ratio at twb using saturation pressure (Pws) at twb,
            // and Fs correction factor at twb
            double density = (data.BarometricPressure - data.SaturationVaporPressureWetBulbTemperature * data.FsWetBulbTemperature);

            if (density != 0.0)
            {
                WsWB = 0.62198 * data.SaturationVaporPressureWetBulbTemperature * data.FsWetBulbTemperature / density;  //ASHRAE Eq.(21a)
            }

            // Calculate humidity ratio of the mixture
            double c1 = (data.IsInternationalSystemOfUnits_SI) ? 2501.0 : 1093.0;
            double c2 = (data.IsInternationalSystemOfUnits_SI) ? 1.805 : 0.444;
            double c3 = (data.IsInternationalSystemOfUnits_SI) ? 2.381 : 0.556;
            double c4 = (data.IsInternationalSystemOfUnits_SI) ? 1.0 : 0.24;
            double c5 = (data.IsInternationalSystemOfUnits_SI) ? 4.186 : 1.0;

            density = (c1 + c2 * data.DryBulbTemperature - (c5 * data.WetBulbTemperature));

            return (density == 0.0) ? 0.0 : ((c1 - c3 * data.WetBulbTemperature) * WsWB - (c4 * (data.DryBulbTemperature - data.WetBulbTemperature))) / density;  // ASHRAE Eq.(33)
        }

        private static double CalculateDegreeOfSaturation(PsychrometricsData data)
        {
            double WsDB = 0.0;
            double degreeOfSaturation = 0.0;

            // Calculate saturated humidity ratio at tdb using saturation pressure (Pws) at tdb and correction factor Fs at tdb
            double density = (data.BarometricPressure - data.SaturationVaporPressureDryBulbTemperature * data.FsDryBulbTemperature);

            if (density != 0.0)
            {
                WsDB = 0.62198 * data.SaturationVaporPressureDryBulbTemperature * data.FsDryBulbTemperature / density; //ASHRAE Eq.(21a)
            }

            // Calculate degree of saturation
            if (WsDB != 0.0)
            {
                degreeOfSaturation = data.HumidityRatio / WsDB;           //ASHRAE Eq.(10)
            }

            return degreeOfSaturation;
        }

        public static double CalculateRelativeHumidity(PsychrometricsData data)
        {
            double density = ((data.BarometricPressure != 0.0) ? (1.0 - (1.0 - data.DegreeOfSaturation) * (data.FsDryBulbTemperature * data.SaturationVaporPressureDryBulbTemperature / data.BarometricPressure)) : 0.0);
            return (density == 0.0) ? 0.0 : data.DegreeOfSaturation / density;  //ASHRAE Eq.(23a)
        }

        private static double CalculateSpecificVolume(PsychrometricsData data)
        {
            double Ra = (data.IsInternationalSystemOfUnits_SI) ? (287.055 / 1000) : (53.352 / 144.0);
            double c1 = (data.IsInternationalSystemOfUnits_SI) ? 273.15 : 459.67;

            return (data.BarometricPressure == 0.0) ? 0.0 : (Ra * (data.DryBulbTemperature + c1) * (1.0 + 1.6078 * data.HumidityRatio) / data.BarometricPressure);   //ASHRAE Eq.(26)
        }

        public static double CalculateDensity(PsychrometricsData data)
        {
            return (data.SpecificVolume == 0.0) ? 0.0 : ((1.0 + data.HumidityRatio) / data.SpecificVolume);
        }

        // streamlined Enthalpy function for demand curves
        public static double CalculateEnthalpy(PsychrometricsData data)
        {
            double c1 = (data.IsInternationalSystemOfUnits_SI) ? 1.006 : 0.24;
            double c2 = (data.IsInternationalSystemOfUnits_SI) ? 2501.0 : 1061.0;
            double c3 = (data.IsInternationalSystemOfUnits_SI) ? 1.805 : 0.444;

            // Calculate enthalpy
            return c1 * data.DryBulbTemperature + data.HumidityRatio * (c2 + c3 * data.DryBulbTemperature);  //ASHRAE Eq.(30)
        }

        //*** Function to find DewPoint
        //*** Converges to the same Humidity Ratio as if you had entered
        //*** saturated conditions (DB=WB)
        public static double CalculateDewPoint(PsychrometricsData data)
        {
            int iLoop;
            double PDEW;
            double lnpw;
            double PwsDP;
            double WSDP;
            double DeltaT;
            double t;
            double tF;
            double DERPws;
            double DERHR;
            double Ppsi = UnitConverter.ConvertBarometricPressureToPsi(data.BarometricPressure);
            double FsDP;

            double C1 = (data.IsInternationalSystemOfUnits_SI) ? -5674.5359 : -10214.16462;
            double C3 = (data.IsInternationalSystemOfUnits_SI) ? -.009677843 : -0.00537657944;
            double C4 = (data.IsInternationalSystemOfUnits_SI) ? .00000062215701 : .000000192023769;
            double C5 = (data.IsInternationalSystemOfUnits_SI) ? .0000000020747825 : 3.55758316E-10;
            double C6 = (data.IsInternationalSystemOfUnits_SI) ? -9.484024000000001E-13 : -9.03446883E-14;
            double C7 = 4.1635019;

            double C8 = (data.IsInternationalSystemOfUnits_SI) ? -5800.2206 : -10440.39708;
            double C10 = (data.IsInternationalSystemOfUnits_SI) ? -.048640239 : -0.027022355;
            double C11 = (data.IsInternationalSystemOfUnits_SI) ? .000041764768 : 0.00001289036;
            double C12 = (data.IsInternationalSystemOfUnits_SI) ? -.000000014452093 : -0.000000002478068;
            double C13 = 6.5459673;

            double C14 = (data.IsInternationalSystemOfUnits_SI) ? 6.54 : 100.45;
            double C15 = (data.IsInternationalSystemOfUnits_SI) ? 14.526 : 33.193;
            double C16 = (data.IsInternationalSystemOfUnits_SI) ? 0.7389 : 2.319;
            double C17 = (data.IsInternationalSystemOfUnits_SI) ? 0.09486 : 0.17074;
            double C18 = (data.IsInternationalSystemOfUnits_SI) ? 0.4569 : 1.2063;
            
            double density;
            double freezing = (data.IsInternationalSystemOfUnits_SI) ? 0.0 : 32.0;
            double c1 = (data.IsInternationalSystemOfUnits_SI) ? 6.09 : 90.12;
            double c2 = (data.IsInternationalSystemOfUnits_SI) ? 0.4959 : 0.8927;
            double c3 = (data.IsInternationalSystemOfUnits_SI) ? 12.608 : 26.142;

            StringBuilder stringBuilder = new StringBuilder();

            // Method to determine Dew Point - Fs varies with temp - Process in iterative passes.
            double DewPoint = data.WetBulbTemperature;
            if(data.IsInternationalSystemOfUnits_SI)
            {
                tF = UnitConverter.ConvertCelsiusToFahrenheit(data.WetBulbTemperature);
                FsDP = Fs(tF, Ppsi);
            }
            else
            {
                FsDP = Fs(data.WetBulbTemperature, data.BarometricPressure);
            }

            for (iLoop = 1; iLoop <= 2; iLoop++)      // Makes exactly two passes to get best first estimate
            {
                // Calculate dew point pressure
                density = (FsDP * (.62198 + data.HumidityRatio));
                PDEW = (density == 0.0) ? 0.0 : (data.BarometricPressure * data.HumidityRatio / density);  //ASHRAE Eq.(34)
                stringBuilder.AppendFormat(" density {0} pressure {1} HumidityRatio {2}\n", density.ToString("F6"), data.BarometricPressure.ToString("F6"), data.HumidityRatio.ToString("F6"));

                // Calculate dew point temperature - check above and below ice point
                if (DewPoint < freezing)
                {
                    lnpw = Math.Log(PDEW);
                    DewPoint = c1 + c3 * lnpw + c2 * Math.Pow(lnpw, 2.0);   //ASHRAE Eq.(36)
                    stringBuilder.AppendFormat(" DewPoint {0} lnpw {1}\n", DewPoint.ToString("F6"), lnpw.ToString("F6"));
                }
                else
                {
                    lnpw = Math.Log(PDEW);
                    DewPoint = C14 + C15 * lnpw + C16 * Math.Pow(lnpw, 2.0) + C17 * Math.Pow(lnpw, 3.0) + C18 * Math.Pow(PDEW, 0.1984);  //ASHRAE Eq.(36)
                    stringBuilder.AppendFormat(" DewPoint {0} lnpw {1} PDEW {2}\n", DewPoint.ToString("F6"), lnpw.ToString("F6"), PDEW.ToString("F6"));
                }
                if (data.IsInternationalSystemOfUnits_SI)
                {
                    tF = UnitConverter.ConvertCelsiusToFahrenheit(DewPoint);
                    FsDP = Fs(tF, Ppsi);
                }
                else
                {
                    FsDP = Fs(DewPoint, data.BarometricPressure);
                }
            }

            PwsDP = CalculateVaporPressure(data.IsInternationalSystemOfUnits_SI, DewPoint);
            density = (data.BarometricPressure - PwsDP * FsDP);
            WSDP = (density == 0.0) ? 0.0 : (0.62198 * PwsDP * FsDP / density);
            DeltaT = 1.0;
            stringBuilder.AppendFormat(" PwsDP {0} density {1} WSDP {2}\n", PwsDP.ToString("F6"), density.ToString("F6"), WSDP.ToString("F6"));

            // DavidL, 04/26/2001: Fixed the loop conditions to mimic IPDEWPoint()
            while ((WSDP != 0.0) &&  ((Math.Abs(data.HumidityRatio / WSDP - 1.0) >= .000001) || (Math.Abs(DeltaT) >= .0001)))
            {
                PwsDP = CalculateVaporPressure(data.IsInternationalSystemOfUnits_SI, DewPoint);
                if(data.IsInternationalSystemOfUnits_SI)
                {
                    tF = UnitConverter.ConvertCelsiusToFahrenheit(DewPoint);
                    FsDP = Fs(tF, Ppsi);
                }
                else
                {
                    FsDP = Fs(DewPoint, data.BarometricPressure);
                }

                density = (data.BarometricPressure - PwsDP * FsDP);
                WSDP = (density == 0.0) ? 0.0 : (0.62198 * PwsDP * FsDP / density);
                stringBuilder.AppendFormat(" PwsDP {0} density {1} WSDP {2}\n", PwsDP.ToString("F6"), density.ToString("F6"), WSDP.ToString("F6"));

                //Calculate DERivative of Vapor Pressure
                t = DewPoint + ((data.IsInternationalSystemOfUnits_SI) ? 273.15 : 459.67);

                if (DewPoint >= freezing)
                {
                    DERPws = (t == 0.0) ? 0.0 : (PwsDP * (-C8 / Math.Pow(t, 2.0) + C10 + 2.0 * C11 * t + 3.0 * C12 * t * t + C13 / t));
                }
                else
                {
                    DERPws = (t == 0.0) ? 0.0 : (PwsDP * (-C1 / Math.Pow(t, 2.0) + C3 + 2.0 * C4 * t + 3.0 * C5 * t * t + 4.0 * C6 * Math.Pow(t, 3.0) + C7 / t));
                }

                //*****************************************************************************

                //Calculate DERivative of Humidity Ratio
                density = Math.Pow((data.BarometricPressure - FsDP * PwsDP), 2.0);
                DERHR = (density == 0.0) ? 0.0 :((data.BarometricPressure - PwsDP * FsDP) * 0.62198 * FsDP * DERPws - (.62198 * FsDP * PwsDP) * (-FsDP * DERPws)) / density;

                stringBuilder.AppendFormat(" PwsDP {0} density {1} WSDP {2} DERHR {3} FsDP {4} DERPws {5}\n", PwsDP.ToString("F6"), density.ToString("F6"), WSDP.ToString("F6"), DERHR.ToString("F6"), FsDP.ToString("F6"), DERPws.ToString("F6"));

                //Converge to given humidityRatio using Newton-Raphson Method
                //Yields abref one order of magnitude correction per iteration

                DeltaT = DERHR != 0.0 ? ((data.HumidityRatio - WSDP) / DERHR) : 0.0;
                DewPoint += DeltaT;
                stringBuilder.AppendFormat(" DeltaT {0} DERHR {1} WSDP {2} DewPoint {3}\n", DeltaT.ToString("F6"), DERHR.ToString("F6"), WSDP.ToString("F6"), DewPoint.ToString("F6"));
            }
            File.WriteAllText("out.txt", stringBuilder.ToString());
            return DewPoint;
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

        public static double CalculateTestLiquidToGasRatio(MechanicalDraftPerformanceCurveData data, PsychrometricsData testPsychrometricsData, PsychrometricsData designPsychrometricsData)
        {
            double liquidToGasRatio = 0;

            if ((data.DesignData.WaterFlowRate != 0) && (data.DesignData.FanDriverPower != 0) && (designPsychrometricsData.Density != 0) && (designPsychrometricsData.SpecificVolume != 0))
            {
                liquidToGasRatio = data.DesignData.LiquidToGasRatio
                                   * (data.TestData.WaterFlowRate / data.DesignData.WaterFlowRate)
                                   * Math.Pow((data.DesignData.FanDriverPower / data.TestData.FanDriverPower), (1.0 / 3.0))
                                   * (testPsychrometricsData.Density / designPsychrometricsData.Density)
                                   * Math.Pow((testPsychrometricsData.SpecificVolume / designPsychrometricsData.SpecificVolume), (1.0 / 3.0));

            }
            return liquidToGasRatio;
        }

        public static double CalcAdjustedFlow(double dblTestWaterFlowRate, double dblDesignFanDriverPower, double dblTestFanDriverPower, double dblDesignAirDensity, double dblTestAirDensity)
        {
            double dblReturn;

            dblReturn = dblTestWaterFlowRate * Math.Pow((dblDesignFanDriverPower / dblTestFanDriverPower), (1.0 / 3.0)) * Math.Pow((dblTestAirDensity / dblDesignAirDensity), (1.0 / 3.0));

            return dblReturn;
        }

        public static double DetermineAdjustedTestFlow(MechanicalDraftPerformanceCurveData data, PsychrometricsData testPsychrometricsData, PsychrometricsData designPsychrometricsData, MechanicalDraftPerformanceCurveOutput output)
        {
            double Cpw = (data.IsInternationalSystemOfUnits_SI) ? 4.186 : 1.0; // specific heat at constant pressure
            StringBuilder stringBuilder = new StringBuilder();

            output.LiquidToGasRatio = 0;

            if(!data.IsInternationalSystemOfUnits_SI)
            {

                designPsychrometricsData.BarometricPressure = 14.696 * designPsychrometricsData.BarometricPressure / 29.921;
                testPsychrometricsData.BarometricPressure = 14.696 * testPsychrometricsData.BarometricPressure / 29.921;
            }

            CalculateProperties(designPsychrometricsData);
            stringBuilder.AppendLine("designPsychrometricsData ");
            stringBuilder.AppendFormat("BarometricPressure {0} \nDensity {1} \nDewPoint {2} \nDryBulbTemperature {3} \nEnthalpy {4} \nHumidityRatio {5} \nRelativeHumidity {6} \nSpecificVolume {7} \nWetBulbTemperature {8} \n",
                        designPsychrometricsData.BarometricPressure.ToString("F6"),
                        designPsychrometricsData.Density.ToString("F6"),
                        designPsychrometricsData.DewPoint.ToString("F6"),
                        designPsychrometricsData.DryBulbTemperature.ToString("F6"),
                        designPsychrometricsData.Enthalpy.ToString("F6"),
                        designPsychrometricsData.HumidityRatio.ToString("F6"),
                        designPsychrometricsData.RelativeHumidity.ToString("F6"),
                        designPsychrometricsData.SpecificVolume.ToString("F6"),
                        designPsychrometricsData.WetBulbTemperature.ToString("F6"));
            CalculateProperties(testPsychrometricsData);
            stringBuilder.AppendLine("testPsychrometricsData ");
            stringBuilder.AppendFormat("BarometricPressure {0} \nDensity {1} \nDewPoint {2} \nDryBulbTemperature {3} \nEnthalpy {4} \nHumidityRatio {5} \nRelativeHumidity {6} \nSpecificVolume {7} \nWetBulbTemperature {8} \n", 
                        testPsychrometricsData.BarometricPressure.ToString("F6"), 
                        testPsychrometricsData.Density.ToString("F6"), 
                        testPsychrometricsData.DewPoint.ToString("F6"), 
                        testPsychrometricsData.DryBulbTemperature.ToString("F6"), 
                        testPsychrometricsData.Enthalpy.ToString("F6"), 
                        testPsychrometricsData.HumidityRatio.ToString("F6"), 
                        testPsychrometricsData.RelativeHumidity.ToString("F6"), 
                        testPsychrometricsData.SpecificVolume.ToString("F6"), 
                        testPsychrometricsData.WetBulbTemperature.ToString("F6"));


            if (data.DesignData.TowerType == TOWER_TYPE.Induced)      //'compute AdjTestFlow on LEAVING air temperatures
            {
                //'  LEAVING AIR CONDITIONS - Predicted Leaving Wet Bulb

                //'First determine Design Leaving Air Density, designPsychrometricsData.Density  *****************************
                //'first step is determine Leaving air Enthalpy Design, HOutD                
                designPsychrometricsData.RootEnthalpy = designPsychrometricsData.Enthalpy + data.DesignData.LiquidToGasRatio * Cpw * (data.DesignData.HotWaterTemperature - data.DesignData.ColdWaterTemperature);

                stringBuilder.AppendFormat("HOutD {0}\n", designPsychrometricsData.RootEnthalpy);

                //EnthalpysearchIP(int sat, double P,                                    double RootEnthalpy, ref double OutputEnthalpy, ref double temperatureWetBulb, ref double temperatureDryBulb, ref double humidityRatio, ref double relativeHumidity, ref double specificVolume, ref double Density, ref double DEWPoint)
                //EnthalpysearchIP(1,       designPsychrometricsData.BarometricPressure, HOutD,               ref OutputEnthalpy,        ref LWBD,                      ref LDBD,                      ref humidityRatio,        ref relativeHumidity,        ref designPsychrometricsData.SpecificVolume,                ref designPsychrometricsData.Density,        ref DEWPoint);

                //'Call Enthalpy Search subroutine with calculated HOutD value
                EnthalpySearch(true, designPsychrometricsData);

                stringBuilder.AppendFormat("OutputEnthalpy {0}\n", designPsychrometricsData.Enthalpy);

                //    //'Store Density Out as Density Design and SV Out as SV Design
                output.Density = designPsychrometricsData.Density;
                output.SpecificVolume = designPsychrometricsData.SpecificVolume;

                //    //'Next Iterate to find Test Leaving Wet bulb and testPsychrometricsData.Density
                //    //'Initial guess of Leaving Wet Bulb is average of Test Entering and Leaving temperature
                testPsychrometricsData.WetBulbTemperature = testPsychrometricsData.DryBulbTemperature = (data.TestData.HotWaterTemperature + data.TestData.ColdWaterTemperature) / 2.0;

                bool bGoto200 = true;
                while (bGoto200)
                {
                    //200 'Top of iteration loop *****************************************************************
                    //' Determine conditions of air at guess Leaving Wet Bulb (assumed saturated LDB=LWB)

                    CalculateProperties(testPsychrometricsData);
                    stringBuilder.AppendLine("testPsychrometricsData ");
                    stringBuilder.AppendFormat("BarometricPressure {0} \nDensity {1} \nDewPoint {2} \nDryBulbTemperature {3} \nEnthalpy {4} \nHumidityRatio {5} \nRelativeHumidity {6} \nSpecificVolume {7} \nWetBulbTemperature {8} \n", 
                        testPsychrometricsData.BarometricPressure.ToString("F6"), 
                        testPsychrometricsData.Density.ToString("F6"), 
                        testPsychrometricsData.DewPoint.ToString("F6"), 
                        testPsychrometricsData.DryBulbTemperature.ToString("F6"), 
                        testPsychrometricsData.Enthalpy.ToString("F6"), 
                        testPsychrometricsData.HumidityRatio.ToString("F6"), 
                        testPsychrometricsData.RelativeHumidity.ToString("F6"), 
                        testPsychrometricsData.SpecificVolume.ToString("F6"), 
                        testPsychrometricsData.WetBulbTemperature.ToString("F6"));

                    //'Calculate L/G Test
                    //'Equation 5.1, Liquid to Gas ratio Test
                    if ((data.DesignData.WaterFlowRate == 0.0) || (designPsychrometricsData.Density == 0.0) || (data.TestData.FanDriverPower == 0.0) || (designPsychrometricsData.SpecificVolume == 0.0))
                    {
                        output.LiquidToGasRatio = 0.0;
                    }
                    else
                    {
                        output.LiquidToGasRatio = data.DesignData.LiquidToGasRatio * (data.TestData.WaterFlowRate / data.DesignData.WaterFlowRate) * Math.Pow((output.Density / designPsychrometricsData.Density * data.DesignData.FanDriverPower / data.TestData.FanDriverPower), (1.0 / 3.0)) * (output.SpecificVolume / designPsychrometricsData.SpecificVolume);
                    }

                    testPsychrometricsData.RootEnthalpy = testPsychrometricsData.Enthalpy + output.LiquidToGasRatio * Cpw * (data.TestData.HotWaterTemperature - data.TestData.ColdWaterTemperature);

                    //'Call Enthalpy Search subroutine for calculated Href value
                    EnthalpySearch(true, testPsychrometricsData);
                    stringBuilder.AppendLine("EnthalpysearchSI ");
                    stringBuilder.AppendFormat("BPt {0} \n HCalcT {1} \n OutputEnthalpy {2} \n LWBTnew {3} \n LDBTnew {4} \n HumidRatio {5} \n RelHumid {6} \n SpVolume {7} \n Density {8} \n DEWPoint {9} \n",
                        testPsychrometricsData.BarometricPressure.ToString("F6"),
                        testPsychrometricsData.RootEnthalpy.ToString("F6"),
                        testPsychrometricsData.Enthalpy.ToString("F6"),
                        testPsychrometricsData.WetBulbTemperature.ToString("F6"),
                        testPsychrometricsData.DryBulbTemperature.ToString("F6"),
                        testPsychrometricsData.Enthalpy.ToString("F6"),
                        testPsychrometricsData.HumidityRatio.ToString("F6"),
                        testPsychrometricsData.RelativeHumidity.ToString("F6"),
                        testPsychrometricsData.SpecificVolume.ToString("F6"),
                        testPsychrometricsData.Density.ToString("F6"),
                        testPsychrometricsData.DewPoint.ToString("F6")
                        );

                    //'Check to see if Enthalpy  of Leaving Wet Bulb Test (testPsychrometricsData.Enthalpy) converged to calculated value (HCalcT)
                    if (Math.Abs(testPsychrometricsData.RootEnthalpy - testPsychrometricsData.Enthalpy) > 0.0002)
                    {
                        testPsychrometricsData.WetBulbTemperature = testPsychrometricsData.DryBulbTemperature = testPsychrometricsData.WetBulbTemperature;
                        bGoto200 = true;
                    }
                    else
                    {
                        bGoto200 = false;
                    }
                    bGoto200 = false;
                }

                //'Save convergered Density Out Test as Density Design
                designPsychrometricsData.Density = testPsychrometricsData.Density;
            }
            else    //'Forced Draft NO ITERATION
            {
                //'        ENTERING air conditions  Test and Design
                //    DenTest = testPsychrometricsData.Density;
                //    DenDesign = designPsychrometricsData.Density;

                //    // Try these values for Forced Draft option
                //    // (Toolkit v3.0 Build #5, DBL - 05/23/03)
                //    testPsychrometricsData.Enthalpy = HInT;

                //    testPsychrometricsData.SpecificVolume = SVInT;

                //    testPsychrometricsData.Density = DenInT;

                //    LWBTnew = data.TestData.WetBulbTemperature;
            }

            //'Equation 6.1, Adjusted TestFlow

            File.WriteAllText("adjout.txt", stringBuilder.ToString());

            return 0.0;// ((data.TestData.FanDriverPower == 0.0) || (DenDesign == 0.0)) ? 0.0 : data.TestData.WaterFlowRate * Math.Pow((data.DesignData.FanDriverPower / data.TestData.FanDriverPower * DenTest / DenDesign), (1.0 / 3.0));
        }
    }
}
