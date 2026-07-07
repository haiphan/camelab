using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3754Tests {
    public static TheoryData<int, long> Lc3754Data => new()
    {
        { 0, 0L },
    };
    
    [Theory]
    [MemberData(nameof(Lc3754Data))]
    public void Test_SumAndMultiply(int n, long expected) {
        // Arrange
        var solution = new Lc3754Solution();

        // Act
        // var result = solution.SumAndMultiply(n);

        // Assert
        // Assert.Equal(expected, result);
    }
}