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
                PressurePSI = 14.56,
                DryBulbTemperature = 30.0,
                RelativeHumidity = 24.0
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
            Assert.AreEqual(9.6398162841796875, WetBulbTemperature, "WetBulbTemperature value does not match");
        }

        [TestMethod]
        public void SI_CalculateWetBulbTemperature_TemperatureTolerance_Test()
        {
            bool methodThrew = false;
            double WetBulbTemperature = 0.0;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                PressurePSI = 14.56,
                DryBulbTemperature = -20.0,
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
            Assert.AreEqual(-20.0, WetBulbTemperature, "WetBulbTemperature value does not match");
        }

        [TestMethod]
        public void SI_CalculateWetBulbTemperature_RelativeHumdityDryBulbTolerance_Test()
        {
            bool methodThrew = false;
            double WetBulbTemperature = 0.0;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                PressurePSI = 14.56,
                DryBulbTemperature = 30.0,
                RelativeHumidity = 100.0
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
            Assert.AreEqual(data.DryBulbTemperature, WetBulbTemperature, "WetBulbTemperature value does not match");
        }

        [TestMethod]
        public void SI_CalculateWetBulbTemperature_RelativeHumdityMidpointZero_Test()
        {
            bool methodThrew = false;
            double WetBulbTemperature = 0.0;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                PressurePSI = 0,
                DryBulbTemperature = 0,
                RelativeHumidity = 0
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
            Assert.AreEqual(0.0, WetBulbTemperature, "WetBulbTemperature value does not match");
        }

        [TestMethod]
        public void IP_CalculateWetBulbTemperatureTest()
        {
            bool methodThrew = false;
            double WetBulbTemperature = 0.0;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = false,
                PressurePSI = 14.696,
                DryBulbTemperature = 100.0,
                RelativeHumidity = 42.38
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
            Assert.AreEqual(79.998397827148438, WetBulbTemperature, "WetBulbTemperature value does not match");
        }

        [TestMethod]
        public void IP_CalculateWetBulbTemperature_TemperatureTolerance_Test()
        {
            bool methodThrew = false;
            double WetBulbTemperature = 0.0;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = false,
                PressurePSI = 29.145,
                DryBulbTemperature = 0.0,
                RelativeHumidity = 0.24
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                WetBulbTemperature = CalculationLibrary.CalculateWetBulbTemperature(data);
            }
            catch
            {
                methodThrew = false;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.0, WetBulbTemperature, "WetBulbTemperature value does not match");
        }

        [TestMethod]
        public void IP_CalculateWetBulbTemperature_RelativeHumdityDryBulbTolerance_Test()
        {
            bool methodThrew = false;
            double WetBulbTemperature = 0.0;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = false,
                PressurePSI = 29.145,
                DryBulbTemperature = 70.0,
                RelativeHumidity = 100
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                WetBulbTemperature = CalculationLibrary.CalculateWetBulbTemperature(data);
            }
            catch
            {
                methodThrew = false;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(data.DryBulbTemperature, WetBulbTemperature, "WetBulbTemperature value does not match");
        }

        [TestMethod]
        public void IP_CalculateWetBulbTemperature_RelativeHumdityMidpointZero_Test()
        {
            bool methodThrew = false;
            double WetBulbTemperature = 0.0;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = false,
                PressurePSI = 29.145,
                DryBulbTemperature = 70.0,
                RelativeHumidity = -72.221645050788952
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                WetBulbTemperature = CalculationLibrary.CalculateWetBulbTemperature(data);
            }
            catch
            {
                methodThrew = false;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(35.0, WetBulbTemperature, "WetBulbTemperature value does not match");
        }
    }
}
