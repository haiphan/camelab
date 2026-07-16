using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3867Tests {
    public static TheoryData<int[], long> Lc3867Data => new()
    {
        // nums, expected
        {[2,6,4], 2},
    };
    
    [Theory]
    [MemberData(nameof(Lc3867Data))]
    public void Test_GcdSum(int[] nums, long expected) {
        // Arrange
        var solution = new Lc3867Solution();

        // Act
        var result = solution.GcdSum(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}