using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2747Tests {
    public static TheoryData<int, int[][], int, int[], int[]> Lc2747Data => new()
    {
        // n, logs, x, queries, expected
        { 3, [[1,3],[2,6],[1,5]], 5, [10,11], [1, 2] },
        { 2, [], 1, [5], [2] },
        { 3, [[1,1],[2,2]], 1, [2,100,200], [1, 3, 3] }
    };
    
    [Theory]
    [MemberData(nameof(Lc2747Data))]
    public void Test_CountServers(int n, int[][] logs, int x, int[] queries, int[] expected) {
        // Arrange
        var solution = new Lc2747Solution();

        // Act
        var result = solution.CountServers(n, logs, x, queries);

        // Assert
        Assert.Equal(expected, result);
    }
}