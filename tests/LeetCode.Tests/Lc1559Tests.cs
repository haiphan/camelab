using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1559Tests {
    public static TheoryData<char[][], bool> Lc1559Data => new()
    {
        // grid, expectedResult
        { [['a','a','a','a'],['a','b','b','a'],['a','b','b','a'],['a','a','a','a']], true },
        { [['a','b','b'],['b','z','b'],['b','b','a']], false },
    };
    
    [Theory]
    [MemberData(nameof(Lc1559Data))]
    public void Test_ContainsCycle(char[][] grid, bool expected) {
        // Arrange
        var solution = new Lc1559Solution();

        // Act
        var result = solution.ContainsCycle(grid);

        // Assert
        Assert.Equal(expected, result);
    }
}