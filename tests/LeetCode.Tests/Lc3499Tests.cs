using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3499Tests {
    public static TheoryData<string, int> Lc3499Data => new()
    {
        { "01", 1 },
        { "0100", 4 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3499Data))]
    public void Test_MaxActiveSectionsAfterTrade(string s, int expected) {
        // Arrange
        var solution = new Lc3499Solution();

        // Act
        var result = solution.MaxActiveSectionsAfterTrade(s);

        // Assert
        Assert.Equal(expected, result);
    }
}