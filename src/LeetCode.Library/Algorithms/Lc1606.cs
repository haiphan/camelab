namespace LeetCode.Library.Algorithms;

public class Lc1606Solution {
    public IList<int> BusiestServers(int k, int[] arrival, int[] load) {
        int n = arrival.Length;
        int[] handled = new int[k];

        // Fenwick tree over a free/busy bitmap: supports O(log k) toggle + "k-th free server"
        // order-statistics query, avoiding SortedSet's ambiguous view/Count cost for ceiling search.
        int[] tree = new int[k + 1];
        int highestBit = 1;
        while ((highestBit << 1) <= k)
        {
            highestBit <<= 1;
        }

        void Update(int i, int delta) {
            for (int pos = i + 1; pos <= k; pos += pos & -pos)
            {
                tree[pos] += delta;
            }
        }

        int PrefixSum(int i) {
            int sum = 0;
            for (int pos = i + 1; pos > 0; pos -= pos & -pos)
            {
                sum += tree[pos];
            }

            return sum;
        }

        int FindKth(int kth) {
            int pos = 0, remaining = kth;
            for (int pw = highestBit; pw > 0; pw >>= 1) {
                int next = pos + pw;
                if (next <= k && tree[next] < remaining)
                {
                    pos = next;
                    remaining -= tree[pos];
                }
            }

            return pos;
        }

        for (int i = 0; i < k; i++)
        {
            Update(i, 1);
        }

        int totalFree = k;

        // Busy servers as a fixed-capacity (k) array-based min-heap keyed by end time, avoiding
        // PriorityQueue's per-comparison Comparer<T>.Default dispatch (same fix as Lc1882).
        long[] busyEnd = new long[k];
        int[] busyServer = new int[k];
        int busySize = 0;

        void BusySiftUp(int idx) {
            while (idx > 0) {
                int parent = (idx - 1) >> 1;
                if (busyEnd[parent] <= busyEnd[idx])
                {
                    break;
                }

                (busyEnd[parent], busyEnd[idx]) = (busyEnd[idx], busyEnd[parent]);
                (busyServer[parent], busyServer[idx]) = (busyServer[idx], busyServer[parent]);
                idx = parent;
            }
        }

        void BusySiftDown(int idx) {
            while (true) {
                int left = 2 * idx + 1, right = left + 1, smallest = idx;
                if (left < busySize && busyEnd[left] < busyEnd[smallest])
                {
                    smallest = left;
                }

                if (right < busySize && busyEnd[right] < busyEnd[smallest])
                {
                    smallest = right;
                }

                if (smallest == idx)
                {
                    break;
                }

                (busyEnd[smallest], busyEnd[idx]) = (busyEnd[idx], busyEnd[smallest]);
                (busyServer[smallest], busyServer[idx]) = (busyServer[idx], busyServer[smallest]);
                idx = smallest;
            }
        }

        for (int i = 0; i < n; i++) {
            long start = arrival[i];

            while (busySize > 0 && busyEnd[0] <= start)
            {
                int freedServer = busyServer[0];
                busySize--;
                busyEnd[0] = busyEnd[busySize];
                busyServer[0] = busyServer[busySize];
                BusySiftDown(0);

                Update(freedServer, 1);
                totalFree++;
            }

            if (totalFree == 0)
            {
                continue;
            }

            int startIdx = i % k;
            int freeBeforeStart = PrefixSum(startIdx - 1);
            int kth = freeBeforeStart + 1;
            int server = kth <= totalFree ? FindKth(kth) : FindKth(1);

            Update(server, -1);
            totalFree--;
            handled[server]++;

            busyEnd[busySize] = start + load[i];
            busyServer[busySize] = server;
            BusySiftUp(busySize);
            busySize++;
        }

        int maxHandled = handled.Max();
        List<int> result = [];
        for (int s = 0; s < k; s++)
        {
            if (handled[s] == maxHandled)
            {
                result.Add(s);
            }
        }

        return result;
    }
}