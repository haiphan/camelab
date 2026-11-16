using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2243Tests {
    public static TheoryData<string, int, string> Lc2243Data => new()
    {
        { "11111222223", 3, "135" },
    };
    
    [Theory]
    [MemberData(nameof(Lc2243Data))]
    public void Test_DigitSum(string s, int k, string expected) {
        // Arrange
        var solution = new Lc2243Solution();

        // Act
        var result = solution.DigitSum(s, k);

        // Assert
        Assert.Equal(expected, result);
    }
}