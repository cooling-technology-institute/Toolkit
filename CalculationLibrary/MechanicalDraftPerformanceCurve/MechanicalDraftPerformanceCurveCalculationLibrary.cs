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
			string errorMessage = string.Empty;

			DetermineAdjustedTestFlow(data, output);


            //			m_filePerfData.m_designData.m_fnGetCOLD_WATER_TEMPERATUREArray(COLD_WATER_TEMPERATURE, !data.IsInternationalSystemOfUnits_SI);
            //			m_filePerfData.m_designData.m_fnGetRangeArray(R, !data.IsInternationalSystemOfUnits_SI);
            //			m_filePerfData.m_designData.m_fnGetFlowArray(FLOW, !data.IsInternationalSystemOfUnits_SI);
            //			m_filePerfData.m_designData.m_fnGetWET_BULB_TEMPERATUREArray(WET_BULB_TEMPERATUREemp, !data.IsInternationalSystemOfUnits_SI);

            //			int IFlowNo = m_filePerfData.m_designData.m_fnGetFlowCnt();
            //			int IRangeNo = m_filePerfData.m_designData.m_fnGetRangeCnt();
            //			int IWBNo = m_filePerfData.m_designData.m_fnGetWET_BULB_TEMPERATURECnt(0);

            //Init Others
            double TestWetBulbTemperature = data.TowerTestData.WetBulbTemperature;
            double TestRange = data.TowerTestData.HotWaterTemperature - data.TowerTestData.ColdWaterTemperature;
            double TestColdWaterTemperature = data.TowerTestData.ColdWaterTemperature;

            //'Interpolate for WB
            //# ifdef _DEBUG
            //			//    PRINT USING "@ TestWB=##.##"; TestWB
            //			//    PRINT #2, USING "@ TestWB=##.###"; TestWB
            //			strTemp.Format("@ TestWB=%.03f\r\n", TestWB);
            //			OutputDebugString(strTemp);
            //#endif // _DEBUG
            List<double> x = new List<double>();
            List<double> y = new List<double>();
            List<double> y2 = new List<double>();
            double yfit;
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
                    //memcpy(WB, WET_BULB_TEMPERATUREemp[IFlow], sizeof(WB));
                    //CalculatePerformanceData(List<double> x, List< double > ymeas, double xreal, ref double yfit, List< double > y2, StringBuilder errorMessage);
                    //COLD_WATER_TEMPERATURE_WB[IFlow][IR] = YFIT;
                    CalculatePerformanceData(x, y, TestWetBulbTemperature, ref yfit, y2, stringBuilder);
                    data.WaterFlowRates[flowRateIndex].Yfit.Add(yfit);

                    //#ifdef _DEBUG
                    //                //PRINT USING "FLOW=###### RANGE=##.## COLD_WATER_TEMPERATURE=##.###"; FLOW(IFlow); R(IR); COLD_WATER_TEMPERATURE_WB(IFlow, IR)            
                    //                strTemp.Format("FLOW=%.0f RANGE=%.02f COLD_WATER_TEMPERATURE=%.03f\r\n", FLOW[IFlow], R[IR], COLD_WATER_TEMPERATURE_WB[IFlow][IR]);
                    //                OutputDebugString(strTemp);
                    //#endif // _DEBUG
                }
            }

            //'Interpolate for Range
            //#ifdef _DEBUG
            //            //    PRINT #2, USING "@ TestWB=##.## and TestR=##.##"; TestWB; TestR
            //            strTemp.Format("@ TestWB=%.02f and TestR=%.02f\r\n", TestWB, TestR);
            //            OutputDebugString(strTemp);
            //#endif // _DEBUG
            data.WetBulbTemperatureRange.Clear();
            for (int flowRateIndex = 0; flowRateIndex < data.WaterFlowRates.Count; flowRateIndex++)
            {
                y.Clear();
                x.Clear();
                for (int rangeIndex = 0; rangeIndex < data.Ranges.Count; rangeIndex++)
                {
                    x.Add(data.Ranges[rangeIndex]);
                    y.Add(data.WaterFlowRates[flowRateIndex].Yfit[rangeIndex]);


                    //# ifdef _DEBUG
                    //				//PRINT USING "FLOW=######  COLD_WATER_TEMPERATURE=##.###"; FLOW(IFlow); COLD_WATER_TEMPERATURE_WB_R(IFlow)
                    //				strTemp.Format("FLOW=%.0f COLD_WATER_TEMPERATURE=%.03f\r\n", FLOW[IFlow], COLD_WATER_TEMPERATURE_WB_R[IFlow]);
                    //				OutputDebugString(strTemp);
                    //#endif // _DEBUG
                }
                yfit = 0.0;
                y2.Clear();
                CalculatePerformanceData(x, y, TestRange, ref yfit, y2, stringBuilder);
                data.WetBulbTemperatureRange.Add(yfit);
            }

            //'Final interpolation for Flow (Y) vs COLD_WATER_TEMPERATURE (X)
            //'Rev:1-23-01 Added check for EXTRAPOLATED flow (y contains the flow rates from the above loop)
            //'and determine Min and Max Flows
            //# ifdef _DEBUG
            //			//    PRINT #2, USING "@ TestWB=##.## and TestR=##.## and TestCOLD_WATER_TEMPERATURE=###.##"; TestWB; TestR; TestCOLD_WATER_TEMPERATURE
            //			strTemp.Format("@ TestWB=%.02f and TestR=%.02f and TestCOLD_WATER_TEMPERATURE=%.02f\r\n", TestWB, TestR, TestCOLD_WATER_TEMPERATURE);
            //			OutputDebugString(strTemp);
            //#endif // _DEBUG
            y.Clear();
            double minimumFlow = 0.0;
            double maximumFlow = 0.0;
            for (int flowRateIndex = 0; flowRateIndex < data.WaterFlowRates.Count; flowRateIndex++)
            {
                if(flowRateIndex == 0)
                {
                    minimumFlow = data.WaterFlowRates[flowRateIndex].FlowRate;
                    maximumFlow = data.WaterFlowRates[flowRateIndex].FlowRate;
                }
                else if(data.WaterFlowRates[flowRateIndex].FlowRate > maximumFlow)
                {
                    maximumFlow = data.WaterFlowRates[flowRateIndex].FlowRate;
                }
                else if (data.WaterFlowRates[flowRateIndex].FlowRate < minimumFlow)
                {
                    minimumFlow = data.WaterFlowRates[flowRateIndex].FlowRate;
                }
                y.Add(data.WaterFlowRates[flowRateIndex].FlowRate);
            }
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

            //			LWET_BULB_TEMPERATUREnew = 0;
            //			DenOutT = 0;
            //			SVOutT = 0;
            //			HLWET_BULB_TEMPERATURE = 0;
            output.Clear();
            output.PredictedFlow = predicatedFlow;
            output.AdjustedFlow = DetermineAdjustedTestFlow(data, output);
            output.TowerCapability = (predicatedFlow != 0.0) ? (output.AdjustedFlow / output.PredictedFlow * 100.0) : 0.0;

            //# ifdef _DEBUG
            //			//    PRINT USING "TestCOLD_WATER_TEMPERATURE=##.###  PredFlow=######.###"; TestCOLD_WATER_TEMPERATURE; PredFlow
            //			//    PRINT USING "AdjTestFlow=######.###  PredFlow=######.###  Percent Capability=###.##"; AdjTestFlow; PredFlow; AdjTestFlow / PredFlow * 100
            //			strTemp.Format("TestCOLD_WATER_TEMPERATURE=%.02f PredFlow=%.03f\r\n", TestCOLD_WATER_TEMPERATURE, PredFlow);
            //			OutputDebugString(strTemp);
            //			strTemp.Format("AdjTestFlow=%.03f  PredFlow=%.03f  Percent Capability=%.03f",
            //				AdjTestFlow, PredFlow, PredFlow != 0.0 ? (AdjTestFlow / PredFlow * 100.0) : 0.0);
            //			TRACE0(strTemp);
            //#endif // _DEBUG

            if (calculateWetBulbDeviation)
            {
                CalculateWetBulbTemperatureDeviation(data, output);
            }
        }

        void CalculateWetBulbTemperatureDeviation(MechanicalDraftPerformanceCurveCalculationData data, MechanicalDraftPerformanceCurveOutput output)
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

            //CString strTemp;
            //strTemp.Format("\nCWT deviation calculation took %u iterations.\n", iterationCount);
            //OutputDebugString(strTemp);

            if (iterationCount > MAX_COLD_WATER_TEMPERATURE_DEVIATION_ITERATIONS)
            {
                //m_bCWTDevCalcOk = false;
                output.ColdWaterTemperatureDeviation = 0.0;
                //GetDlgItem(IDC_EDIT_COLD_WATER_DEV)->SetWindowText("");
                //strTemp.Format("\n*** CWT deviation calculation exceeded max iterations (%u) - CWT dev set to 0! ***\n",
                //    MAX_COLD_WATER_TEMPERATURE_DEVIATION_ITERATIONS);
                //OutputDebugString(strTemp);
                //strTemp = "The CWT Deviation calculation did not converge - please contact CTI support for assistance.\n";
                //strTemp += "(Choose \"About CTI Toolkit\" from the Help menu for a link to the CTI website.)";
                //MessageBox(strTemp, "Calculation error");
            }
            else
            {
                //m_bCWTDevCalcOk = true;
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
    }
}