using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc462Tests {
    public static TheoryData<int[], int> Lc462Data => new()
    {
        // nums, expected
        {[1, 2, 3], 2}
    };
    
    [Theory]
    [MemberData(nameof(Lc462Data))]
    public void Test_MinMoves2(int[] nums, int expected) {
        // Arrange
        var solution = new Lc462Solution();

        // Act
        var result = solution.MinMoves2(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}