using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2540Tests {
    public static TheoryData<int[], int[], int> Lc2540Data => new()
    {
        // nums1, nums2, expectedResult
        { [1,2,3], [2,4], 2 },
        { [1,2,3], [4,5], -1 },
    };
    
    [Theory]
    [MemberData(nameof(Lc2540Data))]
    public void Test_GetCommon(int[] nums1, int[] nums2, int expected) {
        // Arrange
        var solution = new Lc2540Solution();

        // Act
        var result = solution.GetCommon(nums1, nums2);

        // Assert
        Assert.Equal(expected, result);
    }
}