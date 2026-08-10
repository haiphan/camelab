using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1510Tests {
    public static TheoryData<int, bool> Lc1510Data => new()
    {
        { 1, true },
        { 2, false },
    };
    
    [Theory]
    [MemberData(nameof(Lc1510Data))]
    public void Test_WinnerSquareGame(int n, bool expected) {
        // Arrange
        var solution = new Lc1510Solution();

        // Act
        var result = solution.WinnerSquareGame(n);

        // Assert
        Assert.Equal(expected, result);
    }
}