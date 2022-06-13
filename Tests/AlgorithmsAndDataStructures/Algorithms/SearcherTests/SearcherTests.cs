using System.Collections.Generic;
using AlgorithmsAndDataStructures.Algorithms.Searcher;
using FluentAssertions;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithms.SearcherTests
{
    public class SearcherTests
    {
        [Fact]
        public void BinarySearch_ReturnDesiredValue()
        {
            // Arrange
            var data = new List<int>();
            for (int i = 1; i <= 100; i++)
                data.Add(i);
            
            // Act
            var position = Searcher.BinarySearch(data, 76);

            // Assert
            position.Should().Be(75);
        }
    }
}