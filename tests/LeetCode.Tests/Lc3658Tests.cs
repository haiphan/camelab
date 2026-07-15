using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3658Tests {
    public static TheoryData<int, int> Lc3658Data => new()
    {
        { 4, 4 },
        { 5, 5 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3658Data))]
    public void Test_GcdOfOddEvenSums(int n, int expected) {
        // Arrange
        var solution = new Lc3658Solution();

        // Act
        var result = solution.GcdOfOddEvenSums(n);

        // Assert
        Assert.Equal(expected, result);
    }
}