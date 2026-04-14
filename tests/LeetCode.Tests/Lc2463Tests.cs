using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2463Tests {
    public static TheoryData<IList<int>, int[][], long> Lc2463Data => new()
    {
        // robot, factory, expectedResult
        { [0,4,6], [[2,2],[6,2]], 4 },
        { [1,-1], [[-2,1],[2,1]], 2 },
    };
    
    [Theory]
    [MemberData(nameof(Lc2463Data))]
    public void Test_MinimumTotalDistance(IList<int> robot, int[][] factory, long expected) {
        // Arrange
        var solution = new Lc2463Solution();

        // Act
        var result = solution.MinimumTotalDistance(robot, factory);

        // Assert
        Assert.Equal(expected, result);
    }
}