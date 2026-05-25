using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1871Tests {
    public static TheoryData<string, int, int, bool> Lc1871Data => new()
    {
        // s, minJump, maxJump, expectedResult
        { "011010", 2, 3, true },
        { "01101110", 2, 3, false },
    };
    
    [Theory]
    [MemberData(nameof(Lc1871Data))]
    public void Test_CanReach(string s, int minJump, int maxJump, bool expected) {
        // Arrange
        var solution = new Lc1871Solution();

        // Act
        var result = solution.CanReach(s, minJump, maxJump);

        // Assert
        Assert.Equal(expected, result);
    }
}