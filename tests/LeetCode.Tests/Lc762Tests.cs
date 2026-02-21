using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc762Tests {
    public static TheoryData<int, int, int> Lc762Data => new()
    {
        // left, right, expectedResult
        { 6, 10, 4 },
    };
    
    [Theory]
    [MemberData(nameof(Lc762Data))]
    public void Test_CountPrimeSetBits(int left, int right, int expected) {
        // Arrange
        var solution = new Lc762Solution();

        // Act
        var result = solution.CountPrimeSetBits(left, right);

        // Assert
        Assert.Equal(expected, result);
    }
}