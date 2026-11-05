using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1385Tests {
    public static TheoryData<int[], int[], int, int> Lc1385Data => new()
    {
        // arr1, arr2, d, expected
        { [4,5,8], [10,9,1,8], 2, 2 }
    };
    
    [Theory]
    [MemberData(nameof(Lc1385Data))]
    public void Test_FindTheDistanceValue(int[] arr1, int[] arr2, int d, int expected) {
        // Arrange
        var solution = new Lc1385Solution();

        // Act
        var result = solution.FindTheDistanceValue(arr1, arr2, d);

        // Assert
        Assert.Equal(expected, result);
    }
}