using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArtomatixCodingExercise;
using System.Diagnostics;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        /// <summary>
        /// TODO: Add as many test cases as required to fully validate your implementation of 
        /// MedianCalculator and GetMedianValueHighPerformance methods
        /// </summary>
        [TestMethod]
        public void TestGetMedianSingleArray()
        {
            int[] a = { 2, 1, 3 };
            double result = MedianCalculator.GetMedianValue(a);
            double expected = 2;
            Assert.AreEqual(expected, result);

            //even array
            a = new int[] { 2, 1, 3, 4, 5, 5};
            result = MedianCalculator.GetMedianValue(a);
            expected = 3.5;
            Assert.AreEqual(expected, result);

            //odd array
            a = new int[] { 1,2,3,4,4,5,5 };
            result = MedianCalculator.GetMedianValue(a);
            expected = 4;
            Assert.AreEqual(expected, result);

            //even array
            a = new int[] { 1,1,1,2,1,1,1,1 };
            result = MedianCalculator.GetMedianValue(a);
            expected = 1;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestGetMedianDoubleArray() {
            int[] a = { 1, 2, 3, 4 };
            int[] b = { 5, 6, 7, 8 };
            double result = MedianCalculator.GetMedianValueHighPerformance(a, b);
            double expected = 4.5;
            Assert.AreEqual(expected, result);


            a = new int[] { 1, 2 };
            b = new int[] { 1, 2, 3 };
            result = MedianCalculator.GetMedianValueHighPerformance(a, b);
            expected = 2;
            Assert.AreEqual(expected, result);


            a = new int[] { 1, 1, 1 };
            b = new int[] { 1, 1, 3 };
            result = MedianCalculator.GetMedianValueHighPerformance(a, b);
            expected = 1;
            Assert.AreEqual(expected, result);

            a = new int[] { 1, 1, 1 };
            b = new int[] { 1, 1, 1, 1, 1, 3 };
            result = MedianCalculator.GetMedianValueHighPerformance(a, b);
            expected = 1;
            Assert.AreEqual(expected, result);

            a = new int[] { 1, 1, 1, 1, 1, 3 };
            b = new int[] { 1, 1, 1 };
            result = MedianCalculator.GetMedianValueHighPerformance(a, b);
            expected = 1;
            Assert.AreEqual(expected, result);

        }

        /// <summary>
        /// This test uses a large data set.
        /// Within this test case implement a scheme that validates that GetMedianValueHighPerformance 
        /// returns the correct result.
        /// 
        /// For additional credit, perform memory and performance analysis of algorithms developed, and report on the results.
        ///     -> My performance profiler on VS wouldnt work for a long time, so I could do this part.
        ///     
        /// </summary>
        [TestMethod]
        public void TestVeryLargeSourceData()
        {
            Random randNumber = new Random();
            int[] a = CreateRandomDataSet(randNumber.Next(3, 10000000));
            int[] b = CreateRandomDataSet(randNumber.Next(3, 10000000));

            //my best guess at how to validate the median, using the previous method and a simple concat.
            //I suppose this doesnt have to be efficient if its a test.
            double result = MedianCalculator.GetMedianValueHighPerformance(a, b);
            int[] combined = a.Concat(b).ToArray();
            double expected = MedianCalculator.GetMedianValue(combined);
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void TestVeryLargeSourceData2() {
            Random randNumber = new Random();
            int[] a = CreateRandomDataSet(randNumber.Next(10000000, 20000000));
            int[] b = CreateRandomDataSet(randNumber.Next(10000000, 20000000));

            double result = MedianCalculator.GetMedianValueHighPerformance(a, b);
            int[] combined = a.Concat(b).ToArray();
            double expected = MedianCalculator.GetMedianValue(combined);
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void TestVeryLargeSourceData3() {
            Random randNumber = new Random();
            int[] a = CreateRandomDataSet(randNumber.Next(3, 10000000));
            int[] b = { };

            double result = MedianCalculator.GetMedianValueHighPerformance(a, b);
            int[] combined = a.Concat(b).ToArray();
            double expected = MedianCalculator.GetMedianValue(combined);
            Assert.AreEqual(expected, result);

        }

        private int[] CreateRandomDataSet(int size)
        {
            Random rnd = new Random();
            int[] a = new int[size];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = rnd.Next();
            }
            return a;
        }
                
    }
}
