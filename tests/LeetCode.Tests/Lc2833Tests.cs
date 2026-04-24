using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2833Tests {
    public static TheoryData<string, int> Lc2833Data => new()
    {
        // moves, expectedResult
        { "L_RL__R", 3 },
    };
    
    [Theory]
    [MemberData(nameof(Lc2833Data))]
    public void Test_FurthestDistanceFromOrigin(string moves, int expected) {
        // Arrange
        var solution = new Lc2833Solution();

        // Act
        var result = solution.FurthestDistanceFromOrigin(moves);

        // Assert
        Assert.Equal(expected, result);
    }
}