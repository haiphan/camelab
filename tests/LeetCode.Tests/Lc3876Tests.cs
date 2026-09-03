using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3876Tests {
    public static TheoryData<int[], bool> Lc3876Data => new()
    {
        // nums1, expected
        { [1, 4, 7], true },
    };
    
    [Theory]
    [MemberData(nameof(Lc3876Data))]
    public void Test_UniformArray(int[] nums1, bool expected) {
        // Arrange
        var solution = new Lc3876Solution();

        // Act
        var result = solution.UniformArray(nums1);

        // Assert
        Assert.Equal(expected, result);
    }
}