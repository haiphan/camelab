using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2515Tests {
    public static TheoryData<string[], string, int, int> Lc2515Data => new()
    {
        // words, target, startIndex, expectedResult
        { ["hello","i","am","leetcode","hello"], "hello", 1, 1 },
        { ["a","b","c","d"], "a", 0, 0 },
        { ["a","b","c","d"], "e", 0, -1 },
    };
    
    [Theory]
    [MemberData(nameof(Lc2515Data))]
    public void Test_ClosestTarget(string[] words, string target, int startIndex, int expected) {
        // Arrange
        var solution = new Lc2515Solution();

        // Act
        var result = solution.ClosestTarget(words, target, startIndex);

        // Assert
        Assert.Equal(expected, result);
    }
}