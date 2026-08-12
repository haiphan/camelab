using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2958Tests {
    public static TheoryData<int[], int, int> Lc2958Data => new()
    {
        // nums, k, expected
        { [1,2,3,1,2,3,1,2], 2, 6 },
        { [1,2,1], 3, 3 },
    };
    
    [Theory]
    [MemberData(nameof(Lc2958Data))]
    public void Test_MaxSubarrayLength(int[] nums, int k, int expected) {
        // Arrange
        var solution = new Lc2958Solution();

        // Act
        var result = solution.MaxSubarrayLength(nums, k);

        // Assert
        Assert.Equal(expected, result);
    }
}