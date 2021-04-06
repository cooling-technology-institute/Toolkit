// Copyright Cooling Technology Institute 2019-2021

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Models;

namespace CalculationLibrary
{
    public class MechanicalDraftPerformanceCurveCalculationLibrary : CalculationLibrary
    {
        const int MAX_COLD_WATER_TEMPERATURE_DEVIATION_ITERATIONS = 1000;

        public void MechanicalDraftPerformanceCurveCalculation(MechanicalDraftPerformanceCurveCalculationData data, MechanicalDraftPerformanceCurveOutput output, bool calculateWetBulbDeviation)
        {
            List<double> y;
            List<double> y2 = new List<double>();
            double yfit;
            double TestColdWaterTemperature = data.TowerTestData.ColdWaterTemperature;
            StringBuilder stringBuilder = new StringBuilder();

            DetermineAdjustedTestFlow(data, output);

            InterpolateWetBulbTemperature(data);
            
            InterpolateRange(data);

            //'Final interpolation for Flow (Y) vs COLD_WATER_TEMPERATURE (X)
            //'Rev:1-23-01 Added check for EXTRAPOLATED flow (y contains the flow rates from the above loop)
            double minimumFlow = data.FindMinimumWaterFlowRate();
            double maximumFlow = data.FindMaximumWaterFlowRate();

            y = data.GetWaterFlowRates();
            yfit = 0.0;
            y2.Clear();

            CalculatePerformanceData(data.WetBulbTemperatureRange, y, TestColdWaterTemperature, ref yfit, y2, stringBuilder);

            double predicatedFlow = yfit;

            if ((predicatedFlow < minimumFlow) || (predicatedFlow > maximumFlow))
            {
                //PRINT #2, STRING$(80, 42)
                //PRINT #2, USING "CAUTION: Predicted Flow ####.## is EXTRAPOLATED beyond the"; PredFlow
                //PRINT #2, USING "Supplied Curve Flows of #####.## to #####.##"; MinFlow; MaxFlow
                //PRINT #2, STRING$(80, 42)
                //CString strWarning;
                //strWarning.Format("CAUTION: Predicted Flow %.02f is EXTRAPOLATED beyond the\r\nSupplied Curve Flows of %.02f to %.02f", PredFlow, MinFlow, MaxFlow);
                //if (bCalcWET_BULB_TEMPERATUREDeviation)
                //{
                //    MessageBox(strWarning, "Extrapolation Warning", MB_ICONWARNING);
                //}
            }
            //'End check for Extrapolation

            output.Clear();
            output.PredictedFlow = predicatedFlow;
            output.AdjustedFlow = DetermineAdjustedTestFlow(data, output);
            output.TowerCapability = (predicatedFlow != 0.0) ? (output.AdjustedFlow / output.PredictedFlow * 100.0) : 0.0;

            if (calculateWetBulbDeviation)
            {
                CalculateWetBulbTemperatureDeviation(data, output);
            }
        }

        private void InterpolateWetBulbTemperature(MechanicalDraftPerformanceCurveCalculationData data)
        {
            //'Interpolate for WB
            List<double> x = new List<double>();
            List<double> y = new List<double>();
            List<double> y2 = new List<double>();
            double yfit;
            double TestWetBulbTemperature = data.TowerTestData.WetBulbTemperature;
            StringBuilder stringBuilder = new StringBuilder();

            for (int flowRateIndex = 0; flowRateIndex < data.WaterFlowRates.Count; flowRateIndex++)
            {
                data.WaterFlowRates[flowRateIndex].Yfit.Clear();
                for (int rangeIndex = 0; rangeIndex < data.Ranges.Count; rangeIndex++)
                {
                    y.Clear();
                    x.Clear();
                    y2.Clear();
                    yfit = 0.0;
                    for (int wetBulbTemperatureIndex = 0; wetBulbTemperatureIndex < data.WaterFlowRates[flowRateIndex].WetBulbTemperatures.Count; wetBulbTemperatureIndex++)
                    {
                        x.Add(data.WaterFlowRates[flowRateIndex].WetBulbTemperatures[wetBulbTemperatureIndex].Temperature);
                        y.Add(data.WaterFlowRates[flowRateIndex].WetBulbTemperatures[wetBulbTemperatureIndex].ColdWaterTemperatures[rangeIndex]); // COLD_WATER_TEMPERATURE[IFlow][IWB][IR]);
                    }
                    CalculatePerformanceData(x, y, TestWetBulbTemperature, ref yfit, y2, stringBuilder);
                    data.WaterFlowRates[flowRateIndex].Yfit.Add(yfit);
                }
            }
        }

        private void InterpolateRange(MechanicalDraftPerformanceCurveCalculationData data)
        {
            //'Interpolate for Range
            List<double> x = new List<double>();
            List<double> y = new List<double>();
            List<double> y2 = new List<double>();
            double yfit;
            double TestRange = data.TowerTestData.HotWaterTemperature - data.TowerTestData.ColdWaterTemperature;
            StringBuilder stringBuilder = new StringBuilder();

            //'Interpolate for Range
            data.WetBulbTemperatureRange.Clear();
            for (int flowRateIndex = 0; flowRateIndex < data.WaterFlowRates.Count; flowRateIndex++)
            {
                y.Clear();
                x.Clear();
                for (int rangeIndex = 0; rangeIndex < data.Ranges.Count; rangeIndex++)
                {
                    x.Add(data.Ranges[rangeIndex]);
                    y.Add(data.WaterFlowRates[flowRateIndex].Yfit[rangeIndex]);
                }
                yfit = 0.0;
                y2.Clear();
                CalculatePerformanceData(x, y, TestRange, ref yfit, y2, stringBuilder);
                data.WetBulbTemperatureRange.Add(yfit);
            }
        }

        private void CalculateWetBulbTemperatureDeviation(MechanicalDraftPerformanceCurveCalculationData data, MechanicalDraftPerformanceCurveOutput output)
        {
            int iterationCount = 0;

            // save the current Calculated values
            double capability = output.TowerCapability;
            double adjustedFlow = output.AdjustedFlow;
            double predictedFlow = output.PredictedFlow;

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
            MechanicalDraftPerformanceCurveCalculation(data, output, false);
            double deltaCapability = capability - output.TowerCapability;
            while (Math.Abs(deltaCapability) > 0.01)
            {
                double deltaColdWaterTemperature = deltaCapability / estimatedSlope;
                double priorCapability = output.TowerCapability;
                data.TowerTestData.ColdWaterTemperature += deltaColdWaterTemperature;
                data.TowerTestData.HotWaterTemperature += deltaColdWaterTemperature;
                MechanicalDraftPerformanceCurveCalculation(data, output, false);
                estimatedSlope = (output.TowerCapability - priorCapability) / deltaColdWaterTemperature;
                deltaCapability = capability - output.TowerCapability;
                if (++iterationCount >= MAX_COLD_WATER_TEMPERATURE_DEVIATION_ITERATIONS)
                {
                    break;
                }
            }

            if (iterationCount > MAX_COLD_WATER_TEMPERATURE_DEVIATION_ITERATIONS)
            {
                output.ColdWaterTemperatureDeviation = 0.0;
            }
            else
            {
                output.ColdWaterTemperatureDeviation = data.TowerTestData.ColdWaterTemperature - data.TowerDesignData.ColdWaterTemperature;
            }

            // Restore the Calculated values
            output.TowerCapability = capability;
            output.AdjustedFlow = adjustedFlow;
            output.PredictedFlow = predictedFlow;

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
                CalculatePerformanceData(data.Ranges, data.WaterFlowRates[flowRateIndex].Yfit, testX, ref yfit, y2, stringBuilder);
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
                    yfit = 0.0;

                    for (int wetBulbTemperatureIndex = 0; wetBulbTemperatureIndex < waterFlowRate.WetBulbTemperatures.Count; wetBulbTemperatureIndex++)
                    {
                        x.Add(waterFlowRate.WetBulbTemperatures[wetBulbTemperatureIndex].Temperature);
                        y.Add(waterFlowRate.WetBulbTemperatures[wetBulbTemperatureIndex].ColdWaterTemperatures[rangeIndex]);
                    }

                    RangePoints rangePoints = new RangePoints();
                    for (double wetBulbTemperature = waterFlowRate.WetBulbTemperatures[0].Temperature; wetBulbTemperature <= waterFlowRate.WetBulbTemperatures[waterFlowRate.WetBulbTemperatures.Count - 1].Temperature; wetBulbTemperature += increment)
                    {
                        testX = wetBulbTemperature;
                        yfit = 0.0;
                        y2.Clear();
                        CalculatePerformanceData(x, y, testX, ref yfit, y2, stringBuilder);
                        rangePoints.Points.Add(new Point() { X = testX, Y = yfit });
                    }
                    waterFlowRate.RangePoints.Add(rangePoints);
                }
            }
        }
    }
}