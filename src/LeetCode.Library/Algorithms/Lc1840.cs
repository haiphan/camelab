namespace LeetCode.Library.Algorithms;

public class Lc1840Solution {
    public int MaxBuilding(int n, int[][] restrictions) {
        int rl = restrictions.Length;
        if (rl == 0) {
            return n - 1;
        }
        Array.Sort(restrictions, (a, b) => a[0].CompareTo(b[0]));
        int yCap(int x1, int y1, int x2, int y2)
        {
            return Math.Min(y2, y1 + Math.Abs(x2 - x1));
        }
        int yPeak(int x1, int y1, int x2, int y2)
        {
            return (y1 + y2 + Math.Abs(x2 - x1)) >> 1;
        }
        restrictions[0][1] = yCap(1, 0, restrictions[0][0], restrictions[0][1]);
        for (int i = 1; i < rl; ++i)
        {
            restrictions[i][1] = yCap(restrictions[i - 1][0], restrictions[i - 1][1], restrictions[i][0], restrictions[i][1]);
        }
        int ans = yPeak(1, 0, restrictions[0][0], restrictions[0][1]);
        for (int i = rl - 2; i >= 0; --i)
        {
            restrictions[i][1] = yCap(restrictions[i + 1][0], restrictions[i + 1][1], restrictions[i][0], restrictions[i][1]);
            ans = Math.Max(ans, yPeak(restrictions[i][0], restrictions[i][1], restrictions[i + 1][0], restrictions[i + 1][1]));
        }
        ans = Math.Max(ans, restrictions[rl - 1][1] + n - restrictions[rl - 1][0]);
        return ans;
    }
}