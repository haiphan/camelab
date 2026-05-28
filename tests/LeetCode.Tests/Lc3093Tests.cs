using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3093Tests {
    public static TheoryData<string[], string[], int[]> Lc3093Data => new()
    {
        // wordsContainer, wordsQuery, expectedResult
        { ["abcd","bcd","xbcd"], ["cd","bcd","xyz"], [1, 1, 1] },
    };
    
    [Theory]
    [MemberData(nameof(Lc3093Data))]
    public void Test_StringIndices(string[] wordsContainer, string[] wordsQuery, int[] expected) {
        // Arrange
        var solution = new Lc3093Solution();

        // Act
        var result = solution.StringIndices(wordsContainer, wordsQuery);

        // Assert
        Assert.Equal(expected, result);
    }
}