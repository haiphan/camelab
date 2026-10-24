using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2409Tests {
    public static TheoryData<string, string, string, string, int> Lc2409Data => new()
    {
        { "08-15", "08-18", "08-16", "08-19", 3 },
    };
    
    [Theory]
    [MemberData(nameof(Lc2409Data))]
    public void Test_CountDaysTogether(string arriveAlice, string leaveAlice, string arriveBob, string leaveBob, int expected) {
        // Arrange
        var solution = new Lc2409Solution();

        // Act
        var result = solution.CountDaysTogether(arriveAlice, leaveAlice, arriveBob, leaveBob);

        // Assert
        Assert.Equal(expected, result);
    }
}