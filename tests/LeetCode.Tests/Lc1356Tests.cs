using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1356Tests {
    public static TheoryData<int[], int[]> Lc1356Data => new()
    {
        // arr, expectedResult
        { [0,1,2,3,4,5,6,7,8], [0,1,2,4,8,3,5,6,7] },
    };
    
    [Theory]
    [MemberData(nameof(Lc1356Data))]
    public void Test_SortByBits(int[] arr, int[] expected) {
        // Arrange
        var solution = new Lc1356Solution();

        // Act
        var result = solution.SortByBits(arr);

        // Assert
        Assert.Equal(expected, result);
    }
}