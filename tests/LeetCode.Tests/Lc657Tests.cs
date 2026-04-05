using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc657Tests {
    public static TheoryData<string, bool> Lc657Data => new()
    {
        { "UD", true },
        { "LL", false },
    };
    
    [Theory]
    [MemberData(nameof(Lc657Data))]
    public void Test_JudgeCircle(string moves, bool expected) {
        // Arrange
        var solution = new Lc657Solution();

        // Act
        var result = solution.JudgeCircle(moves);

        // Assert
        Assert.Equal(expected, result);
    }
}