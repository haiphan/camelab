using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2029Tests {
    public static TheoryData<int[], bool> Lc2029Data => new()
    {
        // nums, expected
        { [2, 1], true },
        { [5, 1, 2, 4, 3], false },
        { [2], false },
    };
    
    [Theory]
    [MemberData(nameof(Lc2029Data))]
    public void Test_StoneGameIX(int[] stones, bool expected) {
        // Arrange
        var solution = new Lc2029Solution();

        // Act
        var result = solution.StoneGameIX(stones);

        // Assert
        Assert.Equal(expected, result);
    }
}