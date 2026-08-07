using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3348Tests {
    public static TheoryData<string, long, string> Lc3348Data => new()
    {
        { "1234", 256L, "1488" },
        { "1234", 11L, "-1" },
        { "109", 2L, "112" },
        { "99", 2L, "112" },
        { "1203", 1L, "1211" },
    };
    
    [Theory]
    [MemberData(nameof(Lc3348Data))]
    public void Test_SmallestNumber(string num, long t, string expected) {
        // Arrange
        var solution = new Lc3348Solution();

        // Act
        var result = solution.SmallestNumber(num, t);

        // Assert
        Assert.Equal(expected, result);
    }
}