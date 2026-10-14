using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3723Tests {
    public static TheoryData<int, int, string> Lc3723Data => new()
    {
        { 2, 3, "30" },
        { 1, 10, "" },
    };
    
    [Theory]
    [MemberData(nameof(Lc3723Data))]
    public void Test_MaxSumOfSquares(int num, int sum, string expected) {
        // Arrange
        var solution = new Lc3723Solution();

        // Act
        var result = solution.MaxSumOfSquares(num, sum);

        // Assert
        Assert.Equal(expected, result);
    }
}