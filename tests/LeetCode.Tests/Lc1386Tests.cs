using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1386Tests {
    public static TheoryData<int, int[][], int> Lc1386Data => new()
    {
        // n, reservedSeats, expected
        { 3, [[1,2],[1,3],[1,8],[2,6],[3,1],[3,10]], 4 },
        { 2, [[2,1],[1,8],[2,6]], 2 },
        { 1, [[1,1]], 2 },
        { 1, [[1,2]], 1 },
        { 1, [[1,2],[1,9]], 1 },
    };
    
    [Theory]
    [MemberData(nameof(Lc1386Data))]
    public void Test_MaxNumberOfFamilies(int n, int[][] reservedSeats, int expected) {
        // Arrange
        var solution = new Lc1386Solution();

        // Act
        var result = solution.MaxNumberOfFamilies(n, reservedSeats);

        // Assert
        Assert.Equal(expected, result);
    }
}