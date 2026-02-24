using LeetCode.Library.Algorithms;
using LeetCode.Library.DataStructures;
using Xunit;

namespace LeetCode.Tests;

public class Lc1022Tests {
    public static TheoryData<string, int> Lc1022Data => new()
    {
        // tree, expectedResult
        { "1,0,0,#,#,1,#,#,1,0,#,#,1,#,#", 22 },
    };
    
    [Theory]
    [MemberData(nameof(Lc1022Data))]
    public void Test_SumRootToLeaf(string tree, int expected) {
        // Arrange
        var solution = new Lc1022Solution();
        TreeCodec codec = new();
        TreeNode root = codec.Deserialize(tree)!;
        // Act
        var result = solution.SumRootToLeaf(root);

        // Assert
        Assert.Equal(expected, result);
    }
}