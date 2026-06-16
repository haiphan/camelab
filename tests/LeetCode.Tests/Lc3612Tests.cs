using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3612Tests {
    public static TheoryData<string, string> Lc3612Data => new()
    {
        { "a#b%*", "ba" },
    };
    
    [Theory]
    [MemberData(nameof(Lc3612Data))]
    public void Test_ProcessStr(string s, string expected) {
        // Arrange
        var solution = new Lc3612Solution();

        // Act
        var result = solution.ProcessStr(s);

        // Assert
        Assert.Equal(expected, result);
    }
}