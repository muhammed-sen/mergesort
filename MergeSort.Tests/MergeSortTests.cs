using System;
using System.Collections.Generic;
using Xunit;

namespace MergeSort.Tests
{
    public class MergeSortTests
    {   
        [Theory]
        [MemberData(nameof(Data))]
        public void MergeSort_Order_Test(List<int> unsorted, List<int> expectedValue)
        {
            var result = MergeSort.Program.MergeSort(unsorted);
            Assert.Equal(expectedValue,result);

        }

        [Theory]
        [MemberData(nameof(ArrayData))]
        public void MergeSortWithArray_Order_Test(int[] unsorted, int[] expectedValue)
        {
            var result = MergeSort.Program.MergeSortWithArray(unsorted);
            Assert.Equal(expectedValue, result);

        }

        public static IEnumerable<object[]> Data {
            get
            {
                yield return new object[] { new List<int> { 600, 42, 2112 }, new List<int> { 42, 600, 2112 } };
                yield return new object[] { new List<int> { 600, 42, 2112, 1000, 950 }, new List<int> { 42, 600, 950, 1000, 2112 } };
                yield return new object[] { new List<int> { 300, 600, 42, 2112 }, new List<int> { 42, 300, 600, 2112 } };
            }
        }

        public static IEnumerable<object[]> ArrayData
        {
            get
            {
                yield return new object[] { new int[] { 600, 42, 2112 }, new int[] { 42, 600, 2112 } };
                yield return new object[] { new int[] { 600, 42, 2112, 1000, 950 }, new int[] { 42, 600, 950, 1000, 2112 } };
                yield return new object[] { new int[] { 300, 600, 42, 2112 }, new int[] { 42, 300, 600, 2112 } };
            }
        }

    }
}
