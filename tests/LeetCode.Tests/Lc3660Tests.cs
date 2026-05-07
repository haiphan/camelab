using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3660Tests {
    public static TheoryData<int[], int[]> Lc3660Data => new()
    {
        // nums, expectedResult
        { [2, 3, 1], [3, 3, 3] },
    };
    
    [Theory]
    [MemberData(nameof(Lc3660Data))]
    public void Test_MaxValue(int[] nums, int[] expected) {
        // Arrange
        var solution = new Lc3660Solution();

        // Act
        var result = solution.MaxValue(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}