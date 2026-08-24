using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1872Tests {
    public static TheoryData<int[], int> Lc1872Data => new()
    {
        // stones, expected
        { [-1,2,-3,4,-5], 5 },
        { [7,-6,5,10,5,-2,-6], 13 },
    };
    
    [Theory]
    [MemberData(nameof(Lc1872Data))]
    public void Test_StoneGameVIII(int[] stones, int expected) {
        // Arrange
        var solution = new Lc1872Solution();

        // Act
        var result = solution.StoneGameVIII(stones);

        // Assert
        Assert.Equal(expected, result);
    }
}