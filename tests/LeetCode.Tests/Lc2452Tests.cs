using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2452Tests {
    public static TheoryData<string[], string[], IList<string>> Lc2452Data => new()
    {
        // queries, dictionary, expectedResult
        { ["word","note","ants","wood"], ["wood","joke","moat"], ["word","note", "wood"] },
    };
    
    [Theory]
    [MemberData(nameof(Lc2452Data))]
    public void Test_TwoEditWords(string[] queries, string[] dictionary, IList<string> expected) {
        // Arrange
        var solution = new Lc2452Solution();

        // Act
        var result = solution.TwoEditWords(queries, dictionary);

        // Assert
        Assert.Equal(expected, result);
    }
}