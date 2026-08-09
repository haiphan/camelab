using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1140Tests {
    public static TheoryData<int[], int> Lc1140Data => new()
    {
        // piles, expected
        { [2,7,9,4,4], 10 },
    };
    
    [Theory]
    [MemberData(nameof(Lc1140Data))]
    public void Test_StoneGameII(int[] piles, int expected) {
        // Arrange
        var solution = new Lc1140Solution();

        // Act
        var result = solution.StoneGameII(piles);

        // Assert
        Assert.Equal(expected, result);
    }
}