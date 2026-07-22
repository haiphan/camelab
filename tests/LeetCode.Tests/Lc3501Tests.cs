using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3501Tests {
    public static TheoryData<string, int[][], IList<int>> Lc3501Data => new()
    {
        // s, quries, expected
        { "01", [[0,1]], new List<int> { 1 } },
        { "0100", [[0,3],[1,3],[0,1]], new List<int> { 4, 1, 1 } },
        { "001100", [[0,5],[1,4],[2,3]], new List<int> { 6, 4, 2 } },
    };
    
    [Theory]
    [MemberData(nameof(Lc3501Data))]
    public void Test_MaxActiveSectionsAfterTrade(string s, int[][] queries, IList<int> expected) {
        // Arrange
        var solution = new Lc3501Solution();

        // Act
        var result = solution.MaxActiveSectionsAfterTrade(s, queries);

        // Assert
        Assert.Equal(expected, result);
    }
}