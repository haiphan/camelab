using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3934Tests {
    public static TheoryData<int[], int> Lc3934Data => new()
    {
        {[3,3,3], 3},
        {[1], 1},
        {[1,2], 1},
        {[1,1,2,2], 2},
        {[1,1,1,1,1], 5},
        {[1,2,1,2,1,2], 4},
    };
    
    [Theory]
    [MemberData(nameof(Lc3934Data))]
    public void Test_SmallestUniqueSubarray(int[] nums, int expected) {
        // Arrange
        var solution = new Lc3934Solution();

        // Act
        var result = solution.SmallestUniqueSubarray(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}