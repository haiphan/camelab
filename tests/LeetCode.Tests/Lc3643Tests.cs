using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3643Tests {
    public static TheoryData<int[][], int, int, int, int[][]> Lc3643Data => new()
    {
        // grid, x, y, k, expectedResult
        { [[1,2,3,4],[5,6,7,8],[9,10,11,12],[13,14,15,16]], 1, 0, 3, [[1,2,3,4],[13,14,15,8],[9,10,11,12],[5,6,7,16]]  },
    };
    
    [Theory]
    [MemberData(nameof(Lc3643Data))]
    public void Test_ReverseSubmatrix(int[][] grid, int x, int y, int k, int[][] expected) {
        // Arrange
        var solution = new Lc3643Solution();

        // Act
        var result = solution.ReverseSubmatrix(grid, x, y, k);

        // Assert
        Assert.Equal(expected, result);
    }
}