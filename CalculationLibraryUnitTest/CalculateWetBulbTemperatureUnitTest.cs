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
                DryBulbTemperature = 100.0,
                RelativeHumidity = 42.38,
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.CalculateProperties(data);
                WetBulbTemperature = CalculationLibrary.CalculateWetBulbTemperature(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(1.5576363962243127, WetBulbTemperature, "WetBulbTemperature value does not match");
        }

        [TestMethod]
        public void IP_CalculateWetBulbTemperatureTest()
        {
            bool methodThrew = false;
            double WetBulbTemperature = 0.0;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = false,
                DryBulbTemperature = 100.0,
                RelativeHumidity = 42.38,
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.CalculateProperties(data);
                WetBulbTemperature = CalculationLibrary.CalculateWetBulbTemperature(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(2.1200361989715248, WetBulbTemperature, "WetBulbTemperature value does not match");
        }
    }
}
