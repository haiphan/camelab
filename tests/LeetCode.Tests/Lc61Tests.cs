using LeetCode.Library.Algorithms;
using LeetCode.Library.DataStructures;
using Xunit;

namespace LeetCode.Tests;

public class Lc61Tests {
    public static TheoryData<int[], int, int[]> Lc61Data => new()
    {
        // head, k, expectedResult
        { [1, 2, 3, 4, 5], 2, [4, 5, 1, 2, 3] },
        { [0, 1, 2], 4, [2, 0, 1] },
    };
    
    [Theory]
    [MemberData(nameof(Lc61Data))]
    public void Test_RotateRight(int[] head, int k, int[] expected) {
        // Arrange
        var solution = new Lc61Solution();
        var codec = new ListCodec();
        var headNode = codec.CreateList(head);
        // Act
        var result = solution.RotateRight(headNode, k);

        // Assert
        Assert.Equal(expected, codec.GetListValues(result));
    }
}