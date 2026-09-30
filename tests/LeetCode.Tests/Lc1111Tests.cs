using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1111Tests {
    public static TheoryData<string, int[]> Lc1111Data => new()
    {
        // seq, expected
        {"(()())", [0,1,1,1,1,0]}
    };
    
    [Theory]
    [MemberData(nameof(Lc1111Data))]
    public void Test_MaxDepthAfterSplit(string seq, int[] expected) {
        int SplitScore(string seq, int[] split)
        {
            int scoreA = 0, scoreB = 0, depth = 0;
            for (int i = 0; i < seq.Length; i++)
            {
                if (seq[i] == '(')
                {
                    depth++;
                }

                if (split[i] == 0)
                {
                    scoreA = Math.Max(scoreA, depth);
                }
                else
                {
                    scoreB = Math.Max(scoreB, depth);
                }

                if (seq[i] == ')')
                {
                    depth--;
                }
            }
            return Math.Max(scoreA, scoreB);
        }
        // Arrange
        var solution = new Lc1111Solution();

        // Act
        var result = solution.MaxDepthAfterSplit(seq);

        // Assert
        Assert.Equal(SplitScore(seq, expected), SplitScore(seq, result));
    }

}