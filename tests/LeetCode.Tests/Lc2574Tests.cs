using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2574Tests {
    public static TheoryData<int[], int[]> Lc2574Data => new()
    {
        // nums, expectedResult
        { [10,4,8,3], [15,1,11,22] },
    };
    
    [Theory]
    [MemberData(nameof(Lc2574Data))]
    public void Test_LeftRightDifference(int[] nums, int[] expected) {
        // Arrange
        var solution = new Lc2574Solution();

        // Act
        var result = solution.LeftRightDifference(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}