using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1081Tests {
    public static TheoryData<string, string> Lc1081Data => new()
    {
        { "bcabc", "abc" },
    };
    
    [Theory]
    [MemberData(nameof(Lc1081Data))]
    public void Test_SmallestSubsequence(string s, string expected) {
        // Arrange
        var solution = new Lc1081Solution();

        // Act
        var result = solution.SmallestSubsequence(s);

        // Assert
        Assert.Equal(expected, result);
    }
}