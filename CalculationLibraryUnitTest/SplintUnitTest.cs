using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculationLibraryUnitTest
{
    [TestClass]
    public class SplintUnitTest
    {
        CalculationLibrary.CalculationLibrary CalculationLibrary { get; set; }

        [TestMethod]
        public void SplintTest()
        {
            bool methodThrew = false;

            List<double> xa = new List<double>() { 5.0, 10.0, 15.0, 20.0, 25.0, 30.0 };
            List<double> ya = new List<double>() { 18.0, 20.379999999999999, 23.050000000000001, 25.800000000000001, 28.930000000000000, 32.600000000000001 };
            List<double> y2 = new List<double>() { 0.0, 0.018396172248804021, -0.0039846889952154310, 0.016742583732057319, 0.028214354066985834, 0.0 };

            double yfit = 0.0;
            double xreal = 24.530000000000001;
            StringBuilder errorMessage = new StringBuilder();

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.Splint(xa, ya, y2, xreal, ref yfit, errorMessage);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(errorMessage.Length, 0, "errorMethod is not empty");
            Assert.AreEqual(yfit, 28.610197818305455, "yfit value does not match");
        }

        [TestMethod]
        public void SplintTest_ListCountNotMatching_X()
        {
            bool methodThrew = false;

            List<double> xa = new List<double>() { 5.0, 10.0, 15.0, 20.0, 25.0 };
            List<double> ya = new List<double>() { 18.0, 20.379999999999999, 23.050000000000001, 25.800000000000001, 28.930000000000000, 32.600000000000001 };
            List<double> y2 = new List<double>() { 0.0, 0.018396172248804021, -0.0039846889952154310, 0.016742583732057319, 0.028214354066985834, 0.0 };

            double yfit = 0.0;
            double xreal = 24.530000000000001;
            StringBuilder errorMessage = new StringBuilder();

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.Splint(xa, ya, y2, xreal, ref yfit, errorMessage);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreNotEqual(errorMessage.Length, 0, "errorMethod is empty");
            Assert.IsTrue(errorMessage.ToString().Contains("array sizes must be equal"), "errorMethod does not have correct information");
        }

        [TestMethod]
        public void SplintTest_ListCountNotMatching_Y()
        {
            bool methodThrew = false;

            List<double> xa = new List<double>() { 5.0, 10.0, 15.0, 20.0, 25.0, 30.0 };
            List<double> ya = new List<double>() { 18.0, 20.379999999999999, 23.050000000000001, 25.800000000000001, 28.930000000000000 };
            List<double> y2 = new List<double>() { 0.0, 0.018396172248804021, -0.0039846889952154310, 0.016742583732057319, 0.028214354066985834, 0.0 };

            double yfit = 0.0;
            double xreal = 24.530000000000001;
            StringBuilder errorMessage = new StringBuilder();

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.Splint(xa, ya, y2, xreal, ref yfit, errorMessage);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreNotEqual(errorMessage.Length, 0, "errorMethod is empty");
            Assert.IsTrue(errorMessage.ToString().Contains("array sizes must be equal"), "errorMethod does not have correct information");
        }

        [TestMethod]
        public void SplintTest_ListCountNotMatching_Y2()
        {
            bool methodThrew = false;

            List<double> xa = new List<double>() { 5.0, 10.0, 15.0, 20.0, 25.0, 30.0 };
            List<double> ya = new List<double>() { 18.0, 20.379999999999999, 23.050000000000001, 25.800000000000001, 28.930000000000000, 32.600000000000001 };
            List<double> y2 = new List<double>() { 0.0, 0.018396172248804021, -0.0039846889952154310, 0.016742583732057319, 0.028214354066985834 };

            double yfit = 0.0;
            double xreal = 24.530000000000001;
            StringBuilder errorMessage = new StringBuilder();

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.Splint(xa, ya, y2, xreal, ref yfit, errorMessage);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreNotEqual(errorMessage.Length, 0, "errorMethod is empty");
            Assert.IsTrue(errorMessage.ToString().Contains("array sizes must be equal"), "errorMethod does not have correct information");
        }

        [TestMethod]
        public void SplintTest_ListCountLessThan2_X()
        {
            bool methodThrew = false;

            List<double> xa = new List<double>() { 5.0 };
            List<double> ya = new List<double>() { 18.0 };
            List<double> y2 = new List<double>() { 0.0 };

            double yfit = 0.0;
            double xreal = 24.530000000000001;
            StringBuilder errorMessage = new StringBuilder();

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.Splint(xa, ya, y2, xreal, ref yfit, errorMessage);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreNotEqual(errorMessage.Length, 0, "errorMethod is empty");
            Assert.IsTrue(errorMessage.ToString().Contains("least 2 values in order"), "errorMethod does not have correct information");
        }

        [TestMethod]
        public void SplintTest_First2Matching_X()
        {
            bool methodThrew = false;

            List<double> xa = new List<double>() { 5.0, 5.0, 15.0, 20.0, 25.0, 30.0 };
            List<double> ya = new List<double>() { 18.0, 20.379999999999999, 23.050000000000001, 25.800000000000001, 28.930000000000000, 32.600000000000001 };
            List<double> y2 = new List<double>() { 0.0, 0.018396172248804021, -0.0039846889952154310, 0.016742583732057319, 0.028214354066985834, 0.0 };

            double yfit = 0.0;
            double xreal = 24.530000000000001;
            StringBuilder errorMessage = new StringBuilder();

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.Splint(xa, ya, y2, xreal, ref yfit, errorMessage);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreNotEqual(errorMessage.Length, 0, "errorMethod is empty");
            Assert.IsTrue(errorMessage.ToString().Contains("first two values"), "errorMethod does not have correct information");
        }

        [TestMethod]
        public void SplintTest_BisectionEqual()
        {
            bool methodThrew = false;

            List<double> xa = new List<double>() { 5.0, 10.0, 15.0, 15.0, 15.0, 15.0 };
            List<double> ya = new List<double>() { 18.0, 20.379999999999999, 23.050000000000001, 25.800000000000001, 28.930000000000000, 32.600000000000001 };
            List<double> y2 = new List<double>() { 0.0, 0.018396172248804021, -0.0039846889952154310, 0.016742583732057319, 0.028214354066985834, 0.0 };

            double yfit = 0.0;
            double xreal = 15.0;
            StringBuilder errorMessage = new StringBuilder();

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.Splint(xa, ya, y2, xreal, ref yfit, errorMessage);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreNotEqual(errorMessage.Length, 0, "errorMethod is empty");
            Assert.IsTrue(errorMessage.ToString().Contains("bisection values"), "errorMethod does not have correct information");
        }

        [TestMethod]
        public void SplintTest_OrderIncreasing()
        {
            bool methodThrew = false;

            List<double> xa = new List<double>() { 5.0, 10.0, 15.0, 20.0, 25.0, 30.0 };
            List<double> ya = new List<double>() { 18.0, 20.379999999999999, 23.050000000000001, 25.800000000000001, 28.930000000000000, 32.600000000000001 };
            List<double> y2 = new List<double>() { 0.0, 0.018396172248804021, -0.0039846889952154310, 0.016742583732057319, 0.028214354066985834, 0.0 };

            double yfit = 0.0;
            double xreal = 31.0;
            StringBuilder errorMessage = new StringBuilder();

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.Splint(xa, ya, y2, xreal, ref yfit, errorMessage);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreNotEqual(errorMessage.Length, 0, "errorMethod is empty");
            Assert.IsTrue(errorMessage.ToString().Contains("increasing"), "errorMethod does not have correct information");
        }

        [TestMethod]
        public void SplintTest_OrderDecreasing()
        {
            bool methodThrew = false;

            List<double> xa = new List<double>() { 30.0, 25.0, 20.0, 15.0, 10.0, 5.0 };
            List<double> ya = new List<double>() { 18.0, 20.379999999999999, 23.050000000000001, 25.800000000000001, 28.930000000000000, 32.600000000000001 };
            List<double> y2 = new List<double>() { 0.0, 0.018396172248804021, -0.0039846889952154310, 0.016742583732057319, 0.028214354066985834, 0.0 };

            double yfit = 0.0;
            double xreal = 31.0;
            StringBuilder errorMessage = new StringBuilder();

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.Splint(xa, ya, y2, xreal, ref yfit, errorMessage);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreNotEqual(errorMessage.Length, 0, "errorMethod is empty");
            Assert.IsTrue(errorMessage.ToString().Contains("decreasing"), "errorMethod does not have correct information");
        }
    }
}
