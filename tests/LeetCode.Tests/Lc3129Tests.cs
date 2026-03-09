using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3129Tests {
    public static TheoryData<int, int, int, int> Lc3129Data => new()
    {
        // zero, one, limit, expectedResult
        { 1, 1, 2, 2 },
        { 3, 3, 2, 14 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3129Data))]
    public void Test_NumberOfStableArrays(int zero, int one, int limit, int expected) {
        // Arrange
        var solution = new Lc3129Solution();

        // Act
        var result = solution.NumberOfStableArrays(zero, one, limit);

        // Assert
        Assert.Equal(expected, result);
    }
}