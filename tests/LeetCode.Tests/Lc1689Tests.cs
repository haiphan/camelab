using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1689Tests {
    public static TheoryData<string, int> Lc1689Data => new()
    {
        // n, expectedResult
        { "32", 3 },
    };
    
    [Theory]
    [MemberData(nameof(Lc1689Data))]
    public void Test_minPartitions(string n, int expected) {
        // Arrange
        var solution = new Lc1689Solution();

        // Act
        var result = solution.MinPartitions(n);

        // Assert
        Assert.Equal(expected, result);
    }
}