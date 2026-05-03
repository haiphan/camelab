using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc796Tests {
    public static TheoryData<string, string, bool> Lc796Data => new()
    {
        { "abcde", "cdeab", true },
        { "abcde", "abced", false },
    };
    
    [Theory]
    [MemberData(nameof(Lc796Data))]
    public void Test_RotateString(string s, string goal, bool expected) {
        // Arrange
        var solution = new Lc796Solution();

        // Act
        var result = solution.RotateString(s, goal);

        // Assert
        Assert.Equal(expected, result);
    }
}