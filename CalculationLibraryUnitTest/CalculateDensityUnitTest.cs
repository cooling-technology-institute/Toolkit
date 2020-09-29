using System;
using CalculationLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace CalculationLibraryUnitTest
{
    [TestClass]
    public class CalculateDensityUnitTest
    {
        CalculationLibrary.CalculationLibrary CalculationLibrary { get; set; }

        [TestMethod]
        public void SI_CalculateDensityTest()
        {
            bool methodThrew = false;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                DryBulbTemperature = 13,
                WetBulbTemperature = 40,
                BarometricPressure = 14.56
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.CalculateVariables(data);
                data.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(data);
                data.DegreeOfSaturation = CalculationLibrary.CalculateDegreeOfSaturation(data);
                data.RelativeHumidity = CalculationLibrary.CalculateRelativeHumidity(data);
                CalculationLibrary.CalculateSpecificVolume(data);
                CalculationLibrary.CalculateDensity(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.14258609761478092, data.Density, "Density value does not match");
        }

        [TestMethod]
        public void IP_CalculateDensityTest()
        {
            bool methodThrew = false;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = false,
                DryBulbTemperature = 70,
                WetBulbTemperature = 90,
                BarometricPressure = 29.145
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();

                CalculationLibrary.CalculateVariables(data);
                data.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(data);
                data.DegreeOfSaturation = CalculationLibrary.CalculateDegreeOfSaturation(data);
                data.RelativeHumidity = CalculationLibrary.CalculateRelativeHumidity(data);
                CalculationLibrary.CalculateSpecificVolume(data);
                CalculationLibrary.CalculateDensity(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.14675003558781019, data.Density, "Density value does not match");
        }

        [TestMethod]
        public void SI_CalculateDensity_SpecificVolumeZeroTest()
        {
            bool methodThrew = false;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                DryBulbTemperature = 50,
                WetBulbTemperature = 55,
                BarometricPressure = 15
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();

                CalculationLibrary.CalculateVariables(data);
                data.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(data);
                data.DegreeOfSaturation = CalculationLibrary.CalculateDegreeOfSaturation(data);
                data.RelativeHumidity = CalculationLibrary.CalculateRelativeHumidity(data);
                data.SpecificVolume = 0.0;
                CalculationLibrary.CalculateDensity(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.0, data.Density, "Density value does not match");
        }

        [TestMethod]
        public void IP_CalculateDensity_SpecificVolumeZeroTest()
        {
            bool methodThrew = false;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = false,
                DryBulbTemperature = 50,
                WetBulbTemperature = 80,
                BarometricPressure = 30
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();

                CalculationLibrary.CalculateVariables(data);
                data.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(data);
                data.DegreeOfSaturation = CalculationLibrary.CalculateDegreeOfSaturation(data);
                data.RelativeHumidity = CalculationLibrary.CalculateRelativeHumidity(data);
                data.SpecificVolume = 0.0;
                CalculationLibrary.CalculateDensity(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.0, data.Density, "Density value does not match");
        }
    }
}
