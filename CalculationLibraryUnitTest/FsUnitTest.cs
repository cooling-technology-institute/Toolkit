﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculationLibraryUnitTest
{
    [TestClass]
    public class FsUnitTest
    {
        CalculationLibrary.CalculationLibrary CalculationLibrary { get; set; }

        [TestMethod]
        public void SI_FsBelowFreezingTest()
        {
            double returnValue = 0.0;
            bool methodThrew = false;
            double temperature = -0.1;
            double pressure = 14.2;

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                returnValue = CalculationLibrary.Fs(true, pressure, temperature);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(returnValue, 1.0087291644121439, "Returned value does not match");
        }

        [TestMethod]
        public void IP_FsBelowFreezingTest()
        {
            double returnValue = 0.0;
            bool methodThrew = false;
            double temperature = 30.0;
            double pressure = 29.921;

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                returnValue = CalculationLibrary.Fs(false,temperature, pressure);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(returnValue, 1.0087291644121439, "Returned value does not match");
        }

        [TestMethod]
        public void SI_FsAboveFreezingTest()
        {
            double returnValue = 0.0;
            bool methodThrew = false;
            double temperature = 55.0;
            double pressure = 14;

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                returnValue = CalculationLibrary.Fs(true, pressure, temperature);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(returnValue, 1.0067004464605553, "Returned value does not match");
        }

        [TestMethod]
        public void IP_FsAboveFreezingTest()
        {
            double returnValue = 0.0;
            bool methodThrew = false;
            double temperature = 55.0;
            double pressure = 29.921;

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                returnValue = CalculationLibrary.Fs(false, temperature, pressure);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(returnValue, 1.0067004464605553, "Returned value does not match");
        }

        [TestMethod]
        public void SI_FsHighPressureTest()
        {
            double returnValue = 0.0;
            bool methodThrew = false;
            double temperature = 55.0;
            double pressure = 2900.921;

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                returnValue = CalculationLibrary.Fs(true, pressure, temperature);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(returnValue, -525272.94744189642, "Returned value does not match");
        }


        [TestMethod]
        public void IP_FsHighPressureTest()
        {
            double returnValue = 0.0;
            bool methodThrew = false;
            double temperature = 55.0;
            double pressure = 2900.921;

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                returnValue = CalculationLibrary.Fs(false, temperature, pressure);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(returnValue, -525272.94744189642, "Returned value does not match");
        }

        [TestMethod]
        public void SI_FsLowPressureTest()
        {
            double returnValue = 0.0;
            bool methodThrew = false;
            double temperature = 55.0;
            double pressure = -290.921;

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                returnValue = CalculationLibrary.Fs(true, pressure, temperature);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(returnValue, -62.825713642810555, "Returned value does not match");
        }

        [TestMethod]
        public void IP_FsLowPressureTest()
        {
            double returnValue = 0.0;
            bool methodThrew = false;
            double temperature = 55.0;
            double pressure = -290.921;

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                returnValue = CalculationLibrary.Fs(false, temperature, pressure);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(returnValue, -62.825713642810555, "Returned value does not match");
        }

        [TestMethod]
        public void SI_FsHighTemperatureTest()
        {
            double returnValue = 0.0;
            bool methodThrew = false;
            double temperature = 500.0;
            double pressure = 29.921;

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                returnValue = CalculationLibrary.Fs(true, pressure, temperature);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(returnValue, -0.59087150438310587, "Returned value does not match");
        }

        [TestMethod]
        public void IP_FsHighTemperatureTest()
        {
            double returnValue = 0.0;
            bool methodThrew = false;
            double temperature = 500.0;
            double pressure = 29.921;

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                returnValue = CalculationLibrary.Fs(false, temperature, pressure);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(returnValue, -0.59087150438310587, "Returned value does not match");
        }

        [TestMethod]
        public void SI_FsLowTemperatureTest()
        {
            double returnValue = 0.0;
            bool methodThrew = false;
            double temperature = -500.1;
            double pressure = 29.921;

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                returnValue = CalculationLibrary.Fs(true, pressure, temperature);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(returnValue, 14.757152021470306, "Returned value does not match");
        }

        [TestMethod]
        public void IP_FsLowTemperatureTest()
        {
            double returnValue = 0.0;
            bool methodThrew = false;
            double temperature = -500.1;
            double pressure = 29.921;

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                returnValue = CalculationLibrary.Fs(false, temperature, pressure);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(returnValue, 14.757152021470306 , "Returned value does not match");
        }
    }
}
