using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1Tests {
    [Theory]
    [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
    [InlineData(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
    [InlineData(new int[] { 3, 3 }, 6, new int[] { 0, 1 })]
    public void TestTwoSum(int[] nums, int target, int[] expected) {
        // Arrange
        var solution = new Lc1Solution();

        // Act
        var result = solution.TwoSum(nums, target);

        // Assert
        Assert.Equal(expected, result);
    }
}