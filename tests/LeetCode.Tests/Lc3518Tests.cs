using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3518Tests {
    public static TheoryData<string, int, string> Lc3518Data => new()
    {
        { "bacab", 1, "abcba" },
        { "abba", 2, "baab" },
        { "bacab", 3, "" },
        { "aabb", 1, "abba" },
        { "aabb", 2, "baab" },
        { "aabb", 3, "" },
        { "aaa", 1, "aaa" },
        { "aaa", 2, "" },
        { "aabccbaa", 12, "cbaaaabc" },
        { "aabccbaa", 13, "" },
        { new string('a', 10_000), 1, new string('a', 10_000) },
    };
    
    [Theory]
    [MemberData(nameof(Lc3518Data))]
    public void Test_SmallestPalindrome(string s, int k, string expected) {
        // Arrange
        var solution = new Lc3518Solution();

        // Act
        var result = solution.SmallestPalindrome(s, k);

        // Assert
        Assert.Equal(expected, result);
    }
}