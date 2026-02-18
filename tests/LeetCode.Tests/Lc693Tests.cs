using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc693Tests {
    public static TheoryData<int, bool> Lc693Data => new()
    {
        // n, expectedResult
        { 5, true },
        { 7, false },
        { 11, false },
        { 10, true },
    };
    
    [Theory]
    [MemberData(nameof(Lc693Data))]
    public void Test_HasAlternatingBits(int n, bool expected) {
        // Arrange
        var solution = new Lc693Solution();

        // Act
        var result = solution.HasAlternatingBits(n);

        // Assert
        Assert.Equal(expected, result);
    }
}