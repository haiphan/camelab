using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1406Tests {
    public static TheoryData<int[], string> Lc1406Data => new()
    {
        // stoneValue, expected
        {[1,2,3,7], "Bob"}
    };
    
    [Theory]
    [MemberData(nameof(Lc1406Data))]
    public void Test_StoneGameIII(int[] stoneValue, string expected) {
        // Arrange
        var solution = new Lc1406Solution();

        // Act
        var result = solution.StoneGameIII(stoneValue);

        // Assert
        Assert.Equal(expected, result);
    }
}