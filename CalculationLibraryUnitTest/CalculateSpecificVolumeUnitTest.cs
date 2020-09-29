using System;
using CalculationLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace CalculationLibraryUnitTest
{
    [TestClass]
    public class CalculateSpecificVolumeUnitTest
    {
        CalculationLibrary.CalculationLibrary CalculationLibrary { get; set; }

        [TestMethod]
        public void SI_CalculateSpecificVolumeTest()
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
                data.SpecificVolume = CalculationLibrary.CalculateSpecificVolume(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(11.689970139488507, data.SpecificVolume, "SpecificVolume value does not match");
        }

        [TestMethod]
        public void IP_CalculateSpecificVolumeTest()
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
                data.SpecificVolume = CalculationLibrary.CalculateSpecificVolume(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(6.9518746096697424, data.SpecificVolume, "SpecificVolume value does not match");
        }

        [TestMethod]
        public void SI_CalculateSpecificVolume_BarometricPressureZeroTest()
        {
            bool methodThrew = false;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                DryBulbTemperature = 50,
                WetBulbTemperature = 55,
                BarometricPressure = 0
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();

                CalculationLibrary.CalculateVariables(data);
                data.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(data);
                data.DegreeOfSaturation = CalculationLibrary.CalculateDegreeOfSaturation(data);
                data.RelativeHumidity = CalculationLibrary.CalculateRelativeHumidity(data);
                data.SpecificVolume = CalculationLibrary.CalculateSpecificVolume(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.0, data.SpecificVolume, "SpecificVolume value does not match");
        }

        [TestMethod]
        public void IP_CalculateSpecificVolume_BarometricPressureZeroTest()
        {
            bool methodThrew = false;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = false,
                DryBulbTemperature = 50,
                WetBulbTemperature = 80,
                BarometricPressure = 0
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();

                CalculationLibrary.CalculateVariables(data);
                data.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(data);
                data.DegreeOfSaturation = CalculationLibrary.CalculateDegreeOfSaturation(data);
                data.RelativeHumidity = CalculationLibrary.CalculateRelativeHumidity(data);
                data.SpecificVolume = CalculationLibrary.CalculateSpecificVolume(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.0, data.SpecificVolume, "SpecificVolume value does not match");
        }
    }
}
