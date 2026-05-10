using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2770Tests {
    public static TheoryData<int[], int, int> Lc2770Data => new()
    {
        // nums, target, expectedResult
        { [1,3,6,4,1,2], 2, 3 },
        { [1,3,4,0,2], 2, 3}
    };
    
    [Theory]
    [MemberData(nameof(Lc2770Data))]
    public void Test_MaximumJumps(int[] nums, int target, int expected) {
        // Arrange
        var solution = new Lc2770Solution();

        // Act
        var result = solution.MaximumJumps(nums, target);

        // Assert
        Assert.Equal(expected, result);
    }
}