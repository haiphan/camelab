namespace LeetCode.Library.Algorithms;

public class RangeMinMaxSparseTable
{
    private int[] lg = [];
    private int[] baseIdx = [];
    private int[] rowSize = [];
    private int[] stMin = [];
    private int[] stMax = [];

    public RangeMinMaxSparseTable(int[] arr)
    {
        int n = arr.Length;
        lg = new int[n + 1];
        for (int i = 2; i <= n; i++) lg[i] = lg[i >> 1] + 1;

        int levels = lg[n] + 1;
        baseIdx = new int[levels];
        rowSize = new int[levels];
        int totalSize = 0;
        for (int j = 0; j < levels; j++) {
            rowSize[j] = n - (1 << j) + 1;
            baseIdx[j] = totalSize;
            totalSize += rowSize[j];
        }
        stMin = new int[totalSize];
        stMax = new int[totalSize];
        Array.Copy(arr, 0, stMin, baseIdx[0], n);
        Array.Copy(arr, 0, stMax, baseIdx[0], n);

        for (int j = 1; j < levels; j++) {
            int len = 1 << j;
            int half = len >> 1;
            int size = rowSize[j];
            int curBase = baseIdx[j];
            int prevBase = baseIdx[j - 1];
            for (int i = 0; i < size; i++) {
                stMin[curBase + i] = Math.Min(stMin[prevBase + i], stMin[prevBase + i + half]);
                stMax[curBase + i] = Math.Max(stMax[prevBase + i], stMax[prevBase + i + half]);
            }
        }
    }
    public (int min, int max) Query(int ql, int qr) {
        int len = qr - ql + 1;
        int j = lg[len];
        int offset = qr - (1 << j) + 1;
        int b = baseIdx[j];
        int mn = Math.Min(stMin[b + ql], stMin[b + offset]);
        int mx = Math.Max(stMax[b + ql], stMax[b + offset]);
        return (mn, mx);
    }
}

public class Lc3691Solution {
    private readonly struct State {
        public readonly int Val;
        public readonly int L;
        public readonly int R;

        public State(int val, int l, int r) {
            Val = val;
            L = l;
            R = r;
        }
    }

    public long MaxTotalValue(int[] nums, int k) {
        int n = nums.Length;
        int iMin = 0, iMax = 0;
        for (int i = 0; i < n; i++) {
            if (nums[i] < nums[iMin]) iMin = i;
            if (nums[i] > nums[iMax]) iMax = i;
        }
        if (iMin == iMax) return 0;
        int v0 = nums[iMax] - nums[iMin];
        int l0 = iMin, r0 = iMax;
        if (l0 > r0) {
            int tmp = l0; l0 = r0; r0 = tmp;
        }
        long ways = (l0 + 1L) * (n - r0);
        if (ways >= k) {
            return (long)v0 * k;
        }
        long total = ways * v0;
        k -= (int)ways;
        // Keep only the best k initial ranges; k <= 100000 by constraints.
        var initMinHeap = new PriorityQueue<State, int>();
        RangeMinMaxSparseTable seg = new RangeMinMaxSparseTable(nums);
        for(int l=l0+1; l<n; l++){
            var (mn, mx) = seg.Query(l, n-1);
            int val = mx - mn;
            ConsiderInitial(val, l, n - 1);
        }
        void ConsiderInitial(int val, int l, int r) {
            if (val <= 0) return;
            var st = new State(val, l, r);
            if (initMinHeap.Count < k) {
                initMinHeap.Enqueue(st, val);
                return;
            }
            initMinHeap.TryPeek(out _, out int smallest);
            if (val > smallest) {
                initMinHeap.Dequeue();
                initMinHeap.Enqueue(st, val);
            }
        }
        for(int l=0; l<=l0; l++){
            var (mn, mx) = seg.Query(l, r0-1);
            int val = mx - mn;
            ConsiderInitial(val, l, r0 - 1);
        }
        // Max-heap by value for extraction of next best range.
        var pq = new PriorityQueue<State, int>();
        while (initMinHeap.Count > 0) {
            var st = initMinHeap.Dequeue();
            pq.Enqueue(st, -st.Val);
        }
        while (k > 0 && pq.Count > 0) {
            var st = pq.Dequeue();
            int x = st.Val, l = st.L, r = st.R;
            total += x;
            if (r > l) {
                var (mn, mx) = seg.Query(l, r - 1);
                int nextVal = mx - mn;
                if (nextVal > 0) {
                    pq.Enqueue(new State(nextVal, l, r - 1), -nextVal);
                }
            }
            k--;
        }
        return total;
    }
}