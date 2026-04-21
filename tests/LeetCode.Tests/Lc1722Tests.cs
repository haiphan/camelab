using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1722Tests {
    public static TheoryData<int[], int[], int[][], int> Lc1722Data => new()
    {
        // source, target, allowedSwaps, expectedResult
        { [1,2,3,4], [2,1,4,5], [[0,1],[2,3]], 1 },
    };
    
    [Theory]
    [MemberData(nameof(Lc1722Data))]
    public void Test_MinimumHammingDistance(int[] source, int[] target, int[][] allowedSwaps, int expected) {
        // Arrange
        var solution = new Lc1722Solution();

        // Act
        var result = solution.MinimumHammingDistance(source, target, allowedSwaps);

        // Assert
        Assert.Equal(expected, result);
    }
}