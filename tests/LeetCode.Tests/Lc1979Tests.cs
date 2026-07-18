using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1979Tests {
    public static TheoryData<int[], int> Lc1979Data => new()
    {
        // nums, expected
        {[2,5,6,9,10], 2},
    };
    
    [Theory]
    [MemberData(nameof(Lc1979Data))]
    public void Test_FindGCD(int[] nums, int expected) {
        // Arrange
        var solution = new Lc1979Solution();

        // Act
        var result = solution.FindGCD(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}