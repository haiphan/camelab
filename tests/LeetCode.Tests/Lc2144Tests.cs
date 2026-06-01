using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2144Tests {
    public static TheoryData<int[], int> Lc2144Data => new()
    {
        // cost, expectedResult
        { [1, 2, 3], 5 },
    };
    
    [Theory]
    [MemberData(nameof(Lc2144Data))]
    public void Test_MinimumCost(int[] cost, int expected) {
        // Arrange
        var solution = new Lc2144Solution();

        // Act
        var result = solution.MinimumCost(cost);

        // Assert
        Assert.Equal(expected, result);
    }
}