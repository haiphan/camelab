using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3517Tests {
    public static TheoryData<string, string> Lc3517Data => new()
    {
        { "babab", "abbba" },
    };
    
    [Theory]
    [MemberData(nameof(Lc3517Data))]
    public void Test_SmallestPalindrome(string s, string expected) {
        // Arrange
        var solution = new Lc3517Solution();

        // Act
        var result = solution.SmallestPalindrome(s);

        // Assert
        Assert.Equal(expected, result);
    }
}