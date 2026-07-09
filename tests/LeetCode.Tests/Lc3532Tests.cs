using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3532Tests {
    public static TheoryData<int, int[], int, int[][], bool[]> Lc3532Data => new()
    {
        // n, nums, maxDiff, queries, expected
        { 2, [1, 3], 1, [[0,0],[0,1]], [true,false] },
    };
    
    [Theory]
    [MemberData(nameof(Lc3532Data))]
    public void Test_PathExistenceQueries(int n, int[] nums, int maxDiff, int[][] queries, bool[] expected) {
        // Arrange
        var solution = new Lc3532Solution();

        // Act
        var result = solution.PathExistenceQueries(n, nums, maxDiff, queries);

        // Assert
        Assert.Equal(expected, result);
    }
}