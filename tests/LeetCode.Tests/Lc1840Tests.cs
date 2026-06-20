using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1840Tests {
    public static TheoryData<int, int[][], int> Lc1840Data => new()
    {
        // n, restrictions, expected
        { 5, [[2,1],[4,1]], 2 },
    };
    
    [Theory]
    [MemberData(nameof(Lc1840Data))]
    public void Test_MaxBuilding(int n, int[][] restrictions, int expected) {
        // Arrange
        var solution = new Lc1840Solution();

        // Act
        var result = solution.MaxBuilding(n, restrictions);

        // Assert
        Assert.Equal(expected, result);
    }
}