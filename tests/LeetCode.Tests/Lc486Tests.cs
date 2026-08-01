using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc486Tests {
    public static TheoryData<int[], bool> Lc486Data => new()
    {
        // nums, expected
        {[1,5,233,7], true}
    };
    
    [Theory]
    [MemberData(nameof(Lc486Data))]
    public void Test_PredictTheWinner(int[] nums, bool expected) {
        // Arrange
        var solution = new Lc486Solution();

        // Act
        var result = solution.PredictTheWinner(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}