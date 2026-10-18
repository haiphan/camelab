using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1569Tests {
    public static TheoryData<int[], int> Lc1569Data => new()
    {
        // nums, expected
        {[2, 1, 3], 1},
        {[31,23,14,24,15,12,25,28,5,35,17,6,9,11,1,27,18,20,2,3,33,10,13,4,7,36,32,29,8,30,26,19,34,22,21,16], 936157466}
    };
    
    [Theory]
    [MemberData(nameof(Lc1569Data))]
    public void Test_NumOfWays(int[] nums, int expected) {
        // Arrange
        var solution = new Lc1569Solution();

        // Act
        var result = solution.NumOfWays(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}