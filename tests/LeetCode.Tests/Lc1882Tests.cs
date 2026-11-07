using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1882Tests {
    public static TheoryData<int[], int[], int[]> Lc1882Data => new()
    {
        // servers, tasks, expected
        { [3,3,2], [1,2,3,2,1,2], [2,2,0,2,1,2] },
        { [5,1,4,3,2], [2,1,2,4,5,2,1], [1,4,1,4,1,3,2] },
        { [5], [200000,200000,200000], [0, 0, 0] }
    };
    
    [Theory]
    [MemberData(nameof(Lc1882Data))]
    public void Test_AssignTasks(int[] servers, int[] tasks, int[] expected) {
        // Arrange
        var solution = new Lc1882Solution();

        // Act
        var result = solution.AssignTasks(servers, tasks);

        // Assert
        Assert.Equal(expected, result);
    }
}