using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3505Tests {
    public static TheoryData<int[], int, int, long> Lc3505Data => new()
    {
        // nums, x, k, expected
        { [5,-2,1,3,7,3,6,4,-1], 3, 2, 8 }
    };
    
    [Theory]
    [MemberData(nameof(Lc3505Data))]
    public void Test_MinOperations(int[] nums, int x, int k, long expected) {
        // Arrange
        var solution = new Lc3505Solution();

        // Act
        var result = solution.MinOperations(nums, x, k);

        // Assert
        Assert.Equal(expected, result);
    }
}