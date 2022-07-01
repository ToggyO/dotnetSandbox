using AlgorithmsAndDataStructures.Algorithms.Sorter;

using FluentAssertions;

using Xunit.Abstractions;

namespace Tests.AlgorithmsAndDataStructures.Algorithms
{
    public class SorterTests
    {
        private readonly ITestOutputHelper _output;

        private int[] _sourceArray => new int[] { 2, 5, -4, 11, 0, 18, 22, 67, 51, 6 };


        public SorterTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void QuickSortTest()
        {
            // Arrange
            int[] arr = _sourceArray;
            

            // Act
            Sorter.QuickSort(arr, 0, arr.Length-1);

            foreach (var item in arr)
                _output.WriteLine(" " + item);
            
            // Assert
            arr.Should().BeInAscendingOrder();
        }

        [Fact]
        public void QuickSortV2Test()
        {
            // Arrange
            int[] arr = _sourceArray;
            

            // Act
            Sorter.QuickSortV2(arr);

            foreach (var item in arr)
                _output.WriteLine(" " + item);
            
            // Assert
            arr.Should().BeInAscendingOrder();
        }
    }
}