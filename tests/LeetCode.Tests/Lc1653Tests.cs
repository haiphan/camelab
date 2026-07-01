using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1653Tests {
    public static TheoryData<string, int> Lc1653Data => new()
    {
        // s, expectedResult
        { "ababa", 2 },
    };
    
    [Theory]
    [MemberData(nameof(Lc1653Data))]
    public void Test_MinimumDeletions(string s, int expected) {
        // Arrange
        var solution = new Lc1653Solution();

        // Act
        var result = solution.MinimumDeletions(s);

        // Assert
        Assert.Equal(expected, result);
    }
}