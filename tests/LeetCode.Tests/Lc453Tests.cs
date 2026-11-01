using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc453Tests {
    public static TheoryData<int[], int> Lc453Data => new()
    {
        // nums, expected
        { new int[] {1, 2, 3}, 3 },
        { new int[] {1, 1, 1}, 0 },
    };
    
    [Theory]
    [MemberData(nameof(Lc453Data))]
    public void Test_MinMoves(int[] nums, int expected) {
        // Arrange
        var solution = new Lc453Solution();

        // Act
        var result = solution.MinMoves(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}