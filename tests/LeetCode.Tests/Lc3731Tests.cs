using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3731Tests {
    public static TheoryData<int[], IList<int>> Lc3731Data => new()
    {
        // nums, expected
        {[1,4,2,5], new List<int> {3}},
    };
    
    [Theory]
    [MemberData(nameof(Lc3731Data))]
    public void Test_FindMissingElements(int[] nums, IList<int> expected) {
        // Arrange
        var solution = new Lc3731Solution();

        // Act
        var result = solution.FindMissingElements(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}