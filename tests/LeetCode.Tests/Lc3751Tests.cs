using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3751Tests {
    public static TheoryData<int, int, int> Lc3751Data => new()
    {
        // num1, num2, expectedResult
        { 1, 9, 0 },
        { 10, 99, 0 },
        { 100, 109, 9 },
        { 121, 121, 1 },
        { 123, 123, 0 },
        { 120, 130, 3 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3751Data))]
    public void Test_TotalWaviness(int num1, int num2, int expected) {
        // Arrange
        var solution = new Lc3751Solution();

        // Act
        var result = solution.TotalWaviness(num1, num2);

        // Assert
        Assert.Equal(expected, result);
    }
}