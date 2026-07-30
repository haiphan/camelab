using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3014Tests {
    public static TheoryData<string, int> Lc3014Data => new()
    {
        { "xycdefghij", 12 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3014Data))]
    public void Test_MinimumPushes(string word, int expected) {
        // Arrange
        var solution = new Lc3014Solution();

        // Act
        var result = solution.MinimumPushes(word);

        // Assert
        Assert.Equal(expected, result);
    }
}