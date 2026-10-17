using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3551Tests {
    public static TheoryData<int[], int> Lc3551Data => new()
    {
        // nums, expected
        { [37, 100], 1 }
    };
    
    [Theory]
    [MemberData(nameof(Lc3551Data))]
    public void Test_MinSwaps(int[] nums, int expected) {
        // Arrange
        var solution = new Lc3551Solution();

        // Act
        var result = solution.MinSwaps(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}