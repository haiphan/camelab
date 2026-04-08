using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3653Tests {
    public static TheoryData<int[], int[][], int> Lc3653Data => new()
    {
        // nums, queries, expectedResult
        { [1,1,1], [[0,2,1,4]], 4 },
        {[2,3,1,5,4], [[1,4,2,3],[0,2,1,2]], 31},
        {[2,1,3,4], [[1,1,2,3], [0,1,2,4], [3,3,4,5]], 28}
    };
    
    [Theory]
    [MemberData(nameof(Lc3653Data))]
    public void Test_XorAfterQueries(int[] nums, int[][] queries, int expected) {
        // Arrange
        var solution = new Lc3653Solution();

        // Act
        var result = solution.XorAfterQueries(nums, queries);

        // Assert
        Assert.Equal(expected, result);
    }
}