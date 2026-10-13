using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3727Tests {
    public static TheoryData<int[], long> Lc3727Data => new()
    {
        // nums, expected
        { [1,2,3], 12}
    };
    
    [Theory]
    [MemberData(nameof(Lc3727Data))]
    public void Test_MaxAlternatingSum(int[] nums, long expected) {
        // Arrange
        var solution = new Lc3727Solution();

        // Act
        var result = solution.MaxAlternatingSum(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}