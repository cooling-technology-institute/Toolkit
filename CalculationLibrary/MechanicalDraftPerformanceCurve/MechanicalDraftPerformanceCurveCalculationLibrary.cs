// Copyright Cooling Technology Institute 2019-2020

using System;
using System.Data;
using System.Text;
using Models;

namespace CalculationLibrary
{
    public class MechanicalDraftPerformanceCurveCalculationLibrary : CalculationLibrary
    {
        public void MechanicalDraftPerformanceCurveCalculation(MechanicalDraftPerformanceCurveFileData data, MechanicalDraftPerformanceCurveOutput output)
        {
			DetermineAdjustedTestFlow(data, output);

			//if(data.DesignData.ValidateRanges())

			//if (m_filePerfData.m_designData.m_fnGetFlowCnt() < MIN_FLOW_COUNT)
			//{
			//	CString cstrMsg;
			//	cstrMsg.Format("You must specify a minimum of %d flows in the Tower Design Data to calculate Tower Capability.", MIN_FLOW_COUNT);
			//	if (bCalcWBTDeviation)
			//	{
			//		MessageBox(cstrMsg);
			//	}
			//	return;
			//}
			//else if (m_filePerfData.m_designData.m_fnGetRangeCnt() < MIN_RANGE_COUNT)
			//{
			//	CString cstrMsg;
			//	cstrMsg.Format("You must specify a minimum of %d ranges in the Tower Design Data to calculate Tower Capability.", MIN_RANGE_COUNT);
			//	if (bCalcWBTDeviation)
			//	{
			//		MessageBox(cstrMsg);
			//	}
			//	return;
			//}
			//else if (m_filePerfData.m_designData.m_fnGetWBTCnt(0) < MIN_WBT_COUNT)
			//{
			//	CString cstrMsg;
			//	cstrMsg.Format("You must specify a minimum of %d WBT values in the Tower Design Data to calculate Tower Capability.", MIN_WBT_COUNT);
			//	if (bCalcWBTDeviation)
			//	{
			//		MessageBox(cstrMsg);
			//	}
			//	return;
			//}


			//			m_filePerfData.m_designData.m_fnGetCWTArray(CWT, !data.IsInternationalSystemOfUnits_SI);
			//			m_filePerfData.m_designData.m_fnGetRangeArray(R, !data.IsInternationalSystemOfUnits_SI);
			//			m_filePerfData.m_designData.m_fnGetFlowArray(FLOW, !data.IsInternationalSystemOfUnits_SI);
			//			m_filePerfData.m_designData.m_fnGetWBTArray(WBTemp, !data.IsInternationalSystemOfUnits_SI);

			//			int IFlowNo = m_filePerfData.m_designData.m_fnGetFlowCnt();
			//			int IRangeNo = m_filePerfData.m_designData.m_fnGetRangeCnt();
			//			int IWBNo = m_filePerfData.m_designData.m_fnGetWBTCnt(0);

			//			//Init Others
			//			double TestWB = data.TestData.WetBulbTemperature;
			//			double TestR = m_dblTestHWT - m_dblTestCWT;
			//			double TestCWT = m_dblTestCWT;


			//			//'Interpolate for WB
			//# ifdef _DEBUG
			//			//    PRINT USING "@ TestWB=##.##"; TestWB
			//			//    PRINT #2, USING "@ TestWB=##.###"; TestWB
			//			strTemp.Format("@ TestWB=%.03f\r\n", TestWB);
			//			OutputDebugString(strTemp);
			//#endif // _DEBUG

			//			for (IFlow = 0; IFlow < IFlowNo; IFlow++)
			//			{
			//				IWBNo = m_filePerfData.m_designData.m_fnGetWBTCnt(IFlow);

			//				for (IR = 0; IR < IRangeNo; IR++)
			//				{
			//					for (int IWB = 0; IWB < IWBNo; IWB++)
			//					{
			//						Y[IWB] = CWT[IFlow][IWB][IR];
			//					}
			//					memcpy(WB, WBTemp[IFlow], sizeof(WB));
			//					CalcPerfData(IWBNo, WB, Y, TestWB, YFIT, Y2);

			//					CWT_WB[IFlow][IR] = YFIT;

			//# ifdef _DEBUG
			//					//PRINT USING "FLOW=###### RANGE=##.## CWT=##.###"; FLOW(IFlow); R(IR); CWT_WB(IFlow, IR)            
			//					strTemp.Format("FLOW=%.0f RANGE=%.02f CWT=%.03f\r\n", FLOW[IFlow], R[IR], CWT_WB[IFlow][IR]);
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
			//					Y[IR] = CWT_WB[IFlow][IR];
			//				}
			//				CalcPerfData(IRangeNo, R, Y, TestR, YFIT, Y2);
			//				CWT_WB_R[IFlow] = YFIT;

			//# ifdef _DEBUG
			//				//PRINT USING "FLOW=######  CWT=##.###"; FLOW(IFlow); CWT_WB_R(IFlow)
			//				strTemp.Format("FLOW=%.0f CWT=%.03f\r\n", FLOW[IFlow], CWT_WB_R[IFlow]);
			//				OutputDebugString(strTemp);
			//#endif // _DEBUG
			//			}
			//			TRACE0("\r\n");

			//			//'Final interpolation for Flow (Y) vs CWT (X)
			//# ifdef _DEBUG
			//			//    PRINT #2, USING "@ TestWB=##.## and TestR=##.## and TestCWT=###.##"; TestWB; TestR; TestCWT
			//			strTemp.Format("@ TestWB=%.02f and TestR=%.02f and TestCWT=%.02f\r\n", TestWB, TestR, TestCWT);
			//			OutputDebugString(strTemp);
			//#endif // _DEBUG

			//			CalcPerfData(IFlowNo, CWT_WB_R, FLOW, TestCWT, YFIT, Y2);
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
			//				if (bCalcWBTDeviation)
			//				{
			//					MessageBox(strWarning, "Extrapolation Warning", MB_ICONWARNING);
			//				}
			//			}
			//			//'End check for Extrapolation

			//			LWBTnew = 0;
			//			DenOutT = 0;
			//			SVOutT = 0;
			//			HLWBT = 0;
			//			dblAdjustedFlow = DetermineAdjTestFlow(!data.IsInternationalSystemOfUnits_SI, (int)m_filePerfData.m_designData.m_fnGetInducedFlow(), data.DesignData.HotWaterTemperature, data.DesignData.ColdWaterTemperature, data.DesignData.WetBulbTemperature, data.DesignData.DryBulbTemperature, data.DesignData.BarometricPressure, data.DesignData.WaterFlowRate, data.DesignData.FanDriverPower, m_dblDesignLG, m_dblTestHWT, m_dblTestCWT, data.TestData.WetBulbTemperature, data.TestData.DryBulbTemperature, data.TestData.BarometricPressure, data.TestData.WaterFlowRate, data.TestData.FanDriverPower, LWBTnew, DenOutT, SVOutT, HLWBT, dblAdjustedFlow, testLiquidToGasRatio);
			//			double AdjTestFlow = dblAdjustedFlow;

			//# ifdef _DEBUG
			//			//    PRINT USING "TestCWT=##.###  PredFlow=######.###"; TestCWT; PredFlow
			//			//    PRINT USING "AdjTestFlow=######.###  PredFlow=######.###  Percent Capability=###.##"; AdjTestFlow; PredFlow; AdjTestFlow / PredFlow * 100
			//			strTemp.Format("TestCWT=%.02f PredFlow=%.03f\r\n", TestCWT, PredFlow);
			//			OutputDebugString(strTemp);
			//			strTemp.Format("AdjTestFlow=%.03f  PredFlow=%.03f  Percent Capability=%.03f",
			//				AdjTestFlow, PredFlow, PredFlow != 0.0 ? (AdjTestFlow / PredFlow * 100.0) : 0.0);
			//			TRACE0(strTemp);
			//#endif // _DEBUG

			//			m_dblPredictedFlow = PredFlow;
			//			m_dblAdjustedFlow = AdjTestFlow;

			//			m_dblCapability = PredFlow != 0.0 ? (AdjTestFlow / PredFlow * 100.0) : 0.0;

			//			if (bCalcWBTDeviation)
			//			{
			//				m_fnCalcWBTDeviation();
			//			}
		}
	}
}