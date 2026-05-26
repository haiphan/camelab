using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3120Tests {
    public static TheoryData<string, int> Lc3120Data => new()
    {
        // word, expectedResult
        { "aaAbcBC", 3 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3120Data))]
    public void Test_NumberOfSpecialChars(string word, int expected) {
        // Arrange
        var solution = new Lc3120Solution();

        // Act
        var result = solution.NumberOfSpecialChars(word);

        // Assert
        Assert.Equal(expected, result);
    }
}