namespace LeetCode.Library.Algorithms;

public class Lc3161Solution {
    private int _MAXX = 50000;
    public int[] _seg = [];
    private int[] _bit = [];

    private void _BitAdd(int idx, int delta) {
        int n = _bit.Length;
        while (idx < n) {
            _bit[idx] += delta;
            idx += idx & -idx;
        }
    }

    private int _BitSum(int idx) {
        int sum = 0;
        while (idx > 0) {
            sum += _bit[idx];
            idx -= idx & -idx;
        }
        return sum;
    }

    // Returns the smallest 1-based index i such that prefixSum(i) >= k.
    private int _BitFindByOrder(int k) {
        int idx = 0;
        int bitMask = 1;
        while ((bitMask << 1) < _bit.Length) {
            bitMask <<= 1;
        }
        while (bitMask > 0) {
            int next = idx + bitMask;
            if (next < _bit.Length && _bit[next] < k) {
                k -= _bit[next];
                idx = next;
            }
            bitMask >>= 1;
        }
        return idx + 1;
    }

    private int _PrefixCountByCoord(int coord) {
        if (coord < 0) {
            return 0;
        }
        if (coord > _MAXX) {
            coord = _MAXX;
        }
        return _BitSum(coord + 1);
    }

    private void _Update(int node, int l, int r, int idx, int val) {
        if (l == r) {
            _seg[node] = val;
            return;
        }
        int mid = (l + r) >> 1;
        if (idx <= mid) {
            _Update(node << 1, l, mid, idx, val);
        } else {
            _Update((node << 1) | 1, mid + 1, r, idx, val);
        }
        _seg[node] = Math.Max(_seg[node << 1], _seg[(node << 1) | 1]);
    }
    private int _Query(int node, int l, int r, int ql, int qr) {
        if (ql > r || qr < l) {
            return 0;
        }
        if (ql <= l && r <= qr) {
            return _seg[node];
        }
        int mid = (l + r) >> 1;
        return Math.Max(_Query(node << 1, l, mid, ql, qr), _Query((node << 1) | 1, mid + 1, r, ql, qr));
    }
    public IList<bool> GetResults(int[][] queries) {
        int maxX = 0;
        foreach (int[] q in queries) {
            if (q[1] > maxX) {
                maxX = q[1];
            }
        }
        _MAXX = maxX;

        _seg = new int[(_MAXX + 1) * 4];
        _bit = new int[_MAXX + 3];

        HashSet<int> obstacles = new();
        obstacles.Add(0);
        foreach (int[] q in queries) {
            int op = q[0], x = q[1];
            if (op == 1) {
                obstacles.Add(x);
            }
        }

        List<int> pos = obstacles.ToList();
        pos.Sort();
        foreach (int p in pos) {
            _BitAdd(p + 1, 1);
        }

        for (int i = 1; i < pos.Count; i++) {
            _Update(1, 0, _MAXX, pos[i], pos[i] - pos[i - 1]);
        }

        int getFloor(int x) {
            int k = _PrefixCountByCoord(x);
            return k == 0 ? 0 : _BitFindByOrder(k) - 1;
        }

        int getLower(int x) {
            int k = _PrefixCountByCoord(x - 1);
            return k == 0 ? 0 : _BitFindByOrder(k) - 1;
        }

        int getHigher(int x) {
            int total = _PrefixCountByCoord(_MAXX);
            int k = _PrefixCountByCoord(x) + 1;
            return k > total ? _MAXX : _BitFindByOrder(k) - 1;
        }

        List<bool> ans = new();
        for (int i = queries.Length - 1; i >= 0; i--) {
            int op = queries[i][0], x = queries[i][1];
            if (op == 2) {
                int sz = queries[i][2];
                // find an obstacle just less than x. use the sorted set
                int prevObstacle = getFloor(x);
                int best = _Query(1, 0, _MAXX, 0, x);
                best = Math.Max(best, x - prevObstacle);
                ans.Add(best >= sz);
            } else {
                int lPos = getLower(x);
                _Update(1, 0, _MAXX, x, 0);
                int rPos = getHigher(x);
                _Update(1, 0, _MAXX, rPos, rPos - lPos);
                _BitAdd(x + 1, -1);
            }
        }
        ans.Reverse();
        return ans;
    }
}