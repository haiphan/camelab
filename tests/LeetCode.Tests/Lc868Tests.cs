using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc868Tests {
    public static TheoryData<int, int> Lc868Data => new()
    {
        // n, expectedResult
        { 22, 2 },
    };
    
    [Theory]
    [MemberData(nameof(Lc868Data))]
    public void Test_BinaryGap(int n, int expected) {
        // Arrange
        var solution = new Lc868Solution();

        // Act
        var result = solution.BinaryGap(n);

        // Assert
        Assert.Equal(expected, result);
    }
}