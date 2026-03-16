using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1878Tests {
    public static TheoryData<int[][], int[]> Lc1878Data => new()
    {
        // grid, expectedResult
        { [[3,4,5,1,3],[3,3,4,2,3],[20,30,200,40,10],[1,5,5,4,1],[4,3,2,2,5]], [228,216,211] },
    };
    
    [Theory]
    [MemberData(nameof(Lc1878Data))]
    public void Test_GetBiggestThree(int[][] grid, int[] expected) {
        // Arrange
        var solution = new Lc1878Solution();

        // Act
        var result = solution.GetBiggestThree(grid);

        // Assert
        Assert.Equal(expected, result);
    }
}