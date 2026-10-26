using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3619Tests {
    public static TheoryData<int[][], int, int> Lc3619Data => new()
    {
        // grid, k, expected
        {[[0,2,1,0,0],[0,5,0,0,5],[0,0,1,0,0],[0,1,4,7,0],[0,2,0,0,8]], 5, 2},
        {[[0,0,0],[0,0,1],[11,0,6],[0,10,2],[0,0,0],[8,0,0]], 19, 1}
    };
    
    [Theory]
    [MemberData(nameof(Lc3619Data))]
    public void Test_CountIslands(int[][] grid, int k, int expected) {
        // Arrange
        var solution = new Lc3619Solution();

        // Act
        var result = solution.CountIslands(grid, k);

        // Assert
        Assert.Equal(expected, result);
    }
}