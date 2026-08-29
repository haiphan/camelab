using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2948Tests {
    public static TheoryData<int[], int, int[]> Lc2948Data => new()
    {
        // nums, limit, expected
        { [1,5,3,9,8], 2, [1,3,5,8,9] }
    };
    
    [Theory]
    [MemberData(nameof(Lc2948Data))]
    public void Test_LexicographicallySmallestArray(int[] nums, int limit, int[] expected) {
        // Arrange
        var solution = new Lc2948Solution();

        // Act
        var result = solution.LexicographicallySmallestArray(nums, limit);

        // Assert
        Assert.Equal(expected, result);
    }
}