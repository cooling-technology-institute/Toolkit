using CalculationLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System;

namespace CalculationLibraryUnitTest
{
    [TestClass]
    public class CalculatePsychrometricsUnitTest
    {
        [TestMethod]
        public void IP_Psychrometrics_WetBulbTemperature_DryBulbTemperature_CalculationTest()
        {
            string errorMessage;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = false,
                BarometricPressure = 0.0,
                DryBulbTemperature = 100,
                WetBulbTemperature = 80,
                Elevation = 0
            };

            PsychrometricsCalculationLibrary psychrometricsCalculationLibrary = new PsychrometricsCalculationLibrary();
            psychrometricsCalculationLibrary.Psychrometrics_WetBulbTemperature_DryBulbTemperature_Calculation(true, data, out errorMessage);

            Assert.IsTrue(string.IsNullOrEmpty(errorMessage), "errorMessage is not empty");
            Assert.AreEqual(29.9210, data.BarometricPressure, "BarometricPressure value does not match");
            Assert.AreEqual(0.0000000000000000, data.Elevation, "Elevation value does not match");
            Assert.AreEqual(100, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(80, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(0.017611081475212367, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(0.42383992095343836, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(43.467289462699753, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(14.509328343623606, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(0.070134954380739509, data.Density, "Density value does not match");
            Assert.AreEqual(73.060344595630482, data.DewPoint, "DewPoint value does not match");

            //Assert.AreEqual(0.42383992095343836, data.DegreeOfSaturation, "DegreeOfSaturation value does not match");
            //Assert.AreEqual(7.3834598538015586, data.SaturationVaporPressureDryBulb, "SaturationVaporPressureDryBulb value does not match");
            //Assert.AreEqual(1.4978108118095652, data.SaturationVaporPressureWetBulb, "SaturationVaporPressureWetBulb value does not match");
            //Assert.AreEqual(1.0016780922074051, data.FsDryBulb, "FsDryBulb value does not match");
            //Assert.AreEqual(1.0012003737919406, data.FsWetBulb, "FsWetBulb value does not match");
            //Assert.AreEqual(0.64209581848919040, data.WsDryBulb, "WsDryBulb value does not match");
            //Assert.AreEqual(0.071416439887867028, data.WsWetBulb, "WsWetBulb value does not match");
        }

        [TestMethod]
        public void IP_Pressure_Psychrometrics_WetBulbTemperature_DryBulbTemperature_CalculationTest()
        {
            string errorMessage;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = false,
                BarometricPressure = 29.921,
                DryBulbTemperature = 100,
                WetBulbTemperature = 80,
                Elevation = 0
            };

            PsychrometricsCalculationLibrary psychrometricsCalculationLibrary = new PsychrometricsCalculationLibrary();
            psychrometricsCalculationLibrary.Psychrometrics_WetBulbTemperature_DryBulbTemperature_Calculation(false, data, out errorMessage);

            Assert.IsTrue(string.IsNullOrEmpty(errorMessage), "errorMessage is not empty");
            Assert.AreEqual(29.9210, data.BarometricPressure, "BarometricPressure value does not match");
            Assert.AreEqual(0.0000000000000000, data.Elevation, "Elevation value does not match");
            Assert.AreEqual(100, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(80, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(0.017611081475212367, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(0.42383992095343836, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(43.467289462699753, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(14.509328343623606, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(0.070134954380739509, data.Density, "Density value does not match");
            Assert.AreEqual(73.060344595630482, data.DewPoint, "DewPoint value does not match");

            //Assert.AreEqual(0.42383992095343836, data.DegreeOfSaturation, "DegreeOfSaturation value does not match");
            //Assert.AreEqual(7.3834598538015586, data.SaturationVaporPressureDryBulb, "SaturationVaporPressureDryBulb value does not match");
            //Assert.AreEqual(1.4978108118095652, data.SaturationVaporPressureWetBulb, "SaturationVaporPressureWetBulb value does not match");
            //Assert.AreEqual(1.0016780922074051, data.FsDryBulb, "FsDryBulb value does not match");
            //Assert.AreEqual(1.0012003737919406, data.FsWetBulb, "FsWetBulb value does not match");
            //Assert.AreEqual(0.64209581848919040, data.WsDryBulb, "WsDryBulb value does not match");
            //Assert.AreEqual(0.071416439887867028, data.WsWetBulb, "WsWetBulb value does not match");
        }
    }
}
