// Copyright Cooling Technology Institute 2019-2020

using Models;
using System;
using System.Collections.Generic;
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
        public double AdjustPrecision(double number, int precision)
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
            return(((-4.55447E-10 * T + 9.400757E -9 * P + 1.282159E - 7 ) * T - 1.762686E-6 * P + 6.35199E-6 ) * T + 3.18886E-4 * P + 1.000104);
        }
        */
        // Psychrometrics 35 version
        // fs = adjust pWV over purewater to pWV in association with air
        public double CalculateFs(bool isInternationalSystemOfUnits_SI, double pressure, double temperature)
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

            if (isInternationalSystemOfUnits_SI)
            {
                pressure = UnitConverter.ConvertKilopascalToBarometricPressure(pressure);
                temperature = UnitConverter.ConvertCelsiusToFahrenheit(temperature);
            }

            double C13 = C1 + C2 * temperature + C3 * Math.Pow(temperature, 4.0) + C4 * Math.Pow(temperature, 5.0) + C5 * pressure + C6 * pressure * temperature;
            double C14 = C13 + C7 * pressure * Math.Pow(temperature, 2.0) + C8 * pressure * Math.Pow(temperature, 4.0) + C9 * temperature * Math.Pow(pressure, 4.0);
            return (C14 + C10 * Math.Pow(temperature, 2.0) * Math.Pow(pressure, 2.0) + C11 * Math.Pow(temperature, 2.0) * Math.Pow(pressure, 3.0) + C12 * Math.Pow(pressure, 2.0) * Math.Pow(temperature, 3.0));
        }

        public double CalculateSaturatedHumidityRatio(double barometricPressure, double saturationVaporPressure, double fs)
        {
            // Calculate saturated humidity ratio at using saturation pressure (saturationVaporPressure) at tdb and correction factor Fs at tdb
            double denominator = (barometricPressure - saturationVaporPressure * fs);

            return (denominator == 0.0) ? 0.0 : 0.62198 * saturationVaporPressure * fs / denominator; //ASHRAE Eq.(21a)
        }

        //*********** Partial Pressure of Water Vapor (-148ø to 32ø) ****************
        //*********** Partial Pressure of Water Vapor (32ø-392ø) ********************
        // Pws = saturation vapor pressure
        public double CalculateVaporPressure(bool isInternationalSystemOfUnits_SI, double airTemperature)
        {
            // saturation vapor pressure (Pws)
            double Pws = 0.0;
            double C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13;
            double LnPws; // natural logarithm saturation pressure
            double t; // absolute temperature, K = °C + 273.15; K = °F + 459.67

            double freezingTemperature = (isInternationalSystemOfUnits_SI) ? 0.0 : 32.0;

            // Calculate saturation pressure at t!
            if (airTemperature >= freezingTemperature)
            {
                C8 = (isInternationalSystemOfUnits_SI) ? -5800.2206 : -10440.39708;
                C9 = (isInternationalSystemOfUnits_SI) ? -5.516256 : -11.2946496;
                C10 = (isInternationalSystemOfUnits_SI) ? -0.048640239 : -0.027022355;
                C11 = (isInternationalSystemOfUnits_SI) ? 0.000041764768 : 0.00001289036;
                C12 = (isInternationalSystemOfUnits_SI) ? -0.000000014452093 : -0.000000002478068;
                C13 = 6.5459673;
                t = airTemperature + ((isInternationalSystemOfUnits_SI) ? 273.15 : 459.67);

                if (t > 0.0)
                {
                    LnPws = C8 / t + C9 + C10 * t + C11 * t * t + C12 * t * t * t + C13 * Math.Log(t);
                    Pws = Math.Exp(LnPws);    //ASHRAE Eq.(6) in PSYCHROMETRICS_F01_06SI.pdf
                }
            }
            else
            {
                C1 = (isInternationalSystemOfUnits_SI) ? -5674.5359 : -10214.16462;
                C2 = (isInternationalSystemOfUnits_SI) ? -0.51523058 : -4.89350301;
                C3 = (isInternationalSystemOfUnits_SI) ? -0.009677843 : -.00537657944;
                C4 = (isInternationalSystemOfUnits_SI) ? 0.00000062215701 : .000000192023769;
                C5 = (isInternationalSystemOfUnits_SI) ? 0.0000000020747825 : 3.55758316E-10;
                C6 = (isInternationalSystemOfUnits_SI) ? -9.484024000000001E-13 : -9.03446883E-14;
                C7 = 4.1635019;
                t = airTemperature + ((isInternationalSystemOfUnits_SI) ? 273.15 : 459.67);

                if (t > 0.0)
                {
                    LnPws = C1 / t + C2 + C3 * t + C4 * t * t + C5 * t * t * t + C6 * t * t * t * t + C7 * Math.Log(t);
                    Pws = Math.Exp(LnPws);   //ASHRAE Eq.(5) PSYCHROMETRICS_F01_06SI.pdf
                }
            }
            return Pws;
        }

        public void CalculateVariables(PsychrometricsData data)
        {
            data.SaturationVaporPressureDryBulb = CalculateVaporPressure(data.IsInternationalSystemOfUnits_SI, data.DryBulbTemperature);
            data.SaturationVaporPressureWetBulb = CalculateVaporPressure(data.IsInternationalSystemOfUnits_SI, data.WetBulbTemperature);

            data.FsDryBulb = CalculateFs(data.IsInternationalSystemOfUnits_SI, data.BarometricPressure, data.DryBulbTemperature);
            data.FsWetBulb = CalculateFs(data.IsInternationalSystemOfUnits_SI, data.BarometricPressure, data.WetBulbTemperature);

            data.WsWetBulb = CalculateSaturatedHumidityRatio(data.BarometricPressure, data.SaturationVaporPressureWetBulb, data.FsWetBulb);  // 'ASHRAE Eq.(21a)
            data.WsDryBulb = CalculateSaturatedHumidityRatio(data.BarometricPressure, data.SaturationVaporPressureDryBulb, data.FsDryBulb);  // 'ASHRAE Eq.(21a)
        }

        // void IPWBsearch (double psi, double RelHumid, double TDB, double& TWB)
        // void SIWBsearch (double psi, double RelHumid, double TDB, double& TWB)
        // public double CalculatetemperatureWetBulbIP(PsychrometricsData data)
        // (double pressure, double temperatureDryBulb, double temperatureWetBulb)
        public double CalculateWetBulbTemperature(PsychrometricsData data)
        {
            double temperatureTolerance = .0005;
            double relativeHumdityDryBulbTolerance = .00005;
            double relativeHumdityMidpoint;

            double relativeHumdityDryBulb = CalculateRelativeHumidity(data.IsInternationalSystemOfUnits_SI, data.BarometricPressure, data.DryBulbTemperature, data.DryBulbTemperature);

            //Calculate saturation value and compare to program and tolerance limits
            if (Math.Abs(relativeHumdityDryBulb - (data.RelativeHumidity / 100)) <= relativeHumdityDryBulbTolerance)
            {
                return data.DryBulbTemperature;
            }

            // Begin bisection root search procedure from Numerical Recipes in BASIC, p 193   
            double t1 = (data.IsInternationalSystemOfUnits_SI) ? -20.0 : 0.0;
            double t2 = data.DryBulbTemperature;
            double trtbis = t1;
            double DT = t2 - t1;
            double tmid;
            double relativeHumidity;

            do
            {
                DT /= 2;
                tmid = trtbis + DT;
                relativeHumidity = CalculateRelativeHumidity(data.IsInternationalSystemOfUnits_SI, data.BarometricPressure, data.DryBulbTemperature, tmid);
                relativeHumdityMidpoint = data.RelativeHumidity - relativeHumidity;
                if (relativeHumdityMidpoint >= 0.0)
                {
                    trtbis = tmid;
                }
            }
            while ((Math.Abs(DT) >= temperatureTolerance) && (relativeHumdityMidpoint != 0.0));

            // found wet bulb
            return tmid;
        }

        // streamlined Enthalpy function for demand curves
        public double CalculateEnthalpy(bool isSI, double pressure, double dryBulbTemperature, double wetBulbTemperature)
        {
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = isSI,
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
        public double CalculateMerkel(MerkelData merkelData)
        {
            short i;
            double KaV, Ha, Haex, Hain, Hw, Tcold, Thot, Tw;
            double[] X = new double[4] { 0.9, 0.6, 0.4, 0.1 };
            double pressure = 14.696;

            if (merkelData.IsInternationalSystemOfUnits_SI)
            {
                merkelData.WetBulbTemperature = UnitConverter.ConvertCelsiusToFahrenheit(merkelData.WetBulbTemperature);
                merkelData.HotWaterTemperature = UnitConverter.ConvertCelsiusToFahrenheit(merkelData.HotWaterTemperature); // T1
                merkelData.ColdWaterTemperature = UnitConverter.ConvertCelsiusToFahrenheit(merkelData.ColdWaterTemperature); // T2
                merkelData.Elevation = UnitConverter.ConvertMetersToFeet(merkelData.Elevation);
            }

            merkelData.Range = merkelData.HotWaterTemperature - merkelData.ColdWaterTemperature;
            merkelData.Approach = merkelData.ColdWaterTemperature - merkelData.WetBulbTemperature;

            if (merkelData.Elevation != 0)
            {
                pressure = StandardAtmosphericPressure(merkelData.Elevation);
            }

            Hain = CalculateEnthalpy(false, pressure, merkelData.WetBulbTemperature, merkelData.WetBulbTemperature);
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
                Hw = CalculateEnthalpy(false, pressure, Tw, Tw);
                Ha = Hain + X[i] * (Haex - Hain);
                if (Hw <= Ha)
                {
                    return (999);
                }
                KaV += .25 / (Hw - Ha);
            }

            merkelData.KaV_L = KaV * merkelData.Range;

            return merkelData.KaV_L;
        }

        public double StandardAtmosphericPressure(double Z)
        {
            Z /= 10000.0;
            return (.491154 * ((.547462 * Z - 7.67923) * Z + 29.9309) / (.10803 * Z + 1.0));
        }

        public void EnthalpySearch(bool saturation, PsychrometricsData data)
        {
            //'****** Procedure finds SI WB, DB & properties given enthalpy & pressure **
            //'****** Uses bisection method to search for roots.  Limits -20 to 60 øC ****
            //'Establish tolerance on enthalpy search

            double temperatureTolerance = (data.IsInternationalSystemOfUnits_SI) ? 0.00001 : 0.0001;
            double Htolerance = 0.00005;
            double temperatureCold = (data.IsInternationalSystemOfUnits_SI) ? -20.0 : 0.0; // cold
            double temperatureHot = (data.IsInternationalSystemOfUnits_SI) ? 60.0 : 140;  // hot

             //First need to bracket region of WB/DB to created bisection region
            //High and low values are -20ø and 60ø.
            //Calculate low value and compare to program and tolerance limits
            data.WetBulbTemperature = temperatureCold;

            if (saturation)
            {
                data.DryBulbTemperature = data.WetBulbTemperature;
            }

            CalculateProperties(data);

            if (Math.Abs(data.Enthalpy - data.RootEnthalpy) <= Htolerance)
            {
                // assert low temperature Enthalpy absolution difference lower than tolerance
                data.Enthalpy = 0.0;
                return;
            }

            if (data.RootEnthalpy < data.Enthalpy)
            {
                // assert low temperature root Enthalpy less than calculated Enthalpy
                ////todo ASSERT(0);
                //LOCATE 17, 10: PRINT "Enthalpy ref of range of program"
                data.Enthalpy = 0.0;
                return;
            }

            //Calculate high value and compare to program and tolerance limits
            data.WetBulbTemperature = temperatureHot;

            if (saturation)
            {
                data.DryBulbTemperature = data.WetBulbTemperature;
            }

            CalculateProperties(data);

            if (Math.Abs(data.Enthalpy - data.RootEnthalpy) <= Htolerance)
            {
                // assert high temperature Enthalpy absolution difference lower than tolerance
                data.Enthalpy = 0.0;
                return;
            }

            if (data.RootEnthalpy > data.Enthalpy)
            {
                ////todo ASSERT(0);
                //LOCATE 17, 10: PRINT "Enthalpy ref of range of program"
                // assert high temperature root Enthalpy less than calculated Enthalpy
                data.Enthalpy = 0.0;
                return;
            }

            //Begin bisection root search procedure from Numerical Recipes in BASIC, p 193
            double trtbis = temperatureCold;
            double DT = temperatureHot - temperatureCold;
            double enthalpyMidPoint;

            do
            {
                DT /= 2.0;
                data.WetBulbTemperature = trtbis + DT;

                if (saturation)
                {
                    data.DryBulbTemperature = data.WetBulbTemperature;
                }

                CalculateProperties(data);

                enthalpyMidPoint = data.RootEnthalpy - data.Enthalpy;

                if (enthalpyMidPoint >= 0.0)
                {
                    trtbis = data.WetBulbTemperature;
                }
            } 
            while ((Math.Abs(DT) >= temperatureTolerance) && (enthalpyMidPoint != 0.0));

            if (saturation)
            {
                data.DryBulbTemperature = data.WetBulbTemperature;
            }
        }

        public void CalculateProperties(PsychrometricsData data)
        {
            /*
            if (!data.IsInternationalSystemOfUnits_SI)
            {
                data.BarometricPressure = UnitConverter.ConvertBarometricPressureToPsi(data.BarometricPressure);
            }
            */

            CalculateVariables(data);

            // Calculate humidity ratio of the mixture
            // humidityRatio = ((1093. - .556 * data.WetBulbTemperature) * WsWB - .24 * (data.DryBulbTemperature - data.WetBulbTemperature)) / (1093. + .444 * data.DryBulbTemperature - data.WetBulbTemperature);  //ASHRAE Eq.(33)
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

        public double CalculateHumidityRatio(bool isInternationalSystemOfUnits_SI, double barometricPressure, double saturationVaporPressure, double fs, double dryBulbTemperature, double wetBulbTemperature)
        {
            // WsWB = humidity ratio of moist air at saturation at thermodynamic wet bulb temperature --- saturation humidity ratio Ws
            double Ws = CalculateSaturatedHumidityRatio(barometricPressure, saturationVaporPressure, fs);

            // Calculate humidity ratio of the mixture
            double c1 = (isInternationalSystemOfUnits_SI) ? 2501.0 : 1093.0;
            double c2 = (isInternationalSystemOfUnits_SI) ? 1.805 : 0.444;
            double c3 = (isInternationalSystemOfUnits_SI) ? 2.381 : 0.556;
            double c4 = (isInternationalSystemOfUnits_SI) ? 1.0 : 0.24;
            double c5 = (isInternationalSystemOfUnits_SI) ? 4.186 : 1.0;

            double denominator = c1 + c2 * dryBulbTemperature - c5 * wetBulbTemperature;

            return (denominator == 0.0) ? 0.0 : ((c1 - c3 * wetBulbTemperature) * Ws - (c4 * (dryBulbTemperature - wetBulbTemperature))) / denominator;  // ASHRAE Eq.(33)
        }

        public double CalculateHumidityRatio(PsychrometricsData data)
        {
            // WsWB = humidity ratio of moist air at saturation at thermodynamic wet bulb temperature --- saturation humidity ratio Ws
            // Calculate humidity ratio of the mixture
            double c1 = (data.IsInternationalSystemOfUnits_SI) ? 2501.0 : 1093.0;
            double c2 = (data.IsInternationalSystemOfUnits_SI) ? 1.805 : 0.444;
            double c3 = (data.IsInternationalSystemOfUnits_SI) ? 2.381 : 0.556;
            double c4 = (data.IsInternationalSystemOfUnits_SI) ? 1.0 : 0.24;
            double c5 = (data.IsInternationalSystemOfUnits_SI) ? 4.186 : 1.0;

            double denominator = c1 + c2 * data.DryBulbTemperature - c5 * data.WetBulbTemperature;

            return (denominator == 0.0) ? 0.0 : ((c1 - c3 * data.WetBulbTemperature) * data.WsWetBulb - (c4 * (data.DryBulbTemperature - data.WetBulbTemperature))) / denominator;  // ASHRAE Eq.(33)
        }

        public double CalculateDegreeOfSaturation(PsychrometricsData data)
        {
            double degreeOfSaturation = 0.0;

            // Calculate degree of saturation
            if (data.WsDryBulb != 0.0)
            {
                degreeOfSaturation = data.HumidityRatio / data.WsDryBulb;           //ASHRAE Eq.(10)
            }

            return degreeOfSaturation;
        }


        public double CalculateRelativeHumidity(bool isInternationalSystemOfUnits_SI, double barometricPressure, double DryBulbTemperature, double WetBulbTemperature)
        {
            if (barometricPressure == 0.0)
            {
                return 0.0;
            }

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI,
                WetBulbTemperature = WetBulbTemperature,
                DryBulbTemperature = DryBulbTemperature,
                BarometricPressure = barometricPressure
            };

            CalculateVariables(data);

            data.HumidityRatio = CalculateHumidityRatio(data);

            data.DegreeOfSaturation = CalculateDegreeOfSaturation(data); // WsDB != 0.0 ? (HumidityRatio / WsDB) : 0.0;

            return CalculateRelativeHumidity(data);
        }

        public double CalculateRelativeHumidity(PsychrometricsData data)
        {
            double denominator = ((data.BarometricPressure == 0.0) ? 0.0 : (1.0 - (1.0 - data.DegreeOfSaturation) * (data.FsDryBulb * data.SaturationVaporPressureDryBulb / data.BarometricPressure)));
            data.RelativeHumidity = (denominator == 0.0) ? 0.0 : data.DegreeOfSaturation / denominator;  //ASHRAE Eq.(23a)

            return data.RelativeHumidity;
        }

        public double CalculateSpecificVolume(PsychrometricsData data)
        {
            double Ra = (data.IsInternationalSystemOfUnits_SI) ? (287.055 / 1000) : (53.352 / 144.0);
            double c1 = (data.IsInternationalSystemOfUnits_SI) ? 273.15 : 459.67;

            data.SpecificVolume = (data.BarometricPressure == 0.0) ? 0.0 : (Ra * (data.DryBulbTemperature + c1) * (1.0 + 1.6078 * data.HumidityRatio) / data.BarometricPressure);   //ASHRAE Eq.(26)
            
            return data.SpecificVolume;
        }

        public double CalculateDensity(PsychrometricsData data)
        {
            data.Density = (data.SpecificVolume == 0.0) ? 0.0 : ((1.0 + data.HumidityRatio) / data.SpecificVolume);
            
            return data.Density;
        }

        // streamlined Enthalpy function for demand curves
        public double CalculateEnthalpy(PsychrometricsData data)
        {
            double c1 = (data.IsInternationalSystemOfUnits_SI) ? 1.006 : 0.24;
            double c2 = (data.IsInternationalSystemOfUnits_SI) ? 2501.0 : 1061.0;
            double c3 = (data.IsInternationalSystemOfUnits_SI) ? 1.805 : 0.444;

            // Calculate enthalpy
            data.Enthalpy = c1 * data.DryBulbTemperature + data.HumidityRatio * (c2 + c3 * data.DryBulbTemperature);  //ASHRAE Eq.(30)
            
            return data.Enthalpy;
        }

        //*** Function to find DewPoint
        //*** Converges to the same Humidity Ratio as if you had entered
        //*** saturated conditions (DB=WB)
        public double CalculateDewPoint(PsychrometricsData data)
        {
            int iLoop;
            double dewPointPressure;
            double lnpw;
            double vaporPressureDewPoint;
            double wsDewPoint;
            double deltaT;
            double t;
            double derivativeOfVaporPressure;
            double derivativeOfHumidityRatio;
            double fsDewPoint;

            // Method to determine Dew Point - Fs varies with temp - Process in iterative passes.
            double dewPoint = data.WetBulbTemperature;

            if (data.HumidityRatio <= 0.0)
            {
                dewPoint = 0.0;
            }
            else
            {
                double C1 = (data.IsInternationalSystemOfUnits_SI) ? -5674.5359 : -10214.16462;
                double C3 = (data.IsInternationalSystemOfUnits_SI) ? -0.009677843 : -0.00537657944;
                double C4 = (data.IsInternationalSystemOfUnits_SI) ? 0.00000062215701 : 0.000000192023769;
                double C5 = (data.IsInternationalSystemOfUnits_SI) ? 0.0000000020747825 : 3.55758316E-10;
                double C6 = (data.IsInternationalSystemOfUnits_SI) ? -9.484024000000001E-13 : -9.03446883E-14;
                double C7 = 4.1635019;

                double C8 = (data.IsInternationalSystemOfUnits_SI) ? -5800.2206 : -10440.39708;
                double C10 = (data.IsInternationalSystemOfUnits_SI) ? -0.048640239 : -0.027022355;
                double C11 = (data.IsInternationalSystemOfUnits_SI) ? 0.000041764768 : 0.00001289036;
                double C12 = (data.IsInternationalSystemOfUnits_SI) ? -0.000000014452093 : -0.000000002478068;
                double C13 = 6.5459673;

                double C14 = (data.IsInternationalSystemOfUnits_SI) ? 6.54 : 100.45;
                double C15 = (data.IsInternationalSystemOfUnits_SI) ? 14.526 : 33.193;
                double C16 = (data.IsInternationalSystemOfUnits_SI) ? 0.7389 : 2.319;
                double C17 = (data.IsInternationalSystemOfUnits_SI) ? 0.09486 : 0.17074;
                double C18 = (data.IsInternationalSystemOfUnits_SI) ? 0.4569 : 1.2063;

                double denominator;
                double freezing = (data.IsInternationalSystemOfUnits_SI) ? 0.0 : 32.0;
                double c1 = (data.IsInternationalSystemOfUnits_SI) ? 6.09 : 90.12;
                double c2 = (data.IsInternationalSystemOfUnits_SI) ? 0.4959 : 0.8927;
                double c3 = (data.IsInternationalSystemOfUnits_SI) ? 12.608 : 26.142;

                fsDewPoint = CalculateFs(data.IsInternationalSystemOfUnits_SI, data.BarometricPressure, dewPoint);

                for (iLoop = 1; iLoop <= 2; iLoop++)      // Makes exactly two passes to get best first estimate
                {
                    // Calculate dew point pressure
                    denominator = (fsDewPoint * (0.62198 + data.HumidityRatio));
                    dewPointPressure = (denominator == 0.0) ? 0.0 : (data.BarometricPressure * data.HumidityRatio / denominator);  //ASHRAE Eq.(34)

                    if (dewPointPressure > 0)
                    {
                        // Calculate dew point temperature - check above and below ice point
                        if (dewPoint < freezing)
                        {
                            lnpw = Math.Log(dewPointPressure);
                            dewPoint = c1 + c3 * lnpw + c2 * Math.Pow(lnpw, 2.0);   //ASHRAE Eq.(36)
                        }
                        else
                        {
                            lnpw = Math.Log(dewPointPressure);
                            dewPoint = C14 + C15 * lnpw + C16 * Math.Pow(lnpw, 2.0) + C17 * Math.Pow(lnpw, 3.0) + C18 * Math.Pow(dewPointPressure, 0.1984);  //ASHRAE Eq.(36)
                        }
                    }
                    else
                    {
                        dewPoint = 0;
                    }

                    fsDewPoint = CalculateFs(data.IsInternationalSystemOfUnits_SI, data.BarometricPressure, dewPoint);
                }

                vaporPressureDewPoint = CalculateVaporPressure(data.IsInternationalSystemOfUnits_SI, dewPoint);
                denominator = (data.BarometricPressure - vaporPressureDewPoint * fsDewPoint);
                wsDewPoint = (denominator == 0.0) ? 0.0 : (0.62198 * vaporPressureDewPoint * fsDewPoint / denominator);
                deltaT = 1.0;

                // DavidL, 04/26/2001: Fixed the loop conditions to mimic IPDEWPoint()
                while ((wsDewPoint != 0.0) && ((Math.Abs(data.HumidityRatio / wsDewPoint - 1.0) >= 0.000001) || (Math.Abs(deltaT) >= 0.0001)))
                {
                    vaporPressureDewPoint = CalculateVaporPressure(data.IsInternationalSystemOfUnits_SI, dewPoint);
                    
                    fsDewPoint = CalculateFs(data.IsInternationalSystemOfUnits_SI, data.BarometricPressure, dewPoint);

                    denominator = (data.BarometricPressure - vaporPressureDewPoint * fsDewPoint);
                    wsDewPoint = (denominator == 0.0) ? 0.0 : (0.62198 * vaporPressureDewPoint * fsDewPoint / denominator);

                    //Calculate DERivative of Vapor Pressure
                    t = dewPoint + ((data.IsInternationalSystemOfUnits_SI) ? 273.15 : 459.67);

                    if (t == 0.0)
                    {
                        derivativeOfVaporPressure = 0.0;
                    }
                    else
                    {
                        if (dewPoint >= freezing)
                        {
                            derivativeOfVaporPressure = vaporPressureDewPoint * (-C8 / Math.Pow(t, 2.0) + C10 + 2.0 * C11 * t + 3.0 * C12 * t * t + C13 / t);
                        }
                        else
                        {
                            derivativeOfVaporPressure = vaporPressureDewPoint * (-C1 / Math.Pow(t, 2.0) + C3 + 2.0 * C4 * t + 3.0 * C5 * t * t + 4.0 * C6 * Math.Pow(t, 3.0) + C7 / t);
                        }
                    }

                    //*****************************************************************************

                    //Calculate DERivative of Humidity Ratio
                    denominator = Math.Pow((data.BarometricPressure - fsDewPoint * vaporPressureDewPoint), 2.0);
                    derivativeOfHumidityRatio = (denominator == 0.0) ? 0.0 : ((data.BarometricPressure - vaporPressureDewPoint * fsDewPoint) * 0.62198 * fsDewPoint * derivativeOfVaporPressure - (0.62198 * fsDewPoint * vaporPressureDewPoint) * (-fsDewPoint * derivativeOfVaporPressure)) / denominator;

                    //Converge to given humidityRatio using Newton-Raphson Method
                    //Yields abref one order of magnitude correction per iteration
                    deltaT = derivativeOfHumidityRatio != 0.0 ? ((data.HumidityRatio - wsDewPoint) / derivativeOfHumidityRatio) : 0.0;
                    dewPoint += deltaT;
                }
            }

            data.DewPoint = dewPoint;

            return data.DewPoint;
        }

        public void CalculatePerformanceData(List<double> x, List<double> ymeas, double xreal, ref double yfit, List<double> y2, StringBuilder errorMessage)
        {
            //'						I			I			I				I				O			O
            //'  EXAMPLE:			4			2			112
            //'						9			113
            //'						16			114
            //'						23			115
            //'     DIM YMEASP(INUM)

            //' DETERMINE THE SECOND DERIVITATIVES FOR THE SPLINE INTERPOLATION
            Spline(x, ymeas, 1E+31, 1E+31, y2, errorMessage);

            //' DETERMINE INTERPOLATED VALUES
            Splint(x, ymeas, y2, xreal, ref yfit, errorMessage);

            //'ERASE YMEASP
        }

        public void Spline(List<double> x, List<double> y, double yp1, double ypn, List<double> y2, StringBuilder errorMessage)
        {
            // 3.3 Cubic Spline Interpolation from Numerical Recipes in C, p43 Second Edition
            double qn;
            double un;
            List<double> u = new List<double>();
            int i;

            // Check preconditions
            if (x.Count != y.Count)
            {
                errorMessage.AppendLine("The x and y array size must be equal to perform the calculation.");
                return;
            }

            // make sure there are at least 2 values
            if (x.Count < 2)
            {
                errorMessage.AppendLine("There must be at least 2 values to perform the calculation.");
                return;
            }

            // make sure the are ascending values
            for (i = 0; i < x.Count - 1; i++)
            {
                if (x[i] >= x[i+1])
                {
                    errorMessage.AppendLine("The values must be in ascending order to perform the calculation.");
                    return;
                }
            }

            for (i = 0; i < x.Count; i++)
            {
                u.Add(0.0);
                y2.Add(0.0);
            }

            //The lower boundary condition is set either to be “natural” or else to have a specified first derivative
            if (yp1 > 9.9E+29)
            {
                y2[0] = 0.0;
                u[0] = 0.0;
            }
            else
            {
                y2[0] = -0.5;
                u[0] = (3.0 / (x[1] - x[0])) * ((y[1] - y[0]) / (x[1] - x[0]) - yp1);
            }

            // Convert number down by 1
            // This is the decomposition loop of the tridiagonal algorithm. y2 and u are used for temporary storage of the decomposed factors.
            for (i = 1; i < x.Count - 1; i++)
            {
                double sig = (x[i] - x[i - 1]) / (x[i + 1] - x[i - 1]);
                double p = sig * y2[i - 1] + 2.0;
                y2[i] = (sig - 1.0) / p;
                double value1 = (y[i + 1] - y[i]) / (x[i + 1] - x[i]);
                double value2 = (y[i] - y[i - 1]) / (x[i] - x[i - 1]);
                u[i] = (6.0 * (value1 - value2) / (x[i + 1] - x[i - 1]) - sig * u[i - 1]) / p;
            }

            if (ypn > 9.9E+29)
            {
                qn = 0.0;
                un = 0.0;
            }
            else
            {
                qn = 0.5;
                un = (3.0 / (x[x.Count - 1] - x[x.Count - 2])) * (ypn - (y[y.Count - 1] - y[y.Count - 2]) / (x[x.Count - 1] - x[x.Count - 2]));
            }

            // This is the backsubstitution loop of the tridiagonal algorithm.
            y2[x.Count - 1] = (un - qn * u[x.Count - 2]) / (qn * y2[x.Count - 2] + 1.0);

            for (int k = x.Count - 2; k >= 0; k--)
            {
                y2[k] = y2[k] * y2[k + 1] + u[k];
            }
        }

        public void Splint(List<double> xa, List<double> ya, List<double> y2a, double x, ref double y, StringBuilder errorMessage)
        {
            y = 0.0;

            //' Determine interpolated Y value
            //' Rev: 2-22-99 to handle either Increasing or Decreasing XA array
            // Check preconditions
            if ((xa.Count != ya.Count) || (xa.Count != y2a.Count))
            {
                errorMessage.AppendLine("The array sizes must be equal to perform the calculation.");
                return;
            }

            // make sure there are at least 2 values
            if (xa.Count < 2)
            {
                errorMessage.AppendLine("There must be at least 2 values in order to perform the calculation.");
                return;
            }

            // make sure the first 2 values are not equal
            if (xa[0] == xa[1])
            {
                errorMessage.AppendLine("The first two values must be not equal in order to perform the calculation.");
                return;
            }

            int kLow = 0;
            int kHigh = (xa.Count - 1);
            bool increasingX = (xa[1] > xa[0]);

            //We will find the right place in the table by means of bisection. This is optimal if sequential calls to this
            //routine are at random values of x. If sequential calls are in order, and closely spaced, one would do better
            //to store previous values of klo and khi and test if they remain appropriate on the next call.
            while (kHigh - kLow > 1)
            {
                int k = ((kHigh + kLow) / 2);
                if (increasingX)
                {
                    if (xa[k] > x)
                    {
                        kHigh = k;
                    }
                    else
                    {
                        kLow = k;
                    }
                }
                else               //X DECREASING
                {
                    if (xa[k] > x)
                    {
                        kLow = k;
                    }
                    else
                    {
                        kHigh = k;
                    }
                }
            }

            double h = (xa[kHigh] - xa[kLow]);
            if (h == 0.0)
            {
                errorMessage.AppendLine("The bisection values must be unique in order to perform the calculation.");
                return;
            }

            double a = ((xa[kHigh] - x) / h);
            double b = ((x - xa[kLow]) / h);
            y = a * ya[kLow] + b * ya[kHigh];

            // Change suggested by Rich Harrison on Aug. 3, 2001:
            // Do just the linear fit (last calc above) if x is beyond array range
            if (((increasingX) && (x > xa[0]) && (x < xa[xa.Count - 1])) || ((!increasingX) && (x > xa[xa.Count - 1]) && (x < xa[0])))
            {
                y += ((Math.Pow(a, 3.0) - a) * y2a[kLow] + (Math.Pow(b, 3.0) - b) * y2a[kHigh]) * (Math.Pow(h, 2.0)) / 6.0;
            }
            else
            {
                if (increasingX)
                {
                    errorMessage.AppendLine("X value is out of range of the increasing XA values.");
                    return;
                }
                else
                {
                    errorMessage.AppendLine("X value is out of range of the decreasing XA values.");
                    return;
                }
            }
        }

        public double CalculateTestLiquidToGasRatio(MechanicalDraftPerformanceCurveFileData data, PsychrometricsData testPsychrometricsData, PsychrometricsData designPsychrometricsData)
        {
            double liquidToGasRatio = 0;
            double oneThird = (1.0 / 3.0);
            if ((data.DesignData.MechanicalDraftPerformanceCurveData.WaterFlowRate != 0) 
             && (data.TestData.FanDriverPower != 0) 
             && (designPsychrometricsData.Density != 0) 
             && (designPsychrometricsData.SpecificVolume != 0))
            {
                liquidToGasRatio = data.DesignData.MechanicalDraftPerformanceCurveData.LiquidToGasRatio 
                                   * (data.TestData.WaterFlowRate / data.DesignData.MechanicalDraftPerformanceCurveData.WaterFlowRate)
                                   * Math.Pow((data.DesignData.MechanicalDraftPerformanceCurveData.FanDriverPower / data.TestData.FanDriverPower), oneThird)
                                   * Math.Pow((testPsychrometricsData.Density / designPsychrometricsData.Density), oneThird)
                                   * (testPsychrometricsData.SpecificVolume / designPsychrometricsData.SpecificVolume);
            }
            return liquidToGasRatio;
        }

        public double CalculateAdjustedFlow(double testWaterFlowRate, double designFanDriverPower, double testFanDriverPower, double designAirDensity, double testAirDensity)
        {
            double oneThird = (1.0 / 3.0);
            return testWaterFlowRate * Math.Pow((designFanDriverPower / testFanDriverPower), oneThird) * Math.Pow((testAirDensity / designAirDensity), oneThird);
        }

        public double DetermineAdjustedTestFlow(MechanicalDraftPerformanceCurveFileData data, MechanicalDraftPerformanceCurveOutput output)
        {
            double Cpw = (data.IsInternationalSystemOfUnits_SI) ? 4.186 : 1.0; // specific heat at constant pressure
            
            PsychrometricsData testPsychrometricsData = new PsychrometricsData(data.TestData);
            PsychrometricsData designPsychrometricsData = new PsychrometricsData(data.DesignData.MechanicalDraftPerformanceCurveData);
            if(!data.IsInternationalSystemOfUnits_SI)
            {
                designPsychrometricsData.BarometricPressure = UnitConverter.ConvertBarometricPressureToPsi(designPsychrometricsData.BarometricPressure);
                testPsychrometricsData.BarometricPressure = UnitConverter.ConvertBarometricPressureToPsi(testPsychrometricsData.BarometricPressure);
            }

            CalculateProperties(designPsychrometricsData);
            CalculateProperties(testPsychrometricsData);

            PsychrometricsData searchDesignPsychrometricsData = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = designPsychrometricsData.IsInternationalSystemOfUnits_SI,
                BarometricPressure = designPsychrometricsData.BarometricPressure
            };

            if (data.DesignData.TowerType == TOWER_TYPE.Induced)      //'compute AdjTestFlow on LEAVING air temperatures
            {
                //'  LEAVING AIR CONDITIONS - Predicted Leaving Wet Bulb

                //'First determine Design Leaving Air Density, designPsychrometricsData.Density  *****************************
                //'first step is determine Leaving air Enthalpy Design, HOutD                
                searchDesignPsychrometricsData.RootEnthalpy = designPsychrometricsData.Enthalpy 
                                                        + data.DesignData.MechanicalDraftPerformanceCurveData.LiquidToGasRatio 
                                                        * Cpw 
                                                        * (data.DesignData.MechanicalDraftPerformanceCurveData.HotWaterTemperature - data.DesignData.MechanicalDraftPerformanceCurveData.ColdWaterTemperature);

                //EnthalpysearchIP(int sat, double P,                                    double RootEnthalpy, ref double OutputEnthalpy, ref double temperatureWetBulb, ref double temperatureDryBulb, ref double humidityRatio, ref double relativeHumidity, ref double specificVolume, ref double Density, ref double DEWPoint)
                //EnthalpysearchIP(1,       designPsychrometricsData.BarometricPressure, HOutD,               ref OutputEnthalpy,        ref LWBD,                      ref LDBD,                      ref humidityRatio,        ref relativeHumidity,        ref designPsychrometricsData.SpecificVolume,                ref designPsychrometricsData.Density,        ref DEWPoint);

                //'Call Enthalpy Search subroutine with calculated HOutD value
                EnthalpySearch(true, searchDesignPsychrometricsData);

                //    //'Store Density Out as Density Design and SV Out as SV Design
                output.Density = searchDesignPsychrometricsData.Density;

                // Next Iterate to find Test Leaving Wet bulb and testPsychrometricsData.Density
                // Initial guess of Leaving Wet Bulb is average of Test Entering and Leaving temperature
                testPsychrometricsData.WetBulbTemperature = testPsychrometricsData.DryBulbTemperature = (data.TestData.HotWaterTemperature + data.TestData.ColdWaterTemperature) / 2.0;
                double enthalpy = testPsychrometricsData.Enthalpy;

                PsychrometricsData testSearchPsychrometricsData = new PsychrometricsData()
                {
                    IsInternationalSystemOfUnits_SI = designPsychrometricsData.IsInternationalSystemOfUnits_SI,
                    BarometricPressure = testPsychrometricsData.BarometricPressure
                };

                bool bGoto200 = true;
                while (bGoto200)
                {
                    //200 'Top of iteration loop *****************************************************************
                    //' Determine conditions of air at guess Leaving Wet Bulb (assumed saturated LDB=LWB)
                    CalculateProperties(testPsychrometricsData);

                    output.SpecificVolume = testPsychrometricsData.SpecificVolume;
                    output.WetBulbTemperature = testPsychrometricsData.Enthalpy;

                    //'Calculate L/G Test
                    //'Equation 5.1, Liquid to Gas ratio Test
                    output.LiquidToGasRatio = CalculateTestLiquidToGasRatio(data, testPsychrometricsData, searchDesignPsychrometricsData);
                    //if ((data.DesignData.MechanicalDraftPerformanceCurveData.WaterFlowRate == 0.0) || (searchDesignPsychrometricsData.Density == 0.0) || (data.TestData.FanDriverPower == 0.0) || (searchDesignPsychrometricsData.SpecificVolume == 0.0))
                    //{
                    //    output.LiquidToGasRatio = 0.0;
                    //}
                    //else
                    //{
                    //    output.LiquidToGasRatio = data.DesignData.MechanicalDraftPerformanceCurveData.LiquidToGasRatio
                    //                              * (data.TestData.WaterFlowRate / data.DesignData.MechanicalDraftPerformanceCurveData.WaterFlowRate)
                    //                              * Math.Pow((testPsychrometricsData.Density / searchDesignPsychrometricsData.Density * data.DesignData.MechanicalDraftPerformanceCurveData.FanDriverPower / data.TestData.FanDriverPower), (1.0 / 3.0))
                    //                              * (testPsychrometricsData.SpecificVolume / searchDesignPsychrometricsData.SpecificVolume);
                    //}

                        // HCalcT = HInT + LinGt * Cpw * (EWTt - LWTt);
                    testSearchPsychrometricsData.RootEnthalpy = enthalpy + output.LiquidToGasRatio * Cpw * (data.TestData.HotWaterTemperature - data.TestData.ColdWaterTemperature);

                    //'Call Enthalpy Search subroutine for calculated Href value
                    EnthalpySearch(true, testSearchPsychrometricsData);

                    output.ColdWaterTemperatureDeviation = testSearchPsychrometricsData.WetBulbTemperature;

                    //'Check to see if Enthalpy  of Leaving Wet Bulb Test (testPsychrometricsData.Enthalpy) converged to calculated value (HCalcT)
                    if (Math.Abs(testSearchPsychrometricsData.RootEnthalpy - testSearchPsychrometricsData.Enthalpy) > 0.0002)
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
                //'        ENTERING air conditions  Test and Design
                testPsychrometricsData.Density = testPsychrometricsData.Density; // DenTest = DenInT;
                searchDesignPsychrometricsData.Density = designPsychrometricsData.Density; // DenDesign = DenInD

                // Try these values for Forced Draft option
                // (Toolkit v3.0 Build #5, DBL - 05/23/03)
                output.ColdWaterTemperatureDeviation  = testPsychrometricsData.Enthalpy; // HLWBT = HInT 
                output.SpecificVolume = testPsychrometricsData.SpecificVolume; // SVOutT = SVInT
                output.Density = testPsychrometricsData.Density; // DenOutT = DenInT;
                output.WetBulbTemperature = data.TestData.WetBulbTemperature; // LWBTnew = EWBt;
            }

            //'Equation 6.1, Adjusted TestFlow
            output.AdjustedFlow = ((data.TestData.FanDriverPower == 0.0) || (searchDesignPsychrometricsData.Density == 0.0)) ? 0.0 : 
                data.TestData.WaterFlowRate * Math.Pow(data.DesignData.MechanicalDraftPerformanceCurveData.FanDriverPower / data.TestData.FanDriverPower * testPsychrometricsData.Density / searchDesignPsychrometricsData.Density, (1.0 / 3.0));

            output.Density = testPsychrometricsData.Density;

            return output.AdjustedFlow;
        }
    }
}
