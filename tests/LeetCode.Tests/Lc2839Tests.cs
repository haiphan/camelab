using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2839Tests {
    public static TheoryData<string, string, bool> Lc2839Data => new()
    {
        // s1, s2, expectedResult
        { "abcd", "cdab", true },
        { "abcd", "dacb", false },
    };
    
    [Theory]
    [MemberData(nameof(Lc2839Data))]
    public void Test_CanBeEqual(string s1, string s2, bool expected) {
        // Arrange
        var solution = new Lc2839Solution();

        // Act
        var result = solution.CanBeEqual(s1, s2);

        // Assert
        Assert.Equal(expected, result);
    }
}