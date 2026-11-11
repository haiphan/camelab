using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3789Tests {
    public static TheoryData<int, int, int, int, int, long> Lc3789Data => new()
    {
        { 3, 2, 1, 3, 2, 3L },
    };
    
    [Theory]
    [MemberData(nameof(Lc3789Data))]
    public void Test_MinimumCost(int cost1, int cost2, int costBoth, int need1, int need2, long expected) {
        // Arrange
        var solution = new Lc3789Solution();

        // Act
        var result = solution.MinimumCost(cost1, cost2, costBoth, need1, need2);

        // Assert
        Assert.Equal(expected, result);
    }
}