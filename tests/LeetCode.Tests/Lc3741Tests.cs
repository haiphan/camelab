using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3741Tests {
    public static TheoryData<int[], int> Lc3741Data => new()
    {
        // nums, expectedResult
        { [1,2,1,1,3], 6 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3741Data))]
    public void Test_MinimumDistance(int[] nums, int expected) {
        // Arrange
        var solution = new Lc3741Solution();

        // Act
        var result = solution.MinimumDistance(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}