using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2996Tests {
    public static TheoryData<int[], int> Lc2996Data => new()
    {
        // nums, expected
        { [1,2,3,2,5], 6 },
        { [3,4,5,1,12,14,13], 15 },
    };
    
    [Theory]
    [MemberData(nameof(Lc2996Data))]
    public void Test_MissingInteger(int[] nums, int expected) {
        // Arrange
        var solution = new Lc2996Solution();

        // Act
        var result = solution.MissingInteger(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}