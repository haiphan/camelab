using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc3886Tests {
    public static TheoryData<int[], int> Lc3886Data => new()
    {
        // nums, expected
        { [3,1,2], 3 }
    };
    
    [Theory]
    [MemberData(nameof(Lc3886Data))]
    public void Test_SortableIntegers(int[] nums, int expected) {
        // Arrange
        var solution = new Lc3886Solution();

        // Act
        var result = solution.SortableIntegers(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}