using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2840Tests {
    public static TheoryData<string, string, bool> Lc2840Data => new()
    {
        // s1, s2, expectedResult
        { "abcdba", "cabdab", true },
        { "aab", "xxy", false },
    };
    
    [Theory]
    [MemberData(nameof(Lc2840Data))]
    public void Test_CheckStrings(string s1, string s2, bool expected) {
        // Arrange
        var solution = new Lc2840Solution();

        // Act
        var result = solution.CheckStrings(s1, s2);

        // Assert
        Assert.Equal(expected, result);
    }
}