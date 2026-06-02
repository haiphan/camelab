using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3633Tests {
    public static TheoryData<int[], int[], int[], int[], int> Lc3633Data => new()
    {
        // landStartTime, landDuration, waterStartTime, waterDuration, expectedResult
        { [5], [3], [1], [10], 14 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3633Data))]
    public void Test_EarliestFinishTime(int[] landStartTime, int[] landDuration, int[] waterStartTime, int[] waterDuration, int expected) {
        // Arrange
        var solution = new Lc3633Solution();

        // Act
        var result = solution.EarliestFinishTime(landStartTime, landDuration, waterStartTime, waterDuration);

        // Assert
        Assert.Equal(expected, result);
    }
}