using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3488Tests {
    public static TheoryData<int[], int[], IList<int>> Lc3488Data => new()
    {
        // nums, queries, expectedResult
        { [1,3,1,4,1,3,2], [0,3,5], [2,-1,3] },
    };
    
    [Theory]
    [MemberData(nameof(Lc3488Data))]
    public void Test_SolveQueries(int[] nums, int[] queries, IList<int> expected) {
        // Arrange
        var solution = new Lc3488Solution();

        // Act
        var result = solution.SolveQueries(nums, queries);

        // Assert
        Assert.Equal(expected, result);
    }
}