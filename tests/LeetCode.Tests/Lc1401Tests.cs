using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1401Tests {
    public static TheoryData<int, int, int, int, int, int, int, bool> Lc1401Data => new()
    {
        { 1, 0, 0, 1, -1, 3, 1, true },
    };
    
    [Theory]
    [MemberData(nameof(Lc1401Data))]
    public void Test_CheckOverlap(int radius, int xCenter, int yCenter, int x1, int y1, int x2, int y2, bool expected) {
        // Arrange
        var solution = new Lc1401Solution();

        // Act
        var result = solution.CheckOverlap(radius, xCenter, yCenter, x1, y1, x2, y2);

        // Assert
        Assert.Equal(expected, result);
    }
}