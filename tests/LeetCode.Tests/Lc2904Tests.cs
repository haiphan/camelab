using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2904Tests {
    public static TheoryData<string, int, string> Lc2904Data => new()
    {
        // s, k, expected
        { "100011001", 3, "11001" },
        { "000", 1, "" },
        { "001110101101101111", 10, "10101101101111" },
    };
    
    [Theory]
    [MemberData(nameof(Lc2904Data))]
    public void Test_ShortestBeautifulSubstring(string s, int k, string expected) {
        // Arrange
        var solution = new Lc2904Solution();

        // Act
        var result = solution.ShortestBeautifulSubstring(s, k);

        // Assert
        Assert.Equal(expected, result);
    }
}