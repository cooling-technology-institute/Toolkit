﻿using System;
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
            Assert.AreEqual(3549.8089648534847, data.TestOutput.AdjustedFlow, "AdjustedFlow value does not match"); // 
			Assert.AreEqual(39.941644668579102, data.TestOutput.WetBulbTemperature, "WetBulbTemperature value does not match");
			Assert.AreEqual(1.0791204854438692, data.TestOutput.Density, "Density value does not match");
			Assert.AreEqual(1.2839296953830412, data.TestOutput.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(0.96780162756832133, data.TestOutput.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(152.00262906811440, data.TestOutput.Enthalpy, "Enthalpy value does not match");  //LWBTnew
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
				CalculationLibrary.DetermineAdjustedTestFlow(data, data.TowerDesignData, data.TowerDesignData, data.DesignOutput);
			}
			catch
			{
				methodThrew = true;
			}

			Assert.IsFalse(methodThrew, "Method threw");
			Assert.AreEqual(41.728010177612305, data.DesignOutput.WetBulbTemperature, "WetBulbTemperature value does not match");
			Assert.AreEqual(1.0962026451105518, data.DesignOutput.Density, "Density value does not match");
			Assert.AreEqual(0.95696108697698912, data.DesignOutput.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(166.34291126591086, data.DesignOutput.Enthalpy, "Enthalpy value does not match");  //LWBTnew
			Assert.AreEqual(3593.8116660848173, data.DesignOutput.AdjustedFlow, "AdjustedFlow value does not match"); // 
			Assert.AreEqual(1.2852851981790823, data.DesignOutput.LiquidToGasRatio, "LiquidToGasRatio value does not match");
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
			Assert.AreEqual(24.521169662475586, data.TestOutput.WetBulbTemperature, "WetBulbTemperature value does not match");
			Assert.AreEqual(1.0791204854438692, data.TestOutput.Density, "Density value does not match");
			Assert.AreEqual(0.0, data.TestOutput.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(0.96780162756832133, data.TestOutput.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(152.00262906811440, data.TestOutput.Enthalpy, "Enthalpy value does not match");  //LWBTnew
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
			Assert.AreEqual(3549.8089648534847, data.TestOutput.AdjustedFlow, "AdjustedFlow value does not match"); // 
			Assert.AreEqual(24.521169662475586, data.TestOutput.WetBulbTemperature, "WetBulbTemperature value does not match");
			Assert.AreEqual(1.0791204854438692, data.TestOutput.Density, "Density value does not match");
			Assert.AreEqual(0.0, data.TestOutput.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(0.96780162756832133, data.TestOutput.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(152.00262906811440, data.TestOutput.Enthalpy, "Enthalpy value does not match");  //LWBTnew
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
			Assert.AreEqual(24.521169662475586, data.TestOutput.WetBulbTemperature, "WetBulbTemperature value does not match");
			Assert.AreEqual(1.0791204854438692, data.TestOutput.Density, "Density value does not match");
			Assert.AreEqual(0.0, data.TestOutput.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(0.96780162756832133, data.TestOutput.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(152.00262906811440, data.TestOutput.Enthalpy, "Enthalpy value does not match");  //LWBTnew
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
			Assert.AreEqual(24.521169662475586, data.TestOutput.WetBulbTemperature, "WetBulbTemperature value does not match");
			Assert.AreEqual(1.0791204854438692, data.TestOutput.Density, "Density value does not match");
			Assert.AreEqual(0.0, data.TestOutput.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(0.96780162756832133, data.TestOutput.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(152.00262906811440, data.TestOutput.Enthalpy, "Enthalpy value does not match");  //LWBTnew
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
			Assert.AreEqual(3549.8089648534847, data.TestOutput.AdjustedFlow, "AdjustedFlow value does not match"); // 
			Assert.AreEqual(24.521169662475586, data.TestOutput.WetBulbTemperature, "WetBulbTemperature value does not match");
			Assert.AreEqual(1.0791204854438692, data.TestOutput.Density, "Density value does not match");
			Assert.AreEqual(0.0, data.TestOutput.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(0.96780162756832133, data.TestOutput.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(152.00262906811440, data.TestOutput.Enthalpy, "Enthalpy value does not match");  //LWBTnew
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
			Assert.AreEqual(3546.2191136184192, data.TestOutput.AdjustedFlow, "AdjustedFlow value does not match");
			Assert.AreEqual(75.821218466275639, data.TestOutput.Enthalpy, "Enthalpy value does not match"); // HLWBT
			Assert.AreEqual(1.1390247623025043, data.TestOutput.Density, "Density value does not match"); // DenOutT
			Assert.AreEqual(0.0, data.TestOutput.LiquidToGasRatio, "LiquidToGasRatio value does not match"); // LinGt
			Assert.AreEqual(0.89522952152485946, data.TestOutput.SpecificVolume, "SpecificVolume value does not match"); // SVOutT
			Assert.AreEqual(24.53, data.TestOutput.WetBulbTemperature, "WetBulbTemperature value does not match");  //LWBTnew // LWBTnew
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
			Assert.AreEqual(51028.716619350191, data.TestOutput.AdjustedFlow, "AdjustedFlow value does not match");
			Assert.AreEqual(102.01949119567871, data.TestOutput.WetBulbTemperature, "WetBulbTemperature value does not match");
			Assert.AreEqual(0.067379633634750025, data.TestOutput.Density, "Density value does not match");
			Assert.AreEqual(1.1643467203016293, data.TestOutput.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(15.499719809090942, data.TestOutput.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(73.037664309523052, data.TestOutput.Enthalpy, "Enthalpy value does not match");  //LWBTnew
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
				CalculationLibrary.DetermineAdjustedTestFlow(data, data.TowerDesignData, data.TowerDesignData, data.DesignOutput);
			}
			catch
			{
				methodThrew = true;
			}

			Assert.IsFalse(methodThrew, "Method threw");
			Assert.AreEqual(56958.512391914417, data.DesignOutput.AdjustedFlow, "AdjustedFlow value does not match");
			Assert.AreEqual(107.09170341491699, data.DesignOutput.WetBulbTemperature, "WetBulbTemperature value does not match");
			Assert.AreEqual(0.068422033486526229, data.DesignOutput.Density, "Density value does not match");
			Assert.AreEqual(1.2856961304652681, data.DesignOutput.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(15.333308295391994, data.DesignOutput.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(79.362347906243286, data.DesignOutput.Enthalpy, "Enthalpy value does not match");  //LWBTnew
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
			Assert.AreEqual(0.067379633634750025, data.TestOutput.Density, "Density value does not match");
			Assert.AreEqual(0.0, data.TestOutput.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(15.499719809090942, data.TestOutput.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(73.037664309523052, data.TestOutput.Enthalpy, "Enthalpy value does not match");  //LWBTnew
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
			Assert.AreEqual(0.067379633634750025, data.TestOutput.Density, "Density value does not match");
			Assert.AreEqual(0.0, data.TestOutput.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(15.499719809090942, data.TestOutput.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(73.037664309523052, data.TestOutput.Enthalpy, "Enthalpy value does not match");  //LWBTnew
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
