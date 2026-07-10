using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3534Tests {
    public static TheoryData<int, int[], int, int[][], int[]> Lc3534Data => new()
    {
        // n, nums, maxDiff, queries, expected
        { 5, [1, 8, 3, 4, 2], 3, [[0,3],[2,4]], [1,1] },
        { 5, [5,3,1,9,10], 2, [[0,1],[0,2],[2,3],[4,3]], [1,2,-1,1] },
    };
    
    [Theory]
    [MemberData(nameof(Lc3534Data))]
    public void Test_PathExistenceQueries(int n, int[] nums, int maxDiff, int[][] queries, int[] expected) {
        // Arrange
        var solution = new Lc3534Solution();

        // Act
        var result = solution.PathExistenceQueries(n, nums, maxDiff, queries);

        // Assert
        Assert.Equal(expected, result);
    }
}