using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3620Tests {
    public static TheoryData<int[][], bool[], long, int> Lc3620Data => new()
    {
        // edges, online, k, expected
        { [[0,1,7],[1,4,5],[0,2,6],[2,3,6],[3,4,2],[2,4,6]], [true,true,true,false,true], 12, 6 }
    };
    
    [Theory]
    [MemberData(nameof(Lc3620Data))]
    public void Test_FindMaxPathScore(int[][] edges, bool[] online, long k, int expected) {
        // Arrange
        var solution = new Lc3620Solution();

        // Act
        var result = solution.FindMaxPathScore(edges, online, k);

        // Assert
        Assert.Equal(expected, result);
    }
}