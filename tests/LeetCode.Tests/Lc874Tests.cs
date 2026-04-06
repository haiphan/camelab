using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc874Tests {
    public static TheoryData<int[], int[][], int> Lc874Data => new()
    {
        // commands, obstacles, expectedResult
        { [4,-1,3], [], 25 },
    };
    
    [Theory]
    [MemberData(nameof(Lc874Data))]
    public void Test_RobotSim(int[] commands, int[][] obstacles, int expected) {
        // Arrange
        var solution = new Lc874Solution();

        // Act
        var result = solution.RobotSim(commands, obstacles);

        // Assert
        Assert.Equal(expected, result);
    }
}