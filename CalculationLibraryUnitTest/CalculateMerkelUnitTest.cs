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
            double merkel = 0.0;
            MerkelData data = new MerkelData(true)
            {
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
                merkel = CalculationLibrary.CalculateMerkel(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(1.5576363962243127, merkel, "Merkel value does not match");
        }

        [TestMethod]
        public void IP_CalculateMerkelTest()
        {
            bool methodThrew = false;
            double merkel = 0.0;
            MerkelData data = new MerkelData(false)
            {
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
                merkel = CalculationLibrary.CalculateMerkel(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(2.1200361989715248, merkel, "Merkel value does not match");
        }


        [TestMethod]
        public void SI_CalculateMerkel_ElevationZeroTest()
        {
            bool methodThrew = false;
            double merkel = 0.0;
            MerkelData data = new MerkelData(true)
            {
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
                merkel = CalculationLibrary.CalculateMerkel(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(1.5724858232706995, merkel, "Merkel value does not match");
        }

        [TestMethod]
        public void IP_CalculateMerkel_ElevationZeroTest()
        {
            bool methodThrew = false;
            double merkel = 0.0;
            MerkelData data = new MerkelData(false)
            {
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
                merkel = CalculationLibrary.CalculateMerkel(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(2.1262455221481726, merkel, "Merkel value does not match");
        }

        [TestMethod]
        public void SI_CalculateMerkel_BoilingTest()
        {
            bool methodThrew = false;
            double merkel = 0.0;
            MerkelData data = new MerkelData(true)
            {
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
                merkel = CalculationLibrary.CalculateMerkel(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(999, merkel, "Merkel value does not match");
        }

        [TestMethod]
        public void IP_CalculateMerkel_BoilingTest()
        {
            bool methodThrew = false;
            double merkel = 0.0;

            MerkelData data = new MerkelData(false)
            {
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
                merkel = CalculationLibrary.CalculateMerkel(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(999, merkel, "Merkel value does not match");
        }

        [TestMethod]
        public void SI_CalculateMerkel_LoopRangeCheckTest()
        {
            bool methodThrew = false;
            double merkel = 0.0;
            MerkelData data = new MerkelData(true)
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
                merkel = CalculationLibrary.CalculateMerkel(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(999, merkel, "Merkel value does not match");
        }

        [TestMethod]
        public void IP_CalculateMerkel_LoopRangeCheckTest()
        {
            bool methodThrew = false;
            double merkel = 0.0;

            MerkelData data = new MerkelData(false)
            {
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
                merkel = CalculationLibrary.CalculateMerkel(data);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(999, merkel, "Merkel value does not match");
        }
    }
}
