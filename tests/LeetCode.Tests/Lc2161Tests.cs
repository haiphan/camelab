using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2161Tests {
    public static TheoryData<int[], int, int[]> Lc2161Data => new()
    {
        // nums, pivot, expectedResult
        { [9,12,5,10,14,3,10], 10, [9,5,3,10,10,12,14] },
    };
    
    [Theory]
    [MemberData(nameof(Lc2161Data))]
    public void Test_PivotArray(int[] nums, int pivot, int[] expected) {
        // Arrange
        var solution = new Lc2161Solution();

        // Act
        var result = solution.PivotArray(nums, pivot);

        // Assert
        Assert.Equal(expected, result);
    }
}