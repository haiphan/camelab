namespace LeetCode.Library.Algorithms;

public class Lc3525Solution {
    public int[] ResultArray(int[] nums, int k, int[][] queries) {
        int n = nums.Length;
        int m = queries.Length;
        int[] result = new int[m];

        int size = 1;
        while (size < n) size <<= 1;

        int[] products = new int[size * 2];
        int[] prefixCounts = new int[size * 2 * k];
        for (int i = 0; i < n; i++) {
            int node = size + i;
            int remainder = nums[i] % k;
            products[node] = remainder;
            prefixCounts[node * k + remainder] = 1;
        }

        for (int node = size - 1; node > 0; node--) {
            Merge(node, node * 2, node * 2 + 1, k, products, prefixCounts);
        }

        for (int queryIndex = 0; queryIndex < m; queryIndex++) {
            int[] query = queries[queryIndex];
            int index = query[0];
            int value = query[1] % k;
            int start = query[2];
            int remainder = query[3];

            int node = size + index;
            products[node] = value;
            Array.Clear(prefixCounts, node * k, k);
            prefixCounts[node * k + value] = 1;
            for (node >>= 1; node > 0; node >>= 1) {
                Merge(node, node * 2, node * 2 + 1, k, products, prefixCounts);
            }

            int left = size + start;
            int right = size + n;
            int leftProduct = 1 % k;
            int rightProduct = 1 % k;
            int[] leftCounts = new int[k];
            int[] leftScratch = new int[k];
            int[] rightCounts = new int[k];
            int[] rightScratch = new int[k];

            while (left < right) {
                if ((left & 1) != 0) {
                    AppendNode(leftProduct, leftCounts, left, k, products, prefixCounts, out leftProduct, leftScratch);
                    (leftCounts, leftScratch) = (leftScratch, leftCounts);
                    left++;
                }

                if ((right & 1) != 0) {
                    --right;
                    PrependNode(right, rightProduct, rightCounts, k, products, prefixCounts, out rightProduct, rightScratch);
                    (rightCounts, rightScratch) = (rightScratch, rightCounts);
                }

                left >>= 1;
                right >>= 1;
            }

            int[] counts = new int[k];
            MergeCounts(leftProduct, leftCounts, rightProduct, rightCounts, k, counts, out _);
            result[queryIndex] = counts[remainder];
        }

        return result;
    }

    private static void Merge(int destination, int left, int right, int k, int[] products, int[] prefixCounts) {
        int leftProduct = products[left];
        products[destination] = leftProduct * products[right] % k;
        int destinationOffset = destination * k;
        int leftOffset = left * k;
        int rightOffset = right * k;

        Array.Clear(prefixCounts, destinationOffset, k);
        for (int remainder = 0; remainder < k; remainder++) {
            prefixCounts[destinationOffset + remainder] = prefixCounts[leftOffset + remainder];
        }

        for (int remainder = 0; remainder < k; remainder++) {
            int shifted = leftProduct * remainder % k;
            prefixCounts[destinationOffset + shifted] += prefixCounts[rightOffset + remainder];
        }
    }

    private static void AppendNode(
        int leftProduct,
        int[] leftCounts,
        int node,
        int k,
        int[] products,
        int[] prefixCounts,
        out int product,
        int[] destinationCounts) {
        for (int remainder = 0; remainder < k; remainder++) {
            destinationCounts[remainder] = leftCounts[remainder];
        }

        int sourceOffset = node * k;
        for (int remainder = 0; remainder < k; remainder++) {
            int shifted = leftProduct * remainder % k;
            destinationCounts[shifted] += prefixCounts[sourceOffset + remainder];
        }

        product = leftProduct * products[node] % k;
    }

    private static void PrependNode(
        int node,
        int rightProduct,
        int[] rightCounts,
        int k,
        int[] products,
        int[] prefixCounts,
        out int product,
        int[] destinationCounts) {
        int nodeOffset = node * k;
        for (int remainder = 0; remainder < k; remainder++) {
            destinationCounts[remainder] = prefixCounts[nodeOffset + remainder];
        }

        for (int remainder = 0; remainder < k; remainder++) {
            int shifted = products[node] * remainder % k;
            destinationCounts[shifted] += rightCounts[remainder];
        }

        product = products[node] * rightProduct % k;
    }

    private static void MergeCounts(
        int leftProduct,
        int[] leftCounts,
        int rightProduct,
        int[] rightCounts,
        int k,
        int[] destinationCounts,
        out int product) {
        for (int remainder = 0; remainder < k; remainder++) {
            destinationCounts[remainder] = leftCounts[remainder];
        }

        for (int remainder = 0; remainder < k; remainder++) {
            int shifted = leftProduct * remainder % k;
            destinationCounts[shifted] += rightCounts[remainder];
        }

        product = leftProduct * rightProduct % k;
    }
}