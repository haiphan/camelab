using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3963Tests {
    public static TheoryData<int, int> Lc3963Data => new()
    {
        // m, n
        {2, 3},
    };
    
    [Theory]
    [MemberData(nameof(Lc3963Data))]
    public void Test_CreateGrid(int m, int n) {
        // Arrange
        var solution = new Lc3963Solution();

        // Act
        var result = solution.CreateGrid(m, n);

        // Assert
        Assert.Equal(m, result.Length);
        foreach (string row in result)
        {
            Assert.Equal(n, row.Length);
            Assert.All(row, ch => Assert.True(ch == '.' || ch == '#'));
        }

        Assert.Equal(1, solution.CountPaths(result));
    }
}