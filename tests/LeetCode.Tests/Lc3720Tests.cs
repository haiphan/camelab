using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3720Tests {
    public static TheoryData<string, string, string> Lc3720Data => new()
    {
        { "abc", "bba", "bca" },
    };
    
    [Theory]
    [MemberData(nameof(Lc3720Data))]
    public void Test_LexGreaterPermutation(string s, string target, string expected) {
        // Arrange
        var solution = new Lc3720Solution();

        // Act
        var result = solution.LexGreaterPermutation(s, target);

        // Assert
        Assert.Equal(expected, result);
    }
}