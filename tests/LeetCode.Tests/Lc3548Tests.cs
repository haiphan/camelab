using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3548Tests {
    public static TheoryData<int[][], bool> Lc3548Data => new()
    {
        // grid, expectedResult
        { [[1,2],[3,4]], true },
        { [[4,3,7],[5,3,3]], true },
        { [[1,1],[2,1],[4,3]], false },
    };
    
    [Theory]
    [MemberData(nameof(Lc3548Data))]
    public void Test_CanPartitionGrid(int[][] grid, bool expected) {
        // Arrange
        var solution = new Lc3548Solution();

        // Act
        var result = solution.CanPartitionGrid(grid);

        // Assert
        Assert.Equal(expected, result);
    }
}