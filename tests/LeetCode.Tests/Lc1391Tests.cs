using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1391Tests {
    public static TheoryData<int[][], bool> Lc1391Data => new()
    {
        // grid, expectedResult
        { [[2,4,3],[6,5,2]], true },
        { [[1,2,3],[5,6,7]], false },
    };
    
    [Theory]
    [MemberData(nameof(Lc1391Data))]
    public void Test_HasValidPath(int[][] grid, bool expected) {
        // Arrange
        var solution = new Lc1391Solution();

        // Act
        var result = solution.HasValidPath(grid);

        // Assert
        Assert.Equal(expected, result);
    }
}