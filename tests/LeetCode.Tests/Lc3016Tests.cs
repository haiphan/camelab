using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3016Tests {
    public static TheoryData<string, int> Lc3016Data => new()
    {
        { "aabbccddeeffgghhiiiiii", 24 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3016Data))]
    public void Test_MinimumPushes(string word, int expected) {
        // Arrange
        var solution = new Lc3016Solution();

        // Act
        var result = solution.MinimumPushes(word);

        // Assert
        Assert.Equal(expected, result);
    }
}