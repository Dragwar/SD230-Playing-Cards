using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;

namespace PlayingCardsDeck
{
    public static class ArrayHelper
    {
        /// <summary>
        ///     Provides random numbers and
        ///     this is a property because Random
        ///     produces random numbers based on the
        ///     seed (seed is made by the current DateTime)
        ///     (in other words this is just for random consistency)
        /// </summary>
        private static Random Random { get; } = new Random();

        /// <summary>
        ///     I'm trying out recursion to shuffle the arr multiple times.
        ///     This method will default to 5 passes (array gets shuffled 5 times)
        /// </summary>
        /// <param name="list">
        ///     Represents the array that will be shuffled
        /// </param>
        /// <param name="numberOfPassesLimit">
        ///     Determines many times the array will be shuffled
        /// </param>
        /// <param name="numberOfPassesCounter">
        ///     Counts the number of times this function gets invoked (similar to i in for...loops)
        /// </param>
        /// <returns>
        ///     Shuffled int array
        /// </returns>
        private static List<T> ShuffleLoop<T>(this List<T> list, int? numberOfPassesLimit, int numberOfPassesCounter = 0)
        {
            if (numberOfPassesCounter >= numberOfPassesLimit.Value)
            {
                return list;
            }

            // .OrderBy() will output something similar to .Sort() when:
            // Sort: ((new int[] {3,2,4}).Sort() -> {2,3,4})
            // OrderBy: ((new int[] {3,2,4}).OrderBy(n => n) -> {2,3,4})
            //
            // but .OrderBy() operates on element and key to sort (sorts by key value)
            // .OrderBy(n /* n is the current element of the current iteration */ => /* This is where you define a key to sort by */)
            // since I'm using Random.Next(), then .OrderBy() tries to sort by a random int key
            // (each iteration Random.Next() provides a new random int for the key)
            // in other words the currentNumber value is ignored when it comes to OrderBy and
            // the Random.Next() int key will be use to sort the array
            return list.OrderBy(currentNumber => Random.Next()).ToList().ShuffleLoop(numberOfPassesLimit.Value, numberOfPassesCounter + 1);
        }

        /// <summary>
        ///     Only using this to prevent user/dev from
        ///     changing numberOfPassesCounter parameter
        /// </summary>
        /// <param name="list">
        ///     Represents the array that will be shuffled
        /// </param>
        /// <param name="numberOfPassesLimit">
        ///     Determines many times the array will be shuffled
        /// </param>
        /// <returns>
        ///     Fully shuffled int array
        /// </returns>
        public static List<T> Shuffle<T>(this List<T> list, [Optional] int? numberOfPassesLimit)
        {
            // default to 5 if number is below 0, else if number is greater then 50 then default to 50
            if (numberOfPassesLimit.HasValue)
            {
                numberOfPassesLimit = numberOfPassesLimit < 0 ? 5 : numberOfPassesLimit > 50 ? 50 : numberOfPassesLimit;
            }
            else
            {
                numberOfPassesLimit = 5;
            }
            return list.ShuffleLoop(numberOfPassesLimit);
        }

        // Got this function from my Old JavaScript SD110 Final Project (memory card game)
        // I only added on a numberOfPasses functionality
        public static List<T> OldShuffle<T>(this List<T> array, int numberOfPasses = 1)
        {
            int currentIndex = array.Count, randomIndex, counter = 0;
            T temporaryValue;
            do
            {
                while (currentIndex != 0)
                {
                    randomIndex = Random.Next(0, array.Count);
                    currentIndex -= 1;
                    temporaryValue = array[currentIndex];
                    array[currentIndex] = array[randomIndex];
                    array[randomIndex] = temporaryValue;
                }
                counter++;
            } while (counter < numberOfPasses);

            return array;
        }


        /// <summary>
        ///     Simple Method to display an array of integers
        ///     on one line in the console
        /// </summary>
        /// <param name="list">
        ///     Array that will have its elements
        ///     displayed on oneline in the console
        /// </param>
        /// <returns>
        ///     Returns passed in array
        /// </returns>
        public static List<T> Display<T>(this List<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if ((i + 1) == list.Count)
                {
                    Console.Write("{0}\n\n", list[i]);
                }
                else
                {
                    Console.Write("{0}, ", list[i]);
                }
            }
            return list;
        }
    }
}