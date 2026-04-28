using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2033Tests {
    public static TheoryData<int[][], int, int> Lc2033Data => new()
    {
        // grid, x, expectedResult
        { [[1,2],[3,4]], 1, 4 },
    };
    
    [Theory]
    [MemberData(nameof(Lc2033Data))]
    public void Test_MinOperations(int[][] grid, int x, int expected) {
        // Arrange
        var solution = new Lc2033Solution();

        // Act
        var result = solution.MinOperations(grid, x);

        // Assert
        Assert.Equal(expected, result);
    }
}