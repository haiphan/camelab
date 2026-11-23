namespace LeetCode.Library.Algorithms;

public class Lc1352Solution {
    // At most 4 * 1e4 calls are made in total, so the prefix list never needs to
    // grow past that size; preallocating avoids backing-array reallocations.
    private const int MaxCalls = 40_000 + 1;

    // prefixProducts[i] holds the product of all numbers since the last zero,
    // up to and including the i-th addition. prefixProducts[0] == 1 is a sentinel.
    private List<int> prefixProducts = new List<int>(MaxCalls) { 1 };

    public void Add(int num) {
        if (num == 0) {
            // A zero wipes out any product spanning it, so restart the prefix list.
            // Clear (rather than reallocate) to reuse the preallocated backing array.
            prefixProducts.Clear();
            prefixProducts.Add(1);
        } else {
            prefixProducts.Add(prefixProducts[^1] * num);
        }
    }

    public int GetProduct(int k) {
        // If k reaches past the last reset point, a zero is within the last k numbers.
        if (k >= prefixProducts.Count) {
            return 0;
        }
        return prefixProducts[^1] / prefixProducts[prefixProducts.Count - 1 - k];
    }
}