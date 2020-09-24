using System;
using CalculationLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace CalculationLibraryUnitTest
{
    [TestClass]
    public class CalculateFsUnitTest
    {
        CalculationLibrary.CalculationLibrary CalculationLibrary { get; set; }

        [TestMethod]
        public void FsTest()
        {
            bool methodThrew = false;
            double fs = 0.0;
            double temperature = 13;
            double pressure = 14.56;

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                fs = CalculationLibrary.Fs(pressure, temperature);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(1.0036805701060310, fs, "Fs value does not match");
        }
    }
}
