using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1541Tests {
    public static TheoryData<string, int> Lc1541Data => new()
    {
        { "(()))", 1 },
    };
    
    [Theory]
    [MemberData(nameof(Lc1541Data))]
    public void Test_MinInsertions(string s, int expected) {
        // Arrange
        var solution = new Lc1541Solution();

        // Act
        var result = solution.MinInsertions(s);

        // Assert
        Assert.Equal(expected, result);
    }
}