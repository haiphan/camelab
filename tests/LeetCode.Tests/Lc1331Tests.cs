using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1331Tests {
    public static TheoryData<int[], int[]> Lc1331Data => new()
    {
        // arr, expected
        { [40,10,20,30], [4,1,2,3] },
        { [100,100,100], [1,1,1] },
        { [-100,-100,-100], [1,1,1] },
        { [-1000,-5000,-3000], [3,1,2] },
        { [-10,-20,-30], [3,2,1] }
    };
    
    [Theory]
    [MemberData(nameof(Lc1331Data))]
    public void Test_ArrayRankTransform(int[] arr, int[] expected) {
        // Arrange
        var solution = new Lc1331Solution();

        // Act
        var result = solution.ArrayRankTransform(arr);

        // Assert
        Assert.Equal(expected, result);
    }
}