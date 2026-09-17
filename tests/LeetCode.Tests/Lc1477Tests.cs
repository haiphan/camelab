using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1477Tests {
    public static TheoryData<int[], int, int> Lc1477Data => new()
    {
        // arr, target, expected
        { [3,2,2,4,3], 3, 2 }
    };
    
    [Theory]
    [MemberData(nameof(Lc1477Data))]
    public void Test_MinSumOfLengths(int[] arr, int target, int expected) {
        // Arrange
        var solution = new Lc1477Solution();

        // Act
        var result = solution.MinSumOfLengths(arr, target);

        // Assert
        Assert.Equal(expected, result);
    }
}