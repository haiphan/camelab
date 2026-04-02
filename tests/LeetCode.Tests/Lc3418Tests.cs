using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3418Tests {
    public static TheoryData<int[][], int> Lc3418Data => new()
    {
        // coins, expectedResult
        { [[0,1,-1],[1,-2,3],[2,-3,4]], 8 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3418Data))]
    public void Test_MaximumAmount(int[][] coins, int expected) {
        // Arrange
        var solution = new Lc3418Solution();

        // Act
        var result = solution.MaximumAmount(coins);

        // Assert
        Assert.Equal(expected, result);
    }
}