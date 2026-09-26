using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1807Tests {
    public static TheoryData<string, IList<IList<string>>, string> Lc1807Data => new()
    {
        // s, knowledge, expected
        {"(name)is(age)yearsold", [["name","bob"],["age","two"]], "bobistwoyearsold"}
    };
    
    [Theory]
    [MemberData(nameof(Lc1807Data))]
    public void Test_Evaluate(string s, IList<IList<string>> knowledge, string expected) {
        // Arrange
        var solution = new Lc1807Solution();

        // Act
        var result = solution.Evaluate(s, knowledge);

        // Assert
        Assert.Equal(expected, result);
    }
}