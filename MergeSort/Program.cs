using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeSort
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> unsorted = new List<int>(); 
            List<int> sorted;
            
            Random random = new Random();
            var sizeOfArray = random.Next(10, 100);
            int[] arrayUnsorted = new int[sizeOfArray];
            int[] arraySorted = new int[sizeOfArray];

            Console.WriteLine("Original List elements:");
            for (int i = 0; i < sizeOfArray; i++)
            {
                unsorted.Add(random.Next(0, 100));
                arrayUnsorted[i] = random.Next(0, 100);
                Console.Write(unsorted[i] + " ");
            }
            Console.WriteLine();

            sorted = MergeSort(unsorted);
            arraySorted = MergeSortWithArray(arrayUnsorted);
            Console.WriteLine("Sorted List elements: ");
            foreach (int x in sorted)
            {
                Console.Write(x + " ");
            }
            Console.Write("\n\n");

            Console.WriteLine("Original Array elements:");
            foreach (int x in arrayUnsorted)
            {
                Console.Write(x + " ");
            }
            Console.Write("\n");
            Console.WriteLine("Sorted Array elements: ");
            foreach (int x in arraySorted)
            {
                Console.Write(x + " ");
            }
            Console.Write("\n");
        }


        public static List<int> MergeSort(List<int> unsorted)
        {
            // return single element array
            if (unsorted.Count <= 1)
                return unsorted;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            // The  middle of our array  
            int middle = unsorted.Count / 2;

            //populate left array
            for (int i = 0; i < middle; i++)
            {
                left.Add(unsorted[i]);
            }
            //populate right array
            //We start our index from the middle, as we have already populated the left array from 0 to middle
            for (int i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }
            //Recursively sort the left array
            left = MergeSort(left);
            //Recursively sort the right array
            right = MergeSort(right);
            //Merge our two sorted arrays
            return Merge(left, right);
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            //while either array still has an element
            while (left.Count > 0 || right.Count > 0)
            {
                //if both arrays have elements  
                if (left.Count > 0 && right.Count > 0)
                {   //If item on left array is less than item on right array, add that item to the result array 
                    if (left.First() <= right.First()) 
                    {
                        result.Add(left.First());
                        //Rest of the list minus the first element
                        left.Remove(left.First());      
                    }
                    // otherwise the item in the right array wll be added to the results array
                    else
                    {
                        result.Add(right.First());
                        //Rest of the list minus the first element
                        right.Remove(right.First());
                    }
                }
                //if only the left array still has elements, add all its items to the results array
                else if (left.Count > 0)
                {
                    // AddRange adds the all element in the right to the result list
                    result.AddRange(left);
                    // remove all elements from the list, it will end the while loop
                    left.Clear();
                }
                //if only the right array still has elements, add all its items to the results array
                else if (right.Count > 0)
                {
                    // AddRange adds the all element in the right to the result list
                    result.AddRange(right);
                    // remove all elements from the list, it will end the while loop
                    right.Clear();
                   
                }
            }
            return result;
        }

        public static int[] MergeSortWithArray(int[] array)
        {
            int[] left;
            int[] right;

            // return single element array
            if (array.Length <= 1)
                return array;
            // The  middle of our array  
            int middle = array.Length / 2;
            //Will represent our 'left' array
            left = new int[middle];

            //Will represent our 'right' array
            right = new int[array.Length - middle];
          
            //populate left array
            for (int i = 0; i < middle; i++)
                left[i] = array[i];
            
            //populate right array   
            int x = 0;
            //We start our index from the middle, as we have already populated the left array from 0 to midpont
            for (int i = middle; i < array.Length; i++)
            {
                right[x] = array[i];
                x++;
            }
            //Recursively sort the left array
            left = MergeSortWithArray(left);
            //Recursively sort the right array
            right = MergeSortWithArray(right);
            //Merge our two sorted arrays
            
            return MergeWithArray(left, right); ;
        }

        public static int[] MergeWithArray(int[] left, int[] right)
        {
            int resultLength = right.Length + left.Length;
            int[] result = new int[resultLength];
            //
            int indexLeft = 0, indexRight = 0, indexResult = 0;
            //while either array still has an element
            while (indexLeft < left.Length || indexRight < right.Length)
            {
                //if both arrays have elements  
                if (indexLeft < left.Length && indexRight < right.Length)
                {
                    //If item on left array is less than item on right array, add that item to the result array 
                    if (left[indexLeft] <= right[indexRight])
                    {
                        result[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    // else the item in the right array wll be added to the results array
                    else
                    {
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }
                //if only the left array still has elements, add all its items to the results array
                else if (indexLeft < left.Length)
                {
                    while (indexLeft < left.Length)
                    {
                        result[indexResult] = left[indexLeft];
                        // iterate indexLeft to the length of left array
                        indexLeft++;
                        indexResult++;
                    }
                }
                //if only the right array still has elements, add all its items to the results array
                else if (indexRight < right.Length)
                {
                    while (indexRight < right.Length)
                    {
                        result[indexResult] = right[indexRight];
                        // iterate indexright to the length of right array
                        indexRight++;
                        indexResult++;
                    }
                }
            }
            return result;
        }


    }
}
