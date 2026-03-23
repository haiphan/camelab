using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1594Tests {
    public static TheoryData<int[][], int> Lc1594Data => new()
    {
        // grid, expectedResult
        { [[-1,-2,-3],[-2,-3,-3],[-3,-3,-2]], -1 },
        { [[1,-2,1],[1,-2,1],[3,-4,1]], 8 },
    };
    
    [Theory]
    [MemberData(nameof(Lc1594Data))]
    public void Test_MaxProductPath(int[][] grid, int expected) {
        // Arrange
        var solution = new Lc1594Solution();

        // Act
        var result = solution.MaxProductPath(grid);

        // Assert
        Assert.Equal(expected, result);
    }
}