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
        public void SI_FsTest()
        {
            bool methodThrew = false;
            double fs = 0.0;
            double temperature = 13;
            double pressure = 14.56;

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                fs = CalculationLibrary.CalculateFs(true, pressure, temperature);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(1.0012003737919406, fs, "Fs value does not match");
        }


        [TestMethod]
        public void IP_FsTest()
        {
            bool methodThrew = false;
            double fs = 0.0;
            double temperature = 70;
            double pressure = 29;

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                fs = CalculationLibrary.CalculateFs(false, pressure, temperature);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(1.0072504161537958, fs, "Fs value does not match");
        }
    }
}
