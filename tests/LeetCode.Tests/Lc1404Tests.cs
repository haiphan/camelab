using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1404Tests {
    public static TheoryData<string, int> Lc1404Data => new()
    {
        // s, expectedResult
        { "1101", 6 },
    };
    
    [Theory]
    [MemberData(nameof(Lc1404Data))]
    public void Test_NumSteps(string s, int expected) {
        // Arrange
        var solution = new Lc1404Solution();

        // Act
        var result = solution.NumSteps(s);

        // Assert
        Assert.Equal(expected, result);
    }
}