using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3020Tests {
    public static TheoryData<int[], int> Lc3020Data => new()
    {
        // nums, expected
        { [14,14,196,196,38416,38416], 5 },
        { [1,1], 1 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3020Data))]
    public void Test_MaximumLength(int[] nums, int expected) {
        // Arrange
        var solution = new Lc3020Solution();

        // Act
        var result = solution.MaximumLength(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}