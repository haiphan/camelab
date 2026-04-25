using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3464Tests {
    public static TheoryData<int, int[][], int, int> Lc3464Data => new()
    {
        // side, points, k, expectedResult
        { 2, [[0,2],[2,0],[2,2],[0,0]], 4, 2 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3464Data))]
    public void Test_MaxDistance(int side, int[][] points, int k, int expected) {
        // Arrange
        var solution = new Lc3464Solution();

        // Act
        var result = solution.MaxDistance(side, points, k);

        // Assert
        Assert.Equal(expected, result);
    }
}