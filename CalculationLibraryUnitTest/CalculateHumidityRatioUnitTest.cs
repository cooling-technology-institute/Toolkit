using System;
using CalculationLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace CalculationLibraryUnitTest
{
    [TestClass]
    public class CalculateHumidityRatioUnitTest
    {
        CalculationLibrary.CalculationLibrary CalculationLibrary { get; set; }

        [TestMethod]
        public void SI_CalculateHumidityRatioTest()
        {
            bool methodThrew = false;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                DryBulbTemperature = 13,
                WetBulbTemperature = 40,
                BarometricPressure = 14.56
            };

            PsychrometricsData results = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = data.IsInternationalSystemOfUnits_SI,
                DryBulbTemperature = data.DryBulbTemperature,
                WetBulbTemperature = data.WetBulbTemperature,
                BarometricPressure = data.BarometricPressure
            };


            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();

                data.SaturationVaporPressureDryBulbTemperature = CalculationLibrary.CalculateVaporPressure(true, data.DryBulbTemperature);
                data.SaturationVaporPressureWetBulbTemperature = CalculationLibrary.CalculateVaporPressure(true, data.WetBulbTemperature);
                data.FsDryBulbTemperature = CalculationLibrary.Fs(UnitConverter.ConvertCelsiusToFahrenheit(data.DryBulbTemperature), UnitConverter.ConvertKilopascalToBarometricPressure(data.BarometricPressure));
                data.FsWetBulbTemperature = CalculationLibrary.Fs(UnitConverter.ConvertCelsiusToFahrenheit(data.WetBulbTemperature), UnitConverter.ConvertKilopascalToBarometricPressure(data.BarometricPressure));

                data.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(data.HumidityRatio, 0.66682722342298228, "HumidityRatio value does not match");
        }

        [TestMethod]
        public void IP_CalculateHumidityRatioTest()
        {
            bool methodThrew = false;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = false,
                DryBulbTemperature = 70,
                WetBulbTemperature = 90,
                BarometricPressure = 29.145
            };

            PsychrometricsData results = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = data.IsInternationalSystemOfUnits_SI,
                DryBulbTemperature = data.DryBulbTemperature,
                WetBulbTemperature = data.WetBulbTemperature,
                BarometricPressure = data.BarometricPressure
            };


            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();

                data.SaturationVaporPressureDryBulbTemperature = CalculationLibrary.CalculateVaporPressure(false, data.DryBulbTemperature);
                data.SaturationVaporPressureWetBulbTemperature = CalculationLibrary.CalculateVaporPressure(false, data.WetBulbTemperature);
                data.FsDryBulbTemperature = CalculationLibrary.Fs(data.DryBulbTemperature, data.BarometricPressure);
                data.FsWetBulbTemperature = CalculationLibrary.Fs(data.WetBulbTemperature, data.BarometricPressure);

                data.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(data.HumidityRatio, 0.020187846371028835, "HumidityRatio value does not match");
        }

        [TestMethod]
        public void SI_CalculateHumidityRatio_DensityZeroTest()
        {
            bool methodThrew = false;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                DryBulbTemperature = 13,
                WetBulbTemperature = 40,
                BarometricPressure = 14.56
            };

            PsychrometricsData results = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = data.IsInternationalSystemOfUnits_SI,
                DryBulbTemperature = data.DryBulbTemperature,
                WetBulbTemperature = data.WetBulbTemperature,
                BarometricPressure = data.BarometricPressure
            };


            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();

                data.SaturationVaporPressureDryBulbTemperature = CalculationLibrary.CalculateVaporPressure(true, data.DryBulbTemperature);
                data.SaturationVaporPressureWetBulbTemperature = CalculationLibrary.CalculateVaporPressure(true, data.WetBulbTemperature);
                data.FsDryBulbTemperature = CalculationLibrary.Fs(UnitConverter.ConvertCelsiusToFahrenheit(data.DryBulbTemperature), UnitConverter.ConvertKilopascalToBarometricPressure(data.BarometricPressure));
                data.FsWetBulbTemperature = CalculationLibrary.Fs(UnitConverter.ConvertCelsiusToFahrenheit(data.WetBulbTemperature), UnitConverter.ConvertKilopascalToBarometricPressure(data.BarometricPressure));

                data.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(data.HumidityRatio, 0.66682722342298228, "HumidityRatio value does not match");
        }

        [TestMethod]
        public void IP_CalculateHumidityRatio_DensityZeroTest()
        {
            bool methodThrew = false;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = false,
                DryBulbTemperature = 70,
                WetBulbTemperature = 90,
                BarometricPressure = 29.145
            };

            PsychrometricsData results = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = data.IsInternationalSystemOfUnits_SI,
                DryBulbTemperature = data.DryBulbTemperature,
                WetBulbTemperature = data.WetBulbTemperature,
                BarometricPressure = data.BarometricPressure
            };


            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();

                data.SaturationVaporPressureDryBulbTemperature = CalculationLibrary.CalculateVaporPressure(false, data.DryBulbTemperature);
                data.SaturationVaporPressureWetBulbTemperature = CalculationLibrary.CalculateVaporPressure(false, data.WetBulbTemperature);
                data.FsDryBulbTemperature = data.BarometricPressure;
                data.FsWetBulbTemperature = 1.0;

                data.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(data.HumidityRatio, 0.0, "HumidityRatio value does not match");
        }
    }
}
