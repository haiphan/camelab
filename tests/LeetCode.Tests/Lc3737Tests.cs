using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3737Tests {
    public static TheoryData<int[], int, int> Lc3737Data => new()
    {
        // nums, target, expected
        { [1,2,2,3], 2, 5 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3737Data))]
    public void Test_CountMajoritySubarrays(int[] nums, int target, int expected) {
        // Arrange
        var solution = new Lc3737Solution();

        // Act
        var result = solution.CountMajoritySubarrays(nums, target);

        // Assert
        Assert.Equal(expected, result);
    }
}