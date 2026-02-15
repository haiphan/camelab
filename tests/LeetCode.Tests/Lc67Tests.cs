using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc67Tests {
    public static TheoryData<string, string, string> Lc67Data => new()
    {
        // a, b, expectedResult
        { "11", "1", "100" },
        { "1010", "1011", "10101" },
    };
    
    [Theory]
    [MemberData(nameof(Lc67Data))]
    public void Test_AddBinary(string a, string b, string expected) {
        // Arrange
        var solution = new Lc67Solution();

        // Act
        var result = solution.AddBinary(a, b);

        // Assert
        Assert.Equal(expected, result);
    }
}