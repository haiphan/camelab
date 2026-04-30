using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3742Tests {
    public static TheoryData<int[][], int, int> Lc3742Data => new()
    {
        // grid, k, expectedResult
        { [[0, 1],[2, 0]], 1, 2 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3742Data))]
    public void Test_MaxPathScore(int[][] grid, int k, int expected) {
        // Arrange
        var solution = new Lc3742Solution();

        // Act
        var result = solution.MaxPathScore(grid, k);

        // Assert
        Assert.Equal(expected, result);
    }
}