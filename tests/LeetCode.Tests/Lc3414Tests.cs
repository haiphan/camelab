using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3414Tests {
    public static TheoryData<IList<IList<int>>, int[]> Lc3414Data => new()
    {
        // intervals, expected
        {[[1,3,2],[4,5,2],[1,5,5],[6,9,3],[6,7,1],[8,9,1]], [2, 3]}
    };
    
    [Theory]
    [MemberData(nameof(Lc3414Data))]
    public void Test_MaximumWeight(IList<IList<int>> intervals, int[] expected) {
        // Arrange
        var solution = new Lc3414Solution();

        // Act
        var result = solution.MaximumWeight(intervals);

        // Assert
        Assert.Equal(expected, result);
    }
}