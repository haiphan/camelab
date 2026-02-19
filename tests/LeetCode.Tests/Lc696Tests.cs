using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc696Tests {
    public static TheoryData<string, int> Lc696Data => new()
    {
        // s, expectedResult
        { "00110011", 6 },
        { "10101", 4 },
    };
    
    [Theory]
    [MemberData(nameof(Lc696Data))]
    public void Test_CountBinarySubstrings(string s, int expected) {
        // Arrange
        var solution = new Lc696Solution();

        // Act
        var result = solution.CountBinarySubstrings(s);

        // Assert
        Assert.Equal(expected, result);
    }
}