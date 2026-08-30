using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2091Tests {
    public static TheoryData<int[], int> Lc2091Data => new()
    {
        // nums, expected
        { [2,10,7,5,4,1,8,6], 5 },
    };
    
    [Theory]
    [MemberData(nameof(Lc2091Data))]
    public void Test_MinimumDeletions(int[] nums, int expected) {
        // Arrange
        var solution = new Lc2091Solution();

        // Act
        var result = solution.MinimumDeletions(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}