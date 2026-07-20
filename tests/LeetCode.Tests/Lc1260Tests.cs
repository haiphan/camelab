using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1260Tests {
    public static TheoryData<int[][], int, IList<IList<int>>> Lc1260Data => new()
    {
        // grid, k, expected
        { [[3,8,1,9],[19,7,2,5],[4,6,11,10],[12,0,21,13]], 4, [[12,0,21,13],[3,8,1,9],[19,7,2,5],[4,6,11,10]] },
    };
    
    [Theory]
    [MemberData(nameof(Lc1260Data))]
    public void Test_ShiftGrid(int[][] grid, int k, IList<IList<int>> expected) {
        // Arrange
        var solution = new Lc1260Solution();

        // Act
        var result = solution.ShiftGrid(grid, k);

        // Assert
        Assert.Equal(expected, result);
    }
}