using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3946Tests {
    public static TheoryData<int[][], int, int> Lc3946Data => new()
    {
        // items, budget, expected
        {[[6,2],[2,6],[3,4]], 9, 4}
    };
    
    [Theory]
    [MemberData(nameof(Lc3946Data))]
    public void Test_MaximumSaleItems(int[][] items, int budget, int expected) {
        // Arrange
        var solution = new Lc3946Solution();

        // Act
        var result = solution.MaximumSaleItems(items, budget);

        // Assert
        Assert.Equal(expected, result);
    }
}