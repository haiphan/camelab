using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1758Tests {
    public static TheoryData<string, int> Lc1758Data => new()
    {
        // s, expectedResult
        { "0100", 1 },
    };
    
    [Theory]
    [MemberData(nameof(Lc1758Data))]
    public void Test_MinOperations(string s, int expected) {
        // Arrange
        var solution = new Lc1758Solution();

        // Act
        var result = solution.MinOperations(s);

        // Assert
        Assert.Equal(expected, result);
    }
}