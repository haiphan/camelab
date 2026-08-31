using LeetCode.Library.Algorithms;
using LeetCode.Library.DataStructures;
using Xunit;

namespace LeetCode.Tests;

public class Lc2058Tests {
    public static TheoryData<int[], int[]> Lc2058Data => new()
    {
        // head, expected
        { [3,1], [-1, -1] },
        { [5,3,1,2,5,1,2], [1, 3] },
    };
    
    [Theory]
    [MemberData(nameof(Lc2058Data))]
    public void Test_NodesBetweenCriticalPoints(int[] headArr, int[] expected) {
        // Arrange
        var solution = new Lc2058Solution();
        ListCodec listCodec = new ListCodec();
        var head = listCodec.CreateList(headArr);

        // Act
        var result = solution.NodesBetweenCriticalPoints(head);

        // Assert
        Assert.Equal(expected, result);
    }
}