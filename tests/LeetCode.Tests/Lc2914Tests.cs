using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2914Tests {
    public static TheoryData<string, int> Lc2914Data => new()
    {
        { "1001", 2 },
    };
    
    [Theory]
    [MemberData(nameof(Lc2914Data))]
    public void Test_MinChanges(string s, int expected) {
        // Arrange
        var solution = new Lc2914Solution();

        // Act
        var result = solution.MinChanges(s);

        // Assert
        Assert.Equal(expected, result);
    }
}