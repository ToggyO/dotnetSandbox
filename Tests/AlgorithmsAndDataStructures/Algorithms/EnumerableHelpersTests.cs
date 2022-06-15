using FluentAssertions;
using EnumerableHelpers = AlgorithmsAndDataStructures.Algorithms.EnumerableHelpers.EnumerableHelpers;

namespace Tests.AlgorithmsAndDataStructures.Algorithms.EnumerableHelpersTests
{
    public class SearcherTests
    {
        [Fact]
        public void BinarySearch_ReturnDesiredValue()
        {
            // Arrange
            var data = CreateListOfIntegers(100);

            // Act
            var position = EnumerableHelpers.BinarySearch(data, 76);

            // Assert
            position.Should().Be(75);
        }

        [Fact]
        public void Sum_ReturnSumOfIntEnumerable()
        {
            // Arrange
            var data = CreateListOfIntegers(6);
            
            // Act
            var sum = EnumerableHelpers.Sum(data);
            
            // Assert
            sum.Should().Be(21);
        }

        [Fact]
        public void Max_ReturnMaxValueOfIntEnumerable()
        {
            // Arrange
            var data = CreateListOfIntegers(6);
            
            // Act
            var sum = EnumerableHelpers.Max(data);
            
            // Assert
            sum.Should().Be(6);
        }

        private IList<int> CreateListOfIntegers(int maxValue)
        {
            var data = new List<int>(maxValue);
            for (int i = 1; i <= maxValue; i++)
                data.Add(i);

            return data;
        }
    }
}