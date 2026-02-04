using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3640Tests {
    public static TheoryData<int[], long> Lc3640Data => new()
    {
        // nums, expectedResult
        { new int[] {0,-2,-1,-3,0,2,-1}, -4 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3640Data))]
    public void Test_MaxSumTrionic(int[] nums, long expected) {
        // Arrange
        var solution = new Lc3640Solution();

        // Act
        var result = solution.MaxSumTrionic(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}