using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc20Tests {
    public static TheoryData<string, bool> Lc20Data => new()
    {
        { "()", true },
    };
    
    [Theory]
    [MemberData(nameof(Lc20Data))]
    public void Test_IsValid(string s, bool expected) {
        // Arrange
        var solution = new Lc20Solution();

        // Act
        var result = solution.IsValid(s);

        // Assert
        Assert.Equal(expected, result);
    }
}