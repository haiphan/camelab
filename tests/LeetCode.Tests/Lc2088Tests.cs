using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2088Tests {
    public static TheoryData<int[][], int> Lc2088Data => new()
    {
        // grid, expectedResult
        { [[0,1,1,0],[1,1,1,1]], 2 },
        { [[1,1,1],[1,1,1]], 2 },
    };
    
    [Theory]
    [MemberData(nameof(Lc2088Data))]
    public void Test_CountPyramids(int[][] grid, int expected) {
        // Arrange
        var solution = new Lc2088Solution();

        // Act
        var result = solution.CountPyramids(grid);

        // Assert
        Assert.Equal(expected, result);
    }
}