using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc921Tests {
    public static TheoryData<string, int> Lc921Data => new()
    {
        { "())", 1 },
    };
    
    [Theory]
    [MemberData(nameof(Lc921Data))]
    public void Test_MinAddToMakeValid(string s, int expected) {
        // Arrange
        var solution = new Lc921Solution();

        // Act
        var result = solution.MinAddToMakeValid(s);

        // Assert
        Assert.Equal(expected, result);
    }
}