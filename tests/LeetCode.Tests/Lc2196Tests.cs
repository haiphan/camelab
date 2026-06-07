using LeetCode.Library.Algorithms;
using LeetCode.Library.DataStructures;
using Xunit;

namespace LeetCode.Tests;

public class Lc2196Tests {
    public static TheoryData<int[][], string> Lc2196Data => new()
    {
        // descriptions, expectedResult
        { [[20,15,1],[20,17,0],[50,20,1],[50,80,0],[80,19,1]], "50,20,15,#,#,17,#,#,80,19,#,#,#" },
    };
    
    [Theory]
    [MemberData(nameof(Lc2196Data))]
    public void Test_CreateBinaryTree(int[][] descriptions, string expected) {
        // Arrange
        var solution = new Lc2196Solution();
        TreeCodec codec = new TreeCodec();

        // Act
        var result = solution.CreateBinaryTree(descriptions);
        string resultStr = codec.Serialize(result);
        // Assert
        Assert.Equal(expected, resultStr);
    }
}