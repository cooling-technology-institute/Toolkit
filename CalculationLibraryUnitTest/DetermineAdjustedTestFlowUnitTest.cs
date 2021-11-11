using System;
using CalculationLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace CalculationLibraryUnitTest
{
    [TestClass]
    public class DetermineAdjustedTestFlowUnitTest
    {
		MechanicalDraftPerformanceCurveCalculationLibrary CalculationLibrary { get; set; }

        [TestMethod]
        public void SI_CalculateAdjustedFlowTest()
        {
            bool methodThrew = false;

			TowerSpecifications design = new TowerSpecifications()
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

			TowerSpecifications test = new TowerSpecifications()
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

			MechanicalDraftPerformanceCurveCalculationData data = new MechanicalDraftPerformanceCurveCalculationData()
			{
				IsInternationalSystemOfUnits_SI = true,
				TowerType = TOWER_TYPE.Induced,
				TowerDesignData = design,
				TowerTestData = test,
			};

			try
			{
                CalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();
                CalculationLibrary.DetermineAdjustedTestFlow(data, data.TowerDesignData, data.TowerTestData, data.TestOutput);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(3536.9646313759695, data.TestOutput.AdjustedFlow, "AdjustedFlow value does not match"); // 
			Assert.AreEqual(40.087404251098633, data.TestOutput.WetBulbTemperature, "WetBulbTemperature value does not match");
			Assert.AreEqual(1.0674650586972729, data.TestOutput.Density, "Density value does not match");
			Assert.AreEqual(1.3011728466790744, data.TestOutput.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(0.98433703933651040, data.TestOutput.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(170.91398613910155, data.TestOutput.Enthalpy, "Enthalpy value does not match");  //LWBTnew
		}

		[TestMethod]
		public void SI_CalculateAdjustedFlowEqualTest()
		{
			bool methodThrew = false;

			TowerSpecifications design = new TowerSpecifications()
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

			TowerSpecifications test = new TowerSpecifications()
			{
				IsInternationalSystemOfUnits_SI = true,
				HotWaterTemperature = 49.36,
				ColdWaterTemperature = 30.56,
				WetBulbTemperature = 26.0,
				DryBulbTemperature = 30.2,
				BarometricPressure = 101.325,
				WaterFlowRate = 3583.0,
				FanDriverPower = 107.0,
				LiquidToGasRatio = 0.0
			};

			MechanicalDraftPerformanceCurveCalculationData data = new MechanicalDraftPerformanceCurveCalculationData()
			{
				IsInternationalSystemOfUnits_SI = true,
				TowerType = TOWER_TYPE.Induced,
				TowerDesignData = design,
				TowerTestData = test,
			};

			try
			{
				CalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();
				CalculationLibrary.DetermineAdjustedTestFlow(data, data.TowerDesignData, data.TowerTestData, data.TestOutput);
			}
			catch
			{
				methodThrew = true;
			}

			Assert.IsFalse(methodThrew, "Method threw");
			Assert.AreEqual(3583.0000000000000, data.TestOutput.AdjustedFlow, "AdjustedFlow value does not match"); // 
			Assert.AreEqual(41.851568222045898, data.TestOutput.WetBulbTemperature, "WetBulbTemperature value does not match");
			Assert.AreEqual(1.0863552148049491, data.TestOutput.Density, "Density value does not match");
			Assert.AreEqual(1.3, data.TestOutput.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(0.97081414797849852, data.TestOutput.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(182.90815739210535, data.TestOutput.Enthalpy, "Enthalpy value does not match");  //LWBTnew
		}

		[TestMethod]
		public void SI_CalculateAdjustedFlowDesignTest()
		{
			bool methodThrew = false;

			TowerSpecifications design = new TowerSpecifications()
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

			TowerSpecifications test = new TowerSpecifications()
			{
				IsInternationalSystemOfUnits_SI = true,
				HotWaterTemperature = 49.36,
				ColdWaterTemperature = 30.56,
				WetBulbTemperature = 26.0,
				DryBulbTemperature = 30.2,
				BarometricPressure = 101.325,
				WaterFlowRate = 3583.0,
				FanDriverPower = 107.0,
				LiquidToGasRatio = 0.0
			};

			MechanicalDraftPerformanceCurveCalculationData data = new MechanicalDraftPerformanceCurveCalculationData()
			{
				IsInternationalSystemOfUnits_SI = true,
				TowerType = TOWER_TYPE.Induced,
				TowerDesignData = design,
				TowerTestData = test,
			};

			try
			{
				CalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();
				CalculationLibrary.DetermineAdjustedTestFlow(data, data.TowerDesignData, data.TowerTestData, data.DesignOutput);
			}
			catch
			{
				methodThrew = true;
			}

			Assert.IsFalse(methodThrew, "Method threw");
			Assert.AreEqual(41.851568222045898, data.DesignOutput.WetBulbTemperature, "WetBulbTemperature value does not match");
			Assert.AreEqual(1.0863552148049491, data.DesignOutput.Density, "Density value does not match");
			Assert.AreEqual(0.97081414797849852, data.DesignOutput.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(182.90815739210535, data.DesignOutput.Enthalpy, "Enthalpy value does not match");  //LWBTnew
			Assert.AreEqual(3583.0000000000000, data.DesignOutput.AdjustedFlow, "AdjustedFlow value does not match"); // 
			Assert.AreEqual(1.3000000000000000, data.DesignOutput.LiquidToGasRatio, "LiquidToGasRatio value does not match");
		}

		[TestMethod]
		public void SI_CalculateAdjustedFlowDesignSpecificVolumeZeroTest()
		{
			bool methodThrew = false;

			TowerSpecifications design = new TowerSpecifications()
			{
				IsInternationalSystemOfUnits_SI = true,
				HotWaterTemperature = 49.36,
				ColdWaterTemperature = 30.56,
				WetBulbTemperature = 26.0,
				DryBulbTemperature = 30.2,
				BarometricPressure = 0.0,
				WaterFlowRate = 3583.0,
				FanDriverPower = 107.0,
				LiquidToGasRatio = 1.3,
			};

			TowerSpecifications test = new TowerSpecifications()
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

			MechanicalDraftPerformanceCurveCalculationData data = new MechanicalDraftPerformanceCurveCalculationData()
			{
				IsInternationalSystemOfUnits_SI = true,
				TowerType = TOWER_TYPE.Induced,
				TowerDesignData = design,
				TowerTestData = test
			};

			try
			{
				CalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();
				CalculationLibrary.DetermineAdjustedTestFlow(data, data.TowerDesignData, data.TowerTestData, data.TestOutput);
			}
			catch
			{
				methodThrew = true;
			}

			Assert.IsFalse(methodThrew, "Method threw");
			Assert.AreEqual(0.0, data.TestOutput.AdjustedFlow, "AdjustedFlow value does not match"); // 
			Assert.AreEqual(24.519567489624023, data.TestOutput.WetBulbTemperature, "WetBulbTemperature value does not match");
			Assert.AreEqual(1.1425844778969703, data.TestOutput.Density, "Density value does not match");
			Assert.AreEqual(0.0, data.TestOutput.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(0.89279643212401505, data.TestOutput.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(75.814519566529384, data.TestOutput.Enthalpy, "Enthalpy value does not match");  //LWBTnew
		}

		[TestMethod]
		public void SI_CalculateAdjustedFlowDesignWaterFlowRateZeroTest()
		{
			bool methodThrew = false;

			TowerSpecifications design = new TowerSpecifications()
			{
				IsInternationalSystemOfUnits_SI = true,
				HotWaterTemperature = 49.36,
				ColdWaterTemperature = 30.56,
				WetBulbTemperature = 26.0,
				DryBulbTemperature = 30.2,
				BarometricPressure = 101.325,
				WaterFlowRate = 0.0,
				FanDriverPower = 107.0,
				LiquidToGasRatio = 1.3,
			};

			TowerSpecifications test = new TowerSpecifications()
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

			MechanicalDraftPerformanceCurveCalculationData data = new MechanicalDraftPerformanceCurveCalculationData()
			{
				IsInternationalSystemOfUnits_SI = true,
				TowerType = TOWER_TYPE.Induced,
				TowerDesignData = design,
				TowerTestData = test
			};

			try
			{
				CalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();
				CalculationLibrary.DetermineAdjustedTestFlow(data, data.TowerDesignData, data.TowerTestData, data.TestOutput);
			}
			catch
			{
				methodThrew = true;
			}

			Assert.IsFalse(methodThrew, "Method threw");
			Assert.AreEqual(3618.0586354734178, data.TestOutput.AdjustedFlow, "AdjustedFlow value does not match"); // 
			Assert.AreEqual(24.519567489624023, data.TestOutput.WetBulbTemperature, "WetBulbTemperature value does not match");
			Assert.AreEqual(1.1425844778969703, data.TestOutput.Density, "Density value does not match");
			Assert.AreEqual(0.0, data.TestOutput.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(0.89279643212401505, data.TestOutput.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(75.814519566529384, data.TestOutput.Enthalpy, "Enthalpy value does not match");  //LWBTnew
		}

		[TestMethod]
		public void SI_CalculateAdjustedFlowDesignDensityZeroTest()
		{
			bool methodThrew = false;

			TowerSpecifications design = new TowerSpecifications()
			{
				IsInternationalSystemOfUnits_SI = true,
				HotWaterTemperature = 49.36,
				ColdWaterTemperature = 30.56,
				WetBulbTemperature = 26.0,
				DryBulbTemperature = 30.2,
				BarometricPressure = 0.0,
				WaterFlowRate = 3583.0,
				FanDriverPower = 107.0,
				LiquidToGasRatio = 1.3,
			};

			TowerSpecifications test = new TowerSpecifications()
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

			MechanicalDraftPerformanceCurveCalculationData data = new MechanicalDraftPerformanceCurveCalculationData()
			{
				IsInternationalSystemOfUnits_SI = true,
				TowerType = TOWER_TYPE.Induced,
				TowerDesignData = design,
				TowerTestData = test
			};

			try
			{
				CalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();
				CalculationLibrary.DetermineAdjustedTestFlow(data, data.TowerDesignData, data.TowerTestData, data.TestOutput);
			}
			catch
			{
				methodThrew = true;
			}

			Assert.IsFalse(methodThrew, "Method threw");
			Assert.AreEqual(0.0, data.TestOutput.AdjustedFlow, "AdjustedFlow value does not match"); // 
			Assert.AreEqual(24.519567489624023, data.TestOutput.WetBulbTemperature, "WetBulbTemperature value does not match");
			Assert.AreEqual(1.1425844778969703, data.TestOutput.Density, "Density value does not match");
			Assert.AreEqual(0.0, data.TestOutput.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(0.89279643212401505, data.TestOutput.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(75.814519566529384, data.TestOutput.Enthalpy, "Enthalpy value does not match");  //LWBTnew
		}

		[TestMethod]
		public void SI_CalculateAdjustedFlowTestDataFanDriverPowerZeroTest()
		{
			bool methodThrew = false;

			TowerSpecifications design = new TowerSpecifications()
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

			TowerSpecifications test = new TowerSpecifications()
			{
				IsInternationalSystemOfUnits_SI = true,
				HotWaterTemperature = 46.5,
				ColdWaterTemperature = 29.04,
				WetBulbTemperature = 24.53,
				DryBulbTemperature = 25.52,
				BarometricPressure = 98.8,
				WaterFlowRate = 3623.0,
				FanDriverPower = 0.0,
				LiquidToGasRatio = 0.0
			};

			MechanicalDraftPerformanceCurveCalculationData data = new MechanicalDraftPerformanceCurveCalculationData()
			{
				IsInternationalSystemOfUnits_SI = true,
				TowerType = TOWER_TYPE.Induced,
				TowerDesignData = design,
				TowerTestData = test
			};

			try
			{
				CalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();
				CalculationLibrary.DetermineAdjustedTestFlow(data, data.TowerDesignData, data.TowerTestData, data.TestOutput);
			}
			catch
			{
				methodThrew = true;
			}

			Assert.IsFalse(methodThrew, "Method threw");
			Assert.AreEqual(0.0, data.TestOutput.AdjustedFlow, "AdjustedFlow value does not match"); // 
			Assert.AreEqual(24.519567489624023, data.TestOutput.WetBulbTemperature, "WetBulbTemperature value does not match");
			Assert.AreEqual(1.1425844778969703, data.TestOutput.Density, "Density value does not match");
			Assert.AreEqual(0.0, data.TestOutput.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(0.89279643212401505, data.TestOutput.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(75.814519566529384, data.TestOutput.Enthalpy, "Enthalpy value does not match");  //LWBTnew
		}

		[TestMethod]
		public void SI_CalculateAdjustedFlowDesignWaterFlowRateZero_Test()
		{
			bool methodThrew = false;

			TowerSpecifications design = new TowerSpecifications()
			{
				IsInternationalSystemOfUnits_SI = true,
				HotWaterTemperature = 49.36,
				ColdWaterTemperature = 30.56,
				WetBulbTemperature = 26.0,
				DryBulbTemperature = 30.2,
				BarometricPressure = 101.325,
				WaterFlowRate = 0.0,
				FanDriverPower = 107.0,
				LiquidToGasRatio = 1.3,
			};

			TowerSpecifications test = new TowerSpecifications()
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

			MechanicalDraftPerformanceCurveCalculationData data = new MechanicalDraftPerformanceCurveCalculationData()
			{
				IsInternationalSystemOfUnits_SI = true,
				TowerType = TOWER_TYPE.Induced,
				TowerDesignData = design,
				TowerTestData = test
			};

			try
			{
				CalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();
				CalculationLibrary.DetermineAdjustedTestFlow(data, data.TowerDesignData, data.TowerTestData, data.TestOutput);
			}
			catch
			{
				methodThrew = true;
			}

			Assert.IsFalse(methodThrew, "Method threw");
			Assert.AreEqual(3618.0586354734178, data.TestOutput.AdjustedFlow, "AdjustedFlow value does not match"); // 
			Assert.AreEqual(24.519567489624023, data.TestOutput.WetBulbTemperature, "WetBulbTemperature value does not match");
			Assert.AreEqual(1.1425844778969703, data.TestOutput.Density, "Density value does not match");
			Assert.AreEqual(0.0, data.TestOutput.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(0.89279643212401505, data.TestOutput.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(75.814519566529384, data.TestOutput.Enthalpy, "Enthalpy value does not match");  //LWBTnew
		}

		[TestMethod]
		public void SI_CalculateAdjustedFlow_TowerTypeForcedTest()
		{
			bool methodThrew = false;

			TowerSpecifications design = new TowerSpecifications()
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

			TowerSpecifications test = new TowerSpecifications()
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

			MechanicalDraftPerformanceCurveCalculationData data = new MechanicalDraftPerformanceCurveCalculationData()
			{
				IsInternationalSystemOfUnits_SI = true,
				TowerType = TOWER_TYPE.Forced,
				TowerDesignData = design,
				TowerTestData = test
			};

			try
			{
				CalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();
				CalculationLibrary.DetermineAdjustedTestFlow(data, data.TowerDesignData, data.TowerTestData, data.TestOutput);
			}
			catch
			{
				methodThrew = true;
			}

			Assert.IsFalse(methodThrew, "Method threw");
			Assert.AreEqual(3546.2133275650176, data.TestOutput.AdjustedFlow, "AdjustedFlow value does not match");
			Assert.AreEqual(75.814505757206248, data.TestOutput.Enthalpy, "Enthalpy value does not match"); // HLWBT
			Assert.AreEqual(1.1390264967114228, data.TestOutput.Density, "Density value does not match"); // DenOutT
			Assert.AreEqual(0.0, data.TestOutput.LiquidToGasRatio, "LiquidToGasRatio value does not match"); // LinGt
			Assert.AreEqual(0.89522584455700294, data.TestOutput.SpecificVolume, "SpecificVolume value does not match"); // SVOutT
			Assert.AreEqual(24.530000000000001, data.TestOutput.WetBulbTemperature, "WetBulbTemperature value does not match");  //LWBTnew // LWBTnew
		}

		[TestMethod]
		public void IP_CalculateAdjustedFlowTest()
		{
			bool methodThrew = false;

			TowerSpecifications design = new TowerSpecifications()
			{
				IsInternationalSystemOfUnits_SI = false,
				HotWaterTemperature = 120.92, // EWTd
				ColdWaterTemperature = 87.08, // LWTd
				WetBulbTemperature = 78.78,   // EWBd
				DryBulbTemperature = 86.36,   // EDBd
				BarometricPressure = 29.921,  // BPd
				WaterFlowRate = 56792.0,      // FLOWd
				FanDriverPower = 107.0,       // BHPd
				LiquidToGasRatio = 1.3        // LinGD
			};

			TowerSpecifications test = new TowerSpecifications()
			{
				IsInternationalSystemOfUnits_SI = false,
				HotWaterTemperature = 115.70, // EWTt
				ColdWaterTemperature = 84.27, // LWTt
				WetBulbTemperature = 76.18,   // EWBt
				DryBulbTemperature = 77.94,   // EDBt
				BarometricPressure = 29.18,   // BPt
				WaterFlowRate = 57426.0,      // FLOWt
				FanDriverPower = 151.5,       // BHPt
				LiquidToGasRatio = 0.0        // LinGt
			};

			DesignData designData = new DesignData()
			{
				TowerSpecifications = design,
				TowerType = TOWER_TYPE.Induced
			};

			MechanicalDraftPerformanceCurveCalculationData data = new MechanicalDraftPerformanceCurveCalculationData()
			{
				IsInternationalSystemOfUnits_SI = false,
				TowerType = TOWER_TYPE.Induced,
				TowerDesignData = design,
				TowerTestData = test
			};

			try
			{
				CalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();
				CalculationLibrary.DetermineAdjustedTestFlow(data, data.TowerDesignData, data.TowerTestData, data.TestOutput);
			}
			catch
			{
				methodThrew = true;
			}

			Assert.IsFalse(methodThrew, "Method threw");
			Assert.AreEqual(50933.754011184392, data.TestOutput.AdjustedFlow, "AdjustedFlow value does not match");
			Assert.AreEqual(102.14726448059082, data.TestOutput.WetBulbTemperature, "WetBulbTemperature value does not match");
			Assert.AreEqual(0.067004160013637529, data.TestOutput.Density, "Density value does not match");
			Assert.AreEqual(1.1722743247225325, data.TestOutput.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(15.634346602502317, data.TestOutput.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(77.140437876858286, data.TestOutput.Enthalpy, "Enthalpy value does not match");  //LWBTnew
		}

		[TestMethod]
		public void IP_CalculateAdjustedFlowDesignTest()
		{
			bool methodThrew = false;

			TowerSpecifications design = new TowerSpecifications()
			{
				IsInternationalSystemOfUnits_SI = false,
				HotWaterTemperature = 120.92, // EWTd
				ColdWaterTemperature = 87.08, // LWTd
				WetBulbTemperature = 78.78,   // EWBd
				DryBulbTemperature = 86.36,   // EDBd
				BarometricPressure = 29.921,  // BPd
				WaterFlowRate = 56792.0,      // FLOWd
				FanDriverPower = 107.0,       // BHPd
				LiquidToGasRatio = 1.3        // LinGD
			};

			TowerSpecifications test = new TowerSpecifications()
			{
				IsInternationalSystemOfUnits_SI = false,
				HotWaterTemperature = 120.92, // EWTd
				ColdWaterTemperature = 87.08, // LWTd
				WetBulbTemperature = 78.78,   // EWBd
				DryBulbTemperature = 86.36,   // EDBd
				BarometricPressure = 29.921,  // BPd
				WaterFlowRate = 56792.0,      // FLOWd
				FanDriverPower = 107.0,       // BHPd
				LiquidToGasRatio = 0.0        // LinGt
			};

			DesignData designData = new DesignData()
			{
				TowerSpecifications = design,
				TowerType = TOWER_TYPE.Induced
			};

			MechanicalDraftPerformanceCurveCalculationData data = new MechanicalDraftPerformanceCurveCalculationData()
			{
				IsInternationalSystemOfUnits_SI = false,
				TowerType = TOWER_TYPE.Induced,
				TowerDesignData = design,
				TowerTestData = test
			};

			try
			{
				CalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();
				CalculationLibrary.DetermineAdjustedTestFlow(data, data.TowerDesignData, data.TowerTestData, data.DesignOutput);
			}
			catch
			{
				methodThrew = true;
			}

			Assert.IsFalse(methodThrew, "Method threw");
			Assert.AreEqual(56792.006785297119, data.DesignOutput.AdjustedFlow, "AdjustedFlow value does not match");
			Assert.AreEqual(107.31320381164551, data.DesignOutput.WetBulbTemperature, "WetBulbTemperature value does not match");
			Assert.AreEqual(0.067823735869406584, data.DesignOutput.Density, "Density value does not match");
			Assert.AreEqual(1.2999994033048008, data.DesignOutput.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(15.549345267950724, data.DesignOutput.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(86.303580556326608, data.DesignOutput.Enthalpy, "Enthalpy value does not match");  //LWBTnew
		}

		[TestMethod]
		public void IP_CalculateAdjustedFlowDesignEqualTest()
		{
			bool methodThrew = false;

			TowerSpecifications design = new TowerSpecifications()
			{
				IsInternationalSystemOfUnits_SI = false,
				WaterFlowRate = 56792.0,
				ColdWaterTemperature = 87.08,
				HotWaterTemperature = 120.92,
				WetBulbTemperature = 78.8,
				DryBulbTemperature = 86.36,
				FanDriverPower = 143.4,
				BarometricPressure = 29.921,
				LiquidToGasRatio = 1.3
			};

			TowerSpecifications test = new TowerSpecifications()
			{
				IsInternationalSystemOfUnits_SI = false,
				WaterFlowRate = 56792.0,
				ColdWaterTemperature = 87.075,
				HotWaterTemperature = 120.924,
				WetBulbTemperature = 78.804,
				DryBulbTemperature = 86.36,
				FanDriverPower = 143.4,
				BarometricPressure = 29.921,
				LiquidToGasRatio = 0.0
			};

			DesignData designData = new DesignData()
			{
				TowerSpecifications = design,
				TowerType = TOWER_TYPE.Induced
			};

			MechanicalDraftPerformanceCurveCalculationData data = new MechanicalDraftPerformanceCurveCalculationData()
			{
				IsInternationalSystemOfUnits_SI = false,
				TowerType = TOWER_TYPE.Induced,
				TowerDesignData = design,
				TowerTestData = test
			};

			try
			{
				CalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();
				CalculationLibrary.DetermineAdjustedTestFlow(data, data.TowerDesignData, data.TowerTestData, data.DesignOutput);
			}
			catch
			{
				methodThrew = true;
			}

			Assert.IsFalse(methodThrew, "Method threw");
			Assert.AreEqual(56791.606412452042, data.DesignOutput.AdjustedFlow, "AdjustedFlow value does not match");
			Assert.AreEqual(107.33069419860840, data.DesignOutput.WetBulbTemperature, "WetBulbTemperature value does not match");
			Assert.AreEqual(0.067820551120395103, data.DesignOutput.Density, "Density value does not match");
			Assert.AreEqual(1.3000346171623827, data.DesignOutput.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(15.550523802136656, data.DesignOutput.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(86.341914432515892, data.DesignOutput.Enthalpy, "Enthalpy value does not match");  //LWBTnew
		}

		[TestMethod]
		public void IP_CalculateAdjustedFlowTDesignDensityZeroest()
		{
			bool methodThrew = false;

			TowerSpecifications design = new TowerSpecifications()
			{
				IsInternationalSystemOfUnits_SI = false,
				HotWaterTemperature = 120.92, // EWTd
				ColdWaterTemperature = 87.08, // LWTd
				WetBulbTemperature = 78.78,   // EWBd
				DryBulbTemperature = 86.36,   // EDBd
				BarometricPressure = 0.0,  // BPd
				WaterFlowRate = 56792.0,      // FLOWd
				FanDriverPower = 107.0,       // BHPd
				LiquidToGasRatio = 1.3        // LinGD
			};

			TowerSpecifications test = new TowerSpecifications()
			{
				IsInternationalSystemOfUnits_SI = false,
				HotWaterTemperature = 115.70, // EWTt
				ColdWaterTemperature = 84.27, // LWTt
				WetBulbTemperature = 76.18,   // EWBt
				DryBulbTemperature = 77.94,   // EDBt
				BarometricPressure = 29.18,   // BPt
				WaterFlowRate = 57426.0,      // FLOWt
				FanDriverPower = 151.5,       // BHPt
				LiquidToGasRatio = 0.0        // LinGt
			};

			MechanicalDraftPerformanceCurveCalculationData data = new MechanicalDraftPerformanceCurveCalculationData()
			{
				IsInternationalSystemOfUnits_SI = false,
				TowerType = TOWER_TYPE.Induced,
				TowerDesignData = design,
				TowerTestData = test
			};

			try
			{
				CalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();
				CalculationLibrary.DetermineAdjustedTestFlow(data, data.TowerDesignData, data.TowerTestData, data.TestOutput);
			}
			catch
			{
				methodThrew = true;
			}

			Assert.IsFalse(methodThrew, "Method threw");
			Assert.AreEqual(0.0, data.TestOutput.AdjustedFlow, "AdjustedFlow value does not match");
			Assert.AreEqual(76.161623001098633, data.TestOutput.WetBulbTemperature, "WetBulbTemperature value does not match");
			Assert.AreEqual(0.071337679048821351, data.TestOutput.Density, "Density value does not match");
			Assert.AreEqual(0.0, data.TestOutput.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(14.299739250387431, data.TestOutput.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(40.295763420590589, data.TestOutput.Enthalpy, "Enthalpy value does not match");  //LWBTnew
		}

		[TestMethod]
		public void IP_CalculateAdjustedFlowTestDataFanDriverPowerZeroTest()
		{
			bool methodThrew = false;

			TowerSpecifications design = new TowerSpecifications()
			{
				IsInternationalSystemOfUnits_SI = false,
				HotWaterTemperature = 120.92, // EWTd
				ColdWaterTemperature = 87.08, // LWTd
				WetBulbTemperature = 78.78,   // EWBd
				DryBulbTemperature = 86.36,   // EDBd
				BarometricPressure = 29.921,  // BPd
				WaterFlowRate = 56792.0,      // FLOWd
				FanDriverPower = 107.0,       // BHPd
				LiquidToGasRatio = 1.3        // LinGD
			};

			TowerSpecifications test = new TowerSpecifications()
			{
				IsInternationalSystemOfUnits_SI = false,
				HotWaterTemperature = 115.70, // EWTt
				ColdWaterTemperature = 84.27, // LWTt
				WetBulbTemperature = 76.18,   // EWBt
				DryBulbTemperature = 77.94,   // EDBt
				BarometricPressure = 29.18,   // BPt
				WaterFlowRate = 57426.0,      // FLOWt
				FanDriverPower = 0.0,       // BHPt
				LiquidToGasRatio = 0.0        // LinGt
			};

			MechanicalDraftPerformanceCurveCalculationData data = new MechanicalDraftPerformanceCurveCalculationData()
			{
				IsInternationalSystemOfUnits_SI = false,
				TowerType = TOWER_TYPE.Induced,
				TowerDesignData = design,
				TowerTestData = test
			};

			try
			{
				CalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();
				CalculationLibrary.DetermineAdjustedTestFlow(data, data.TowerDesignData, data.TowerTestData, data.TestOutput);
			}
			catch
			{
				methodThrew = true;
			}

			Assert.IsFalse(methodThrew, "Method threw");
			Assert.AreEqual(0.0, data.TestOutput.AdjustedFlow, "AdjustedFlow value does not match");
			Assert.AreEqual(76.161623001098633, data.TestOutput.WetBulbTemperature, "WetBulbTemperature value does not match");
			Assert.AreEqual(0.071337679048821351, data.TestOutput.Density, "Density value does not match");
			Assert.AreEqual(0.0, data.TestOutput.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(14.299739250387431, data.TestOutput.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(40.295763420590589, data.TestOutput.Enthalpy, "Enthalpy value does not match");  //LWBTnew
		}

		[TestMethod]
		public void IP_CalculateAdjustedFlow_TowerTypeForcedTest()
		{
			bool methodThrew = false;

			TowerSpecifications design = new TowerSpecifications()
			{
				IsInternationalSystemOfUnits_SI = false,
				HotWaterTemperature = 120.92, // EWTd
				ColdWaterTemperature = 87.08, // LWTd
				WetBulbTemperature = 78.78,   // EWBd
				DryBulbTemperature = 86.36,   // EDBd
				BarometricPressure = 29.921,  // BPd
				WaterFlowRate = 56792.0,      // FLOWd
				FanDriverPower = 107.0,       // BHPd
				LiquidToGasRatio = 1.3        // LinGD
			};

			TowerSpecifications test = new TowerSpecifications()
			{
				IsInternationalSystemOfUnits_SI = false,
				HotWaterTemperature = 115.70, // EWTt
				ColdWaterTemperature = 84.27, // LWTt
				WetBulbTemperature = 76.18,   // EWBt
				DryBulbTemperature = 77.94,   // EDBt
				BarometricPressure = 29.18,   // BPt
				WaterFlowRate = 57426.0,      // FLOWt
				FanDriverPower = 151.5,       // BHPt
				LiquidToGasRatio = 0.0        // LinGt
			};

			DesignData designData = new DesignData()
			{
				TowerSpecifications = design,
				TowerType = TOWER_TYPE.Forced
			};

			MechanicalDraftPerformanceCurveCalculationData data = new MechanicalDraftPerformanceCurveCalculationData()
			{
				IsInternationalSystemOfUnits_SI = false,
				TowerType = TOWER_TYPE.Forced,
				TowerDesignData = design,
				TowerTestData = test
			};

			try
			{
				CalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();
				CalculationLibrary.DetermineAdjustedTestFlow(data, data.TowerDesignData, data.TowerTestData, data.TestOutput);
			}
			catch
			{
				methodThrew = true;
			}

			Assert.IsFalse(methodThrew, "Method threw");
			Assert.AreEqual(50977.565031811129, data.TestOutput.AdjustedFlow, "AdjustedFlow value does not match");
			Assert.AreEqual(40.295820974981808, data.TestOutput.Enthalpy, "Enthalpy value does not match");
			Assert.AreEqual(0.071118288489722126, data.TestOutput.Density, "Density value does not match");
			Assert.AreEqual(0.0, data.TestOutput.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(14.338171292573175, data.TestOutput.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(76.18, data.TestOutput.WetBulbTemperature, "WetBulbTemperature value does not match");  //LWBTnew
		}
	}
}
