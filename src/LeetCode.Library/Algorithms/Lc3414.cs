namespace LeetCode.Library.Algorithms;

public class Lc3414Solution {
    public int[] MaximumWeight(IList<IList<int>> intervals) {
        var n = intervals.Count;
        var order = new int[n];
        for (var i = 0; i < n; i++) order[i] = i;
        Array.Sort(order, (a, b) => intervals[a][1] != intervals[b][1] ? intervals[a][1] - intervals[b][1] : a - b);

        var ends = new int[n];
        for (var i = 0; i < n; i++) ends[i] = intervals[order[i]][1];

        // dp[i][j]: best (score, packed indices) using at most j of the first i intervals (sorted by end).
        var dp = new SelectionState[n + 1][];
        dp[0] = new SelectionState[5];

        for (var i = 1; i <= n; i++) {
            var origIndex = order[i - 1];
            var l = intervals[origIndex][0];
            var w = intervals[origIndex][2];
            // p = count of prior intervals whose end is strictly before this interval's start.
            var p = LowerBound(ends, l);

            var row = new SelectionState[5];
            var prevRow = dp[i - 1];
            var pRow = dp[p];
            for (var j = 0; j <= 4; j++) {
                var best = prevRow[j];
                if (j >= 1) {
                    var prev = pRow[j - 1];
                    var candidate = new SelectionState(prev.Score + w, InsertSorted(prev.Key, origIndex));
                    if (IsBetter(candidate, best)) best = candidate;
                }
                row[j] = best;
            }
            dp[i] = row;
        }

        return Decode(dp[n][4].Key);
    }

    // Higher score wins; ties broken by the smaller packed key (lexicographically smaller index list).
    private static bool IsBetter(SelectionState a, SelectionState b) {
        return a.Score != b.Score ? a.Score > b.Score : a.Key < b.Key;
    }

    // Packs up to 4 ascending indices (each +1, so 0 means "empty") into 16-bit slots of a ulong.
    private static ulong InsertSorted(ulong key, int value) {
        Span<int> slots = stackalloc int[4];
        var count = 0;
        for (var shift = 48; shift >= 0; shift -= 16) {
            var slot = (int)((key >> shift) & 0xFFFF);
            if (slot != 0) slots[count++] = slot;
        }

        var v = value + 1;
        var insertPos = count;
        while (insertPos > 0 && slots[insertPos - 1] > v) {
            slots[insertPos] = slots[insertPos - 1];
            insertPos--;
        }
        slots[insertPos] = v;
        count++;

        var newKey = 0UL;
        for (var i = 0; i < count; i++) {
            newKey |= (ulong)slots[i] << (48 - 16 * i);
        }
        return newKey;
    }

    private static int[] Decode(ulong key) {
        Span<int> buffer = stackalloc int[4];
        var count = 0;
        for (var shift = 48; shift >= 0; shift -= 16) {
            var slot = (int)((key >> shift) & 0xFFFF);
            if (slot != 0) buffer[count++] = slot - 1;
        }
        return buffer[..count].ToArray();
    }

    private static int LowerBound(int[] sortedEnds, int value) {
        var lo = 0;
        var hi = sortedEnds.Length;
        while (lo < hi) {
            var mid = (lo + hi) / 2;
            if (sortedEnds[mid] < value) lo = mid + 1;
            else hi = mid;
        }
        return lo;
    }

    private readonly struct SelectionState(long score, ulong key) {
        public long Score { get; } = score;
        public ulong Key { get; } = key;
    }
}

