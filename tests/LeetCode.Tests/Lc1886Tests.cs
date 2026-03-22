using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1886Tests {
    public static TheoryData<int[][], int[][], bool> Lc1886Data => new()
    {
        // mat, target, expectedResult
        { [[0,1],[1,0]], [[1,0],[0,1]], true },
        { [[0,1],[1,1]], [[1,0],[0,1]], false },
    };
    
    [Theory]
    [MemberData(nameof(Lc1886Data))]
    public void Test_FindRotation(int[][] mat, int[][] target, bool expected) {
        // Arrange
        var solution = new Lc1886Solution();

        // Act
        var result = solution.FindRotation(mat, target);

        // Assert
        Assert.Equal(expected, result);
    }
}