using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3360Tests {
    public static TheoryData<int, bool> Lc3360Data => new()
    {
        { 12, true },
        { 1, false },
        { 10, true },
        { 50, true },
    };

    public static TheoryData<int, bool> Lc3360BigNData => new()
    {
        { 54, true },
        { 55, false },
        { 56, false },
        { 1_000_000, false },
        { 2_000_000_000, false },
    };

    [Theory]
    [MemberData(nameof(Lc3360Data))]
    public void Test_CanAliceWin(int n, bool expected) {
        // Arrange
        var solution = new Lc3360Solution();

        // Act
        var result = solution.CanAliceWin(n);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(Lc3360Data))]
    public void Test_CanAliceWinIter(int n, bool expected) {
        // Arrange
        var solution = new Lc3360Solution();

        // Act
        var result = solution.CanAliceWinIter(n);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(Lc3360BigNData))]
    public void Test_CanAliceWin_BigN(int n, bool expected) {
        // Arrange
        var solution = new Lc3360Solution();

        // Act
        var result = solution.CanAliceWin(n);

        // Assert
        Assert.Equal(expected, result);
    }
}