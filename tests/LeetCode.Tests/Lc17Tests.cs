using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc17Tests {
    public static TheoryData<string, IList<string>> Lc17Data => new()
    {
        // digits, expectedResult
        { "23", ["ad","ae","af","bd","be","bf","cd","ce","cf"] },
    };
    
    [Theory]
    [MemberData(nameof(Lc17Data))]
    public void Test_LetterCombinations(string digits, IList<string> expected) {
        // Arrange
        var solution = new Lc17Solution();

        // Act
        var result = solution.LetterCombinations(digits);

        // Assert
        Assert.Equal(expected, result);
    }
}