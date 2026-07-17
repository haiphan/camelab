using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3312Tests {
    public static TheoryData<int[], long[], int[]> Lc3312Data => new()
    {
        // nums, queries, expected
        {[2,3,4], [0,2,2], [1,2,2]},
        {[4,4,2,1], [5,3,1,0], [4,2,1,1]},
    };
    
    [Theory]
    [MemberData(nameof(Lc3312Data))]
    public void Test_GcdValues(int[] nums, long[] queries, int[] expected) {
        // Arrange
        var solution = new Lc3312Solution();

        // Act
        var result = solution.GcdValues(nums, queries);

        // Assert
        Assert.Equal(expected, result);
    }
}