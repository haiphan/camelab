using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3420Tests {
    public static TheoryData<int[], int, long> Lc3420Data => new()
    {
        // nums, k, expected
        {[6,3,1,2,4,4], 7, 17}
    };
    
    [Theory]
    [MemberData(nameof(Lc3420Data))]
    public void Test_CountNonDecreasingSubarrays(int[] nums, int k, long expected) {
        // Arrange
        var solution = new Lc3420Solution();

        // Act
        var result = solution.CountNonDecreasingSubarrays(nums, k);

        // Assert
        Assert.Equal(expected, result);
    }
}