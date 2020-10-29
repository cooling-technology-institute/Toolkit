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
                DryBulbTemperature = 40,
                WetBulbTemperature = 13,
                BarometricPressure = 14.56
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.CalculateProperties(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.059315162287052359, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(0.092377431185608816, data.DegreeOfSaturation, "DegreeOfSaturation value does not match");
            Assert.AreEqual(0.17139719082091084, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(6.7626323439709850, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(0.15664242981232773, data.Density, "Density value does not match");
            Assert.AreEqual(192.86977559704312, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(10.457871298859809, data.DewPoint, "DewPoint value does not match");
            Assert.AreEqual(7.3834598538015586, data.SaturationVaporPressureDryBulb, "SaturationVaporPressureDryBulb value does not match");
            Assert.AreEqual(1.4978108118095652, data.SaturationVaporPressureWetBulb, "SaturationVaporPressureWetBulb value does not match");
            Assert.AreEqual(1.0016780922074051, data.FsDryBulb, "FsDryBulb value does not match");
            Assert.AreEqual(1.0012003737919406, data.FsWetBulb, "FsWetBulb value does not match");
            Assert.AreEqual(0.64209581848919040, data.WsDryBulb, "WsDryBulb value does not match");
            Assert.AreEqual(0.071416439887867028, data.WsWetBulb, "WsWetBulb value does not match");
        }

        [TestMethod]
        public void SI_CalculateProperties_HumidityRatioZeroTest()
        {
            bool methodThrew = false;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                DryBulbTemperature = 50,
                WetBulbTemperature = (2501.0 + 1.805 * 50) / 4.186,
                BarometricPressure = 14
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.CalculateProperties(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.0, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(0.21582111084374225, data.DegreeOfSaturation, "DegreeOfSaturation value does not match");
            Assert.AreEqual(0.0, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(6.6258445178571419, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(0.15092415726099909, data.Density, "Density value does not match");
            Assert.AreEqual(50.299999999999997, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(0.0, data.DewPoint, "DewPoint value does not match");
            Assert.AreEqual(12.349856207156227, data.SaturationVaporPressureDryBulb, "SaturationVaporPressureDryBulb value does not match");
            Assert.AreEqual(169166.66853760454, data.SaturationVaporPressureWetBulb, "SaturationVaporPressureWetBulb value does not match");
            Assert.AreEqual(1.0012841881631684, data.FsDryBulb, "FsDryBulb value does not match");
            Assert.AreEqual(-283.69372867183989, data.FsWetBulb, "FsWetBulb value does not match");
            Assert.AreEqual(4.7061751115492703 , data.WsDryBulb, "WsDryBulb value does not match");
            Assert.AreEqual(-0.62197981855717588, data.WsWetBulb, "WsWetBulb value does not match");
        }

        [TestMethod]
        public void IP_CalculatePropertiesTest()
        {
            bool methodThrew = false;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = false,
                DryBulbTemperature = 90,
                WetBulbTemperature = 70,
                BarometricPressure = 29.145
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.CalculateProperties(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.0033265968119200531, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(0.21582111084374225, data.DegreeOfSaturation, "DegreeOfSaturation value does not match");
            Assert.AreEqual(0.21999289954058668, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(7.0249432881313369, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(0.14282344435535066, data.Density, "Density value does not match");
            Assert.AreEqual(25.262450026051500, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(46.137187274280663, data.DewPoint, "DewPoint value does not match");
            Assert.AreEqual(0.69888797756930821, data.SaturationVaporPressureDryBulb, "SaturationVaporPressureDryBulb value does not match");
            Assert.AreEqual(0.36327716067983784, data.SaturationVaporPressureWetBulb, "SaturationVaporPressureWetBulb value does not match");
            Assert.AreEqual(1.0084514220198235, data.FsDryBulb, "FsDryBulb value does not match");
            Assert.AreEqual(1.0072761896919915, data.FsWetBulb, "FsWetBulb value does not match");
            Assert.AreEqual(0.015413676627438729, data.WsDryBulb, "WsDryBulb value does not match");
            Assert.AreEqual(0.0079083554826944250, data.WsWetBulb, "WsWetBulb value does not match");
        }

        [TestMethod]
        public void IP_CalculateProperties_HumidityRatioZeroTest()
        {
            bool methodThrew = false;

            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = false,
                DryBulbTemperature = 0,
                WetBulbTemperature = 1093.0,
                BarometricPressure = 29.145
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.CalculateProperties(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.0, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(0.0, data.DegreeOfSaturation, "DegreeOfSaturation value does not match");
            Assert.AreEqual(0.0, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(5.8434632012352035, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(0.17113139341557210, data.Density, "Density value does not match");
            Assert.AreEqual(0.0, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(0.0, data.DewPoint, "DewPoint value does not match");
            Assert.AreEqual(0.018497445338518818, data.SaturationVaporPressureDryBulb, "SaturationVaporPressureDryBulb value does not match");
            Assert.AreEqual(20383.720021359124, data.SaturationVaporPressureWetBulb, "SaturationVaporPressureWetBulb value does not match");
            Assert.AreEqual(1.0084913005364999, data.FsDryBulb, "FsDryBulb value does not match");
            Assert.AreEqual(-151.34434429529546, data.FsWetBulb, "FsWetBulb value does not match");
            Assert.AreEqual(0.00039835872364996306, data.WsDryBulb, "WsDryBulb value does not match");
            Assert.AreEqual(-0.62197412393305318, data.WsWetBulb, "WsWetBulb value does not match");
        }
    }
}
