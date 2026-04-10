using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3740Tests {
    public static TheoryData<int[], int> Lc3740Data => new()
    {
        // nums, expectedResult
        { [1,2,1,1,3], 6 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3740Data))]
    public void Test_MinimumDistance(int[] nums, int expected) {
        // Arrange
        var solution = new Lc3740Solution();

        // Act
        var result = solution.MinimumDistance(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}