using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3734Tests {
    public static TheoryData<string, string, string> Lc3734Data => new()
    {
        { "baba", "abba", "baab" },
        { "aac", "abb", "aca" },
    };
    
    [Theory]
    [MemberData(nameof(Lc3734Data))]
    public void Test_LexPalindromicPermutation(string s, string target, string expected) {
        // Arrange
        var solution = new Lc3734Solution();

        // Act
        var result = solution.LexPalindromicPermutation(s, target);

        // Assert
        Assert.Equal(expected, result);
    }
}