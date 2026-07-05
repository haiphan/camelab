using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1301Tests {
    public static TheoryData<IList<string>, int[]> Lc1301Data => new()
    {
        // board, expected
        { ["E23","2X2","12S"], [7, 1] }
    };
    
    [Theory]
    [MemberData(nameof(Lc1301Data))]
    public void Test_PathsWithMaxScore(IList<string> board, int[] expected) {
        // Arrange
        var solution = new Lc1301Solution();

        // Act
        var result = solution.PathsWithMaxScore(board);

        // Assert
        Assert.Equal(expected, result);
    }
}