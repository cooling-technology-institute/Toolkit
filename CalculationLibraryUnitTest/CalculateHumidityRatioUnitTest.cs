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
                DryBulbTemperature = 43,
                WetBulbTemperature = 20,
                PressurePSI = 14
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.CalculateVariables(data);

                data.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(data.IsInternationalSystemOfUnits_SI, data.PressurePSI, data.SaturationVaporPressureWetBulb, data.FsWetBulb, data.DryBulbTemperature, data.WetBulbTemperature);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.11354219293284637, data.HumidityRatio, "HumidityRatio value does not match");
        }

        [TestMethod]
        public void SI_CalculateHumidityRatio_ZeroTest()
        {
            bool methodThrew = false;
            double wet = (2501.0 + 1.86 * 50) / 4.186;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                DryBulbTemperature = 50,
                WetBulbTemperature = wet,
                PressurePSI = 14.56
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.CalculateVariables(data);

                data.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(data.IsInternationalSystemOfUnits_SI, data.PressurePSI, data.SaturationVaporPressureDryBulb, data.FsDryBulb, data.DryBulbTemperature, data.WetBulbTemperature);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.0, data.HumidityRatio, "HumidityRatio value does not match");
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
                PressurePSI = 29.145
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.CalculateVariables(data);
                data.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(data.IsInternationalSystemOfUnits_SI, data.PressurePSI, data.SaturationVaporPressureWetBulb, data.FsWetBulb, data.DryBulbTemperature, data.WetBulbTemperature);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.020187846371028835, data.HumidityRatio, "HumidityRatio value does not match");
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
                PressurePSI = 29.145
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.CalculateVariables(data);
                data.FsDryBulb = data.PressurePSI;
                data.FsWetBulb = 1.0;

                data.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(data.IsInternationalSystemOfUnits_SI, data.PressurePSI, data.SaturationVaporPressureDryBulb, data.FsDryBulb, data.DryBulbTemperature, data.WetBulbTemperature);
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
                PressurePSI = 10
            };

            double c1 = (data.IsInternationalSystemOfUnits_SI) ? 2501.0 : 1093.0;
            double c2 = (data.IsInternationalSystemOfUnits_SI) ? 1.86 : 0.444;
            double c3 = (data.IsInternationalSystemOfUnits_SI) ? 2.326 : 0.556;
            double c4 = (data.IsInternationalSystemOfUnits_SI) ? 1.006 : 0.24;
            double c5 = (data.IsInternationalSystemOfUnits_SI) ? 4.186 : 1.0;

            double humidityRatio = ((c1 - c3 * data.WetBulbTemperature) * 0.0 - (c4 * (data.DryBulbTemperature - data.WetBulbTemperature))) / (c1 + c2 * data.DryBulbTemperature - c5 * data.WetBulbTemperature);

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.CalculateVariables(data);
                data.SaturationVaporPressureWetBulb = 2;
                data.FsDryBulb = CalculationLibrary.CalculateFs(data.IsInternationalSystemOfUnits_SI, data.PressurePSI, data.DryBulbTemperature);
                data.FsWetBulb = data.PressurePSI / data.SaturationVaporPressureWetBulb;

                data.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(data.IsInternationalSystemOfUnits_SI, data.PressurePSI, data.SaturationVaporPressureWetBulb, data.FsWetBulb, data.DryBulbTemperature, data.WetBulbTemperature);
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
                PressurePSI = 29
            };

            double c1 = (data.IsInternationalSystemOfUnits_SI) ? 2501.0 : 1093.0;
            double c2 = (data.IsInternationalSystemOfUnits_SI) ? 1.86 : 0.444;
            double c3 = (data.IsInternationalSystemOfUnits_SI) ? 2.326 : 0.556;
            double c4 = (data.IsInternationalSystemOfUnits_SI) ? 1.006 : 0.24;
            double c5 = (data.IsInternationalSystemOfUnits_SI) ? 4.186 : 1.0;

            double humidityRatio = c1 + c2 * data.DryBulbTemperature - c5 * data.WetBulbTemperature;

            humidityRatio = ((c1 - c3 * data.WetBulbTemperature) * 0.0 - (c4 * (data.DryBulbTemperature - data.WetBulbTemperature))) / humidityRatio;  // ASHRAE Eq.(33)

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.CalculateVariables(data);
                data.FsDryBulb = data.PressurePSI;
                data.FsWetBulb = data.PressurePSI / data.SaturationVaporPressureWetBulb;

                data.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(data.IsInternationalSystemOfUnits_SI, data.PressurePSI, data.SaturationVaporPressureWetBulb, data.FsWetBulb, data.DryBulbTemperature, data.WetBulbTemperature);
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
