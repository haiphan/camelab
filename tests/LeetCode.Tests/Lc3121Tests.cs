using LeetCode.Library.Algorithms;
using System.Diagnostics;
using Xunit;

namespace LeetCode.Tests;

public class Lc3121Tests {
    public static TheoryData<string, int> Lc3121Data => new()
    {
        // word, expectedResult
        { "aaAbcBC", 3 },
        { "AbBCab", 0 },
        { "aAa", 0 },
    };
    
    [Theory]
    [MemberData(nameof(Lc3121Data))]
    public void Test_NumberOfSpecialChars(string word, int expected) {
        // Arrange
        var solution = new Lc3121Solution();

        // Act
        var result = solution.NumberOfSpecialChars(word);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    [Trait("Category", "Benchmark")]
    public void Benchmark_NumberOfSpecialChars_CompareImplementations() {
        var random = new Random(3121);
        var samples = new string[300];
        for (int i = 0; i < samples.Length; i++) {
            samples[i] = CreateRandomWord(random, 2000);
        }

        var solution = new Lc3121Solution();

        // Warm up JIT for both implementations.
        for (int i = 0; i < 2; i++) {
            foreach (string word in samples) {
                _ = solution.NumberOfSpecialChars(word);
                _ = PreviousBranchlessArrayVersion(word);
            }
        }

        var swCurrent = Stopwatch.StartNew();
        int checksumCurrent = 0;
        for (int round = 0; round < 6; round++) {
            foreach (string word in samples) {
                checksumCurrent += solution.NumberOfSpecialChars(word);
            }
        }
        swCurrent.Stop();

        var swPrevious = Stopwatch.StartNew();
        int checksumPrevious = 0;
        for (int round = 0; round < 6; round++) {
            foreach (string word in samples) {
                checksumPrevious += PreviousBranchlessArrayVersion(word);
            }
        }
        swPrevious.Stop();

        Assert.Equal(checksumPrevious, checksumCurrent);
        Console.WriteLine($"Lc3121 benchmark (ms) current={swCurrent.ElapsedMilliseconds}, previous={swPrevious.ElapsedMilliseconds}");
    }

    private static string CreateRandomWord(Random random, int length) {
        char[] chars = new char[length];
        for (int i = 0; i < length; i++) {
            int letter = random.Next(26);
            bool isUpper = random.Next(2) == 0;
            chars[i] = (char)((isUpper ? 'A' : 'a') + letter);
        }
        return new string(chars);
    }

    private static int PreviousBranchlessArrayVersion(string word) {
        int[] masks = new int[2];

        foreach (char c in word) {
            int code = c & 31;
            int ci = (c >> 5) & 1;
            int bit = 1 << code;
            int upperSeen = (masks[0] >> code) & 1;
            int value = 1 ^ (ci & upperSeen);

            masks[ci] = (masks[ci] & ~bit) | (value << code);
        }

        int specialMask = masks[0] & masks[1];
        return System.Numerics.BitOperations.PopCount((uint)specialMask);
    }
}