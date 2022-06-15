using AlgorithmsAndDataStructures.Algorithms.Sorter;
using FluentAssertions;
using Xunit.Abstractions;

namespace Tests.AlgorithmsAndDataStructures.Algorithms
{
    public class SorterTests
    {
        private readonly ITestOutputHelper _output;

        public SorterTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void QuickSortTest()
        {
            // Arrange
            int[] arr = new int[] { 2, 5, -4, 11, 0, 18, 22, 67, 51, 6 };
            

            // Act
            Sorter.QuickSort(arr, 0, arr.Length-1);

            foreach (var item in arr)
                _output.WriteLine(" " + item);
            
            // Assert
            arr.Should().BeInAscendingOrder();
        }
    }
}