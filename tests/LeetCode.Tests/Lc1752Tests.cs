using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1752Tests {
    public static TheoryData<int[], bool> Lc1752Data => new()
    {
        // nums, expectedResult
        { [3,4,5,1,2], true },
        { [2,1,3,4], false },
        { [1,2,3], true },
        { [1], true },
    };
    
    [Theory]
    [MemberData(nameof(Lc1752Data))]
    public void Test_Check(int[] nums, bool expected) {
        // Arrange
        var solution = new Lc1752Solution();

        // Act
        var result = solution.Check(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}