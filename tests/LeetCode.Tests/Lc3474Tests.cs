using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3474Tests {
    public static TheoryData<string, string, string> Lc3474Data => new()
    {
        // sstr1, sstr2, expectedResult
        { "TFTF", "ab", "ababa" },
    };
    
    [Theory]
    [MemberData(nameof(Lc3474Data))]
    public void Test_GenerateString(string str1, string str2, string expected) {
        // Arrange
        var solution = new Lc3474Solution();

        // Act
        var result = solution.GenerateString(str1, str2);

        // Assert
        Assert.Equal(expected, result);
    }
}