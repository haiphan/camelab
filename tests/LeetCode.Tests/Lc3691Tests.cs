using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3691Tests {
    public static TheoryData<int[], int, long> Lc3691Data => new()
    {
        // nums, k, expected
        { [1,3,2], 2, 4 },
        { [9,9,37], 2, 56 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3691Data))]
    public void Test_MaxTotalValue(int[] nums, int k, long expected) {
        // Arrange
        var solution = new Lc3691Solution();

        // Act
        var result = solution.MaxTotalValue(nums, k);

        // Assert
        Assert.Equal(expected, result);
    }
}