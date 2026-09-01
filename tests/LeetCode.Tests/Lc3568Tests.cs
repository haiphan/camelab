using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3568Tests {
    public static TheoryData<string[], int, int> Lc3568Data => new()
    {
        // classroom, energy, expected
        { ["S.", "XL"], 2, 2 },
        { ["LS", "RL"], 4, 3 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3568Data))]
    public void Test_MinMoves(string[] classroom, int energy, int expected) {
        // Arrange
        var solution = new Lc3568Solution();

        // Act
        var result = solution.MinMoves(classroom, energy);

        // Assert
        Assert.Equal(expected, result);
    }
}