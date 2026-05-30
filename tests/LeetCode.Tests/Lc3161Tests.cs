using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3161Tests {
    public static TheoryData<int[][], IList<bool>> Lc3161Data => new()
    {
        // queries, expectedResult
        { [[1,2],[2,3,3],[2,3,1],[2,2,2]], [false, true, true] },
    };
    
    [Theory]
    [MemberData(nameof(Lc3161Data))]
    public void Test_GetResults(int[][] queries, IList<bool> expected) {
        // Arrange
        var solution = new Lc3161Solution();

        // Act
        var result = solution.GetResults(queries);

        // Assert
        Assert.Equal(expected, result);
    }
}