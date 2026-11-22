using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2124Tests {
    public static TheoryData<string, bool> Lc2124Data => new()
    {
        // s, expectedResult
        { "aaabbb", true },
        { "abab", false },
        { "bbb", true },
    };
    
    [Theory]
    [MemberData(nameof(Lc2124Data))]
    public void Test_CheckString(string s, bool expected) {
        // Arrange
        var solution = new Lc2124Solution();

        // Act
        var result = solution.CheckString(s);

        // Assert
        Assert.Equal(expected, result);
    }
}