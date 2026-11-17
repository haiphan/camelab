using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2911Tests {
    public static TheoryData<string, int, int> Lc2911Data => new()
    {
        { "abcac", 2, 1 },
    };
    
    [Theory]
    [MemberData(nameof(Lc2911Data))]
    public void Test_MinimumChanges(string s, int k, int expected) {
        // Arrange
        var solution = new Lc2911Solution();

        // Act
        var result = solution.MinimumChanges(s, k);

        // Assert
        Assert.Equal(expected, result);
    }
}