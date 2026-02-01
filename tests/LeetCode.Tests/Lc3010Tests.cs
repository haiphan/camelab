using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3010Tests {
    public static TheoryData<int[], int> Lc3010Data => new()
    {
        // nums, expectedResult
        { [1,2,3,12], 6 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3010Data))]
    public void Test_MinimumCost(int[] nums, int expected) {
        // Arrange
        var solution = new Lc3010Solution();

        // Act
        var result = solution.MinimumCost(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}