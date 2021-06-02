// Copyright Cooling Technology Institute 2019-2021

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using Models;

namespace CalculationLibrary
{
    public class MechanicalDraftPerformanceCurveCalculationLibrary : CalculationLibrary
    {
        const int MAX_COLD_WATER_TEMPERATURE_DEVIATION_ITERATIONS = 1000;

        public void MechanicalDraftPerformanceCurveCalculation(MechanicalDraftPerformanceCurveCalculationData data, bool calculateWetBulbDeviation)
        {
            List<double> y;
            List<double> y2 = new List<double>();
            StringBuilder stringBuilder = new StringBuilder();

            DetermineAdjustedTestFlow(data, data.TowerDesignData, data.TowerDesignData, data.DesignOutput);

            InterpolateWetBulbTemperature(data);
            
            InterpolateRange(data);

            //'Final interpolation for Flow (Y) vs COLD_WATER_TEMPERATURE (X)
            //'Rev:1-23-01 Added check for EXTRAPOLATED flow (y contains the flow rates from the above loop)
            double minimumFlow = data.FindMinimumWaterFlowRate();
            double maximumFlow = data.FindMaximumWaterFlowRate();

            y = data.GetWaterFlowRates();
            y2.Clear();
            double yfit = 0.0;

            CalculatePerformanceData(data.InterpolateRanges, y, data.TowerTestData.ColdWaterTemperature, ref yfit, y2, stringBuilder);
            double predicatedFlow = yfit;

            if ((predicatedFlow < minimumFlow) || (predicatedFlow > maximumFlow))
            {
                data.TestOutput.ErrorMessage = string.Format("CAUTION: Predicted Flow {0} is EXTRAPOLATED beyond the Supplied Curve Flows of {1} to {2}", predicatedFlow.ToString("F2"), minimumFlow.ToString("F2"), maximumFlow.ToString("F2"));
            }
            //'End check for Extrapolation

            //data.TestOutput.Clear();
            data.TestOutput.PredictedFlow = predicatedFlow;
            data.TestOutput.AdjustedFlow = DetermineAdjustedTestFlow(data, data.TowerDesignData, data.TowerTestData, data.TestOutput);
            data.TestOutput.TowerCapability = (predicatedFlow != 0.0) ? (data.TestOutput.AdjustedFlow / data.TestOutput.PredictedFlow * 100.0) : 0.0;

            if (calculateWetBulbDeviation)
            {
                CalculateColdWaterTemperatureDeviation(data);
            }
        }

        public void InterpolateWetBulbTemperature(MechanicalDraftPerformanceCurveCalculationData data)
        {
            //'Interpolate for WB
            List<double> x = new List<double>();
            List<double> y = new List<double>();
            List<double> y2 = new List<double>();
            double yfit = 0.0;
            StringBuilder stringBuilder = new StringBuilder();

            for (int flowRateIndex = 0; flowRateIndex < data.WaterFlowRates.Count; flowRateIndex++)
            {
                data.WaterFlowRates[flowRateIndex].Yfit.Clear();
                for (int rangeIndex = 0; rangeIndex < data.Ranges.Count; rangeIndex++)
                {
                    y.Clear();
                    x.Clear();
                    y2.Clear();
                    for (int wetBulbTemperatureIndex = 0; wetBulbTemperatureIndex < data.WaterFlowRates[flowRateIndex].WetBulbTemperatures.Count; wetBulbTemperatureIndex++)
                    {
                        x.Add(data.WaterFlowRates[flowRateIndex].WetBulbTemperatures[wetBulbTemperatureIndex].Temperature);
                        y.Add(data.WaterFlowRates[flowRateIndex].WetBulbTemperatures[wetBulbTemperatureIndex].ColdWaterTemperatures[rangeIndex]); // COLD_WATER_TEMPERATURE[IFlow][IWB][IR]);
                    }
                    CalculatePerformanceData(x, y, data.TowerTestData.WetBulbTemperature, ref yfit, y2, stringBuilder);
                    data.WaterFlowRates[flowRateIndex].Yfit.Add(yfit);
                }
            }
        }

        public void InterpolateRange(MechanicalDraftPerformanceCurveCalculationData data)
        {
            //'Interpolate for Range
            List<double> x = new List<double>();
            List<double> y = new List<double>();
            List<double> y2 = new List<double>();
            double yfit;
            double testRange = data.TowerTestData.HotWaterTemperature - data.TowerTestData.ColdWaterTemperature;
            StringBuilder stringBuilder = new StringBuilder();

            //'Interpolate for Range
            data.InterpolateRanges.Clear();
            for (int flowRateIndex = 0; flowRateIndex < data.WaterFlowRates.Count; flowRateIndex++)
            {
                y.Clear();
                x.Clear();
                yfit = 0.0;
                for (int rangeIndex = 0; rangeIndex < data.Ranges.Count; rangeIndex++)
                {
                    x.Add(data.Ranges[rangeIndex]);
                    y.Add(data.WaterFlowRates[flowRateIndex].Yfit[rangeIndex]);
                }
                y2.Clear();
                CalculatePerformanceData(x, y, testRange, ref yfit, y2, stringBuilder);
                data.InterpolateRanges.Add(yfit);
            }
        }

        public void CalculateColdWaterTemperatureDeviation(MechanicalDraftPerformanceCurveCalculationData data)
        {
            int iterationCount = 0;

            // save the current Calculated values
            double capability = data.TestOutput.TowerCapability;
            double adjustedFlow = data.TestOutput.AdjustedFlow;
            double predictedFlow = data.TestOutput.PredictedFlow;

            // save Test Values
            TowerSpecifications testHold = new TowerSpecifications(data.TowerTestData);

            // Set test values to design values
            data.TowerTestData.BarometricPressure = data.TowerDesignData.BarometricPressure;
            data.TowerTestData.ColdWaterTemperature = data.TowerDesignData.ColdWaterTemperature;
            data.TowerTestData.DryBulbTemperature = data.TowerDesignData.DryBulbTemperature;
            data.TowerTestData.FanDriverPower = data.TowerDesignData.FanDriverPower;
            data.TowerTestData.HotWaterTemperature = data.TowerDesignData.HotWaterTemperature;
            data.TowerTestData.LiquidToGasRatio = data.TowerDesignData.LiquidToGasRatio;
            data.TowerTestData.WaterFlowRate = data.TowerDesignData.WaterFlowRate;
            data.TowerTestData.WetBulbTemperature = data.TowerDesignData.WetBulbTemperature;

            double estimatedSlope = -10.0;   // original estimate of slope (Cap vs. CWT)
            MechanicalDraftPerformanceCurveCalculation(data, false);
            double deltaCapability = capability - data.TestOutput.TowerCapability;
            while (Math.Abs(deltaCapability) > 0.01)
            {
                double deltaColdWaterTemperature = deltaCapability / estimatedSlope;
                double priorCapability = data.TestOutput.TowerCapability;
                data.TowerTestData.ColdWaterTemperature += deltaColdWaterTemperature;
                data.TowerTestData.HotWaterTemperature += deltaColdWaterTemperature;
                MechanicalDraftPerformanceCurveCalculation(data, false);
                estimatedSlope = (data.TestOutput.TowerCapability - priorCapability) / deltaColdWaterTemperature;
                deltaCapability = capability - data.TestOutput.TowerCapability;
                if (++iterationCount >= MAX_COLD_WATER_TEMPERATURE_DEVIATION_ITERATIONS)
                {
                    break;
                }
            }

            if (iterationCount > MAX_COLD_WATER_TEMPERATURE_DEVIATION_ITERATIONS)
            {
                data.TestOutput.ColdWaterTemperatureDeviation = 0.0;
            }
            else
            {
                data.TestOutput.ColdWaterTemperatureDeviation = data.TowerTestData.ColdWaterTemperature - data.TowerDesignData.ColdWaterTemperature;
            }

            // Restore the Calculated values
            data.TestOutput.TowerCapability = capability;
            data.TestOutput.AdjustedFlow = adjustedFlow;
            data.TestOutput.PredictedFlow = predictedFlow;

            // Restore Real Test Values
            data.TowerTestData.BarometricPressure = testHold.BarometricPressure;
            data.TowerTestData.ColdWaterTemperature = testHold.ColdWaterTemperature;
            data.TowerTestData.DryBulbTemperature = testHold.DryBulbTemperature;
            data.TowerTestData.FanDriverPower = testHold.FanDriverPower;
            data.TowerTestData.HotWaterTemperature = testHold.HotWaterTemperature;
            data.TowerTestData.LiquidToGasRatio = testHold.LiquidToGasRatio;
            data.TowerTestData.WaterFlowRate = testHold.WaterFlowRate;
            data.TowerTestData.WetBulbTemperature = testHold.WetBulbTemperature;
        }

        public void CalculateCrossPlot1(MechanicalDraftPerformanceCurveCalculationData data)
        {
            StringBuilder stringBuilder = new StringBuilder();
            List<double> x = new List<double>();
            List<double> y = new List<double>();
            List<double> y2 = new List<double>();
            double yfit;
            double testX;

            double rangeMinimum = data.FindMinimumRange();
            double rangeMaximum = data.FindMaximumRange();
            double rangeIncrement = (rangeMaximum - rangeMinimum) / 50.0;
            y.Clear();
            x.Clear();
            yfit = 0.0;
            
            InterpolateWetBulbTemperature(data);

            for (double rangeValue = rangeMinimum; rangeValue <= rangeMaximum; rangeValue += rangeIncrement)
            {
                testX = rangeValue;
                yfit = 0.0;
                y2.Clear();
                //CalculatePerformanceData(data.Ranges, data.WaterFlowRates[flowRateIndex].Yfit, testX, ref yfit, y2, stringBuilder);
                data.CrossPlot1.Points.Add(new Point() { X = testX, Y = yfit });

                //CalcPerfDat.a(iCnt, xAxis, yAxis, TestX, YFIT, Y2);
                //m_wndGraph.GetSeries(IFlow).AddXY(TestX, YFIT, NULL, DATACOLOR);
                if (yfit < data.CrossPlot1.ColdWaterTemperatureMinimum)
                {
                    data.CrossPlot1.ColdWaterTemperatureMinimum = yfit;
                }
                else if (yfit > data.CrossPlot1.ColdWaterTemperatureMaximum)
                {
                    data.CrossPlot1.ColdWaterTemperatureMaximum = yfit;
                }
            }

            foreach (WaterFlowRate waterFlowRate in data.WaterFlowRates)
            {
                waterFlowRate.RangePoints.Clear();

                for (int rangeIndex = 0; rangeIndex < data.Ranges.Count; rangeIndex++)
                {
                    //
                    // Iterate through with 50 increments
                    //
                    double increment = (waterFlowRate.WetBulbTemperatures[waterFlowRate.WetBulbTemperatures.Count - 1].Temperature - waterFlowRate.WetBulbTemperatures[0].Temperature) / 50.0;

                    y.Clear();
                    x.Clear();

                    for (int wetBulbTemperatureIndex = 0; wetBulbTemperatureIndex < waterFlowRate.WetBulbTemperatures.Count; wetBulbTemperatureIndex++)
                    {
                        x.Add(waterFlowRate.WetBulbTemperatures[wetBulbTemperatureIndex].Temperature);
                        y.Add(waterFlowRate.WetBulbTemperatures[wetBulbTemperatureIndex].ColdWaterTemperatures[rangeIndex]);
                    }

                    RangePoints rangePoints = new RangePoints();
                    for (double wetBulbTemperature = waterFlowRate.WetBulbTemperatures[0].Temperature; wetBulbTemperature <= waterFlowRate.WetBulbTemperatures[waterFlowRate.WetBulbTemperatures.Count - 1].Temperature; wetBulbTemperature += increment)
                    {
                        testX = wetBulbTemperature;
                        y2.Clear();
                        CalculatePerformanceData(x, y, testX, ref yfit, y2, stringBuilder);
                        rangePoints.Points.Add(new Point() { X = testX, Y = yfit });
                    }
                    waterFlowRate.RangePoints.Add(rangePoints);
                }
            }
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
                if (x[i] >= x[i + 1])
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

            double a = (xa[kHigh] - x) / h;
            double b = (x - xa[kLow]) / h;
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

        public double CalculateTestLiquidToGasRatio(TowerSpecifications towerDesignData, TowerSpecifications towerTestData, 
                                                    PsychrometricsData designPsychrometricsData, PsychrometricsData testPsychrometricsData)
        {
            double liquidToGasRatio = 0;
            double oneThird = (1.0 / 3.0);
  
            if ((towerDesignData.WaterFlowRate != 0)
            && (towerTestData.FanDriverPower != 0)
            && (designPsychrometricsData.Density != 0) // P
            && (designPsychrometricsData.SpecificVolume != 0)) // V
            {
                liquidToGasRatio = towerDesignData.LiquidToGasRatio
                                   * (towerTestData.WaterFlowRate / towerDesignData.WaterFlowRate) // Qw
                                   * Math.Pow((towerDesignData.FanDriverPower / towerTestData.FanDriverPower), oneThird) // W
                                   * Math.Pow((testPsychrometricsData.Density / designPsychrometricsData.Density), oneThird) // P
                                   * (testPsychrometricsData.SpecificVolume / designPsychrometricsData.SpecificVolume); // V
            }
            return liquidToGasRatio;
        }

        public double CalculateAdjustedFlow(double testWaterFlowRate, double designFanDriverPower, double testFanDriverPower, double designAirDensity, double testAirDensity)
        {
            double oneThird = (1.0 / 3.0);
            return testWaterFlowRate * Math.Pow((designFanDriverPower / testFanDriverPower), oneThird) * Math.Pow((testAirDensity / designAirDensity), oneThird);
        }

        public double DetermineAdjustedTestFlow(MechanicalDraftPerformanceCurveCalculationData data, TowerSpecifications towerDesignData, TowerSpecifications towerTestData, MechanicalDraftPerformanceCurveOutput output)
        {
            double Cpw = (data.IsInternationalSystemOfUnits_SI) ? 4.186 : 1.0; // specific heat at constant pressure

            PsychrometricsData testPsychrometricsData = new PsychrometricsData(towerTestData);
            PsychrometricsData designPsychrometricsData = new PsychrometricsData(towerDesignData);

            if (!data.IsInternationalSystemOfUnits_SI)
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

            if (data.TowerType == TOWER_TYPE.Induced)      //'compute AdjTestFlow on LEAVING air temperatures
            {
                //'  LEAVING AIR CONDITIONS - Predicted Leaving Wet Bulb

                //'First determine Design Leaving Air Density, designPsychrometricsData.Density  *****************************
                //'first step is determine Leaving air Enthalpy Design, HOutD                
                searchDesignPsychrometricsData.RootEnthalpy = designPsychrometricsData.Enthalpy
                                                        + towerDesignData.LiquidToGasRatio
                                                        * Cpw
                                                        * (towerDesignData.HotWaterTemperature - towerDesignData.ColdWaterTemperature);

                //EnthalpysearchIP(int sat, double P,                                    double RootEnthalpy, ref double OutputEnthalpy, ref double temperatureWetBulb, ref double temperatureDryBulb, ref double humidityRatio, ref double relativeHumidity, ref double specificVolume, ref double Density, ref double DEWPoint)
                //EnthalpysearchIP(1,       designPsychrometricsData.BarometricPressure, HOutD,               ref OutputEnthalpy,        ref LWBD,                      ref LDBD,                      ref humidityRatio,        ref relativeHumidity,        ref designPsychrometricsData.SpecificVolume,                ref designPsychrometricsData.Density,        ref DEWPoint);

                //'Call Enthalpy Search subroutine with calculated HOutD value
                EnthalpySearch(true, searchDesignPsychrometricsData);

                //    //'Store Density Out as Density Design and SV Out as SV Design
                output.Density = searchDesignPsychrometricsData.Density;

                // Next Iterate to find Test Leaving Wet bulb and testPsychrometricsData.Density
                // Initial guess of Leaving Wet Bulb is average of Test Entering and Leaving temperature
                testPsychrometricsData.WetBulbTemperature = testPsychrometricsData.DryBulbTemperature = (towerTestData.HotWaterTemperature + towerTestData.ColdWaterTemperature) / 2.0;
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

                    //'Calculate L/G Test
                    //'Equation 5.1, Liquid to Gas ratio Test
                    output.LiquidToGasRatio = CalculateTestLiquidToGasRatio(towerDesignData, towerTestData, searchDesignPsychrometricsData, testPsychrometricsData);

                    // HCalcT = HInT + LinGt * Cpw * (EWTt - LWTt);
                    testSearchPsychrometricsData.RootEnthalpy = enthalpy + output.LiquidToGasRatio * Cpw * (towerTestData.HotWaterTemperature - towerTestData.ColdWaterTemperature);

                    //'Call Enthalpy Search subroutine for calculated Href value
                    EnthalpySearch(true, testSearchPsychrometricsData);

                    output.WetBulbTemperature = testSearchPsychrometricsData.WetBulbTemperature;
 
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
                searchDesignPsychrometricsData.Density = designPsychrometricsData.Density; // DenDesign = DenInD
                output.WetBulbTemperature = towerTestData.WetBulbTemperature; // LWBTnew = EWBt;
            }

            output.Enthalpy = testPsychrometricsData.Enthalpy; // HLWBT = HInT 
            output.SpecificVolume = testPsychrometricsData.SpecificVolume; // SVOutT = SVInT
            output.Density = testPsychrometricsData.Density; // DenOutT = DenInT;

            //'Equation 6.1, Adjusted TestFlow
            output.AdjustedFlow = ((towerTestData.FanDriverPower == 0.0) || (searchDesignPsychrometricsData.Density == 0.0)) ? 0.0 :
                towerTestData.WaterFlowRate * Math.Pow(towerDesignData.FanDriverPower / towerTestData.FanDriverPower * testPsychrometricsData.Density / searchDesignPsychrometricsData.Density, (1.0 / 3.0));

            return output.AdjustedFlow;
        }
    }
}