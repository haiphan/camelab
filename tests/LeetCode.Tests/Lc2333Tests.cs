using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2333Tests {
    public static TheoryData<int[], int[], int, int, long> Lc2333Data => new()
    {
        // nums1, nums2, k1, k2, expected
        { [1, 2, 3, 4], [2, 10, 20, 19], 0, 0, 579 }
    };
    
    [Theory]
    [MemberData(nameof(Lc2333Data))]
    public void Test_MinSumSquareDiff(int[] nums1, int[] nums2, int k1, int k2, long expected) {
        // Arrange
        var solution = new Lc2333Solution();

        // Act
        var result = solution.MinSumSquareDiff(nums1, nums2, k1, k2);

        // Assert
        Assert.Equal(expected, result);
    }
}