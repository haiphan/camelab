using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1021Tests {
    public static TheoryData<string, string> Lc1021Data => new()
    {
        { "(()())(())", "()()()" },
    };
    
    [Theory]
    [MemberData(nameof(Lc1021Data))]
    public void Test_RemoveOuterParentheses(string s, string expected) {
        // Arrange
        var solution = new Lc1021Solution();

        // Act
        var result = solution.RemoveOuterParentheses(s);

        // Assert
        Assert.Equal(expected, result);
    }
}