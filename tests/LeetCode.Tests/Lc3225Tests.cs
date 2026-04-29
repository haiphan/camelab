using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3225Tests {
    public static TheoryData<int[][], long> Lc3225Data => new()
    {
        // grid, expectedResult
        { [[0,0,0,0,0],[0,0,3,0,0],[0,1,0,0,0],[5,0,0,3,0],[0,0,0,0,2]], 11 },
        { [[1,6,0,6],[8,0,10,0],[4,0,5,7],[0,7,12,12]], 46 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3225Data))]
    public void Test_MaximumScore(int[][] grid, long expected) {
        // Arrange
        var solution = new Lc3225Solution();

        // Act
        var result = solution.MaximumScore(grid);

        // Assert
        Assert.Equal(expected, result);
    }
}