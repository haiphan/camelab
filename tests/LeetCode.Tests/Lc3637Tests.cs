using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3637Tests {
    public static TheoryData<int[], bool> Lc3637Data => new()
    {
        // nums, expectedResult
        { new int[] {1,3,5,7,9,7}, false },
    };
    
    [Theory]
    [MemberData(nameof(Lc3637Data))]
    public void Test_IsTrionic(int[] nums, bool expected) {
        // Arrange
        var solution = new Lc3637Solution();

        // Act
        var result = solution.IsTrionic(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}