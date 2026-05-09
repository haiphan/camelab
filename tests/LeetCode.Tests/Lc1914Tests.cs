using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1914Tests {
    public static TheoryData<int[][], int, int[][]> Lc1914Data => new()
    {
        // grid, k, expectedResult
        { [[40,10],[30,20]], 1, [[10,20],[40,30]] },
    };
    
    [Theory]
    [MemberData(nameof(Lc1914Data))]
    public void Test_RotateGrid(int[][] grid, int k, int[][] expected) {
        // Arrange
        var solution = new Lc1914Solution();

        // Act
        var result = solution.RotateGrid(grid, k);

        // Assert
        Assert.Equal(expected, result);
    }
}