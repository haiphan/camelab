using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc856Tests {
    public static TheoryData<string, int> Lc856Data => new()
    {
        { "()", 1 },
    };
    
    [Theory]
    [MemberData(nameof(Lc856Data))]
    public void Test_ScoreOfParentheses(string s, int expected) {
        // Arrange
        var solution = new Lc856Solution();

        // Act
        var result = solution.ScoreOfParentheses(s);

        // Assert
        Assert.Equal(expected, result);
    }
}