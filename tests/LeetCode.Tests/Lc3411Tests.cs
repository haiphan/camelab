using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3411Tests {
    public static TheoryData<int[], int> Lc3411Data => new()
    {
        // nums, expected
        {[1,2,1,2,1,1,1], 5}
    };
    
    [Theory]
    [MemberData(nameof(Lc3411Data))]
    public void Test_MaxLength(int[] nums, int expected) {
        // Arrange
        var solution = new Lc3411Solution();

        // Act
        var result = solution.MaxLength(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}