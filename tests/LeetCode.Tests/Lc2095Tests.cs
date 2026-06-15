using LeetCode.Library.Algorithms;
using LeetCode.Library.DataStructures;
using Xunit;

namespace LeetCode.Tests;

public class Lc2095Tests {
    public static TheoryData<int[], int[]> Lc2095Data => new()
    {
        // head, expected
        {[1,2,3,4,5], [1,2,4,5]},
        {[1], []},
        {[], []}
    };
    
    [Theory]
    [MemberData(nameof(Lc2095Data))]
    public void Test_DeleteMiddle(int[] head, int[] expected) {
        // Arrange
        var solution = new Lc2095Solution();
        ListCodec listCodec = new ListCodec();
        // Act
        var result = solution.DeleteMiddle(listCodec.CreateList(head));

        // Assert
        Assert.Equal(expected, listCodec.GetListValues(result));
    }
}