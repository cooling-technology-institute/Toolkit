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
            Assert.AreEqual(0.66682722342298228, data.HumidityRatio, "HumidityRatio value does not match");
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
            Assert.AreEqual(0.020187846371028835, data.HumidityRatio, "HumidityRatio value does not match");
        }

        [TestMethod]
        public void SI_CalculateHumidityRatio_ZeroTest()
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

                data.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.0, data.HumidityRatio, "HumidityRatio value does not match");
        }

        [TestMethod]
        public void IP_CalculateHumidityRatio_ZeroTest()
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

                data.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.0, data.HumidityRatio, "HumidityRatio value does not match");
        }

        [TestMethod]
        public void SI_CalculateHumidityRatio_ZeroTest2()
        {
            bool methodThrew = false;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                DryBulbTemperature = 20,
                WetBulbTemperature = 39,
                BarometricPressure = 10
            };

            double c1 = (data.IsInternationalSystemOfUnits_SI) ? 2501.0 : 1093.0;
            double c2 = (data.IsInternationalSystemOfUnits_SI) ? 1.805 : 0.444;
            double c3 = (data.IsInternationalSystemOfUnits_SI) ? 2.381 : 0.556;
            double c4 = (data.IsInternationalSystemOfUnits_SI) ? 1.0 : 0.24;
            double c5 = (data.IsInternationalSystemOfUnits_SI) ? 4.186 : 1.0;

            double humidityRatio = ((c1 - c3 * data.WetBulbTemperature) * 0.0 - (c4 * (data.DryBulbTemperature - data.WetBulbTemperature))) / (c1 + c2 * data.DryBulbTemperature - c5 * data.WetBulbTemperature);

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();

                data.SaturationVaporPressureDryBulbTemperature = CalculationLibrary.CalculateVaporPressure(true, data.DryBulbTemperature);
                data.SaturationVaporPressureWetBulbTemperature = 2;
                data.FsDryBulbTemperature = CalculationLibrary.Fs(UnitConverter.ConvertCelsiusToFahrenheit(data.DryBulbTemperature), UnitConverter.ConvertKilopascalToBarometricPressure(data.BarometricPressure));
                data.FsWetBulbTemperature = data.BarometricPressure / data.SaturationVaporPressureWetBulbTemperature;

                data.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(humidityRatio, data.HumidityRatio, "HumidityRatio value does not match");
        }

        [TestMethod]
        public void IP_CalculateHumidityRatio_ZeroTest2()
        {
            bool methodThrew = false;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = false,
                DryBulbTemperature = 70,
                WetBulbTemperature = 90,
                BarometricPressure = 29
            };

            double c1 = (data.IsInternationalSystemOfUnits_SI) ? 2501.0 : 1093.0;
            double c2 = (data.IsInternationalSystemOfUnits_SI) ? 1.805 : 0.444;
            double c3 = (data.IsInternationalSystemOfUnits_SI) ? 2.381 : 0.556;
            double c4 = (data.IsInternationalSystemOfUnits_SI) ? 1.0 : 0.24;
            double c5 = (data.IsInternationalSystemOfUnits_SI) ? 4.186 : 1.0;

            double humidityRatio = c1 + c2 * data.DryBulbTemperature - c5 * data.WetBulbTemperature;

            humidityRatio = ((c1 - c3 * data.WetBulbTemperature) * 0.0 - (c4 * (data.DryBulbTemperature - data.WetBulbTemperature))) / humidityRatio;  // ASHRAE Eq.(33)

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();

                data.SaturationVaporPressureDryBulbTemperature = CalculationLibrary.CalculateVaporPressure(false, data.DryBulbTemperature);
                data.SaturationVaporPressureWetBulbTemperature = CalculationLibrary.CalculateVaporPressure(false, data.WetBulbTemperature);
                data.FsDryBulbTemperature = data.BarometricPressure;
                data.FsWetBulbTemperature = data.BarometricPressure / data.SaturationVaporPressureWetBulbTemperature;

                data.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(humidityRatio, data.HumidityRatio, "HumidityRatio value does not match");
        }
    }
}
