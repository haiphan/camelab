using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1461Tests {
    public static TheoryData<string, int, bool> Lc1461Data => new()
    {
        // s, k, expectedResult
        { "00110110", 2, true },
        { "0110", 1, true },
        { "0110", 2, false },
    };
    
    [Theory]
    [MemberData(nameof(Lc1461Data))]
    public void Test_HasAllCodes(string s, int k, bool expected) {
        // Arrange
        var solution = new Lc1461Solution();

        // Act
        var result = solution.HasAllCodes(s, k);

        // Assert
        Assert.Equal(expected, result);
    }
}