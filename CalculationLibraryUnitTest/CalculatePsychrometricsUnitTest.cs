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
                Elevation = 0,
                IsElevation = true
            };

            PsychrometricsCalculationLibrary psychrometricsCalculationLibrary = new PsychrometricsCalculationLibrary();
            psychrometricsCalculationLibrary.PsychrometricsCalculation(PsychrometricsCalculationType.WetBulbTemperature_DryBulbTemperature, data, out errorMessage);

            Assert.IsTrue(string.IsNullOrEmpty(errorMessage), "errorMessage is not empty");
            Assert.AreEqual(14.696000000000000, data.PressurePSI, "PressurePSI value does not match");
            Assert.AreEqual(29.9210, data.BarometricPressure, "BarometricPressure value does not match");
            Assert.AreEqual(0.0, data.Elevation, "Elevation value does not match");
            Assert.AreEqual(100, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(80, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(0.017611081475212367, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(0.42383992095343836, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(43.467289462699753, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(14.509328343623606, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(0.070134954380739509, data.Density, "Density value does not match");
            Assert.AreEqual(73.060344595630482, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void IP_Pressure_Psychrometrics_WetBulbTemperature_DryBulbTemperature_CalculationTest()
        {
            string errorMessage;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = false,
                BarometricPressure = 12,
                DryBulbTemperature = 100,
                WetBulbTemperature = 80,
                Elevation = 0,
                IsElevation = false
            };

            PsychrometricsCalculationLibrary psychrometricsCalculationLibrary = new PsychrometricsCalculationLibrary();
            psychrometricsCalculationLibrary.PsychrometricsCalculation(PsychrometricsCalculationType.WetBulbTemperature_DryBulbTemperature, data, out errorMessage);

            Assert.IsTrue(string.IsNullOrEmpty(errorMessage), "errorMessage is not empty");
            Assert.AreEqual(5.8939206622609923, data.PressurePSI, "PressurePSI value does not match");
            Assert.AreEqual(12, data.BarometricPressure, "BarometricPressure value does not match");
            Assert.AreEqual(23207.2565, data.Elevation, "Elevation value does not match");
            Assert.AreEqual(100, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(80, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(0.053709030831886516, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(0.49157258508919321, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(83.369962681567358, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(38.219682474076620, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(0.027569800757674765, data.Density, "Density value does not match");
            Assert.AreEqual(77.502677247640321, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void SI_Psychrometrics_WetBulbTemperature_DryBulbTemperature_CalculationTest()
        {
            string errorMessage;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                BarometricPressure = 0.0,
                DryBulbTemperature = 37.78,
                WetBulbTemperature = 26.67,
                Elevation = 0,
                IsElevation = true
            };

            PsychrometricsCalculationLibrary psychrometricsCalculationLibrary = new PsychrometricsCalculationLibrary();
            psychrometricsCalculationLibrary.PsychrometricsCalculation(PsychrometricsCalculationType.WetBulbTemperature_DryBulbTemperature, data, out errorMessage);

            Assert.IsTrue(string.IsNullOrEmpty(errorMessage), "errorMessage is not empty");
            Assert.AreEqual(101.32500000000000, data.PressurePSI, "PressurePSI value does not match");
            Assert.AreEqual(101.32500000000000, data.BarometricPressure, "BarometricPressure value does not match");
            Assert.AreEqual(0, data.Elevation, "Elevation value does not match");
            Assert.AreEqual(37.78, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(26.67, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(0.017639664871541238, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(0.42445615618351601, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(83.326381746343174, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(0.90585096379762986, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(1.1234073876846760, data.Density, "Density value does not match");
            Assert.AreEqual(22.837251296241423, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void SI_Pressure_Psychrometrics_WetBulbTemperature_DryBulbTemperature_CalculationTest()
        {
            string errorMessage;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                IsElevation = false,
                BarometricPressure = 50,
                DryBulbTemperature = 37.78,
                WetBulbTemperature = 26.67,
                Elevation = 0
            };

            PsychrometricsCalculationLibrary psychrometricsCalculationLibrary = new PsychrometricsCalculationLibrary();
            psychrometricsCalculationLibrary.PsychrometricsCalculation(PsychrometricsCalculationType.WetBulbTemperature_DryBulbTemperature, data, out errorMessage);

            Assert.IsTrue(string.IsNullOrEmpty(errorMessage), "errorMessage is not empty");
            Assert.AreEqual(49.999999760425993, data.PressurePSI, "PressurePSI value does not match");
            Assert.AreEqual(50, data.BarometricPressure, "BarometricPressure value does not match");
            Assert.AreEqual(5574.4067, data.Elevation, "Elevation value does not match");
            Assert.AreEqual(37.78, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(26.67, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(0.042032914186369390, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(0.48145342050663797, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(145.99734469392951, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(1.9057168808237024, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(0.54679313840992716, data.Density, "Density value does not match");
            Assert.AreEqual(24.932933473526944, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void SI_Pressure_Psychrometrics_WetBulbTemperature_DryBulbTemperature_Calculation_ErrorTest()
        {
            string errorMessage;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                IsElevation = false,
                BarometricPressure = 17,
                DryBulbTemperature = 37.78,
                WetBulbTemperature = -18,
                Elevation = 0
            };

            PsychrometricsCalculationLibrary psychrometricsCalculationLibrary = new PsychrometricsCalculationLibrary();
            psychrometricsCalculationLibrary.PsychrometricsCalculation(PsychrometricsCalculationType.WetBulbTemperature_DryBulbTemperature, data, out errorMessage);

            Assert.IsFalse(string.IsNullOrEmpty(errorMessage), "errorMessage is empty");
            Assert.AreEqual(16.999999959027324, data.PressurePSI, "PressurePSI value does not match");
            Assert.AreEqual(17, data.BarometricPressure, "BarometricPressure value does not match");
            Assert.AreEqual(12766.147400000000, data.Elevation, "Elevation value does not match");
            Assert.AreEqual(37.78, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(-18, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(-0.016659800536511421, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(-0.071269940983315655, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(-4.7955612538213330, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(5.1096050989075241, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(0.19244935380108630, data.Density, "Density value does not match");
            Assert.AreEqual(0.0000000000000000, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void IP_Psychrometrics_DryBulbTemperature_RelativeHumidity_CalculationTest()
        {
            string errorMessage;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = false,
                RelativeHumidity = 42.38,
                DryBulbTemperature = 100,
                Elevation = 0,
                IsElevation = true
            };

            PsychrometricsCalculationLibrary psychrometricsCalculationLibrary = new PsychrometricsCalculationLibrary();
            psychrometricsCalculationLibrary.PsychrometricsCalculation(PsychrometricsCalculationType.DryBulbTemperature_RelativeHumidity, data, out errorMessage);

            Assert.IsTrue(string.IsNullOrEmpty(errorMessage), "errorMessage is not empty");
            Assert.AreEqual(14.696000000000000, data.PressurePSI, "PressurePSI value does not match");
            Assert.AreEqual(29.9210, data.BarometricPressure, "BarometricPressure value does not match");
            Assert.AreEqual(0.0, data.Elevation, "Elevation value does not match");
            Assert.AreEqual(100, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(79.998397827148438, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(0.017609507138849852, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(0.42380307511445447, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(43.465549191284623, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(14.509292628624149, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(0.070135018514361935, data.Density, "Density value does not match");
            Assert.AreEqual(73.057764082025201, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void IP_Pressure_Psychrometrics_DryBulbTemperature_RelativeHumidity_CalculationTest()
        {
            string errorMessage;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = false,
                RelativeHumidity = 42.38,
                BarometricPressure = 12,
                DryBulbTemperature = 100,
                Elevation = 0,
                IsElevation = false
            };

            PsychrometricsCalculationLibrary psychrometricsCalculationLibrary = new PsychrometricsCalculationLibrary();
            psychrometricsCalculationLibrary.PsychrometricsCalculation(PsychrometricsCalculationType.DryBulbTemperature_RelativeHumidity, data, out errorMessage);

            Assert.IsTrue(string.IsNullOrEmpty(errorMessage), "errorMessage is not empty");
            Assert.AreEqual(5.8939206622609923, data.PressurePSI, "PressurePSI value does not match");
            Assert.AreEqual(12, data.BarometricPressure, "BarometricPressure value does not match");
            Assert.AreEqual(23207.2565, data.Elevation, "Elevation value does not match");
            Assert.AreEqual(100, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(76.393508911132812, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(0.045759835271935952, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(0.42380333899392653, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(74.582921909598014, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(37.770036032916259, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(0.027687551962104703, data.Density, "Density value does not match");
            Assert.AreEqual(73.058753392525887, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void SI_Psychrometrics_DryBulbTemperature_RelativeHumidity_CalculationTest()
        {
            string errorMessage;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                RelativeHumidity = 42.38,
                DryBulbTemperature = 37.78,
                Elevation = 0,
                IsElevation = true
            };

            PsychrometricsCalculationLibrary psychrometricsCalculationLibrary = new PsychrometricsCalculationLibrary();
            psychrometricsCalculationLibrary.PsychrometricsCalculation(PsychrometricsCalculationType.DryBulbTemperature_RelativeHumidity, data, out errorMessage);

            Assert.IsTrue(string.IsNullOrEmpty(errorMessage), "errorMessage is not empty");
            Assert.AreEqual(101.32500000000000, data.PressurePSI, "PressurePSI value does not match");
            Assert.AreEqual(101.32500000000000, data.BarometricPressure, "BarometricPressure value does not match");
            Assert.AreEqual(0, data.Elevation, "Elevation value does not match");
            Assert.AreEqual(37.78, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(26.653982086181642, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(0.017611367066026447, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(0.42379398680817371, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(83.253679225328980, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(0.90581088673233545, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(1.1234258518762181, data.Density, "Density value does not match");
            Assert.AreEqual(22.811502963486326, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void SI_Pressure_Psychrometrics_DryBulbTemperature_RelativeHumidity_CalculationTest()
        {
            string errorMessage;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                IsElevation = false,
                RelativeHumidity = 30,
                DryBulbTemperature = 37.78,
                BarometricPressure = 50,
                Elevation = 0
            };

            PsychrometricsCalculationLibrary psychrometricsCalculationLibrary = new PsychrometricsCalculationLibrary();
            psychrometricsCalculationLibrary.PsychrometricsCalculation(PsychrometricsCalculationType.DryBulbTemperature_RelativeHumidity, data, out errorMessage);

            Assert.IsTrue(string.IsNullOrEmpty(errorMessage), "errorMessage is not empty");
            Assert.AreEqual(49.999999760425993, data.PressurePSI, "PressurePSI value does not match");
            Assert.AreEqual(50, data.BarometricPressure, "BarometricPressure value does not match");
            Assert.AreEqual(5574.4067, data.Elevation, "Elevation value does not match");
            Assert.AreEqual(37.78, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(21.019338836669924, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(0.025540973006916518, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(0.30000251789343241, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(103.62636650846157, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(1.8583841521188964, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(0.55184552227138450, data.Density, "Density value does not match");
            Assert.AreEqual(17.237863244192727, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void SI_Pressure_Psychrometrics_DryBulbTemperature_RelativeHumidity_Calculation_ErrorTest()
        {
            string errorMessage;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                IsElevation = false,
                RelativeHumidity = 0.044,
                DryBulbTemperature = -18,
                BarometricPressure = 17,
                Elevation = 0
            };

            PsychrometricsCalculationLibrary psychrometricsCalculationLibrary = new PsychrometricsCalculationLibrary();
            psychrometricsCalculationLibrary.PsychrometricsCalculation(PsychrometricsCalculationType.DryBulbTemperature_RelativeHumidity, data, out errorMessage);

            Assert.IsFalse(string.IsNullOrEmpty(errorMessage), "errorMessage is empty");
            Assert.AreEqual(16.999999959027324, data.PressurePSI, "PressurePSI value does not match");
            Assert.AreEqual(17, data.BarometricPressure, "BarometricPressure value does not match");
            Assert.AreEqual(12766.1474, data.Elevation, "Elevation value does not match");
            Assert.AreEqual(-18, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(-19.999511718750000, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(0.0030155302329988795, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(0.65605834067307001, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(-10.664133464539937, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(4.3292463594445643, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(0.23168363427617092, data.Density, "Density value does not match");
            Assert.AreEqual(-22.384709428732208, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void IP_Psychrometrics_Enthalpy_CalculationTest()
        {
            string errorMessage;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = false,
                RootEnthalpy = 43.46,
                Elevation = 0,
                IsElevation = true
            };

            PsychrometricsCalculationLibrary psychrometricsCalculationLibrary = new PsychrometricsCalculationLibrary();
            psychrometricsCalculationLibrary.PsychrometricsCalculation(PsychrometricsCalculationType.Enthalpy, data, out errorMessage);

            Assert.IsTrue(string.IsNullOrEmpty(errorMessage), "errorMessage is not empty");
            Assert.AreEqual(14.696000000000000, data.PressurePSI, "PressurePSI value does not match");
            Assert.AreEqual(29.9210, data.BarometricPressure, "BarometricPressure value does not match");
            Assert.AreEqual(0.0, data.Elevation, "Elevation value does not match");
            Assert.AreEqual(79.782333374023438, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(79.782333374023438, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(0.022173864755881373, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(1.0000000000000000, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(43.459703221299804, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(14.084960469223194, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(0.072572008064162905, data.Density, "Density value does not match");
            Assert.AreEqual(79.782333373085351, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void IP_Pressure_Psychrometrics_Enthalpy_CalculationTest()
        {
            string errorMessage;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = false,
                BarometricPressure = 12,
                RootEnthalpy = 43.46,
                IsElevation = false
            };

            PsychrometricsCalculationLibrary psychrometricsCalculationLibrary = new PsychrometricsCalculationLibrary();
            psychrometricsCalculationLibrary.PsychrometricsCalculation(PsychrometricsCalculationType.Enthalpy, data, out errorMessage);

            Assert.IsTrue(string.IsNullOrEmpty(errorMessage), "errorMessage is not empty");
            Assert.AreEqual(5.8939206622609923, data.PressurePSI, "PressurePSI value does not match");
            Assert.AreEqual(12, data.BarometricPressure, "BarometricPressure value does not match");
            Assert.AreEqual(23207.2565, data.Elevation, "Elevation value does not match");
            Assert.AreEqual(58.713760375976562, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(58.713760375976562, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(0.027016083547215367, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(1.0000000000000000, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(43.459646973755603, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(34.001754084903290, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(0.030204797110841067, data.Density, "Density value does not match");
            Assert.AreEqual(58.713760375981458, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void SI_Psychrometrics_Enthalpy_CalculationTest()
        {
            string errorMessage;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                RootEnthalpy = 43.46,
                Elevation = 0,
                IsElevation = true
            };

            PsychrometricsCalculationLibrary psychrometricsCalculationLibrary = new PsychrometricsCalculationLibrary();
            psychrometricsCalculationLibrary.PsychrometricsCalculation(PsychrometricsCalculationType.Enthalpy, data, out errorMessage);

            Assert.IsTrue(string.IsNullOrEmpty(errorMessage), "errorMessage is not empty");
            Assert.AreEqual(101.32500000000000, data.PressurePSI, "PressurePSI value does not match");
            Assert.AreEqual(101.32500000000000, data.BarometricPressure, "BarometricPressure value does not match");
            Assert.AreEqual(0, data.Elevation, "Elevation value does not match");
            Assert.AreEqual(15.475639343261719, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(15.475639343261719, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(0.011029306298183390, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(1.0, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(43.460875678569025, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(0.83217992225714477, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(1.2149167256474303, data.Density, "Density value does not match");
            Assert.AreEqual(15.475639343262369, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void SI_Pressure_Psychrometrics_Enthalpy_CalculationTest()
        {
            string errorMessage;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                IsElevation = false,
                RootEnthalpy = 43.46,
                BarometricPressure = 100,
            };

            PsychrometricsCalculationLibrary psychrometricsCalculationLibrary = new PsychrometricsCalculationLibrary();
            psychrometricsCalculationLibrary.PsychrometricsCalculation(PsychrometricsCalculationType.Enthalpy, data, out errorMessage);

            Assert.IsTrue(string.IsNullOrEmpty(errorMessage), "errorMessage is not empty");
            Assert.AreEqual(99.999999870085546, data.PressurePSI, "PressurePSI value does not match");
            Assert.AreEqual(100, data.BarometricPressure, "BarometricPressure value does not match");
            Assert.AreEqual(110.88360000000000, data.Elevation, "Elevation value does not match");
            Assert.AreEqual(15.345222473144531, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(15.345222473144531, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(0.011082728793060619, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(1.0, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(43.462169344212974, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(0.84289643170235762, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(1.1995337633011747, data.Density, "Density value does not match");
            Assert.AreEqual(15.345222473144966, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void SI_Pressure_Psychrometrics_Enthalpy_Calculation_ErrorTest()
        {
            string errorMessage;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                IsElevation = false,
                RootEnthalpy = 43.46,
                BarometricPressure = 50,
            };

            PsychrometricsCalculationLibrary psychrometricsCalculationLibrary = new PsychrometricsCalculationLibrary();
            psychrometricsCalculationLibrary.PsychrometricsCalculation(PsychrometricsCalculationType.Enthalpy, data, out errorMessage);

            Assert.IsFalse(string.IsNullOrEmpty(errorMessage), "errorMessage is empty");
            Assert.AreEqual(49.999999760425993, data.PressurePSI, "PressurePSI value does not match");
            Assert.AreEqual(50, data.BarometricPressure, "BarometricPressure value does not match");
            Assert.AreEqual(5574.4067, data.Elevation, "Elevation value does not match");
            Assert.AreEqual(93.000000000000000, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(93.000000000000000, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(-1.7288444818515576, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(1.0000000000000000, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(-4520.4945280567572, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(-3.7409798858205607, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(0.19482715868484016, data.Density, "Density value does not match");
            //Assert.AreEqual(92.999999759362794, data.DewPoint, "DewPoint value does not match");
            Assert.AreEqual(0, data.DewPoint, "DewPoint value does not match");
        }
    }
}
