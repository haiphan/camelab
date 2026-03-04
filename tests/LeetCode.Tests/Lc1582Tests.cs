using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1582Tests {
    public static TheoryData<int[][], int> Lc1582Data => new()
    {
        // mat, expectedResult
        { [[1,0,0],[0,0,1],[1,0,0]], 1 },
    };
    
    [Theory]
    [MemberData(nameof(Lc1582Data))]
    public void Test_NumSpecial(int[][] mat, int expected) {
        // Arrange
        var solution = new Lc1582Solution();

        // Act
        var result = solution.NumSpecial(mat);

        // Assert
        Assert.Equal(expected, result);
    }
}