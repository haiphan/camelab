using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3212Tests {
    public static TheoryData<char[][], int> Lc3212Data => new()
    {
        // grid, expectedResult
        { [['X', 'Y', '.'],['Y', '.', '.']], 3 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3212Data))]
    public void Test_NumberOfSubmatrices(char[][] grid, int expected) {
        // Arrange
        var solution = new Lc3212Solution();

        // Act
        var result = solution.NumberOfSubmatrices(grid);

        // Assert
        Assert.Equal(expected, result);
    }
}