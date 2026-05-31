using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2126Tests {
    public static TheoryData<int, int[], bool> Lc2126Data => new()
    {
        // mass, asteroids, expectedResult
        { 10, [3, 9, 19, 5, 21], true },
        { 5, [4, 9, 23, 4], false },
    };
    
    [Theory]
    [MemberData(nameof(Lc2126Data))]
    public void Test_AsteroidsDestroyed(int mass, int[] asteroids, bool expected) {
        // Arrange
        var solution = new Lc2126Solution();

        // Act
        var result = solution.AsteroidsDestroyed(mass, asteroids);

        // Assert
        Assert.Equal(expected, result);
    }
}