// Copyright Cooling Technology Institute 2019-2021

using System;
using System.Data;
using System.Text;
using Models;

namespace CalculationLibrary
{
    public class MechanicalDraftPerformanceCurveCalculationLibrary : CalculationLibrary
    {
		public void MechanicalDraftPerformanceCurveCalculation(int testIndex, MechanicalDraftPerformanceCurveFileData data, MechanicalDraftPerformanceCurveOutput output)
        {
			string errorMessage = string.Empty;

			DetermineAdjustedTestFlow(testIndex, data, output);

			if(data.DesignData.ValidateRanges(3, out errorMessage))
            {
				if (data.DesignData.ValidateRangedTemperatures(3, out errorMessage))
				{
					if (data.DesignData.ValidateWaterFlowRates(3, out errorMessage))
					{

					}
					else
					{

					}
				}
				else
				{

				}
			}
			else
            {

            }
			//if (m_filePerfData.m_designData.m_fnGetFlowCnt() < MIN_FLOW_COUNT)
			//{
			//	CString cstrMsg;
			//	cstrMsg.Format("You must specify a minimum of %d flows in the Tower Design Data to calculate Tower Capability.", MIN_FLOW_COUNT);
			//	if (bCalcWET_BULB_TEMPERATUREDeviation)
			//	{
			//		MessageBox(cstrMsg);
			//	}
			//	return;
			//}
			//else if (m_filePerfData.m_designData.m_fnGetRangeCnt() < MIN_RANGE_COUNT)
			//{
			//	CString cstrMsg;
			//	cstrMsg.Format("You must specify a minimum of %d ranges in the Tower Design Data to calculate Tower Capability.", MIN_RANGE_COUNT);
			//	if (bCalcWET_BULB_TEMPERATUREDeviation)
			//	{
			//		MessageBox(cstrMsg);
			//	}
			//	return;
			//}
			//else if (m_filePerfData.m_designData.m_fnGetWET_BULB_TEMPERATURECnt(0) < MIN_WET_BULB_TEMPERATURE_COUNT)
			//{
			//	CString cstrMsg;
			//	cstrMsg.Format("You must specify a minimum of %d WET_BULB_TEMPERATURE values in the Tower Design Data to calculate Tower Capability.", MIN_WET_BULB_TEMPERATURE_COUNT);
			//	if (bCalcWET_BULB_TEMPERATUREDeviation)
			//	{
			//		MessageBox(cstrMsg);
			//	}
			//	return;
			//}


			//			m_filePerfData.m_designData.m_fnGetCOLD_WATER_TEMPERATUREArray(COLD_WATER_TEMPERATURE, !data.IsInternationalSystemOfUnits_SI);
			//			m_filePerfData.m_designData.m_fnGetRangeArray(R, !data.IsInternationalSystemOfUnits_SI);
			//			m_filePerfData.m_designData.m_fnGetFlowArray(FLOW, !data.IsInternationalSystemOfUnits_SI);
			//			m_filePerfData.m_designData.m_fnGetWET_BULB_TEMPERATUREArray(WET_BULB_TEMPERATUREemp, !data.IsInternationalSystemOfUnits_SI);

			//			int IFlowNo = m_filePerfData.m_designData.m_fnGetFlowCnt();
			//			int IRangeNo = m_filePerfData.m_designData.m_fnGetRangeCnt();
			//			int IWBNo = m_filePerfData.m_designData.m_fnGetWET_BULB_TEMPERATURECnt(0);

			//			//Init Others
			//			double TestWB = data.TestData.WetBulbTemperature;
			//			double TestR = m_dblTestHWT - m_dblTestCOLD_WATER_TEMPERATURE;
			//			double TestCOLD_WATER_TEMPERATURE = m_dblTestCOLD_WATER_TEMPERATURE;


			//			//'Interpolate for WB
			//# ifdef _DEBUG
			//			//    PRINT USING "@ TestWB=##.##"; TestWB
			//			//    PRINT #2, USING "@ TestWB=##.###"; TestWB
			//			strTemp.Format("@ TestWB=%.03f\r\n", TestWB);
			//			OutputDebugString(strTemp);
			//#endif // _DEBUG

			//			for (IFlow = 0; IFlow < IFlowNo; IFlow++)
			//			{
			//				IWBNo = m_filePerfData.m_designData.m_fnGetWET_BULB_TEMPERATURECnt(IFlow);

			//				for (IR = 0; IR < IRangeNo; IR++)
			//				{
			//					for (int IWB = 0; IWB < IWBNo; IWB++)
			//					{
			//						Y[IWB] = COLD_WATER_TEMPERATURE[IFlow][IWB][IR];
			//					}
			//					memcpy(WB, WET_BULB_TEMPERATUREemp[IFlow], sizeof(WB));
			//					CalcPerfData(IWBNo, WB, Y, TestWB, YFIT, Y2);

			//					COLD_WATER_TEMPERATURE_WB[IFlow][IR] = YFIT;

			//# ifdef _DEBUG
			//					//PRINT USING "FLOW=###### RANGE=##.## COLD_WATER_TEMPERATURE=##.###"; FLOW(IFlow); R(IR); COLD_WATER_TEMPERATURE_WB(IFlow, IR)            
			//					strTemp.Format("FLOW=%.0f RANGE=%.02f COLD_WATER_TEMPERATURE=%.03f\r\n", FLOW[IFlow], R[IR], COLD_WATER_TEMPERATURE_WB[IFlow][IR]);
			//					OutputDebugString(strTemp);
			//#endif // _DEBUG
			//				}
			//				TRACE0("\r\n");
			//			}
			//			//'Interpolate for Range
			//# ifdef _DEBUG
			//			//    PRINT #2, USING "@ TestWB=##.## and TestR=##.##"; TestWB; TestR
			//			strTemp.Format("@ TestWB=%.02f and TestR=%.02f\r\n", TestWB, TestR);
			//			OutputDebugString(strTemp);
			//#endif // _DEBUG

			//			for (IFlow = 0; IFlow < IFlowNo; IFlow++)
			//			{
			//				for (IR = 0; IR < IRangeNo; IR++)
			//				{
			//					Y[IR] = COLD_WATER_TEMPERATURE_WB[IFlow][IR];
			//				}
			//				CalcPerfData(IRangeNo, R, Y, TestR, YFIT, Y2);
			//				COLD_WATER_TEMPERATURE_WB_R[IFlow] = YFIT;

			//# ifdef _DEBUG
			//				//PRINT USING "FLOW=######  COLD_WATER_TEMPERATURE=##.###"; FLOW(IFlow); COLD_WATER_TEMPERATURE_WB_R(IFlow)
			//				strTemp.Format("FLOW=%.0f COLD_WATER_TEMPERATURE=%.03f\r\n", FLOW[IFlow], COLD_WATER_TEMPERATURE_WB_R[IFlow]);
			//				OutputDebugString(strTemp);
			//#endif // _DEBUG
			//			}
			//			TRACE0("\r\n");

			//			//'Final interpolation for Flow (Y) vs COLD_WATER_TEMPERATURE (X)
			//# ifdef _DEBUG
			//			//    PRINT #2, USING "@ TestWB=##.## and TestR=##.## and TestCOLD_WATER_TEMPERATURE=###.##"; TestWB; TestR; TestCOLD_WATER_TEMPERATURE
			//			strTemp.Format("@ TestWB=%.02f and TestR=%.02f and TestCOLD_WATER_TEMPERATURE=%.02f\r\n", TestWB, TestR, TestCOLD_WATER_TEMPERATURE);
			//			OutputDebugString(strTemp);
			//#endif // _DEBUG

			//			CalcPerfData(IFlowNo, COLD_WATER_TEMPERATURE_WB_R, FLOW, TestCOLD_WATER_TEMPERATURE, YFIT, Y2);
			//			double PredFlow = YFIT;


			//			//'Rev:1-23-01 Added check for EXTRAPOLATED flow
			//			//'Determine Min and Max Flows
			//			double MinFlow = FLOW[0];
			//			double MaxFlow = FLOW[0];
			//			for (int iExt = 1; iExt < IFlowNo; iExt++)
			//			{
			//				if (FLOW[iExt] < MinFlow)
			//				{
			//					MinFlow = FLOW[iExt];
			//				}
			//				if (FLOW[iExt] > MaxFlow)
			//				{
			//					MaxFlow = FLOW[iExt];
			//				}
			//			}
			//			if ((PredFlow < MinFlow) || (PredFlow > MaxFlow))
			//			{
			//				//PRINT #2, STRING$(80, 42)
			//				//PRINT #2, USING "CAUTION: Predicted Flow ####.## is EXTRAPOLATED beyond the"; PredFlow
			//				//PRINT #2, USING "Supplied Curve Flows of #####.## to #####.##"; MinFlow; MaxFlow
			//				//PRINT #2, STRING$(80, 42)
			//				CString strWarning;
			//				strWarning.Format("CAUTION: Predicted Flow %.02f is EXTRAPOLATED beyond the\r\nSupplied Curve Flows of %.02f to %.02f", PredFlow, MinFlow, MaxFlow);
			//				if (bCalcWET_BULB_TEMPERATUREDeviation)
			//				{
			//					MessageBox(strWarning, "Extrapolation Warning", MB_ICONWARNING);
			//				}
			//			}
			//			//'End check for Extrapolation

			//			LWET_BULB_TEMPERATUREnew = 0;
			//			DenOutT = 0;
			//			SVOutT = 0;
			//			HLWET_BULB_TEMPERATURE = 0;
			//			dblAdjustedFlow = DetermineAdjTestFlow(!data.IsInternationalSystemOfUnits_SI, (int)m_filePerfData.m_designData.m_fnGetInducedFlow(), data.DesignData.HotWaterTemperature, data.DesignData.ColdWaterTemperature, data.DesignData.WetBulbTemperature, data.DesignData.DryBulbTemperature, data.DesignData.BarometricPressure, data.DesignData.WaterFlowRate, data.DesignData.FanDriverPower, m_dblDesignLIQUID_GAS_RATIO, m_dblTestHWT, m_dblTestCOLD_WATER_TEMPERATURE, data.TestData.WetBulbTemperature, data.TestData.DryBulbTemperature, data.TestData.BarometricPressure, data.TestData.WaterFlowRate, data.TestData.FanDriverPower, LWET_BULB_TEMPERATUREnew, DenOutT, SVOutT, HLWET_BULB_TEMPERATURE, dblAdjustedFlow, testLiquidToGasRatio);
			//			double AdjTestFlow = dblAdjustedFlow;

			//# ifdef _DEBUG
			//			//    PRINT USING "TestCOLD_WATER_TEMPERATURE=##.###  PredFlow=######.###"; TestCOLD_WATER_TEMPERATURE; PredFlow
			//			//    PRINT USING "AdjTestFlow=######.###  PredFlow=######.###  Percent Capability=###.##"; AdjTestFlow; PredFlow; AdjTestFlow / PredFlow * 100
			//			strTemp.Format("TestCOLD_WATER_TEMPERATURE=%.02f PredFlow=%.03f\r\n", TestCOLD_WATER_TEMPERATURE, PredFlow);
			//			OutputDebugString(strTemp);
			//			strTemp.Format("AdjTestFlow=%.03f  PredFlow=%.03f  Percent Capability=%.03f",
			//				AdjTestFlow, PredFlow, PredFlow != 0.0 ? (AdjTestFlow / PredFlow * 100.0) : 0.0);
			//			TRACE0(strTemp);
			//#endif // _DEBUG

			//			m_dblPredictedFlow = PredFlow;
			//			m_dblAdjustedFlow = AdjTestFlow;

			//			m_dblCapability = PredFlow != 0.0 ? (AdjTestFlow / PredFlow * 100.0) : 0.0;

			//			if (bCalcWET_BULB_TEMPERATUREDeviation)
			//			{
			//				m_fnCalcWET_BULB_TEMPERATUREDeviation();
			//			}
		}
	}
}