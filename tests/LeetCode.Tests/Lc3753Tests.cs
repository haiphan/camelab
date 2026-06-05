using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3753Tests {
    public static TheoryData<long, long, long> Lc3753Data => new()
    {
        // num1, num2, expectedResult
        { 0L, 0L, 0L },
        { 1L, 9L, 0L },
        { 100L, 109L, 9L },
        { 121L, 121L, 1L },
        { 4848, 4848, 2 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3753Data))]
    public void Test_TotalWaviness(long num1, long num2, long expected) {
        // Arrange
        var solution = new Lc3753Solution();

        // Act
        var result = solution.TotalWaviness(num1, num2);

        // Assert
        Assert.Equal(expected, result);
    }
}