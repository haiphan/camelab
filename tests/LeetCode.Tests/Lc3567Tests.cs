using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3567Tests {
    public static TheoryData<int[][], int, int[][]> Lc3567Data => new()
    {
        // grid, k, expectedResult
        { [[1,8],[3,-2]], 2, [[2]] },
    };
    
    [Theory]
    [MemberData(nameof(Lc3567Data))]
    public void Test_MinAbsDiff(int[][] grid, int k, int[][] expected) {
        // Arrange
        var solution = new Lc3567Solution();

        // Act
        var result = solution.MinAbsDiff(grid, k);

        // Assert
        Assert.Equal(expected, result);
    }
}