using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1524Tests {
    public static TheoryData<int[], int> Lc1524Data => new()
    {
        // arr, expected
        {[1,3,5], 4}
    };
    
    [Theory]
    [MemberData(nameof(Lc1524Data))]
    public void Test_NumOfSubarrays(int[] arr, int expected) {
        // Arrange
        var solution = new Lc1524Solution();

        // Act
        var result = solution.NumOfSubarrays(arr);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Test_NumOfSubarrays_DoesNotOverflowForLargeInput() {
        // Arrange: a max-length array (n = 100,000) alternating odd/even values so that
        // oddCount ends up at 50,000, which previously made oddCount * (n - oddCount)
        // overflow Int32 before the modulo was applied.
        const int n = 100_000;
        var arr = new int[n];
        for (int i = 0; i < n; i++) {
            arr[i] = i % 2 == 0 ? 1 : 2;
        }
        var solution = new Lc1524Solution();

        // Act
        var result = solution.NumOfSubarrays(arr);

        // Assert
        Assert.Equal(500_049_986, result);
    }
}