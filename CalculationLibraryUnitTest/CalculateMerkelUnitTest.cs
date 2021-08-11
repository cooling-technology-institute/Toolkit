using System;
using CalculationLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace CalculationLibraryUnitTest
{
    [TestClass]
    public class CalculateMerkelUnitTest
    {
        CalculationLibrary.CalculationLibrary CalculationLibrary { get; set; }

        [TestMethod]
        public void SI_CalculateMerkelTest()
        {
            bool methodThrew = false;
            bool returnValue = false;

            MerkelCalculationData data = new MerkelCalculationData(true)
            {
                IsElevation = true,
                Elevation = 50.0,
                BarometricPressure = 0.0,
                HotWaterTemperature = 40.0,
                ColdWaterTemperature = 30.0,
                WetBulbTemperature = 25.0,
                LiquidToGasRatio = 1.3
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                returnValue = CalculationLibrary.CalculateMerkel(data, true);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.IsTrue(returnValue, "CalculateMerkel return value");
            Assert.AreEqual(1.5576363962243127, data.KaV_L, "Merkel value does not match");
        }

        [TestMethod]
        public void SI_CalculateMerkelLargeElevationTest()
        {
            bool methodThrew = false;
            bool returnValue = false;

            MerkelCalculationData data = new MerkelCalculationData(true)
            {
                IsElevation = true,
                Elevation = 444.0,
                BarometricPressure = 0.0,
                HotWaterTemperature = 40.0,
                ColdWaterTemperature = 30.0,
                WetBulbTemperature = 25.0,
                LiquidToGasRatio = 1.3
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                returnValue = CalculationLibrary.CalculateMerkel(data, true);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.IsTrue(returnValue, "CalculateMerkel return value");
            Assert.AreEqual(1.4410303258277655, data.KaV_L, "Merkel value does not match");
        }

        [TestMethod]
        public void IP_CalculateMerkelTest()
        {
            bool methodThrew = false;
            bool returnValue = false;

            MerkelCalculationData data = new MerkelCalculationData(false)
            {
                IsElevation = true,
                Elevation = 50.0,
                BarometricPressure = 0.0,
                HotWaterTemperature = 100.0,
                ColdWaterTemperature = 80.0,
                WetBulbTemperature = 70.0,
                LiquidToGasRatio = 1.3
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                returnValue = CalculationLibrary.CalculateMerkel(data, true);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.IsTrue(returnValue, "CalculateMerkel return value");
            Assert.AreEqual(2.1200361989715248, data.KaV_L, "Merkel value does not match");
        }

        [TestMethod]
        public void SI_CalculateMerkelBarometricPressureTest()
        {
            bool methodThrew = false;
            bool returnValue = false;

            MerkelCalculationData data = new MerkelCalculationData(true)
            {
                IsElevation = false,
                Elevation = 0.0,
                BarometricPressure = 14.0,
                HotWaterTemperature = 40.0,
                ColdWaterTemperature = 30.0,
                WetBulbTemperature = 25.0,
                LiquidToGasRatio = 1.3
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                returnValue = CalculationLibrary.CalculateMerkel(data, true);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.IsTrue(returnValue, "CalculateMerkel return value");
            Assert.AreEqual(0.084193571669267636, data.KaV_L, "Merkel value does not match");
        }

        [TestMethod]
        public void IP_CalculateMerkelBarometricPressureTest()
        {
            bool methodThrew = false;
            bool returnValue = false;

            MerkelCalculationData data = new MerkelCalculationData(false)
            {
                IsElevation = false,
                Elevation = 0.0,
                BarometricPressure = 14.0,
                HotWaterTemperature = 100.0,
                ColdWaterTemperature = 80.0,
                WetBulbTemperature = 70.0,
                LiquidToGasRatio = 1.3
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                returnValue = CalculationLibrary.CalculateMerkel(data, true);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.IsTrue(returnValue, "CalculateMerkel return value");
            Assert.AreEqual(0.66440307482312777, data.KaV_L, "Merkel value does not match");
        }

        [TestMethod]
        public void SI_CalculateMerkel_ElevationZeroTest()
        {
            bool methodThrew = false;
            bool returnValue = false;
            MerkelCalculationData data = new MerkelCalculationData(true)
            {
                IsElevation = true,
                Elevation = 0.0,
                BarometricPressure = 0.0,
                HotWaterTemperature = 40.0,
                ColdWaterTemperature = 30.0,
                WetBulbTemperature = 25.0,
                LiquidToGasRatio = 1.3
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                returnValue = CalculationLibrary.CalculateMerkel(data, true);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.IsTrue(returnValue, "CalculateMerkel return value");
            Assert.AreEqual(1.5724858232706995, data.KaV_L, "Merkel value does not match");
        }

        [TestMethod]
        public void IP_CalculateMerkel_ElevationZeroTest()
        {
            bool methodThrew = false;
            bool returnValue = false;

            MerkelCalculationData data = new MerkelCalculationData(false)
            {
                IsElevation = true,
                Elevation = 0.0,
                BarometricPressure = 0.0,
                HotWaterTemperature = 100.0,
                ColdWaterTemperature = 80.0,
                WetBulbTemperature = 70.0,
                LiquidToGasRatio = 1.3
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                returnValue = CalculationLibrary.CalculateMerkel(data, true);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.IsTrue(returnValue, "CalculateMerkel return value");
            Assert.AreEqual(2.1262455221481726, data.KaV_L, "Merkel value does not match");
        }

        [TestMethod]
        public void SI_CalculateMerkel_BoilingTest()
        {
            bool methodThrew = false;
            bool returnValue = false;
            MerkelCalculationData data = new MerkelCalculationData(true)
            {
                IsElevation = true,
                Elevation = 0.0,
                BarometricPressure = 0.0,
                HotWaterTemperature = 100.0,
                ColdWaterTemperature = 30.0,
                WetBulbTemperature = 25.0,
                LiquidToGasRatio = 1.3
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                returnValue = CalculationLibrary.CalculateMerkel(data, true);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.IsFalse(returnValue, "CalculateMerkel return value");
        }

        [TestMethod]
        public void IP_CalculateMerkel_BoilingTest()
        {
            bool methodThrew = false;
            bool returnValue = false;

            MerkelCalculationData data = new MerkelCalculationData(false)
            {
                IsElevation = true,
                Elevation = 0.0,
                BarometricPressure = 0.0,
                HotWaterTemperature = 212.0,
                ColdWaterTemperature = 180.0,
                WetBulbTemperature = 150.0,
                LiquidToGasRatio = 1.3
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                returnValue = CalculationLibrary.CalculateMerkel(data, true);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.IsFalse(returnValue, "CalculateMerkel return value");
        }

        [TestMethod]
        public void SI_CalculateMerkel_LoopRangeCheckTest()
        {
            bool methodThrew = false;
            bool returnValue = false;
            MerkelCalculationData data = new MerkelCalculationData(true)
            {
                Elevation = 0.0,
                BarometricPressure = 0.0,
                HotWaterTemperature = 80.0,
                ColdWaterTemperature = 75.0,
                WetBulbTemperature = 74.69,
                LiquidToGasRatio = 51.3
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                returnValue = CalculationLibrary.CalculateMerkel(data, true);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.IsFalse(returnValue, "CalculateMerkel return value");
        }

        [TestMethod]
        public void IP_CalculateMerkel_LoopRangeCheckTest()
        {
            bool methodThrew = false;
            bool returnValue = false;

            MerkelCalculationData data = new MerkelCalculationData(false)
            {
                IsElevation = true,
                Elevation = 0.0,
                BarometricPressure = 0.0,
                HotWaterTemperature = 112.0,
                ColdWaterTemperature = 80.0,
                WetBulbTemperature = 9.0,
                LiquidToGasRatio = 51.3
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                returnValue = CalculationLibrary.CalculateMerkel(data, true);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.IsFalse(returnValue, "CalculateMerkel return value");
        }

        [TestMethod]
        public void IP_HwHaRangeTest()
        {
            bool methodThrew = false;
            bool returnValue = false;

            MerkelCalculationData data = new MerkelCalculationData(true)
            {
                IsElevation = true,
                IsInternationalSystemOfUnits_SI = false,
                Elevation = 0.0,
                BarometricPressure = 14.0,
                HotWaterTemperature = 110.0,
                ColdWaterTemperature = 84.0,
                WetBulbTemperature = 80.0,
                LiquidToGasRatio = 1.754
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                returnValue = CalculationLibrary.CalculateMerkel(data, true);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.IsFalse(returnValue, "CalculateMerkel return value");
            Assert.IsTrue(CalculationLibrary.ErrorMessage.Contains("The L/G value entered produces an out of bounds value of KaV/L."), "ErrorMessage value does not match");
        }

        [TestMethod]
        public void IP_HotWaterTemperatureBoilingTest()
        {
            bool methodThrew = false;
            bool returnValue = false;

            MerkelCalculationData data = new MerkelCalculationData(true)
            {
                IsElevation = true,
                IsInternationalSystemOfUnits_SI = true,
                Elevation = 0.0,
                BarometricPressure = 14.0,
                HotWaterTemperature = 110.0,
                ColdWaterTemperature = 84.0,
                WetBulbTemperature = 80.0,
                LiquidToGasRatio = 1.754
            };

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                returnValue = CalculationLibrary.CalculateMerkel(data, true);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.IsFalse(returnValue, "CalculateMerkel return value");
            Assert.IsTrue(CalculationLibrary.ErrorMessage.Contains("he calculated Hot Water Temperature value is greater than or equal to the boiling point."), "ErrorMessage value does not match");
        }
    }
}