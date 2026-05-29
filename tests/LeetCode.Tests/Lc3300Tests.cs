using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3300Tests {
    public static TheoryData<int[], int> Lc3300Data => new()
    {
        // nums, expectedResult
        { [123, 456, 789], 6 },
        { [10, 20, 30], 1 },
        { [9999, 8888, 7777], 28 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3300Data))]
    public void Test_MinElement(int[] nums, int expected) {
        // Arrange
        var solution = new Lc3300Solution();

        // Act
        var result = solution.MinElement(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}