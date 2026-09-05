using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3904Tests {
    public static TheoryData<int[], int, int> Lc3904Data => new()
    {
        // nums, k, expected
        { [5,0,1,4], 3, 3 }
    };
    
    [Theory]
    [MemberData(nameof(Lc3904Data))]
    public void Test_FirstStableIndex(int[] nums, int k, int expected) {
        // Arrange
        var solution = new Lc3904Solution();

        // Act
        var result = solution.FirstStableIndex(nums, k);

        // Assert
        Assert.Equal(expected, result);
    }
}