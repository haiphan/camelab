using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1855Tests {
    public static TheoryData<int[], int[], int> Lc1855Data => new()
    {
        // nums1, nums2, expectedResult
        { [55,30,5,4,2], [100,20,10,10,5], 2 },
    };
    
    [Theory]
    [MemberData(nameof(Lc1855Data))]
    public void Test_MaxDistance(int[] nums1, int[] nums2, int expected) {
        // Arrange
        var solution = new Lc1855Solution();

        // Act
        var result = solution.MaxDistance(nums1, nums2);

        // Assert
        Assert.Equal(expected, result);
    }
}