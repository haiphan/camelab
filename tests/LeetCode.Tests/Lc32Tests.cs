using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc32Tests {
    public static TheoryData<string, int> Lc32Data => new()
    {
        { "(())", 4 },
    };
    
    [Theory]
    [MemberData(nameof(Lc32Data))]
    public void Test_LongestValidParentheses(string s, int expected) {
        // Arrange
        var solution = new Lc32Solution();

        // Act
        var result = solution.LongestValidParentheses(s);

        // Assert
        Assert.Equal(expected, result);
    }
}