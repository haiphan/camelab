using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3364Tests {
    public static TheoryData<IList<int>, int, int, int> Lc3364Data => new()
    {
        // nums, l, r, expected
        {[3, -2, 1, 4], 2, 3, 1}
    };
    
    [Theory]
    [MemberData(nameof(Lc3364Data))]
    public void Test_MinimumSumSubarray(IList<int> nums, int l, int r, int expected) {
        // Arrange
        var solution = new Lc3364Solution();

        // Act
        var result = solution.MinimumSumSubarray(nums, l, r);

        // Assert
        Assert.Equal(expected, result);
    }
}