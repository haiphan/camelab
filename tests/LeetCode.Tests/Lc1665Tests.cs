using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1665Tests {
    public static TheoryData<int[][], int> Lc1665Data => new()
    {
        // tasks, expectedResult
        { [[1,2],[2,4],[4,8]], 8 },
        { [[1,3],[2,4],[10,11],[10,12],[8,9]], 32 }
    };
    
    [Theory]
    [MemberData(nameof(Lc1665Data))]
    public void Test_MinimumEffort(int[][] tasks, int expected) {
        // Arrange
        var solution = new Lc1665Solution();

        // Act
        var result = solution.MinimumEffort(tasks);

        // Assert
        Assert.Equal(expected, result);
    }
}