using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3559Tests {
    public static TheoryData<int[][], int[][], int[]> Lc3559Data => new()
    {
        // edges, queries, expectedResult (hop distance between query pairs)
        { [[1,2]], [[1,1],[1,2]], [0,1] },
        { [[1,2],[1,3],[3,4],[3,5]], [[1,4],[3,4],[2,5]], [2,1,4] },

    };
    
    [Theory]
    [MemberData(nameof(Lc3559Data))]
    public void Test_AssignEdgeWeights(int[][] edges, int[][] queries, int[] expected) {
        // Arrange
        var solution = new Lc3559Solution();

        // Act
        var result = solution.AssignEdgeWeights(edges, queries);

        // Assert
        Assert.Equal(expected, result);
    }
}