using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3550Tests {
    public static TheoryData<int[], int> Lc3550Data => new()
    {
        // nums, expected
        { [1, 3, 2], 2}
    };
    
    [Theory]
    [MemberData(nameof(Lc3550Data))]
    public void Test_SmallestIndex(int[] nums, int expected) {
        // Arrange
        var solution = new Lc3550Solution();

        // Act
        var result = solution.SmallestIndex(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}