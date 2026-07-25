using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3536Tests {
    public static TheoryData<int, int> Lc3536Data => new()
    {
        { 31, 3 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3536Data))]
    public void Test_MaxProduct(int n, int expected) {
        // Arrange
        var solution = new Lc3536Solution();

        // Act
        var result = solution.MaxProduct(n);

        // Assert
        Assert.Equal(expected, result);
    }
}