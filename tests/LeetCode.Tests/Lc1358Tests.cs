using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1358Tests {
    public static TheoryData<string, int> Lc1358Data => new()
    {
        // s, expected
        { "abcabc", 10 },
    };
    
    [Theory]
    [MemberData(nameof(Lc1358Data))]
    public void Test_NumberOfSubstrings(string s, int expected) {
        // Arrange
        var solution = new Lc1358Solution();

        // Act
        var result = solution.NumberOfSubstrings(s);

        // Assert
        Assert.Equal(expected, result);
    }
}