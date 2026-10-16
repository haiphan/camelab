using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2916Tests {
    public static TheoryData<int[], int> Lc2916Data => new()
    {
        // nums, expected
        { [1,2,1], 15}
    };
    
    [Theory]
    [MemberData(nameof(Lc2916Data))]
    public void Test_SumCounts(int[] nums, int expected) {
        // Arrange
        var solution = new Lc2916Solution();

        // Act
        var result = solution.SumCounts(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}