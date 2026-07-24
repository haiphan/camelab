using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3514Tests {
    public static TheoryData<int[], int> Lc3514Data => new()
    {
        // nums, expected
        { [6, 7, 8, 9], 4 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3514Data))]
    public void Test_UniqueXorTriplets(int[] nums, int expected) {
        // Arrange
        var solution = new Lc3514Solution();

        // Act
        var result = solution.UniqueXorTriplets(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}