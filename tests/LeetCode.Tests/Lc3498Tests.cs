using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3498Tests {
    public static TheoryData<string, int> Lc3498Data => new()
    {
        { "abc", 148 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3498Data))]
    public void Test_ReverseDegree(string s, int expected) {
        // Arrange
        var solution = new Lc3498Solution();

        // Act
        var result = solution.ReverseDegree(s);

        // Assert
        Assert.Equal(expected, result);
    }
}