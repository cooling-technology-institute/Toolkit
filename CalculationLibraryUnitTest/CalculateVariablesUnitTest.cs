using System;
using CalculationLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace CalculationLibraryUnitTest
{
    [TestClass]
    public class CalculateVariablesUnitTest
    {
        CalculationLibrary.CalculationLibrary CalculationLibrary { get; set; }

        [TestMethod]
        public void SI_CalculateVariablesTest()
        {
            bool methodThrew = false;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                DryBulbTemperature = 13,
                WetBulbTemperature = 40,
                PressurePSI = 14.56
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.CalculateVariables(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(1.4978108118095652, data.SaturationVaporPressureDryBulb, "SaturationVaporPressureDryBulb value does not match");
            Assert.AreEqual(7.3834598538015586, data.SaturationVaporPressureWetBulb, "SaturationVaporPressureWetBulb value does not match");
            Assert.AreEqual(1.0012003737919406, data.FsDryBulb, "FsDryBulb value does not match");
            Assert.AreEqual(1.0016780922074051, data.FsWetBulb, "FsWetBulb value does not match");
            Assert.AreEqual(0.071416439887867028, data.WsDryBulb, "WsDryBulb value does not match");
            Assert.AreEqual(0.64209581848919040, data.WsWetBulb, "WsWetBulb value does not match");
        }

        [TestMethod]
        public void IP_CalculateVariablesTest()
        {
            bool methodThrew = false;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = false,
                DryBulbTemperature = 70.0,
                WetBulbTemperature = 90.0,
                PressurePSI = 29.145
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.CalculateVariables(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.36327716067983784, data.SaturationVaporPressureDryBulb, "SaturationVaporPressureDryBulb value does not match");
            Assert.AreEqual(0.69888797756930821, data.SaturationVaporPressureWetBulb, "SaturationVaporPressureWetBulb value does not match");
            Assert.AreEqual(1.0072761896919915, data.FsDryBulb, "FsDryBulb value does not match");
            Assert.AreEqual(1.0084514220198235, data.FsWetBulb, "FsWetBulb value does not match");
            Assert.AreEqual(0.0079083554826944250, data.WsDryBulb, "WsDryBulb value does not match");
            Assert.AreEqual(0.015413676627438729, data.WsWetBulb, "WsWetBulb value does not match");
        }
    }
}
