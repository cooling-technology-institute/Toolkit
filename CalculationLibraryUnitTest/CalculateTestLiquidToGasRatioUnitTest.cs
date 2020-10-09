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

            data.DesignData.MechanicalDraftPerformanceCurveData.WaterFlowRate = 3583.0;
            data.DesignData.MechanicalDraftPerformanceCurveData.FanDriverPower = 107.0;
            data.DesignData.MechanicalDraftPerformanceCurveData.LiquidToGasRatio = 1.3;

            data.TestData.WaterFlowRate = 3623.0;
            data.TestData.FanDriverPower = 113.0;

            designPsychrometricsData.Density = 1.1501296596771431;
            designPsychrometricsData.SpecificVolume = 0.88656371124694966;

            testPsychrometricsData.Density = 1.1390247623025043;
            testPsychrometricsData.SpecificVolume = 0.89522952152485946;

            /*
            dblDesignAirDensity 1.1501296596771431  double
            dblDesignFanPower   107.00000000000000  double
            dblDesignFlow   3583.0000000000000  double
            dblDesignLG 1.3000000000000000  double
            dblDesignSpecificVolume 0.88656371124694966 double
            dblReturn   1.2825112012708488  double
            dblTestAirDensity   1.1390247623025043  double
            dblTestFanPower 113.00000000000000  double
            dblTestFlow 3623.0000000000000  double
            dblTestSpecificVolume   0.89522952152485946 double
            */

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                ratio = CalculationLibrary.CalculateTestLiquidToGasRatio(data, testPsychrometricsData, designPsychrometricsData);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(1.2825112012708488, ratio, "TestLiquidToGasRatio value does not match");
        }

        [TestMethod]
        public void CalculateTestLiquidToGasRatio_DesignWaterFlowRateZeroTest()
        {
            bool methodThrew = false;
            double ratio = 0.0;
            MechanicalDraftPerformanceCurveFileData data = new MechanicalDraftPerformanceCurveFileData(true);
            PsychrometricsData designPsychrometricsData = new PsychrometricsData();
            PsychrometricsData testPsychrometricsData = new PsychrometricsData();

            data.DesignData.MechanicalDraftPerformanceCurveData.WaterFlowRate = 0.0;
            data.DesignData.MechanicalDraftPerformanceCurveData.FanDriverPower = 107.0;
            data.DesignData.MechanicalDraftPerformanceCurveData.LiquidToGasRatio = 1.3;

            data.TestData.WaterFlowRate = 3623.0;
            data.TestData.FanDriverPower = 113.0;

            designPsychrometricsData.Density = 1.1501296596771431;
            designPsychrometricsData.SpecificVolume = 0.88656371124694966;

            testPsychrometricsData.Density = 1.1390247623025043;
            testPsychrometricsData.SpecificVolume = 0.89522952152485946;

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                ratio = CalculationLibrary.CalculateTestLiquidToGasRatio(data, testPsychrometricsData, designPsychrometricsData);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.0, ratio, "TestLiquidToGasRatio value does not match");
        }

        [TestMethod]
        public void CalculateTestLiquidToGasRatio_DesignFanDriverPowerZeroTest()
        {
            bool methodThrew = false;
            double ratio = 0.0;
            MechanicalDraftPerformanceCurveFileData data = new MechanicalDraftPerformanceCurveFileData(true);
            PsychrometricsData designPsychrometricsData = new PsychrometricsData();
            PsychrometricsData testPsychrometricsData = new PsychrometricsData();

            data.DesignData.MechanicalDraftPerformanceCurveData.WaterFlowRate = 3583.0;
            data.DesignData.MechanicalDraftPerformanceCurveData.FanDriverPower = 0.0;
            data.DesignData.MechanicalDraftPerformanceCurveData.LiquidToGasRatio = 1.3;

            data.TestData.WaterFlowRate = 3623.0;
            data.TestData.FanDriverPower = 113.0;

            designPsychrometricsData.Density = 1.1501296596771431;
            designPsychrometricsData.SpecificVolume = 0.88656371124694966;

            testPsychrometricsData.Density = 1.1390247623025043;
            testPsychrometricsData.SpecificVolume = 0.89522952152485946;

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                ratio = CalculationLibrary.CalculateTestLiquidToGasRatio(data, testPsychrometricsData, designPsychrometricsData);
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

            data.DesignData.MechanicalDraftPerformanceCurveData.WaterFlowRate = 3583.0;
            data.DesignData.MechanicalDraftPerformanceCurveData.FanDriverPower = 107.0;
            data.DesignData.MechanicalDraftPerformanceCurveData.LiquidToGasRatio = 1.3;

            data.TestData.WaterFlowRate = 3623.0;
            data.TestData.FanDriverPower = 113.0;

            designPsychrometricsData.Density = 0.0;
            designPsychrometricsData.SpecificVolume = 0.88656371124694966;

            testPsychrometricsData.Density = 1.1390247623025043;
            testPsychrometricsData.SpecificVolume = 0.89522952152485946;

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                ratio = CalculationLibrary.CalculateTestLiquidToGasRatio(data, testPsychrometricsData, designPsychrometricsData);
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

            data.DesignData.MechanicalDraftPerformanceCurveData.WaterFlowRate = 3583.0;
            data.DesignData.MechanicalDraftPerformanceCurveData.FanDriverPower = 107.0;
            data.DesignData.MechanicalDraftPerformanceCurveData.LiquidToGasRatio = 1.3;

            data.TestData.WaterFlowRate = 3623.0;
            data.TestData.FanDriverPower = 113.0;

            designPsychrometricsData.Density = 1.1501296596771431;
            designPsychrometricsData.SpecificVolume = 0.0;

            testPsychrometricsData.Density = 1.1390247623025043;
            testPsychrometricsData.SpecificVolume = 0.89522952152485946;

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                ratio = CalculationLibrary.CalculateTestLiquidToGasRatio(data, testPsychrometricsData, designPsychrometricsData);
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
