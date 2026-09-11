using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3483Tests {
    public static TheoryData<int[], int> Lc3483Data => new()
    {
        // digits, expected
        { [1, 2, 3, 4], 12 },
        { [0, 2, 2], 2 }
    };
    
    [Theory]
    [MemberData(nameof(Lc3483Data))]
    public void Test_TotalNumbers(int[] digits, int expected) {
        // Arrange
        var solution = new Lc3483Solution();

        // Act
        var result = solution.TotalNumbers(digits);

        // Assert
        Assert.Equal(expected, result);
    }
}