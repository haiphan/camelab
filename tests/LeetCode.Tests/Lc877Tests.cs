using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc877Tests {
    public static TheoryData<int[], bool> Lc877Data => new()
    {
        // piles, expected
        {[5,3,4,5], true}
    };
    
    [Theory]
    [MemberData(nameof(Lc877Data))]
    public void Test_StoneGame(int[] piles, bool expected) {
        // Arrange
        var solution = new Lc877Solution();

        // Act
        var result = solution.StoneGame(piles);

        // Assert
        Assert.Equal(expected, result);
    }
}