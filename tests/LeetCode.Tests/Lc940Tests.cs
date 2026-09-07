using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc940Tests {
    public static TheoryData<string, int> Lc940Data => new()
    {
        { "abc", 7 },
    };
    
    [Theory]
    [MemberData(nameof(Lc940Data))]
    public void Test_DistinctSubseqII(string s, int expected) {
        // Arrange
        var solution = new Lc940Solution();

        // Act
        var result = solution.DistinctSubseqII(s);

        // Assert
        Assert.Equal(expected, result);
    }
}