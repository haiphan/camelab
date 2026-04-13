using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1848Tests {
    public static TheoryData<int[], int, int, int> Lc1848Data => new()
    {
        // nums, target, start, expectedResult
        { [1,2,3,4,5], 5, 3, 1 },
        { [1], 1, 0, 0 },
        { [1,1,1,1,1], 1, 0, 0 },
    };
    
    [Theory]
    [MemberData(nameof(Lc1848Data))]
    public void Test_GetMinDistance(int[] nums, int target, int start, int expected) {
        // Arrange
        var solution = new Lc1848Solution();

        // Act
        var result = solution.GetMinDistance(nums, target, start);

        // Assert
        Assert.Equal(expected, result);
    }
}