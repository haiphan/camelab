namespace LeetCode.Library.Algorithms;

public class Lc3501Solution {
    public IList<int> MaxActiveSectionsAfterTrade(string s, int[][] queries) {
        int n = s.Length;
        int totalOnes = 0;
        foreach (char c in s) {
            totalOnes += c - '0';
        }

        List<int> starts = new List<int>();
        List<int> ends = new List<int>();
        List<char> chars = new List<char>();
        int[] runId = new int[n];

        int runCount = 0;
        int i = 0;
        while (i < n) {
            int start = i;
            char ch = s[i];
            while (i + 1 < n && s[i + 1] == ch) {
                i++;
            }

            int end = i;
            starts.Add(start);
            ends.Add(end);
            chars.Add(ch);
            for (int p = start; p <= end; p++) {
                runId[p] = runCount;
            }

            runCount++;
            i++;
        }

        int[] gainByRun = new int[runCount];
        for (int r = 1; r + 1 < runCount; r++) {
            if (chars[r] != '1' || chars[r - 1] != '0' || chars[r + 1] != '0') {
                continue;
            }

            int leftLen = ends[r - 1] - starts[r - 1] + 1;
            int rightLen = ends[r + 1] - starts[r + 1] + 1;
            gainByRun[r] = leftLen + rightLen;
        }

        SegmentTreeMax seg = new SegmentTreeMax(gainByRun);

        List<int> ans = new List<int>(queries.Length);
        foreach (int[] query in queries) {
            int l = query[0];
            int r = query[1];
            int leftRun = runId[l];
            int rightRun = runId[r];

            int bestGain = 0;

            // Fully-contained candidates can use precomputed gains directly.
            int interiorLeft = leftRun + 2;
            int interiorRight = rightRun - 2;
            if (interiorLeft <= interiorRight) {
                bestGain = Math.Max(bestGain, seg.Query(interiorLeft, interiorRight));
            }

            // Boundary-adjacent candidates may have clipped zero-run lengths.
            int leftEdgeCandidate = leftRun + 1;
            bestGain = Math.Max(bestGain, EvaluateCandidate(leftEdgeCandidate, l, r, starts, ends, chars));

            int rightEdgeCandidate = rightRun - 1;
            if (rightEdgeCandidate != leftEdgeCandidate) {
                bestGain = Math.Max(bestGain, EvaluateCandidate(rightEdgeCandidate, l, r, starts, ends, chars));
            }

            ans.Add(totalOnes + bestGain);
        }

        return ans;
    }

    private static int EvaluateCandidate(
        int oneRun,
        int l,
        int r,
        List<int> starts,
        List<int> ends,
        List<char> chars
    ) {
        int runCount = starts.Count;
        if (oneRun <= 0 || oneRun + 1 >= runCount) {
            return 0;
        }

        if (chars[oneRun] != '1' || chars[oneRun - 1] != '0' || chars[oneRun + 1] != '0') {
            return 0;
        }

        int leftAvailable = ends[oneRun - 1] - Math.Max(l, starts[oneRun - 1]) + 1;
        if (leftAvailable <= 0) {
            return 0;
        }

        int rightAvailable = Math.Min(r, ends[oneRun + 1]) - starts[oneRun + 1] + 1;
        if (rightAvailable <= 0) {
            return 0;
        }

        return leftAvailable + rightAvailable;
    }

    private sealed class SegmentTreeMax {
        private readonly int size;
        private readonly int[] tree;

        public SegmentTreeMax(int[] values) {
            int n = values.Length;
            size = 1;
            while (size < n) {
                size <<= 1;
            }

            tree = new int[size << 1];
            for (int i = 0; i < n; i++) {
                tree[size + i] = values[i];
            }

            for (int i = size - 1; i > 0; i--) {
                tree[i] = Math.Max(tree[i << 1], tree[(i << 1) | 1]);
            }
        }

        public int Query(int left, int right) {
            left += size;
            right += size;
            int res = 0;

            while (left <= right) {
                if ((left & 1) == 1) {
                    res = Math.Max(res, tree[left]);
                    left++;
                }
                if ((right & 1) == 0) {
                    res = Math.Max(res, tree[right]);
                    right--;
                }
                left >>= 1;
                right >>= 1;
            }

            return res;
        }
    }
}