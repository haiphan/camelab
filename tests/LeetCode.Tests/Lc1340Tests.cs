using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1340Tests {
    public static TheoryData<int[], int, int> Lc1340Data => new()
    {
        // arr, d, expectedResult
        { [6,4,14,6,8,13,9,7,10,6,12], 2, 4 },
        { [3,3,3,3,3], 3, 1 },
        { [7,6,5,4,3], 1, 5 },
    };
    
    [Theory]
    [MemberData(nameof(Lc1340Data))]
    public void Test_MaxJumps(int[] arr, int d, int expected) {
        // Arrange
        var solution = new Lc1340Solution();

        // Act
        var result = solution.MaxJumps(arr, d);

        // Assert
        Assert.Equal(expected, result);
    }
}