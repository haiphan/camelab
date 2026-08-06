using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3345Tests {
    public static TheoryData<int, int, int> Lc3345Data => new()
    {
        { 15, 3, 16 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3345Data))]
    public void Test_SmallestNumber(int n, int t, int expected) {
        // Arrange
        var solution = new Lc3345Solution();

        // Act
        var result = solution.SmallestNumber(n, t);

        // Assert
        Assert.Equal(expected, result);
    }
}