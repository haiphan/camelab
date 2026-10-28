using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3882Tests {
    public static TheoryData<int[][], int> Lc3882Data => new()
    {
        // grid, expected
        {[[1,2],[3,4]], 6}
    };
    
    [Theory]
    [MemberData(nameof(Lc3882Data))]
    public void Test_MinCost(int[][] grid, int expected) {
        // Arrange
        var solution = new Lc3882Solution();

        // Act
        var result = solution.MinCost(grid);

        // Assert
        Assert.Equal(expected, result);
    }
}