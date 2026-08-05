using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3310Tests {
    public static TheoryData<int, int, int[][], IList<int>> Lc3310Data => new()
    {
        // n, k, invocations, expected
        {4, 1, [[1,2],[0,1],[3,2]], new List<int> {0,1,2,3}},
        {5, 2, [], new List<int> {0,1,3,4}},
        {3, 2, [[1,2],[0,1],[2,0]], new List<int>()},
    };
    
    [Theory]
    [MemberData(nameof(Lc3310Data))]
    public void Test_RemainingMethods(int n, int k, int[][] invocations, IList<int> expected) {
        // Arrange
        var solution = new Lc3310Solution();

        // Act
        var result = solution.RemainingMethods(n, k, invocations);

        // Assert
        Assert.Equal(expected, result);
    }
}