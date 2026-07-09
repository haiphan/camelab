using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3756Tests {
    public static TheoryData<string, int[][], int[]> Lc3756Data => new()
    {
        // s, queries, expected
        { "10203004", [[0,7],[1,3],[4,6]], [12340, 4, 9] },
        { "1000", [[1,3]], [0] },
        { "101", [[1,2]], [1] },
    };
    
    [Theory]
    [MemberData(nameof(Lc3756Data))]
    public void Test_SumAndMultiply(string s, int[][] queries, int[] expected) {
        // Arrange
        var solution = new Lc3756Solution();

        // Act
        var result = solution.SumAndMultiply(s, queries);

        // Assert
        Assert.Equal(expected, result);
    }
}