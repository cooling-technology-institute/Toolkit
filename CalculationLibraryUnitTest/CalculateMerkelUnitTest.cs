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
                HotWaterTemperature = 0.0,
                ColdWaterTemperature = 0.0,
                LiquidToGasRatio = 0.0,
                BarometricPressure = 0.0,
                WetBulbTemperature = 0.0,
                Range = 0.0,
                KaV_L = 0.0
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
            Assert.AreEqual(1.0036805701060310, merkel, "Merkel value does not match");
        }

        [TestMethod]
        public void IP_CalculateMerkelTest()
        {
            bool methodThrew = false;
            double merkel = 0.0;
            MerkelData data = new MerkelData(true)
            {
                HotWaterTemperature = 0.0,
                ColdWaterTemperature = 0.0,
                LiquidToGasRatio = 0.0,
                BarometricPressure = 0.0,
                WetBulbTemperature = 0.0,
                Range = 0.0,
                KaV_L = 0.0
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
            Assert.AreEqual(1.0036805701060310, merkel, "Merkel value does not match");
        }
    }
}
