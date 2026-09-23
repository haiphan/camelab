using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1658Tests {
    public static TheoryData<int[], int, int> Lc1658Data => new()
    {
        // nums, x, expected
        { [1,1,4,2,3], 5, 2 },
        { [5,6,7,8,9], 4, -1 },
        { [3,2,20,1,1,3], 10, 5 }
    };
    
    [Theory]
    [MemberData(nameof(Lc1658Data))]
    public void Test_MinOperations(int[] nums, int x, int expected) {
        // Arrange
        var solution = new Lc1658Solution();

        // Act
        var result = solution.MinOperations(nums, x);

        // Assert
        Assert.Equal(expected, result);
    }
}