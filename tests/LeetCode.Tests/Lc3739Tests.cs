using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3739Tests {
    public static TheoryData<int[], int, long> Lc3739Data => new()
    {
        // nums, target, expected
        {[1,2,2,3], 2, 5}
    };
    
    [Theory]
    [MemberData(nameof(Lc3739Data))]
    public void Test_CountMajoritySubarrays(int[] nums, int target, long expected) {
        // Arrange
        var solution = new Lc3739Solution();

        // Act
        var result = solution.CountMajoritySubarrays(nums, target);

        // Assert
        Assert.Equal(expected, result);
    }
}