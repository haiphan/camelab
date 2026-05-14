using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2784Tests {
    public static TheoryData<int[], bool> Lc2784Data => new()
    {
        // nums, expectedResult
        { [2,1,3], false },
    };
    
    [Theory]
    [MemberData(nameof(Lc2784Data))]
    public void Test_IsGood(int[] nums, bool expected) {
        // Arrange
        var solution = new Lc2784Solution();

        // Act
        var result = solution.IsGood(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}