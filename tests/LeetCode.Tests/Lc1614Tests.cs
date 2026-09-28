using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1614Tests {
    public static TheoryData<string, int> Lc1614Data => new()
    {
        { "(1+(2*3)+((8)/4))+1", 3 },
    };
    
    [Theory]
    [MemberData(nameof(Lc1614Data))]
    public void Test_MaxDepth(string s, int expected) {
        // Arrange
        var solution = new Lc1614Solution();

        // Act
        var result = solution.MaxDepth(s);

        // Assert
        Assert.Equal(expected, result);
    }
}