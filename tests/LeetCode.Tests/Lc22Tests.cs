using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc22Tests {
    public static TheoryData<int, IList<string>> Lc22Data => new()
    {
        // n, expected
        { 3, ["((()))","(()())","(())()","()(())","()()()"]}
    };
    
    [Theory]
    [MemberData(nameof(Lc22Data))]
    public void Test_GenerateParenthesis(int n, IList<string> expected) {
        // Arrange
        var solution = new Lc22Solution();

        // Act
        var result = solution.GenerateParenthesis(n);

        // Assert
        Assert.Equal(expected, result);
    }
}