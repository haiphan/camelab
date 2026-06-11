using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3558Tests {
    public static TheoryData<int[][], int> Lc3558Data => new()
    {
        // edges, expectedResult
        { [[1,2]], 1 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3558Data))]
    public void Test_AssignEdgeWeights(int[][] edges, int expected) {
        // Arrange
        var solution = new Lc3558Solution();

        // Act
        var result = solution.AssignEdgeWeights(edges);

        // Assert
        Assert.Equal(expected, result);
    }
}