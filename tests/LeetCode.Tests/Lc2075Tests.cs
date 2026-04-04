using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2075Tests {
    public static TheoryData<string, int, string> Lc2075Data => new()
    {
        // encodedText, rows, expectedResult
        { "ch   ie   pr", 3, "cipher" },
    };
    
    [Theory]
    [MemberData(nameof(Lc2075Data))]
    public void Test_DecodeCiphertext(string encodedText, int rows, string expected) {
        // Arrange
        var solution = new Lc2075Solution();

        // Act
        var result = solution.DecodeCiphertext(encodedText, rows);

        // Assert
        Assert.Equal(expected, result);
    }
}