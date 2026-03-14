using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1415Tests {
    public static TheoryData<int, int, string> Lc1415Data => new()
    {
        // n, k, expectedResult
        { 1, 3, "c" },
    };
    
    [Theory]
    [MemberData(nameof(Lc1415Data))]
    public void Test_GetHappyString(int n, int k, string expected) {
        // Arrange
        var solution = new Lc1415Solution();

        // Act
        var result = solution.GetHappyString(n, k);

        // Assert
        Assert.Equal(expected, result);
    }
}