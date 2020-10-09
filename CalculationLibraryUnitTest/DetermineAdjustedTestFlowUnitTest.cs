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
        public void SI_CalculateAdjustedFlowTest()
        {
            bool methodThrew = false;

			MechanicalDraftPerformanceCurveData design = new MechanicalDraftPerformanceCurveData()
			{
				WaterFlowRate = 3583.0,
				ColdWaterTemperature = 30.56,
				HotWaterTemperature = 49.36,
				WetBulbTemperature = 26.0,
				DryBulbTemperature = 30.2,
				FanDriverPower = 107.0,
				BarometricPressure = 101.325,
				LiquidToGasRatio = 1.3
			};

			MechanicalDraftPerformanceCurveDesignData designData = new MechanicalDraftPerformanceCurveDesignData()
			{
				MechanicalDraftPerformanceCurveData = design
			};

			MechanicalDraftPerformanceCurveData test = new MechanicalDraftPerformanceCurveData()
			{
				WaterFlowRate = 3583.0,
				ColdWaterTemperature = 30.56,
				HotWaterTemperature = 49.36,
				WetBulbTemperature = 26.0,
				DryBulbTemperature = 30.2,
				FanDriverPower = 107.0,
				BarometricPressure = 101.325,
				LiquidToGasRatio = 1.2853
			};

			MechanicalDraftPerformanceCurveFileData data = new MechanicalDraftPerformanceCurveFileData(true)
			{
				TestData = test,
				DesignData = designData
			};

			PsychrometricsData testPsychrometricsData = new PsychrometricsData(test);

			PsychrometricsData designPsychrometricsData = new PsychrometricsData(design);

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
            Assert.AreEqual(56260.921322402552, output.AdjustedFlow, "AdjustedFlow value does not match");
			Assert.AreEqual(39.941644668579102, output.ColdWaterTemperatureDeviation, "ColdWaterTemperatureDeviation value does not match");
			Assert.AreEqual(1.0791204854438692, output.Density, "Density value does not match");
			Assert.AreEqual(1.2839296953830412, output.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(3549.8089648534847, output.PredictedFlow, "PredictedFlow value does not match");
			Assert.AreEqual(0.96780162756832133, output.SpecificVolume, "SpecificVolume value does not match");
			//Assert.AreEqual(0.96780162756832133, output.TowerCapability, "TowerCapability value does not match");
			Assert.AreEqual(152.00262906811440, output.WetBulbTemperature, "WetBulbTemperature value does not match");
		}

		[TestMethod]
		public void IP_CalculateAdjustedFlowTest()
		{
			bool methodThrew = false;

			MechanicalDraftPerformanceCurveData design = new MechanicalDraftPerformanceCurveData()
			{
				WaterFlowRate = 56792.0,
				ColdWaterTemperature = 87.08,
				HotWaterTemperature = 120.92,
				WetBulbTemperature = 78.8,
				DryBulbTemperature = 86.36,
				FanDriverPower = 143.4,
				BarometricPressure = 29.921,
				LiquidToGasRatio = 1.3,
			};

			MechanicalDraftPerformanceCurveDesignData designData = new MechanicalDraftPerformanceCurveDesignData()
			{
				MechanicalDraftPerformanceCurveData = design
			};

			MechanicalDraftPerformanceCurveData test = new MechanicalDraftPerformanceCurveData()
			{
				WaterFlowRate = 57426.0,
				ColdWaterTemperature = 84.27,
				HotWaterTemperature = 115.7,
				WetBulbTemperature = 76.18,
				DryBulbTemperature = 77.94,
				FanDriverPower = 151.5,
				BarometricPressure = 29.18,
				LiquidToGasRatio = 0.0
			};

			MechanicalDraftPerformanceCurveFileData data = new MechanicalDraftPerformanceCurveFileData(false)
			{
				TestData = test,
				DesignData = designData
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
