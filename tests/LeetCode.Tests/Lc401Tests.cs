using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc401Tests {
    public static TheoryData<int, IList<string>> Lc401Data => new()
    {
        // turnedOn, expectedResult
        { 1, ["0:01", "0:02", "0:04", "0:08", "0:16", "0:32", "1:00", "2:00", "4:00", "8:00"] },
    };
    
    [Theory]
    [MemberData(nameof(Lc401Data))]
    public void Test_ReadBinaryWatch(int turnedOn, IList<string> expected) {
        // Arrange
        var solution = new Lc401Solution();

        // Act
        var result = solution.ReadBinaryWatch(turnedOn);

        // Assert
        Assert.Equal(expected, result);
    }
}