using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc153Tests {
    public static TheoryData<int[], int> Lc153Data => new()
    {
        // nums, expectedResult
        { [3,4,5,1,2], 1 },
        { [4,5,6,7,0,1,2], 0 },
        { [11,13,15,17], 11 },
    };
    
    [Theory]
    [MemberData(nameof(Lc153Data))]
    public void Test_FindMin(int[] nums, int expected) {
        // Arrange
        var solution = new Lc153Solution();

        // Act
        var result = solution.FindMin(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}