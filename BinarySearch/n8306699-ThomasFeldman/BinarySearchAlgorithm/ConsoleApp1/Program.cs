using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchAlgorithm
{
    /* Binary Search Algorith
     * Name: Thomas Feldman
     * Student No. n8306699
     * Date Due: 15/04/18
     * 
     * Code below for generation of sorted arrays
     * Some commented code for debugging purposes
     * BinarySearch() conducted as originally intended, with single addition to collect basic op count
     */  
        class Program
        {
            //Variable for Array Generation
            public static int[] Array;
            //Variable for counting basic operations
            public static int baseOpCount;
            //Stopwatch - used to count milliseconds for each binary search method
            public static Stopwatch stopwatch = new Stopwatch();

            public static double timeAvg;
            public static int baseCountAvg;

            /*
             * Main Method: Houses the code necessary for the generation of informations used in testing
             * Each line serves a purpose for generating each individual data point
             * 
             */

            static void Main(string[] args)
            {
                timeAvg = 0;
                baseCountAvg = 0;
                int y = 0;
                do
                {
                    baseOpCount = 0;
                    //Generat the array based on loop input
                    Array = createArray(5);

                    //Generate a random key value to search for avg case efficiency
                    //Random rnd = new Random();
                    //int K = rnd.Next(0, Array.Length-1);

                    //Key not inside array gives worse case
                    //int K = -10;
                    //Middle value for best case
                    int K =(Array.Length-1)/2;

                    //Start Stopwatch, run the search algorithm, then stop the stopwatch for accurate timing of elapsed time per run
                    stopwatch.Start();
                    int index = BinarySearch(Array, K);
                    stopwatch.Stop();

                    //Out results to text. I did this to make life easier when it came to graphing data
                    //Below is all for debugging purposes
                    //File.AppendAllText(@"E:\n8306699\CAB301\TimeFor100Tests.txt", stopwatch.Elapsed.TotalMilliseconds + Environment.NewLine);
                    //timeAvg += stopwatch.Elapsed.TotalMilliseconds;
                    //baseCountAvg += baseOpCount;
                    //Testing Outputs
                    //Console.WriteLine(Array.Length + " in length");
                    //Console.WriteLine(baseOpCount);
                    //Console.WriteLine($"Total ms = {stopwatch.Elapsed.TotalMilliseconds}");
                    File.AppendAllText(@"E:\n8306699\CAB301\BaseOpCount.txt", baseOpCount.ToString());
                    //Reset Stopwatch for next run
                    stopwatch.Reset();
                    //increment y to progress loop
                    y++;
                } while (y <= 10);

                //File.AppendAllText(@"E:\n8306699\CAB301\AverageTimeFor100Tests.txt", (timeAvg / 100).ToString() + "   " + (baseCountAvg/100) + "  "+Array.Length + Environment.NewLine);


                Console.ReadKey();
            }

            //Generate Array from 0 to given value+1
            private static int[] createArray(int n)
            {
                //Array = Add numbers via enumerable, from the range 0 to passed value +1, then add to array and return
                Array = Enumerable.Range(0, n).ToArray();
                return Array;
            }

            //Standard Binary Search, contsructed as closely as possible to the given algorigthms psuedocode 
            public static int BinarySearch(int[] a, int K)
            {
                //local variable for search
                int l = 0;
                int n = Array.Length;
                int r = n - 1;

                //While the first index is less than the last index, loop
                while (l <= r)
                {
                    //local variable for middle of array
                    int m = ((l + r) / 2);
                    //call public variable for the basic operations count
                    //Doing this here allow us to accurately count how many times the program compares the key to the middle value, which is our basic operation               
                    baseOpCount += 1;

                    //If the key value we are searching for is equal to the middle, the we can return that value and break the loop
                    if (K == Array[m])
                    {
                        return m;
                        //Else if it isnt the middle value, check if it is smaller, then change the length of the array to 1 less than the middle and go again
                    }
                    else if (K < Array[m])
                    {
                        r = m - 1;
                    }
                    //Else if it isnt the middle value or smaller, then change the first index the 1 + the middle and go again
                    else
                    {
                        l = m + 1;
                    }
                }
                //If the loop ends without finding the key value, return -1 to indicate that the searched value was not contained within the array
                return -1;

            }
        }
    }

