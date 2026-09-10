using LeetCode.Library.Algorithms;
using LeetCode.Library.DataStructures;
using Xunit;

namespace LeetCode.Tests;

public class Lc2265Tests {
    public static TheoryData<string, int> Lc2265Data => new()
    {
        // tree, expected
        { "4,8,0,#,#,1,#,#,5,#,6,#,#", 5 },
    };
    
    [Theory]
    [MemberData(nameof(Lc2265Data))]
    public void Test_AverageOfSubtree(string tree, int expected) {
        // Arrange
        var solution = new Lc2265Solution();

        // Act
        TreeCodec codec = new TreeCodec();
        TreeNode root = codec.Deserialize(tree)!;
        var result = solution.AverageOfSubtree(root);

        // Assert
        Assert.Equal(expected, result);
    }
}