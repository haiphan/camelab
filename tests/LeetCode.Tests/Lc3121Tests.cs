using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3121Tests {
    public static TheoryData<string, int> Lc3121Data => new()
    {
        // word, expectedResult
        { "aaAbcBC", 3 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3121Data))]
    public void Test_NumberOfSpecialChars(string word, int expected) {
        // Arrange
        var solution = new Lc3121Solution();

        // Act
        var result = solution.NumberOfSpecialChars(word);

        // Assert
        Assert.Equal(expected, result);
    }
}