using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc628Tests {
    public static TheoryData<int[], int> Lc628Data => new()
    {
        // nums, expected
        { [1, 2, 3], 6 },
        { [1, 2, 3, 4], 24 },
        { [0, 0, 0], 0 },
        { [-1, -2, -3], -6 },
    };
    
    [Theory]
    [MemberData(nameof(Lc628Data))]
    public void Test_MaximumProduct(int[] nums, int expected) {
        // Arrange
        var solution = new Lc628Solution();

        // Act
        var result = solution.MaximumProduct(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}