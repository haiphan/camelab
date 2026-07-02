using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3286Tests {
    public static TheoryData<IList<IList<int>>, int, bool> Lc3286Data => new()
    {
        // grid, health
        {[[0,1,0,0,0],[0,1,0,1,0],[0,0,0,1,0]], 1, true}
    };
    
    [Theory]
    [MemberData(nameof(Lc3286Data))]
    public void Test_FindSafeWalk(IList<IList<int>> grid, int health, bool expected) {
        // Arrange
        var solution = new Lc3286Solution();

        // Act
        var result = solution.FindSafeWalk(grid, health);

        // Assert
        Assert.Equal(expected, result);
    }
}