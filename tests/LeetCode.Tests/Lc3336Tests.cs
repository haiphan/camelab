using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3336Tests {
    public static TheoryData<int[], int> Lc3336Data => new()
    {
        // nums, expected
        { [1,2,3,4], 10 },
        { [10,20,30], 2}
    };
    
    [Theory]
    [MemberData(nameof(Lc3336Data))]
    public void Test_SubsequencePairCount(int[] nums, int expected) {
        // Arrange
        var solution = new Lc3336Solution();

        // Act
        var result = solution.SubsequencePairCount(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}