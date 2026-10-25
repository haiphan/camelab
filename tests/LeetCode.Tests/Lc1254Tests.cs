using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1254Tests {
    public static TheoryData<int[][], int> Lc1254Data => new()
    {
        // grid, expected
        {[[1,1,1,1,1,1,1,0],[1,0,0,0,0,1,1,0],[1,0,1,0,1,1,1,0],[1,0,0,0,0,1,0,1],[1,1,1,1,1,1,1,0]], 2}
    };
    
    [Theory]
    [MemberData(nameof(Lc1254Data))]
    public void Test_ClosedIsland(int[][] grid, int expected) {
        // Arrange
        var solution = new Lc1254Solution();

        // Act
        var result = solution.ClosedIsland(grid);

        // Assert
        Assert.Equal(expected, result);
    }
}