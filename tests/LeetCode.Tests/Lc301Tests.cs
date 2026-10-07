using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc301Tests {
    public static TheoryData<string, IList<string>> Lc301Data => new()
    {
        // s, expected
        { "()())()", ["(())()","()()()"] }
    };
    
    [Theory]
    [MemberData(nameof(Lc301Data))]
    public void Test_RemoveInvalidParentheses(string s, IList<string> expected) {
        // Arrange
        var solution = new Lc301Solution();

        // Act
        var result = solution.RemoveInvalidParentheses(s);
        // sort result and expected before asserting
        result = result.OrderBy(x => x).ToList();
        expected = expected.OrderBy(x => x).ToList();

        // Assert
        Assert.Equal(expected, result);
    }
}