namespace LeetCode.Library.Algorithms;

public class Lc3841Solution {
    private int[] fenwick = [];
    private int fenwickSize;

    private void FenwickUpdate(int pos, int val) {
        for (; pos <= fenwickSize; pos += pos & -pos)
        {
            fenwick[pos] ^= val;
        }
    }

    private int FenwickPrefixXor(int pos) {
        int res = 0;
        for (; pos > 0; pos -= pos & -pos)
        {
            res ^= fenwick[pos];
        }
        return res;
    }

    public IList<bool> PalindromePath(int n, int[][] edges, string s, string[] queries) {
        // CSR adjacency: avoids n separate List<int> allocations, better cache locality.
        int[] degree = new int[n];
        foreach (int[] e in edges)
        {
            degree[e[0]]++;
            degree[e[1]]++;
        }
        int[] adjStart = new int[n + 1];
        for (int i = 0; i < n; i++)
        {
            adjStart[i + 1] = adjStart[i] + degree[i];
        }
        int[] adjList = new int[edges.Length * 2];
        int[] insertPos = (int[])adjStart.Clone();
        foreach (int[] e in edges)
        {
            adjList[insertPos[e[0]]++] = e[1];
            adjList[insertPos[e[1]]++] = e[0];
        }

        // Iterative Euler tour (avoids recursion-depth risk on skewed trees up to n=5e4).
        int[] parent = new int[n];
        int[] depth = new int[n];
        int[] tin = new int[n];
        int[] tout = new int[n];
        int[] iter = new int[n];
        int[] stack = new int[n];
        int top = 0;
        int timer = 0;
        parent[0] = 0;
        tin[0] = timer++;
        stack[top++] = 0;
        while (top > 0)
        {
            int u = stack[top - 1];
            int uStart = adjStart[u];
            int uEnd = adjStart[u + 1];
            if (uStart + iter[u] < uEnd)
            {
                int v = adjList[uStart + iter[u]++];
                if (v == parent[u] && u != 0)
                {
                    continue;
                }

                parent[v] = u;
                depth[v] = depth[u] + 1;
                tin[v] = timer++;
                stack[top++] = v;
            }
            else
            {
                tout[u] = timer - 1;
                top--;
            }
        }

        int log = 1;
        while ((1 << log) < n)
        {
            log++;
        }
        log++;
        int[][] up = new int[log][];
        up[0] = parent;
        for (int i = 1; i < log; i++)
        {
            up[i] = new int[n];
            int[] prev = up[i - 1];
            int[] cur = up[i];
            for (int v = 0; v < n; v++)
            {
                cur[v] = prev[prev[v]];
            }
        }

        int Lca(int u, int v) {
            if (depth[u] < depth[v])
            {
                (u, v) = (v, u);
            }
            int diff = depth[u] - depth[v];
            for (int i = 0; i < log; i++)
            {
                if (((diff >> i) & 1) == 1)
                {
                    u = up[i][u];
                }
            }
            if (u == v)
            {
                return u;
            }
            for (int i = log - 1; i >= 0; i--)
            {
                if (up[i][u] != up[i][v])
                {
                    u = up[i][u];
                    v = up[i][v];
                }
            }
            return parent[u];
        }

        // Fenwick over Euler tour: XOR mask added at tin[v] and cancelled at tout[v]+1,
        // so prefix XOR up to tin[v] equals the XOR of masks on the root-to-v path.
        char[] curChar = s.ToCharArray();
        fenwickSize = n + 2;
        fenwick = new int[fenwickSize + 1];
        for (int v = 0; v < n; v++)
        {
            int mask = 1 << (curChar[v] - 'a');
            FenwickUpdate(tin[v] + 1, mask);
            FenwickUpdate(tout[v] + 2, mask);
        }

        List<bool> ans = [];
        foreach (string query in queries)
        {
            ReadOnlySpan<char> span = query.AsSpan();
            char kind = span[0];
            int sp1 = span.IndexOf(' ');
            ReadOnlySpan<char> rest = span[(sp1 + 1)..];
            int sp2 = rest.IndexOf(' ');
            int u = int.Parse(rest[..sp2]);
            ReadOnlySpan<char> arg2 = rest[(sp2 + 1)..];
            if (kind == 'u')
            {
                char c = arg2[0];
                if (curChar[u] != c)
                {
                    int diff = (1 << (curChar[u] - 'a')) ^ (1 << (c - 'a'));
                    FenwickUpdate(tin[u] + 1, diff);
                    FenwickUpdate(tout[u] + 2, diff);
                    curChar[u] = c;
                }
            }
            else
            {
                int v = int.Parse(arg2);
                int lca = Lca(u, v);
                int xorVal = FenwickPrefixXor(tin[u] + 1) ^ FenwickPrefixXor(tin[v] + 1) ^ (1 << (curChar[lca] - 'a'));
                ans.Add(System.Numerics.BitOperations.PopCount((uint)xorVal) <= 1);
            }
        }
        return ans;
    }
}
