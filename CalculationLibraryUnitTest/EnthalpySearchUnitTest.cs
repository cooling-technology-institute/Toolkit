using System;
using CalculationLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace CalculationLibraryUnitTest
{
    [TestClass]
    public class EnthalpySearchUnitTest
    {
        CalculationLibrary.CalculationLibrary CalculationLibrary { get; set; }

        [TestMethod]
        public void SI_EnthalpySearchUnitTest()
        {
            bool methodThrew = false;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                BarometricPressure = 98.8,
                RootEnthalpy = 169.660507
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.EnthalpySearch(true, data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(169.660507, data.RootEnthalpy, "RootEnthalpy value does not match");
            Assert.AreEqual(169.66052206096091, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(39.941644668579102, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(39.941644668579102, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(0.050320428977248283, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(1.0, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(0.98325745909103257, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(1.0682048930991195, data.Density, "Density value does not match");
            Assert.AreEqual(39.941644668620228, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void SI_EnthalpySearch_RootEnthaply_LowTemperatureLessThanHtolerance_UnitTest()
        {
            bool methodThrew = false;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                BarometricPressure = 101.325,
                RootEnthalpy = -18.549065779718866
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.EnthalpySearch(true, data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(-18.549065779718866, data.RootEnthalpy, "RootEnthalpy value does not match");
            Assert.AreEqual(0.0, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(-20.0, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(-20.0, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(0.00063732168456372888, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(1.0, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(0.71791201668518922, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(1.3938160922626706, data.Density, "Density value does not match");
            Assert.AreEqual(-19.999999999994323, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void SI_EnthalpySearch_RootEnthaply_HighTemperatureLessThanHtolerance_UnitTest()
        {
            bool methodThrew = false;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                BarometricPressure = 101.325,
                RootEnthalpy = 460.97747901630419
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.EnthalpySearch(true, data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(460.97747901630419, data.RootEnthalpy, "RootEnthalpy value does not match");
            Assert.AreEqual(0.0, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(60.0, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(60.0, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(0.15353446480523672, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(0.99999999999999978, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(1.1768022106183109, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(0.98022798937397571, data.Density, "Density value does not match");
            Assert.AreEqual(60.000000003612605, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void SI_EnthalpySearch_SaturationFalse_UnitTest()
        {
            bool methodThrew = false;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                BarometricPressure = 98.8,
                RootEnthalpy = 169.660507
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.EnthalpySearch(false, data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(169.660507, data.RootEnthalpy, "RootEnthalpy value does not match");
            Assert.AreEqual(169.66044916375441, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(39.609231948852539, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(0.0, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(0.067837044847562741, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(15.834671752095273, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(0.88017232257297717, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(1.2132136144953884, data.Density, "Density value does not match");
            Assert.AreEqual(45.151339804038024, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void IP_EnthalpySearchUnitTest()
        {
            bool methodThrew = false;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = false,
                BarometricPressure = 98.8,
                RootEnthalpy = 169.660507
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.EnthalpySearch(true, data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(1.0012003737919406, data.Enthalpy, "Enthalpy value does not match");
        }
    }
}
