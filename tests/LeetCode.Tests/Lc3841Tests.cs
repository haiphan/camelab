using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3841Tests {
    public static TheoryData<int, int[][], string, string[], IList<bool>> Lc3841Data => new()
    {
        // n, edges, s, queries, expected
        { 3, [[0,1],[1,2]], "aac", ["query 0 2","update 1 b","query 0 2"], [true, false]}
    };
    
    [Theory]
    [MemberData(nameof(Lc3841Data))]
    public void Test_PalindromePath(int n, int[][] edges, string s, string[] queries, IList<bool> expected) {
        // Arrange
        var solution = new Lc3841Solution();

        // Act
        var result = solution.PalindromePath(n, edges, s, queries);

        // Assert
        Assert.Equal(expected, result);
    }
}