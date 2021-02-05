using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculationLibraryUnitTest
{
    [TestClass]
    public class SplineUnitTest
    {
        CalculationLibrary.CalculationLibrary CalculationLibrary { get; set; }

        [TestMethod]
        public void SplineTest()
        {
            List<double> returnValue = new List<double>() { 0.0, 0.018396172248804021, -0.0039846889952154310, 0.016742583732057319, 0.028214354066985834, 0.0 };
            bool methodThrew = false;

            List<double> x = new List<double>() { 5.0, 10.0, 15.0, 20.0, 25.0, 30.0 };
            List<double> y = new List<double>() { 18.0, 20.379999999999999, 23.050000000000001, 25.800000000000001, 28.930000000000000, 32.600000000000001};

        double yp1 = 1E+31;
            double ypn = 1E+31;
            List<double> y2 = new List<double>();
            StringBuilder errorMessage = new StringBuilder();

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.Spline(x, y, yp1, ypn, y2, errorMessage);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreEqual(errorMessage.Length, 0, "errorMethod is not empty");
            for (int i = 0; i < y2.Count; i++)
            {
                Assert.AreEqual(returnValue[i], y2[i], string.Format("y2[{0}] does not match", i));
            }
        }

        [TestMethod]
        public void SplineTest_X_OutOfOrder()
        {
            List<double> returnValue = new List<double>() { 0.0, 0.018396172248804021, -0.0039846889952154310, 0.016742583732057319, 0.028214354066985834, 0.0 };
            bool methodThrew = false;

            List<double> x = new List<double>() { 5.0, 10.0, 20.0, 15.0, 25.0, 30.0 };
            List<double> y = new List<double>() { 18.0, 20.379999999999999, 23.050000000000001, 25.800000000000001, 28.930000000000000, 32.600000000000001 };

            double yp1 = 1E+31;
            double ypn = 1E+31;
            List<double> y2 = new List<double>();
            StringBuilder errorMessage = new StringBuilder();

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.Spline(x, y, yp1, ypn, y2, errorMessage);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreNotEqual(errorMessage.Length, 0, "errorMethod is empty");
        }

        [TestMethod]
        public void SplineTest_XY_CountDoNotMatch()
        {
            List<double> returnValue = new List<double>() { 0.0, 0.018396172248804021, -0.0039846889952154310, 0.016742583732057319, 0.028214354066985834, 0.0 };
            bool methodThrew = false;

            List<double> x = new List<double>() { 5.0, 10.0, 15.0, 20.0, 30.0 };
            List<double> y = new List<double>() { 18.0, 20.379999999999999, 23.050000000000001, 25.800000000000001, 28.930000000000000, 32.600000000000001 };

            double yp1 = 1E+31;
            double ypn = 1E+31;
            List<double> y2 = new List<double>();
            StringBuilder errorMessage = new StringBuilder();

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.Spline(x, y, yp1, ypn, y2, errorMessage);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreNotEqual(errorMessage.Length, 0, "errorMethod is empty");
        }

        [TestMethod]
        public void SplineTest_X_CountLessThan2()
        {
            List<double> returnValue = new List<double>() { 0.0, 0.018396172248804021, -0.0039846889952154310, 0.016742583732057319, 0.028214354066985834, 0.0 };
            bool methodThrew = false;

            List<double> x = new List<double>() { 5.0 };
            List<double> y = new List<double>() { 18.0 };

            double yp1 = 1E+31;
            double ypn = 1E+31;
            List<double> y2 = new List<double>();
            StringBuilder errorMessage = new StringBuilder();

            try
            {
                CalculationLibrary = new CalculationLibrary.CalculationLibrary();
                CalculationLibrary.Spline(x, y, yp1, ypn, y2, errorMessage);
            }
            catch
            {
                methodThrew = true;
            }

            Assert.IsFalse(methodThrew, "Method threw");
            Assert.AreNotEqual(errorMessage.Length, 0, "errorMethod is empty");
        }
    }
}
