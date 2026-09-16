using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1621Tests {
    public static TheoryData<int, int, int> Lc1621Data => new()
    {
        { 4, 2, 5 },
    };
    
    [Theory]
    [MemberData(nameof(Lc1621Data))]
    public void Test_NumberOfSets(int n, int k, int expected) {
        // Arrange
        var solution = new Lc1621Solution();

        // Act
        var result = solution.NumberOfSets(n, k);

        // Assert
        Assert.Equal(expected, result);
    }
}