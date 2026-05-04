using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc48Tests {
    public static TheoryData<int[][], int[][]> Lc48Data => new()
    {
        // matrix, expectedResult
        { [[0,1],[1,0]], [[1,0],[0,1]] },
    };
    
    [Theory]
    [MemberData(nameof(Lc48Data))]
    public void Test_Rotate(int[][] matrix, int[][] expected) {
        // Arrange
        var solution = new Lc48Solution();

        // Act
        solution.Rotate(matrix);

        // Assert
        Assert.Equal(expected, matrix);
    }
}