using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3116Tests {
    public static TheoryData<int[], int, long> Lc3116Data => new()
    {
        // coins, k, expected
        { [3,6,9], 3, 9 },
        { [5, 2], 7, 12 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3116Data))]
    public void Test_FindKthSmallest(int[] coins, int k, long expected) {
        // Arrange
        var solution = new Lc3116Solution();

        // Act
        var result = solution.FindKthSmallest(coins, k);

        // Assert
        Assert.Equal(expected, result);
    }
}