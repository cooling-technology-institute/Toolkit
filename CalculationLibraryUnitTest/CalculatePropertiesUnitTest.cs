﻿using System;
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

                results.SaturationVaporPressureDryBulbTemperature = CalculationLibrary.CalculateVaporPressure(true, data.DryBulbTemperature);
                results.SaturationVaporPressureWetBulbTemperature = CalculationLibrary.CalculateVaporPressure(true, data.WetBulbTemperature);
                results.FsDryBulbTemperature = CalculationLibrary.Fs(UnitConverter.ConvertCelsiusToFahrenheit(data.DryBulbTemperature), UnitConverter.ConvertKilopascalToBarometricPressure(data.BarometricPressure));
                results.FsWetBulbTemperature = CalculationLibrary.Fs(UnitConverter.ConvertCelsiusToFahrenheit(data.WetBulbTemperature), UnitConverter.ConvertKilopascalToBarometricPressure(data.BarometricPressure));
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
            Assert.AreEqual(data.SaturationVaporPressureDryBulbTemperature, results.SaturationVaporPressureDryBulbTemperature, "SaturationVaporPressureDryBulbTemperature value does not match");
            Assert.AreEqual(data.SaturationVaporPressureWetBulbTemperature, results.SaturationVaporPressureWetBulbTemperature, "SaturationVaporPressureWetBulbTemperature value does not match");
            Assert.AreEqual(data.FsDryBulbTemperature, results.FsDryBulbTemperature, "FsDryBulbTemperature value does not match");
            Assert.AreEqual(data.FsWetBulbTemperature, results.FsWetBulbTemperature, "FsWetBulbTemperature value does not match");
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

                results.SaturationVaporPressureDryBulbTemperature = CalculationLibrary.CalculateVaporPressure(false, data.DryBulbTemperature);
                results.SaturationVaporPressureWetBulbTemperature = CalculationLibrary.CalculateVaporPressure(false, data.WetBulbTemperature);
                results.FsDryBulbTemperature = CalculationLibrary.Fs(data.DryBulbTemperature, data.BarometricPressure);
                results.FsWetBulbTemperature = CalculationLibrary.Fs(data.WetBulbTemperature, data.BarometricPressure);
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
            Assert.AreEqual(data.SaturationVaporPressureDryBulbTemperature, results.SaturationVaporPressureDryBulbTemperature, "SaturationVaporPressureDryBulbTemperature value does not match");
            Assert.AreEqual(data.SaturationVaporPressureWetBulbTemperature, results.SaturationVaporPressureWetBulbTemperature, "SaturationVaporPressureWetBulbTemperature value does not match");
            Assert.AreEqual(data.FsDryBulbTemperature, results.FsDryBulbTemperature, "FsDryBulbTemperature value does not match");
            Assert.AreEqual(data.FsWetBulbTemperature, results.FsWetBulbTemperature, "FsWetBulbTemperature value does not match");
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
