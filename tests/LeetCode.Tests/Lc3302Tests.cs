using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3302Tests {
    public static TheoryData<string, string, int[]> Lc3302Data => new()
    {
        // word1, word2, expected
        { "vbcca", "abc", [0, 1, 2] },
        { "aaaaaa", "aaabc", [] },
        { "abdc", "abc", [0, 1, 2] },
        { "abc", "abcd", [] },
    };
    
    [Theory]
    [MemberData(nameof(Lc3302Data))]
    public void Test_ValidSequence(string word1, string word2, int[] expected) {
        // Arrange
        var solution = new Lc3302Solution();

        // Act
        var result = solution.ValidSequence(word1, word2);

        // Assert
        Assert.Equal(expected, result);
    }
}