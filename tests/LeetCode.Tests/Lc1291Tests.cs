using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1291Tests {
    public static TheoryData<int, int, IList<int>> Lc1291Data => new()
    {
        // low, high, expected
        { 100, 300, [123, 234] },
        { 1000, 13000, [1234, 2345, 3456, 4567, 5678, 6789, 12345] }
    };
    
    [Theory]
    [MemberData(nameof(Lc1291Data))]
    public void Test_SequentialDigits(int low, int high, IList<int> expected) {
        // Arrange
        var solution = new Lc1291Solution();

        // Act
        var result = solution.SequentialDigits(low, high);

        // Assert
        Assert.Equal(expected, result);
    }
}