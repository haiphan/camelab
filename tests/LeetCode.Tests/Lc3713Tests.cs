using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3713Tests {
    public static TheoryData<string, int> Lc3713Data => new()
    {
        // s, expectedResult
        { "abbac", 4 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3713Data))]
    public void Test_LongestBalanced(string s, int expected) {
        // Arrange
        var solution = new Lc3713Solution();

        // Act
        var result = solution.LongestBalanced(s);

        // Assert
        Assert.Equal(expected, result);
    }
}