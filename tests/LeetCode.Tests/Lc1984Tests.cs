using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1984Tests {
    [Theory]
    [InlineData(new int[] { 9,4,1,7 }, 2, 2)]
    public void Test_MinimumDifference(int[] nums, int k, int expected) {
        // Arrange
        var solution = new Lc1984Solution();

        // Act
        var result = solution.MinimumDifference(nums, k);

        // Assert
        Assert.Equal(expected, result);
    }
}