using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1345Tests {
    public static TheoryData<int[], int> Lc1345Data => new()
    {
        // arr, expectedResult
        { [100,-23,-23,404,100,23,23,23,3,404], 3 },
        { [1,2,3,1,4], 2 },
    };
    
    [Theory]
    [MemberData(nameof(Lc1345Data))]
    public void Test_MinJumps(int[] arr, int expected) {
        // Arrange
        var solution = new Lc1345Solution();

        // Act
        var result = solution.MinJumps(arr);

        // Assert
        Assert.Equal(expected, result);
    }
}