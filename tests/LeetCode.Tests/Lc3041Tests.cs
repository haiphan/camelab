using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3041Tests {
    public static TheoryData<int[], int> Lc3041Data => new()
    {
        // nums, expected
        { [2,1,5,1,1], 3 }
    };
    
    [Theory]
    [MemberData(nameof(Lc3041Data))]
    public void Test_MaxSelectedElements(int[] nums, int expected) {
        // Arrange
        var solution = new Lc3041Solution();

        // Act
        var result = solution.MaxSelectedElements(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}