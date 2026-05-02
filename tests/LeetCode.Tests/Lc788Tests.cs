using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc788Tests {
    public static TheoryData<int, int> Lc788Data => new()
    {
        // num expectedResult
        { 10, 4 },
        { 100, 40 },
        { 0, 0 },
    };
    
    [Theory]
    [MemberData(nameof(Lc788Data))]
    public void Test_RotatedDigits(int n, int expected) {
        // Arrange
        var solution = new Lc788Solution();

        // Act
        var result = solution.RotatedDigits(n);

        // Assert
        Assert.Equal(expected, result);
    }
}