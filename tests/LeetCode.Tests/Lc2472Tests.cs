using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2472Tests {
    public static TheoryData<string, int, int> Lc2472Data => new()
    {
        { "abaccdbbd", 2, 3 },
    };
    
    [Theory]
    [MemberData(nameof(Lc2472Data))]
    public void Test_MaxPalindromes(string s, int k, int expected) {
        // Arrange
        var solution = new Lc2472Solution();

        // Act
        var result = solution.MaxPalindromes(s, k);

        // Assert
        Assert.Equal(expected, result);
    }
}