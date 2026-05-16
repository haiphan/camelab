using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc154Tests {
    public static TheoryData<int[], int> Lc154Data => new()
    {
        // nums, expectedResult
        { [3,4,5,1,2], 1 },
        { [4,5,6,7,0,1,2], 0 },
        { [11,13,15,17], 11 },
    };
    
    [Theory]
    [MemberData(nameof(Lc154Data))]
    public void Test_FindMin(int[] nums, int expected) {
        // Arrange
        var solution = new Lc154Solution();

        // Act
        var result = solution.FindMin(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}