using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1967Tests {
    public static TheoryData<string[], string, int> Lc1967Data => new()
    {
        // patterns, word, expected
        { ["a", "abc", "bc"], "abc", 3 },
        { ["a", "b", "c"], "aaaaabbbbb", 2 },
        { ["a", "a", "a"], "ab", 3 },
        { ["a", "b", "c"], "def", 0 }
    };
    
    [Theory]
    [MemberData(nameof(Lc1967Data))]
    public void Test_NumOfStrings(string[] patterns, string word, int expected) {
        // Arrange
        var solution = new Lc1967Solution();

        // Act
        var result = solution.NumOfStrings(patterns, word);

        // Assert
        Assert.Equal(expected, result);
    }
}