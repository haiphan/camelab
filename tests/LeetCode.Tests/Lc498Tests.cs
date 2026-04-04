using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc498Tests {
    public static TheoryData<int[][], int[]> Lc498Data => new()
    {
        // mat, expectedResult
        { [[1,2,3],[4,5,6],[7,8,9]], [1,2,4,7,5,3,6,8,9] },
    };
    
    [Theory]
    [MemberData(nameof(Lc498Data))]
    public void Test_FindDiagonalOrder(int[][] mat, int[] expected) {
        // Arrange
        var solution = new Lc498Solution();

        // Act
        var result = solution.FindDiagonalOrder(mat);

        // Assert
        Assert.Equal(expected, result);
    }
}