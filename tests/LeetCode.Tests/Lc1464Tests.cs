using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1464Tests {
    public static TheoryData<int[], int> Lc1464Data => new()
    {
        // nums, expected
        { [3,4,5,2], 12 },
    };
    
    [Theory]
    [MemberData(nameof(Lc1464Data))]
    public void Test_MaxProduct(int[] nums, int expected) {
        // Arrange
        var solution = new Lc1464Solution();

        // Act
        // var result = solution.MaxProduct(nums);

        // Assert
        // Assert.Equal(expected, result);
    }
}