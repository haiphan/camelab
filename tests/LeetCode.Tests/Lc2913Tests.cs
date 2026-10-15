using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2913Tests {
    public static TheoryData<IList<int>, int> Lc2913Data => new()
    {
        // nums, expected
        { [1,2,1], 15 }
    };
    
    [Theory]
    [MemberData(nameof(Lc2913Data))]
    public void Test_SumCounts(IList<int> nums, int expected) {
        // Arrange
        var solution = new Lc2913Solution();

        // Act
        var result = solution.SumCounts(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}