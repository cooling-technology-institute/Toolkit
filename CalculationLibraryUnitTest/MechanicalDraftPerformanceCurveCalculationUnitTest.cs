// Copyright Cooling Technology Institute 2019-2021

using CalculationLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System;
using System.Collections.Generic;

namespace CalculationLibraryUnitTest
{
	[TestClass]
	public class MechanicalDraftPerformanceCurveCalculationUnitTest
	{
		MechanicalDraftPerformanceCurveCalculationLibrary CalculationLibrary { get; set; }

        MechanicalDraftPerformanceCurveCalculationData dataIP = new MechanicalDraftPerformanceCurveCalculationData()
        {
            IsInternationalSystemOfUnits_SI = false,
            TowerType = TOWER_TYPE.Induced,
            TowerTestData = {
                IsInternationalSystemOfUnits_SI = false,
                WaterFlowRate = 57426.0,
                ColdWaterTemperature = 84.27,
                HotWaterTemperature = 115.7,
                WetBulbTemperature = 76.18,
                DryBulbTemperature = 77.94,
                FanDriverPower = 151.5,
                BarometricPressure = 29.18,
                LiquidToGasRatio = 0.0
            },
            TowerDesignData = {
                IsInternationalSystemOfUnits_SI = false,
                WaterFlowRate = 56792.0,
                ColdWaterTemperature = 87.08,
                HotWaterTemperature = 120.92,
                WetBulbTemperature = 78.8,
                DryBulbTemperature = 86.36,
                FanDriverPower = 143.4,
                BarometricPressure = 29.921,
                LiquidToGasRatio = 1.3
            },
            Ranges = new List<double>()
            {
                27.07,  33.84, 40.61
            },
            InterpolateRanges = new List<double>(),
            WaterFlowRates = new List<WaterFlowRate>()
            {
                new WaterFlowRate()
                {
                    FlowRate = 51112.8,
                    WetBulbTemperatures = new List<WetBulbTemperature>()
                    {
                        new WetBulbTemperature()
                        {
                            Temperature = 40.0001,
                            ColdWaterTemperatures = new List<double>()
                            {
                                62.3601,
                                64.9501,
                                67.0699,
                            },
                        },
                        new WetBulbTemperature()
                        {
                            Temperature = 50.0,
                            ColdWaterTemperatures = new List<double>()
                            {
                                67.2201,
                                69.3199,
                                71.0901,
                            },
                        },
                        new WetBulbTemperature()
                        {
                            Temperature = 60.0001,
                            ColdWaterTemperatures = new List<double>()
                            {
                                  72.63,
                                  74.2901,
                                  75.72,
                            },
                        },
                        new WetBulbTemperature()
                        {
                            Temperature = 70.0,
                            ColdWaterTemperatures = new List<double>()
                            {
                                78.7201,
                                79.9801,
                                81.1099,
                            },
                        },
                        new WetBulbTemperature()
                        {
                            Temperature = 80.0001,
                            ColdWaterTemperatures = new List<double>()
                            {
                                85.66,
                                86.5701,
                                87.42,
                            },
                        },
                        new WetBulbTemperature()
                        {
                            Temperature = 90.0,
                            ColdWaterTemperatures = new List<double>()
                            {
                                  93.6801,
                                  94.3,
                                  94.9201,
                            },
                        },
                    },
                },
                new WaterFlowRate()
                {
                    FlowRate = 56792.0,
                    WetBulbTemperatures = new List<WetBulbTemperature>()
                    {
                        new WetBulbTemperature()
                        {
                            Temperature = 40.0001,
                            ColdWaterTemperatures = new List<double>()
                            {
                                64.9099,
                                67.7401,
                                70.0601
                            },
                        },
                        new WetBulbTemperature()
                        {
                            Temperature = 50.0,
                            ColdWaterTemperatures = new List<double>()
                            {
                                69.4301,
                                71.76,
                                73.72,
                            },
                        },
                        new WetBulbTemperature()
                        {
                            Temperature = 60.0001,
                            ColdWaterTemperatures = new List<double>()
                            {
                                74.48,
                                76.3601,
                                77.9801,
                            },
                        },
                        new WetBulbTemperature()
                        {
                            Temperature = 70.0,
                            ColdWaterTemperatures = new List<double>()
                            {
                                80.2099,
                                81.6701,
                                82.98,
                            },
                        },
                        new WetBulbTemperature()
                        {
                            Temperature = 80.0001,
                            ColdWaterTemperatures = new List<double>()
                            {
                                86.7799,
                                87.8801,
                                88.8901,
                            },
                        },
                        new WetBulbTemperature()
                        {
                            Temperature = 90.0,
                            ColdWaterTemperatures = new List<double>()
                            {
                                94.4501,
                                95.2101,
                                95.9801,
                            },
                        },
                    },
                },
                new WaterFlowRate()
                {
                    FlowRate = 62471.2,
                    WetBulbTemperatures = new List<WetBulbTemperature>()
                    {
                        new WetBulbTemperature()
                        {
                            Temperature = 40.0001,
                            ColdWaterTemperatures = new List<double>()
                            {
                                67.75,
                                70.81,
                                73.29,
                            },
                        },
                        new WetBulbTemperature()
                        {
                            Temperature = 50.0,
                            ColdWaterTemperatures = new List<double>()
                            {
                                71.9501,
                                74.5101,
                                76.6301,
                            },
                        },
                        new WetBulbTemperature()
                        {
                            Temperature = 60.0001,
                            ColdWaterTemperatures = new List<double>()
                            {
                                76.6999,
                                78.78,
                                80.5699,
                            },
                        },
                        new WetBulbTemperature()
                        {
                            Temperature = 70.0,
                            ColdWaterTemperatures = new List<double>()
                            {
                                82.08,
                                83.7401,
                                85.24,
                            },
                        },
                        new WetBulbTemperature()
                        {
                            Temperature = 80.0001,
                            ColdWaterTemperatures = new List<double>()
                            {
                                88.3301,
                                89.6101,
                                90.79,
                            },
                        },
                        new WetBulbTemperature()
                        {
                            Temperature = 90.0,
                            ColdWaterTemperatures = new List<double>()
                            {
                                95.67,
                                96.6,
                                97.52,
                            },
                        },
                    }
                }
            }
        };

        MechanicalDraftPerformanceCurveCalculationData dataSI = new MechanicalDraftPerformanceCurveCalculationData()
        {
            IsInternationalSystemOfUnits_SI = true,
            TowerType = TOWER_TYPE.Induced,
            TowerTestData = {
                IsInternationalSystemOfUnits_SI = true,
                WaterFlowRate = 3623.0,
                ColdWaterTemperature = 29.04,
                HotWaterTemperature = 46.5,
                WetBulbTemperature = 24.53,
                DryBulbTemperature = 25.52,
                FanDriverPower = 113.0,
                BarometricPressure = 98.8,
                LiquidToGasRatio = 0.0
            },
            TowerDesignData = {
                IsInternationalSystemOfUnits_SI = true,
                WaterFlowRate = 3583.0,
                ColdWaterTemperature = 30.56,
                HotWaterTemperature = 49.36,
                WetBulbTemperature = 26.0,
                DryBulbTemperature = 30.2,
                FanDriverPower = 107.0,
                BarometricPressure = 101.325,
                LiquidToGasRatio = 1.3
            },
            Ranges = new List<double>()
            {
                17.0, 18.8, 21.0
            },
            InterpolateRanges = new List<double>(),
            WaterFlowRates = new List<WaterFlowRate>()
            {
                new WaterFlowRate()
                {
                    FlowRate = 3225.0,
                    WetBulbTemperatures = new List<WetBulbTemperature>()
                    {
                        new WetBulbTemperature()
                        {
                            Temperature = 5.0,
                            ColdWaterTemperatures = new List<double>()
                            {
                                18.0,
                                18.55,
                                19.1
                            }
                        },
                        new WetBulbTemperature()
                        {
                            Temperature = 10.0,
                            ColdWaterTemperatures = new List<double>()
                            {
                                20.38,
                                20.8,
                                21.22
                            }
                        },
                        new WetBulbTemperature()
                        {
                            Temperature = 15.0,
                            ColdWaterTemperatures = new List<double>()
                            {
                                23.05,
                                23.4,
                                23.75
                            }
                        },
                        new WetBulbTemperature()
                        {
                            Temperature = 20.0,
                            ColdWaterTemperatures = new List<double>()
                            {
                                25.8,
                                26.1,
                                26.4
                            }
                        },
                        new WetBulbTemperature()
                        {
                            Temperature = 25.0,
                            ColdWaterTemperatures = new List<double>()
                            {
                                28.93,
                                29.15,
                                29.37
                            }
                        },
                        new WetBulbTemperature()
                        {
                            Temperature = 30.0,
                            ColdWaterTemperatures = new List<double>()
                            {
                                32.6,
                                32.75,
                                32.9
                            }
                        }
                    }
                },
                new WaterFlowRate()
                {
                    FlowRate = 3583.0,
                    WetBulbTemperatures = new List<WetBulbTemperature>()
                    {
                        new WetBulbTemperature()
                        {
                            Temperature = 5.0,
                            ColdWaterTemperatures = new List<double>()
                            {
                                19.45,
                                20.0,
                                20.55
                            }
                        },
                        new WetBulbTemperature()
                        {
                            Temperature = 10.0,
                            ColdWaterTemperatures = new List<double>()
                            {
                                21.73,
                                22.15,
                                22.57
                            }
                        },
                        new WetBulbTemperature()
                        {
                            Temperature = 15.0,
                            ColdWaterTemperatures = new List<double>()
                            {
                                24.15,
                                24.5,
                                24.85
                            }
                        },
                        new WetBulbTemperature()
                        {
                            Temperature = 20.0,
                            ColdWaterTemperatures = new List<double>()
                            {
                                26.8,
                                27.1,
                                27.4
                            }
                        },
                        new WetBulbTemperature()
                        {
                            Temperature = 25.0,
                            ColdWaterTemperatures = new List<double>()
                            {
                                29.7,
                                29.92,
                                30.14
                            }
                        },
                        new WetBulbTemperature()
                        {
                            Temperature = 30.0,
                            ColdWaterTemperatures = new List<double>()
                            {
                                33.2,
                                33.35,
                                33.5
                            }
                        }
                    },
                },
                new WaterFlowRate()
                {
                    FlowRate = 3942.0,
                    WetBulbTemperatures = new List<WetBulbTemperature>()
                    {
                        new WetBulbTemperature()
                        {
                            Temperature = 5.0,
                            ColdWaterTemperatures = new List<double>()
                            {
                                20.84,
                                21.42,
                                22.0
                             }
                        },
                        new WetBulbTemperature()
                        {
                            Temperature = 10.0,
                            ColdWaterTemperatures = new List<double>()
                            {
                                22.95,
                                23.4,
                                23.85
                            }
                        },
                        new WetBulbTemperature()
                        {
                            Temperature = 15.0,
                            ColdWaterTemperatures = new List<double>()
                            {
                                25.22,
                                25.6,
                                25.98
                            }
                        },
                        new WetBulbTemperature()
                        {
                            Temperature = 20.0,
                            ColdWaterTemperatures = new List<double>()
                            {
                                27.75,
                                28.07,
                                28.4
                            }
                        },
                        new WetBulbTemperature()
                        {
                            Temperature = 25.0,
                            ColdWaterTemperatures = new List<double>()
                            {
                                30.5,
                                30.75,
                                31.0
                            }
                        },
                        new WetBulbTemperature()
                        {
                            Temperature = 30.0,
                            ColdWaterTemperatures = new List<double>()
                            {
                                33.8,
                                33.97,
                                34.14
                            }
                        }
                    }
                }
            }
        };

		[TestMethod]
		public void SI_MechanicalDraftPerformanceCurveCalculationTest()
		{
			bool methodThrew = false;

			try
			{
				CalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();
				CalculationLibrary.MechanicalDraftPerformanceCurveCalculation(dataSI, false);
			}
			catch
			{
				methodThrew = true;
			}

			Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(3393.1144762761005, dataSI.TestOutput.PredictedFlow, "PredictedFlow value does not match"); // 
            Assert.AreEqual(3536.9646313759695, dataSI.TestOutput.AdjustedFlow, "AdjustedFlow value does not match");
            Assert.AreEqual(104.23947249954686, dataSI.TestOutput.TowerCapability, "TowerCapability value does not match");
        }

        [TestMethod]
		public void SI_MechanicalDraftPerformanceCurveCalculationWithDeviationTest()
		{
			bool methodThrew = false;
			try
			{
				CalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();
                CalculationLibrary.MechanicalDraftPerformanceCurveCalculation(dataSI, true);
			}
			catch
			{
				methodThrew = true;
			}

			Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(3393.1144762761005, dataSI.TestOutput.PredictedFlow, "PredictedFlow value does not match"); // 
            Assert.AreEqual(3536.9646313759695, dataSI.TestOutput.AdjustedFlow, "AdjustedFlow value does not match");
            Assert.AreEqual(104.23947249954686, dataSI.TestOutput.TowerCapability, "TowerCapability value does not match");
            Assert.AreEqual(-0.29901049483711972, dataSI.TestOutput.ColdWaterTemperatureDeviation, "ColdWaterTemperatureDeviation value does not match");
        }

        [TestMethod]
        public void IP_MechanicalDraftPerformanceCurveCalculationTest()
        {
            bool methodThrew = false;

            try
            {
                CalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();
                CalculationLibrary.MechanicalDraftPerformanceCurveCalculation(dataIP, false);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(54152.265653743343, dataIP.TestOutput.PredictedFlow, "PredictedFlow value does not match"); // 
            Assert.AreEqual(56057.403948435858, dataIP.TestOutput.AdjustedFlow, "AdjustedFlow value does not match");
            Assert.AreEqual(103.51811373299545, dataIP.TestOutput.TowerCapability, "TowerCapability value does not match");
        }

        [TestMethod]
        public void IP_MechanicalDraftPerformanceCurveCalculationWithDeviationTest()
        {
            bool methodThrew = false;
            try
            {
                CalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();
                CalculationLibrary.MechanicalDraftPerformanceCurveCalculation(dataIP, true);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(54152.265653743343, dataIP.TestOutput.PredictedFlow, "PredictedFlow value does not match"); // 
            Assert.AreEqual(56057.403948435858, dataIP.TestOutput.AdjustedFlow, "AdjustedFlow value does not match");
            Assert.AreEqual(103.51811373299545, dataIP.TestOutput.TowerCapability, "TowerCapability value does not match");
            Assert.AreEqual(-0.49673537057178407, dataIP.TestOutput.ColdWaterTemperatureDeviation, "ColdWaterTemperatureDeviation value does not match");
        }

        [TestMethod]
		public void InterpolateRangeTest()
		{
			bool methodThrew = false;

			try
			{
				CalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();
                dataSI.WaterFlowRates[0].Yfit.Add(28.610197818305455);
                dataSI.WaterFlowRates[0].Yfit.Add(28.837822802290912);
                dataSI.WaterFlowRates[0].Yfit.Add(29.065447786276366);
                dataSI.WaterFlowRates[1].Yfit.Add(29.402326944181819);
                dataSI.WaterFlowRates[1].Yfit.Add(29.629951928167277);
                dataSI.WaterFlowRates[1].Yfit.Add(29.857576912152730);
                dataSI.WaterFlowRates[2].Yfit.Add(30.218820826800002);
                dataSI.WaterFlowRates[2].Yfit.Add(30.475899732996364);
                dataSI.WaterFlowRates[2].Yfit.Add(30.733892780305457);
                CalculationLibrary.InterpolateRange(dataSI);
			}
			catch
			{
				methodThrew = true;
			}

			Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(28.670592947284472, dataSI.InterpolateRanges[0], "WetBulbTemperatureRange[0] value does not match"); // 
            Assert.AreEqual(29.462722073160837, dataSI.InterpolateRanges[1], "WetBulbTemperatureRange[1] value does not match");
            Assert.AreEqual(30.286990688774534, dataSI.InterpolateRanges[2], "WetBulbTemperatureRange[3] value does not match");
        }

        [TestMethod]
		public void InterpolateWetBulbTemperatureTest()
		{
			bool methodThrew = false;
			List<double> yfit = new List<double>()
			{
                    28.610197818305455,
                    28.837822802290912,
                    29.065447786276366,
                    29.402326944181819,
                    29.629951928167277,
                    29.857576912152730,
                    30.218820826800002, 
                    30.475899732996364, 
                    30.733892780305457
            };

			try
			{
				CalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();
				CalculationLibrary.InterpolateWetBulbTemperature(dataSI);
			}
			catch
			{
				methodThrew = true;
			}

			Assert.IsFalse(methodThrew, "Method threw");
			int x = 0;
			foreach(WaterFlowRate waterFlowRate in dataSI.WaterFlowRates)
            {
				Assert.AreEqual(yfit[x++], waterFlowRate.Yfit[0], string.Format("WaterFlowRate {0} Yfit[0] value does not match", waterFlowRate.FlowRate)); // 
				Assert.AreEqual(yfit[x++], waterFlowRate.Yfit[1], string.Format("WaterFlowRate {0} Yfit[1] value does not match", waterFlowRate.FlowRate)); // 
				Assert.AreEqual(yfit[x++], waterFlowRate.Yfit[2], string.Format("WaterFlowRate {0} Yfit[2] value does not match", waterFlowRate.FlowRate)); // 
			}
		}

        [TestMethod]
        public void CalculateColdWaterTemperatureDeviationTest()
        {
            bool methodThrew = false;

            try
            {
                CalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();
                dataSI.TestOutput.TowerCapability = 104.23989369362691;
                dataSI.TestOutput.AdjustedFlow = 3536.9789229732728;
                dataSI.TestOutput.PredictedFlow = 3393.1144762761005;
                CalculationLibrary.CalculateColdWaterTemperatureDeviation(dataSI);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(-0.29903869175254272, dataSI.TestOutput.ColdWaterTemperatureDeviation, "ColdWaterTemperatureDeviation value does not match"); // 
        }
    }
}