using System;
using CalculationLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace CalculationLibraryUnitTest
{
    [TestClass]
    public class CalculateTestLiquidToGasRatioUnitTest
    {
        MechanicalDraftPerformanceCurveCalculationLibrary CalculationLibrary { get; set; }

        [TestMethod]
        public void CalculateTestLiquidToGasRatioTest()
        {
            bool methodThrew = false;
            double ratio = 0.0;
            MechanicalDraftPerformanceCurveCalculationData data = new MechanicalDraftPerformanceCurveCalculationData()
            {
                IsInternationalSystemOfUnits_SI = false,
                TowerType = TOWER_TYPE.Induced,
                TowerDesignData = {
                    WaterFlowRate = 3583.0,
                    FanDriverPower = 107.0,
                    LiquidToGasRatio = 1.3
                },
                TowerTestData = {
                    WaterFlowRate = 3623.0,
                    FanDriverPower = 113.0
                }
            };
            PsychrometricsData designPsychrometricsData = new PsychrometricsData();
            PsychrometricsData testPsychrometricsData = new PsychrometricsData();

            designPsychrometricsData.Density = 1.1501296596771431;
            designPsychrometricsData.SpecificVolume = 0.88656371124694966;

            testPsychrometricsData.Density = 1.1390247623025043;
            testPsychrometricsData.SpecificVolume = 0.89522952152485946;

            try
            {
                CalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();
                ratio = CalculationLibrary.CalculateTestLiquidToGasRatio(data.TowerDesignData, data.TowerTestData, designPsychrometricsData, testPsychrometricsData);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(1.2992315398021315, ratio, "TestLiquidToGasRatio value does not match");
        }

        [TestMethod]
        public void CalculateTestLiquidToGasRatioMatchTest()
        {
            bool methodThrew = false;
            double ratio = 0.0;
            MechanicalDraftPerformanceCurveCalculationData data = new MechanicalDraftPerformanceCurveCalculationData()
            {
                IsInternationalSystemOfUnits_SI = false,
                TowerType = TOWER_TYPE.Induced,
                TowerDesignData = {
                    WaterFlowRate = 3583.0,
                    FanDriverPower = 107.0,
                    LiquidToGasRatio = 1.3
                },
                TowerTestData = {
                    WaterFlowRate = 3583.0,
                    FanDriverPower = 107.0
                }
            };
            PsychrometricsData designPsychrometricsData = new PsychrometricsData();
            PsychrometricsData testPsychrometricsData = new PsychrometricsData();

            designPsychrometricsData.Density = 1.15;
            designPsychrometricsData.SpecificVolume = 0.88;

            testPsychrometricsData.Density = 1.15;
            testPsychrometricsData.SpecificVolume = 0.88;

            try
            {
                CalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();
                ratio = CalculationLibrary.CalculateTestLiquidToGasRatio(data.TowerDesignData, data.TowerTestData, designPsychrometricsData, testPsychrometricsData);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(1.3, ratio, "TestLiquidToGasRatio value does not match");
        }

        [TestMethod]
        public void CalculateTestLiquidToGasRatioDesignTest()
        {
            bool methodThrew = false;
            double ratio = 0.0;
            MechanicalDraftPerformanceCurveCalculationData data = new MechanicalDraftPerformanceCurveCalculationData()
            {
                IsInternationalSystemOfUnits_SI = false,
                TowerType = TOWER_TYPE.Induced,
                TowerDesignData = {
                    WaterFlowRate = 3583.0,
                    FanDriverPower = 107.0,
                    LiquidToGasRatio = 1.3
                },
                TowerTestData = {
                    WaterFlowRate = 3623.0,
                    FanDriverPower = 113.0
                }
            };
            PsychrometricsData designPsychrometricsData = new PsychrometricsData();
            PsychrometricsData testPsychrometricsData = new PsychrometricsData();

            designPsychrometricsData.Density = 1.0863388914262087;
            designPsychrometricsData.SpecificVolume = 0.97083769524317687;

            testPsychrometricsData.Density = 1.0962026451105518;
            testPsychrometricsData.SpecificVolume = 0.95696108697698912;

            try
            {
                CalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();
                ratio = CalculationLibrary.CalculateTestLiquidToGasRatio(data.TowerDesignData, data.TowerDesignData, designPsychrometricsData, testPsychrometricsData);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(1.2852851981790823, ratio, "TestLiquidToGasRatio value does not match");
        }

        [TestMethod]
        public void CalculateTestLiquidToGasRatio_DesignWaterFlowRateZeroTest()
        {
            bool methodThrew = false;
            double ratio = 0.0;
            MechanicalDraftPerformanceCurveCalculationData data = new MechanicalDraftPerformanceCurveCalculationData()
            {
                IsInternationalSystemOfUnits_SI = false,
                TowerType = TOWER_TYPE.Induced,
                TowerDesignData = {
                    WaterFlowRate = 0.0,
                    FanDriverPower = 107.0,
                    LiquidToGasRatio = 1.3
                },
                TowerTestData = {
                    WaterFlowRate = 3623.0,
                    FanDriverPower = 113.0
                }
            };
            PsychrometricsData designPsychrometricsData = new PsychrometricsData();
            PsychrometricsData testPsychrometricsData = new PsychrometricsData();

            designPsychrometricsData.Density = 1.1501296596771431;
            designPsychrometricsData.SpecificVolume = 0.88656371124694966;

            testPsychrometricsData.Density = 1.1390247623025043;
            testPsychrometricsData.SpecificVolume = 0.89522952152485946;

            try
            {
                CalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();
                ratio = CalculationLibrary.CalculateTestLiquidToGasRatio(data.TowerDesignData, data.TowerTestData, designPsychrometricsData, testPsychrometricsData);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.0, ratio, "TestLiquidToGasRatio value does not match");
        }

        [TestMethod]
        public void CalculateTestLiquidToGasRatio_TestFanDriverPowerZeroTest()
        {
            bool methodThrew = false;
            double ratio = 0.0;
            MechanicalDraftPerformanceCurveCalculationData data = new MechanicalDraftPerformanceCurveCalculationData()
            {
                IsInternationalSystemOfUnits_SI = false,
                TowerType = TOWER_TYPE.Induced,
                TowerDesignData = {
                    WaterFlowRate = 3583.0,
                    FanDriverPower = 107.0,
                    LiquidToGasRatio = 1.3
                },
                TowerTestData = {
                    WaterFlowRate = 3623.0,
                    FanDriverPower = 0.0
                }
            };
            PsychrometricsData designPsychrometricsData = new PsychrometricsData();
            PsychrometricsData testPsychrometricsData = new PsychrometricsData();

            designPsychrometricsData.Density = 1.1501296596771431;
            designPsychrometricsData.SpecificVolume = 0.88656371124694966;

            testPsychrometricsData.Density = 1.1390247623025043;
            testPsychrometricsData.SpecificVolume = 0.89522952152485946;

            try
            {
                CalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();
                ratio = CalculationLibrary.CalculateTestLiquidToGasRatio(data.TowerDesignData, data.TowerTestData, designPsychrometricsData, testPsychrometricsData);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.0, ratio, "TestLiquidToGasRatio value does not match");
        }

        [TestMethod]
        public void CalculateTestLiquidToGasRatio_DesignDensityZeroTest()
        {
            bool methodThrew = false;
            double ratio = 0.0;
            MechanicalDraftPerformanceCurveCalculationData data = new MechanicalDraftPerformanceCurveCalculationData()
            {
                IsInternationalSystemOfUnits_SI = false,
                TowerType = TOWER_TYPE.Induced,
                TowerDesignData = {
                    WaterFlowRate = 3583.0,
                    FanDriverPower = 107.0,
                    LiquidToGasRatio = 1.3
                },
                TowerTestData = {
                    WaterFlowRate = 3623.0,
                    FanDriverPower = 113.0
                }
            };
            PsychrometricsData designPsychrometricsData = new PsychrometricsData();
            PsychrometricsData testPsychrometricsData = new PsychrometricsData();

            designPsychrometricsData.Density = 0.0;
            designPsychrometricsData.SpecificVolume = 0.88656371124694966;

            testPsychrometricsData.Density = 1.1390247623025043;
            testPsychrometricsData.SpecificVolume = 0.89522952152485946;

            try
            {
                CalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();
                ratio = CalculationLibrary.CalculateTestLiquidToGasRatio(data.TowerDesignData, data.TowerTestData, designPsychrometricsData, testPsychrometricsData);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.0, ratio, "TestLiquidToGasRatio value does not match");
        }

        [TestMethod]
        public void CalculateTestLiquidToGasRatio_DesignSpecificVolumeZeroTest()
        {
            bool methodThrew = false;
            double ratio = 0.0;

            MechanicalDraftPerformanceCurveCalculationData data = new MechanicalDraftPerformanceCurveCalculationData()
            {
                IsInternationalSystemOfUnits_SI = false,
                TowerType = TOWER_TYPE.Induced,
                TowerDesignData = {
                    WaterFlowRate = 3583.0,
                    FanDriverPower = 107.0,
                    LiquidToGasRatio = 1.3
                },
                TowerTestData = {
                    WaterFlowRate = 3623.0,
                    FanDriverPower = 113.0
                }
            };

            PsychrometricsData designPsychrometricsData = new PsychrometricsData();
            PsychrometricsData testPsychrometricsData = new PsychrometricsData();

            designPsychrometricsData.Density = 1.1501296596771431;
            designPsychrometricsData.SpecificVolume = 0.0;

            testPsychrometricsData.Density = 1.1390247623025043;
            testPsychrometricsData.SpecificVolume = 0.89522952152485946;

            try
            {
                CalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();
                ratio = CalculationLibrary.CalculateTestLiquidToGasRatio(data.TowerDesignData, data.TowerTestData, designPsychrometricsData, testPsychrometricsData);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.0, ratio, "TestLiquidToGasRatio value does not match");
        }
    }
}
