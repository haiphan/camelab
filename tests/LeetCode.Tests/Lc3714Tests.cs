using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3714Tests {
    public static TheoryData<string, int> Lc3714Data => new()
    {
        // s, expectedResult
        { "abbac", 4 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3714Data))]
    public void Test_LongestBalanced(string s, int expected) {
        // Arrange
        var solution = new Lc3714Solution();

        // Act
        var result = solution.LongestBalanced(s);

        // Assert
        Assert.Equal(expected, result);
    }
}