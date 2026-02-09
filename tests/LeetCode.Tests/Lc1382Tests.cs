using LeetCode.Library.Algorithms;
using LeetCode.Library.DataStructures;
using Xunit;

namespace LeetCode.Tests;

public class Lc1382Tests {
    public static TheoryData<string, string> Lc1382Data => new()
    {
        // tree, expectedResult
        { "1,#,2,#,3,#,4,#,#", "2,1,#,#,3,#,4,#,#" },
    };
    
    [Theory]
    [MemberData(nameof(Lc1382Data))]
    public void Test_BalanceBST(string tree, string expected) {
        // Arrange
        var solution = new Lc1382Solution();
        var codec = new TreeCodec();
        var root = codec.Deserialize(tree)!;

        // Act
        var resultRoot = solution.BalanceBST(root);
        var result = codec.Serialize(resultRoot);
    
        // Assert
        Assert.Equal(expected, result);
    }
}