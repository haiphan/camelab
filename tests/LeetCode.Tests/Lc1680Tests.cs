using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1680Tests {
    public static TheoryData<int, int> Lc1680Data => new()
    {
        // n, expectedResult
        { 1, 1 },
    };
    
    [Theory]
    [MemberData(nameof(Lc1680Data))]
    public void Test_ConcatenatedBinary(int n, int expected) {
        // Arrange
        var solution = new Lc1680Solution();

        // Act
        var result = solution.ConcatenatedBinary(n);

        // Assert
        Assert.Equal(expected, result);
    }
}