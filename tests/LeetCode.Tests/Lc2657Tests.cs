using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2657Tests {
    public static TheoryData<int[], int[], int[]> Lc2657Data => new()
    {
        // A, B, expectedResult
        { [1,3,2,4], [3,1,2,4], [0,2,3,4] },
    };
    
    [Theory]
    [MemberData(nameof(Lc2657Data))]
    public void Test_FindThePrefixCommonArray(int[] A, int[] B, int[] expected) {
        // Arrange
        var solution = new Lc2657Solution();

        // Act
        var result = solution.FindThePrefixCommonArray(A, B);

        // Assert
        Assert.Equal(expected, result);
    }
}