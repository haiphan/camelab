using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1732Tests {
    public static TheoryData<int[], int> Lc1732Data => new()
    {
        // gain, expected
        { new[] {-5,1,5,0,-7}, 1 },
    };
    
    [Theory]
    [MemberData(nameof(Lc1732Data))]
    public void Test_LargestAltitude(int[] gain, int expected) {
        // Arrange
        var solution = new Lc1732Solution();

        // Act
        var result = solution.LargestAltitude(gain);

        // Assert
        Assert.Equal(expected, result);
    }
}