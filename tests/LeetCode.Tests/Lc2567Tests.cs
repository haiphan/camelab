using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2567Tests {
    public static TheoryData<int[], int> Lc2567Data => new()
    {
        // nums, expected
        { [1,4,7,8,5], 3 }
    };
    
    [Theory]
    [MemberData(nameof(Lc2567Data))]
    public void Test_MinimizeSum(int[] nums, int expected) {
        // Arrange
        var solution = new Lc2567Solution();

        // Act
        var result = solution.MinimizeSum(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}