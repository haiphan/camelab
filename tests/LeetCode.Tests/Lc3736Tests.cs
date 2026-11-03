using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3736Tests {
    public static TheoryData<int[], int> Lc3736Data => new()
    {
        // nums, expected
        { [2,1,3], 3}
    };
    
    [Theory]
    [MemberData(nameof(Lc3736Data))]
    public void Test_MinMoves(int[] nums, int expected) {
        // Arrange
        var solution = new Lc3736Solution();

        // Act
        var result = solution.MinMoves(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}