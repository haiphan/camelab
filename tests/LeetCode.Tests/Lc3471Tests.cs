using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3471Tests {
    public static TheoryData<int[], int, int> Lc3471Data => new()
    {
        // nums, k, expected
        { [3,9,2,1,7], 3, 7 },
        { [3,9,7,2,1,7], 4, 3 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3471Data))]
    public void Test_LargestInteger(int[] nums, int k, int expected) {
        // Arrange
        var solution = new Lc3471Solution();

        // Act
        var result = solution.LargestInteger(nums, k);

        // Assert
        Assert.Equal(expected, result);
    }
}