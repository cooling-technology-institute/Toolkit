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

			TowerTestData test = new TowerTestData(true)
			{
				TestName = "test",
				TowerSpecifications =
                {
					HotWaterTemperature = 46.5,
					ColdWaterTemperature = 29.04,
					WetBulbTemperature = 24.53,
					DryBulbTemperature = 25.52,
					BarometricPressure = 98.8,
					WaterFlowRate = 3623.0,
					FanDriverPower = 113.0,
					LiquidToGasRatio = 0.0
				}
			};

			DesignData designData = new DesignData()
			{
				TowerSpecifications = design,
				TowerType = TOWER_TYPE.Induced
			};

			MechanicalDraftPerformanceCurveFileData data = new MechanicalDraftPerformanceCurveFileData(true)
			{
				IsInternationalSystemOfUnits_SI = true,
				DesignData = designData
			};
			data.TestData.Add(test);

			MechanicalDraftPerformanceCurveOutput output = new MechanicalDraftPerformanceCurveOutput();

			try
			{
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.DetermineAdjustedTestFlow(0, data, output);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(3549.8089648534847, output.AdjustedFlow, "AdjustedFlow value does not match"); // 
			Assert.AreEqual(39.941644668579102, output.ColdWaterTemperatureDeviation, "ColdWaterTemperatureDeviation value does not match");
			Assert.AreEqual(1.0791204854438692, output.Density, "Density value does not match");
			Assert.AreEqual(1.2839296953830412, output.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(0.96780162756832133, output.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(152.00262906811440, output.WetBulbTemperature, "WetBulbTemperature value does not match");  //LWBTnew
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

			TowerTestData test = new TowerTestData(true)
			{
				TestName = "test",
				TowerSpecifications =
				{
					HotWaterTemperature = 46.5,
					ColdWaterTemperature = 29.04,
					WetBulbTemperature = 24.53,
					DryBulbTemperature = 25.52,
					BarometricPressure = 98.8,
					WaterFlowRate = 3623.0,
					FanDriverPower = 113.0,
					LiquidToGasRatio = 0.0
				}
			};

			DesignData designData = new DesignData()
			{
				TowerSpecifications = design,
				TowerType = TOWER_TYPE.Induced
			};

			MechanicalDraftPerformanceCurveFileData data = new MechanicalDraftPerformanceCurveFileData(true)
			{
				IsInternationalSystemOfUnits_SI = true,
				DesignData = designData
			};
			data.TestData.Add(test);

			MechanicalDraftPerformanceCurveOutput output = new MechanicalDraftPerformanceCurveOutput();

			try
			{
				CalculationLibrary = new CalculationLibrary.CalculationLibrary();
				CalculationLibrary.DetermineAdjustedTestFlow(0, data, output);
			}
			catch
			{
				methodThrew = true;
			}

			Assert.IsFalse(methodThrew, "Method threw");
			Assert.AreEqual(0.0, output.AdjustedFlow, "AdjustedFlow value does not match"); // 
			Assert.AreEqual(24.521169662475586, output.ColdWaterTemperatureDeviation, "ColdWaterTemperatureDeviation value does not match");
			Assert.AreEqual(1.0791204854438692, output.Density, "Density value does not match");
			Assert.AreEqual(0.0, output.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(0.96780162756832133, output.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(152.00262906811440, output.WetBulbTemperature, "WetBulbTemperature value does not match");  //LWBTnew
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

			TowerTestData test = new TowerTestData(true)
			{
				TestName = "test",
				TowerSpecifications =
				{
					HotWaterTemperature = 46.5,
					ColdWaterTemperature = 29.04,
					WetBulbTemperature = 24.53,
					DryBulbTemperature = 25.52,
					BarometricPressure = 98.8,
					WaterFlowRate = 3623.0,
					FanDriverPower = 113.0,
					LiquidToGasRatio = 0.0
				}
			};

			DesignData designData = new DesignData()
			{
				TowerSpecifications = design,
				TowerType = TOWER_TYPE.Induced
			};

			MechanicalDraftPerformanceCurveFileData data = new MechanicalDraftPerformanceCurveFileData(true)
			{
				IsInternationalSystemOfUnits_SI = true,
				DesignData = designData
			};
			data.TestData.Add(test);

			MechanicalDraftPerformanceCurveOutput output = new MechanicalDraftPerformanceCurveOutput();

			try
			{
				CalculationLibrary = new CalculationLibrary.CalculationLibrary();
				CalculationLibrary.DetermineAdjustedTestFlow(0, data, output);
			}
			catch
			{
				methodThrew = true;
			}

			Assert.IsFalse(methodThrew, "Method threw");
			Assert.AreEqual(3549.8089648534847, output.AdjustedFlow, "AdjustedFlow value does not match"); // 
			Assert.AreEqual(24.521169662475586, output.ColdWaterTemperatureDeviation, "ColdWaterTemperatureDeviation value does not match");
			Assert.AreEqual(1.0791204854438692, output.Density, "Density value does not match");
			Assert.AreEqual(0.0, output.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(0.96780162756832133, output.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(152.00262906811440, output.WetBulbTemperature, "WetBulbTemperature value does not match");  //LWBTnew
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

			TowerTestData test = new TowerTestData(true)
			{
				TestName = "test",
				TowerSpecifications =
				{
					HotWaterTemperature = 46.5,
					ColdWaterTemperature = 29.04,
					WetBulbTemperature = 24.53,
					DryBulbTemperature = 25.52,
					BarometricPressure = 98.8,
					WaterFlowRate = 3623.0,
					FanDriverPower = 113.0,
					LiquidToGasRatio = 0.0
				}
			};

			DesignData designData = new DesignData()
			{
				TowerSpecifications = design,
				TowerType = TOWER_TYPE.Induced
			};

			MechanicalDraftPerformanceCurveFileData data = new MechanicalDraftPerformanceCurveFileData(true)
			{
				IsInternationalSystemOfUnits_SI = true,
				DesignData = designData
			};
			data.TestData.Add(test);

			MechanicalDraftPerformanceCurveOutput output = new MechanicalDraftPerformanceCurveOutput();

			try
			{
				CalculationLibrary = new CalculationLibrary.CalculationLibrary();
				CalculationLibrary.DetermineAdjustedTestFlow(0, data, output);
			}
			catch
			{
				methodThrew = true;
			}

			Assert.IsFalse(methodThrew, "Method threw");
			Assert.AreEqual(0.0, output.AdjustedFlow, "AdjustedFlow value does not match"); // 
			Assert.AreEqual(24.521169662475586, output.ColdWaterTemperatureDeviation, "ColdWaterTemperatureDeviation value does not match");
			Assert.AreEqual(1.0791204854438692, output.Density, "Density value does not match");
			Assert.AreEqual(0.0, output.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(0.96780162756832133, output.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(152.00262906811440, output.WetBulbTemperature, "WetBulbTemperature value does not match");  //LWBTnew
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

			TowerTestData test = new TowerTestData(true)
			{
				TestName = "test",
				TowerSpecifications =
				{
					HotWaterTemperature = 46.5,
					ColdWaterTemperature = 29.04,
					WetBulbTemperature = 24.53,
					DryBulbTemperature = 25.52,
					BarometricPressure = 98.8,
					WaterFlowRate = 3623.0,
					FanDriverPower = 0.0,
					LiquidToGasRatio = 0.0
				}
			};

			DesignData designData = new DesignData()
			{
				TowerSpecifications = design,
				TowerType = TOWER_TYPE.Induced
			};

			MechanicalDraftPerformanceCurveFileData data = new MechanicalDraftPerformanceCurveFileData(true)
			{
				IsInternationalSystemOfUnits_SI = true,
				DesignData = designData
			};
			data.TestData.Add(test);

			MechanicalDraftPerformanceCurveOutput output = new MechanicalDraftPerformanceCurveOutput();

			try
			{
				CalculationLibrary = new CalculationLibrary.CalculationLibrary();
				CalculationLibrary.DetermineAdjustedTestFlow(0, data, output);
			}
			catch
			{
				methodThrew = true;
			}

			Assert.IsFalse(methodThrew, "Method threw");
			Assert.AreEqual(0.0, output.AdjustedFlow, "AdjustedFlow value does not match"); // 
			Assert.AreEqual(24.521169662475586, output.ColdWaterTemperatureDeviation, "ColdWaterTemperatureDeviation value does not match");
			Assert.AreEqual(1.0791204854438692, output.Density, "Density value does not match");
			Assert.AreEqual(0.0, output.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(0.96780162756832133, output.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(152.00262906811440, output.WetBulbTemperature, "WetBulbTemperature value does not match");  //LWBTnew
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

			TowerTestData test = new TowerTestData(true)
			{
				TestName = "test",
				TowerSpecifications =
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
				}
			};

			DesignData designData = new DesignData()
			{
				TowerSpecifications = design,
				TowerType = TOWER_TYPE.Induced
			};

			MechanicalDraftPerformanceCurveFileData data = new MechanicalDraftPerformanceCurveFileData(true)
			{
				IsInternationalSystemOfUnits_SI = true,
				DesignData = designData
			};
			data.TestData.Add(test);

			MechanicalDraftPerformanceCurveOutput output = new MechanicalDraftPerformanceCurveOutput();

			try
			{
				CalculationLibrary = new CalculationLibrary.CalculationLibrary();
				CalculationLibrary.DetermineAdjustedTestFlow(0, data, output);
			}
			catch
			{
				methodThrew = true;
			}

			Assert.IsFalse(methodThrew, "Method threw");
			Assert.AreEqual(3549.8089648534847, output.AdjustedFlow, "AdjustedFlow value does not match"); // 
			Assert.AreEqual(24.521169662475586, output.ColdWaterTemperatureDeviation, "ColdWaterTemperatureDeviation value does not match");
			Assert.AreEqual(1.0791204854438692, output.Density, "Density value does not match");
			Assert.AreEqual(0.0, output.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(0.96780162756832133, output.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(152.00262906811440, output.WetBulbTemperature, "WetBulbTemperature value does not match");  //LWBTnew
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

			TowerTestData test = new TowerTestData(true)
			{
				TestName = "test",
				TowerSpecifications =
				{
					HotWaterTemperature = 46.5,
					ColdWaterTemperature = 29.04,
					WetBulbTemperature = 24.53,
					DryBulbTemperature = 25.52,
					BarometricPressure = 98.8,
					WaterFlowRate = 3623.0,
					FanDriverPower = 113.0,
					LiquidToGasRatio = 0.0
				}
			};

			DesignData designData = new DesignData()
			{
				TowerSpecifications = design,
				TowerType = TOWER_TYPE.Forced
			};

			MechanicalDraftPerformanceCurveFileData data = new MechanicalDraftPerformanceCurveFileData(true)
			{
				IsInternationalSystemOfUnits_SI = true,
				DesignData = designData
			};
			data.TestData.Add(test);

			MechanicalDraftPerformanceCurveOutput output = new MechanicalDraftPerformanceCurveOutput();

			try
			{
				CalculationLibrary = new CalculationLibrary.CalculationLibrary();
				CalculationLibrary.DetermineAdjustedTestFlow(0, data, output);
			}
			catch
			{
				methodThrew = true;
			}

			Assert.IsFalse(methodThrew, "Method threw");
			Assert.AreEqual(3546.2191136184192, output.AdjustedFlow, "AdjustedFlow value does not match");
			Assert.AreEqual(75.821218466275639, output.ColdWaterTemperatureDeviation, "ColdWaterTemperatureDeviation value does not match"); // HLWBT
			Assert.AreEqual(1.1390247623025043, output.Density, "Density value does not match"); // DenOutT
			Assert.AreEqual(0.0, output.LiquidToGasRatio, "LiquidToGasRatio value does not match"); // LinGt
			Assert.AreEqual(0.89522952152485946, output.SpecificVolume, "SpecificVolume value does not match"); // SVOutT
			Assert.AreEqual(24.53, output.WetBulbTemperature, "WetBulbTemperature value does not match");  //LWBTnew // LWBTnew
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

			TowerTestData test = new TowerTestData(false)
			{
				TestName = "test",
				TowerSpecifications =
				{
					HotWaterTemperature = 115.70, // EWTt
					ColdWaterTemperature = 84.27, // LWTt
					WetBulbTemperature = 76.18,   // EWBt
					DryBulbTemperature = 77.94,   // EDBt
					BarometricPressure = 29.18,   // BPt
					WaterFlowRate = 57426.0,      // FLOWt
					FanDriverPower = 151.5,       // BHPt
					LiquidToGasRatio = 0.0        // LinGt
				}
			};

			DesignData designData = new DesignData()
			{
				TowerSpecifications = design,
				TowerType = TOWER_TYPE.Induced
			};

			MechanicalDraftPerformanceCurveFileData data = new MechanicalDraftPerformanceCurveFileData(false)
			{
				IsInternationalSystemOfUnits_SI = false,
				DesignData = designData
			};
			data.TestData.Add(test);

			MechanicalDraftPerformanceCurveOutput output = new MechanicalDraftPerformanceCurveOutput();

			try
			{
				CalculationLibrary = new CalculationLibrary.CalculationLibrary();
				CalculationLibrary.DetermineAdjustedTestFlow(0, data, output);
			}
			catch
			{
				methodThrew = true;
			}

			Assert.IsFalse(methodThrew, "Method threw");
			Assert.AreEqual(51028.716619350191, output.AdjustedFlow, "AdjustedFlow value does not match");
			Assert.AreEqual(102.01949119567871, output.ColdWaterTemperatureDeviation, "ColdWaterTemperatureDeviation value does not match");
			Assert.AreEqual(0.067379633634750025, output.Density, "Density value does not match");
			Assert.AreEqual(1.1643467203016293, output.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(15.499719809090942, output.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(73.037664309523052, output.WetBulbTemperature, "WetBulbTemperature value does not match");  //LWBTnew
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

			TowerTestData test = new TowerTestData(false)
			{
				TestName = "test",
				TowerSpecifications =
				{
					HotWaterTemperature = 115.70, // EWTt
					ColdWaterTemperature = 84.27, // LWTt
					WetBulbTemperature = 76.18,   // EWBt
					DryBulbTemperature = 77.94,   // EDBt
					BarometricPressure = 29.18,   // BPt
					WaterFlowRate = 57426.0,      // FLOWt
					FanDriverPower = 151.5,       // BHPt
					LiquidToGasRatio = 0.0        // LinGt
				}
			};

			DesignData designData = new DesignData()
			{
				TowerSpecifications = design,
				TowerType = TOWER_TYPE.Induced
			};

			MechanicalDraftPerformanceCurveFileData data = new MechanicalDraftPerformanceCurveFileData(false)
			{
				IsInternationalSystemOfUnits_SI = false,
				DesignData = designData
			};
			data.TestData.Add(test);

			MechanicalDraftPerformanceCurveOutput output = new MechanicalDraftPerformanceCurveOutput();

			try
			{
				CalculationLibrary = new CalculationLibrary.CalculationLibrary();
				CalculationLibrary.DetermineAdjustedTestFlow(0, data, output);
			}
			catch
			{
				methodThrew = true;
			}

			Assert.IsFalse(methodThrew, "Method threw");
			Assert.AreEqual(0.0, output.AdjustedFlow, "AdjustedFlow value does not match");
			Assert.AreEqual(76.161623001098633, output.ColdWaterTemperatureDeviation, "ColdWaterTemperatureDeviation value does not match");
			Assert.AreEqual(0.067379633634750025, output.Density, "Density value does not match");
			Assert.AreEqual(0.0, output.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(15.499719809090942, output.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(73.037664309523052, output.WetBulbTemperature, "WetBulbTemperature value does not match");  //LWBTnew
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

			TowerTestData test = new TowerTestData(false)
			{
				TestName = "test",
				TowerSpecifications =
				{
					HotWaterTemperature = 115.70, // EWTt
					ColdWaterTemperature = 84.27, // LWTt
					WetBulbTemperature = 76.18,   // EWBt
					DryBulbTemperature = 77.94,   // EDBt
					BarometricPressure = 29.18,   // BPt
					WaterFlowRate = 57426.0,      // FLOWt
					FanDriverPower = 0.0,       // BHPt
					LiquidToGasRatio = 0.0        // LinGt
				}
			};

			DesignData designData = new DesignData()
			{
				TowerSpecifications = design,
				TowerType = TOWER_TYPE.Induced
			};

			MechanicalDraftPerformanceCurveFileData data = new MechanicalDraftPerformanceCurveFileData(false)
			{
				IsInternationalSystemOfUnits_SI = false,
				DesignData = designData
			};
			data.TestData.Add(test);

			MechanicalDraftPerformanceCurveOutput output = new MechanicalDraftPerformanceCurveOutput();

			try
			{
				CalculationLibrary = new CalculationLibrary.CalculationLibrary();
				CalculationLibrary.DetermineAdjustedTestFlow(0, data, output);
			}
			catch
			{
				methodThrew = true;
			}

			Assert.IsFalse(methodThrew, "Method threw");
			Assert.AreEqual(0.0, output.AdjustedFlow, "AdjustedFlow value does not match");
			Assert.AreEqual(76.161623001098633, output.ColdWaterTemperatureDeviation, "ColdWaterTemperatureDeviation value does not match");
			Assert.AreEqual(0.067379633634750025, output.Density, "Density value does not match");
			Assert.AreEqual(0.0, output.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(15.499719809090942, output.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(73.037664309523052, output.WetBulbTemperature, "WetBulbTemperature value does not match");  //LWBTnew
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

			TowerTestData test = new TowerTestData(false)
			{
				TestName = "test",
				TowerSpecifications =
				{
					HotWaterTemperature = 115.70, // EWTt
					ColdWaterTemperature = 84.27, // LWTt
					WetBulbTemperature = 76.18,   // EWBt
					DryBulbTemperature = 77.94,   // EDBt
					BarometricPressure = 29.18,   // BPt
					WaterFlowRate = 57426.0,      // FLOWt
					FanDriverPower = 151.5,       // BHPt
					LiquidToGasRatio = 0.0        // LinGt
				}
			};

			DesignData designData = new DesignData()
			{
				TowerSpecifications = design,
				TowerType = TOWER_TYPE.Forced
			};

			MechanicalDraftPerformanceCurveFileData data = new MechanicalDraftPerformanceCurveFileData(false)
			{
				IsInternationalSystemOfUnits_SI = false,
				DesignData = designData
			};
			data.TestData.Add(test);

			MechanicalDraftPerformanceCurveOutput output = new MechanicalDraftPerformanceCurveOutput();

			try
			{
				CalculationLibrary = new CalculationLibrary.CalculationLibrary();
				CalculationLibrary.DetermineAdjustedTestFlow(0, data, output);
			}
			catch
			{
				methodThrew = true;
			}

			Assert.IsFalse(methodThrew, "Method threw");
			Assert.AreEqual(50977.565031811129, output.AdjustedFlow, "AdjustedFlow value does not match");
			Assert.AreEqual(40.295820974981808, output.ColdWaterTemperatureDeviation, "ColdWaterTemperatureDeviation value does not match");
			Assert.AreEqual(0.071118288489722126, output.Density, "Density value does not match");
			Assert.AreEqual(0.0, output.LiquidToGasRatio, "LiquidToGasRatio value does not match");
			Assert.AreEqual(14.338171292573175, output.SpecificVolume, "SpecificVolume value does not match");
			Assert.AreEqual(76.18, output.WetBulbTemperature, "WetBulbTemperature value does not match");  //LWBTnew
		}
	}
}
