using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3614Tests {
    public static TheoryData<string, long, char> Lc3614Data => new()
    {
        { "a#b%*", 1L, 'a' },
        { "#jief%k", 0L, 'f' },
    };
    
    [Theory]
    [MemberData(nameof(Lc3614Data))]
    public void Test_ProcessStr(string s, long k, char expected) {
        // Arrange
        var solution = new Lc3614Solution();

        // Act
        var result = solution.ProcessStr(s, k);

        // Assert
        Assert.Equal(expected, result);
    }
}