using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3719Tests {
    public static TheoryData<int[], int> Lc3719Data => new()
    {
        // nums, expectedResult
        { [2,5,4,3], 4 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3719Data))]
    public void Test_LongestBalanced(int[] nums, int expected) {
        // Arrange
        var solution = new Lc3719Solution();

        // Act
        var result = solution.LongestBalanced(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}