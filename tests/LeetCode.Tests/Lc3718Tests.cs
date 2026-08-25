using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3718Tests {
    public static TheoryData<int[], int, int> Lc3718Data => new()
    {
        // nums, k, expected
        { [1, 2, 3, 4, 5], 2, 6 },
        { [1,4,7,10,15], 5, 5 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3718Data))]
    public void Test_MissingMultiple(int[] nums, int k, int expected) {
        // Arrange
        var solution = new Lc3718Solution();

        // Act
        var result = solution.MissingMultiple(nums, k);

        // Assert
        Assert.Equal(expected, result);
    }
}