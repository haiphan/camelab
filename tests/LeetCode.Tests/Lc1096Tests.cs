using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1096Tests {
    public static TheoryData<string, IList<string>> Lc1096Data => new()
    {
        // expression, expected
        {"{a,b}{c,{d,e}}", ["ac","ad","ae","bc","bd","be"]}
    };
    
    [Theory]
    [MemberData(nameof(Lc1096Data))]
    public void Test_BraceExpansionII(string expression, IList<string> expected) {
        // Arrange
        var solution = new Lc1096Solution();

        // Act
        var result = solution.BraceExpansionII(expression);

        // Assert
        Assert.Equal(expected, result);
    }
}