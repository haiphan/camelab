using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc835Tests {
    public static TheoryData<int[][], int[][], int> Lc835Data => new()
    {
        // img1, img2, expected
        { [[1,1,0],[0,1,0],[0,1,0]], [[0,0,0],[0,1,1],[0,0,1]], 3}
    };
    
    [Theory]
    [MemberData(nameof(Lc835Data))]
    public void Test_LargestOverlap(int[][] img1, int[][] img2, int expected) {
        // Arrange
        var solution = new Lc835Solution();

        // Act
        var result = solution.LargestOverlap(img1, img2);

        // Assert
        Assert.Equal(expected, result);
    }
}