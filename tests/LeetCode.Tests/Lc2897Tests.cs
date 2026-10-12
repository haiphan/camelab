using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2897Tests {
    public static TheoryData<IList<int>, int, int> Lc2897Data => new()
    {
        // nums, k, expected
        { [2, 6, 5, 8], 2, 261}
    };
    
    [Theory]
    [MemberData(nameof(Lc2897Data))]
    public void Test_MaxSum(IList<int> nums, int k, int expected) {
        // Arrange
        var solution = new Lc2897Solution();

        // Act
        var result = solution.MaxSum(nums, k);

        // Assert
        Assert.Equal(expected, result);
    }
}