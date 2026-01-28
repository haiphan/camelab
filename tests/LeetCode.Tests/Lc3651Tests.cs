using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3651Tests {
    public static TheoryData<int[][], int, int> Lc3651Data => new()
    {
        { [[1,3,3],[2,5,4],[4,3,5]], 2, 7 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3651Data))]
    public void Test_MinCost(int[][] grid, int k, int expected) {
        // Arrange
        var solution = new Lc3651Solution();

        // Act
        var result = solution.MinCost(grid, k);

        // Assert
        Assert.Equal(expected, result);
    }
}