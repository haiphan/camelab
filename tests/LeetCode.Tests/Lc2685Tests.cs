using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2685Tests {
    public static TheoryData<int, int[][], int> Lc2685Data => new()
    {
        // n, edges, expected
        { 6, [[0,1],[0,2],[1,2],[3,4]], 3 },
        { 5, [[1,2],[3,4],[1,4],[2,3],[1,3],[2,4]], 2 }
    };
    
    [Theory]
    [MemberData(nameof(Lc2685Data))]
    public void Test_CountCompleteComponents(int n, int[][] edges, int expected) {
        // Arrange
        var solution = new Lc2685Solution();

        // Act
        var result = solution.CountCompleteComponents(n, edges);

        // Assert
        Assert.Equal(expected, result);
    }
}