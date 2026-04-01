using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2751Tests {
    public static TheoryData<int[], int[], string, IList<int>> Lc2751Data => new()
    {
        // positions, healths, directions, expectedResult
        { [5,4,3,2,1], [2, 17, 9, 15, 10], "RRRRR", [2,17,9,15,10] },
    };
    
    [Theory]
    [MemberData(nameof(Lc2751Data))]
    public void Test_SurvivedRobotsHealths(int[] positions, int[] healths, string directions, IList<int> expected) {
        // Arrange
        var solution = new Lc2751Solution();

        // Act
        var result = solution.SurvivedRobotsHealths(positions, healths, directions);

        // Assert
        Assert.Equal(expected, result);
    }
}