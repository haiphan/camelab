using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3650Tests {
    public static TheoryData<int, int[][], int> Lc3650Data => new()
    {
        // n, edges, expectedResult
        { 4, [[0,1,3], [3,1,1], [2,3,4], [0,2,2]], 5 },
        { 4, [[0,2,1],[2,1,1],[1,3,1],[2,3,3]], 3 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3650Data))]
    public void Test_MinCost(int n, int[][] edges, int expected) {
        // Arrange
        var solution = new Lc3650Solution();

        // Act
        var result = solution.MinCost(n, edges);

        // Assert
        Assert.Equal(expected, result);
    }
}