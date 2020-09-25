using System;
using CalculationLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace CalculationLibraryUnitTest
{
    [TestClass]
    public class CalculateVariablesUnitTest
    {
        CalculationLibrary.CalculationLibrary CalculationLibrary { get; set; }

        [TestMethod]
        public void SI_CalculateVariablesTest()
        {
            bool methodThrew = false;
            double SaturationVaporPressureDryBulbTemperature = 0.0;
            double SaturationVaporPressureWetBulbTemperature = 0.0;
            double FsDryBulbTemperature = 0.0;
            double FsWetBulbTemperature = 0.0;

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
                SaturationVaporPressureDryBulbTemperature = CalculationLibrary.CalculateVaporPressure(true, data.DryBulbTemperature);
                SaturationVaporPressureWetBulbTemperature = CalculationLibrary.CalculateVaporPressure(true, data.WetBulbTemperature);
                FsDryBulbTemperature = CalculationLibrary.CalculateFs(data.IsInternationalSystemOfUnits_SI, data.BarometricPressure, data.DryBulbTemperature);
                FsWetBulbTemperature = CalculationLibrary.CalculateFs(data.IsInternationalSystemOfUnits_SI, data.BarometricPressure, data.WetBulbTemperature);
                CalculationLibrary.CalculateVariables(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(data.SaturationVaporPressureDryBulbTemperature, SaturationVaporPressureDryBulbTemperature, "SaturationVaporPressureDryBulbTemperature value does not match");
            Assert.AreEqual(data.SaturationVaporPressureWetBulbTemperature, SaturationVaporPressureWetBulbTemperature, "SaturationVaporPressureWetBulbTemperature value does not match");
            Assert.AreEqual(data.FsDryBulbTemperature, FsDryBulbTemperature, "FsDryBulbTemperature value does not match");
            Assert.AreEqual(data.FsWetBulbTemperature, FsWetBulbTemperature, "FsWetBulbTemperature value does not match");
        }

        [TestMethod]
        public void IP_CalculateVariablesTest()
        {
            bool methodThrew = false;
            double SaturationVaporPressureDryBulbTemperature = 0.0;
            double SaturationVaporPressureWetBulbTemperature = 0.0;
            double FsDryBulbTemperature = 0.0;
            double FsWetBulbTemperature = 0.0;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = false,
                DryBulbTemperature = 25.0,
                WetBulbTemperature = 55.0,
                BarometricPressure = 29.921
        };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                SaturationVaporPressureDryBulbTemperature = CalculationLibrary.CalculateVaporPressure(false, data.DryBulbTemperature);
                SaturationVaporPressureWetBulbTemperature = CalculationLibrary.CalculateVaporPressure(false, data.WetBulbTemperature);
                FsDryBulbTemperature = CalculationLibrary.CalculateFs(data.IsInternationalSystemOfUnits_SI, data.BarometricPressure, data.DryBulbTemperature);
                FsWetBulbTemperature = CalculationLibrary.CalculateFs(data.IsInternationalSystemOfUnits_SI, data.BarometricPressure, data.WetBulbTemperature);
                CalculationLibrary.CalculateVariables(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(data.SaturationVaporPressureDryBulbTemperature, SaturationVaporPressureDryBulbTemperature, "SaturationVaporPressureDryBulbTemperature value does not match");
            Assert.AreEqual(data.SaturationVaporPressureWetBulbTemperature, SaturationVaporPressureWetBulbTemperature, "SaturationVaporPressureWetBulbTemperature value does not match");
            Assert.AreEqual(data.FsDryBulbTemperature, FsDryBulbTemperature, "FsDryBulbTemperature value does not match");
            Assert.AreEqual(data.FsWetBulbTemperature, FsWetBulbTemperature, "FsWetBulbTemperature value does not match");
        }
    }
}
