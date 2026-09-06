using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc115Tests {
    public static TheoryData<string, string, int> Lc115Data => new()
    {
        { "rabbbit", "rabbit", 3 },
    };
    
    [Theory]
    [MemberData(nameof(Lc115Data))]
    public void Test_NumDistinct(string s, string t, int expected) {
        // Arrange
        var solution = new Lc115Solution();

        // Act
        var result = solution.NumDistinct(s, t);

        // Assert
        Assert.Equal(expected, result);
    }
}