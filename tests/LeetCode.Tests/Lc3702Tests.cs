using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3702Tests {
    public static TheoryData<int[], int> Lc3702Data => new()
    {
        // nums, expected
        { [1, 2, 3], 2 },
        { [2, 3, 4], 3 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3702Data))]
    public void Test_LongestSubsequence(int[] nums, int expected) {
        // Arrange
        var solution = new Lc3702Solution();

        // Act
        var result = solution.LongestSubsequence(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}