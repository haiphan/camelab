using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3838Tests {
    public static TheoryData<string[], int[], string> Lc3838Data => new()
    {
        // words, weights, expected
        {["abcd","def","xyz"], [5,3,12,14,1,2,3,2,10,6,6,9,7,8,7,10,8,9,6,9,9,8,3,7,7,2], "rij"},
    };
    
    [Theory]
    [MemberData(nameof(Lc3838Data))]
    public void Test_MapWordWeights(string[] words, int[] weights, string expected) {
        // Arrange
        var solution = new Lc3838Solution();

        // Act
        var result = solution.MapWordWeights(words, weights);

        // Assert
        Assert.Equal(expected, result);
    }
}