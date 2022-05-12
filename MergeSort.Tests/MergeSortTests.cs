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
        public static IEnumerable<object[]> Data {
            get
            {
                yield return new object[] { new List<int> { 600, 42, 2112 }, new List<int> { 42, 600, 2112 } };
                yield return new object[] { new List<int> { 600, 42, 2112, 1000, 950 }, new List<int> { 42, 600, 950, 1000, 2112 } };
                yield return new object[] { new List<int> { 300, 600, 42, 2112 }, new List<int> { 42, 300, 600, 2112 } };
                yield return new object[] { new List<int> { 200, 100, 12, 1112 }, new List<int> { 12, 300, 200, 1112 } };

            }
        }

    }
}
