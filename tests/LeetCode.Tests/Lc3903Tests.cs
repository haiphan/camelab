using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3903Tests {
    public static TheoryData<int[], int, int> Lc3903Data => new()
    {
        // nums, k, expected
        { [5,0,1,4], 3, 3 }
    };
    
    [Theory]
    [MemberData(nameof(Lc3903Data))]
    public void Test_FirstStableIndex(int[] nums, int k, int expected) {
        // Arrange
        var solution = new Lc3903Solution();

        // Act
        var result = solution.FirstStableIndex(nums, k);

        // Assert
        Assert.Equal(expected, result);
    }
}