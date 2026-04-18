using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3783Tests {
    public static TheoryData<int, int> Lc3783Data => new()
    {
        // n, expectedResult
        { 25, 27 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3783Data))]
    public void Test_MirrorDistance(int n, int expected) {
        // Arrange
        var solution = new Lc3783Solution();

        // Act
        var result = solution.MirrorDistance(n);

        // Assert
        Assert.Equal(expected, result);
    }
}