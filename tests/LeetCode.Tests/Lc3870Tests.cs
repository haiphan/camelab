using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3870Tests {
    public static TheoryData<int, int> Lc3870Data => new()
    {
        { 1002, 3 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3870Data))]
    public void Test_CountCommas(int n, int expected) {
        // Arrange
        var solution = new Lc3870Solution();

        // Act
        var result = solution.CountCommas(n);

        // Assert
        Assert.Equal(expected, result);
    }
}