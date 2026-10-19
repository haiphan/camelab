using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2089Tests {
    public static TheoryData<int[], int, IList<int>> Lc2089Data => new()
    {
        // nums, target, expected
        {[1,2,5,2,3], 2, [1, 2]},
    };
    
    [Theory]
    [MemberData(nameof(Lc2089Data))]
    public void Test_TargetIndices(int[] nums, int target, IList<int> expected) {
        // Arrange
        var solution = new Lc2089Solution();

        // Act
        var result = solution.TargetIndices(nums, target);

        // Assert
        Assert.Equal(expected, result);
    }
}