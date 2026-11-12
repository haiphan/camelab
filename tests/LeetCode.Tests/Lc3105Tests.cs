using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3105Tests {
    public static TheoryData<int[], int> Lc3105Data => new()
    {
        // nums, expected
        {[1,4,3,3,2], 2}
    };
    
    [Theory]
    [MemberData(nameof(Lc3105Data))]
    public void Test_LongestMonotonicSubarray(int[] nums, int expected) {
        // Arrange
        var solution = new Lc3105Solution();

        // Act
        var result = solution.LongestMonotonicSubarray(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}