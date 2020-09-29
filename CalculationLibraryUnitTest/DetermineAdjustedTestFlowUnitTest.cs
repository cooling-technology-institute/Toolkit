using System;
using CalculationLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace CalculationLibraryUnitTest
{
    [TestClass]
    public class DetermineAdjustedTestFlowUnitTest
    {
        CalculationLibrary.CalculationLibrary CalculationLibrary { get; set; }

        [TestMethod]
        public void CalculateAdjustedFlowTest()
        {
            bool methodThrew = false;
			double BHPd = 107.00000000000000;
			double BHPt = 113.0000000000000;
			
			double BPd = 101.32500000000000;
			double BPt = 98.799999999999997;
			
			double Cpw = 1.0032476431355153;
			
			double EDBd = 30.199999999999999;
			double EDBt = 25.520000000000000;
			
			double EWBd = 26.000000000000000;
			double EWBt = 24.530000000000001;
			
			double EWTd = 49.359999999999999;
			double EWTt = 46.500000000000000;
			
			double FLOWd = 3583.0000000000000;
			double FLOWt = 3623.0000000000000;
			
			double HCalcT = 3.0814966048164618;
			
			double HInD = 1.1945304577553741e+103;
			double HInT = 7.9213071773430747e+268;
			
			double HLWBT = 0.0;
			double HOutD = 1.8869646367645145e-239;
			
			double LWTd = 30.559999999999999;
			double LWTt = 29.039999999999999;
			
			double LinGt = 1.2825112012708488;
			double LinGD = 1.3000000000000000;

			/*
double DetermineAdjTestFlow(int IunitsIP, int IInduced, double EWTd, double LWTd, double EWBd, double EDBd, double BPd, double FLOWd, double BHPd, double LinGD, double EWTt, double LWTt, double EWBt, double EDBt, double BPt, double FLOWt, double BHPt, double &LWBTnew, double &DenOutT, double &SVOutT, double &HLWBT, double &AdjTestFlow, double &LinGt)
			
			AdjustedFlow = DetermineAdjTestFlow(
			
					m_bIPUnits, --IunitsIP
					(int) m_designData.m_fnGetInducedFlow(), -- IInduced
			
					m_designData.m_fnGetHWT(m_bIPUnits),  -- EWTd
					m_designData.m_fnGetCWT(m_bIPUnits),  -- LWTd
					m_designData.m_fnGetWBT(m_bIPUnits),  -- EWBd
					m_designData.m_fnGetDBT(m_bIPUnits),  -- EDBd
					m_designData.m_fnGetBarometricPressure(m_bIPUnits),  -- BPd
					m_designData.m_fnGetWaterFlowRate(m_bIPUnits),  -- FLOWd
					m_designData.m_fnGetFanDriverPower(m_bIPUnits),  -- BHPd
					m_designData.m_fnGetLG(m_bIPUnits),  -- LinGD
			
					m_testData.m_fnGetHWT(m_bIPUnits),  -- EWTt
					m_testData.m_fnGetCWT(m_bIPUnits),  -- LWTt
					m_testData.m_fnGetWBT(m_bIPUnits),  -- EWBt
					m_testData.m_fnGetDBT(m_bIPUnits),  -- EDBt
					m_testData.m_fnGetBarometricPressure(m_bIPUnits),  -- BPt
					m_testData.m_fnGetWaterFlowRate(m_bIPUnits),  -- FLOWt
					m_testData.m_fnGetFanDriverPower(m_bIPUnits),  -- BHPt
			
					LWBTnew, DenOutT, SVOutT, HLWBT, dblAdjustedFlow, dblTestLG);
			*/

			MechanicalDraftPerformanceCurveTestData test = new MechanicalDraftPerformanceCurveTestData()
			{
				WaterFlowRate = FLOWt,
				HotWaterTemperature = EWTt,
				ColdWaterTemperature = LWTt,
				WetBulbTemperature = EWBt,
				DryBulbTemperature = EDBt,
				FanDriverPower = BHPt,
				BarometricPressure = BPt,
				LiquidToGasRatio = 0.0
			};

			MechanicalDraftPerformanceCurveDesignData design = new MechanicalDraftPerformanceCurveDesignData()
			{
				WaterFlowRate = FLOWd,
				HotWaterTemperature = EWTd,
				ColdWaterTemperature = LWTd,
				WetBulbTemperature = EWBd,
				DryBulbTemperature = EDBd,
				FanDriverPower = BHPd,
				BarometricPressure = BPd,
				LiquidToGasRatio = LinGD
			};

			MechanicalDraftPerformanceCurveData data = new MechanicalDraftPerformanceCurveData(true)
			{
				TestData = test,
				DesignData = design
			};

			PsychrometricsData testPsychrometricsData = new PsychrometricsData()
			{
				IsInternationalSystemOfUnits_SI = false,
				Elevation = 0.0,
				WetBulbTemperature = 0.0,
				DryBulbTemperature = 0.0,
				BarometricPressure = 0.0,
				HumidityRatio = 0.0,
				RelativeHumidity = 0.0,
				Enthalpy = 0.0,
				RootEnthalpy = 0.0,
				SpecificVolume = 0.0,
				Density = 0.0,
				DewPoint = 0.0,
				DegreeOfSaturation = 0.0,
				SaturationVaporPressureWetBulb = 0.0,
				SaturationVaporPressureDryBulb = 0.0,
				FsWetBulb = 0.0,
				FsDryBulb = 0.0
			};
			
			PsychrometricsData designPsychrometricsData = new PsychrometricsData()
			{
				IsInternationalSystemOfUnits_SI = false,
				Elevation = 0.0,
				WetBulbTemperature = 0.0,
				DryBulbTemperature = 0.0,
				BarometricPressure = 0.0,
				HumidityRatio = 0.0,
				RelativeHumidity = 0.0,
				Enthalpy = 0.0,
				RootEnthalpy = 0.0,
				SpecificVolume = 0.0,
				Density = 0.0,
				DewPoint = 0.0,
				DegreeOfSaturation = 0.0,
				SaturationVaporPressureWetBulb = 0.0,
				SaturationVaporPressureDryBulb = 0.0,
				FsWetBulb = 0.0,
				FsDryBulb = 0.0
			};

			MechanicalDraftPerformanceCurveOutput output = new MechanicalDraftPerformanceCurveOutput();

			try
			{
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.DetermineAdjustedTestFlow(data, testPsychrometricsData, designPsychrometricsData, output);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(3549.8089648534847, output.AdjustedFlow, "AdjustedFlow value does not match");
			Assert.AreEqual(39.941644668579102, output.ColdWaterTemperatureDeviation, "ColdWaterTemperatureDeviation value does not match");
			Assert.AreEqual(1.0791204854438692, output.Density, "Density value does not match");
			Assert.AreEqual(1.2839296953830412, output.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(3549.8089648534847, output.PredictedFlow, "PredictedFlow value does not match");
			Assert.AreEqual(0.96780162756832133, output.SpecificVolume, "SpecificVolume value does not match");
			//Assert.AreEqual(0.96780162756832133, output.TowerCapability, "TowerCapability value does not match");
			Assert.AreEqual(152.00262906811440, output.WetBulbTemperature, "WetBulbTemperature value does not match");
		}
	}
}
