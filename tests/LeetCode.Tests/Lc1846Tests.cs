using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1846Tests {
    public static TheoryData<int[], int> Lc1846Data => new()
    {
        // arr, expected
        { [2,2,1,2,1], 2 },
        { [100,1,1000], 3 },
        { [1,2,3,4,5], 5 },
        { [5,4,3,2,1], 5 },
        { [10,9,8,7,6], 5 },
        { [1], 1 },
        { [2], 1 },
        { [3], 1 },
        { [4], 1 },
        { [5], 1 },
    };
    
    [Theory]
    [MemberData(nameof(Lc1846Data))]
    public void Test_MaximumElementAfterDecrementingAndRearranging(int[] arr, int expected) {
        // Arrange
        var solution = new Lc1846Solution();

        // Act
        var result = solution.MaximumElementAfterDecrementingAndRearranging(arr);

        // Assert
        Assert.Equal(expected, result);
    }
}