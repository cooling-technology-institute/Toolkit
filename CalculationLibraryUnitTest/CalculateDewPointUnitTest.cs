using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace CalculationLibraryUnitTest
{
    [TestClass]
    public class CalculateDewPointUnitTest
    {
        CalculationLibrary.CalculationLibrary CalculationLibrary { get; set; }

        [TestMethod]
        public void SI_CalculateDewPointTest()
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
                data.DewPoint = CalculationLibrary.CalculateDewPoint(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(40.345922298440044, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void SI_CalculateDewPointHumidityRatio_ZeroTest()
        {
            bool methodThrew = false;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                DryBulbTemperature = 50,
                WetBulbTemperature = 40,
                PressurePSI = 14
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                data.HumidityRatio = 0.0;
                data.DewPoint = CalculationLibrary.CalculateDewPoint(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.0, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void SI_CalculateDewPointFreezingTest()
        {
            bool methodThrew = false;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                DryBulbTemperature = -13,
                WetBulbTemperature = -1,
                PressurePSI = 14.56
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.CalculateVariables(data);
                data.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(data);
                data.DewPoint = CalculationLibrary.CalculateDewPoint(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(1.2920507862745469, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void IP_CalculateDewPointTest()
        {
            bool methodThrew = false;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = false,
                DryBulbTemperature = 70,
                WetBulbTemperature = 90,
                PressurePSI = 29.145
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.CalculateVariables(data);
                data.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(data);
                data.DewPoint = CalculationLibrary.CalculateDewPoint(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(98.493137518364762, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void IP_CalculateDewPointHumidityRatio_ZeroTest()
        {
            bool methodThrew = false;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                DryBulbTemperature = 90,
                WetBulbTemperature = 70,
                PressurePSI = 29.145
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                data.HumidityRatio = 0.0;
                data.DewPoint = CalculationLibrary.CalculateDewPoint(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.0, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void IP_CalculateDewPointFreezingTest()
        {
            bool methodThrew = false;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = false,
                DryBulbTemperature = -20,
                WetBulbTemperature = 31,
                PressurePSI = 29.145
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.CalculateVariables(data);
                data.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(data);
                data.DewPoint = CalculationLibrary.CalculateDewPoint(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(85.878779107265359, data.DewPoint, "DewPoint value does not match");
        }
    }
}
