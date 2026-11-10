using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3693Tests {
    public static TheoryData<int, int[], int> Lc3693Data => new()
    {
        // n, costs, expected
        { 4, [1,2,3,4], 13 }
    };
    
    [Theory]
    [MemberData(nameof(Lc3693Data))]
    public void Test_ClimbStairs(int n, int[] costs, int expected) {
        // Arrange
        var solution = new Lc3693Solution();

        // Act
        var result = solution.ClimbStairs(n, costs);

        // Assert
        Assert.Equal(expected, result);
    }
}