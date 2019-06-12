/// Interview coding exercise for Senior Software Engineer
/// Do not plagiarize a soltuion from the internet.
/// Make sure to document your workings and algorithm with good use of comments.
/// 
/// Marks will be given for:
///     A soltuion that compiles with running unit tests
///     Working implementation of both methods GetMedianValue and GetMedianValueHighPerformance
///     Performance and memory usage of the implemented algorithms
///     Coding style and readability
///     Usage of test driven development
///     Completness of test cases and handling of edge cases
///     Soltuion used to validate the algorithm correctness for a large data set

/// Kyril Khaletsky

using System;
using System.Linq;

namespace ArtomatixCodingExercise {
    public class MedianCalculator {
        public static void Main(string[] argv) {


        }

        /// <summary>
        /// TODO Implement this method to return the median (middle number)
        /// of the given data set
        /// </summary>
        /// <param name="a">array of values to return the median for</param>
        /// <returns>The median value of the numbers passed</returns>
        static public double GetMedianValue(int[] a) {

            //based on the first Unit test provided I also assume that its the median of a sorted array
            double median;
            Array.Sort(a);

            //if its an even array
            if (a.Length % 2 == 0) {
                double med1 = a[a.Length / 2 - 1];
                double med2 = a[a.Length / 2];
                median = (med1 + med2) / 2;
                //or if its an odd array
            } else {
                median = a[a.Length / 2];
            }
            return median;
        }

        /// <summary>
        /// TODO: Implement a high performance algorithm to return the media number of 
        /// the combined data set.
        /// These arrays may contain 100's millions of numbers. It is advisable to avoid
        /// creating a combined array in memory.
        /// 
        /// Using Big O notation what is the efficiency of your algorithm?
        ///     -> My median algorithm is O(n/2) but can just be considered as O(n) 
        ///
        ///     -> Although the sort im using is O(nLogn) (Used inbuilt because its 
        ///        *probably* out of the scope of this excercise).
        /// 
        /// </summary>
        /// <param name="a">First array of data</param>
        /// <param name="b">Second array of data</param>
        /// <returns>The median value of all the values from both arrays</returns>
        static public double GetMedianValueHighPerformance(int[] a, int[] b) {

            //if a is empty use GetMedian on b
            if (a.Length == 0) {
                return GetMedianValue(b);
            //if a is empty use GetMedian on a
            } else if (b.Length == 0) {
                return GetMedianValue(a);
            //if both are empty return 0
            } else if (a.Length == 0 && b.Length == 0) {
                return 0;
            //if both have data run the alg
            } else {
                //sort both arrays
                Array.Sort(a);
                Array.Sort(b);

                //assign lenghts and sizes
                int len_a = a.Length;
                int len_b = b.Length;
                int total = len_a + len_b;

                double median = 0;
                double sec_median = 0;

                int i = 0;
                int j = 0;
                int z = 0;

                //if its an odd total array
                if (total % 2 != 0) {
                    if (len_a < len_b) {
                        //continue until we get the median index
                        while (z <= total / 2) {
                            //if we reached the end of the smaller array continue with the larger
                            if (i == a.Length - 1) {
                                median = b[j];
                                j++;
                                //if a[i] is bigger assign it as the median and increase the index
                            } else if (a[i] < b[j]) {
                                median = a[i];
                                i++;
                                //if b[j] is bigger assign it as the median and increase the index
                            } else {
                                median = b[j];
                                j++;
                            }
                            //increase the overall median index to stop at the median index later
                            z++;
                        }
                        //Same as above but if array a is larger than array b
                    } else if (len_a > len_b) {
                        while (z <= total / 2) {
                            if (j == b.Length - 1) {
                                median = b[j];
                                j++;
                            } else if (b[j] < a[i]) {
                                median = b[j];
                                j++;
                            } else {
                                median = a[i];
                                i++;
                            }
                            z++;
                        }
                    }
                    //if its an even total array
                } else {
                    //continue until we reached the median index
                    while (z <= (total / 2) - 1) {
                        //if we reached the last two indexes and the numbers are equal assign as median
                        if (z == (total / 2) - 1 && a[i] == b[j]) {
                            median = a[i];
                            return median;
                            //same process as earlier
                        } else if (a[i] <= b[j]) {
                            median = a[i];
                            i++;
                        } else {
                            median = b[j];
                            j++;
                        }
                        z++;
                    }
                    //if array a or b is larger get the MIN value of a[i] and b[j]
                    if (len_a != len_b) {
                        sec_median = Math.Min(a[i], b[j]);
                        //if we reached the end of array a then get the next value of array b
                    } else {
                        sec_median = b[j];
                    }
                    //get median if its an even number
                    median = (median + sec_median) / 2;
                }
                return median;
            }
        }     
    }
}
