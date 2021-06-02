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

        MechanicalDraftPerformanceCurveCalculationData data = new MechanicalDraftPerformanceCurveCalculationData()
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
				CalculationLibrary.MechanicalDraftPerformanceCurveCalculation(data, false);
			}
			catch
			{
				methodThrew = true;
			}

			Assert.IsFalse(methodThrew, "Method threw");
			Assert.AreEqual(3393.1144762761005, data.TestOutput.PredictedFlow, "PredictedFlow value does not match"); // 
			Assert.AreEqual(3549.8089648534847, data.TestOutput.AdjustedFlow, "AdjustedFlow value does not match");
			Assert.AreEqual(104.61801361766474, data.TestOutput.TowerCapability, "TowerCapability value does not match");
		}

		[TestMethod]
		public void SI_MechanicalDraftPerformanceCurveCalculationWithDeviationTest()
		{
			bool methodThrew = false;
			try
			{
				CalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();
                CalculationLibrary.MechanicalDraftPerformanceCurveCalculation(data, true);
			}
			catch
			{
				methodThrew = true;
			}

			Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(3393.1144762761005, data.TestOutput.PredictedFlow, "PredictedFlow value does not match"); // 
            Assert.AreEqual(3549.8089648534847, data.TestOutput.AdjustedFlow, "AdjustedFlow value does not match");
            Assert.AreEqual(104.61801361766474, data.TestOutput.TowerCapability, "TowerCapability value does not match");
            Assert.AreEqual(-0.29998321047046517, data.TestOutput.ColdWaterTemperatureDeviation, "ColdWaterTemperatureDeviation value does not match");
        }

        [TestMethod]
		public void InterpolateRangeTest()
		{
			bool methodThrew = false;

			try
			{
				CalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();
                data.WaterFlowRates[0].Yfit.Add(28.610197818305455);
                data.WaterFlowRates[0].Yfit.Add(28.837822802290912);
                data.WaterFlowRates[0].Yfit.Add(29.065447786276366);
                data.WaterFlowRates[1].Yfit.Add(29.402326944181819);
                data.WaterFlowRates[1].Yfit.Add(29.629951928167277);
                data.WaterFlowRates[1].Yfit.Add(29.857576912152730);
                data.WaterFlowRates[2].Yfit.Add(30.218820826800002);
                data.WaterFlowRates[2].Yfit.Add(30.475899732996364);
                data.WaterFlowRates[2].Yfit.Add(30.733892780305457);
                CalculationLibrary.InterpolateRange(data);
			}
			catch
			{
				methodThrew = true;
			}

			Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(28.670592947284472, data.InterpolateRanges[0], "WetBulbTemperatureRange[0] value does not match"); // 
            Assert.AreEqual(29.462722073160837, data.InterpolateRanges[1], "WetBulbTemperatureRange[1] value does not match");
            Assert.AreEqual(30.286990688774534, data.InterpolateRanges[2], "WetBulbTemperatureRange[3] value does not match");
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
				CalculationLibrary.InterpolateWetBulbTemperature(data);
			}
			catch
			{
				methodThrew = true;
			}

			Assert.IsFalse(methodThrew, "Method threw");
			int x = 0;
			foreach(WaterFlowRate waterFlowRate in data.WaterFlowRates)
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
                data.TestOutput.TowerCapability = 104.64646026826094;
                data.TestOutput.AdjustedFlow = 3549.8089648534847;
                data.TestOutput.PredictedFlow = 3392.1921064062349;
                CalculationLibrary.CalculateColdWaterTemperatureDeviation(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(-0.30185874617716379, data.TestOutput.ColdWaterTemperatureDeviation, "ColdWaterTemperatureDeviation value does not match"); // 
        }
    }
}