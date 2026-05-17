using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1306Tests {
    public static TheoryData<int[], int, bool> Lc1306Data => new()
    {
        // arr, start, expectedResult
        { [4,2,3,0,3,1,2], 5, true },
    };
    
    [Theory]
    [MemberData(nameof(Lc1306Data))]
    public void Test_CanReach(int[] arr, int start, bool expected) {
        // Arrange
        var solution = new Lc1306Solution();

        // Act
        var result = solution.CanReach(arr, start);

        // Assert
        Assert.Equal(expected, result);
    }
}