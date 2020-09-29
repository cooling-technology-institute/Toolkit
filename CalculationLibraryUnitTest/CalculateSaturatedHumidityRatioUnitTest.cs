using System;
using CalculationLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace CalculationLibraryUnitTest
{
    [TestClass]
    public class CalculateSaturatedHumidityRatioUnitTest
    {
        CalculationLibrary.CalculationLibrary CalculationLibrary { get; set; }

        [TestMethod]
        public void CalculateSaturatedHumidityRatioTest()
        {
            bool methodThrew = false;
            double ratio = 0.0;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                BarometricPressure = 14.56,
                SaturationVaporPressureDryBulb = 3.4,
                FsDryBulb = 2.1,
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                ratio = CalculationLibrary.CalculateSaturatedHumidityRatio(data.BarometricPressure, data.SaturationVaporPressureDryBulb, data.FsDryBulb);
            }
            catch
            {
                methodThrew = true;
            }

            double expected = 0.62198 * data.SaturationVaporPressureDryBulb * data.FsDryBulb / (data.BarometricPressure - data.SaturationVaporPressureDryBulb * data.FsDryBulb);

            Assert.IsFalse(methodThrew, "Method threw");
            // 9.3371669670174899
            Assert.AreEqual(expected, ratio, "SaturatedHumidityRatio value does not match");
        }

        [TestMethod]
        public void CalculateSaturatedHumidityRatio_ZeroTest()
        {
            bool methodThrew = false;
            double ratio = 0.0;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                BarometricPressure = 14.56,
                SaturationVaporPressureDryBulb = 14.56,
                FsDryBulb = 1,
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                ratio = CalculationLibrary.CalculateSaturatedHumidityRatio(data.BarometricPressure, data.SaturationVaporPressureDryBulb, data.FsDryBulb);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.0, ratio, "SaturatedHumidityRatio value does not match");
        }
    }
}
