using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1267Tests {
    public static TheoryData<int[][], int> Lc1267Data => new()
    {
        // grid, expected
        { [[1,0],[0,1]], 0 },
    };
    
    [Theory]
    [MemberData(nameof(Lc1267Data))]
    public void Test_CountServers(int[][] grid, int expected) {
        // Arrange
        var solution = new Lc1267Solution();

        // Act
        var result = solution.CountServers(grid);

        // Assert
        Assert.Equal(expected, result);
    }
}