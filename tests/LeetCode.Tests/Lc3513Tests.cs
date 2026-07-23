using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3513Tests {
    public static TheoryData<int[], int> Lc3513Data => new()
    {
        // nums, expected
        { [3, 1, 2], 4 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3513Data))]
    public void Test_UniqueXorTriplets(int[] nums, int expected) {
        // Arrange
        var solution = new Lc3513Solution();

        // Act
        var result = solution.UniqueXorTriplets(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}