using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc7Tests {
    public static TheoryData<int, int> Lc7Data => new()
    {
        // x, expectedResult
        { 123, 321 },
        { -123, -321 },
        { 120, 21 },
    };
    
    [Theory]
    [MemberData(nameof(Lc7Data))]
    public void Test_Reverse(int x, int expected) {
        // Arrange
        var solution = new Lc7Solution();

        // Act
        var result = solution.Reverse(x);

        // Assert
        Assert.Equal(expected, result);
    }
}