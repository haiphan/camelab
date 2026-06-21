using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1833Tests {
    public static TheoryData<int[], int, int> Lc1833Data => new()
    {
        // costs, coins, expected
        { new[] {1,3,2,4,1}, 7, 4 },
    };
    
    [Theory]
    [MemberData(nameof(Lc1833Data))]
    public void Test_MaxIceCream(int[] costs, int coins, int expected) {
        // Arrange
        var solution = new Lc1833Solution();

        // Act
        var result = solution.MaxIceCream(costs, coins);

        // Assert
        Assert.Equal(expected, result);
    }
}