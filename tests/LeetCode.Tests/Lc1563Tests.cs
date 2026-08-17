using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1563Tests {
    public static TheoryData<int[], int> Lc1563Data => new()
    {
        // stoneValue, expected
        { [6, 2, 3, 4, 5, 5], 18 },
        { [7, 7, 7, 7, 7, 7, 7], 28 },
        { [98,77,24,49,6,12,2,44,51,96], 330 },
        { [16, 1, 2, 4, 6], 20 }
    };
    
    [Theory]
    [MemberData(nameof(Lc1563Data))]
    public void Test_StoneGameV(int[] stoneValue, int expected) {
        // Arrange
        var solution = new Lc1563Solution();

        // Act
        var result = solution.StoneGameV(stoneValue);

        // Assert
        Assert.Equal(expected, result);
    }
}