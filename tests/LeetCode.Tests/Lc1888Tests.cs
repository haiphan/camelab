using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1888Tests {
    public static TheoryData<string, int> Lc1888Data => new()
    {
        // s, expectedResult
        { "111000", 2 },
    };
    
    [Theory]
    [MemberData(nameof(Lc1888Data))]
    public void Test_minFlips(string s, int expected) {
        // Arrange
        var solution = new Lc1888Solution();

        // Act
        var result = solution.MinFlips(s);

        // Assert
        Assert.Equal(expected, result);
    }
}