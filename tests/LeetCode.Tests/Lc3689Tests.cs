using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3689Tests {
    public static TheoryData<int[], int, long> Lc3689Data => new()
    {
        // nums, k, expected
        { [1,2,3], 3, 6 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3689Data))]
    public void Test_MaxTotalValue(int[] nums, int k, long expected) {
        // Arrange
        var solution = new Lc3689Solution();

        // Act
        var result = solution.MaxTotalValue(nums, k);

        // Assert
        Assert.Equal(expected, result);
    }
}