using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3661Tests {
    public static TheoryData<int[], int[], int[], int> Lc3661Data => new()
    {
        // robots, distance, walls, expectedResult
        { [4], [3], [1, 10], 1 },
        {[17,59,32,11,72,18], [5,7,6,5,2,10], [17,25,33,29,54,53,18,35,39,37,20,14,34,13,16,58,22,51,56,27,10,15,12,23,45,43,21,2,42,7,32,40,8,9,1,5,55,30,38,4,3,31,36,41,57,28,11,49,26,19,50,52,6,47,46,44,24,48], 37 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3661Data))]
    public void Test_MaxWalls(int[] robots, int[] distance, int[] walls, int expected) {
        // Arrange
        var solution = new Lc3661Solution();

        // Act
        var result = solution.MaxWalls(robots, distance, walls);

        // Assert
        Assert.Equal(expected, result);
    }
}