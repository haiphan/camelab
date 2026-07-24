namespace LeetCode.Library.Algorithms;

public class Lc3514Solution {
    public int UniqueXorTriplets(int[] nums) {
        long[] f = new long[1 << 11];
        int maxv = 0;
        foreach (int v in nums) {
            maxv |= v;
            f[v] = 1;
        }
        // bumber of bits needed to represent maxv
        int shift = (int)Math.Log2(maxv) + 1;
        int n = 1 << shift;
        void fwht() { // fast walsh-hadamard transform
            // O(nlogn) convolution
            for (int k = 1; k*2 <= n; k *= 2) {
                for (int i = 0; i < n; i += k * 2) {
                    for (int j = 0; j < k; j++) {
                        long u = f[i+j], v = f[i+j+k];
                        f[i+j] = u + v;
                        f[i+j+k] = u - v;
                    }
                }
            }
        }
        fwht(); // transform
        for (int i = 0; i < n; i++) {
            // f[i]^3 to find triplets
            // if the question asked for quadruplets, just f[i]^4
            f[i] *= f[i] * f[i];
        }
        fwht(); // inverse transform
        int count = 0;
        for (int i = 0; i < n; i++) {
            // same as: if f[i] >= n { count++ }
            count += (int)Math.Min(1L, f[i]>>shift);
        }
        return count;
    }
}