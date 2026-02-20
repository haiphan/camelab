using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc761Tests {
    public static TheoryData<string, string> Lc761Data => new()
    {
        // s, expectedResult
        { "11011000", "11100100" },
    };
    
    [Theory]
    [MemberData(nameof(Lc761Data))]
    public void Test_MakeLargestSpecial(string s, string expected) {
        // Arrange
        var solution = new Lc761Solution();

        // Act
        var result = solution.MakeLargestSpecial(s);

        // Assert
        Assert.Equal(expected, result);
    }
}