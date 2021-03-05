using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace CalculationLibraryUnitTest
{
    [TestClass]
    public class CalculateTestLiquidToGasRatioUnitTest
    {
        CalculationLibrary.CalculationLibrary CalculationLibrary { get; set; }

        [TestMethod]
        public void CalculateTestLiquidToGasRatioTest()
        {
            bool methodThrew = false;
            double ratio = 0.0;
            MechanicalDraftPerformanceCurveFileData data = new MechanicalDraftPerformanceCurveFileData(true);
            PsychrometricsData designPsychrometricsData = new PsychrometricsData();
            PsychrometricsData testPsychrometricsData = new PsychrometricsData();

            data.DesignData.TowerSpecifications.WaterFlowRate = 3583.0;
            data.DesignData.TowerSpecifications.FanDriverPower = 107.0;
            data.DesignData.TowerSpecifications.LiquidToGasRatio = 1.3;

            data.TestData.Add(new TowerTestData(true));
            data.TestData[0].TowerSpecifications.WaterFlowRate = 3623.0;
            data.TestData[0].TowerSpecifications.FanDriverPower = 113.0;

            designPsychrometricsData.Density = 1.1501296596771431;
            designPsychrometricsData.SpecificVolume = 0.88656371124694966;

            testPsychrometricsData.Density = 1.1390247623025043;
            testPsychrometricsData.SpecificVolume = 0.89522952152485946;

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                ratio = CalculationLibrary.CalculateTestLiquidToGasRatio(0, data, testPsychrometricsData, designPsychrometricsData);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(1.2992315398021315, ratio, "TestLiquidToGasRatio value does not match");
        }

        [TestMethod]
        public void CalculateTestLiquidToGasRatio_DesignWaterFlowRateZeroTest()
        {
            bool methodThrew = false;
            double ratio = 0.0;
            MechanicalDraftPerformanceCurveFileData data = new MechanicalDraftPerformanceCurveFileData(true);
            PsychrometricsData designPsychrometricsData = new PsychrometricsData();
            PsychrometricsData testPsychrometricsData = new PsychrometricsData();

            data.DesignData.TowerSpecifications.WaterFlowRate = 0.0;
            data.DesignData.TowerSpecifications.FanDriverPower = 107.0;
            data.DesignData.TowerSpecifications.LiquidToGasRatio = 1.3;

            data.TestData.Add(new TowerTestData(true));
            data.TestData[0].TowerSpecifications.WaterFlowRate = 3623.0;
            data.TestData[0].TowerSpecifications.FanDriverPower = 113.0;

            designPsychrometricsData.Density = 1.1501296596771431;
            designPsychrometricsData.SpecificVolume = 0.88656371124694966;

            testPsychrometricsData.Density = 1.1390247623025043;
            testPsychrometricsData.SpecificVolume = 0.89522952152485946;

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                ratio = CalculationLibrary.CalculateTestLiquidToGasRatio(0, data, testPsychrometricsData, designPsychrometricsData);
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
            MechanicalDraftPerformanceCurveFileData data = new MechanicalDraftPerformanceCurveFileData(true);
            PsychrometricsData designPsychrometricsData = new PsychrometricsData();
            PsychrometricsData testPsychrometricsData = new PsychrometricsData();

            data.DesignData.TowerSpecifications.WaterFlowRate = 3583.0;
            data.DesignData.TowerSpecifications.FanDriverPower = 107.0;
            data.DesignData.TowerSpecifications.LiquidToGasRatio = 1.3;

            data.TestData.Add(new TowerTestData(true));
            data.TestData[0].TowerSpecifications.WaterFlowRate = 3623.0;
            data.TestData[0].TowerSpecifications.FanDriverPower = 0.0;

            designPsychrometricsData.Density = 1.1501296596771431;
            designPsychrometricsData.SpecificVolume = 0.88656371124694966;

            testPsychrometricsData.Density = 1.1390247623025043;
            testPsychrometricsData.SpecificVolume = 0.89522952152485946;

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                ratio = CalculationLibrary.CalculateTestLiquidToGasRatio(0, data, testPsychrometricsData, designPsychrometricsData);
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
            MechanicalDraftPerformanceCurveFileData data = new MechanicalDraftPerformanceCurveFileData(true);
            PsychrometricsData designPsychrometricsData = new PsychrometricsData();
            PsychrometricsData testPsychrometricsData = new PsychrometricsData();

            data.DesignData.TowerSpecifications.WaterFlowRate = 3583.0;
            data.DesignData.TowerSpecifications.FanDriverPower = 107.0;
            data.DesignData.TowerSpecifications.LiquidToGasRatio = 1.3;

            data.TestData.Add(new TowerTestData(true));
            data.TestData[0].TowerSpecifications.WaterFlowRate = 3623.0;
            data.TestData[0].TowerSpecifications.FanDriverPower = 113.0;

            designPsychrometricsData.Density = 0.0;
            designPsychrometricsData.SpecificVolume = 0.88656371124694966;

            testPsychrometricsData.Density = 1.1390247623025043;
            testPsychrometricsData.SpecificVolume = 0.89522952152485946;

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                ratio = CalculationLibrary.CalculateTestLiquidToGasRatio(0, data, testPsychrometricsData, designPsychrometricsData);
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
            MechanicalDraftPerformanceCurveFileData data = new MechanicalDraftPerformanceCurveFileData(true);
            PsychrometricsData designPsychrometricsData = new PsychrometricsData();
            PsychrometricsData testPsychrometricsData = new PsychrometricsData();

            data.DesignData.TowerSpecifications.WaterFlowRate = 3583.0;
            data.DesignData.TowerSpecifications.FanDriverPower = 107.0;
            data.DesignData.TowerSpecifications.LiquidToGasRatio = 1.3;

            data.TestData.Add(new TowerTestData(true));
            data.TestData[0].TowerSpecifications.WaterFlowRate = 3623.0;
            data.TestData[0].TowerSpecifications.FanDriverPower = 113.0;

            designPsychrometricsData.Density = 1.1501296596771431;
            designPsychrometricsData.SpecificVolume = 0.0;

            testPsychrometricsData.Density = 1.1390247623025043;
            testPsychrometricsData.SpecificVolume = 0.89522952152485946;

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                ratio = CalculationLibrary.CalculateTestLiquidToGasRatio(0, data, testPsychrometricsData, designPsychrometricsData);
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
