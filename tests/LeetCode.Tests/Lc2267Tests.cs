using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2267Tests {
    public static TheoryData<char[][], bool> Lc2267Data => new()
    {
        // grid, expected
        {[['(','(','('],[')','(',')'],['(','(',')'],['(','(',')']], true}
    };
    
    [Theory]
    [MemberData(nameof(Lc2267Data))]
    public void Test_HasValidPath(char[][] grid, bool expected) {
        // Arrange
        var solution = new Lc2267Solution();

        // Act
        var result = solution.HasValidPath(grid);

        // Assert
        Assert.Equal(expected, result);
    }
}