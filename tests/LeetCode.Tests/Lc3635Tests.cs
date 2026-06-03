using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3635Tests {
    public static TheoryData<int[], int[], int[], int[], int> Lc3635Data => new()
    {
        // landStartTime, landDuration, waterStartTime, waterDuration, expectedResult
        { [2, 8], [4, 1], [6], [3], 9 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3635Data))]
    public void Test_EarliestFinishTime(int[] landStartTime, int[] landDuration, int[] waterStartTime, int[] waterDuration, int expected) {
        // Arrange
        var solution = new Lc3635Solution();

        // Act
        var result = solution.EarliestFinishTime(landStartTime, landDuration, waterStartTime, waterDuration);

        // Assert
        Assert.Equal(expected, result);
    }
}