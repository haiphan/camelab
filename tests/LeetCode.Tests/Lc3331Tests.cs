using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3331Tests {
    public static TheoryData<int[], string, int[]> Lc3331Data => new()
    {
        // parent, s, expected
        {[-1,0,0,1,1,1], "abaabc",[6,3,1,1,1,1] }
    };
    
    [Theory]
    [MemberData(nameof(Lc3331Data))]
    public void Test_FindSubtreeSizes(int[] parent, string s, int[] expected) {
        // Arrange
        var solution = new Lc3331Solution();

        // Act
        var result = solution.FindSubtreeSizes(parent, s);

        // Assert
        Assert.Equal(expected, result);
    }
}