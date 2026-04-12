using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1320Tests {
    public static TheoryData<string, int> Lc1320Data => new()
    {
        { "CAKE", 3 },
        { "BIQPM", 6 },
    };
    
    [Theory]
    [MemberData(nameof(Lc1320Data))]
    public void Test_MinimumDistance(string word, int expected) {
        // Arrange
        var solution = new Lc1320Solution();

        // Act
        var result = solution.MinimumDistance(word);

        // Assert
        Assert.Equal(expected, result);
    }
}