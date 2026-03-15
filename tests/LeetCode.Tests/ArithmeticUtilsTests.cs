using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class ArithmeticUtilsTests {
    [Theory]
    [InlineData(2, 10, 1000, 24)]
    [InlineData(-2, 3, 5, 2)]
    [InlineData(7, 0, 13, 1)]
    public void PowMod_Works(int a, int b, int m, int expected) {
        int result = ArithmeticUtils.PowMod(a, b, m);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(54, 24, 6)]
    [InlineData(-42, 56, 14)]
    public void Gcd_Works(int a, int b, int expected) {
        int result = ArithmeticUtils.Gcd(a, b);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(12, 18, 36)]
    [InlineData(0, 18, 0)]
    public void Lcm_Works(int a, int b, long expected) {
        long result = ArithmeticUtils.Lcm(a, b);
        Assert.Equal(expected, result);
    }
}
