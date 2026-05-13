using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1674Tests {
    public static TheoryData<int[], int, int> Lc1674Data => new()
    {
        // nums, limit, expectedResult
        { [1,2,4,3], 4, 1 },
        { [1,2,2,1], 2, 2 },
        { [1,2,1,2], 2, 0 }
    };
    
    [Theory]
    [MemberData(nameof(Lc1674Data))]
    public void Test_MinMoves(int[] nums, int limit, int expected) {
        // Arrange
        var solution = new Lc1674Solution();

        // Act
        var result = solution.MinMoves(nums, limit);

        // Assert
        Assert.Equal(expected, result);
    }
}