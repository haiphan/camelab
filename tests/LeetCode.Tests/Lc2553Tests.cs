using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2553Tests {
    public static TheoryData<int[], int[]> Lc2553Data => new()
    {
        // nums, expectedResult
        { [13,25,83,77], [1,3,2,5,8,3,7,7] },
    };
    
    [Theory]
    [MemberData(nameof(Lc2553Data))]
    public void Test_SeparateDigits(int[] nums, int[] expected) {
        // Arrange
        var solution = new Lc2553Solution();

        // Act
        var result = solution.SeparateDigits(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}