using System;
using CalculationLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace CalculationLibraryUnitTest
{
    [TestClass]
    public class EnthalpySearchUnitTest
    {
        CalculationLibrary.CalculationLibrary CalculationLibrary { get; set; }

        [TestMethod]
        public void SI_EnthalpySearchUnitTest()
        {
            bool methodThrew = false;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                BarometricPressure = 98.8,
                RootEnthalpy = 169.660507
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.EnthalpySearch(true, data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(169.660507, data.RootEnthalpy, "RootEnthalpy value does not match");
            Assert.AreEqual(169.66052206096091, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(39.941644668579102, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(39.941644668579102, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(0.050320428977248283, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(1.0, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(0.98325745909103257, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(1.0682048930991195, data.Density, "Density value does not match");
            Assert.AreEqual(39.941644668620228, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void SI_EnthalpySearch_MidPoint_Zero_UnitTest()
        {
            bool methodThrew = false;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                BarometricPressure = 98.8,
                RootEnthalpy = 58.537578190586729
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.EnthalpySearch(true, data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(58.537578190586729, data.RootEnthalpy, "RootEnthalpy value does not match");
            Assert.AreEqual(58.537578190586729, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(20.0, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(20.0, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(0.015142319258439448, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(0.99999999999999989, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(0.87245828235790901, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(1.1635425323889550, data.Density, "Density value does not match");
            Assert.AreEqual(19.999999999534658, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void SI_EnthalpySearch_RootEnthaply_LowTemperatureLessThanHtolerance_UnitTest()
        {
            bool methodThrew = false;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                BarometricPressure = 101.325,
                RootEnthalpy = -18.549065779718866
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.EnthalpySearch(true, data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(-18.549065779718866, data.RootEnthalpy, "RootEnthalpy value does not match");
            Assert.AreEqual(0.0, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(-20.0, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(-20.0, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(0.00063732168456372888, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(1.0, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(0.71791201668518922, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(1.3938160922626706, data.Density, "Density value does not match");
            Assert.AreEqual(-19.999999999994323, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void SI_EnthalpySearch_RootEnthaply_HighTemperatureLessThanHtolerance_UnitTest()
        {
            bool methodThrew = false;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                BarometricPressure = 101.325,
                RootEnthalpy = 460.97747901630419
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.EnthalpySearch(true, data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(460.97747901630419, data.RootEnthalpy, "RootEnthalpy value does not match");
            Assert.AreEqual(0.0, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(60.0, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(60.0, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(0.15353446480523672, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(0.99999999999999978, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(1.1768022106183109, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(0.98022798937397571, data.Density, "Density value does not match");
            Assert.AreEqual(60.000000003612605, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void SI_EnthalpySearch_RootEnthaply_LowTemperatureLessThanEnthalpy_UnitTest()
        {
            bool methodThrew = false;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                BarometricPressure = 101.325,
                RootEnthalpy = -19.0
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.EnthalpySearch(true, data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(-19.0, data.RootEnthalpy, "RootEnthalpy value does not match");
            Assert.AreEqual(0.0, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(-20.0, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(-20.0, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(0.00063732168456372888, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(1.0, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(0.71791201668518922, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(1.3938160922626706, data.Density, "Density value does not match");
            Assert.AreEqual(-19.999999999994323, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void SI_EnthalpySearch_RootEnthaply_HighTemperatureLessThanEnthalpy_UnitTest()
        {
            bool methodThrew = false;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                BarometricPressure = 101.325,
                RootEnthalpy = 470.0
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.EnthalpySearch(true, data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(470.0, data.RootEnthalpy, "RootEnthalpy value does not match");
            Assert.AreEqual(0.0, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(60.0, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(60.0, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(0.15353446480523672, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(0.99999999999999978, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(1.1768022106183109, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(0.98022798937397571, data.Density, "Density value does not match");
            Assert.AreEqual(60.000000003612605, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void SI_EnthalpySearch_SaturationFalse_UnitTest()
        {
            bool methodThrew = false;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = true,
                BarometricPressure = 98.8,
                RootEnthalpy = 169.660507
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.EnthalpySearch(false, data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(169.660507, data.RootEnthalpy, "RootEnthalpy value does not match");
            Assert.AreEqual(169.66044916375441, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(39.609231948852539, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(0.0, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(0.067837044847562741, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(15.834671752095273, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(0.88017232257297717, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(1.2132136144953884, data.Density, "Density value does not match");
            Assert.AreEqual(45.151339804038024, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void IP_EnthalpySearchUnitTest()
        {
            bool methodThrew = false;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI = false,
                BarometricPressure = 29.921,
                RootEnthalpy = 69.0
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.EnthalpySearch(true, data);
            }
            catch
            {
                methodThrew  = false;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(69.0, data.RootEnthalpy, "RootEnthalpy value does not match");
            Assert.AreEqual(69.000029576930075, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(118.71466636657715, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(118.71466636657715, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(0.036372605685636793, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(1.0, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(7.5807379505126962, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(0.13671130864186454, data.Density, "Density value does not match");
            Assert.AreEqual(118.71466636750331, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void IP_EnthalpySearch_MidPoint_Zero_UnitTest()
        {
            bool methodThrew = false;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI  = false,
                BarometricPressure = 29.921,
                RootEnthalpy = 25.210907558259713
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.EnthalpySearch(true, data);
            }
            catch
            {
                methodThrew  = false;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(25.210907558259713, data.RootEnthalpy, "RootEnthalpy value does not match");
            Assert.AreEqual(25.210907558259713, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(70.0, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(70.0, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(0.0077017320693170037, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(1.0, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(6.6399110435735125, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(0.15176434224139623, data.Density, "Density value does not match");
            Assert.AreEqual(69.999999999912674, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void IP_EnthalpySearch_RootEnthaply_LowTemperatureLessThanHtolerance_UnitTest()
        {
            bool methodThrew = false;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI  = false,
                BarometricPressure = 29.921,
                RootEnthalpy = 0.411782
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.EnthalpySearch(true, data);
            }
            catch
            {
                methodThrew  = false;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.411782, data.RootEnthalpy, "RootEnthalpy value does not match");
            Assert.AreEqual(0.0, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(0.0, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(0.0, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(0.00038810668156934869, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(1.0, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(5.6954649467881211, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(0.17564643379040099, data.Density, "Density value does not match");
            Assert.AreEqual(6.1905881709921226e-10, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void IP_EnthalpySearch_RootEnthaply_HighTemperatureLessThanHtolerance_UnitTest()
        {
            bool methodThrew = false;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI  = false,
                BarometricPressure = 29.921,
                RootEnthalpy = 109.41813
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.EnthalpySearch(true, data);
            }
            catch
            {
                methodThrew  = false;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(109.41813, data.RootEnthalpy, "RootEnthalpy value does not match");
            Assert.AreEqual(0.0, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(140.0, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(140.0, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(0.067504294799131559, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(1.0, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(8.2313906999864663, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(0.12968699138541520, data.Density, "Density value does not match");
            Assert.AreEqual(139.99999999955304, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void IP_EnthalpySearch_RootEnthaply_LowTemperatureLessThanEnthalpy_UnitTest()
        {
            bool methodThrew = false;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI  = false,
                BarometricPressure = 29.921,
                RootEnthalpy = 0.4116
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.EnthalpySearch(true, data);
            }
            catch
            {
                methodThrew  = false;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(0.4116, data.RootEnthalpy, "RootEnthalpy value does not match");
            Assert.AreEqual(0.0, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(0.0, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(0.0, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(0.00038810668156934869, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(1.0, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(5.6954649467881211, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(0.17564643379040099, data.Density, "Density value does not match");
            Assert.AreEqual(6.1905881709921226e-10, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void IP_EnthalpySearch_RootEnthaply_HighTemperatureLessThanEnthalpy_UnitTest()
        {
            bool methodThrew = false;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI  = false,
                BarometricPressure = 29.921,
                RootEnthalpy = 109.5
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.EnthalpySearch(true, data);
            }
            catch
            {
                methodThrew  = false;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(109.5, data.RootEnthalpy, "RootEnthalpy value does not match");
            Assert.AreEqual(0.0, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(140.0, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(140.0, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(0.067504294799131559, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(1.0, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(8.2313906999864663, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(0.12968699138541520, data.Density, "Density value does not match");
            Assert.AreEqual(139.99999999955304, data.DewPoint, "DewPoint value does not match");
        }

        [TestMethod]
        public void IP_EnthalpySearch_SaturationFalse_UnitTest()
        {
            bool methodThrew = false;
            PsychrometricsData data = new PsychrometricsData()
            {
                IsInternationalSystemOfUnits_SI  = false,
                BarometricPressure = 29.921,
                RootEnthalpy = 69.0
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.EnthalpySearch(false, data);
            }
            catch
            {
                methodThrew  = false;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(69.0, data.RootEnthalpy, "RootEnthalpy value does not match");
            Assert.AreEqual(69.000061765088176, data.Enthalpy, "Enthalpy value does not match");
            Assert.AreEqual(116.89566612243652, data.WetBulbTemperature, "WetBulbTemperature value does not match");
            Assert.AreEqual(0.0, data.DryBulbTemperature, "DryBulbTemperature value does not match");
            Assert.AreEqual(0.065033045961440314, data.HumidityRatio, "HumidityRatio value does not match");
            Assert.AreEqual(151.79774534335073, data.RelativeHumidity, "RelativeHumidity value does not match");
            Assert.AreEqual(6.2870603967935974, data.SpecificVolume, "SpecificVolume value does not match");
            Assert.AreEqual(0.16940079762946250, data.Density, "Density value does not match");
            Assert.AreEqual(138.69649571908303, data.DewPoint, "DewPoint value does not match");
        }
    }
}
