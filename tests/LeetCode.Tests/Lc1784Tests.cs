using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1784Tests {
    public static TheoryData<string, bool> Lc1784Data => new()
    {
        // s, expectedResult
        { "1001", false },
        { "110", true },
    };
    
    [Theory]
    [MemberData(nameof(Lc1784Data))]
    public void Test_CheckOnesSegment(string s, bool expected) {
        // Arrange
        var solution = new Lc1784Solution();

        // Act
        var result = solution.CheckOnesSegment(s);

        // Assert
        Assert.Equal(expected, result);
    }
}