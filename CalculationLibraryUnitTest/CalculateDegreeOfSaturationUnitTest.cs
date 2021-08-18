using System;
using CalculationLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace CalculationLibraryUnitTest
{
    [TestClass]
    public class CalculateDegreeOfSaturationUnitTest
    {
        CalculationLibrary.CalculationLibrary CalculationLibrary { get; set; }

        [TestMethod]
        public void SI_CalculateDegreeOfSaturationTest()
        {
            bool methodThrew = false;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                DryBulbTemperature = 13,
                WetBulbTemperature = 40,
                PressurePSI = 14.56
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                
                CalculationLibrary.CalculateVariables(data);
                data.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(data);
                data.DegreeOfSaturation = CalculationLibrary.CalculateDegreeOfSaturation(data);
            }
            catch
            {
                methodThrew = true;
            }

            double expected = data.HumidityRatio / (0.62198 * data.SaturationVaporPressureDryBulb * data.FsDryBulb / (data.PressurePSI - data.SaturationVaporPressureDryBulb * data.FsDryBulb));

            Assert.IsFalse(methodThrew, "Method threw");
            // 9.3371669670174899
            Assert.AreEqual(expected, data.DegreeOfSaturation, "DegreeOfSaturation value does not match");
        }

        [TestMethod]
        public void IP_CalculateDegreeOfSaturationTest()
        {
            bool methodThrew = false;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = false,
                DryBulbTemperature = 70,
                WetBulbTemperature = 90,
                PressurePSI = 29.145
            };

            PsychrometricsData results = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = data.IsInternationalSystemOfUnits_SI,
                DryBulbTemperature = data.DryBulbTemperature,
                WetBulbTemperature = data.WetBulbTemperature,
                PressurePSI = data.PressurePSI
            };


            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();

                CalculationLibrary.CalculateVariables(data);
                data.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(data);
                data.DegreeOfSaturation = CalculationLibrary.CalculateDegreeOfSaturation(data);
            }
            catch
            {
                methodThrew = true;
            }

            double expected = data.HumidityRatio / (0.62198 * data.SaturationVaporPressureDryBulb * data.FsDryBulb / (data.PressurePSI - data.SaturationVaporPressureDryBulb * data.FsDryBulb));

            Assert.IsFalse(methodThrew, "Method threw");
            //2.5527236876497503
            Assert.AreEqual(expected, data.DegreeOfSaturation, "DegreeOfSaturation value does not match");
        }

        [TestMethod]
        public void SI_CalculateDegreeOfSaturation_ZeroTest()
        {
            bool methodThrew = false;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                DryBulbTemperature = 13,
                WetBulbTemperature = 40,
                BarometricPressure = 14
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();

                CalculationLibrary.CalculateVariables(data);
                data.WsDryBulb = 0.0;
                data.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(data);
                data.DegreeOfSaturation = CalculationLibrary.CalculateDegreeOfSaturation(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.0, data.DegreeOfSaturation, "DegreeOfSaturation value does not match");
        }

        [TestMethod]
        public void IP_CalculateDegreeOfSaturation_ZeroTest()
        {
            bool methodThrew = false;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = false,
                DryBulbTemperature = 70,
                WetBulbTemperature = 90,
                BarometricPressure = 14,
                SaturationVaporPressureDryBulb = 14,
                WsDryBulb = 0,
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();

                data.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(data);
                data.DegreeOfSaturation = CalculationLibrary.CalculateDegreeOfSaturation(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.0, data.DegreeOfSaturation, "DegreeOfSaturation value does not match");
        }

        [TestMethod]
        public void SI_CalculateDegreeOfSaturation_WsDBZeroTest()
        {
            bool methodThrew = false;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                DryBulbTemperature = 20,
                WetBulbTemperature = 39,
                BarometricPressure = 11
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();

                CalculationLibrary.CalculateVariables(data);
                data.WsDryBulb = 0.0;
                data.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(data);
                data.DegreeOfSaturation = CalculationLibrary.CalculateDegreeOfSaturation(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.0, data.DegreeOfSaturation, "DegreeOfSaturation value does not match");
        }

        [TestMethod]
        public void IP_CalculateDegreeOfSaturation_WsDBZeroTest()
        {
            bool methodThrew = false;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = false,
                DryBulbTemperature = 70,
                WetBulbTemperature = 90,
                BarometricPressure = 30
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();

                CalculationLibrary.CalculateVariables(data);
                data.WsDryBulb = 0.0;
                data.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(data);
                data.DegreeOfSaturation = CalculationLibrary.CalculateDegreeOfSaturation(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.0, data.DegreeOfSaturation, "DegreeOfSaturation value does not match");
        }
    }
}
