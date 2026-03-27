using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2946Tests {
    public static TheoryData<int[][], int, bool> Lc2946Data => new()
    {
        // mat, k, expectedResult
        { [[1,2,3],[4,5,6],[7,8,9]], 4, false },
        { [[1,2,3],[4,5,6],[7,8,9]], 3, true },
        { [[1,2,3],[4,5,6],[7,8,9]], 0, true },
    };
    
    [Theory]
    [MemberData(nameof(Lc2946Data))]
    public void Test_AreSimilar(int[][] mat, int k, bool expected) {
        // Arrange
        var solution = new Lc2946Solution();

        // Act
        var result = solution.AreSimilar(mat, k);

        // Assert
        Assert.Equal(expected, result);
    }
}