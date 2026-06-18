using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1344Tests {
    public static TheoryData<int, int, double> Lc1344Data => new()
    {
        { 12, 30, 165.0 },
    };
    
    [Theory]
    [MemberData(nameof(Lc1344Data))]
    public void Test_AngleClock(int hour, int minutes, double expected) {
        // Arrange
        var solution = new Lc1344Solution();

        // Act
        var result = solution.AngleClock(hour, minutes);
        double epsilon = 1e-6;
        Assert.InRange(result, expected - epsilon, expected + epsilon);
    }
}