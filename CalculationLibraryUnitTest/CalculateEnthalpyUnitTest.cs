using System;
using CalculationLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace CalculationLibraryUnitTest
{
    [TestClass]
    public class CalculateEnthalpyUnitTest
    {
        CalculationLibrary.CalculationLibrary CalculationLibrary { get; set; }

        [TestMethod]
        public void SI_CalculateEnthalpyTest()
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
                data.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(data.IsInternationalSystemOfUnits_SI, data.BarometricPressure, data.SaturationVaporPressureDryBulbTemperature, data.FsDryBulbTemperature, data.DryBulbTemperature, data.WetBulbTemperature);
                data.Enthalpy = CalculationLibrary.CalculateEnthalpy(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(1696.4599865784990, data.Enthalpy, "Enthalpy value does not match");
        }

        [TestMethod]
        public void IP_CalculateEnthalpyTest()
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
                data.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(data.IsInternationalSystemOfUnits_SI, data.BarometricPressure, data.SaturationVaporPressureDryBulbTemperature, data.FsDryBulbTemperature, data.DryBulbTemperature, data.WetBulbTemperature);
                data.Enthalpy = CalculationLibrary.CalculateEnthalpy(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(38.846743264873169, data.Enthalpy, "Enthalpy value does not match");
        }
    }
}
