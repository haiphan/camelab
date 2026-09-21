using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3524Tests {
    public static TheoryData<int[], int, long[]> Lc3524Data => new()
    {
        // nums, k, expected
        {[1,2,3,4,5], 3, [9, 2, 4]}
    };
    
    [Theory]
    [MemberData(nameof(Lc3524Data))]
    public void Test_ResultArray(int[] nums, int k, long[] expected) {
        // Arrange
        var solution = new Lc3524Solution();

        // Act
        var result = solution.ResultArray(nums, k);

        // Assert
        Assert.Equal(expected, result);
    }
}