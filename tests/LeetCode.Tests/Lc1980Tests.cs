using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1980Tests {
    public static TheoryData<string[]> Lc1980Data => new()
    {
        // nums
        { ["00","01"] },
        { ["111","011","001"] },
    };
    
    [Theory]
    [MemberData(nameof(Lc1980Data))]
    public void Test_FindDifferentBinaryString(string[] nums) {
        // Arrange
        var solution = new Lc1980Solution();

        // Act
        var result = solution.FindDifferentBinaryString(nums);

        // check result is different from all nums
        Assert.All(nums, num => Assert.NotEqual(num, result));
    }
}