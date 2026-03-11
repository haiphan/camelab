using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1009Tests {
    public static TheoryData<int, int> Lc1009Data => new()
    {
        // n, expectedResult
        { 5, 2 },
    };
    
    [Theory]
    [MemberData(nameof(Lc1009Data))]
    public void Test_BitwiseComplement(int n, int expected) {
        // Arrange
        var solution = new Lc1009Solution();

        // Act
        var result = solution.BitwiseComplement(n);

        // Assert
        Assert.Equal(expected, result);
    }
}