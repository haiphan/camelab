using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc678Tests {
    public static TheoryData<string, bool> Lc678Data => new()
    {
        // s, expectedResult
        { "()", true },
        { "(*)", true },
        { "(*))", true },
        { "((*)", true },
    };
    
    [Theory]
    [MemberData(nameof(Lc678Data))]
    public void Test_CheckValidString(string s, bool expected) {
        // Arrange
        var solution = new Lc678Solution();

        // Act
        var result = solution.CheckValidString(s);

        // Assert
        Assert.Equal(expected, result);
    }
}