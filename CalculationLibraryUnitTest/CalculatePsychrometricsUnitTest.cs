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
            Assert.AreEqual(0.017610985758276562, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(0.42378506379695186, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(83.252699572165255, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(0.90581034670121607, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(1.1234261006889759, data.Density, "Density value does not match");
            Assert.AreEqual(22.811155753778316, data.DewPoint, "DewPoint value does not match");
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
            Assert.AreEqual(0.041998294700755306, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(0.48108196403985881, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(145.90840055728816, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(1.9056175210999049, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(0.54680348137191959, data.Density, "Density value does not match");
            Assert.AreEqual(24.920001232093771, data.DewPoint, "DewPoint value does not match");
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
            Assert.AreEqual(-0.016774900099674923, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(-0.071775980133913106, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(-5.0912742342941044, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(5.1086335055832794, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(0.19246342467623639, data.Density, "Density value does not match");
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
            Assert.AreEqual(26.670733489990237, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(0.017612283670676101, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(0.42381543629872326, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(83.256034159486973, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(0.90581218488333071, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(1.1234252537701790, data.Density, "Density value does not match");
            Assert.AreEqual(22.812337573897800, data.DewPoint, "DewPoint value does not match");
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
            Assert.AreEqual(21.037853546142578, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(0.025540763255913149, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(0.30000015135136049, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(103.62582761767295, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(1.8583835501226105, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(0.55184558816625939, data.Density, "Density value does not match");
            Assert.AreEqual(17.237738645888719, data.DewPoint, "DewPoint value does not match");
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
            Assert.AreEqual(0.0030103576948265921, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(0.65493842433243998, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(-10.676901926743609, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(4.3292105293877388, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(0.23168435697135709, data.Density, "Density value does not match");
            Assert.AreEqual(-22.402174563150034, data.DewPoint, "DewPoint value does not match");
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
            Assert.AreEqual(79.782667160034180, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(79.782667160034180, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(0.022174115780745542, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(1.0000000000000000, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(43.46, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(14.084974673263400, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(0.072571952700850276, data.Density, "Density value does not match");
            Assert.AreEqual(79.782667159095979, data.DewPoint, "DewPoint value does not match");
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
            Assert.AreEqual(58.713960647583008, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(58.713960647583008, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(0.027016285868664093, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(1.0000000000000000, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(43.46, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(34.001777821177164, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(0.030204781975518128, data.Density, "Density value does not match");
            Assert.AreEqual(58.713960647587690, data.DewPoint, "DewPoint value does not match");
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
            Assert.AreEqual(15.475339889526367, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(15.475339889526367, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(0.011029090587771405, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(1.0, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(43.46, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(0.83217877527025974, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(1.2149181409480529, data.Density, "Density value does not match");
            Assert.AreEqual(15.475339889526923, data.DewPoint, "DewPoint value does not match");
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
            Assert.AreEqual(15.344457626342773, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(15.344457626342773, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(0.011082174565123016, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(1.0, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(43.46, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(0.84289345910625613, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(1.1995373361150556, data.Density, "Density value does not match");
            Assert.AreEqual(15.344457626342917, data.DewPoint, "DewPoint value does not match");
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
                BarometricPressure = 17,
            };

            PsychrometricsCalculationLibrary psychrometricsCalculationLibrary = new PsychrometricsCalculationLibrary();
            psychrometricsCalculationLibrary.PsychrometricsCalculation(PsychrometricsCalculationType.Enthalpy, data, out errorMessage);

            Assert.IsFalse(string.IsNullOrEmpty(errorMessage), "errorMessage is empty");
            Assert.AreEqual(16.999999959027324, data.PressurePSI, "PressurePSI value does not match");
            Assert.AreEqual(17, data.BarometricPressure, "BarometricPressure value does not match");
            Assert.AreEqual(12766.147400000000, data.Elevation, "Elevation value does not match");
            Assert.AreEqual(60.0, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(60.0, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(-4.2024602485023328, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(1.0000000000000000, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(43.46, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(-32.384022064045553, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(0.098890132984990553, data.Density, "Density value does not match");
            Assert.AreEqual(0.0, data.DewPoint, "DewPoint value does not match");
        }
    }
}
