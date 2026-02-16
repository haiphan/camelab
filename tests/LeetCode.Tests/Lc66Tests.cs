using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc66Tests {
    public static TheoryData<int[], int[]> Lc66Data => new()
    {
        // digits, expectedResult
        { [1,2,3], [1,2,4] },
        { [4,3,2,1], [4,3,2,2] },
        { [9], [1,0] },
        { [9,9], [1,0,0] },
    };
    
    [Theory]
    [MemberData(nameof(Lc66Data))]
    public void Test_plusOne(int[] digits, int[] expected) {
        // Arrange
        var solution = new Lc66Solution();

        // Act
        var result = solution.PlusOne(digits);

        // Assert
        Assert.Equal(expected, result);
    }
}