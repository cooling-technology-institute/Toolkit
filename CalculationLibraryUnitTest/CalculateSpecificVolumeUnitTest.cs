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
            Assert.AreEqual(0.66682722342298228, data.SpecificVolume, "SpecificVolume value does not match");
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

                data.SaturationVaporPressureDryBulbTemperature = CalculationLibrary.CalculateVaporPressure(false, data.DryBulbTemperature);
                data.SaturationVaporPressureWetBulbTemperature = CalculationLibrary.CalculateVaporPressure(false, data.WetBulbTemperature);
                data.FsDryBulbTemperature = CalculationLibrary.Fs(data.DryBulbTemperature, data.BarometricPressure);
                data.FsWetBulbTemperature = CalculationLibrary.Fs(data.WetBulbTemperature, data.BarometricPressure);

                data.SpecificVolume = CalculationLibrary.CalculateSpecificVolume(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.020187846371028835, data.SpecificVolume, "SpecificVolume value does not match");
        }

        [TestMethod]
        public void SI_CalculateSpecificVolume_BarometricPressureZeroTest()
        {
            bool methodThrew = false;
            double wet = (2501.0 + 1.805 * 50) / 4.186;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                DryBulbTemperature = 50,
                WetBulbTemperature = wet,
                BarometricPressure = 14.56
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();

                data.SaturationVaporPressureDryBulbTemperature = CalculationLibrary.CalculateVaporPressure(true, data.DryBulbTemperature);
                data.SaturationVaporPressureWetBulbTemperature = CalculationLibrary.CalculateVaporPressure(true, data.WetBulbTemperature);
                data.FsDryBulbTemperature = CalculationLibrary.Fs(UnitConverter.ConvertCelsiusToFahrenheit(data.DryBulbTemperature), UnitConverter.ConvertKilopascalToBarometricPressure(data.BarometricPressure));
                data.FsWetBulbTemperature = CalculationLibrary.Fs(UnitConverter.ConvertCelsiusToFahrenheit(data.WetBulbTemperature), UnitConverter.ConvertKilopascalToBarometricPressure(data.BarometricPressure));

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
            double wet = (1093.0 + 0.444 * 50) / 1.0;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = false,
                DryBulbTemperature = 50,
                WetBulbTemperature = wet,
                BarometricPressure = 29.145
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();

                data.SaturationVaporPressureDryBulbTemperature = CalculationLibrary.CalculateVaporPressure(false, data.DryBulbTemperature);
                data.SaturationVaporPressureWetBulbTemperature = CalculationLibrary.CalculateVaporPressure(false, data.WetBulbTemperature);
                data.FsDryBulbTemperature = data.BarometricPressure;
                data.FsWetBulbTemperature = 1.0;

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
