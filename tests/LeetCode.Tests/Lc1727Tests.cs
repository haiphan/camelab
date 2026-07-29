using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1727Tests {
    public static TheoryData<int[][], int> Lc1727Data => new()
    {
        // matrix, expectedResult
        { [[0,0,1],[1,1,1],[1,0,1]], 4 },
        { [[1,0,1,0,1]], 3 },
    };
    
    [Theory]
    [MemberData(nameof(Lc1727Data))]
    public void Test_LargestSubmatrix(int[][] matrix, int expected) {
        // Arrange
        var solution = new Lc1727Solution();

        // Act
        var result = solution.LargestSubmatrix(matrix);

        // Assert
        Assert.Equal(expected, result);
    }
}