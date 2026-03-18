using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3070Tests {
    public static TheoryData<int[][], int, int> Lc3070Data => new()
    {
        // grid, k, expectedResult
        { [[7,6,3],[6,6,1]], 18, 4 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3070Data))]
    public void Test_CountSubmatrices(int[][] grid, int k, int expected) {
        // Arrange
        var solution = new Lc3070Solution();

        // Act
        var result = solution.CountSubmatrices(grid, k);

        // Assert
        Assert.Equal(expected, result);
    }
}