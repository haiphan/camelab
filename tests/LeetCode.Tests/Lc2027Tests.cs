using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2027Tests {
    public static TheoryData<string, int> Lc2027Data => new()
    {
        // s, expectedResult
        { "XXOX", 2 },
        { "OOOO", 0 },
        { "XXXX", 2 },
    };
    
    [Theory]
    [MemberData(nameof(Lc2027Data))]
    public void Test_MinimumMoves(string s, int expected) {
        // Arrange
        var solution = new Lc2027Solution();

        // Act
        var result = solution.MinimumMoves(s);

        // Assert
        Assert.Equal(expected, result);
    }
}