using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1927Tests {
    public static TheoryData<string, bool> Lc1927Data => new()
    {
        { "5023", false },
    };
    
    [Theory]
    [MemberData(nameof(Lc1927Data))]
    public void Test_SumGame(string num, bool expected) {
        // Arrange
        var solution = new Lc1927Solution();

        // Act
        var result = solution.SumGame(num);

        // Assert
        Assert.Equal(expected, result);
    }
}