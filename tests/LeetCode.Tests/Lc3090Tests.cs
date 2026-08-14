using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3090Tests {
    public static TheoryData<string, int> Lc3090Data => new()
    {
        { "bcbbbcba", 4 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3090Data))]
    public void Test_MaximumLengthSubstring(string s, int expected) {
        // Arrange
        var solution = new Lc3090Solution();

        // Act
        var result = solution.MaximumLengthSubstring(s);

        // Assert
        Assert.Equal(expected, result);
    }
}