using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1545Tests {
    public static TheoryData<int, int, char> Lc1545Data => new()
    {
        // n, k, expectedResult
        { 3, 1, '0' },
    };
    
    [Theory]
    [MemberData(nameof(Lc1545Data))]
    public void Test_FindKthBit(int n, int k, char expected) {
        // Arrange
        var solution = new Lc1545Solution();

        // Act
        var result = solution.FindKthBit(n, k);

        // Assert
        Assert.Equal(expected, result);
    }
}