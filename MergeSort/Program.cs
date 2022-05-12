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
           
            Console.WriteLine("Original List elements:");
            for (int i = 0; i < sizeOfArray; i++)
            {
                unsorted.Add(random.Next(0, 100));
                Console.Write(unsorted[i] + " ");
            }
            Console.WriteLine();

            sorted = MergeSort(unsorted);

            Console.WriteLine("Sorted List elements: ");
            foreach (int x in sorted)
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
    }
}
