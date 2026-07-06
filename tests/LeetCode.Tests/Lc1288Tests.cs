using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1288Tests {
    public static TheoryData<int[][], int> Lc1288Data => new()
    {
        // intervals, expected
        { [[1,4],[3,6],[2,8]], 2 },
        { [[1,4],[2,3]], 1 },
    };
    
    [Theory]
    [MemberData(nameof(Lc1288Data))]
    public void Test_RemoveCoveredIntervals(int[][] intervals, int expected) {
        // Arrange
        var solution = new Lc1288Solution();

        // Act
        var result = solution.RemoveCoveredIntervals(intervals);

        // Assert
        Assert.Equal(expected, result);
    }
}