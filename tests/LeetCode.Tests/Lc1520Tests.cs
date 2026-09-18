using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1520Tests {
    public static TheoryData<string, IList<string>> Lc1520Data => new()
    {
        // s, expected
        { "adefaddaccc", ["e", "f", "ccc"] },
    };
    
    [Theory]
    [MemberData(nameof(Lc1520Data))]
    public void Test_MaxNumOfSubstrings(string s, IList<string> expected) {
        // Arrange
        var solution = new Lc1520Solution();

        // Act
        var result = solution.MaxNumOfSubstrings(s);

        // Assert
        Assert.Equal(expected, result);
    }
}