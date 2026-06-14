using LeetCode.Library.Algorithms;
using LeetCode.Library.DataStructures;
using Xunit;

namespace LeetCode.Tests;

public class Lc2130Tests {
    public static TheoryData<int[], int> Lc2130Data => new()
    {
        // head, expected
        {[5,4,2,1], 6},
        {[1,100000], 100001}
    };
    
    [Theory]
    [MemberData(nameof(Lc2130Data))]
    public void Test_PairSum(int[] head, int expected) {
        // Arrange
        var solution = new Lc2130Solution();
        ListCodec listCodec = new ListCodec();
        // Act
        var result = solution.PairSum(listCodec.CreateList(head));

        // Assert
        Assert.Equal(expected, result);
    }
}