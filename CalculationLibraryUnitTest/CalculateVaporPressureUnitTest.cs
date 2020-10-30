using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculationLibraryUnitTest
{
    [TestClass]
    public class CalculateVaporPressureUnitTest
    {
        CalculationLibrary.CalculationLibrary CalculationLibrary { get; set; }

        [TestMethod]
        public void SI_CalculateVaporPressureTest()
        {
            double returnValue = 0.0;
            bool methodThrew = false;
            double airTemperature = 50;

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
            Assert.AreEqual(12.349856207156227, returnValue, "Returned value does not match");
        }

        [TestMethod]
        public void SI_CalculateVaporPressure_BelowFreezingTest()
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
            Assert.AreEqual(0.60613974008942884, returnValue, "Returned value does not match");
        }

        [TestMethod]
        public void IP_CalculateVaporPressure_BelowFreezingTest()
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
            Assert.AreEqual(0.088212703345247362, returnValue, "Returned value does not match");
        }

        [TestMethod]
        public void SI_CalculateVaporPressure_FreezingTest()
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
            Assert.AreEqual(0.61121285460480013, returnValue, "Returned value does not match");
        }

        [TestMethod]
        public void IP_CalculateVaporPressure_FreezingTest()
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
            Assert.AreEqual(0.088648919713124566, returnValue, "Returned value does not match");
        }

        [TestMethod]
        public void SI_CalculateVaporPressure_AboveFreezingTest()
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
            Assert.AreEqual(0.61566735840863751, returnValue, "Returned value does not match");
        }

        [TestMethod]
        public void IP_CalculateVaporPressure_AboveFreezingTest()
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
            Assert.AreEqual(0.089007334390018011, returnValue, "Returned value does not match");
        }

        [TestMethod]
        public void SI_CalculateVaporPressure_MiniumTemperatureTest()
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
            Assert.AreEqual(0.0, returnValue, "Returned value does not match");
        }

        [TestMethod]
        public void SI_CalculateVaporPressure_BelowMiniumTemperatureTest()
        {
            double returnValue = 0.0;
            bool methodThrew = false;
            double airTemperature = -274;

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
            Assert.AreEqual(0.0, returnValue, "Returned value does not match");
        }

        [TestMethod]
        public void IP_CalculateVaporPressureTest()
        {
            double returnValue = 0.0;
            bool methodThrew = false;
            double airTemperature = 78.78;

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
            Assert.AreEqual(0.48746047777005813, returnValue, "Returned value does not match");
        }

        [TestMethod]
        public void IP_CalculateVaporPressure_MiniumTemperatureTest()
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
            Assert.AreEqual(0.0, returnValue, "Returned value does not match");
        }

        [TestMethod]
        public void IP_CalculateVaporPressure_BelowMiniumTemperatureTest()
        {
            double returnValue = 0.0;
            bool methodThrew = false;
            double airTemperature = -460;

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
            Assert.AreEqual(0.0, returnValue, "Returned value does not match");
        }
    }
}
