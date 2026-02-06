using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3634Tests {
    public static TheoryData<int[], int, int> Lc3634Data => new()
    {
        // nums, k, expectedResult
        { new int[] {2, 1, 5}, 2, 1 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3634Data))]
    public void Test_MinRemoval(int[] nums, int k, int expected) {
        // Arrange
        var solution = new Lc3634Solution();

        // Act
        var result = solution.MinRemoval(nums, k);

        // Assert
        Assert.Equal(expected, result);
    }
}