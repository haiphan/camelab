namespace LeetCode.Library.Algorithms;

public class Lc1882Solution {
    public int[] AssignTasks(int[] servers, int[] tasks) {
        int n = servers.Length;
        int m = tasks.Length;
        int[] result = new int[m];

        // Hand-rolled binary heaps over raw long[] arrays: avoids PriorityQueue's per-comparison
        // Comparer<T>.Default virtual dispatch and dynamic growth; each server lives in exactly one
        // of free/busy at a time, so both arrays are safely fixed-size at n.
        const int IndexBits = 18;
        const long IndexMask = (1L << IndexBits) - 1;

        long[] freeHeap = new long[n];
        int freeSize = n;
        for (int i = 0; i < n; i++) {
            freeHeap[i] = ((long)servers[i] << IndexBits) | (uint)i;
        }

        for (int i = n / 2 - 1; i >= 0; i--) {
            FreeSiftDown(i);
        }

        long[] busyAvail = new long[n];
        long[] busyKey = new long[n];
        int busySize = 0;

        for (int j = 0; j < m; j++) {
            while (busySize > 0 && busyAvail[0] <= j)
            {
                long freedKey = busyKey[0];
                busySize--;
                busyAvail[0] = busyAvail[busySize];
                busyKey[0] = busyKey[busySize];
                BusySiftDown(0);

                freeHeap[freeSize] = freedKey;
                FreeSiftUp(freeSize);
                freeSize++;
            }

            if (freeSize > 0)
            {
                long top = freeHeap[0];
                freeSize--;
                freeHeap[0] = freeHeap[freeSize];
                FreeSiftDown(0);

                int server = (int)(top & IndexMask);
                result[j] = server;

                busyAvail[busySize] = (long)j + tasks[j];
                busyKey[busySize] = top;
                BusySiftUp(busySize);
                busySize++;
            }
            else
            {
                long avail = busyAvail[0];
                long key = busyKey[0];
                busySize--;
                busyAvail[0] = busyAvail[busySize];
                busyKey[0] = busyKey[busySize];
                BusySiftDown(0);

                int server = (int)(key & IndexMask);
                result[j] = server;

                busyAvail[busySize] = avail + tasks[j];
                busyKey[busySize] = key;
                BusySiftUp(busySize);
                busySize++;
            }
        }

        return result;

        void FreeSiftDown(int i) {
            while (true) {
                int left = 2 * i + 1, right = left + 1, smallest = i;
                if (left < freeSize && freeHeap[left] < freeHeap[smallest]) smallest = left;
                if (right < freeSize && freeHeap[right] < freeHeap[smallest]) smallest = right;
                if (smallest == i) break;
                (freeHeap[smallest], freeHeap[i]) = (freeHeap[i], freeHeap[smallest]);
                i = smallest;
            }
        }

        void FreeSiftUp(int i) {
            while (i > 0) {
                int parent = (i - 1) >> 1;
                if (freeHeap[parent] <= freeHeap[i]) break;
                (freeHeap[parent], freeHeap[i]) = (freeHeap[i], freeHeap[parent]);
                i = parent;
            }
        }

        bool BusyLess(int a, int b) => busyAvail[a] != busyAvail[b] ? busyAvail[a] < busyAvail[b] : busyKey[a] < busyKey[b];

        void BusySwap(int a, int b) {
            (busyAvail[a], busyAvail[b]) = (busyAvail[b], busyAvail[a]);
            (busyKey[a], busyKey[b]) = (busyKey[b], busyKey[a]);
        }

        void BusySiftUp(int i) {
            while (i > 0) {
                int parent = (i - 1) >> 1;
                if (!BusyLess(i, parent)) break;
                BusySwap(i, parent);
                i = parent;
            }
        }

        void BusySiftDown(int i) {
            while (true) {
                int left = 2 * i + 1, right = left + 1, smallest = i;
                if (left < busySize && BusyLess(left, smallest)) smallest = left;
                if (right < busySize && BusyLess(right, smallest)) smallest = right;
                if (smallest == i) break;
                BusySwap(smallest, i);
                i = smallest;
            }
        }
    }
}