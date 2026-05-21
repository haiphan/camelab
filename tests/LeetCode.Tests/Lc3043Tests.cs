using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3043Tests {
    public static TheoryData<int[], int[], int> Lc3043Data => new()
    {
        // arr1, arr2, expectedResult
        { [1,10,100], [1000], 3 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3043Data))]
    public void Test_LongestCommonPrefix(int[] arr1, int[] arr2, int expected) {
        // Arrange
        var solution = new Lc3043Solution();

        // Act
        var result = solution.LongestCommonPrefix(arr1, arr2);

        // Assert
        Assert.Equal(expected, result);
    }
}