using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3644Tests {
    public static TheoryData<int[], int> Lc3644Data => new()
    {
        // nums, expected
        { [0,3,2,1], 1 }
    };
    
    [Theory]
    [MemberData(nameof(Lc3644Data))]
    public void Test_SortPermutation(int[] nums, int expected) {
        // Arrange
        var solution = new Lc3644Solution();

        // Act
        var result = solution.SortPermutation(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}