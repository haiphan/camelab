using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3069Tests {
    public static TheoryData<int[], int[]> Lc3069Data => new()
    {
        // nums, expected
        { [2,1,3], [2,3,1] },
        { [5,4,3,8], [5,3,4,8] },
    };
    
    [Theory]
    [MemberData(nameof(Lc3069Data))]
    public void Test_ResultArray(int[] nums, int[] expected) {
        // Arrange
        var solution = new Lc3069Solution();

        // Act
        var result = solution.ResultArray(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}