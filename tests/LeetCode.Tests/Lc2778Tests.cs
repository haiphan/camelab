using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2778Tests {
    public static TheoryData<int[], int> Lc2778Data => new()
    {
        // nums, expected
        { [1, 2, 3, 4], 21 }
    };
    
    [Theory]
    [MemberData(nameof(Lc2778Data))]
    public void Test_SumOfSquares(int[] nums, int expected) {
        // Arrange
        var solution = new Lc2778Solution();

        // Act
        var result = solution.SumOfSquares(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}