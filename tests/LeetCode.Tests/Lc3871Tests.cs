using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3871Tests {
    public static TheoryData<long, long> Lc3871Data => new()
    {
        { 1002L, 3L },
    };
    
    [Theory]
    [MemberData(nameof(Lc3871Data))]
    public void Test_CountCommas(long n, long expected) {
        // Arrange
        var solution = new Lc3871Solution();

        // Act
        var result = solution.CountCommas(n);

        // Assert
        Assert.Equal(expected, result);
    }
}