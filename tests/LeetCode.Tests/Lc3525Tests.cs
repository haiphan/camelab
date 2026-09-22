using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3525Tests {
    public static TheoryData<int[], int, int[][], int[]> Lc3525Data => new()
    {
        // nums, k, queries, expected
        { [1,2,3,4,5], 3, [[2,2,0,2],[3,3,3,0],[0,1,0,1]], [2, 2, 2] }
    };
    
    [Theory]
    [MemberData(nameof(Lc3525Data))]
    public void Test_ResultArray(int[] nums, int k, int[][] queries, int[] expected) {
        // Arrange
        var solution = new Lc3525Solution();

        // Act
        var result = solution.ResultArray(nums, k, queries);

        // Assert
        Assert.Equal(expected, result);
    }
}