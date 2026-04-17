using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3761Tests {
    public static TheoryData<int[], int> Lc3761Data => new()
    {
        // nums, expectedResult
        { [12,21,45,33,54], 1 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3761Data))]
    public void Test_MinMirrorPairDistance(int[] nums, int expected) {
        // Arrange
        var solution = new Lc3761Solution();

        // Act
        var result = solution.MinMirrorPairDistance(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}