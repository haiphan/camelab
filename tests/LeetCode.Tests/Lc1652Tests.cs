using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1652Tests {
    public static TheoryData<int[], int, int[]> Lc1652Data => new()
    {
        // code, k, expectedResult
        { [5,7,1,4], 3, [12,10,16,13] },
    };
    
    [Theory]
    [MemberData(nameof(Lc1652Data))]
    public void Test_Decrypt(int[] code, int k, int[] expected) {
        // Arrange
        var solution = new Lc1652Solution();

        // Act
        var result = solution.Decrypt(code, k);

        // Assert
        Assert.Equal(expected, result);
    }
}