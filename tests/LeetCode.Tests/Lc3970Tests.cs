using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3970Tests {
    public static TheoryData<int, int[][], string, int, int> Lc3970Data => new()
    {
        // n, edges, labels, k, expected
        {3, [[0,1,1],[1,2,1],[0,2,3]], "aab", 1, 3}
    };
    
    [Theory]
    [MemberData(nameof(Lc3970Data))]
    public void Test_ShortestPath(int n, int[][] edges, string labels, int k, int expected) {
        // Arrange
        var solution = new Lc3970Solution();

        // Act
        var result = solution.ShortestPath(n, edges, labels, k);

        // Assert
        Assert.Equal(expected, result);
    }
}