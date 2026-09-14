using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc836Tests {
    public static TheoryData<int[], int[], bool> Lc836Data => new()
    {
        // rec1, rec2, expected
        { [0,0,2,2], [1,1,3,3], true }
    };
    
    [Theory]
    [MemberData(nameof(Lc836Data))]
    public void Test_IsRectangleOverlap(int[] rec1, int[] rec2, bool expected) {
        // Arrange
        var solution = new Lc836Solution();

        // Act
        var result = solution.IsRectangleOverlap(rec1, rec2);

        // Assert
        Assert.Equal(expected, result);
    }
}