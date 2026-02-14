using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc799Tests {
    public static TheoryData<int, int, int, double> Lc799Data => new()
    {
        // poured, query_row, query_glass, expectedResult
        { 1, 1, 1, 0.0 },
        { 2, 1, 1, 0.5 },
        { 100000009, 33, 15, 1.0 },
    };
    
    [Theory]
    [MemberData(nameof(Lc799Data))]
    public void Test_ChampagneTower(int poured, int query_row, int query_glass, double expected) {
        // Arrange
        var solution = new Lc799Solution();

        // Act
        var result = solution.ChampagneTower(poured, query_row, query_glass);

        // Assert
        Assert.Equal(expected, result);
    }
}