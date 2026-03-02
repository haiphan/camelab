using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1536Tests {
    public static TheoryData<int[][], int> Lc1536Data => new()
    {
        // grid, expectedResult
        { [[0,0,1],[1,1,0],[1,0,0]], 3 },
    };
    
    [Theory]
    [MemberData(nameof(Lc1536Data))]
    public void Test_MinSwaps(int[][] grid, int expected) {
        // Arrange
        var solution = new Lc1536Solution();

        // Act
        var result = solution.MinSwaps(grid);

        // Assert
        Assert.Equal(expected, result);
    }
}