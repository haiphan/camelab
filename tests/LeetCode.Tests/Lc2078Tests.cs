using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2078Tests {
    public static TheoryData<int[], int> Lc2078Data => new()
    {
        // colors, expectedResult
        { [1,1,1,6,1,1,1], 3 },
    };
    
    [Theory]
    [MemberData(nameof(Lc2078Data))]
    public void Test_MaxDistance(int[] colors, int expected) {
        // Arrange
        var solution = new Lc2078Solution();

        // Act
        var result = solution.MaxDistance(colors);

        // Assert
        Assert.Equal(expected, result);
    }
}