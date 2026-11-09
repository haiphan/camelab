using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1606Tests {
    public static TheoryData<int, int[], int[], IList<int>> Lc1606Data => new()
    {
        // k, arrival, load, expected
        { 3, [1,2,3,4,5], [5,2,3,3,3], [1] },
        { 3, [1,2,3,4], [1,2,1,2], [0] },
        { 3, [1,2,3], [10,10,10], [0,1,2] }
    };
    
    [Theory]
    [MemberData(nameof(Lc1606Data))]
    public void Test_BusiestServers(int k, int[] arrival, int[] load, IList<int> expected) {
        // Arrange
        var solution = new Lc1606Solution();

        // Act
        var result = solution.BusiestServers(k, arrival, load);

        // Assert
        Assert.Equal(expected, result);
    }
}