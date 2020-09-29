using System;
using CalculationLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace CalculationLibraryUnitTest
{
    [TestClass]
    public class CalculateRelativeHumidityUnitTest
    {
        CalculationLibrary.CalculationLibrary CalculationLibrary { get; set; }

        [TestMethod]
        public void SI_CalculateRelativeHumidityTest()
        {
            bool methodThrew = false;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                DryBulbTemperature = 43,
                WetBulbTemperature = 20,
                BarometricPressure = 14
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.CalculateVariables(data);
                data.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(data);
                data.DegreeOfSaturation = CalculationLibrary.CalculateDegreeOfSaturation(data);
                data.RelativeHumidity = CalculationLibrary.CalculateRelativeHumidity(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.24967229746811828, data.RelativeHumidity, "RelativeHumidity value does not match");
        }

        [TestMethod]
        public void IP_CalculateRelativeHumidityTest()
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
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(2.5039106749147289, data.RelativeHumidity, "RelativeHumidity value does not match");
        }

        [TestMethod]
        public void SI_CalculateRelativeHumidity_BarometricPressureZeroTest()
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
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.0, data.RelativeHumidity, "RelativeHumidity value does not match");
        }

        [TestMethod]
        public void IP_CalculateRelativeHumidity_BarometricPressureZeroTest()
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
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.0, data.RelativeHumidity, "RelativeHumidity value does not match");
        }


        [TestMethod]
        public void SI_CalculateRelativeHumidity_DensityZeroTest()
        {
            bool methodThrew = false;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                DryBulbTemperature = 50,
                WetBulbTemperature = 55,
                BarometricPressure = 30
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();

                CalculationLibrary.CalculateVariables(data);
                data.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(data);
                data.FsDryBulb = 20.0;
                data.SaturationVaporPressureDryBulb = 1.0;
                data.DegreeOfSaturation = 0;
                data.RelativeHumidity = CalculationLibrary.CalculateRelativeHumidity(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.0, data.RelativeHumidity, "RelativeHumidity value does not match");
        }

        [TestMethod]
        public void IP_CalculateRelativeHumidity_DensityZeroTest()
        {
            bool methodThrew = false;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = false,
                DryBulbTemperature = 50,
                WetBulbTemperature = 80,
                BarometricPressure = 20
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();

                CalculationLibrary.CalculateVariables(data);
                data.FsDryBulb = 20.0;
                data.SaturationVaporPressureDryBulb = 1.0;
                data.DegreeOfSaturation = 0;
                data.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(data);
                data.RelativeHumidity = CalculationLibrary.CalculateRelativeHumidity(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.0, data.RelativeHumidity, "RelativeHumidity value does not match");
        }
        [TestMethod]
        public void SI_CalculateRelativeHumidityMethod2Test()
        {
            bool methodThrew = false;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                DryBulbTemperature = 43,
                WetBulbTemperature = 20,
                BarometricPressure = 14
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                data.RelativeHumidity = CalculationLibrary.CalculateRelativeHumidity(true, data.BarometricPressure, data.DryBulbTemperature, data.WetBulbTemperature);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.24967229746811828, data.RelativeHumidity, "RelativeHumidity value does not match");
        }

        [TestMethod]
        public void IP_CalculateRelativeHumidityMethod2Test()
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
                data.RelativeHumidity = CalculationLibrary.CalculateRelativeHumidity(false, data.BarometricPressure, data.DryBulbTemperature, data.WetBulbTemperature);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(2.5039106749147289, data.RelativeHumidity, "RelativeHumidity value does not match");
        }

    }
}
