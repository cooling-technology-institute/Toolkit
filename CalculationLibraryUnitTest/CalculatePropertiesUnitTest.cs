using System;
using CalculationLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace CalculationLibraryUnitTest
{
    [TestClass]
    public class CalculatePropertiesUnitTest
    {
        CalculationLibrary.CalculationLibrary CalculationLibrary { get; set; }

        [TestMethod]
        public void SI_CalculatePropertiesTest()
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

                results.SaturationVaporPressureDryBulb = CalculationLibrary.CalculateVaporPressure(true, results.DryBulbTemperature);
                results.SaturationVaporPressureWetBulb = CalculationLibrary.CalculateVaporPressure(true, results.WetBulbTemperature);
                results.FsDryBulb = CalculationLibrary.CalculateFs(true, results.BarometricPressure, results.DryBulbTemperature);
                results.FsWetBulb = CalculationLibrary.CalculateFs(true, results.BarometricPressure, results.WetBulbTemperature);
                results.WsWetBulb = CalculationLibrary.CalculateSaturatedHumidityRatio(results.BarometricPressure, results.SaturationVaporPressureWetBulb, results.FsWetBulb);  // 'ASHRAE Eq.(21a)
                results.WsDryBulb = CalculationLibrary.CalculateSaturatedHumidityRatio(results.BarometricPressure, results.SaturationVaporPressureDryBulb, results.FsDryBulb);  // 'ASHRAE Eq.(21a)
                results.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(results);
                results.DegreeOfSaturation = CalculationLibrary.CalculateDegreeOfSaturation(results);
                results.RelativeHumidity = CalculationLibrary.CalculateRelativeHumidity(results);
                results.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(results);
                results.DegreeOfSaturation = CalculationLibrary.CalculateDegreeOfSaturation(results);
                results.RelativeHumidity = CalculationLibrary.CalculateRelativeHumidity(results);
                results.SpecificVolume = CalculationLibrary.CalculateSpecificVolume(results);
                results.Density = CalculationLibrary.CalculateDensity(results);
                results.Enthalpy = CalculationLibrary.CalculateEnthalpy(results);
                results.DewPoint = CalculationLibrary.CalculateDewPoint(results);

                CalculationLibrary.CalculateProperties(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(data.SaturationVaporPressureDryBulb, results.SaturationVaporPressureDryBulb, "SaturationVaporPressureDryBulb value does not match");
            Assert.AreEqual(data.SaturationVaporPressureWetBulb, results.SaturationVaporPressureWetBulb, "SaturationVaporPressureWetBulb value does not match");
            Assert.AreEqual(data.FsDryBulb, results.FsDryBulb, "FsDryBulb value does not match");
            Assert.AreEqual(data.FsWetBulb, results.FsWetBulb, "FsWetBulb value does not match");
            Assert.AreEqual(data.WsDryBulb, results.WsDryBulb, "WsDryBulb value does not match");
            Assert.AreEqual(data.WsWetBulb, results.WsWetBulb, "WsWetBulb value does not match");
            Assert.AreEqual(data.HumidityRatio, results.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(data.DegreeOfSaturation, results.DegreeOfSaturation, "DegreeOfSaturation value does not match");
            Assert.AreEqual(data.RelativeHumidity, results.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(data.SpecificVolume, results.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(data.Density, results.Density, "Density value does not match");
            Assert.AreEqual(data.Enthalpy, results.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(data.DewPoint, results.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void IP_CalculatePropertiesTest()
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

                results.SaturationVaporPressureDryBulb = CalculationLibrary.CalculateVaporPressure(false, results.DryBulbTemperature);
                results.SaturationVaporPressureWetBulb = CalculationLibrary.CalculateVaporPressure(false, results.WetBulbTemperature);
                results.FsDryBulb = CalculationLibrary.CalculateFs(false, results.BarometricPressure, results.DryBulbTemperature);
                results.FsWetBulb = CalculationLibrary.CalculateFs(false, results.BarometricPressure, results.WetBulbTemperature);
                results.WsWetBulb = CalculationLibrary.CalculateSaturatedHumidityRatio(results.BarometricPressure, results.SaturationVaporPressureWetBulb, results.FsWetBulb);  // 'ASHRAE Eq.(21a)
                results.WsDryBulb = CalculationLibrary.CalculateSaturatedHumidityRatio(results.BarometricPressure, results.SaturationVaporPressureDryBulb, results.FsDryBulb);  // 'ASHRAE Eq.(21a)
                results.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(results);
                results.DegreeOfSaturation = CalculationLibrary.CalculateDegreeOfSaturation(results);
                results.RelativeHumidity = CalculationLibrary.CalculateRelativeHumidity(results);
                results.HumidityRatio = CalculationLibrary.CalculateHumidityRatio(results);
                results.DegreeOfSaturation = CalculationLibrary.CalculateDegreeOfSaturation(results);
                results.RelativeHumidity = CalculationLibrary.CalculateRelativeHumidity(results);
                results.SpecificVolume = CalculationLibrary.CalculateSpecificVolume(results);
                results.Density = CalculationLibrary.CalculateDensity(results);
                results.Enthalpy = CalculationLibrary.CalculateEnthalpy(results);
                results.DewPoint = CalculationLibrary.CalculateDewPoint(results);

                CalculationLibrary.CalculateProperties(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(data.SaturationVaporPressureDryBulb, results.SaturationVaporPressureDryBulb, "SaturationVaporPressureDryBulb value does not match");
            Assert.AreEqual(data.SaturationVaporPressureWetBulb, results.SaturationVaporPressureWetBulb, "SaturationVaporPressureWetBulb value does not match");
            Assert.AreEqual(data.FsDryBulb, results.FsDryBulb, "FsDryBulb value does not match");
            Assert.AreEqual(data.FsWetBulb, results.FsWetBulb, "FsWetBulb value does not match");
            Assert.AreEqual(data.WsDryBulb, results.WsDryBulb, "WsDryBulb value does not match");
            Assert.AreEqual(data.WsWetBulb, results.WsWetBulb, "WsWetBulb value does not match");
            Assert.AreEqual(data.HumidityRatio, results.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(data.DegreeOfSaturation, results.DegreeOfSaturation, "DegreeOfSaturation value does not match");
            Assert.AreEqual(data.RelativeHumidity, results.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(data.SpecificVolume, results.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(data.Density, results.Density, "Density value does not match");
            Assert.AreEqual(data.Enthalpy, results.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(data.DewPoint, results.DewPoint, "DewPoint value does not match");
        }
    }
}
