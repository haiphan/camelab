using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3665Tests {
    public static TheoryData<int[][], int> Lc3665Data => new()
    {
        // grid, expected
        { [[0,1,0],[0,0,1],[1,0,0]], 5 }
    };
    
    [Theory]
    [MemberData(nameof(Lc3665Data))]
    public void Test_UniquePaths(int[][] grid, int expected) {
        // Arrange
        var solution = new Lc3665Solution();

        // Act
        var result = solution.UniquePaths(grid);

        // Assert
        Assert.Equal(expected, result);
    }
}