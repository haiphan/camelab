using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3379Tests {
    public static TheoryData<int[], int[]> Lc3379Data => new()
    {
        // nums, expectedResult
        { new int[] {3,-2,1,1}, new int[] {1, 1, 1, 3} },
    };
    
    [Theory]
    [MemberData(nameof(Lc3379Data))]
    public void Test_ConstructTransformedArray(int[] nums, int[] expected) {
        // Arrange
        var solution = new Lc3379Solution();

        // Act
        var result = solution.ConstructTransformedArray(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}