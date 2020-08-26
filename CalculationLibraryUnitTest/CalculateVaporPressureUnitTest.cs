using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculationLibraryUnitTest
{
    [TestClass]
    public class CalculateVaporPressureUnitTest
    {
        CalculationLibrary.CalculationLibrary CalculationLibrary { get; set; }

        [TestMethod]
        public void SI_BelowFreezingTest()
        {
            double returnValue = 0.0;
            bool methodThrew = false;
            double airTemperature = -0.1;

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                returnValue = CalculationLibrary.CalculateVaporPressure(true, airTemperature);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(returnValue, 0.60613974008942884, "Returned value does not match");
        }

        [TestMethod]
        public void IP_BelowFreezingTest()
        {
            double returnValue = 0.0;
            bool methodThrew = false;
            double airTemperature = 31.9;

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                returnValue = CalculationLibrary.CalculateVaporPressure(false, airTemperature);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(returnValue, 0.088212703345247362, "Returned value does not match");
        }

        [TestMethod]
        public void SI_FreezingTest()
        {
            double returnValue = 0.0;
            bool methodThrew = false;
            double airTemperature = 0.0;

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                returnValue = CalculationLibrary.CalculateVaporPressure(true, airTemperature);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(returnValue, 0.61121285460480013, "Returned value does not match");
        }

        [TestMethod]
        public void IP_FreezingTest()
        {
            double returnValue = 0.0;
            bool methodThrew = false;
            double airTemperature = 32.0;

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                returnValue = CalculationLibrary.CalculateVaporPressure(false, airTemperature);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(returnValue, 0.088648919713124566, "Returned value does not match");
        }

        [TestMethod]
        public void SI_AboveFreezingTest()
        {
            double returnValue = 0.0;
            bool methodThrew = false;
            double airTemperature = 0.1;

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                returnValue = CalculationLibrary.CalculateVaporPressure(true, airTemperature);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(returnValue, 0.61566735840863751, "Returned value does not match");
        }

        [TestMethod]
        public void IP_AboveFreezingTest()
        {
            double returnValue = 0.0;
            bool methodThrew = false;
            double airTemperature = 32.1;

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                returnValue = CalculationLibrary.CalculateVaporPressure(false, airTemperature);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(returnValue, 0.089007334390018011, "Returned value does not match");
        }

        [TestMethod]
        public void SI_MiniumTemperatureTest()
        {
            double returnValue = 0.0;
            bool methodThrew = false;
            double airTemperature = -273.15;

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                returnValue = CalculationLibrary.CalculateVaporPressure(true, airTemperature);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(returnValue, 0.0, "Returned value does not match");
        }

        [TestMethod]
        public void IP_MiniumTemperatureTest()
        {
            double returnValue = 0.0;
            bool methodThrew = false;
            double airTemperature = -459.67;

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                returnValue = CalculationLibrary.CalculateVaporPressure(false, airTemperature);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(returnValue, 0.0, "Returned value does not match");
        }
    }
}
