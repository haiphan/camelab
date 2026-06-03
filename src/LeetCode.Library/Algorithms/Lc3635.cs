namespace LeetCode.Library.Algorithms;

public class Lc3635Solution {
    public int EarliestFinishTime(int[] landStartTime, int[] landDuration, int[] waterStartTime, int[] waterDuration) {
        int BIG = 100000 * 3;
        int minL = BIG, minW = BIG, res = BIG;
        int n = landStartTime.Length;
        int m = waterStartTime.Length;

        for (int i = 0; i < n; i++)
        {
            minL = Math.Min(minL, landStartTime[i] + landDuration[i]);
        }

        for (int i = 0; i < m; i++) {
            minW = Math.Min(minW, waterStartTime[i] + waterDuration[i]);
            res = Math.Min(res, Math.Max(minL, waterStartTime[i]) + waterDuration[i]);
        }

        for (int i = 0; i < n; i++)
        {
            res = Math.Min(res, Math.Max(minW, landStartTime[i]) + landDuration[i]);
        }

        return res;
    }
}