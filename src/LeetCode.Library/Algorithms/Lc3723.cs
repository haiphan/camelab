namespace LeetCode.Library.Algorithms;

public class Lc3723Solution {
    public string MaxSumOfSquares(int num, int sum) {
        // Impossible if the digits can't add up to the target sum
        if (sum < 0 || sum > 9 * num)
        {
            return "";
        }
        char[] chars = new char[num];
        int nineCount = Math.Min(sum / 9, num);
        int remainder = sum - nineCount * 9;
        int rc = remainder > 0 ? 1 : 0;

        // Write directly into the string's buffer, no intermediate char[] copy
        return string.Create(num, (nineCount, remainder, rc), static (span, state) => {
            var (nineCount, remainder, rc) = state;
            span[..nineCount].Fill('9');
            if (remainder > 0)
            {
                span[nineCount] = (char)('0' + remainder);
            }
            span[(nineCount + rc)..].Fill('0');
        });
    }
}