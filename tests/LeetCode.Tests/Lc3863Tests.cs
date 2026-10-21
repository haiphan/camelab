using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3863Tests {
    public static TheoryData<string, int> Lc3863Data => new()
    {
        { "dog", 1 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3863Data))]
    public void Test_MinOperations(string s, int expected) {
        // Arrange
        var solution = new Lc3863Solution();

        // Act
        var result = solution.MinOperations(s);

        // Assert
        Assert.Equal(expected, result);
    }
}