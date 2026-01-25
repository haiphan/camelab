using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1877Tests {
    [Theory]
    [InlineData(new int[] { 3,5,2,3 }, 7)]
    public void Test_MinPairSum(int[] nums, int expected) {
        // Arrange
        var solution = new Lc1877Solution();

        // Act
        var result = solution.MinPairSum(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}