using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc33Tests {
    public static TheoryData<int[], int, int> Lc33Data => new()
    {
        // nums, target, expectedResult
        { [4,5,6,7,0,1,2], 0, 4 },
        { [4,5,6,7,0,1,2], 3, -1 },
        { [1], 0, -1 },
    };
    
    [Theory]
    [MemberData(nameof(Lc33Data))]
    public void Test_Search(int[] nums, int target, int expected) {
        // Arrange
        var solution = new Lc33Solution();

        // Act
        var result = solution.Search(nums, target);

        // Assert
        Assert.Equal(expected, result);
    }
}