using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2213Tests {
    public static TheoryData<string, string, int[], int[]> Lc2213Data => new()
    {
        // s, queryCharacters, queryIndices, expected
        { "babacc", "bcb", [1, 3, 3 ], [3, 3, 4] },
        { "abyzz", "aa", [2, 1], [2, 3] },
    };
    
    [Theory]
    [MemberData(nameof(Lc2213Data))]
    public void Test_LongestRepeating(string s, string queryCharacters, int[] queryIndices, int[] expected) {
        // Arrange
        var solution = new Lc2213Solution();

        // Act
        var result = solution.LongestRepeating(s, queryCharacters, queryIndices);

        // Assert
        Assert.Equal(expected, result);
    }
}