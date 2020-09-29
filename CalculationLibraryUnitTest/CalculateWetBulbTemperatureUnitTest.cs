using System;
using CalculationLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace CalculationLibraryUnitTest
{
    [TestClass]
    public class CalculateWetBulbTemperatureUnitTest
    {
        CalculationLibrary.CalculationLibrary CalculationLibrary { get; set; }

        [TestMethod]
        public void SI_CalculateWetBulbTemperatureTest()
        {
            bool methodThrew = false;
            double WetBulbTemperature = 0.0;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                BarometricPressure = 14.56,
                DryBulbTemperature = 30.0,
                RelativeHumidity = 0.24
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                WetBulbTemperature = CalculationLibrary.CalculateWetBulbTemperature(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(-2.4377822875976563, WetBulbTemperature, "WetBulbTemperature value does not match");
        }

        [TestMethod]
        public void IP_CalculateWetBulbTemperatureTest()
        {
            bool methodThrew = false;
            double WetBulbTemperature = 0.0;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = false,
                BarometricPressure = 29.145,
                DryBulbTemperature = 70.0,
                RelativeHumidity = 0.24
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                WetBulbTemperature = CalculationLibrary.CalculateWetBulbTemperature(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(56.616783142089844, WetBulbTemperature, "WetBulbTemperature value does not match");
        }
    }
}
