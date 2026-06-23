using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3699Tests {
    public static TheoryData<int, int, int, int> Lc3699Data => new()
    {
        // n, l, r, expected
        { 3, 4, 5, 2 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3699Data))]
    public void Test_ZigZagArrays(int n, int l, int r, int expected) {
        // Arrange
        var solution = new Lc3699Solution();

        // Act
        var result = solution.ZigZagArrays(n, l, r);

        // Assert
        Assert.Equal(expected, result);
    }
}