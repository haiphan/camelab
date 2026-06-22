using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1189Tests {
    public static TheoryData<string, int> Lc1189Data => new()
    {
        { "", 0 },
    };
    
    [Theory]
    [MemberData(nameof(Lc1189Data))]
    public void Test_MaxNumberOfBalloons(string text, int expected) {
        // Arrange
        var solution = new Lc1189Solution();

        // Act
        // var result = solution.MaxNumberOfBalloons(text);

        // Assert
        // Assert.Equal(expected, result);
    }
}