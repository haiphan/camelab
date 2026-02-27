using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3666Tests {
    public static TheoryData<string, int, int> Lc3666Data => new()
    {
        // s, k, expectedResult
        { "110", 1, 1 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3666Data))]
    public void Test_MinOperations(string s, int k, int expected) {
        // Arrange
        var solution = new Lc3666Solution();

        // Act
        var result = solution.MinOperations(s, k);

        // Assert
        Assert.Equal(expected, result);
    }
}