using LeetCode.Library.Algorithms;
using LeetCode.Library.DataStructures;
using Xunit;

namespace LeetCode.Tests;

public class Lc110Tests {
    public static TheoryData<string, bool> Lc110Data => new()
    {
        // tree, expectedResult
        { "3,9,#,#,20,15,#,#,7,#,#", true },
        { "1,2,2,3,3,#,#,#,#,#,#", false },
    };
    
    [Theory]
    [MemberData(nameof(Lc110Data))]
    public void Test_IsBalanced(string tree, bool expected) {
        // Arrange
        var solution = new Lc110Solution();
        var codec = new TreeCodec();
        TreeNode root = codec.Deserialize(tree)!;
        // Act
        var result = solution.IsBalanced(root);

        // Assert
        Assert.Equal(expected, result);
    }
}