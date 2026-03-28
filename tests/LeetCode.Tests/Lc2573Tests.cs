using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2573Tests {
    public static TheoryData<int[][], string> Lc2573Data => new()
    {
        // lcp, expectedResult
        { [[4,0,2,0],[0,3,0,1],[2,0,2,0],[0,1,0,1]], "abab" },
    };
    
    [Theory]
    [MemberData(nameof(Lc2573Data))]
    public void Test_FindTheString(int[][] lcp, string expected) {
        // Arrange
        var solution = new Lc2573Solution();

        // Act
        var result = solution.FindTheString(lcp);

        // Assert
        Assert.Equal(expected, result);
    }
}