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
				IsInternationalSystemOfUnits_SI = true,
				HotWaterTemperature = 49.36,
				ColdWaterTemperature = 30.56,
				WetBulbTemperature = 26.0,
				DryBulbTemperature = 30.2,
				BarometricPressure = 101.325,
				WaterFlowRate = 3583.0,
				FanDriverPower = 107.0,
				LiquidToGasRatio = 1.3,
			};

			MechanicalDraftPerformanceCurveData test = new MechanicalDraftPerformanceCurveData()
			{
				IsInternationalSystemOfUnits_SI = true,
				HotWaterTemperature = 46.5,
				ColdWaterTemperature = 29.04,
				WetBulbTemperature = 24.53,
				DryBulbTemperature = 25.52,
				BarometricPressure = 98.8,
				WaterFlowRate = 3623.0,
				FanDriverPower = 113.0,
				LiquidToGasRatio = 0.0
			};

			MechanicalDraftPerformanceCurveDesignData designData = new MechanicalDraftPerformanceCurveDesignData()
			{
				MechanicalDraftPerformanceCurveData = design,
				TowerType = TOWER_TYPE.Induced
			};

			MechanicalDraftPerformanceCurveFileData data = new MechanicalDraftPerformanceCurveFileData(true)
			{
				IsInternationalSystemOfUnits_SI = true,
				TestData = test,
				DesignData = designData
			};

			MechanicalDraftPerformanceCurveOutput output = new MechanicalDraftPerformanceCurveOutput();

			try
			{
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.DetermineAdjustedTestFlow(data, output);
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
			Assert.AreEqual(0.96780162756832133, output.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(152.00262906811440, output.WetBulbTemperature, "WetBulbTemperature value does not match");
		}

		[TestMethod]
		public void IP_CalculateAdjustedFlowTest()
		{
			bool methodThrew = false;

			MechanicalDraftPerformanceCurveData design = new MechanicalDraftPerformanceCurveData()
			{
				IsInternationalSystemOfUnits_SI = false,
				ColdWaterTemperature = 87.08,
				HotWaterTemperature = 120.92,
				DryBulbTemperature = 86.36,
				WetBulbTemperature = 78.8,
				BarometricPressure = 29.921,
				FanDriverPower = 143.4,
				WaterFlowRate = 56792.0,
				LiquidToGasRatio = 1.3
			};

			MechanicalDraftPerformanceCurveData test = new MechanicalDraftPerformanceCurveData()
			{
				IsInternationalSystemOfUnits_SI = false,
				ColdWaterTemperature = 84.27,
				HotWaterTemperature = 115.70,
				DryBulbTemperature = 77.94,
				WetBulbTemperature = 76.18,
				BarometricPressure = 29.18,
				FanDriverPower = 151.5,
				WaterFlowRate = 57426.0,
				LiquidToGasRatio = 0.0
			};

			MechanicalDraftPerformanceCurveDesignData designData = new MechanicalDraftPerformanceCurveDesignData()
			{
				MechanicalDraftPerformanceCurveData = design,
				TowerType = TOWER_TYPE.Induced
			};

			MechanicalDraftPerformanceCurveFileData data = new MechanicalDraftPerformanceCurveFileData(false)
			{
				IsInternationalSystemOfUnits_SI = false,
				TestData = test,
				DesignData = designData
			};

			MechanicalDraftPerformanceCurveOutput output = new MechanicalDraftPerformanceCurveOutput();

			try
			{
				CalculationLibrary = new CalculationLibrary.CalculationLibrary();
				CalculationLibrary.DetermineAdjustedTestFlow(data, output);
			}
			catch
			{
				methodThrew = true;
			}

			Assert.IsFalse(methodThrew, "Method threw");
			Assert.AreEqual(51028.716619350191, output.AdjustedFlow, "AdjustedFlow value does not match");
			Assert.AreEqual(102.01949119567871, output.ColdWaterTemperatureDeviation, "ColdWaterTemperatureDeviation value does not match");
			Assert.AreEqual(0.067379633634750025, output.Density, "Density value does not match");
			Assert.AreEqual(1.1643467203016296, output.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(0.96780162756832133, output.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(73.037664309523052, output.WetBulbTemperature, "WetBulbTemperature value does not match");
		}
	}
}
