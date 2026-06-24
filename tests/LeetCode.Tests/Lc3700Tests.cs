using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3700Tests {
    public static TheoryData<int, int, int, int> Lc3700Data => new()
    {
        // n, l, r, expected
        { 3, 4, 5, 2 },
        { 89226042, 23, 49, 901491272 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3700Data))]
    public void Test_ZigZagArrays(int n, int l, int r, int expected) {
        // Arrange
        var solution = new Lc3700Solution();

        // Act
        var result = solution.ZigZagArrays(n, l, r);

        // Assert
        Assert.Equal(expected, result);
    }
}